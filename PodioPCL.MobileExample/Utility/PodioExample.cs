using PodioPCL.MobileExample.Utility;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(PodioExample))]
namespace PodioPCL.MobileExample.Utility
{
	/// <summary>
	/// A helper class to create the <see cref="PodioPCL.Podio"/> client with the correct <see cref="PodioPCL.MobileExample.Utility.PodioExample.Settings.ClientId"/> and <see cref="PodioPCL.MobileExample.Utility.PodioExample.Settings.ClientSecret"/>.
	/// </summary>
	public class PodioExample
	{
		/// <summary>
		/// Gets the <see cref="PodioPCL.Podio" /> API client.
		/// </summary>
		/// <value>Podio client</value>
		public Podio Podio
		{
			get
			{
				if (_Podio == null)
				{
					if (string.IsNullOrEmpty(Settings.ClientId) || string.IsNullOrEmpty(Settings.ClientSecret))
					{
						throw new ArgumentNullException("Podio ClientId and ClientSecret must be set inside the PodioPCL.MobileExample.Utility.PodioExample class");
					}
					_Podio = new Podio(Settings.ClientId, Settings.ClientSecret, new LocalAuthStore());
				}
				return _Podio;
			}
		}
		private Podio _Podio;

		/// <summary>
		/// Setings for the <see cref="PodioPCL.Podio"/> client.
		/// </summary>
		public static class Settings
		{
			/// <summary>
			/// The Client Id from Podio settings.
			/// </summary>
			public static readonly string ClientId = "";
			/// <summary>
			/// The Client Secret from Podio settings.
			/// </summary>
			public static readonly string ClientSecret = "";
		}
	}
}
