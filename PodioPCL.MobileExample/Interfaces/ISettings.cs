using PodioPCL.MobileExample.Interfaces;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.Interfaces
{
	/// <summary>
	/// The ISettings interface to save any object by way of Json Serialization.
	/// </summary>
	public interface ISettings
	{
		/// <summary>
		/// Gets the setting.
		/// </summary>
		/// <typeparam name="TSetting">The type of the setting.</typeparam>
		/// <param name="name">The name.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>TSetting.</returns>
		TSetting GetSetting<TSetting>(string name, TSetting defaultValue);

		/// <summary>
		/// Sets the setting.
		/// </summary>
		/// <typeparam name="TSetting">The type of the setting.</typeparam>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		void SetSetting<TSetting>(string name, TSetting value);
	}
}
