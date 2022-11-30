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

            if (player.Health < 48 && player.Health >= 24)
            {
                tamagotchiImage = player.Level + "_VerySad.png";
            }

            if (player.Health < 72 && player.Health >= 48)
            {
                tamagotchiImage = player.Level + "_Crying.png";
            }

            if (player.Health < 96 && player.Health >= 72)
            {
                tamagotchiImage = player.Level + "_Sad.png";
            }

            if (player.Health < 120 && player.Health >= 96)
            {
                tamagotchiImage = player.Level + "_Annoyed.png";
            }

            if (player.Health >= 120)
            {
                tamagotchiImage = player.Level + "_Zen.png";
            }

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

        public static string GetProgressMeter(Player player)
        {
            string progressMeterImage = ProgressBarHandler.GetProgressBarImage(player);
            return progressMeterImage;
        }
    }
}
