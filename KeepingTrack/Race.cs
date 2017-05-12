using System;
using System.Collections.Generic;
namespace KeepingTrack
{
	public struct Race
	{

		private string rname, date;
		private int laps;
		private Dictionary<string, Runner> runnerDict; 
		public Race(string r, string dt, int l)
		{
			runnerDict = new Dictionary<string, Runner>();
			rname = r;
			date = dt;
			laps = l;
		}

		public string getRaceName()
		{
			return rname;

		}
		public string getRaceDate()
		{
			return date;
		}
		public int getRacelaps()
		{
			return laps;
		}
		public void addRunner(string runName, string rID)
		{
			runnerDict.Add(runName, new Runner(runName, 0, ""));
		}
		public Runner getRunner(string runName)
		{
			return runnerDict[runName];
		}
		public Dictionary<string, Runner> getDict()
		{
			return runnerDict;
		}
	}
}
