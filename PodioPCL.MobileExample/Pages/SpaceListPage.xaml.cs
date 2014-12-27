using PodioPCL.MobileExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.Pages
{
	/// <summary>
	/// Class SpaceListPage.
	/// </summary>
	public partial class SpaceListPage
	{
		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		/// <value>The view model.</value>
		public SpaceListViewModel ViewModel { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SpaceListPage"/> class.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		public SpaceListPage(SpaceListViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
