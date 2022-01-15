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
        }

        private void ButtonSignIn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MunkPage();
        }

        private void ButtonSignUp_Clicked(object sender, EventArgs e)
        {

        }

        private void ButtonSignIn_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}