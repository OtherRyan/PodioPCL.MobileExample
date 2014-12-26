using PodioPCL.MobileExample.ViewModels;
using System;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.Pages
{
	public partial class ItemListPage
	{
		public ItemListViewModel ViewModel { get; set; }

		public ItemListPage(ItemListViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();

			ListView.ItemAppearing += ListView_ItemAppearing;
		}

		void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			ViewModel.OnItemAppearing((Models.Item)e.Item);
		}
	}
}
