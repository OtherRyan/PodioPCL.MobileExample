using PodioPCL.MobileExample.Pages;
using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;

[assembly: ViewModel(typeof(OrgListViewModel), typeof(OrgListPage))]
namespace PodioPCL.MobileExample.Pages
{
	/// <summary>
	/// Class OrgListPage.
	/// </summary>
	public partial class OrgListPage
	{
		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		/// <value>The view model.</value>
		public OrgListViewModel ViewModel { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="OrgListPage"/> class.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		public OrgListPage(OrgListViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
