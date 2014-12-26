using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	public abstract class ListViewModelBase<TModel> : ViewModelBase
	{
		public static readonly BindableProperty ModelsProperty =
			BindableProperty.Create("Models", typeof(List<TModel>), typeof(ListViewModelBase<TModel>), default(List<TModel>));
		public List<TModel> Models
		{
			get { return (List<TModel>)GetValue(ModelsProperty); }
			set { SetValue(ModelsProperty, value); }
		}

		public static readonly BindableProperty SelectedItemProperty =
			BindableProperty.Create("SelectedItem", typeof(TModel), typeof(ListViewModelBase<TModel>), default(TModel));
		public TModel SelectedItem
		{
			get { return (TModel)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		private CancellationTokenSource _GetModelsTokenSource;
		private Task<List<TModel>> _GetModelsTask;

		public abstract Task<List<TModel>> GetModels(CancellationToken token);

		public override void OnAppearing(object sender, EventArgs e)
		{
			base.OnAppearing(sender, e);
			_GetModels();
		}

		public override void OnDisappearing(object sender, EventArgs e)
		{
			base.OnDisappearing(sender, e);
			if (_GetModelsTokenSource != null)
			{
				_GetModelsTokenSource.Cancel();
			}
		}

		protected async void _GetModels()
		{
			_Log.WriteLine("_GetModels: start");
			if (_GetModelsTokenSource != null)
			{
				_GetModelsTokenSource.Cancel();
			}

			if (_GetModelsTask != null)
			{
				await _GetModelsTask;
			}

			_GetModelsTokenSource = new CancellationTokenSource();
			var token = _GetModelsTokenSource.Token;
			_GetModelsTask = GetModels(token);

			try
			{
				while (_GetModelsTask.Status == TaskStatus.Running)
				{
					await Task.Delay(10, token);
				}
				Models = await _GetModelsTask;
			}
			catch (TaskCanceledException ex)
			{
				_Log.WriteLine("_GetModels: Task Canceled");
			}
			_Log.WriteLine("_GetModels: finished");
		}
	}
}
