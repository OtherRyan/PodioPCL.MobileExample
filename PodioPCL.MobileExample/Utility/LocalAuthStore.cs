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
	/// <summary>
	/// An implementation of <see cref="T:PodioPCL.Authentication.IAuthStore"/> using the Mobile <see cref="PodioPCL.MobileExample.Interfaces.ISettings"/> Interface.
	/// </summary>
	public class LocalAuthStore : IAuthStore
	{
		private ISettings _Settings;
		private static readonly string AuthStoreSettingName = "LocalAuthStore.AuthStore";

		/// <summary>
		/// Initializes a new instance of the <see cref="LocalAuthStore"/> class.
		/// </summary>
		public LocalAuthStore()
		{
			_Settings = DependencyService.Get<ISettings>(DependencyFetchTarget.GlobalInstance);
		}

		/// <summary>
		/// Get PodioOAuth object from the <see cref="T:PodioPCL.Authentication.IAuthStore">Authentication Store</see>
		/// </summary>
		/// <returns>PodioOAuth.</returns>
		public PodioOAuth Get()
		{
			return _Settings.GetSetting(AuthStoreSettingName, new PodioOAuth());
		}

		/// <summary>
		/// Saves the PodioOAuth in the <see cref="T:PodioPCL.Authentication.IAuthStore">Authentication Store</see>
		/// </summary>
		/// <param name="podioOAuth">The podio o authentication.</param>
		public void Set(PodioOAuth podioOAuth)
		{
			_Settings.SetSetting(AuthStoreSettingName, podioOAuth);
		}
	}
}
