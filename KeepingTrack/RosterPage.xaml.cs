using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KeepingTrack
{
	public partial class RosterPage : ContentPage
	{
		public RosterPage()
		{
			InitializeComponent();

			App.athList.Add("Jenny");
			App.athList.Add("Shannon");
			App.athList.Add("Morgan");
			App.athList.Add("Alicia");
			App.athList.Add("Mia");
			App.athList.Add("Maddie");
			App.athList.Add("emily");
			App.athList.Add("Kaylie");


			rosterLView.ItemsSource = App.athList;
		}

		async void onNewAthlete(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new AddAthletePage());
		}

	}
}
