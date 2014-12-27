using PodioPCL.MobileExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.Pages
{
	/// <summary>
	/// Class OrgDetailPage.
	/// </summary>
	public partial class OrgDetailPage
	{
		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		/// <value>The view model.</value>
		public OrgDetailViewModel ViewModel { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="OrgDetailPage"/> class.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		public OrgDetailPage(OrgDetailViewModel viewModel)
		{
			BindingContext = ViewModel = viewModel;

			Appearing += new EventHandler(ViewModel.OnAppearing);
			Disappearing += new EventHandler(ViewModel.OnDisappearing);

			InitializeComponent();
		}
	}
}
