using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KeepingTrack
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}
		public Label errMsg;
		public Button logInBtn;


		 void OnLoginBtnClick(object sender, System.EventArgs e)
		{
			//throw new NotImplementedException();
			logInBtn = (Button)sender;

		 	errMsg = this.FindByName<Label>("errMsgLabel");
		 	//errMsg.IsVisible= true;

			string email = "sfoltz1@carthage.edu";
			string password = "Kn33socks";
			//string name = "Morgan";
			bool signInAuth = DependencyService.Get<IFirebaseAuth>().logIn(email, password);

			if (signInAuth == true)
			{
				//initial test, if the sign in works, show it on the 
				errMsg.IsVisible = false;
				//errMsg.IsVisible= true;
				errMsg.Text= "Log in Accepted";

				//real processes 
				//App.Current.MainPage = new KeepingTrackPage();


			}
			else
			{
				errMsg.IsVisible = true;
				errMsg.Text = "Error, cannot Log in";
			}


		}

		void OnSignUpBtnClick(object sender, System.EventArgs e)
		{
			//throw new NotImplementedException();
			logInBtn = (Button)sender;

			errMsg = this.FindByName<Label>("errMsgLabel");
			errMsg.IsVisible = true;
			errMsg.Text = "To The Sign Up Page";

			//Navigation.PushAsync(new SignUpPage());
			App.Current.MainPage = new SignUpPage();

		}

	}

}
