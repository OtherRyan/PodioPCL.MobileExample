using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	/// <summary>
	/// Desplaying the details of a <see cref="PodioPCL.Models.Space" /> model.
	/// </summary>
	public class SpaceDetailViewModel : ViewModelBase
	{

		/// <summary>
		/// The model property
		/// </summary>
		public static readonly BindableProperty ModelProperty =
			BindableProperty.Create("Model", typeof(Models.Space), typeof(SpaceDetailViewModel), default(Models.Space));
		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>The model.</value>
		public Models.Space Model
		{
			get { return (Models.Space)GetValue(ModelProperty); }
			set { SetValue(ModelProperty, value); }
		}

		/// <summary>
		/// The view applications command property
		/// </summary>
		public static readonly BindableProperty ViewAppsCommandProperty =
			BindableProperty.Create("ViewAppsCommand", typeof(Command), typeof(SpaceDetailViewModel), default(Command));
		/// <summary>
		/// Gets or sets the view applications command.
		/// </summary>
		/// <value>The view applications command.</value>
		public Command ViewAppsCommand
		{
			get { return (Command)GetValue(ViewAppsCommandProperty); }
			set { SetValue(ViewAppsCommandProperty, value); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SpaceDetailViewModel"/> class.
		/// </summary>
		/// <param name="space">The <see cref="PodioPCL.Models.Space" /> model to be displayed.</param>
		public SpaceDetailViewModel(Models.Space space)
		{
			Model = space;

			_InitializeCommands();
		}

		private void _InitializeCommands()
		{
			ViewAppsCommand = new Command(async (obj) =>
			{
				await _Nav.PushViewModelAsync(new AppListViewModel(Model.SpaceId));
			});
		}
	}
}
