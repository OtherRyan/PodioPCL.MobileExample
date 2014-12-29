using PodioPCL.MobileExample.Pages;
using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;

[assembly: ViewModel(typeof(AppListViewModel), typeof(AppListPage))]
namespace PodioPCL.MobileExample.Pages
{
	/// <summary>
	/// Class AppListPage.
	/// </summary>
	public partial class AppListPage
	{
		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		/// <value>The view model.</value>
		public AppListViewModel ViewModel { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AppListPage"/> class.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		public AppListPage(AppListViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
