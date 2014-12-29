using PodioPCL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	/// <summary>
	/// View model for listing <see cref="PodioPCL.Models.Organization"/>'s.
	/// </summary>
	public class OrgListViewModel : ListViewModelBase<Models.Organization>
	{
		/// <summary>
		/// The logout command BindableProperty
		/// </summary>
		public static readonly BindableProperty LogoutCommandProperty =
			BindableProperty.Create("LogoutCommand", typeof(Command), typeof(OrgListViewModel), default(Command));
		/// <summary>
		/// Gets or sets the logout command.
		/// </summary>
		/// <value>The logout command.</value>
		public Command LogoutCommand
		{
			get { return (Command)GetValue(LogoutCommandProperty); }
			set { SetValue(LogoutCommandProperty, value); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OrgListViewModel"/> class.
		/// </summary>
		public OrgListViewModel()
		{
			LoadingMessage = "Downloading Organizations from the Podio API.";
			_InitializeCommands();
		}

		private void _InitializeCommands()
		{
			LogoutCommand = new Command(async (obj) =>
			{
				var viewModels = _Nav.NavigationStack;
				_Podio.DeAuthenticate();
				_Nav.InsertBeforeViewModel(new LoginViewModel(), this);
				await _Nav.PopViewModelAsync();
			});
		}
		/// <summary>
		/// When implemented, this method gets a <see cref="List{T}" /> of the <see cref="PodioPCL.Models.Organization"/> model.
		/// </summary>
		/// <param name="token">The cancellation token for use with web accessor methods.</param>
		/// <returns>Task&lt;List&lt;TModel&gt;&gt;.</returns>
		public override async Task<List<Models.Organization>> GetModels(CancellationToken token)
		{
			PodioException lastException = null;
			for (int i = 0; i < 3; i++)
			{
				try
				{
					var models = Models;
					return await _Podio.OrganizationService.GetOrganizations();
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
					await _Nav.PushViewModelAsync(new OrgDetailViewModel(SelectedItem));
				}
				await Task.Delay(200);
				SelectedItem = null;
			}
			else if (propertyName == ListViewModelBase<Models.Application>.ModelsProperty.PropertyName && Models != null && Models.Count > 0)
			{
				foreach (var model in Models)
				{
					_Log.WriteLine("Name: {0}, Type: {1}, Logo: {2}, Url: {3}, UrlLabel: {4}, Premium: {5}, Role: {6}", model.Name, model.Type, model.Logo, model.Url, model.UrlLabel, model.Premium, model.Role);
				}
			}
		}
	}
}
