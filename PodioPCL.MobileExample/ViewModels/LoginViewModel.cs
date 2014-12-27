using PodioPCL.MobileExample.Utility;
using System;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.ViewModels
{
	/// <summary>
	/// Class LoginViewModel.
	/// </summary>
	public class LoginViewModel : ViewModelBase
	{
		/// <summary>
		/// The UserName BindableProperty
		/// </summary>
		public static readonly BindableProperty UserNameProperty =
			BindableProperty.Create("UserName", typeof(string), typeof(LoginViewModel), default(string));
		/// <summary>
		/// Gets or sets the UserName to log in with.<br />This is a <see cref="BindableProperty"/>
		/// </summary>
		/// <value>The UserName</value>
		public string UserName
		{
			get { return (string)GetValue(UserNameProperty); }
			set { SetValue(UserNameProperty, value); }
		}

		/// <summary>
		/// The password BindableProperty.
		/// </summary>
		public static readonly BindableProperty PasswordProperty =
			BindableProperty.Create("Password", typeof(string), typeof(LoginViewModel), default(string));
		/// <summary>
		/// Gets or sets the password.<br />This is a <see cref="BindableProperty"/>
		/// </summary>
		/// <value>The password.</value>
		public string Password
		{
			get { return (string)GetValue(PasswordProperty); }
			set { SetValue(PasswordProperty, value); }
		}

		/// <summary>
		/// The login command BindableProperty
		/// </summary>
		public static readonly BindableProperty LoginCommandProperty =
			BindableProperty.Create("LoginCommand", typeof(Command), typeof(LoginViewModel), default(Command));
		/// <summary>
		/// Gets or sets the login command.<br />This is a <see cref="BindableProperty"/>
		/// </summary>
		/// <value>The login command.</value>
		public Command LoginCommand
		{
			get { return (Command)GetValue(LoginCommandProperty); }
			set { SetValue(LoginCommandProperty, value); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginViewModel"/> class.
		/// </summary>
		public LoginViewModel()
		{
			_InitializeCommands();
		}

		private void _InitializeCommands()
		{
			LoginCommand = new Command(async (obj) =>
			{
				IsLoading = true;
				if (string.IsNullOrEmpty(UserName))
				{
					await _Nav.DisplayAlert("Error", "Username must be filled in.", "OK");
				}
				else if (string.IsNullOrEmpty(Password))
				{
					await _Nav.DisplayAlert("Error", "Password must be filled in.", "OK");
				}
				else
				{
					bool success = false;
					string message = "";
					try
					{
						var podioAuth = await _Podio.AuthenticateWithPassword(UserName, Password);
						success = true;
					}
					catch (PodioPCL.Exceptions.PodioException ex)
					{
						message = ex.Message;
					}
					catch (Exception ex)
					{
						message = ex.Message;
					}

					if (!success)
					{
						if (string.IsNullOrEmpty(message))
						{
							message = "An error occurred.";
						}
						await _Nav.DisplayAlert("Error", message, "OK");
					}
					else
					{
						await _Nav.PushViewModelAsnc(new OrgListViewModel());
						_Nav.RemoveViewModel(this);
					}
				}
				IsLoading = false;
			});
		}
	}
}
