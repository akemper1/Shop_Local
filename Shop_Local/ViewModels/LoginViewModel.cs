using Prism.Navigation;
using Shop_Local.Services.Interfaces;

namespace Shop_Local.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties

        #region Services

        protected readonly INavigationService _navigationService;

        protected readonly IAuthenticationService _authenticationService;

        #endregion

        #endregion

        public LoginViewModel(INavigationService     navigationService,
                              IAuthenticationService authenticationService) : base(navigationService)
        {
            // Services.
            _navigationService     = navigationService;
            _authenticationService = authenticationService;
        }
    }
}
