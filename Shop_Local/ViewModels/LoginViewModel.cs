using Prism.Commands;
using Prism.Navigation;
using Shop_Local.Services.Interfaces;
using Shop_Local.Views;
using System.Windows.Input;

namespace Shop_Local.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties

        #region Services

        protected readonly INavigationService _navigationService;

        protected readonly IAuthenticationService _authenticationService;

        #endregion

        #region ICommand

        public ICommand SignUp { get; set; }

        #endregion

        #endregion

        public LoginViewModel(INavigationService     navigationService,
                              IAuthenticationService authenticationService) : base(navigationService)
        {
            // Services.
            _navigationService     = navigationService;
            _authenticationService = authenticationService;

            // Commands.
            SignUp = new DelegateCommand(ExecuteSignUp);
        }

        #region Methods

        public async void ExecuteSignUp()
        {
            await _navigationService.NavigateAsync(nameof(SignUpPage));
        }

        #endregion
    }
}
