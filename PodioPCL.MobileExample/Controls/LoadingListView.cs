using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.Controls
{
	public class LoadingListView : ListView
	{
		public static readonly BindableProperty IsLoadingProperty =
			BindableProperty.Create("IsLoading", typeof(bool), typeof(LoadingListView), default(bool));
		public bool IsLoading
		{
			get { return (bool)GetValue(IsLoadingProperty); }
			set { SetValue(IsLoadingProperty, value); }
		}
	}
}
