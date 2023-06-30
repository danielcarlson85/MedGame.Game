using MedGame.Services;
using MedGame.UI.Interfaces;
using MedGame.UI.Mobile.Views;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedGame.UI.Mobile
{
    public partial class App : Application
    {
        public static OnlineDateTime OnlineDateTime = new OnlineDateTime();


        public App()
        {
            InitializeComponent();
            Barrel.ApplicationId = AppInfo.PackageName;
            //DependencyService.Get<INotification>().Send("App.xaml.cs", "Welcome to MediGotchi :-D");

            //OnlineDateTime = OnlineDateTime.GetCurrentDateAsync().GetAwaiter().GetResult();

            MainPage = new SignInPage();
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

