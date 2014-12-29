using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.Controls
{
	public class NameValueCell : ViewCell
	{
		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create("Title", typeof(string), typeof(NameValueCell), default(string));
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		public static readonly BindableProperty DescriptionProperty =
			BindableProperty.Create("Description", typeof(string), typeof(NameValueCell), default(string));
		public string Description
		{
			get { return (string)GetValue(DescriptionProperty); }
			set { SetValue(DescriptionProperty, value); }
		}

		private StackLayout _MainStack;
		private Label _TitleLabel;
		private Label _DescriptionLabel;

		/// <summary>
		/// Initializes a new instance of the <see cref="NameValueCell"/> class.
		/// </summary>
		public NameValueCell()
		{
			_TitleLabel = new Label
			{
				BindingContext = this,
				Font = Font.SystemFontOfSize(NamedSize.Medium, FontAttributes.Bold)
			};
			_TitleLabel.SetBinding(Label.TextProperty, NameValueCell.TitleProperty.PropertyName);

			_DescriptionLabel = new Label
			{
				BindingContext = this,
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};
			_DescriptionLabel.SetBinding(Label.TextProperty, NameValueCell.DescriptionProperty.PropertyName);

			View = _MainStack = new StackLayout
			{
				Padding = 5,
				Children = 
				{
					_TitleLabel,
					_DescriptionLabel
				}
			};
		}
	}
}
