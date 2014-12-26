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
	public class ViewModelNavigation
	{
		public Page BasePage { get; set; }

		private Dictionary<Type, Type> _RegisteredPages;
		private Dictionary<ViewModelBase, Page> _Pages;

		public ViewModelNavigation()
		{
			_RegisteredPages = new Dictionary<Type, Type>();
			_Pages = new Dictionary<ViewModelBase, Page>();
		}

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

		public async Task PopViewModelAsync()
		{
			var oldPage = await BasePage.Navigation.PopAsync();
			foreach (var page in _Pages.Where(pv => pv.Value == oldPage).ToList())
			{
				_Pages.Remove(page.Key);
			}
		}

		public void RemoveViewModel(ViewModelBase viewModel)
		{
			BasePage.Navigation.RemovePage(_Pages[viewModel]);
			_Pages.Remove(viewModel);
		}

		public async Task DisplayAlert(string title, string message, string button)
		{
			await BasePage.DisplayAlert(title, message, button);
		}
	}
}
