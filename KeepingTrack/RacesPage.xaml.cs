using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KeepingTrack
{
	public partial class RacesPage : ContentPage
	{
		//private List<string> racesList = new List<string>();
		public RacesPage()
		{
			InitializeComponent();
			DependencyService.Get<IFirebaseDb>().GetRaces(races);

			App.raceList.Add("CCIW Championship 10k");
			App.raceList.Add("CCIW Championship 5k");
			App.raceList.Add("CCIW Championship 3k steeple");
			App.raceList.Add("CCIW Championship 800m");
			App.raceList.Add("NCC Last Chance");
			racesLView.ItemsSource = App.raceList;

		}

		private Dictionary<string, Race> races = new Dictionary<string, Race>();
		async void onNewRace(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new AddRacePage());

		}
	}
}