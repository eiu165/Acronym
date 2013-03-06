//
// C# port of the textview sample
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using System;
using Abbreviation;

namespace Acronym {
	
	public partial class TextViewController : UIViewController {
		UITextView label;
		NSObject obs1, obs2;

		private Entry _entry; 

		public TextViewController(Entry entry)
		{
			_entry = entry;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			Title = this._entry.Acronym;
			label = new UITextView (View.Frame){
				TextColor = UIColor.Black,
				Font = UIFont.FromName ("Arial", 18f),
				BackgroundColor = UIColor.White,  
				ReturnKeyType = UIReturnKeyType.Default,
				KeyboardType = UIKeyboardType.Default,
				ScrollEnabled = true, 
				Text = this._entry.Description,  
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight,
			};  
			View.AddSubview (label);
		}
	
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
	
			obs1 = NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.WillShowNotification, delegate (NSNotification n){
				var kbdRect = UIKeyboard.BoundsFromNotification (n);
				var duration = UIKeyboard.AnimationDurationFromNotification (n);
				var frame = View.Frame;
				frame.Height -= kbdRect.Height;
				UIView.BeginAnimations ("ResizeForKeyboard");
				UIView.SetAnimationDuration (duration);
				View.Frame = frame;
				UIView.CommitAnimations ();
				});
	
			obs2 = NSNotificationCenter.DefaultCenter.AddObserver ("UIKeyboardWillHideNotification", delegate (NSNotification n){
				var kbdRect = UIKeyboard.BoundsFromNotification (n);
				var duration = UIKeyboard.AnimationDurationFromNotification (n);
				var frame = View.Frame;
				frame.Height += kbdRect.Height;
				UIView.BeginAnimations ("ResizeForKeyboard");
				UIView.SetAnimationDuration (duration);
				View.Frame = frame;
				UIView.CommitAnimations ();
			});
		}
	
		public override void ViewDidDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			NSNotificationCenter.DefaultCenter.RemoveObserver (obs1);
			NSNotificationCenter.DefaultCenter.RemoveObserver (obs2);
		}
	}
}
