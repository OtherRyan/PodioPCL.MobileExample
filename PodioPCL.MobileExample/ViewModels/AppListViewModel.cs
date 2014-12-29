using PodioPCL.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PodioPCL.MobileExample.ViewModels
{
	/// <summary>
	/// Class that gets a list of <see cref="Models.Application">Applications</see>
	/// </summary>
	public class AppListViewModel : ListViewModelBase<Models.Application>
	{
		/// <summary>
		/// Gets or sets the workspace identifier.
		/// </summary>
		/// <value>The workspace identifier.</value>
		public int SpaceId { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AppListViewModel"/> class.
		/// </summary>
		/// <param name="spaceId">The workspace identifier.</param>
		public AppListViewModel(int spaceId)
		{
			SpaceId = spaceId;
		}

		/// <summary>
		/// When implemented, this method gets a List of <see cref="Models.Application">Applications</see>
		/// </summary>
		/// <param name="token">The cancellation token for use with web accessor methods.</param>
		/// <returns>Task&lt;List&lt;Models.Application&gt;&gt;.</returns>
		/// <exception cref="System.Exception">Unknown error retrieving models</exception>
		public override async Task<List<Models.Application>> GetModels(CancellationToken token)
		{
			PodioException lastException = null;
			for (int i = 0; i < 3; i++)
			{
				try
				{
					return await _Podio.ApplicationService.GetAppsBySpace(SpaceId);
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
					_Log.WriteLine(SelectedItem.AppId.ToString());
					await _Nav.PushViewModelAsync(new AppDetailViewModel(SelectedItem));
				}
				await Task.Delay(200);
				SelectedItem = null;
			}
		}
	}
}
