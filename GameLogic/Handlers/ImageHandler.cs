using MedGame.Models;

namespace MedGame.GameLogic
{
    public class ImageHandler
    {
        public static string GetTamagotchiImage(Player player)
        {
            string tamagotchiImage = string.Empty;

            if (player.Health < 24 && player.Health >= 0)
            {
                tamagotchiImage = player.Level + "_Sick.png";
            }

            else if (player.Health < 48 && player.Health >= 24)
            {
                tamagotchiImage = player.Level + "_VerySad.png";
            }

            else if (player.Health < 72 && player.Health >= 48)
            {
                tamagotchiImage = player.Level + "_Crying.png";
            }

            else if (player.Health < 96 && player.Health >= 72)
            {
                tamagotchiImage = player.Level + "_Sad.png";
            }

            else if (player.Health < 120 && player.Health >= 96)
            {
                tamagotchiImage = player.Level + "_Annoyed.png";
            }

            else
                tamagotchiImage = player.Level + "_Zen.png";

            return tamagotchiImage;
        }

        public static string GetHealthMeter(Player player)
        {
            string healthMeterImage = string.Empty;

            if (player.Health < 24 && player.Health >= 0)
            {
                healthMeterImage = "healthmeterdead.png";
            }

            if (player.Health < 48 && player.Health >= 24)
            {
                healthMeterImage = "healthmeterterminallyill.png";
            }

            if (player.Health < 72 && player.Health >= 48)
            {
                healthMeterImage = "healthmetersick.png";
            }

            if (player.Health < 96 && player.Health >= 72)
            {
                healthMeterImage = "healthmeterangry.png";

            }

            if (player.Health < 120 && player.Health >= 96)
            {
                healthMeterImage = "healthmeterirritated.png";

            }

            if (player.Health >= 120)
            {
                healthMeterImage = "healthmeterzen.png";
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

            if (pointsInkLevelPoints > points0Procent && pointsInkLevelPoints < points10Procent) progressMeterImage = "progressMeter0.png";
            else if (pointsInkLevelPoints >= points10Procent && pointsInkLevelPoints < points20Procent) progressMeterImage = "progressMeter10.png";
            else if (pointsInkLevelPoints >= points20Procent && pointsInkLevelPoints < points30Procent) progressMeterImage = "progressMeter20.png";
            else if (pointsInkLevelPoints >= points30Procent && pointsInkLevelPoints < points40Procent) progressMeterImage = "progressMeter30.png";
            else if (pointsInkLevelPoints >= points40Procent && pointsInkLevelPoints < points50Procent) progressMeterImage = "progressMeter40.png";
            else if (pointsInkLevelPoints >= points50Procent && pointsInkLevelPoints < points60Procent) progressMeterImage = "progressMeter50.png";
            else if (pointsInkLevelPoints >= points60Procent && pointsInkLevelPoints < points70Procent) progressMeterImage = "progressMeter60.png";
            else if (pointsInkLevelPoints >= points70Procent && pointsInkLevelPoints < points80Procent) progressMeterImage = "progressMeter70.png";
            else if (pointsInkLevelPoints >= points80Procent && pointsInkLevelPoints < points90Procent) progressMeterImage = "progressMeter80.png";
            else if (pointsInkLevelPoints >= points90Procent && pointsInkLevelPoints < points100Procent) progressMeterImage = "progressMeter90.png";
            else if (pointsInkLevelPoints >= points10Procent) progressMeterImage = "progressMeter100.png";

            return progressMeterImage;
        }
    }
}
