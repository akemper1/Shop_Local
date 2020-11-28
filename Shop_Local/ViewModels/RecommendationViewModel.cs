using Prism;
using Prism.Navigation;
using Shop_Local.Validation;
using System;
using System.Text.RegularExpressions;

namespace Shop_Local.ViewModels
{
    public class RecommendationViewModel : ViewModelBase, IActiveAware
    {
        #region Properties

        public bool IsActive { get => _isActive; set => SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        private bool _isActive;

        public string BusinessName
        {
            get { return _businessName; }
            set
            {
                SetProperty(ref _businessName, value);
                IsBusinessNameNotValid = InvalidateText(value, new Regex(RegularExpressions.BusinessName));
            }
        }
        private string _businessName;

        public bool IsBusinessNameNotValid { get => _isBusinessNameNotValid; set => SetProperty(ref _isBusinessNameNotValid, value); }
        private bool _isBusinessNameNotValid;

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
            Title = "Recommend a Business!";

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
            // Only do things if the tab is active.
            if (IsActive)
            {
                
            }
        }

        #endregion
    }
}
