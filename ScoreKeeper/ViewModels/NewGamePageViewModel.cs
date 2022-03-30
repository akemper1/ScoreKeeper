using Prism.Navigation;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace ScoreKeeper.ViewModels
{
    public class NewGamePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AsyncCommand BackCommand { get; set; }

        public NewGamePageViewModel(INavigationService navigationService)
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
