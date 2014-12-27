using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PodioPCL.MobileExample.Interfaces;
using PodioPCL.MobileExample.Droid.Interfaces;

namespace PodioPCL.MobileExample.Droid
{
	[Activity(Label = "PodioPCL.MobileExample", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsApplicationActivity
	{
		public App App { get; set; }

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Xamarin.Forms.Forms.Init(this, bundle);

			Settings_Android settings = (Settings_Android)DependencyService.Get<ISettings>(DependencyFetchTarget.GlobalInstance);
			settings.Context = this;

			App = new App();
			
			LoadApplication(App);
		}
	}
}

