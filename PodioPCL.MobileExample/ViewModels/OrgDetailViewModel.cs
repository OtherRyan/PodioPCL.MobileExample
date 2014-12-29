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

		public static readonly BindableProperty SelectedItemProperty =
			BindableProperty.Create("SelectedItem", typeof(object), typeof(OrgDetailViewModel), default(object));
		public object SelectedItem
		{
			get { return (object)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		public Dictionary<string, string> Properties { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="OrgDetailViewModel"/> class.
		/// </summary>
		/// <param name="organization">The organization.</param>
		public OrgDetailViewModel(Models.Organization organization)
		{
			Model = organization;
			Properties = new Dictionary<string, string>
			{
				{ "Id:",				Model.OrgId.ToString()				},
				{ "Name:",				Model.Name							},
				{ "Type:",				Model.Type							},
				{ "Logo:",				(Model.Logo ?? 0).ToString()		},
				{ "Url:",				Model.Url							},
				{ "Url Label:",			Model.UrlLabel						},
				{ "Premium:",			Model.Premium.ToString()			},
				{ "Role:",				Model.Role							},
				{ "Status:",			Model.Status						},
				{ "Sales Agent ID:",	Model.SalesAgentId.ToString()		},
				{ "Created on:",		Model.CreatedOn						},
				{
					"Domains:",			
					Model.Domains != null ? string.Join(", ", Model.Domains) : ""
				},
				{
					"Rights:",			
					Model.Rights != null ? string.Join(", ", Model.Rights) : ""
				},
				{ "Rank:",				(Model.Rank ?? 0).ToString()		},
				{ 
					"Created By:",		
					Model.CreatedBy != null ? Model.CreatedBy.Name : ""
				},
				{ "Grants Count:",		(Model.GrantsCount ?? 0).ToString()	},
				{ "Segment:",			Model.Segment						},
				{ "Segment Size",		(Model.SegmentSize ?? 0).ToString()	}
			};
			_InitializeCommands();

		}

		protected override void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == OrgDetailViewModel.SelectedItemProperty.PropertyName && SelectedItem != null)
			{
				SelectedItem = null;
			}
		}

		private void _InitializeCommands()
		{
			ViewSpacesCommand = new Command(async (obj) =>
			{
				await _Nav.PushViewModelAsync(new SpaceListViewModel(Model));
			});
		}
	}
}
