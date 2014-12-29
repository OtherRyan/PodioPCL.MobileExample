using Android.App;
using Android.Content.PM;
using Android.OS;
using PodioPCL.MobileExample.Droid.Interfaces;
using PodioPCL.MobileExample.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace PodioPCL.MobileExample.Droid
{
	[Activity(Label = "Podio PCL", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, Theme="@android:style/Theme.Holo.Light")]
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

