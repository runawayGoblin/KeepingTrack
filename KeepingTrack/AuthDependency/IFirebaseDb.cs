using System;
using System.Collections.Generic;
namespace KeepingTrack
{
	public interface IFirebaseDb
	{

		bool AddRunnerToDB(string email, string fname, string lname, string year);

		Dictionary<string, Runner> GetRunnersOnTeam(string team);//team will be null if the user ever needs to get all of the runners in the db 

		bool AddRunnerToTeam(string email, string fname, string coachid);


		bool AddRace(string rname, string date, string rdistance);
		Dictionary<string, Race> GetRaces();


	}
}
