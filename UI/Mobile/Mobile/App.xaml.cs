using MedGame.UI.Interfaces;
using MonkeyCache.FileStore;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedGame.UI.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = AppInfo.PackageName;
            //DependencyService.Get<INotification>().Send("App.xaml.cs", "Welcome to MediGotchi :-D");

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
