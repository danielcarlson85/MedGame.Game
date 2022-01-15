﻿using MedGame.UI.Mobile.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedGame.UI.Mobile.Views
{
    public partial class MunkPage : ContentPage
    {
        private readonly MunkPageViewModel vm;

        public MunkPage()
        {
            InitializeComponent();

            BindingContext = vm = new MunkPageViewModel();
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
    }
}