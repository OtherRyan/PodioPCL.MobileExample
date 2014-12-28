using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using PodioPCL.MobileExample.Droid.Renderers;
using PodioPCL.MobileExample.Controls;

[assembly: ExportRenderer(typeof(LoadingContentPage), typeof(LoadingContentPageRenderer_Android))]
namespace PodioPCL.MobileExample.Droid.Renderers
{
	public class LoadingContentPageRenderer_Android : PageRenderer
	{
		new public LoadingContentPage Element
		{
			get { return (LoadingContentPage)base.Element; }
		}

		private ProgressDialog _ProgressDialog;

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null)
			{
				e.OldElement.PropertyChanged -= Element_PropertyChanged;
				e.NewElement.Disappearing -= Element_Disappearing;
			}
			if (e.NewElement != null)
			{
				e.NewElement.PropertyChanged += Element_PropertyChanged;
				e.NewElement.Disappearing += Element_Disappearing;
			}
		}

		private void Element_Disappearing(object sender, EventArgs e)
		{
			if (_ProgressDialog != null)
			{
				_ProgressDialog.Dismiss();
			}
		}

		private void Element_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == LoadingContentPage.IsLoadingProperty.PropertyName && Element != null && Element.IsLoading)
			{
				_ProgressDialog = ProgressDialog.Show(Context, Element.Title, Element.LoadingMessage);
			}
			else if (e.PropertyName == LoadingContentPage.IsLoadingProperty.PropertyName && Element != null && _ProgressDialog != null)
			{
				_ProgressDialog.Dismiss();
			}
			else if (e.PropertyName == LoadingContentPage.LoadingTitleProperty.PropertyName && Element != null && _ProgressDialog != null)
			{
				_ProgressDialog.SetTitle(Element.LoadingTitle);
			}
			else if (e.PropertyName == LoadingContentPage.LoadingMessageProperty.PropertyName && Element != null && _ProgressDialog != null)
			{
				_ProgressDialog.SetMessage(Element.LoadingMessage);
			}
		}
	}
}