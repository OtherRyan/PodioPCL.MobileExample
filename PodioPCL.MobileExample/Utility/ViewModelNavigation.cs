using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ViewModelNavigation))]
namespace PodioPCL.MobileExample.Utility
{
	/// <summary>
	/// The <see cref="ViewModelNavigation"/> class is used to navigate between ViewModels instead of Pages, in MVVM style.
	/// </summary>
	public class ViewModelNavigation
	{
		/// <summary>
		/// Gets or sets the base page.
		/// </summary>
		/// <value>The base page.</value>
		public Page BasePage { get; set; }

		private Dictionary<Type, Type> _RegisteredPages;
		private Dictionary<ViewModelBase, Page> _Pages;

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewModelNavigation"/> class.
		/// </summary>
		public ViewModelNavigation()
		{
			_RegisteredPages = new Dictionary<Type, Type>();
			_Pages = new Dictionary<ViewModelBase, Page>();
		}

		/// <summary>
		/// Registers a <see cref="T:Xamarin.Forms.Page"/> for use with a <see cref="ViewModelBase">ViewModel</see>
		/// </summary>
		/// <typeparam name="TView">The type of the <see cref="ViewModelBase">ViewModel</see>.</typeparam>
		/// <typeparam name="TPage">The type of the <see cref="T:Xamarin.Forms.Page">Page</see>.</typeparam>
		public void RegisterPage<TView, TPage>()
			where TView : ViewModelBase
			where TPage : Page
		{
			var viewType = typeof(TView);
			var pageType = typeof(TPage);
			if (_RegisteredPages.ContainsKey(viewType))
			{
				_RegisteredPages.Remove(viewType);
			}
			_RegisteredPages.Add(viewType, pageType);
		}

		/// <summary>
		/// Pushes the view model asnc.
		/// </summary>
		/// <typeparam name="TView">The <see cref="ViewModelBase">ViewModel</see>.</typeparam>
		/// <param name="viewModel">The ViewModel.</param>
		/// <returns>Task.</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">The dictionary doesn't contain the <see cref="T:Xamarin.Forms.Page">Page</see></exception>
		public async Task PushViewModelAsnc<TView>(TView viewModel)
			where TView : ViewModelBase
		{
			var viewType = typeof(TView);
			if (!_RegisteredPages.ContainsKey(viewType))
			{
				throw new ArgumentOutOfRangeException(string.Format("Dictionary does not contain a page for {0}", viewType.Name));
			}
			else
			{
				var newPage = (Page)Activator.CreateInstance(_RegisteredPages[viewType], viewModel);
				await BasePage.Navigation.PushAsync(newPage);
				_Pages.Add(viewModel, newPage);
			}
		}

		/// <summary>
		/// Pop the top <see cref="ViewModelBase">ViewModel</see> (and <see cref="T:Xamarin.Forms.Page">Page</see>) off the stack.
		/// </summary>
		/// <returns>Task.</returns>
		public async Task PopViewModelAsync()
		{
			var oldPage = await BasePage.Navigation.PopAsync();
			foreach (var page in _Pages.Where(pv => pv.Value == oldPage).ToList())
			{
				_Pages.Remove(page.Key);
			}
		}

		/// <summary>
		/// Removes the view model (and <see cref="T:Xamarin.Forms.Page">Page</see>) from the stack.
		/// </summary>
		/// <param name="viewModel">The ViewModel</param>
		public void RemoveViewModel(ViewModelBase viewModel)
		{
			BasePage.Navigation.RemovePage(_Pages[viewModel]);
			_Pages.Remove(viewModel);
		}

		/// <summary>
		/// Displays the alert.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		/// <param name="button">The button.</param>
		/// <returns>Task.</returns>
		public async Task DisplayAlert(string title, string message, string button)
		{
			await BasePage.DisplayAlert(title, message, button);
		}

		/// <summary>
		/// Displays the alert.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="message">The message.</param>
		/// <param name="okButton">The ok button.</param>
		/// <param name="cancelButton">The cancel button.</param>
		/// <returns>Task.</returns>
		public async Task DisplayAlert(string title, string message, string okButton, string cancelButton)
		{
			await BasePage.DisplayAlert(title, message, okButton, cancelButton);
		}
	}
}
