using Xamarin.Forms;
using System.Collections.Generic;

namespace KeepingTrack
{
	public partial class App : Application
	{
		
		public App()
		{
			InitializeComponent();
			//isLoggedIn = false;
			//MainPage = new AddAthletePage();
			//MainPage = new StopwatchPage();
			MainPage = new LoginPage();
			//MainPage = new KeepingTrackPage();
		}

		public static bool isLoggedIn { get; set; }
		public static object userObj { get; set; }
		public static string userID { get; set; }
		public static List<string> raceList { get; set; }
		public static List<string> athList { get; set; }


		protected override void OnStart()
		{
			// Handle when your app starts
			userID = "rholan@cartahge-edu";
			raceList = new List<string>();
			athList = new List<string>();
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
