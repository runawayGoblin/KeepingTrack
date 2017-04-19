using System;
using KeepingTrack.iOS;
using Xamarin.Forms;
using Firebase.Auth;
//using Foundation;


[assembly: Xamarin.Forms.Dependency (typeof (FirebaseAuthImpl))]
namespace KeepingTrack.iOS
{
	public class FirebaseAuthImpl : IFirebaseAuth
	{
		public FirebaseAuthImpl()
		{
		}

		public bool signUp(string email, string password)
		{
			
			bool didWork = true; // RETURN THIS TO SEE IF THE SIGN UP WORKED
			//MAY LATER CHANGE THE RETVAL AS I SEE FIT WITH ERROR MESSAGES


		Auth.DefaultInstance.CreateUser (email, password, (user, error) => {
    		if (error != null) {
        		AuthErrorCode errorCode;
		        if (IntPtr.Size == 8) // 64 bits devices
		            errorCode = (AuthErrorCode)((long)error.Code);
		        else // 32 bits devices
		            errorCode = (AuthErrorCode)((int)error.Code);

		        // Posible error codes that CreateUser method could throw
		        switch (errorCode) {
		        case AuthErrorCode.InvalidEmail:
		        case AuthErrorCode.EmailAlreadyInUse:
		        case AuthErrorCode.OperationNotAllowed:
		        case AuthErrorCode.WeakPassword:
		        default:
		            // Print error
		            break;
		        }
   			} 
				else {
        // Do your magic to handle authentication result
    }
});

			return didWork;
		}


		public bool logIn(string email, string password) {
			bool didWork = true;
			//NSError error = null;

			Auth.DefaultInstance.SignIn (email, password, (user,  error) => 
			{
		    if (error != null) 
				{
		        AuthErrorCode errorCode;
		        if (IntPtr.Size == 8) // 64 bits devices
		            errorCode = (AuthErrorCode)((long)error.Code);
		        else // 32 bits devices
		            errorCode = (AuthErrorCode)((int)error.Code);

		        // Posible error codes that SignIn method with email and password could throw
		        // Visit https://firebase.google.com/docs/auth/ios/errors for more information
		        switch (errorCode)
					{
			        case AuthErrorCode.OperationNotAllowed:
			        case AuthErrorCode.InvalidEmail:
			        case AuthErrorCode.UserDisabled:
			        case AuthErrorCode.WrongPassword:
			        default:
			            // Print error
			            break;
		        	}
					didWork = false;
		    	} 
				else 
				{
		        // Do your magic to handle authentication result
		    }
		});


			return didWork;
		}


	}
}
