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



            var progressMeterImage = string.Empty;


            switch (player.Level)
            {
                case Levels.Baby:

                    var points10Procent = ((int)player.Level * 0.1);
                    var points20Procent = ((int)player.Level * 0.2);
                    var points30Procent = ((int)player.Level * 0.3);
                    var points40Procent = ((int)player.Level * 0.4);
                    var points50Procent = ((int)player.Level * 0.5);
                    var points60Procent = ((int)player.Level * 0.6);
                    var points70Procent = ((int)player.Level * 0.7);
                    var points80Procent = ((int)player.Level * 0.8);
                    var points90Procent = ((int)player.Level * 0.9);
                    var points100Procent = ((int)player.Level * 1);

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

                    break;
                case Levels.Child:

                    points10Procent = ((int)player.Level * 0.1) + (int)Levels.Baby;
                    points20Procent = ((int)player.Level * 0.2) + (int)Levels.Baby;
                    points30Procent = ((int)player.Level * 0.3) + (int)Levels.Baby;
                    points40Procent = ((int)player.Level * 0.4) + (int)Levels.Baby;
                    points50Procent = ((int)player.Level * 0.5) + (int)Levels.Baby;
                    points60Procent = ((int)player.Level * 0.6) + (int)Levels.Baby;
                    points70Procent = ((int)player.Level * 0.7) + (int)Levels.Baby;
                    points80Procent = ((int)player.Level * 0.8) + (int)Levels.Baby;
                    points90Procent = ((int)player.Level * 0.9) + (int)Levels.Baby;
                    points100Procent = ((int)player.Level * 1) + (int)Levels.Baby;

                    tempPoints = player.Points;
                    if (tempPoints < points10Procent)
                    {
                        progressMeterImage = "progressMeter0.png";
                        return progressMeterImage;
                    }

                    tempPoints = player.Points + (int)Levels.Baby;

                    if (tempPoints >= points10Procent && tempPoints < points20Procent) progressMeterImage = "progressmeter10.png";
                    else if (tempPoints >= points20Procent && tempPoints < points30Procent) progressMeterImage = "progressMeter20.png";
                    else if (tempPoints >= points30Procent && tempPoints < points40Procent) progressMeterImage = "progressMeter30.png";
                    else if (tempPoints >= points40Procent && tempPoints < points50Procent) progressMeterImage = "progressMeter40.png";
                    else if (tempPoints >= points50Procent && tempPoints < points60Procent) progressMeterImage = "progressMeter50.png";
                    else if (tempPoints >= points60Procent && tempPoints < points70Procent) progressMeterImage = "progressMeter60.png";
                    else if (tempPoints >= points70Procent && tempPoints < points80Procent) progressMeterImage = "progressMeter70.png";
                    else if (tempPoints >= points80Procent && tempPoints < points90Procent) progressMeterImage = "progressMeter80.png";
                    else if (tempPoints >= points90Procent && tempPoints < points100Procent) progressMeterImage = "progressMeter90.png";
                    else progressMeterImage = "progressMeter100.png";

                    break;

                case Levels.Teenager:

                    points10Procent = ((int)player.Level * 0.1) + (int)Levels.Child;
                    points20Procent = ((int)player.Level * 0.2) + (int)Levels.Child;
                    points30Procent = ((int)player.Level * 0.3) + (int)Levels.Child;
                    points40Procent = ((int)player.Level * 0.4) + (int)Levels.Child;
                    points50Procent = ((int)player.Level * 0.5) + (int)Levels.Child;
                    points60Procent = ((int)player.Level * 0.6) + (int)Levels.Child;
                    points70Procent = ((int)player.Level * 0.7) + (int)Levels.Child;
                    points80Procent = ((int)player.Level * 0.8) + (int)Levels.Child;
                    points90Procent = ((int)player.Level * 0.9) + (int)Levels.Child;
                    points100Procent = ((int)player.Level * 1) + (int)Levels.Child;

                    tempPoints = player.Points;
                    if (tempPoints < points10Procent)
                    {
                        progressMeterImage = "progressMeter0.png";
                        return progressMeterImage;
                    }

                    tempPoints = player.Points + (int)Levels.Child;
                    if (tempPoints >= points10Procent && tempPoints < points20Procent) progressMeterImage = "progressmeter10.png";
                    else if (tempPoints >= points20Procent && tempPoints < points30Procent) progressMeterImage = "progressMeter20.png";
                    else if (tempPoints >= points30Procent && tempPoints < points40Procent) progressMeterImage = "progressMeter30.png";
                    else if (tempPoints >= points40Procent && tempPoints < points50Procent) progressMeterImage = "progressMeter40.png";
                    else if (tempPoints >= points50Procent && tempPoints < points60Procent) progressMeterImage = "progressMeter50.png";
                    else if (tempPoints >= points60Procent && tempPoints < points70Procent) progressMeterImage = "progressMeter60.png";
                    else if (tempPoints >= points70Procent && tempPoints < points80Procent) progressMeterImage = "progressMeter70.png";
                    else if (tempPoints >= points80Procent && tempPoints < points90Procent) progressMeterImage = "progressMeter80.png";
                    else if (tempPoints >= points90Procent && tempPoints < points100Procent) progressMeterImage = "progressMeter90.png";
                    else progressMeterImage = "progressMeter100.png";

                    break;

                default:
                    break;

            }




            return progressMeterImage;
        }

        private void CheckBetweenNumbers(double number1, double number2)
        {
            //player.Points < points100Procent && player.Points >= points90Procent
        }
    }
}
