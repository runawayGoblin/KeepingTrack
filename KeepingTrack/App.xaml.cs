using Xamarin.Forms;

namespace KeepingTrack
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new LoginPage();
			//MainPage = new KeepingTrackPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
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
