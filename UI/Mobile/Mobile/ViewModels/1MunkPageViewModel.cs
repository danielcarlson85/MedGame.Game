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
        
        private string tamagochiImage;
        public string TamagochiImage
        {
            get { return tamagochiImage; }
            set { SetProperty(ref tamagochiImage, value); }
        }

        private string progressMeterImage;
        public string ProgressMeterImage
        {
            get { return progressMeterImage; }
            set { SetProperty(ref progressMeterImage, value); }
        }

        private string points;
        public string Points
        {
            get { return points; }
            set { SetProperty(ref points, value); }
        }
        
        private string pointsText;
        public string PointsText
        {
            get { return pointsText; }
            set { SetProperty(ref pointsText, value); }
        }

        public MunkPageViewModel()
        {
            PointsText = "Points";
        }

        public void UpdateUI()
        {
            GamePlay.Player.Level=LevelCounter.CheckLevel(GamePlay.Player.Points);

            TamagochiImage = ImageHandler.GetTamagotchiImage(GamePlay.Player);
            HealthMeterImage = ImageHandler.GetHealthMeter(GamePlay.Player);
            ProgressMeterImage = ImageHandler.GetProgressMeter(GamePlay.Player);
            Points = GamePlay.Player.Points.ToString();
        }
    }
}