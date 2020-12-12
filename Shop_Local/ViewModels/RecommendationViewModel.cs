using Prism.Commands;
using Prism.Navigation;
using Shop_Local.Enums;
using Shop_Local.Models;
using Shop_Local.Services.Interfaces;
using Shop_Local.Validation;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shop_Local.ViewModels
{
    public class RecommendationViewModel : ViewModelBase
    {
        #region Properties

        #region Business Name

        public string BusinessName
        {
            get { return _businessName; }
            set
            {
                SetProperty(ref _businessName, value);
                IsBusinessNameNotValid = InvalidateText(value, new Regex(RegularExpressions.BusinessName));

                if (string.IsNullOrWhiteSpace(_businessName))
                {
                    BusinessNameErrorText = "Required *";
                }
                else
                {
                    BusinessNameErrorText = "Business name can not contain special characters.";
                }
            }
        }
        private string _businessName = "";

        public bool IsBusinessNameNotValid { get => _isBusinessNameNotValid; set => SetProperty(ref _isBusinessNameNotValid, value); }
        private bool _isBusinessNameNotValid;

        public string BusinessNameErrorText { get => _businessNameErrorText; set => SetProperty(ref _businessNameErrorText, value); }
        private string _businessNameErrorText;

        #endregion

        #region Contact Information

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                SetProperty(ref _phoneNumber, value);
                IsPhoneNumberNotValid = InvalidateText(value, new Regex(RegularExpressions.PhoneNumber));

                if (string.IsNullOrWhiteSpace(_phoneNumber))
                {

                }
            }
        }
        private string _phoneNumber = "";

        public bool IsPhoneNumberNotValid { get => _isPhoneNumberNotValid; set => SetProperty(ref _isPhoneNumberNotValid, value); }
        private bool _isPhoneNumberNotValid;

        public string PhoneNumberErrorText { get => _phoneNumberErrorText; set => SetProperty(ref _phoneNumberErrorText, value); }
        private string _phoneNumberErrorText;

        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
                IsEmailNotValid = InvalidateText(value, new Regex(RegularExpressions.Email));

                if (string.IsNullOrWhiteSpace(_email))
                {
                    EmailErrorText = "Required *";
                }
                else
                {
                    EmailErrorText = "Not a valid email address.";
                }
            }
        }
        private string _email = "";

        public bool IsEmailNotValid { get => _isEmailNotValid; set => SetProperty(ref _isEmailNotValid, value); }
        private bool _isEmailNotValid;

        public string EmailErrorText { get => _emailErrorText; set => SetProperty(ref _emailErrorText, value); }
        private string _emailErrorText;

        #endregion

        #region Address Information

        public string StreetNumber 
        {
            get { return _streetNumber; }
            set
            {
                SetProperty(ref _streetNumber, value);

            }
        }
        private string _streetNumber;

        public bool IsStreetNumberNotValid { get => _isStreetNumberNotValid; set => SetProperty(ref _isStreetNumberNotValid, value); }
        private bool _isStreetNumberNotValid;

        public string StreetName
        {
            get { return _streetName; }
            set
            {
                SetProperty(ref _streetName, value);

            }
        }
        private string _streetName;

        public bool IsStreetNameNotValid { get => _iStreetNameNotValid; set => SetProperty(ref _iStreetNameNotValid, value); }
        private bool _iStreetNameNotValid;

        public string City
        {
            get { return _city; }
            set
            {
                SetProperty(ref _city, value);

            }
        }
        private string _city;

        public bool IsCityNotValid { get => _isCityNotValid; set => SetProperty(ref _isCityNotValid, value); }
        private bool _isCityNotValid;

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                SetProperty(ref _zipCode, value);

            }
        }
        private string _zipCode;

        public bool IsZipCodeNotValid { get => _isZipCodeNotValid; set => SetProperty(ref _isZipCodeNotValid, value); }
        private bool _isZipCodeNotValid;

        public string Suite
        {
            get { return _suite; }
            set
            {
                SetProperty(ref _suite, value);

            }
        }
        private string _suite;

        public bool IsSuiteNotValid { get => _isSuiteNotValid; set => SetProperty(ref _isSuiteNotValid, value); }
        private bool _isSuiteNotValid;

        #endregion

        #region Category Information

        public BusinessCategory PriamryCategory { get => _primaryCategory; set => SetProperty(ref _primaryCategory, value); }
        private BusinessCategory _primaryCategory;

        public IList<BusinessCategory> SecondaryCategories { get => _secondaryCategories; set => SetProperty(ref _secondaryCategories, value); }
        private IList<BusinessCategory> _secondaryCategories;

        #endregion

        #endregion

        #region Services

        protected readonly INavigationService _navigationService;

        protected readonly IFirestoreDatabase _firestoreDatabase;

        #endregion

        #region ICommand

        public ICommand AddBusiness { get; set; }

        #endregion

        #region Constructors

        public RecommendationViewModel(INavigationService navigationService, IFirestoreDatabase firestoreDatabase) : base(navigationService)
        {
            // Services.
            _navigationService = navigationService;
            _firestoreDatabase = firestoreDatabase;

            // Properties
            Title = "Recommend a Business!";

            // Commands.
            AddBusiness = new DelegateCommand(async ()=> await Submit());
        }

        #endregion

        #region Methods

        public async Task ExecuteAddBusiness()
        {
            var business = new Business()
            {
                ID   = Guid.NewGuid().ToString(),
                Name = BusinessName,
            };

            await _firestoreDatabase.RecommendShop(business);
        }

        Task Submit()
        {
            return ExecuteAddBusiness();
        }

        #endregion
    }
}
