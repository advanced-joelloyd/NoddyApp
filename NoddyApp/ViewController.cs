using System;
using System.Collections.Generic;

using UIKit;
using Foundation;

namespace NoddyApp
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
			this.PhoneNumbers = new List<string> ();	
		}

		string translatedNumber = "";

		public List<string> PhoneNumbers { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			TranslateButton.TouchUpInside += (object sender, EventArgs e) => {
				// Convert the phone number with text to a number 
				// using PhoneTranslator.cs
				translatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text); 

				// Dismiss the keyboard if text field was tapped
				PhoneNumberText.ResignFirstResponder ();

				if (translatedNumber == "") {
					CallButton.SetTitle ("Call ", UIControlState.Normal);
					CallButton.Enabled = false;
				} else {
					CallButton.SetTitle ("Call " + translatedNumber, 
						UIControlState.Normal);
					CallButton.Enabled = true;
				}
			};

			CallButton.TouchUpInside += (object sender, EventArgs e) => {

				PhoneNumbers.Add(translatedNumber);

				// Use URL handler with tel: prefix to invoke Apple's Phone app...
				var url = new NSUrl ("tel:" + translatedNumber);


				// ...otherwise show an alert dialog                
				if (!UIApplication.SharedApplication.OpenUrl (url)) {
					var alert = UIAlertController.Create ("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			};

			CallHistoryButton.TouchUpInside += (object sender, EventArgs e) =>{
				// Launches a new instance of CallHistoryController
				CallHistoryController callHistory = this.Storyboard.InstantiateViewController ("CallHistoryController") as CallHistoryController;
				if (callHistory != null) {
					callHistory.PhoneNumbers = PhoneNumbers;
					this.NavigationController.PushViewController (callHistory, true);
				}
			};
		}

//		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
//		{
//			base.PrepareForSegue (segue, sender);
//
//			var callHistoryController = segue.DestinationViewController as CallHistoryController;
//			if (callHistoryController != null) {
//				callHistoryController.PhoneNumbers = this.PhoneNumbers;
//			}
//		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

