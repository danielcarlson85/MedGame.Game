using MedGame.Models;

namespace MedGame.GameLogic
{
    public class ImageHandler
    {
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

        public static string GetProgressMeter(Player player)
        {
            //Funkar för baby bara nu.

            var points100Procent = ((int)player.Level * 1);
            var points90Procent = ((int)player.Level * 0.9);
            var points80Procent = ((int)player.Level * 0.8);
            var points70Procent = ((int)player.Level * 0.7);
            var points60Procent = ((int)player.Level * 0.6);
            var points50Procent = ((int)player.Level * 0.5);
            var points40Procent = ((int)player.Level * 0.4);
            var points30Procent = ((int)player.Level * 0.3);
            var points20Procent = ((int)player.Level * 0.2);
            var points10Procent = ((int)player.Level * 0.1);

            var progressMeterImage = string.Empty;

            if (player.Points < points10Procent)
            {
                progressMeterImage = "progressMeter0.png";
            }

            else if (player.Points < points20Procent && player.Points >= points10Procent)
            {
                progressMeterImage = "progressMeter10.png";
            }

            else if (player.Points < points30Procent && player.Points >= points20Procent)
            {
                progressMeterImage = "progressmeter20.png";
            }

            else if (player.Points < points40Procent && player.Points >= points30Procent)
            {
                progressMeterImage = "progressMeter30.png";
            }

            else if (player.Points < points50Procent && player.Points >= points40Procent)
            {
                progressMeterImage = "progressMeter40.png";
            }

            else if (player.Points < points60Procent && player.Points >= points50Procent)
            {
                progressMeterImage = "progressMeter50.png";
            }

            else if (player.Points < points70Procent && player.Points >= points60Procent)
            {
                progressMeterImage = "progressMeter60.png";
            }

            else if (player.Points < points80Procent && player.Points >= points70Procent)
            {
                progressMeterImage = "progressMeter70.png";
            }

            else if (player.Points < points90Procent && player.Points >= points80Procent)
            {
                progressMeterImage = "progressMeter80.png";
            }

            else if (player.Points < points100Procent && player.Points >= points90Procent)
            {
                progressMeterImage = "progressMeter90.png";
            }

            else
            {
                progressMeterImage = "progressMeter100.png";
            }

            return progressMeterImage;
        }

        private void CheckBetweenNumbers(double number1, double number2)
        {
            //player.Points < points100Procent && player.Points >= points90Procent
        }
    }
}
