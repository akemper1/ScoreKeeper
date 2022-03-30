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
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AsyncCommand BackCommand { get; set; }

        public SettingsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;

            BackCommand = new AsyncCommand(NavigateBack, allowsMultipleExecutions: false);
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
