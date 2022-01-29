using MedGame.UI.Mobile.Views;
using Xamarin.Forms;

namespace MedGame.UI.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PlayPage), typeof(PlayPage));
            Routing.RegisterRoute(nameof(StepCounterPage), typeof(StepCounterPage));
        }

    }
}
