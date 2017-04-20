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

			email = emailE.Text;
			password1 = password1E.Text;
			password2 = password2E.Text;

			Label errMsg;
			errMsg = this.FindByName<Label>("errMsgLabel");


			//TEST TO SEE IF ALL OF THE VARIBLES ARE THERE
			//was thinking aout a try catch block, but that seemed unnecisary
			//will ask for advice later
			try 
			{
				
				//check to see if the user entered an email
				if (!isValid(email))
				{
					throw new MISSINGINFOEXECPTION("Please Enter ane Email Adress");
				}
				//check to see it they entered a pasword in p1 and 2
					//put the two passowrds together because the error message would be the same
				if (!(isValid(password1) && isValid(password2)))
				{
					throw new MISSINGINFOEXECPTION("Missing a Password");
				}
				// check to see it the passwords match
				if (password1 != password2)
				{
					throw new MISSINGINFOEXECPTION("Passwords do not match");
				}


			}
			catch (MISSINGINFOEXECPTION error)
			{

				errMsg.Text = error.Message;//set the error display method
				errMsg.IsVisible = true;//show the error message
				return;//this will skip to the end of the function,
					//so that no code after this point will continue to run
					//causing chaous in Auth, but still making it so the user 
					//can easily correct the mistake without restarting anything
			}



			bool signInAuth = DependencyService.Get<IFirebaseAuth>().signUp(email, password1);



			if (signInAuth == true)
			{
				//initial test, if the sign in works, show it on the 
				//errMsg.IsVisible = true;
				//errMsg.Text = "Acct Added";

				//real processes 
				App.Current.MainPage = new NewCoachPage();


			}
			else
			{
				errMsg.IsVisible = true;
				errMsg.Text = "Unable to Add Account at This Time";
			}


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


		bool isValid(string test)
		{
			bool retVal = true;
			if (test == null)
			{
				retVal = false;
			}

			return retVal;
		}

	}
}
