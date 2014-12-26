using PodioPCL.MobileExample.Pages;
using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PodioPCL.MobileExample
{
	public class App : Application
	{
		private ViewModelNavigation _Nav;
		private Podio _Podio;
		private LoginViewModel _LoginViewModel;
		private OrgListViewModel _OrgListViewModel;

		public App()
		{
			//Setup navigation
			MainPage = new NavigationPage();
			_Nav = DependencyService.Get<ViewModelNavigation>(DependencyFetchTarget.GlobalInstance);
			_Nav.BasePage = MainPage;

			//Register page types
			_Nav.RegisterPage<LoginViewModel, LoginPage>();
			_Nav.RegisterPage<OrgListViewModel, OrgListPage>();
			_Nav.RegisterPage<OrgDetailViewModel, OrgDetailPage>();
			_Nav.RegisterPage<SpaceListViewModel, SpaceListPage>();
			_Nav.RegisterPage<SpaceDetailViewModel, SpaceDetailPage>();
			_Nav.RegisterPage<AppListViewModel, AppListPage>();
			_Nav.RegisterPage<AppDetailViewModel, AppDetailPage>();
			_Nav.RegisterPage<ItemListViewModel, ItemListPage>();

			//create the first Podio instance.
			_Podio = DependencyService.Get<PodioExample>(DependencyFetchTarget.GlobalInstance).Podio;

			//send the first page, you must wait for it to finish.
			if (!_Podio.IsAuthenticated())
			{
				_LoginViewModel = new LoginViewModel();
				var pushTask = _Nav.PushViewModelAsnc(_LoginViewModel);
				pushTask.Wait();
			}
			else
			{
				_OrgListViewModel = new OrgListViewModel();
				var pushTask = _Nav.PushViewModelAsnc(_OrgListViewModel);
				pushTask.Wait();
			}

		}
	}
}
