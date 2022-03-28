using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace ScoreKeeper.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public LayoutState State { get; set; }

        public AsyncCommand NewGameCommand {get; set;}
        public AsyncCommand GamesListCommand { get; set; }
        public AsyncCommand PlayersListCommand { get; set; }
        public AsyncCommand SettingsCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;

            Title = "Main Page";

            NewGameCommand = new AsyncCommand(ExecuteNewGame, allowsMultipleExecutions: false);
            GamesListCommand = new AsyncCommand(ExecuteGamesList, allowsMultipleExecutions: false);
            PlayersListCommand = new AsyncCommand(ExecutePlayersList, allowsMultipleExecutions: false);
            SettingsCommand = new AsyncCommand(ExecuteSettings, allowsMultipleExecutions: false);
        }

        private async Task ExecuteSettings()
        {
            await _navigationService.NavigateAsync("SettingsPage");
        }

        private async Task ExecutePlayersList()
        {
            await _navigationService.NavigateAsync("PlayersListPage");
        }

        private async Task ExecuteGamesList()
        {
            await _navigationService.NavigateAsync("GameHistoryPage");
        }

        private async Task ExecuteNewGame()
        {
            await _navigationService.NavigateAsync("NewGamePage");
        }
    }
}
