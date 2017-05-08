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

			fname = fnameEnt.Text;
			//fnameLbl.Text = fname;

			lname = lnameEnt.Text;
			//lnameLbl.Text = lname;

			email = emailEnt.Text;
			email = cleanEmail(email);
			//emailLbl.Text = email;

			year = GradePkr.SelectedIndex.ToString();
			//GradeLbl.Text = year;

			Dictionary<string, string> newRunner = new Dictionary<string, string>();
			newRunner.Add("fname", fname);
			newRunner.Add("lname", lname);
			newRunner.Add("year", year);
			DependencyService.Get<IFirebaseDb>().AddRunnerToDB(email, fname, lname, year);
			DependencyService.Get<IFirebaseDb>().AddRunnerToTeam(email, fname, App.userID);
			

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
