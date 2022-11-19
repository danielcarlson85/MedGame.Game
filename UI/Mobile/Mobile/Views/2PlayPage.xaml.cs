﻿using MedGame.UI.Mobile.ViewModels;
using System;
using System.Threading.Tasks;
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
            vm.StartOrStopMeditationAsync();
        }

        private async void NavButtonMunkPage_ClickedAsync(object sender, EventArgs e)
        {
            await CheckIfAudioIsPlaying(new MunkPage());
        }

        private async void NavButtonPlayPage_ClickedAsync(object sender, EventArgs e)
        {
            await CheckIfAudioIsPlaying(new PlayPage());

        }

        private async void NavButtonStatisticPage_ClickedAsync(object sender, EventArgs e)
        {
            await CheckIfAudioIsPlaying(new StatisticPage());

        }

        private async void NavButtonSharePage_ClickedAsync(object sender, EventArgs e)
        {
            await CheckIfAudioIsPlaying(new SharePage());

        }

        private async void NavButtonSettingsPage_ClickedAsync(object sender, EventArgs e)
        {
            await CheckIfAudioIsPlaying(new SettingsPage());

        }

        private async Task CheckIfAudioIsPlaying(Page page)
        {
            if (vm.IsPlaying)
            {
                bool result = await ShowDisplayAlert();
                if (result)
                {
                    await vm.StopMeditation(false);
                    App.Current.MainPage = page;
                }
            }
            else
            {
                App.Current.MainPage = page;
            }
        }

        private async Task<bool> ShowDisplayAlert()
        {
            return await Application.Current.MainPage.DisplayAlert("Do you want to stop?", "Do you really want to stop the meditation?", "Yes", "No");
        }
    }
}