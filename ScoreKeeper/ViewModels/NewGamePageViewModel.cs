using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

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
