using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KeepingTrack
{
	public partial class AddAthletePage : ContentPage
	{
		public AddAthletePage()
		{
			InitializeComponent();
		}

		private string fname, lname, email, year;
		public void onAddAthlete(object sender, System.EventArgs e)
		{
			string[] years = { "", "2017", "2018", "2019", "2020", "2021" };

			//titleHeader.Text = "Athlete Created";

			fname = fnameEnt.Text;
			fnameLbl.Text = "First Name: " + fname;
			fnameSPACE.IsVisible = true;
			fnameEnt.IsVisible = false;

			lname = lnameEnt.Text;
			lnameLbl.Text = "Last Name: " + lname;
			lnameSPACE.IsVisible = true;
			lnameEnt.IsVisible = false;

			email = emailEnt.Text;
			email = cleanEmail(email);
			emailLbl.Text = "Email: " + email;
			emailSPACE.IsVisible = true;
			emailEnt.IsVisible = false;

			year = years[GradePkr.SelectedIndex];
			GradeLbl.Text = "Graduation Year: " + year;
			gradeSPACE.IsVisible = true;
			GradePkr.IsVisible = false;

			creatAthleteBtn.IsVisible = false;
			editAthBtn.IsVisible = true;
			Dictionary<string, string> newRunner = new Dictionary<string, string>();
			newRunner.Add("fname", fname);
			newRunner.Add("lname", lname);
			newRunner.Add("year", year);
			DependencyService.Get<IFirebaseDb>().AddRunnerToDB(email, fname, lname, year);
			DependencyService.Get<IFirebaseDb>().AddRunnerToTeam(email, fname, App.userID);



		}

		public void onEditAthlete(object sender, System.EventArgs e)
		{

			//titleHeader.Text = "Edit Athlete";

			fnameLbl.Text = "First Name";
			fnameSPACE.IsVisible = false;
			fnameEnt.IsVisible = true;


			lnameLbl.Text = "Last Name";
			lnameSPACE.IsVisible = false;
			lnameEnt.IsVisible = true;



			emailLbl.Text = "Email";
			emailSPACE.IsVisible = false;
			emailEnt.IsVisible = true;


			GradeLbl.Text = "Graduation Year";
			gradeSPACE.IsVisible = false;
			GradePkr.IsVisible = true;

			editAthBtn.IsVisible = false;
			creatAthleteBtn.IsVisible = true;

		}
		private string cleanEmail(string e)
		{
			string retval = null;
			for (int i = 0; i < e.Length; i++)
			{
				if (e[i] == '.')
					retval = retval + "-";
				else
					retval = retval + e[i];
			}
			return retval;
		}
	}
}
