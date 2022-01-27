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

                    GetCurrentLevelProcent(player, out double points10Procent, out double points20Procent, out double points30Procent, out double points40Procent, out double points50Procent, out double points60Procent, out double points70Procent, out double points80Procent, out double points90Procent, out int points100Procent, Levels.Zero);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;
                case Levels.Child:

                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.Baby);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;

                case Levels.Teenager:
                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.Child);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;

                case Levels.Pupil:
                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.Teenager);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;

                case Levels.YoungAdult:
                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.Pupil);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;

                case Levels.Adult:
                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.YoungAdult);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;

                case Levels.OldAdult:
                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.Adult);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;
                    

                case Levels.Old:
                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.OldAdult);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;
                    

                case Levels.Master:
                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.Old);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;
                    

                case Levels.Munk:
                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.Master);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;
                    

                case Levels.God:
                    GetCurrentLevelProcent(player, out points10Procent, out points20Procent, out points30Procent, out points40Procent, out points50Procent, out points60Procent, out points70Procent, out points80Procent, out points90Procent, out points100Procent, Levels.Munk);
                    progressMeterImage = GetProgressBarImageFromLevelProcent(player, points10Procent, points20Procent, points30Procent, points40Procent, points50Procent, points60Procent, points70Procent, points80Procent, points90Procent, points100Procent);
                    break;

                default:
                    break;
            }




            return progressMeterImage;
        }

        private static string GetProgressBarImageFromLevelProcent(Player player, double points10Procent, double points20Procent, double points30Procent, double points40Procent, double points50Procent, double points60Procent, double points70Procent, double points80Procent, double points90Procent, int points100Procent)
        {
            string progressMeterImage;
            var tempPoints = player.Points;
            if (tempPoints <= points10Procent) progressMeterImage = "progressMeter0.png";
            else if (tempPoints > points10Procent && tempPoints <= points20Procent) progressMeterImage = "progressmeter10.png";
            else if (tempPoints > points20Procent && tempPoints <= points30Procent) progressMeterImage = "progressMeter20.png";
            else if (tempPoints > points30Procent && tempPoints <= points40Procent) progressMeterImage = "progressMeter30.png";
            else if (tempPoints > points40Procent && tempPoints <= points50Procent) progressMeterImage = "progressMeter40.png";
            else if (tempPoints > points50Procent && tempPoints <= points60Procent) progressMeterImage = "progressMeter50.png";
            else if (tempPoints > points60Procent && tempPoints <= points70Procent) progressMeterImage = "progressMeter60.png";
            else if (tempPoints > points70Procent && tempPoints <= points80Procent) progressMeterImage = "progressMeter70.png";
            else if (tempPoints > points80Procent && tempPoints <= points90Procent) progressMeterImage = "progressMeter80.png";
            else if (tempPoints > points90Procent && tempPoints < points100Procent) progressMeterImage = "progressMeter90.png";
            else progressMeterImage = "progressMeter100.png";
            return progressMeterImage;
        }

        private static void GetCurrentLevelProcent(Player player, out double points10Procent, out double points20Procent, out double points30Procent, out double points40Procent, out double points50Procent, out double points60Procent, out double points70Procent, out double points80Procent, out double points90Procent, out int points100Procent, Levels levels)
        {
            points10Procent = ((int)player.Level * 0.1) + (int)levels;
            points20Procent = ((int)player.Level * 0.2) + (int)levels;
            points30Procent = ((int)player.Level * 0.3) + (int)levels;
            points40Procent = ((int)player.Level * 0.4) + (int)levels;
            points50Procent = ((int)player.Level * 0.5) + (int)levels;
            points60Procent = ((int)player.Level * 0.6) + (int)levels;
            points70Procent = ((int)player.Level * 0.7) + (int)levels;
            points80Procent = ((int)player.Level * 0.8) + (int)levels;
            points90Procent = ((int)player.Level * 0.9) + (int)levels;
            points100Procent = ((int)player.Level * 1) + (int)levels;
        }
    }
}
