using MedGame.UI.Mobile.ViewModels;
using System;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.Views
{
    public partial class PlayPage : ContentPage
    {
        private readonly PlayPageViewModel vm;

        public PlayPage()
        {
            InitializeComponent();

            BindingContext = vm = new PlayPageViewModel();
        }

        private void ImageButtonPlay_Clicked(object sender, EventArgs e)
        {
            vm.StartOrStopMeditationAsync(ImageButtonPlay);
        }

        private async void NavButtonMunkPage_ClickedAsync(object sender, EventArgs e)
        {
            await vm.StopMeditation();
            App.Current.MainPage = new MunkPage();
        }

        private async void NavButtonPlayPage_ClickedAsync(object sender, EventArgs e)
        {
            await vm.StopMeditation();
            App.Current.MainPage = new PlayPage();
        }

        private async void NavButtonStatisticPage_ClickedAsync(object sender, EventArgs e)
        {
            await vm.StopMeditation();
            App.Current.MainPage = new StatisticPage();
        }

        private async void NavButtonSharePage_ClickedAsync(object sender, EventArgs e)
        {
            await vm.StopMeditation();
            App.Current.MainPage = new SharePage();
        }

        private async void NavButtonSettingsPage_ClickedAsync(object sender, EventArgs e)
        {
            await vm.StopMeditation();
            App.Current.MainPage = new SettingsPage();
        }
    }
}