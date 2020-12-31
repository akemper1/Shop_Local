using Prism;
using Prism.Ioc;
using Shop_Local.ViewModels;
using Shop_Local.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Shop_Local.Services.Interfaces;
using Shop_Local.Services;

namespace Shop_Local
{
    public partial class App
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzc1NjA0QDMxMzgyZTM0MmUzMEQwVTFBL0xEQTVpNTlsLzBhcHRkS3lENm1BNXJUcGNMb2E1SXhRRTBUVHM9");

            InitializeComponent();

            var authenticationService = Current.Container.Resolve<IAuthenticationService>();

            if (authenticationService.IsSignedIn)
            {
                // User is logged in, navigate to Shops Page.
                await NavigationService.NavigateAsync("NavigationPage/ShopsPage");
            }
            else
            {
                // User it not logged in, navigate to Login Page.
                await NavigationService.NavigateAsync(nameof(LoginPage));
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            #region Services

            containerRegistry.RegisterSingleton<IFirestoreDatabase, FirestoreDatabase>();

            #endregion

            #region Navigation

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<RecommendationPage, RecommendationViewModel>();
            containerRegistry.RegisterForNavigation<ShopsPage, ShopsViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();

            #endregion
        }
    }
}
