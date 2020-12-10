﻿using Prism.Navigation;
using Shop_Local.Validation;
using System.Text.RegularExpressions;

namespace Shop_Local.ViewModels
{
    public class RecommendationViewModel : ViewModelBase
    {
        #region Properties

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

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                SetProperty(ref _phoneNumber, value);
                IsPhoneNumberNotValid = InvalidateText(value, new Regex(RegularExpressions.PhoneNumber));
            }
        }
        private string _phoneNumber;

        public bool IsPhoneNumberNotValid { get => _isPhoneNumberNotValid; set => SetProperty(ref _isPhoneNumberNotValid, value); }
        private bool _isPhoneNumberNotValid;

        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
                IsEmailNotValid = InvalidateText(value, new Regex(RegularExpressions.Email));
            }
        }
        private string _email;

        public bool IsEmailNotValid { get => _isEmailNotValid; set => SetProperty(ref _isEmailNotValid, value); }
        private bool _isEmailNotValid;

        #endregion

        #region Services

        protected readonly INavigationService _navigationService;

        #endregion

        #region Constructors

        public RecommendationViewModel(INavigationService navigationService) : base(navigationService)
        {
            // Services.
            _navigationService = navigationService;

            // Properties
            Title = "Recommend a Business!";
        }

        #endregion

        #region Methods

        #endregion
    }
}
