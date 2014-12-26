using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using PodioPCL.MobileExample.Droid.Interfaces;
using PodioPCL.MobileExample.Interfaces;
using Android.Util;

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