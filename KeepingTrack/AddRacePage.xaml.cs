using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KeepingTrack
{
	public partial class AddRacePage : ContentPage
	{
		public AddRacePage()
		{
			InitializeComponent();
			DependencyService.Get<IFirebaseDb>().GetRunnersOnTeam("hi", runnerEmailNameDict);
		}

		private Dictionary<string, string> runnerEmailNameDict = new Dictionary<string, string>();
		private Dictionary<string, string> inRaceDict = new Dictionary<string, string>();
		private List<string> rnInRace = new List<string>();
		private string meetName, date;
		private int numLaps;


		public void onAddRace(object sender, System.EventArgs e)
		{
			int[] laps = { 2, 4, 8, 13, 25 };

			meetName = meetNameEnt.Text;

			numLaps = laps[distancePkr.SelectedIndex];

			date = datePkr.Date.ToString();

			DependencyService.Get<IFirebaseDb>().AddRace(meetName, numLaps.ToString(), date);
			List<athleteInfo> ainf = new List<athleteInfo>();

			foreach (var sRN in rnInRace)
			{
				athleteInfo atemp = new athleteInfo(sRN, inRaceDict[sRN]);
				ainf.Add(atemp);
			}


			DependencyService.Get<IFirebaseDb>().AddRunnerToRace(ainf.ToArray(), App.userID + "--" +meetName);
			//string[] emal = inRaceDict.val;
			//object[] emailobj = { };
			//string[] name = inRaceDict.Keys;
			//object[] nameobj = { };
			/*for (int i = 0; i < emal.Length; i++)
			{
				emailobj[0] = emal[0];
				nameobj[0] = name[0];
			}*/

			Navigation.PushAsync(new StopwatchPage());
		}

		public void onNext(object sender, System.EventArgs e)
		{
			meetNameEnt.IsVisible = false;
			meetNameLbl.IsVisible = false;

			distancePkr.IsVisible = false;
			distanceLbl.IsVisible = false;

			dateLbl.IsVisible = false;
			datePkr.IsVisible = false;//			runnerList.IsVisible = true;
			createRaceBtn.IsVisible = true;
			nextBtn.IsVisible = false;

			runnerList.ItemsSource = runnerEmailNameDict.Keys;

			runnerList.IsVisible = true;
		}

		public void onRunnerTapped(object sender, ItemTappedEventArgs e)
		{

			string name = e.Item.ToString();
			if (inRaceDict.ContainsKey(name))
			{
				athChosenLbl.Text = name + "removed";
				inRaceDict.Remove(name);
				rnInRace.Remove(name);
				//ViewCell.View.BackgroundColor =Color.White;
			}
			else
			{
				athChosenLbl.Text = name + "added";
				athChosenLbl.IsVisible = true;
				rnInRace.Add(name);
				string email = runnerEmailNameDict[name];
				inRaceDict.Add(name, email);
			}
		}
	}
}
