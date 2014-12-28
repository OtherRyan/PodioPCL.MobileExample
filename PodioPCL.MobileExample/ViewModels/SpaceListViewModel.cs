using PodioPCL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.ViewModels
{
	/// <summary>
	/// View model for listing <see cref="Models.Space"/>'s.
	/// </summary>
	public class SpaceListViewModel : ListViewModelBase<Models.Space>
	{
		/// <summary>
		/// Gets or sets the Organization ID this <see cref="SpaceListViewModel"/> represents.
		/// </summary>
		/// <value>The Organization ID.</value>
		public int OrgId { get; set; }


		/// <summary>
		/// Initializes a new instance of the <see cref="SpaceListViewModel"/> class.
		/// </summary>
		/// <param name="orgId">The Organization ID.</param>
		public SpaceListViewModel(int orgId)
		{
			OrgId = orgId;
			LoadingMessage = "Downloading workspaces for the organization.";
		}


		/// <summary>
		/// When implemented, this method gets a <see cref="List{T}" /> of <see cref="PodioPCL.Models.Space" />'s.
		/// </summary>
		/// <param name="token">The cancellation token for use with web accessor methods.</param>
		/// <returns>Task&lt;List&lt;PodioPCL.Models.Space&gt;&gt;.</returns>
		public override async Task<List<Models.Space>> GetModels(CancellationToken token)
		{
			PodioException lastException = null;
			for (int i = 0; i < 3; i++)
			{
				try
				{
					return await _Podio.OrganizationService.GetSpacesOnOrganization(OrgId);
				}
				catch (PodioException ex)
				{
					lastException = ex;
				}
			}
			throw lastException ?? new Exception("Unknown error retrieving models");
		}

		/// <summary>
		/// Call this method from a child class to notify that a change happened on a property.
		/// </summary>
		/// <param name="propertyName">The name of the property that changed.</param>
		/// <remarks>A <see cref="T:Xamarin.Forms.BindableProperty" /> triggers this by itself. An inheritor only needs to call this for properties without <see cref="T:Xamarin.Forms.BindableProperty" /> as the backend store.</remarks>
		protected override async void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == ListViewModelBase<Models.Application>.SelectedItemProperty.PropertyName)
			{
				if (SelectedItem != null)
				{
					_Log.WriteLine("Organization Selected: {0}", SelectedItem.OrgId.ToString());
					await _Nav.PushViewModelAsnc(new SpaceDetailViewModel(SelectedItem));
				}
				await Task.Delay(200);
				SelectedItem = null;
			}
		}
	}
}
