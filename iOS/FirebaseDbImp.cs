using System;
using Xamarin.Forms;
using KeepingTrack.iOS;
using Firebase.Database;
using System.Collections.Generic;
using Foundation;
[assembly: Xamarin.Forms.Dependency(typeof(FirebaseDbImp))]
namespace KeepingTrack.iOS
{

	public class FirebaseDbImp : IFirebaseDb
	{
		public FirebaseDbImp()
		{
		}

		public bool AddRunnerToDB(string email, string fname, string lname, string year)
		{
			bool retval = true;
			DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();

			//DatabaseReference rootAthleteNode = rootNode.GetChild("Athletes");

			//NSDictionary newAth = new NSDictionary("fname", fname, "lname", lname, "year", year);
			DatabaseReference rootNewKey = rootNode.GetChild("Athletes").GetChild(email);
			//NSString keystr = (NSString)"myoung@carthage-edu";
			//rootAthleteNode.SetValue<NSString>(keystr);


			object[] keys = { "fname", "lname", "year" };
			object[] values = { fname, lname, year };
			var newAthlete = NSDictionary.FromObjectsAndKeys(values, keys, keys.Length);



			rootNewKey.SetValue<NSDictionary>(newAthlete);
			return retval;

		}

		public Dictionary<string, Runner> GetRunnersOnTeam(string teamname)
		{

			Dictionary<string, Runner> r = new Dictionary<string, Runner>();

			r.Add("1", new Runner("m", 1, "t"));

			return r;
		}


		public bool AddRunnerToTeam(string e, string fname, string cID)
		{
			bool didwork = true;
			string teamName;
			string teamName2;
			DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();

			//DatabaseReference AonTeamNode = rootNode.GetChild("AthletesOnTeam").GetChild(cID);
			DatabaseReference teamNameNode = rootNode.GetChild("Coaches").GetChild("rholan@carthage-edu").GetChild("team");


			//DataSnapshot ds;
			teamName2 = teamNameNode.ToString(); ;
			teamNameNode.ObserveSingleEvent(DataEventType.Value, (snapshot) =>
			{
				teamName = snapshot.GetValue<NSString>().ToString();
				/*object[] keys = { e };
				object[] values = { fname };
				var athOnTeam = NSDictionary.FromObjectsAndKeys(values, keys, keys.Length);
				*/

				DatabaseReference AonTeamNode = rootNode.GetChild("AthletesOnTeam").GetChild(teamName).GetChild(e);

				AonTeamNode.SetValue<NSString>((NSString)fname);
			}, (error) =>
			{
				Console.WriteLine(error.LocalizedDescription);
				didwork = false;
			});

			return didwork;
		}
		public bool AddRace(string rname, string date, string distance)
		{
			bool retval = true;





			return retval;

		}

		public Dictionary<string, Race> GetRaces()
		{

			Dictionary<string, Race> r = new Dictionary<string, Race>();

			r.Add("1", new Race("1", "2", "3"));


			return r;
		}
		//DatabaseReference AperCoach = rootNode.GetChild("AthletesOnTeam").GetChild(cID);

	}
}
