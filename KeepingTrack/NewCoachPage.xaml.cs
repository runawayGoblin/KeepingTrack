using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KeepingTrack
{
	public partial class NewCoachPage : ContentPage
	{
		public NewCoachPage()
		{
			InitializeComponent();
		}


		void OnBtnClick(object sender, System.EventArgs e)
		{
			//VARIABLES
			Entry fnameE, lnameE, schoolE;
			fnameE = this.FindByName<Entry>("fNameEntry");
			lnameE = this.FindByName<Entry>("lNameEntry");
			schoolE = this.FindByName<Entry>("schoolEntry");

			string fname, lname, school;
			fname = fnameE.Text;
			lname = lnameE.Text;
			school = schoolE.Text;

			Label errMsg;
			errMsg = this.FindByName<Label>("errMsgLabel");


			//CHECK VARIABLES TO SEE IF THEY are filled in 
			try 
			{
				if (fname == string.Empty)
				{
					throw new MISSINGINFOEXECPTION("Please Enter Your First Name");
				}

				if (lname == string.Empty)
				{
					throw new MISSINGINFOEXECPTION("Please Enter Your Last Name");

				}

				if (school == string.Empty)
				{
					throw new MISSINGINFOEXECPTION("Please Enter the Name of Your School");
				}

			}
			catch (MISSINGINFOEXECPTION error)
			{
				errMsg.Text = error.Message;
				errMsg.IsVisible = true;
				return;
			}


			errMsg.Text = "Information accepted";
			errMsg.IsVisible = true;

			App.Current.MainPage = new KeepingTrackPage();




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
