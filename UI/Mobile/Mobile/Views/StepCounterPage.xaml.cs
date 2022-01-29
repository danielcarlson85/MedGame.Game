using MedGame.UI.Mobile.ViewModels;
using System;
using System.ComponentModel;
using System.Timers;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.Views
{
    public interface IStepCounter
    {
        int Steps { get; set; }

        void InitSensorService();

        void StopSensorService();
    }



    public partial class StepCounterPage : ContentPage
    {
        private readonly StepCounterViewModel vm;

        public StepCounterPage()
        {
            InitializeComponent();

            BindingContext = vm = new StepCounterViewModel();


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