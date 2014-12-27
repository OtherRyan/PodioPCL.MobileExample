using PodioPCL.Exceptions;
using PodioPCL.Models.Request;
using PodioPCL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.ViewModels
{
	/// <summary>
	/// A Class to display a list of Items inside an Application
	/// </summary>
	public class ItemListViewModel : ListViewModelBase<Models.Item>
	{
		/// <summary>
		/// Gets or sets the application identifier.
		/// </summary>
		/// <value>The application identifier.</value>
		public int AppId { get; set; }

		/// <summary>
		/// Gets or sets the item collection.
		/// </summary>
		/// <value>The item collection.</value>
		public PodioCollection<Models.Item> ItemCollection { get; set; }

		private int _Skip;
		private int _Take;

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemListViewModel"/> class.
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		public ItemListViewModel(int appId)
		{
			AppId = appId;
			Models = new List<Models.Item>();
			_Take = 25;
		}

		/// <summary>
		/// Handles the <see cref="E:Appearing" /> event.
		/// </summary>
		/// <param name="sender">The sender. Most of the time this is a <see cref="Xamarin.Forms.Page" />.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		public override void OnAppearing(object sender, EventArgs e)
		{
			base.OnAppearing(sender, e);
			Models = new List<Models.Item>();
			_Skip = 0;
		}

		/// <summary>
		/// Called when [item appearing].
		/// </summary>
		/// <param name="item">The item.</param>
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

		/// <summary>
		/// When implemented, this method gets a List of <see cref="Models.Item"/>'s.
		/// </summary>
		/// <param name="token">The cancellation token for use with web accessor methods.</param>
		/// <returns>Task&lt;List&lt;Models.Item&gt;&gt;.</returns>
		/// <exception cref="PodioException">Unknown error retrieving models</exception>
		/// <exception cref="System.Exception">Unknown error retrieving models</exception>
		public override async Task<List<Models.Item>> GetModels(CancellationToken token)
		{
			PodioException lastException = null;
			for (int i = 0; i < 3; i++)
			{
				try
				{
					ItemCollection = await _Podio.ItemService.FilterItems(AppId, limit: _Take, offset: _Skip);
					Models.AddRange(ItemCollection.Items.ToList());
					_Skip += _Take;
					return Models;
				}
				catch (PodioException ex)
				{
					lastException = ex;
				}
			}
			throw lastException ?? new Exception("Unknown error retrieving models");
		}
	}
}
