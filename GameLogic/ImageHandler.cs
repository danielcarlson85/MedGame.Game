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
            var progressMeterImage = string.Empty;

            switch (player.Level)
            {
                case Levels.Baby:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, player.LevelBabyPoints);
                    break;

                case Levels.Child:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, player.LevelChildPoints);
                    break;

                case Levels.Teenager:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, player.LevelTeenagerPoints);
                    break;
            }

            return progressMeterImage;

        }
    }
}
