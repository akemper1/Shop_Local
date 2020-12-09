using Prism;
using Prism.Navigation;
using System;

namespace Shop_Local.ViewModels
{
    public class ShopsViewModel : ViewModelBase, IActiveAware
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

        public ShopsViewModel(INavigationService navigationService) : base(navigationService)
        {
            // Services.
            _navigationService = navigationService;

            // Properties
            Title = "Shop Local!";

            // Event Handlers.
            IsActiveChanged += OnSelected;
        }

        #endregion

        #region Methods

        private void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnSelected(object sender, EventArgs e)
        {
            if (IsActive)
            {

            }
        }

        #endregion
    }
}
