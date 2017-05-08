using Xamarin.Forms;

namespace KeepingTrack
{
	public partial class App : Application
	{
		
		public App()
		{
			InitializeComponent();
			isLoggedIn = false;
			MainPage = new AddAthletePage();
			//MainPage = new StopwatchPage();
			//MainPage = new LoginPage();
			//MainPage = new KeepingTrackPage();
		}

		public static bool isLoggedIn { get; set; }
		public static object userObj { get; set; }
		public static string userID { get; set; }


		protected override void OnStart()
		{
			// Handle when your app starts
			userID = "B1Bzx0YVuPbB9XZyFAEL36DDMyN2";
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
