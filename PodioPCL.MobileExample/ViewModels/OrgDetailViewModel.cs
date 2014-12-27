using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	/// <summary>
	/// Gets a list of <see cref="Models.Organization"/>.
	/// </summary>
	public class OrgDetailViewModel : ViewModelBase
	{
		/// <summary>
		/// The Model BindableProperty
		/// </summary>
		public static readonly BindableProperty ModelProperty =
			BindableProperty.Create("Model", typeof(Models.Organization), typeof(OrgDetailViewModel), default(Models.Organization));
		/// <summary>
		/// The <see cref="Models.Organization"/> Model.<br />This is a BindableProperty.
		/// </summary>
		/// <value>The Model</value>
		public Models.Organization Model
		{
			get { return (Models.Organization)GetValue(ModelProperty); }
			set { SetValue(ModelProperty, value); }
		}

		/// <summary>
		/// The ViewSpacesCommand BindableProperty
		/// </summary>
		public static readonly BindableProperty ViewSpacesCommandProperty =
			BindableProperty.Create("ViewSpacesCommand", typeof(Command), typeof(OrgDetailViewModel), default(Command));
		/// <summary>
		/// The Command to go to the <see cref="SpaceListViewModel"/> ViewModel.<br />This is a BindableProperty.
		/// </summary>
		/// <value>The view spaces command.</value>
		public Command ViewSpacesCommand
		{
			get { return (Command)GetValue(ViewSpacesCommandProperty); }
			set { SetValue(ViewSpacesCommandProperty, value); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OrgDetailViewModel"/> class.
		/// </summary>
		/// <param name="organization">The organization.</param>
		public OrgDetailViewModel(Models.Organization organization)
		{
			Model = organization;

			_InitializeCommands();
		}

		private void _InitializeCommands()
		{
			ViewSpacesCommand = new Command(async (obj) =>
			{
				await _Nav.PushViewModelAsnc(new SpaceListViewModel(Model.OrgId));
			});
		}
	}
}
