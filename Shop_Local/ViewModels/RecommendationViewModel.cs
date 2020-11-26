using Prism;
using Prism.Navigation;
using System;

namespace Shop_Local.ViewModels
{
    public class RecommendationViewModel : ViewModelBase, IActiveAware
    {
        #region Properties

        public bool IsActive { get => _isActive; set => SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        private bool _isActive;

        #endregion

        #region Services

        protected readonly INavigationService _navigationService;

        #endregion

        #region Event Handlers

        public event EventHandler IsActiveChanged;

        #endregion

        #region Constructors

        public RecommendationViewModel(INavigationService navigationService) : base(navigationService)
        {
            // Services.
            _navigationService = navigationService;

            // Properties
            Title = "Recommend a Shop!";

            // Event Handlers.
            IsActiveChanged += OnSelected;
        }

        #endregion

        #region Methods

        private void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        private async void OnSelected(object sender, EventArgs e)
        {
            // Only do things if the tab is active.
            if (IsActive)
            {
                
            }
        }

        #endregion
    }
}
