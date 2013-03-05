using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Acronym.Screens.iPhone.Search;

namespace Acronym
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		NavViewController viewController;
		UINavigationController  rootNavigationController;
		//SearchScreen viewController;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			//RegisterDefaultsFromSettingsBundle();
			window = new UIWindow (UIScreen.MainScreen.Bounds);


			//---- instantiate a new navigation controller
			this.rootNavigationController = new UINavigationController();
			
			//viewController = new SearchScreen ();
			viewController = new NavViewController ();

			//---- add the home screen to the navigation controller (it'll be the top most screen)
			this.rootNavigationController.PushViewController(viewController, false);

			//---- set the root view controller on the window. the nav controller will handle the rest
			this.window.RootViewController = this.rootNavigationController; 
			window.MakeKeyAndVisible ();
			
			return true;
		} 
	}
}

