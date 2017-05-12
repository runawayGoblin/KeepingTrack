using System;
using System.Collections.Generic;
namespace KeepingTrack
{
	public interface IFirebaseDb
	{

		bool AddRunnerToDB(string email, string fname, string lname, string year);

		void GetRunnersOnTeam(string team, Dictionary<string, string> r);//team will be null if the user ever needs to get all of the runners in the db 

		bool AddRunnerToTeam(string email, string fname, string coachid);

		void AddRunnerToRace(athleteInfo[] ainfo, string rname);


		bool AddRace(string rname, string date, string rdistance);

		void GetRaces(Dictionary<string, Race> races);


	}
}
