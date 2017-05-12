using System;
using Android;
using Firebase.Auth;
using Xamarin.Forms;
using KeepingTrack.Droid;
using System.Timers;

[assembly: Xamarin.Forms.Dependency(typeof(FirebaseAuthImpl))]
namespace KeepingTrack.Droid
{
	public class FirebaseAuthImpl : IFirebaseAuth
	{
		public FirebaseAuthImpl()
		{
		}



		public void signUp(string email, string password)
		{
			string ErrCode = null;//will be null if nothing bad happens
			bool retval = true;
			//Not needed if the try catch throws an error
			//Exception error= null;


			try
			{
				FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

			}
			catch (Exception e)
			{
				ErrCode = e.Message;
			}

			return retval;
			//return ErrCode;//will return the string with the error 
		}

		public bool logIn(string email, string password)
		{
			bool retVal = true;


			return retVal;
		}
	}
}
