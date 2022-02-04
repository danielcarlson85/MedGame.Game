using MedGame.UI.Mobile.ViewModels;
using System;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.Views
{
    public partial class SharePage : ContentPage
    {
        public SharePage()
        {
            InitializeComponent();

            BindingContext = new SharePageViewModel();
        }

        private void NavButtonMunkPage_ClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new MunkPage();
        }

        private void NavButtonPlayPage_ClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new PlayPage();
        }

        private void NavButtonStatisticPage_ClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new StatisticPage();
        }

        private void NavButtonSharePage_ClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new SharePage();
        }

        private void NavButtonSettingsPage_ClickedAsync(object sender, EventArgs e)
        {
            App.Current.MainPage = new SettingsPage();
        }
    }
}