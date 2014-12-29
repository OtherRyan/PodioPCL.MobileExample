using PodioPCL.MobileExample.Utility;
using PodioPCL.MobileExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.Utility
{
	/// <summary>
	/// the ViewModelAttribute is used to pair a ViewModel with a Page
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public class ViewModelAttribute : Attribute
	{
		/// <summary>
		/// Gets the type of the view model.
		/// </summary>
		/// <value>The type of the view model.</value>
		public Type ViewModelType { get; private set; }
		/// <summary>
		/// Gets the type of the page.
		/// </summary>
		/// <value>The type of the page.</value>
		public Type PageType { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewModelAttribute"/> class.
		/// </summary>
		/// <param name="viewModelType">Type of the view model.</param>
		/// <param name="pageType">Type of the page.</param>
		public ViewModelAttribute(Type viewModelType, Type pageType)
		{
			ViewModelType = viewModelType;
			PageType = pageType;
		}
	}

	/// <summary>
	/// The <see cref="ViewModelNavigation{TViewBase}"/> class is used to navigate between ViewModels instead of Pages, in MVVM style.
	/// </summary>
	/// <typeparam name="TViewBase">The type of the t view base.</typeparam>
	public class ViewModelNavigation<TViewBase> where TViewBase : class
	{
		/// <summary>
		/// Gets or sets the base page.
		/// </summary>
		/// <value>The base page.</value>
		public Page BasePage { get; set; }

		/// <summary>
		/// Gets or sets the INavigation.
		/// </summary>
		/// <value>The INavigation.</value>
		public INavigation Navigation
		{
			get
			{
				return BasePage.Navigation;
			}
		}

		/// <summary>
		/// Gets the navigation stack.
		/// </summary>
		/// <value>The navigation stack.</value>
		public IReadOnlyList<TViewBase> NavigationStack
		{
			get
			{
				return Navigation.NavigationStack.Select(p => p.BindingContext as TViewBase).Where(v => v != null).ToList();
			}
		}

		private Dictionary<Type, Type> _RegisteredPages;

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewModelNavigation{TViewBase}"/> class.
		/// </summary>
		public ViewModelNavigation()
		{
			_RegisteredPages = new Dictionary<Type, Type>();

			Assembly assembly = this.GetType().GetTypeInfo().Assembly;
			foreach (var attribute in assembly.GetCustomAttributes<ViewModelAttribute>())
			{
				_RegisteredPages.Add(attribute.ViewModelType, attribute.PageType);
			}
		}

		/// <summary>
		/// Pushes the view model asnc.
		/// </summary>
		/// <typeparam name="TView">The ViewModel.</typeparam>
		/// <param name="viewModel">The ViewModel.</param>
		/// <returns>Task.</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">The dictionary doesn't contain the <see cref="T:Xamarin.Forms.Page">Page</see></exception>
		public async Task PushViewModelAsync<TView>(TView viewModel)
			where TView : TViewBase
		{
			var viewType = typeof(TView);
			if (!_RegisteredPages.ContainsKey(viewType))
			{
				throw new ArgumentOutOfRangeException(string.Format("Dictionary does not contain a page for {0}", viewType.Name));
			}
			else
			{
				var newPage = (Page)Activator.CreateInstance(_RegisteredPages[viewType], viewModel);
				await Navigation.PushAsync(newPage);
			}
		}

		/// <summary>
		/// Pop the top <typeparamref name="TViewBase">ViewModel</typeparamref> (and <see cref="T:Xamarin.Forms.Page">Page</see>) off the stack.
		/// </summary>
		/// <returns>Task.</returns>
		public async Task<TViewBase> PopViewModelAsync()
		{
			var oldPage = await Navigation.PopAsync();
			return oldPage.BindingContext as TViewBase;
		}

		/// <summary>
		/// Pops to root asynchronous.
		/// </summary>
		/// <param name="animated">The animated.</param>
		/// <returns>System.Threading.Tasks.Task.</returns>
		public Task PopToRootAsync(bool animated = true)
		{
			return Navigation.PopToRootAsync();
		}

		/// <summary>
		/// Inserts the before the second ViewModel
		/// </summary>
		/// <typeparam name="TView">The type of the <typeparamref name="TViewBase">ViewModel</typeparamref>.</typeparam>
		/// <param name="viewModel">The view model.</param>
		/// <param name="existingViewModel">The existing view model.</param>
		public void InsertBeforeViewModel<TView>(TView viewModel, TViewBase existingViewModel)
			where TView : TViewBase
		{
			var viewType = typeof(TView);
			if (!_RegisteredPages.ContainsKey(viewType))
			{
				throw new ArgumentOutOfRangeException(string.Format("Dictionary does not contain a page for {0}", viewType.Name));
			}
			else
			{
				var newPage = (Page)Activator.CreateInstance(_RegisteredPages[viewType], viewModel);
				var existingPage = Navigation.NavigationStack.Where(p => p.BindingContext == existingViewModel).FirstOrDefault();
				Navigation.InsertPageBefore(newPage, existingPage);
			}
		}

		/// <summary>
		/// Removes the view model (and <see cref="T:Xamarin.Forms.Page">Page</see>) from the stack.
		/// </summary>
		/// <typeparam name="TView">The type of <typeparamref name="TViewBase">ViewModel</typeparamref>.</typeparam>
		/// <param name="viewModel">The ViewModel</param>
		/// <returns>Removal Success</returns>
		public bool RemoveViewModel<TView>(TView viewModel)
			where TView : class, TViewBase
		{
			var page = Navigation.NavigationStack.Where(p => p.BindingContext == viewModel).FirstOrDefault();
			if (page != null)
			{
				Navigation.RemovePage(page);
				return true;
			}
			return false;
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
