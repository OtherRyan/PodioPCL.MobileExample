using Android.App;
using PodioPCL.MobileExample.Controls;
using PodioPCL.MobileExample.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoadingListView), typeof(LoadingListViewRenderer_Android))]
namespace PodioPCL.MobileExample.Droid.Renderers
{
	public class LoadingListViewRenderer_Android : ListViewRenderer
	{
		new public LoadingListView Element
		{
			get { return (LoadingListView)base.Element; }
		}

		private ProgressDialog _ProgressDialog;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null)
			{
				e.OldElement.PropertyChanged -= Element_PropertyChanged;
			}
			if (e.NewElement != null)
			{
				e.NewElement.PropertyChanged += Element_PropertyChanged;
			}
		}

		void Element_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == LoadingListView.IsLoadingProperty.PropertyName)
			{
				if (Element != null && Element.IsLoading)
				{
					_ProgressDialog = ProgressDialog.Show(Control.Context, "Loading...", "Downloading new data from the Podio API");
				}
				else if (Element != null && _ProgressDialog != null)
				{
					_ProgressDialog.Dismiss();
				}
			}
		}
	}
}