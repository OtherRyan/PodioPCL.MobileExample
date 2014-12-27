using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;


namespace PodioPCL.MobileExample.WinPhone
{
	public partial class MainPage : FormsApplicationPage
	{
		public PodioPCL.MobileExample.App Application { get; set; }

		public MainPage()
		{
			InitializeComponent();

			Forms.Init();

			Application = new MobileExample.App();

			LoadApplication(Application);
		}
	}
}
