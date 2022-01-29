using MedGame.UI.Interfaces;
using MedGame.UI.Mobile.ViewModels;
using System;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.Views
{
    public partial class MunkPage : ContentPage
    {
        private readonly MunkPageViewModel vm;

        public MunkPage()
        {
            InitializeComponent();

            BindingContext = vm = new MunkPageViewModel();
            vm.UpdateUI();
        }

        private void ImageButtonPlay_ClickedAsync(object sender, EventArgs e)
        {
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

        private void ImgProgressBar_Clicked(object sender, EventArgs e)
        {

        }

        private void ImgTamagochi_Clicked(object sender, EventArgs e)
        {

        }

        private void ImgDailyEnergy_Clicked(object sender, EventArgs e)
        {

        }
    }
}