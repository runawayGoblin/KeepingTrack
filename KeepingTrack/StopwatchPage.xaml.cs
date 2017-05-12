using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;


namespace KeepingTrack
{
	public partial class StopwatchPage : ContentPage
	{
		private bool inRace = false;
		private int runnersLeft;
		private Label splLbl;
		private Label timerLbl;
		private Label maddieLbl;
		private Label kaylieLbl;
		private Button startLap;
		private string currTimeStr = "";
		private int numLaps;
		//private Runner Maddie = new Runner(0, "Maddie", "");
		//private Runner Kaylie = new Runner(0, "Kaylie", "");
		private Stopwatch sw = new Stopwatch();
		//private IStopWatchImp sw;
		private Dictionary<string, Runner> runners;
		//private Race raceSettings;

		public StopwatchPage()
		{
			InitializeComponent();
			//raceSettings = r;
			splLbl = this.FindByName<Label>("SplitsLabel");
			startLap = this.FindByName<Button>("StartLapBtn");
			//lapCount = 00;
			timerLbl = this.FindByName<Label>("TimeLbl");
			maddieLbl = this.FindByName<Label>("MLabel");
			kaylieLbl = this.FindByName<Label>("KLabel");
			runners = new Dictionary<string, Runner>();
			runners.Add("Shannon", new Runner("Shannon", 0, ""));
			runners.Add("Jenny", new Runner("Jenny", 0, ""));
			numLaps = 4;
			runnersLeft = 2;
			//runnersLeft = 2;



		}

		/*async*/
		async void StartStopClick(object sender, System.EventArgs e)
		{
			if (!inRace)
			{
				//vars
				inRace = true;
				sw.Restart();
				updateTimer();
				//labels
				splLbl.IsVisible = true;
				//splLbl.Text = Maddie.getName() + " : " + Maddie.getLaps().ToString() + "/n " + Kaylie.getName() + " : " + Kaylie.getLaps().ToString() + "/n " + nameBtnClicked + " was clicked";
				startLap.Text = "STOP";
			}
			else
			{
				sw.Stop();
				inRace = false;
				startLap.Text = "START";
			}

		}

		void LapClick(object sender, System.EventArgs e)
		{
			if (inRace)
			{
				//get vars
				string timeOnLap = currTimeStr;
				string nameBtnClicked = ((Button)sender).Text;
				Runner tempRunner = runners[nameBtnClicked];

				//set vals in the temp runner
				tempRunner.setLaps(tempRunner.getLaps() + 1);
				tempRunner.addTime(timeOnLap);

				//upate the cals for the temp runner in the dict
				runners[nameBtnClicked] = tempRunner;

				//update the label
				splLbl.Text = tempRunner.getName() + " : " + tempRunner.getLaps().ToString() + ": " + timeOnLap;
				//check and balances
				if (tempRunner.getLaps() == numLaps && nameBtnClicked == "Shannon")
				{
					MaddieBtn.IsVisible = false;
					runnersLeft--;

				}
				else if (tempRunner.getLaps() == numLaps && nameBtnClicked == "Jenny")
				{
					KaylieBtn.IsVisible = false;
					runnersLeft--;
				}


				//CHECK to see if there are any runners left so the race and timer and tasks can stop
				if (runnersLeft < 1)
				{
					endRace();
				}

			}
		}
		void endRace()
		{

			inRace = false;
			//lapCount = 0;
			splLbl.Text = "Race completed";
			//startLap.BackgroundColor =new Color(255, 255, 255);
			sw.Stop();
			//Runner temp = runners["Maddie"];
			maddieLbl.Text = "Shannon: " + runners["Shannon"].getTimes();
			maddieLbl.IsVisible = true;
			//temp = runners["Maddie"];
			kaylieLbl.Text = "Jenny" + runners["Jenny"].getTimes();
			kaylieLbl.IsVisible = true;
		}


		async void updateTimer()
		{

			await Task.Run(() =>
			{
				while (inRace)
				{
					int mili, min, sec;
					mili = (int)sw.ElapsedMilliseconds;

					min = mili / 60000;
					mili = mili - (min * 60000);

					sec = mili / 1000;
					mili = (mili - (sec * 1000)) / 10;

					currTimeStr = min.ToString() + ":" + sec.ToString() + "." + mili.ToString();


					//string slc = sw.Elapsed.ToString();
					Device.BeginInvokeOnMainThread(() =>
					{
						timerLbl.Text = currTimeStr;
					});
					Task.Delay(100).Wait();
				}
			});
		}
	}
}