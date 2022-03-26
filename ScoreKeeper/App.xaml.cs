using Prism;
using Prism.Ioc;
using ScoreKeeper.ViewModels;
using ScoreKeeper.Views;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace ScoreKeeper
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            SetAppTheme();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NewGamePage, NewGamePageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterForNavigation<GameHistoryPage, GameHistoryPageViewModel>();
        }

        private void SetAppTheme()
        {
            var theme = Preferences.Get("theme", string.Empty);

            // If there is no preference already set, or the theme is set to light, make the app lightmode otherwise dark mode.
            Application.Current.UserAppTheme = string.IsNullOrEmpty(theme) || theme == "light" ? OSAppTheme.Light : OSAppTheme.Dark;
        }
    }
}
