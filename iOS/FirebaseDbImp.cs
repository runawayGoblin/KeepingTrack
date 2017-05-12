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

		public void GetRunnersOnTeam(string cID, Dictionary<string, string> r)
		{

			//Dictionary<string, Runner> r = new Dictionary<string, string>();
			NSDictionary dict;
			DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();
			DatabaseReference aIRNode = rootNode.GetChild("AthletesOnTeam").GetChild("CarthageW");
			//string teamName="CarthageW";
			aIRNode.ObserveSingleEvent(DataEventType.Value, (snapshot) =>
			{
				dict = snapshot.GetValue<NSDictionary>();
				object[] keys = dict.Keys;

				foreach (object k in keys)
				{
					object val = dict.ValueForKey((NSString)k);
					r.Add(val.ToString(), k.ToString());
				}

			}, (error) =>
			{
				Console.WriteLine(error.LocalizedDescription);
			});



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
		public bool AddRace(string rname, string distance, string date)
		{
			bool retval = true;

			DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();
			DatabaseReference raceNode = rootNode.GetChild("Races").GetChild(App.userID + "--" + rname);

			object[] keys = { "meetName", "eventName", "date" };
			object[] values = { rname, distance, date };
			var newAthlete = NSDictionary.FromObjectsAndKeys(values, keys, keys.Length);



			raceNode.SetValue<NSDictionary>(newAthlete);



			return retval;

		}
		public void AddRunnerToRace(athleteInfo[] aInfo, string rname)
		{
			DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();
			DatabaseReference raceNode = rootNode.GetChild("AthletesInRaces").GetChild(App.userID + "--" + rname);
			/*object[] keys;
			object[] vals;
			int itr = 0;*/
			IDictionary<NSObject, NSObject> athDict= new NSMutableDictionary();
			foreach (athleteInfo a in aInfo)
			{
				athDict.Add((NSString)a.name, (NSString)a.rID);
			}

			//var newAthlete = NSDictionary.FromObjectsAndKeys(values, keys, keys.Length);



			raceNode.SetValue<NSDictionary>((NSDictionary)athDict);
		}




		public void GetRaces(Dictionary<string, Race> rcs)
		{
			NSDictionary dict;
			DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();
			DatabaseReference racesNode = rootNode.GetChild("Races");
			//string teamName="CarthageW";
			racesNode.ObserveSingleEvent(DataEventType.Value, (snapshot) =>
						{
							dict = snapshot.GetValue<NSDictionary>();
							object[] keys = dict.Keys;
							string a, c;
							int b;
							
							foreach (object k in keys)
							{
								object val = dict.ValueForKey((NSString)k);
								//rcs.Add(val.ToString(), k.ToString());
							}

						}, (error) =>
						{
							Console.WriteLine(error.LocalizedDescription);
						});



			//DatabaseReference AperCoach = rootNode.GetChild("AthletesOnTeam").GetChild(cID);
		}
	}
}
