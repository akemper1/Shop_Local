using Prism;
using Prism.Ioc;
using Shop_Local.ViewModels;
using Shop_Local.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;

namespace Shop_Local
{
    public partial class App
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU5NDg4QDMxMzgyZTMzMmUzMG5URUFXUzEwcEhkRGovWVBCZUQ5L0J6RmxCMmpBd3hYMEtxSkljWm1vTU09");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ShopsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            #region Navigation

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<RecommendationPage, RecommendationViewModel>();
            containerRegistry.RegisterForNavigation<ShopsPage, ShopsViewModel>();

            #endregion
        }
    }
}
