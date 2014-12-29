using PodioPCL.MobileExample.Pages;
using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;

[assembly: ViewModel(typeof(AppDetailViewModel), typeof(AppDetailPage))]
namespace PodioPCL.MobileExample.Pages
{
	/// <summary>
	/// Class AppDetailPage.
	/// </summary>
	public partial class AppDetailPage
	{
		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		/// <value>The view model.</value>
		public AppDetailViewModel ViewModel { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AppDetailPage"/> class.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		public AppDetailPage(AppDetailViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
