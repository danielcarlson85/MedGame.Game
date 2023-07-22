using MedGame.Models;

namespace MedGame.GameLogic
{
    public class ImageHandler
    {
        public static string GetTamagotchiImage(Player player)
        {
            string tamagotchiImage;
            if (player.Health < 24 && player.Health >= 0)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.Angry;
            }

            else if (player.Health < 48 && player.Health >= 24)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.VerySad;
            }

            else if (player.Health < 72 && player.Health >= 48)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.Irritated;
            }

            else if (player.Health < 96 && player.Health >= 72)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.Sad;
            }

            else if (player.Health < 120 && player.Health >= 96)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.Annoyed;
            }

            else
                tamagotchiImage = player.Level + EmotionImagesConstants.Zen;

            return tamagotchiImage;
        }

        public static string GetHealthMeter(Player player)
        {
            string healthMeterImage = string.Empty;

            if (player.Health < 24 && player.Health >= 0)
            {
                healthMeterImage = HealthMeterConstants.Dead;
            }

            if (player.Health < 48 && player.Health >= 24)
            {
                healthMeterImage = HealthMeterConstants.TerminallyIll;
            }

            if (player.Health < 72 && player.Health >= 48)
            {
                healthMeterImage = HealthMeterConstants.Sick;
            }

            if (player.Health < 96 && player.Health >= 72)
            {
                healthMeterImage = HealthMeterConstants.Angry;

            }

            if (player.Health < 120 && player.Health >= 96)
            {
                healthMeterImage = HealthMeterConstants.Irritated;

            }

            if (player.Health >= 120)
            {
                healthMeterImage = HealthMeterConstants.Zen;
            }

            return healthMeterImage;
        }

        public static string GetProgressBarImage(Player player)
        {
            string progressMeterImage = string.Empty;

            var points0Procent = (int)player.Level * 1;
            var points10Procent = (int)player.Level * 1.1;
            var points20Procent = (int)player.Level * 1.2;
            var points30Procent = (int)player.Level * 1.3;
            var points40Procent = (int)player.Level * 1.4;
            var points50Procent = (int)player.Level * 1.5;
            var points60Procent = (int)player.Level * 1.6;
            var points70Procent = (int)player.Level * 1.7;
            var points80Procent = (int)player.Level * 1.8;
            var points90Procent = (int)player.Level * 1.9;
            var points100Procent = (int)player.Level * 2;

            var pointsInkLevelPoints = player.Points + (int)player.Level;

            if (pointsInkLevelPoints > points0Procent && pointsInkLevelPoints < points10Procent) progressMeterImage = ProgressMeterConstants.Zero;
            else if (pointsInkLevelPoints >= points10Procent && pointsInkLevelPoints < points20Procent) progressMeterImage = ProgressMeterConstants.Ten;
            else if (pointsInkLevelPoints >= points20Procent && pointsInkLevelPoints < points30Procent) progressMeterImage = ProgressMeterConstants.Twenty;
            else if (pointsInkLevelPoints >= points30Procent && pointsInkLevelPoints < points40Procent) progressMeterImage = ProgressMeterConstants.Thirty;
            else if (pointsInkLevelPoints >= points40Procent && pointsInkLevelPoints < points50Procent) progressMeterImage = ProgressMeterConstants.Forty;
            else if (pointsInkLevelPoints >= points50Procent && pointsInkLevelPoints < points60Procent) progressMeterImage = ProgressMeterConstants.Fifty;
            else if (pointsInkLevelPoints >= points60Procent && pointsInkLevelPoints < points70Procent) progressMeterImage = ProgressMeterConstants.Sixty;
            else if (pointsInkLevelPoints >= points70Procent && pointsInkLevelPoints < points80Procent) progressMeterImage = ProgressMeterConstants.Seventy;
            else if (pointsInkLevelPoints >= points80Procent && pointsInkLevelPoints < points90Procent) progressMeterImage = ProgressMeterConstants.Eighty;
            else if (pointsInkLevelPoints >= points90Procent && pointsInkLevelPoints < points100Procent) progressMeterImage = ProgressMeterConstants.Nighty;
            else if (pointsInkLevelPoints >= points100Procent) progressMeterImage = ProgressMeterConstants.OneHundred;

            if (pointsInkLevelPoints == (int)player.Level)
            {
                progressMeterImage = ProgressMeterConstants.Zero;
            }

            return progressMeterImage;
        }
    }
}
