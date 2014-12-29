using PodioPCL.MobileExample.Interfaces;
using PodioPCL.MobileExample.Utility;
using System;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	/// <summary>
	/// The base for all ViewModels that are used with Pages. Extends from <see cref="Xamarin.Forms.BindableObject"/>.
	/// </summary>
	public class ViewModelBase : BindableObject
	{
		/// <summary>
		/// The IsLoading BindableProperty
		/// </summary>
		public static readonly BindableProperty IsLoadingProperty =
			BindableProperty.Create("IsLoading", typeof(bool), typeof(ViewModelBase), default(bool));
		/// <summary>
		/// Gets or sets a value indicating whether this ViewModel is loading.
		/// </summary>
		/// <value><c>true</c> if this instance is loading; otherwise, <c>false</c>.</value>
		public bool IsLoading
		{
			get { return (bool)GetValue(IsLoadingProperty); }
			set { SetValue(IsLoadingProperty, value); }
		}

		/// <summary>
		/// The loading title BindableProperty
		/// </summary>
		public static readonly BindableProperty LoadingTitleProperty =
			BindableProperty.Create("LoadingTitle", typeof(string), typeof(ViewModelBase), "Loading...");
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
			BindableProperty.Create("LoadingMessage", typeof(string), typeof(ViewModelBase), "Downloading new data from the Podio API");
		/// <summary>
		/// Gets or sets the loading message.
		/// </summary>
		/// <value>The loading message.</value>
		public string LoadingMessage
		{
			get { return (string)GetValue(LoadingMessageProperty); }
			set { SetValue(LoadingMessageProperty, value); }
		}

		/// <summary>
		/// The local implementation of the ILog interface.
		/// </summary>
		protected ILog _Log;

		/// <summary>
		/// The local implementation of the Podio class.
		/// </summary>
		protected Podio _Podio;

		/// <summary>
		/// The local implementation of the ViewModelNavigation class.
		/// </summary>
		protected ViewModelNavigation<ViewModelBase> _Nav;

		/// <summary>
		/// The local implementation of the ISettings interface.
		/// </summary>
		protected ISettings _Settings;

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewModelBase"/> class. A parameterless constructor is required for the <see cref="Xamarin.Forms.DependencyService"/>.
		/// </summary>
		public ViewModelBase()
		{
			_Log = DependencyService.Get<ILog>(DependencyFetchTarget.GlobalInstance);
			_Podio = DependencyService.Get<PodioExample>(DependencyFetchTarget.GlobalInstance).Podio;
			_Nav = DependencyService.Get<ViewModelNavigation<ViewModelBase>>(DependencyFetchTarget.GlobalInstance);
			_Settings = DependencyService.Get<ISettings>(DependencyFetchTarget.GlobalInstance);
		}

		/// <summary>
		/// Handles the <see cref="E:Appearing" /> event.
		/// </summary>
		/// <param name="sender">The sender. Most of the time this is a <see cref="Xamarin.Forms.Page"/>.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		public virtual void OnAppearing(object sender, EventArgs e) { }

		/// <summary>
		/// Handles the <see cref="E:Disappearing" /> event.
		/// </summary>
		/// <param name="sender">The sender. Most of the time this is a <see cref="Xamarin.Forms.Page"/>.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		public virtual void OnDisappearing(object sender, EventArgs e) { }

	}
}
