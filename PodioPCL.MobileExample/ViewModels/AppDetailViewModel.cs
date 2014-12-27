using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	/// <summary>
	/// Class to display details about the <see cref="Models.Application">Application</see>.
	/// </summary>
	public class AppDetailViewModel : ViewModelBase
	{
		/// <summary>
		/// The model BindableProperty.
		/// </summary>
		public static readonly BindableProperty ModelProperty =
			BindableProperty.Create("Model", typeof(Models.Application), typeof(AppDetailViewModel), default(Models.Application));
		/// <summary>
		/// Gets or sets the <see cref="Models.Application">Application</see> Model.<br />This is a BindableProperty.
		/// </summary>
		/// <value>The model.</value>
		public Models.Application Model
		{
			get { return (Models.Application)GetValue(ModelProperty); }
			set { SetValue(ModelProperty, value); }
		}

		/// <summary>
		/// The view items command BindableProperty.
		/// </summary>
		public static readonly BindableProperty ViewItemsCommandProperty =
			BindableProperty.Create("ViewItemsCommand", typeof(Command), typeof(AppDetailViewModel), default(Command));
		/// <summary>
		/// Gets or sets the view items command.<br />This is a BindableProperty.
		/// </summary>
		/// <value>The view items command.</value>
		public Command ViewItemsCommand
		{
			get { return (Command)GetValue(ViewItemsCommandProperty); }
			set { SetValue(ViewItemsCommandProperty, value); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AppDetailViewModel"/> class.
		/// </summary>
		/// <param name="application">The application.</param>
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
