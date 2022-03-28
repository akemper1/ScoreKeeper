using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScoreKeeper.Views.Fragments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingView : StackLayout
    {
        public LoadingView()
        {
            InitializeComponent();
        }
    }
}