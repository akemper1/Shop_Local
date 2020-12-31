using Prism.Navigation;

namespace Shop_Local.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        #region Services

        protected readonly INavigationService _navigationService;

        #endregion

        public SignUpViewModel(INavigationService navigationService) : base(navigationService)
        {
            // Services.
            _navigationService = navigationService;
        }
    }
}
