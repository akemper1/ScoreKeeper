using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using ScoreKeeper.ViewModels;
using ScoreKeeper.Views;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

[assembly: ExportFont("FontAwesome-Regular.ttf", Alias = "FontAwesome_Regular")]
[assembly: ExportFont("FontAwesome-Solid.ttf", Alias = "FontAwesome_Solid")]

[assembly: ExportFont("Mulish-Black.ttf", Alias = "Mulish_Black")]
[assembly: ExportFont("Mulish-Bold.ttf", Alias = "Mulish_Bold")]
[assembly: ExportFont("Mulish-ExtraBold.ttf", Alias = "Mulish_ExtraBold")]
[assembly: ExportFont("Mulish-ExtraLight.ttf", Alias = "Mulish_ExtraLight")]
[assembly: ExportFont("Mulish-Light.ttf", Alias = "Mulish_Light")]
[assembly: ExportFont("Mulish-Medium.ttf", Alias = "Mulish_Medium")]
[assembly: ExportFont("Mulish-Regular.ttf", Alias = "Mulish_Regular")]
[assembly: ExportFont("Mulish-SemiBold.ttf", Alias = "Mulish_SemiBold")]

namespace ScoreKeeper
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            SetAppTheme();

            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NewGamePage, NewGamePageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterForNavigation<GameHistoryPage, GameHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<PlayersListPage, PlayersListPageViewModel>();
        }

        private void SetAppTheme()
        {
            var theme = Preferences.Get("theme", string.Empty);

            // If there is no preference already set, or the theme is set to light, make the app lightmode otherwise dark mode.
            Application.Current.UserAppTheme = string.IsNullOrEmpty(theme) || theme == "light" ? OSAppTheme.Light : OSAppTheme.Dark;
        }
    }
}
