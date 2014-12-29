using PodioPCL.MobileExample.Interfaces;
using PodioPCL.MobileExample.Utility;
using PodioPCL.Models;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.Controls
{
	/// <summary>
	/// OrganizationViewCell for displaying simple Organization information in a list.
	/// </summary>
	public class OrganizationViewCell : ViewCell
	{
		/// <summary>
		/// Gets or sets object that contains the properties that will be targeted by the bound properties that belong to this <see cref="T:Xamarin.Forms.BindableObject" />.
		/// </summary>
		/// <value>An <see cref="T:System.Object" /> that contains the properties that will be targeted by the bound properties that belong to this <see cref="T:Xamarin.Forms.BindableObject" />. This is a bindable property.</value>
		/// <remarks><block subset="none" type="note">Typically, the runtime performance is better if  <see cref="P:Xamarin.Forms.BindableObject.BindingContext" /> is set after all calls to <see cref="M:Xamarin.Forms.BindableObject.SetBinding" /> have been made.</block>
		/// <para>The following example shows how to apply a BindingContext and a Binding to a Label (inherits from BindableObject):</para>
		/// <example>
		///   <code lang="C#"><![CDATA[
		/// var label = new Label ();
		/// label.SetBinding (Label.TextProperty, "Name");
		/// label.BindingContext = new {Name = "John Doe", Company = "Xamarin"};
		/// Debug.WriteLine (label.Text); //prints "John Doe"
		/// ]]></code>
		/// </example></remarks>
		new public Organization BindingContext { get { return (Organization)base.BindingContext; } }

		private Xamarin.Forms.Image _IconImage;
		private StackLayout _MainStack;
		private StackLayout _TextStack;
		private Label _NameLabel;
		private Label _DescriptionLabel;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="OrganizationViewCell"/> class.
		/// </summary>
		public OrganizationViewCell()
		{
			_IconImage = new Xamarin.Forms.Image
			{
				Aspect = Aspect.AspectFit,
				WidthRequest = 36,
				HeightRequest = 36
			};

			_IconImage.SetBinding(
				Xamarin.Forms.Image.SourceProperty,
				"Image.Link",
				converter: new QuickConverter<string, string, object>((oldUrl, param, c) =>
				{
					if (string.IsNullOrEmpty(oldUrl))
					{
						return null;
					}
					return string.Format("{0}/large_bounded", oldUrl);
				}));

			_NameLabel = new Label
			{
				Font = Font.SystemFontOfSize(NamedSize.Medium, FontAttributes.Bold),
				LineBreakMode = LineBreakMode.TailTruncation
			};
			_NameLabel.SetBinding(Label.TextProperty, "Name");

			_DescriptionLabel = new Label
			{
				Font = Font.SystemFontOfSize(NamedSize.Small),
				LineBreakMode = LineBreakMode.TailTruncation
			};
			_DescriptionLabel.SetBinding(
				Label.TextProperty,
				"Spaces.Count",
				converter: new QuickConverter<int, string, object>((count, param, c) =>
				{
					return string.Format("Workspaces: {0}", count);
				}));

			_TextStack = new StackLayout
			{
				Children =
				{
					_NameLabel,
					_DescriptionLabel
				}
			};

			View = _MainStack = new StackLayout
			{
				Padding = 5,
				Orientation = StackOrientation.Horizontal,
				Children = 
				{
					_IconImage,
					_TextStack
				}
			};
		}
	}
}
