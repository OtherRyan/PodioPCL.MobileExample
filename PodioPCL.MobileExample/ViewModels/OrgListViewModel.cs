using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	public class OrgListViewModel : ListViewModelBase<Models.Organization>
	{
		public override async Task<List<Models.Organization>> GetModels(CancellationToken token)
		{
			return await _Podio.OrganizationService.GetOrganizations();
		}

		protected override async void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == ListViewModelBase<Models.Application>.SelectedItemProperty.PropertyName)
			{
				if (SelectedItem != null)
				{
					_Log.WriteLine("Organization Selected: {0}", SelectedItem.OrgId.ToString());
					await _Nav.PushViewModelAsnc(new OrgDetailViewModel(SelectedItem));
				}
				await Task.Delay(200);
				SelectedItem = null;
			}
		}
	}
}
