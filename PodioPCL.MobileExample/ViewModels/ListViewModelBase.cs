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
	/// <summary>
	/// The <see cref="ListViewModelBase{TModel}"/> is an abstract class for handling the getting and refreshing a list of the generic TModel type.
	/// </summary>
	/// <typeparam name="TModel">The Model type of the <see cref="ListViewModelBase{TModel}"/></typeparam>
	public abstract class ListViewModelBase<TModel> : ViewModelBase
	{
		/// <summary>
		/// The models BindableProperty
		/// </summary>
		public static readonly BindableProperty ModelsProperty =
			BindableProperty.Create("Models", typeof(List<TModel>), typeof(ListViewModelBase<TModel>), default(List<TModel>));
		/// <summary>
		/// Gets or sets the Models.<br />This is a <see cref="BindableProperty"/>
		/// </summary>
		/// <value>The models.</value>
		public List<TModel> Models
		{
			get { return (List<TModel>)GetValue(ModelsProperty); }
			set { SetValue(ModelsProperty, value); }
		}

		/// <summary>
		/// The selected item BindableProperty
		/// </summary>
		public static readonly BindableProperty SelectedItemProperty =
			BindableProperty.Create("SelectedItem", typeof(TModel), typeof(ListViewModelBase<TModel>), default(TModel));
		/// <summary>
		/// Gets or sets the selected item.<br />This is a <see cref="BindableProperty"/>
		/// </summary>
		/// <value>The selected item.</value>
		public TModel SelectedItem
		{
			get { return (TModel)GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		private CancellationTokenSource _GetModelsTokenSource;
		private Task<List<TModel>> _GetModelsTask;

		/// <summary>
		/// When implemented, this method gets a <see cref="List{TModel}"/> of the TModel generic.
		/// </summary>
		/// <param name="token">The cancellation token for use with web accessor methods.</param>
		/// <returns>Task&lt;List&lt;TModel&gt;&gt;.</returns>
		public abstract Task<List<TModel>> GetModels(CancellationToken token);

		/// <summary>
		/// Handles the <see cref="E:Appearing" /> event.
		/// </summary>
		/// <param name="sender">The sender. Most of the time this is a <see cref="Xamarin.Forms.Page" />.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		public override void OnAppearing(object sender, EventArgs e)
		{
			base.OnAppearing(sender, e);
			_GetModels();
		}

		/// <summary>
		/// Handles the <see cref="E:Disappearing" /> event.
		/// </summary>
		/// <param name="sender">The sender. Most of the time this is a <see cref="Xamarin.Forms.Page" />.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		public override void OnDisappearing(object sender, EventArgs e)
		{
			base.OnDisappearing(sender, e);
			if (_GetModelsTokenSource != null)
			{
				_GetModelsTokenSource.Cancel();
			}
		}

		/// <summary>
		/// A protected method to handle cancelling tasks and getting TModel's.
		/// </summary>
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
			catch (TaskCanceledException)
			{
				_Log.WriteLine("_GetModels: Task Canceled");
			}
			_Log.WriteLine("_GetModels: finished");
		}
	}
}
