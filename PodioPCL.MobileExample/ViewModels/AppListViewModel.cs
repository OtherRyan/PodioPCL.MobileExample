using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	public class AppListViewModel : ListViewModelBase<Models.Application>
	{
		public int SpaceId { get; set; }

		public AppListViewModel(int spaceId)
		{
			SpaceId = spaceId;
		}

		public override async Task<List<Models.Application>> GetModels(CancellationToken token)
		{
			return await _Podio.ApplicationService.GetAppsBySpace(SpaceId);
		}

		protected override async void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == ListViewModelBase<Models.Application>.SelectedItemProperty.PropertyName)
			{
				if (SelectedItem != null)
				{
					_Log.WriteLine(SelectedItem.AppId.ToString());
					await _Nav.PushViewModelAsnc(new AppDetailViewModel(SelectedItem));
				}
				await Task.Delay(200);
				SelectedItem = null;
			}
		}
	}
}
