using PodioPCL.MobileExample.Pages;
using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ViewModelNavigation<ViewModelBase>))]
namespace PodioPCL.MobileExample
{
	/// <summary>
	/// THe App Class creates an Xamarin Forms Application to be called from each Platform.
	/// </summary>
	public class App : Application
	{
		private ViewModelNavigation<ViewModelBase> _Nav;
		private Podio _Podio;
		private LoginViewModel _LoginViewModel;
		private OrgListViewModel _OrgListViewModel;

		/// <summary>
		/// Initializes a new instance of the <see cref="App"/> class.
		/// </summary>
		public App()
		{
			//Setup navigation
			MainPage = new NavigationPage();
			MainPage.PropertyChanged += MainPage_PropertyChanged;
			_Nav = DependencyService.Get<ViewModelNavigation<ViewModelBase>>(DependencyFetchTarget.GlobalInstance);
			_Nav.BasePage = MainPage;

			//create the first Podio instance.
			_Podio = DependencyService.Get<PodioExample>(DependencyFetchTarget.GlobalInstance).Podio;

			//send the first page, you must wait for it to finish.
			if (!_Podio.IsAuthenticated())
			{
				_LoginViewModel = new LoginViewModel();
				var pushTask = _Nav.PushViewModelAsync(_LoginViewModel);
				pushTask.Wait();
			}
			else
			{
				_OrgListViewModel = new OrgListViewModel();
				var pushTask = _Nav.PushViewModelAsync(_OrgListViewModel);
				pushTask.Wait();
			}

		}

		void MainPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == NavigationPage.CurrentPageProperty.PropertyName && sender != null && sender.GetType() == typeof(NavigationPage))
			{
				var navPage = ((NavigationPage)sender);
				if (navPage.CurrentPage != null && !string.IsNullOrEmpty(navPage.CurrentPage.Icon))
				{
					NavigationPage.SetTitleIcon(navPage, navPage.CurrentPage.Icon);
				}
			}
		}
	}
}
