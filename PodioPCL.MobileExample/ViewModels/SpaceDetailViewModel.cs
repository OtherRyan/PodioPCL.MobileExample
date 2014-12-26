using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	public class SpaceDetailViewModel : ViewModelBase
	{
		public static readonly BindableProperty ModelProperty =
			BindableProperty.Create("Model", typeof(Models.Space), typeof(SpaceDetailViewModel), default(Models.Space));
		public Models.Space Model
		{
			get { return (Models.Space)GetValue(ModelProperty); }
			set { SetValue(ModelProperty, value); }
		}

		public static readonly BindableProperty ViewAppsCommandProperty =
			BindableProperty.Create("ViewAppsCommand", typeof(Command), typeof(SpaceDetailViewModel), default(Command));
		public Command ViewAppsCommand
		{
			get { return (Command)GetValue(ViewAppsCommandProperty); }
			set { SetValue(ViewAppsCommandProperty, value); }
		}

		public SpaceDetailViewModel(Models.Space space)
		{
			Model = space;

			_InitializeCommands();
		}

		private void _InitializeCommands()
		{
			ViewAppsCommand = new Command(async (obj) =>
			{
				await _Nav.PushViewModelAsnc(new AppListViewModel(Model.SpaceId));
			});
		}
	}
}
