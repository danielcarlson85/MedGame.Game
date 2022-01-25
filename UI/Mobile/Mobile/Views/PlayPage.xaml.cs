﻿using MedGame.UI.Mobile.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private async void ImageButtonPlay_ClickedAsync(object sender, EventArgs e)
        {

            if (vm.IsPlaying)
            {
                ImageButtonPlay.Source = "PlayButtonNew.png";
            }
            else
            {
                ImageButtonPlay.Source = "pausebutton.png";
            }

            await vm.StartOrStopMeditationAsync();
        }
        private void NavButtonMunkPage_ClickedAsync(object sender, EventArgs e)
        {
            vm.StopMeditation();
            App.Current.MainPage = new MunkPage();
        }

        private void NavButtonPlayPage_ClickedAsync(object sender, EventArgs e)
        {
            vm.StopMeditation();
            App.Current.MainPage = new PlayPage();
        }

        private void NavButtonStatisticPage_ClickedAsync(object sender, EventArgs e)
        {
            //vm.StopMeditation();
            App.Current.MainPage = new StatisticPage();
        }

        private void NavButtonSharePage_ClickedAsync(object sender, EventArgs e)
        {
            vm.StopMeditation();
            App.Current.MainPage = new SharePage();
        }

        private void NavButtonSettingsPage_ClickedAsync(object sender, EventArgs e)
        {
            vm.StopMeditation();
            App.Current.MainPage = new SettingsPage();
        }
    }
}