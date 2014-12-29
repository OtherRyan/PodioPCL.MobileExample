using Android.Util;
using PodioPCL.MobileExample.Droid.Interfaces;
using PodioPCL.MobileExample.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Log_Android))]
namespace PodioPCL.MobileExample.Droid.Interfaces
{
	public class Log_Android : ILog
	{
		public void WriteLine(string message, params object[] args)
		{
			Log.Info("PodioPCL.MobileExample", string.Format(message, args));
		}
	}
}