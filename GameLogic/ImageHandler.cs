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

            var points10Procent = (int)player.Level * 0.1;
            var points20Procent = (int)player.Level * 0.2;
            var points30Procent = (int)player.Level * 0.3;
            var points40Procent = (int)player.Level * 0.4;
            var points50Procent = (int)player.Level * 0.5;
            var points60Procent = (int)player.Level * 0.6;
            var points70Procent = (int)player.Level * 0.7;
            var points80Procent = (int)player.Level * 0.8;
            var points90Procent = (int)player.Level * 0.9;
            var points100Procent = (int)player.Level * 1;

            var progressMeterImage = string.Empty;

            if (CheckBetweenNumbers(player, 0, points10Procent)) progressMeterImage = "progressMeter0.png";
            if (CheckBetweenNumbers(player, points10Procent, points20Procent)) progressMeterImage = "progressMeter10.png";
            if (CheckBetweenNumbers(player, points20Procent, points30Procent)) progressMeterImage = "progressMeter20.png";
            if (CheckBetweenNumbers(player, points30Procent, points40Procent)) progressMeterImage = "progressMeter30.png";
            if (CheckBetweenNumbers(player, points40Procent, points50Procent)) progressMeterImage = "progressMeter40.png";
            if (CheckBetweenNumbers(player, points50Procent, points60Procent)) progressMeterImage = "progressMeter50.png";
            if (CheckBetweenNumbers(player, points60Procent, points70Procent)) progressMeterImage = "progressMeter60.png";
            if (CheckBetweenNumbers(player, points70Procent, points80Procent)) progressMeterImage = "progressMeter70.png";
            if (CheckBetweenNumbers(player, points80Procent, points90Procent)) progressMeterImage = "progressMeter80.png";
            if (CheckBetweenNumbers(player, points90Procent, points100Procent)) progressMeterImage = "progressMeter90.png";
            return progressMeterImage;
        }

        private static bool CheckBetweenNumbers(Player player, double number1, double number2)
        {
            switch (player.Level)
            {
                case Levels.Baby:
                    if ((player.Points) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.Child:
                    if ((player.Points + (int)Levels.Baby) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.Teenager:
                    if ((player.Points + (int)Levels.Child) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.Pupil:
                    if ((player.Points + (int)Levels.Teenager) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.YoungAdult:
                    if ((player.Points + (int)Levels.Pupil) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.Adult:
                    if ((player.Points + (int)Levels.YoungAdult) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.OldAdult:
                    if ((player.Points + (int)Levels.Adult) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.Old:
                    if ((player.Points + (int)Levels.OldAdult) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.Master:
                    if ((player.Points + (int)Levels.Old) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.Munk:
                    if ((player.Points + (int)Levels.Master) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                case Levels.God:
                    if ((player.Points + (int)Levels.Munk) >= number1 && player.Points < number2)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }



            return false;
        }
    }
}
