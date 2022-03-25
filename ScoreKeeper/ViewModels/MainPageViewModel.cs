using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace ScoreKeeper.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AsyncCommand NewGameCommand {get; set;}

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;

            Title = "Main Page";

            NewGameCommand = new AsyncCommand(ExecuteNewGame, allowsMultipleExecutions: false);
        }

        private async Task ExecuteNewGame()
        {
            await _navigationService.NavigateAsync("NewGamePage");
        }
    }
}
