using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace Acronym
{

	/// <summary>
	/// A simple table source that displays a list of strings
	/// </summary>
	public class WordsTableSource : UITableViewSource
	{
		private UIViewController _viewController;
		protected string cellIdentifier = "wordsCell";
		public WordsTableSource(UIViewController  viewController)
		{
			this._viewController = viewController;
		}
		/// <summary>
		/// The words to display in the table
		/// </summary>
		public List<string> Words
		{
			get { return words; }
			set { words = value; }
		}
		protected List<string> words = new List<string>();
		
		/// <summary>
		/// called by the table to determine how many rows to create, in our case, it's the number 
		/// of words.
		/// </summary>
		public override int RowsInSection (UITableView tableview, int section)
		{
			return words.Count;
		}


		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{

			Console.WriteLine ("MonoCatalog: Row selected {0} acronym selected {1}", indexPath.Row, Words[indexPath.Row]);

			//var cont = new TextViewController("aaaaa");
			//this._viewController.NavigationController.PushViewController (cont, true); 
		}
		
		/// <summary>
		/// called by the table to determine how many sections to create, in this case, we just have one
		/// </summary>
		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}
		
		/// <summary>
		/// called by the table to generate the cell to display. in this case, it's very simple
		/// and just displays the word.
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// declare vars
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			string word = words[indexPath.Row];
			
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			
			// set the item text
			cell.TextLabel.Text = word;
			
			return cell;
		}
	}
}

