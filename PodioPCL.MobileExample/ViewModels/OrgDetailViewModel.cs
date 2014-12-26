using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	public class OrgDetailViewModel : ViewModelBase
	{
		public static readonly BindableProperty ModelProperty =
			BindableProperty.Create("Model", typeof(Models.Organization), typeof(OrgDetailViewModel), default(Models.Organization));
		public Models.Organization Model
		{
			get { return (Models.Organization)GetValue(ModelProperty); }
			set { SetValue(ModelProperty, value); }
		}

		public static readonly BindableProperty ViewSpacesCommandProperty =
			BindableProperty.Create("ViewSpacesCommand", typeof(Command), typeof(OrgDetailViewModel), default(Command));
		public Command ViewSpacesCommand
		{
			get { return (Command)GetValue(ViewSpacesCommandProperty); }
			set { SetValue(ViewSpacesCommandProperty, value); }
		}

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
