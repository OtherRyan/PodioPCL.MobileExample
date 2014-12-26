using PodioPCL.MobileExample.Interfaces;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.Interfaces
{
	public interface ISettings
	{
		T GetSetting<T>(string name, T defaultValue);
		void SetSetting<T>(string name, T value);
	}
}
