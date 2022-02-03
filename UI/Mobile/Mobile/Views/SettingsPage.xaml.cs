using MedGame.UI.Mobile.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedGame.UI.Mobile.Views
{
    public partial class SettingsPage : ContentPage
    {
        private readonly SettingsPageViewModel vm;

        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = vm = new SettingsPageViewModel();
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
            App.Current.MainPage = new SignInPage();
        }

        private void ButtonSignUp_Clicked(object sender, EventArgs e)
        {

        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            await vm.UpdatePlayer();
            await DisplayAlert("Player updated", "The player is now updated.", "ok");
        }

        private async void ButtonDeleteAllPlayers_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Warning!", "Do you really want to delete the whole database of questions? \n\nThe database can not be restored.", "Yes", "No");
            if (result)
            {
                await vm.DeleteAllPlayers();
                await DisplayAlert("All players deleted!", "All players is now deleted.", "ok");
                Application.Current.MainPage = new SignInPage();
            }
        }

        private async void ButtonShowAllPlayers_Clicked(object sender, EventArgs e)
        {
            var players = await vm.GetAllPlayersNameAndId();
            await DisplayAlert("All players!", players, "ok");
        }
    }
}