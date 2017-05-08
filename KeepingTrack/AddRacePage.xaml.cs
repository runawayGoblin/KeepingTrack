using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KeepingTrack
{
	public partial class AddRacePage : ContentPage
	{
		public AddRacePage()
		{
			InitializeComponent();
		}

		private string raceName, distance, date;

		public void onAddAthlete(object sender, System.EventArgs e)
		{

			raceName = raceNameLbl.Text;


			distance = distancePkr.SelectedIndex.ToString();

		//	date = dateLbl.Date;

		//	email = emailEnt.Text;
		//	emailLbl.Text = email;

			//year = GradePkr.SelectedIndex.ToString();
			//GradeLbl.Text = year;


		}

	}
}
