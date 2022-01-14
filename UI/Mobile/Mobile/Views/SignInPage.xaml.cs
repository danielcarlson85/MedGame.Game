using MedGame.UI.Mobile.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        }

        private void ButtonSignUp_Clicked(object sender, EventArgs e)
        {

        }
    }
}