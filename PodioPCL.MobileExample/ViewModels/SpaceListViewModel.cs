using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.ViewModels
{
	public class SpaceListViewModel : ListViewModelBase<Models.Space>
	{
		public int OrgId { get; set; }

		public SpaceListViewModel(int orgId)
		{
			OrgId = orgId;
		}

		public override async Task<List<Models.Space>> GetModels(CancellationToken token)
		{
			return await _Podio.OrganizationService.GetSpacesOnOrganization(OrgId);
		}

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
