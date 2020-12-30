using Android.Gms.Extensions;
using Firebase.Auth;
using Shop_Local.Models.Authentication;
using Shop_Local.Services.Interfaces;
using System.Threading.Tasks;

namespace Shop_Local.Droid.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService() { }

        public bool IsSignedIn => FirebaseAuth.Instance.CurrentUser != null;

        public User GetCurrentUser()
        {
            User result = null;

            if (FirebaseAuth.Instance.CurrentUser != null)
            {
                result = new User()
                {
                    Username = FirebaseAuth.Instance.CurrentUser.DisplayName,
                    Email    = FirebaseAuth.Instance.CurrentUser.Email,
                };
            }

            return result;
        }

        public async Task<AuthenticationResult> SignInWithEmailAndPassword(string email, string password)
        {
            var result = AuthenticationResult.None;

            try
            {
                var response = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token    = await response.User.GetIdToken(false);
                result       = AuthenticationResult.Success;
            }

            catch (FirebaseAuthInvalidUserException)
            {
                result = AuthenticationResult.InvalidUser;
            }

            catch (FirebaseAuthInvalidCredentialsException)
            {
                result = AuthenticationResult.InvalidCredentials;
            }

            return result;
        }
    }
}