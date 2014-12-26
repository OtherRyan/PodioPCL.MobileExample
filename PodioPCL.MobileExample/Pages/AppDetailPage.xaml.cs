using PodioPCL.MobileExample.ViewModels;
using System;

namespace PodioPCL.MobileExample.Pages
{
	public partial class AppDetailPage
	{
		AppDetailViewModel ViewModel { get; set; }

		public AppDetailPage(AppDetailViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
