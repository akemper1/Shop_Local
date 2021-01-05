using Prism.Commands;
using Prism.Navigation;
using Shop_Local.Models.Authentication;
using Shop_Local.Services.Interfaces;
using Shop_Local.Validation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shop_Local.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        #region Properties

        #region Email

        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
                IsEmailNotValid = InvalidateText(value, new Regex(RegularExpressions.Email));

                // Sets the proper error message based off user input or lack there of.
                if (string.IsNullOrWhiteSpace(_email))
                {
                    EmailErrorText = "Required *";
                }
                else
                {
                    EmailErrorText = "Not a valid email.";
                }
            }
        }
        private string _email = string.Empty;

        public bool IsEmailNotValid { get => _isEmailNotValid; set => SetProperty(ref _isEmailNotValid, value); }
        private bool _isEmailNotValid;

        public string EmailErrorText { get => _emailErrorText; set => SetProperty(ref _emailErrorText, value); }
        private string _emailErrorText;

        #endregion

        #region Password

        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                IsPasswordNotValid = InvalidateText(value, new Regex(RegularExpressions.Email));

                // Sets the proper error message based off user input or lack there of.
                if (string.IsNullOrWhiteSpace(_password))
                {
                    PasswordErrorText = "Required *";
                }
                else
                {
                    PasswordErrorText = "Not a valid password.";
                }
            }
        }
        private string _password = string.Empty;

        public bool IsPasswordNotValid { get => _isPasswordNotValid; set => SetProperty(ref _isPasswordNotValid, value); }
        private bool _isPasswordNotValid;

        public string PasswordErrorText { get => _passwordErrorText; set => SetProperty(ref _passwordErrorText, value); }
        private string _passwordErrorText;

        public string ConfirmedPassword
        {
            get { return _confirmedPassword; }
            set
            {
                SetProperty(ref _password, value);
                IsConfirmedPasswordNotValid = InvalidateText(value, new Regex(RegularExpressions.Email));

                // Sets the proper error message based off user input or lack there of.
                if (string.IsNullOrWhiteSpace(_confirmedPassword))
                {
                    IsConfirmedPasswordErrorText = "Required *";
                }
                else
                {
                    IsConfirmedPasswordErrorText = "Not a valid password.";
                }
            }
        }
        private string _confirmedPassword = string.Empty;

        public bool IsConfirmedPasswordNotValid { get => _isConfirmedPasswordNotValid; set => SetProperty(ref _isConfirmedPasswordNotValid, value); }
        private bool _isConfirmedPasswordNotValid;

        public string IsConfirmedPasswordErrorText { get => _isConfirmedPasswordErrorText; set => SetProperty(ref _isConfirmedPasswordErrorText, value); }
        private string _isConfirmedPasswordErrorText;

        #endregion

        #region Submission Validation

        // Boolean to turn on and off submit button based of user input.
        public bool CanSubmit => !IsEmailNotValid && !IsPasswordNotValid && !IsConfirmedPasswordNotValid;

        #endregion

        #endregion

        #region Services

        protected readonly INavigationService _navigationService;

        protected readonly IAuthenticationService _authenticationService;

        #endregion

        #region ICommand

        public ICommand CreateAccount { get; set; }

        #endregion

        public SignUpViewModel(INavigationService     navigationService,
                               IAuthenticationService authenticationService) : base(navigationService)
        {
            // Services.
            _navigationService     = navigationService;
            _authenticationService = authenticationService;

            // Commands.
            CreateAccount = new DelegateCommand(async () => await Submit());
        }

        #region Methods

        private async Task ExecuteCreateAccount()
        {
            var result = await _authenticationService.CreateUserWithEmailAndPassword(Email, Password);

            if (result == AuthenticationResult.Success)
            {
                await _navigationService.NavigateAsync("NavigationPage/ShopsPage");
            }
        }

        Task Submit()
        {
            return ExecuteCreateAccount();
        }

        #endregion
    }
}
