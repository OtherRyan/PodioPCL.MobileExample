using Xamarin.Forms;

namespace PodioPCL.MobileExample.Controls
{
	public class LoadingContentPage:ContentPage
	{
		public static readonly BindableProperty IsLoadingProperty =
			BindableProperty.Create("IsLoading", typeof(bool), typeof(LoadingContentPage), default(bool));
		public bool IsLoading
		{
			get { return (bool)GetValue(IsLoadingProperty); }
			set { SetValue(IsLoadingProperty, value); }
		}

		public static readonly BindableProperty LoadingTitleProperty =
			BindableProperty.Create("LoadingTitle", typeof(string), typeof(LoadingContentPage), default(string));
		public string LoadingTitle
		{
			get { return (string)GetValue(LoadingTitleProperty); }
			set { SetValue(LoadingTitleProperty, value); }
		}

		public static readonly BindableProperty LoadingMessageProperty =
			BindableProperty.Create("LoadingMessage", typeof(string), typeof(LoadingContentPage), default(string));
		public string LoadingMessage
		{
			get { return (string)GetValue(LoadingMessageProperty); }
			set { SetValue(LoadingMessageProperty, value); }
		}
	}
}
