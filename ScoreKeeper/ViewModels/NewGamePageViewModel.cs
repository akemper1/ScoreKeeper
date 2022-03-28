using Prism.Navigation;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;

namespace ScoreKeeper.ViewModels
{
    public class NewGamePageViewModel : ViewModelBase
    {
        public NewGamePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
    }
}
