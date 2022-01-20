using MedGame.UI.Mobile.ViewModels;
using System;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.Views
{
    public partial class SignInPage : ContentPage
    {
        private readonly SignInViewModel vm;

        public SignInPage()
        {
            InitializeComponent();

            BindingContext = vm = new SignInViewModel();
            GameLogic.GamePlay.Player = null;
        }

        private async void ButtonSignIn_Clicked(object sender, EventArgs e)
        {
            var player = await vm.SignInPlayerByEmailAsync(EntryEmail.Text);
            if (player != null)
            {
                App.Current.MainPage = new MunkPage();
            }
            else
            {
                await DisplayAlert("No player found!", "No player found with that email.", "ok");
            }
        }

        private async void ButtonSignUp_Clicked(object sender, EventArgs e)
        {
            var player = await vm.SignUpPlayerAsync(EntryEmail.Text);

            if (player != null)
            {
                await DisplayAlert("Player exist!", "The player already exists.\nPlease use another username", "ok");
            }
            else
            {
                await DisplayAlert("Player created!", "The player is created.\nPlease sign in and update your information under settings.", "ok");
            }
        }
    }
}