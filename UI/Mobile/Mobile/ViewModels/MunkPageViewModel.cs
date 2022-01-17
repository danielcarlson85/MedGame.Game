using MedGame.GameLogic;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.ViewModels
{
    public class MunkPageViewModel : BaseViewModel
    {
        private string healthMeterImage;
        public string HealthMeterImage
        {
            get { return healthMeterImage; }
            set { SetProperty(ref healthMeterImage, value); }
        }

        public MunkPageViewModel()
        {
            Title = "test";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            UpdateUI();
        }

        public void UpdateUI()
        {
            HealthMeterImage = GameImageHandler.GetHealthMeter(GamePlay.Player);
        }

        //public ICommand OpenWebCommand { get; }



    }
}