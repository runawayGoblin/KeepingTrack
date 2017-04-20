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

		public Button logInBtn;


		 void OnLoginBtnClick(object sender, System.EventArgs e)
		{

			//VARIABLES
			Entry emailE, passwordE;
			emailE = this.FindByName<Entry>("emailEntry");
			passwordE = this.FindByName<Entry>("passwordEntry");

			string email, password;
			email = emailE.Text;
			password = passwordE.Text;

			Label errMsg;
			errMsg = this.FindByName<Label>("errMsgLabel");

			//TEST TO SEE IF VALS ARE HERE
			//must do this before trying to log in 
			try
			{
				if (email == null)
				{
					throw new MISSINGINFOEXECPTION("Please Enter an Email address");
				}
				if (password == null)
				{
					throw new MISSINGINFOEXECPTION("Please Enter Your Password");
				}

			}
			catch (MISSINGINFOEXECPTION error)
			{
				errMsg.Text = error.Message;
				errMsg.IsVisible = true;
				return;
				
			}
		 	
			bool signInAuth = DependencyService.Get<IFirebaseAuth>().logIn(email, password);

			if (signInAuth == true)
			{
				//initial test, if the sign in works, show it on the 
				errMsg.IsVisible = false;
				//errMsg.IsVisible= true;
				errMsg.Text= "Log in Accepted";

				//real processes 
				App.Current.MainPage = new KeepingTrackPage();


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
			Label errMsg;
			errMsg = this.FindByName<Label>("errMsgLabel");
			errMsg.IsVisible = true;
			errMsg.Text = "To The Sign Up Page";

			//Navigation.PushAsync(new SignUpPage());
			App.Current.MainPage = new SignUpPage();



		}
		//MAKE OWN EXECPTION FOR MISSING STATEMENTS
		//I decided to make add my own excepetion because you can only catch 
		//and throw items from the exception class
		//--This expection will handle 
		class MISSINGINFOEXECPTION : Exception
		{
			public MISSINGINFOEXECPTION(string message) : base(message)
			{
			}
		}


	}
		
}
