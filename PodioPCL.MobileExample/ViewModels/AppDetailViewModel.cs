using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	public class AppDetailViewModel : ViewModelBase
	{
		public static readonly BindableProperty ModelProperty =
			BindableProperty.Create("Model", typeof(Models.Application), typeof(AppDetailViewModel), default(Models.Application));
		public Models.Application Model
		{
			get { return (Models.Application)GetValue(ModelProperty); }
			set { SetValue(ModelProperty, value); }
		}

		public static readonly BindableProperty ViewItemsCommandProperty =
			BindableProperty.Create("ViewItemsCommand", typeof(Command), typeof(AppDetailViewModel), default(Command));
		public Command ViewItemsCommand
		{
			get { return (Command)GetValue(ViewItemsCommandProperty); }
			set { SetValue(ViewItemsCommandProperty, value); }
		}

		public AppDetailViewModel(Models.Application application)
		{
			Model = application;

			_InitializeCommands();
		}

		private void _InitializeCommands()
		{
			ViewItemsCommand = new Command(async (obj) =>
			{
				await _Nav.PushViewModelAsnc(new ItemListViewModel(Model.AppId));
			});
		}
	}
}
