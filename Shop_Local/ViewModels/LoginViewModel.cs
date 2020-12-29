using Prism.Navigation;

namespace Shop_Local.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties

        #region Services

        protected readonly INavigationService _navigationService;

        #endregion

        #endregion

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            // Services.
            _navigationService = navigationService;
        }
    }
}
