using Firebase.Auth;
using Shop_Local.Models.Authentication;
using Shop_Local.Services.Interfaces;
using System;
using System.Threading.Tasks;
using User = Shop_Local.Models.Authentication.User;

namespace Shop_Local.iOS.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService() { }

        public bool IsSignedIn => Auth.DefaultInstance.CurrentUser != null;

        public User GetCurrentUser()
        {
            User result = null;

            if (Auth.DefaultInstance.CurrentUser != null)
            {
                result = new User()
                {
                    Username = Auth.DefaultInstance.CurrentUser.DisplayName,
                    Email    = Auth.DefaultInstance.CurrentUser.Email,
                };
            }

            return result;
        }

        public async Task<AuthenticationResult> SignInWithEmailAndPassword(string email, string password)
        {
            var result = AuthenticationResult.None;

            try
            {
                var response = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                var token    = await response.User.GetIdTokenAsync();
                result       = AuthenticationResult.Success;
            }

            catch (Exception)
            {
                result = AuthenticationResult.InvalidCredentials;
            }

            return result;
        }

        public async Task<AuthenticationResult> CreateUserWithEmailAndPassword(string email, string password)
        {
            var result = AuthenticationResult.None;

            try
            {
                var response = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                var token    = await response.User.GetIdTokenAsync();
                result       = AuthenticationResult.Success;
            }

            catch (Exception)
            {
                result = AuthenticationResult.UserExists;
            }

            return result;
        }
    }
}