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
            var progressMeterImage = string.Empty;

            switch (player.Level)
            {
                case Levels.Baby:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.Zero);
                    break;

                case Levels.Child:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.Baby);
                    break;

                case Levels.Teenager:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player,Levels.Child);
                    break;

                case Levels.Pupil:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.Teenager);
                    break;

                case Levels.YoungAdult:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.Pupil);
                    break;

                case Levels.Adult:
                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.YoungAdult);
                    break;

                case Levels.OldAdult:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.Adult);
                    break;

                case Levels.Old:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.OldAdult);
                    break;

                case Levels.Master:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.Old);
                    break;

                case Levels.Munk:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.Master);
                    break;

                case Levels.God:

                    progressMeterImage = ProgressBarHandler.GetProgressBarImage(player, Levels.Munk);
                    break;
            }

            return progressMeterImage;

        }

    }
}
