using Prism.Commands;
using Prism.Navigation;
using Shop_Local.Views;
using System.Windows.Input;

namespace Shop_Local.ViewModels
{
    public class ShopsViewModel : ViewModelBase
    {
        #region Properties

        #endregion

        #region Services

        protected readonly INavigationService _navigationService;

        #endregion

        #region ICommand

        public ICommand RecommendBusiness { get; set; }

        #endregion

        #region Constructors

        public ShopsViewModel(INavigationService navigationService) : base(navigationService)
        {
            // Services.
            _navigationService = navigationService;

            // Properties
            Title = "Shop Local!";

            // Commands.
            RecommendBusiness = new DelegateCommand(ExecuteRecommendBusiness);
        }

        #endregion

        #region Navigation

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = false;
            base.OnNavigatedTo(parameters);
        }

        #endregion

        #region Methods

        public async void ExecuteRecommendBusiness()
        {
            IsBusy = true;
            await _navigationService.NavigateAsync(nameof(RecommendationPage));
        }

        #endregion
    }
}
