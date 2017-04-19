using System;
using System.Collections.Generic;

using Xamarin.Forms;


namespace KeepingTrack
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage()
		{
			InitializeComponent();

		}
		//public string email ="", password1 ="", password2="";
		public Entry emailE, password1E, password2E;

		void OnBackBtnClick(object sender, System.EventArgs e)
		{
			//throw new NotImplementedException();

			//Navigation.PushAsync(new SignUpPage());
			App.Current.MainPage = new LoginPage();
		}

		void OnCreateAcctBtnClick(object sender, System.EventArgs e)
		{
			/*TEST VALUES FOR FIREBASE AUTH
			 string email = "@carthage.edu";
			string password = "Kn33socks";
			string name = "Morgan";*/


			//VARIABLES 
			string email="", password1="", password2="";
			//GRAB THE INFORMATION entered 
			emailE = this.FindByName<Entry>("emailEntry");
			password1E = this.FindByName<Entry>("password1Entry");
			password2E = this.FindByName<Entry>("password2Entry");



			bool signInAuth = DependencyService.Get<IFirebaseAuth>().signUp(email, password1);


			Label errMsg;
			errMsg = this.FindByName<Label>("errMsgLabel");
				
			if (signInAuth == true)
			{
				//initial test, if the sign in works, show it on the 
				//errMsg.IsVisible = true;
				//errMsg.Text = "Acct Added";

				//real processes 
				App.Current.MainPage = new KeepingTrackPage();


			}
			else
			{
				errMsg.IsVisible = true;
				errMsg.Text = "Unable to Add Account at This Time";
			}


		}

	}
}
