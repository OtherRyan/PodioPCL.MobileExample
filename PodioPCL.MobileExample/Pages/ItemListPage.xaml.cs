using PodioPCL.MobileExample.Pages;
using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;
using Xamarin.Forms;

[assembly: ViewModel(typeof(ItemListViewModel), typeof(ItemListPage))]
namespace PodioPCL.MobileExample.Pages
{
	/// <summary>
	/// Class ItemListPage.
	/// </summary>
	public partial class ItemListPage
	{
		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		/// <value>The view model.</value>
		public ItemListViewModel ViewModel { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemListPage"/> class.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		public ItemListPage(ItemListViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();

			ListView.ItemAppearing += _ListView_ItemAppearing;
		}

		private void _ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			ViewModel.OnItemAppearing((Models.Item)e.Item);
		}
	}
}
