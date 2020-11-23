using Prism;
using Prism.Ioc;
using Shop_Local.ViewModels;
using Shop_Local.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shop_Local
{
    public partial class App
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(nameof(MainPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            #region Navigation

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<RecommendationPage, RecommendationViewModel>();
            containerRegistry.RegisterForNavigation<ShopsPage, ShopsViewModel>();

            #endregion
        }
    }
}
