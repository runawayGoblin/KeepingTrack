using System;
namespace KeepingTrack
{
	public interface IFirebaseAuth
	{
		//These are bool, so we know whether or not the sign up/in worked or not
		bool signUp(string email, string password);

		bool logIn(string email, string password);


	}
}
