using PodioPCL.MobileExample.Utility;
using Xamarin.Forms;

[assembly: Dependency(typeof(PodioExample))]
namespace PodioPCL.MobileExample.Utility
{
	public class PodioExample
	{
		public Podio Podio
		{
			get
			{
				if (_Podio == null)
				{
					_Podio = new Podio(Settings.ClientId, Settings.ClientSecret, new LocalAuthStore());
				}
				return _Podio;
			}
		}
		private Podio _Podio;

		public static class Settings
		{
			public static readonly string ClientId = "";
			public static readonly string ClientSecret = "";
		}
	}
}
