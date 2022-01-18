//using Xamarin.Forms;

//namespace MedGame.UI.Mobile
//{
//    public partial class App : Application
//    {

//        public App()
//        {
//            InitializeComponent();

//            MainPage = new LoginPage();
//        }

//        protected override void OnStart()
//        {
//        }

//        protected override void OnSleep()
//        {
//        }

//        protected override void OnResume()
//        {
//        }
//    }
//}


using SocialMediaAuthentication.ViewModels;
using SocialMediaAuthentication.Views;
using System;
using Xamarin.Forms;

namespace MedGame.UI.Mobile
{
    public partial class App : Application
    {

        public App(IOAuth2Service oAuth2Service)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SocialLoginPage(oAuth2Service));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

}