using PodioPCL.Models.Request;
using PodioPCL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.ViewModels
{
	public class ItemListViewModel : ListViewModelBase<Models.Item>
	{
		public int AppId { get; set; }

		public PodioCollection<Models.Item> ItemCollection { get; set; }

		private int _Skip;
		private int _Take;

		public ItemListViewModel(int appId)
		{
			AppId = appId;
			Models = new List<Models.Item>();
			_Take = 25;
		}

		public override void OnAppearing(object sender, EventArgs e)
		{
			base.OnAppearing(sender, e);
			Models = new List<Models.Item>();
			_Skip = 0;
		}

		public void OnItemAppearing(Models.Item item)
		{
			if (item != null)
			{
				var index = Models.IndexOf(item);
				if (index >= Models.Count - 3 && (ItemCollection == null || _Skip < ItemCollection.Total))
				{
					_GetModels();
				}
			}
		}

		public override async Task<List<Models.Item>> GetModels(System.Threading.CancellationToken token)
		{
			ItemCollection = await _Podio.ItemService.FilterItems(AppId, limit: _Take, offset: _Skip);
			Models.AddRange(ItemCollection.Items.ToList());
			_Skip += _Take;
			return Models;
		}
	}
}
