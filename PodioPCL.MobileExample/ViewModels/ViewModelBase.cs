using PodioPCL.MobileExample.Interfaces;
using PodioPCL.MobileExample.Utility;
using System;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	public class ViewModelBase : BindableObject
	{
		protected ILog _Log;
		protected Podio _Podio;
		protected ViewModelNavigation _Nav;

		public ViewModelBase()
		{
			_Log = DependencyService.Get<ILog>(DependencyFetchTarget.GlobalInstance);
			_Podio = DependencyService.Get<PodioExample>(DependencyFetchTarget.GlobalInstance).Podio;
			_Nav = DependencyService.Get<ViewModelNavigation>(DependencyFetchTarget.GlobalInstance);
		}

		public virtual void OnAppearing(object sender, EventArgs e) { }

		public virtual void OnDisappearing(object sender, EventArgs e) { }

	}
}
