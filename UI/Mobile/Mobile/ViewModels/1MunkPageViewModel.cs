using MedGame.GameLogic;
using MedGame.GameLogic.Handlers;
using MedGame.Models;
using MedGame.UI.Interfaces;
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
            GameModels.Player.Level = LevelCounter.CheckLevel(GameModels.Player);

            TamagochiImage = ImageHandler.GetTamagotchiImage(GameModels.Player);
            HealthMeterImage = ImageHandler.GetHealthMeter(GameModels.Player);
            ProgressMeterImage = ImageHandler.GetProgressBarImage(GameModels.Player);

            Points = GameModels.Player.Points.ToString();
            SendNotificationDependingOnHealth(GameModels.Player);
        }

        public static void SendNotificationDependingOnHealth(Player player)
        {
            var notificationTexts = NotificationHandler.GetHealthNotification(player);

            DependencyService.Get<INotification>().Send($"{notificationTexts.title}", $"{notificationTexts.text}");
        }
    }
}