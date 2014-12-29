using PodioPCL.MobileExample.Pages;
using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;

[assembly: ViewModel(typeof(LoginViewModel), typeof(LoginPage))]
namespace PodioPCL.MobileExample.Pages
{
	/// <summary>
	/// Class LoginPage.
	/// </summary>
	public partial class LoginPage
	{
		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		/// <value>The view model.</value>
		public LoginViewModel ViewModel { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginPage"/> class.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		public LoginPage(LoginViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
