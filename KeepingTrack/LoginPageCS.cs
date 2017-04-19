using System;

using Xamarin.Forms;

namespace KeepingTrack
{
	public class LoginPageCS : ContentPage
	{

		Entry emailEntry, passwordEntry;
		Label errMsgLabel;

		public LoginPageCS()
		{
			//declare an instance of the toolbar item
				//toolbar will not show up in the compiled app unless this is present
			var toolbaritem = new ToolbarItem
			{
				Text = "Sign Up"
			};

			toolbaritem.Clicked += OnSignUpBtnClick;
			ToolbarItems.Add(toolbaritem);




			//create an instance for the error message label
			errMsgLabel = new Label();
			//create an instance for the email entry box
			emailEntry = new Entry
			{
				Placeholder = "Email"
			};
			//create an instance for the password entry box
			passwordEntry = new Entry
			{
				Placeholder = "Pass", //give it placeholder 
				IsPassword = true //this will make it private (show "...." instead of "pass")
			};

			var loginBtn = new Button
			{
				Text = "Login"
			};
			loginBtn.Clicked += OnLoginBtnClick;

			Title = "Login";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label {Text = "Email"},
					emailEntry,
					new Label {Text = "Password"},
					passwordEntry,
					loginBtn,
					errMsgLabel
				}
			};


			/*Content = new StackLayout
			{
				Children = {
					new Label { Text = "Log In" }
				}
			};*/


		}
		  void OnLoginBtnClick(object sender, EventArgs e)
		{
			errMsgLabel.Text = "logged in";
			errMsgLabel.IsVisible = true;
		}


		void OnSignUpBtnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new SignUpPageCs());
		}
	}
}

