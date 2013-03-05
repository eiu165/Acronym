
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Acronym
{
	public partial class NavViewController : UIViewController
	{
		TextViewController _textViewController ;
		public NavViewController () : base ("NavViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			button.TouchUpInside += (sender, e) => 
			{ 
				_textViewController = new TextViewController("aaaaa");
				this.NavigationController.PushViewController (_textViewController, true); 
			};

		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			this.NavigationController.SetNavigationBarHidden(true, animated);
		}
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear(animated);
			this.NavigationController.SetNavigationBarHidden(false, animated);
		} 
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

