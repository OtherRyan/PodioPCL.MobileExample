using PodioPCL.MobileExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.Pages
{
	public partial class SpaceDetailPage
	{
		public SpaceDetailViewModel ViewModel { get; set; }

		public SpaceDetailPage(SpaceDetailViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
