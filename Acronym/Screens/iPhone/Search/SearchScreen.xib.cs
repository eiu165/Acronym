using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;
using Abbreviation; 
using System.Xml.Linq;

namespace Acronym.Screens.iPhone.Search
{
	public partial class SearchScreen : UIViewController
	{
		#region Private Variables
		/// <summary>
		/// the dictionary that will hold our words
		/// </summary>
		List<Entry> _dictionary = null;
		
		/// <summary>
		/// The table source that will hold our matches
		/// </summary>
		WordsTableSource _tableSource = null;
		#endregion

		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public SearchScreen (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public SearchScreen (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public SearchScreen () : base("SearchScreen", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			NavigationItem.Title = "Search Bar Example";
			
			// load our dictonary words
			LoadWords();

			 
			// wire up the search button clicked handler to hide the keyboard
			srchMain.SearchButtonClicked += (s, e) => { srchMain.ResignFirstResponder(); }; 
			
			// refine the search results every time the text changes
			srchMain.TextChanged += (s, e) => { RefineSearchItems(); };
		}
		
		/// <summary>
		/// This loads our dictionary of words into our _dictionary object.
		/// </summary>
		protected void LoadWords ()
		{ 
			var doc = XDocument.Load ("Content/EntryList.xml");
			_dictionary = doc.Descendants ("Entry")
				.Select (o => new Entry
				{
					Acronym = (string)o.Attribute("Acronym"),
					AcronymLower = o.Attribute("Acronym").ToString().ToLower(),
					Discription = (string)o.Attribute("Discription") 
				}).ToList ();
			// create our table source and bind it to the table
			_tableSource = new WordsTableSource();
			tblMain.Source = _tableSource;
			_tableSource.Words = _dictionary.Select(x=> x.Acronym).ToList();
			tblMain.ReloadData();	 
		}

		/// <summary>
		/// is called when the text in the search box text changes. i use some simple
		/// LINQ to refine the word list in our table source
		/// </summary>
		protected void RefineSearchItems()
		{
			// select our words
			_tableSource.Words = _dictionary
				.Where(w => w.AcronymLower.Contains(srchMain.Text.ToLower ()))
				.Select (w=> w.Acronym)
				.ToList();
			
			// refresh the table
			tblMain.ReloadData();
			
		}

		
	}
}

