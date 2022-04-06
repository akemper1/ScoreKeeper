using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScoreKeeper.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AsyncCommand BackCommand { get; set; }

        public ICommand DarkModeToggleCommand { get; set; }

        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get { return _isDarkMode; }
            set { SetProperty(ref _isDarkMode, value); }
        }

        public SettingsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;

            Title = "Settings";

            BackCommand = new AsyncCommand(NavigateBack, allowsMultipleExecutions: false);
            DarkModeToggleCommand = new Command(OnIsDarkModeChanged);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            IsDarkMode = Application.Current.UserAppTheme.Equals(OSAppTheme.Dark);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            MainState = LayoutState.None;
        }

        private async Task NavigateBack()
        {
            MainState = LayoutState.Loading;

            await _navigationService.GoBackAsync();
        }

        private void OnIsDarkModeChanged()
        {
            if (IsDarkMode)
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
                Preferences.Set("theme", "dark");
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
                Preferences.Set("theme", "light");
            }
        }
    }
}
