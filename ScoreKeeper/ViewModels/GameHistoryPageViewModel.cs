using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreKeeper.ViewModels
{
    public class GameHistoryPageViewModel : ViewModelBase
    {
        public GameHistoryPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
    }
}
