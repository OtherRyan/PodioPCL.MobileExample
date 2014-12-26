using PodioPCL.MobileExample.Interfaces;
using PodioPCL.Utils.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.Utility
{
	public class LocalAuthStore : IAuthStore
	{
		private ISettings _Settings;
		private static readonly string AuthStoreSettingName = "LocalAuthStore.AuthStore";

		public LocalAuthStore()
		{
			_Settings = DependencyService.Get<ISettings>(DependencyFetchTarget.GlobalInstance);
		}

		public PodioOAuth Get()
		{
			return _Settings.GetSetting(AuthStoreSettingName, new PodioOAuth());
		}

		public void Set(PodioOAuth podioOAuth)
		{
			_Settings.SetSetting(AuthStoreSettingName, podioOAuth);
		}
	}
}
