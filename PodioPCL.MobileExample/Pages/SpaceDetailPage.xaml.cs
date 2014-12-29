using PodioPCL.MobileExample.Pages;
using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;

[assembly: ViewModel(typeof(SpaceDetailViewModel), typeof(SpaceDetailPage))]
namespace PodioPCL.MobileExample.Pages
{
	/// <summary>
	/// Class SpaceDetailPage.
	/// </summary>
	public partial class SpaceDetailPage
	{
		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		/// <value>The view model.</value>
		public SpaceDetailViewModel ViewModel { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SpaceDetailPage"/> class.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		public SpaceDetailPage(SpaceDetailViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
