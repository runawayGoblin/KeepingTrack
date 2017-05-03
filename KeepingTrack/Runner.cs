using System;
namespace KeepingTrack
{
	public struct Runner
	{
		private int lapsRan;
		private string name;
		private string lapTimes;

		public Runner(string n, int l,  string t)
		{
			lapsRan = 0;
			name = n;
			lapTimes = t;
		}

		public int getLaps()
		{
			return lapsRan;
		}
		public void setLaps(int l)
		{
			lapsRan = l;
		}
		public string getName()
		{
			return name;
		}
		public void setString(string n)
		{
			name = n;
		}
		public string getTimes()
		{
			return lapTimes;
		}
		public void addTime(string t)
		{
			lapTimes = lapTimes + ";" + t;
		}


	}
}
