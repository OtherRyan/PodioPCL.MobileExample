using Android.Content;
using Android.Preferences;
using Newtonsoft.Json;
using PodioPCL.MobileExample.Droid.Interfaces;
using PodioPCL.MobileExample.Interfaces;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(Settings_Android))]
namespace PodioPCL.MobileExample.Droid.Interfaces
{
	public class Settings_Android : ISettings
	{
		public Context Context { get; set; }
		public ISharedPreferences SharedPreferences
		{
			get
			{
				if (_SharedPreferences == null)
				{
					if (Context == null)
					{
						throw new ArgumentNullException("Context in Settings_Android is null.");
					}
					_SharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Context);
				}
				return _SharedPreferences;
			}
		}

		private ISharedPreferences _SharedPreferences;

		public T GetSetting<T>(string name, T defaultValue)
		{
			var setting = SharedPreferences.GetString(name, "");
			if (string.IsNullOrEmpty(setting))
			{
				return defaultValue;
			}
			return JsonConvert.DeserializeObject<T>(setting);
		}

		public void SetSetting<T>(string name, T value)
		{
			var edit = SharedPreferences.Edit();
			edit.PutString(name, JsonConvert.SerializeObject(value));
			edit.Commit();
			edit.Dispose();
		}
	}
}