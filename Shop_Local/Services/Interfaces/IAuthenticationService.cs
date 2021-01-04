using Shop_Local.Models.Authentication;
using System.Threading.Tasks;

namespace Shop_Local.Services.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsSignedIn { get; }

        User GetCurrentUser();

        Task<AuthenticationResult> SignInWithEmailAndPassword(string email, string password);

        Task<AuthenticationResult> CreateUserWithEmailAndPassword(string email, string password);
    }
}
