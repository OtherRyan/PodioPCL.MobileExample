using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace PodioPCL.MobileExample.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{

		public App Application { get; set; }

		public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
		{

			Forms.Init();

			Application = new App();

			LoadApplication(Application);

			return base.FinishedLaunching(uiApplication, launchOptions);
		}
	}
}
