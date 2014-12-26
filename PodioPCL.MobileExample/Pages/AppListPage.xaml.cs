using PodioPCL.MobileExample.ViewModels;
using System;

namespace PodioPCL.MobileExample.Pages
{
	public partial class AppListPage
	{
		public AppListViewModel ViewModel { get; set; }

		public AppListPage(AppListViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
