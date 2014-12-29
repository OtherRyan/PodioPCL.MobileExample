using Xamarin.Forms;

namespace Xamarin.Forms
{
	/// <summary>
	/// Class LoadingContentPage.
	/// </summary>
	public class LoadingContentPage : ContentPage
	{
		/// <summary>
		/// The is loading property{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
		/// </summary>
		public static readonly BindableProperty IsLoadingProperty =
			BindableProperty.Create("IsLoading", typeof(bool), typeof(LoadingContentPage), default(bool));
		/// <summary>
		/// Gets or sets the is loading.
		/// </summary>
		/// <value>The is loading.</value>
		public bool IsLoading
		{
			get { return (bool)GetValue(IsLoadingProperty); }
			set { SetValue(IsLoadingProperty, value); }
		}

		/// <summary>
		/// The loading title BindableProperty
		/// </summary>
		public static readonly BindableProperty LoadingTitleProperty =
			BindableProperty.Create("LoadingTitle", typeof(string), typeof(LoadingContentPage), default(string));
		/// <summary>
		/// Gets or sets the loading title.
		/// </summary>
		/// <value>The loading title.</value>
		public string LoadingTitle
		{
			get { return (string)GetValue(LoadingTitleProperty); }
			set { SetValue(LoadingTitleProperty, value); }
		}

		/// <summary>
		/// The loading message BindableProperty
		/// </summary>
		public static readonly BindableProperty LoadingMessageProperty =
			BindableProperty.Create("LoadingMessage", typeof(string), typeof(LoadingContentPage), default(string));
		/// <summary>
		/// Gets or sets the loading message.
		/// </summary>
		/// <value>The loading message.</value>
		public string LoadingMessage
		{
			get { return (string)GetValue(LoadingMessageProperty); }
			set { SetValue(LoadingMessageProperty, value); }
		}
	}
}
