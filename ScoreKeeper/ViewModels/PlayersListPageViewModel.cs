using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace ScoreKeeper.ViewModels
{
    public class PlayersListPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AsyncCommand BackCommand { get; set; }
        public AsyncCommand AddCommand { get; set; }

        public PlayersListPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;

            Title = "Players";

            BackCommand = new AsyncCommand(NavigateBack, allowsMultipleExecutions: false);
            AddCommand = new AsyncCommand(ExecuteAdd, allowsMultipleExecutions: false);
        }

        private Task ExecuteAdd()
        {
            throw new NotImplementedException();
        }

        public override void Initialize(INavigationParameters parameters)
        {
            MainState = LayoutState.None;
        }

        private async Task NavigateBack()
        {
            MainState = LayoutState.Loading;

            await _navigationService.GoBackAsync();
        }
    }
}
