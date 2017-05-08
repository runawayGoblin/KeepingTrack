using System;
using System.Threading.Tasks;
namespace KeepingTrack
{
	public interface IFirebaseAuth
	{
		//These are bool, so we know whether or not the sign up/in worked or not
		void signUp(string email, string password,  object user,  string error);

		bool logIn(string email, string password);


	}
}
