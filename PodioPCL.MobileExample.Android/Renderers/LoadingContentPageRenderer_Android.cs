using Android.App;
using PodioPCL.MobileExample.Droid.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

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
				_ProgressDialog = ProgressDialog.Show(Context, Element.LoadingTitle, Element.LoadingMessage);
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
