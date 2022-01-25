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
            
            if (player.Health < 72 && player.Health >=48)
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
            var progressMeterImage = string.Empty;

            if (player.Points < 10)
            {
                progressMeterImage = "progressMeter0.png";
            }

            if (player.Points < 20 && player.Points >= 10)
            {
                progressMeterImage = "progressMeter10.png";
            }

            if (player.Points < 30 && player.Points >= 20)
            {
                progressMeterImage = "progressmeter20.png";
            }

            if (player.Points < 40 && player.Points >= 30)
            {
                progressMeterImage = "progressMeter30.png";
            }

            if (player.Points < 50 && player.Points >= 40)
            {
                progressMeterImage = "progressMeter40.png";
            }

            if (player.Points < 60 && player.Points >= 50)
            {
                progressMeterImage = "progressMeter50.png";
            }

            if (player.Points < 70 && player.Points >= 60)
            {
                progressMeterImage = "progressMeter60.png";
            }

            if (player.Points < 80 && player.Points >= 70)
            {
                progressMeterImage = "progressMeter70.png";
            }

            if (player.Points < 90 && player.Points >= 80)
            {
                progressMeterImage = "progressMeter80.png";
            }

            if (player.Points >= 90)
            {
                progressMeterImage = "progressMeter90.png";
            }

            return progressMeterImage;
        }
    }
}
