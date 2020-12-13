using Prism.Commands;
using Prism.Navigation;
using Shop_Local.Enums;
using Shop_Local.Models;
using Shop_Local.Services.Interfaces;
using Shop_Local.Validation;
using Shop_Local.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

                // Sets the proper error message based off user input or lack there of.
                if (string.IsNullOrWhiteSpace(_businessName))
                {
                    BusinessNameErrorText = "Required *";
                }
                else
                {
                    BusinessNameErrorText = "Business name can not contain special characters.";
                }

                // Do this so we can turn on and off the submit button.
                RaisePropertyChanged(nameof(CanSubmit));
            }
        }
        private string _businessName = string.Empty;

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

                // Sets the proper error message based off user input or lack there of.
                if (string.IsNullOrWhiteSpace(_phoneNumber))
                {
                    PhoneNumberErrorText = "Required *";
                }
                else
                {
                    PhoneNumberErrorText = "Not a valid phone number.";
                }

                // Do this so we can turn on and off the submit button.
                RaisePropertyChanged(nameof(CanSubmit));
            }
        }
        private string _phoneNumber = string.Empty;

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

                // Sets the proper error message based off user input or lack there of.
                if (string.IsNullOrWhiteSpace(_email))
                {
                    EmailErrorText = "Required *";
                }
                else
                {
                    EmailErrorText = "Not a valid email address.";
                }

                // Do this so we can turn on and off the submit button.
                RaisePropertyChanged(nameof(CanSubmit));
            }
        }
        private string _email = string.Empty;

        public bool IsEmailNotValid { get => _isEmailNotValid; set => SetProperty(ref _isEmailNotValid, value); }
        private bool _isEmailNotValid;

        public string EmailErrorText { get => _emailErrorText; set => SetProperty(ref _emailErrorText, value); }
        private string _emailErrorText;

        #endregion

        #region Submission Validation

        // Boolean to turn on and off submit button based of user input.
        public bool CanSubmit => !IsBusinessNameNotValid && !IsEmailNotValid && !IsPhoneNumberNotValid;

        #endregion

        #region Address Information

        public string StreetNumberAndName 
        {
            get { return _streetNumberAndName; }
            set
            {
                SetProperty(ref _streetNumberAndName, value);
                IsStreetNumberAndNameNotValid = InvalidateText(value, new Regex(RegularExpressions.StreetNameNumber));
            }
        }
        private string _streetNumberAndName;

        public bool IsStreetNumberAndNameNotValid { get => _isStreetNumberAndNameNotValid; set => SetProperty(ref _isStreetNumberAndNameNotValid, value); }
        private bool _isStreetNumberAndNameNotValid;

        public string City
        {
            get { return _city; }
            set
            {
                SetProperty(ref _city, value);
                IsCityNotValid = InvalidateText(value, new Regex(RegularExpressions.City));
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
                IsZipCodeNotValid = InvalidateText(value, new Regex(RegularExpressions.ZipCode));
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
                IsSuiteNotValid = InvalidateText(value, new Regex(RegularExpressions.Suite));
            }
        }
        private string _suite;

        public bool IsSuiteNotValid { get => _isSuiteNotValid; set => SetProperty(ref _isSuiteNotValid, value); }
        private bool _isSuiteNotValid;

        #endregion

        #region Category Information

        public string PrimaryCategory { get => _primaryCategory; set => SetProperty(ref _primaryCategory, value); }
        private string _primaryCategory;

        public IList<BusinessCategory> SecondaryCategories { get => _secondaryCategories; set => SetProperty(ref _secondaryCategories, value); }
        private IList<BusinessCategory> _secondaryCategories;

        public ObservableCollection<string> PrimaryCategories { get => _primaryCategories; set => SetProperty(ref _primaryCategories, value); }
        private ObservableCollection<string> _primaryCategories;

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
            // Async way of delegate command, that observes a property.
            AddBusiness = new DelegateCommand(async ()=> await Submit()).ObservesCanExecute(() => CanSubmit);
        }

        #endregion

        #region INavigation

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            // Add categories to list so they can be displayed.
            PrimaryCategories = new ObservableCollection<string>(Enum.GetNames(typeof(BusinessCategory)).ToList());
        }

        #endregion

        #region Methods

        public async Task ExecuteAddBusiness()
        {
            // Turn on wait indicator.
            IsBusy = true;

            // Creating new business object.
            var business = new Business()
            {
                ID                  = Guid.NewGuid().ToString(),
                Name                = BusinessName,
                PhoneNumber         = PhoneNumber,
                Email               = Email,
                StreetNumberAndName = StreetNumberAndName,
                Suite               = Suite,
                City                = City,
                ZipCode             = ZipCode,
                Category            = PrimaryCategory,
            };

            // Saving new business to the DB.
            await _firestoreDatabase.RecommendShop(business);

            // Turn off wait indicator.
            IsBusy = false;

            // Navigate back to Shops Page.
            await _navigationService.GoBackToRootAsync();
        }

        // Method so we can ensure that command is async.
        Task Submit()
        {
            return ExecuteAddBusiness();
        }

        #endregion
    }
}
