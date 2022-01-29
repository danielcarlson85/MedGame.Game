using MedGame.Models;

namespace MedGame.GameLogic
{
    public class ProgressBarHandler
    {

        public static string GetProgressBarImage(Player player, double levelPointsType)
        {
            string progressMeterImage;

            var points10Procent = (int)player.Level * 0.1;
            var points20Procent = (int)player.Level* 0.2;
            var points30Procent = (int)player.Level* 0.3;
            var points40Procent = (int)player.Level* 0.4;
            var points50Procent = (int)player.Level* 0.5;
            var points60Procent = (int)player.Level* 0.6;
            var points70Procent = (int)player.Level* 0.7;
            var points80Procent = (int)player.Level* 0.8;
            var points90Procent = (int)player.Level* 0.9;
            var points100Procent = (int)player.Level * 1;

            if (levelPointsType <= points10Procent) progressMeterImage = "progressMeter0.png";
            else if (levelPointsType  > points10Procent && levelPointsType <= points20Procent) progressMeterImage = "progressMeter10.png";
            else if (levelPointsType  > points20Procent && levelPointsType <= points30Procent) progressMeterImage = "progressMeter20.png";
            else if (levelPointsType  > points30Procent && levelPointsType <= points40Procent) progressMeterImage = "progressMeter30.png";
            else if (levelPointsType  > points40Procent && levelPointsType <= points50Procent) progressMeterImage = "progressMeter40.png";
            else if (levelPointsType  > points50Procent && levelPointsType <= points60Procent) progressMeterImage = "progressMeter50.png";
            else if (levelPointsType  > points60Procent && levelPointsType <= points70Procent) progressMeterImage = "progressMeter60.png";
            else if (levelPointsType  > points70Procent && levelPointsType <= points80Procent) progressMeterImage = "progressMeter70.png";
            else if (levelPointsType  > points80Procent && levelPointsType <= points90Procent) progressMeterImage = "progressMeter80.png";
            else if (levelPointsType  > points90Procent && levelPointsType <= points100Procent) progressMeterImage = "progressMeter90.png";
            else progressMeterImage = "progressMeter100.png";

            return progressMeterImage;
        }



        public static string GetProgressImageForBaby(Player player)
        {
            string progressMeterImage;

            var points10Procent = (int)Levels.Baby * 0.1;
            var points20Procent = (int)Levels.Baby * 0.2;
            var points30Procent = (int)Levels.Baby * 0.3;
            var points40Procent = (int)Levels.Baby * 0.4;
            var points50Procent = (int)Levels.Baby * 0.5;
            var points60Procent = (int)Levels.Baby * 0.6;
            var points70Procent = (int)Levels.Baby * 0.7;
            var points80Procent = (int)Levels.Baby * 0.8;
            var points90Procent = (int)Levels.Baby * 0.9;
            var points100Procent = (int)Levels.Baby * 1;

            if (player.LevelBabyPoints <= points10Procent) progressMeterImage = "progressMeter0.png";
            else if (player.LevelBabyPoints > points10Procent && player.LevelBabyPoints <= points20Procent) progressMeterImage = "progressMeter10.png";
            else if (player.LevelBabyPoints > points20Procent && player.LevelBabyPoints <= points30Procent) progressMeterImage = "progressMeter20.png";
            else if (player.LevelBabyPoints > points30Procent && player.LevelBabyPoints <= points40Procent) progressMeterImage = "progressMeter30.png";
            else if (player.LevelBabyPoints > points40Procent && player.LevelBabyPoints <= points50Procent) progressMeterImage = "progressMeter40.png";
            else if (player.LevelBabyPoints > points50Procent && player.LevelBabyPoints <= points60Procent) progressMeterImage = "progressMeter50.png";
            else if (player.LevelBabyPoints > points60Procent && player.LevelBabyPoints <= points70Procent) progressMeterImage = "progressMeter60.png";
            else if (player.LevelBabyPoints > points70Procent && player.LevelBabyPoints <= points80Procent) progressMeterImage = "progressMeter70.png";
            else if (player.LevelBabyPoints > points80Procent && player.LevelBabyPoints <= points90Procent) progressMeterImage = "progressMeter80.png";
            else if (player.LevelBabyPoints > points90Procent && player.LevelBabyPoints <= points100Procent) progressMeterImage = "progressMeter90.png";
            else progressMeterImage = "progressMeter100.png";

            return progressMeterImage;
        }

        public static string GetProgressImageForChild(Player player)
        {
            string progressMeterImage;

            var points10Procent = (int)Levels.Child * 0.1;
            var points20Procent = (int)Levels.Child * 0.2;
            var points30Procent = (int)Levels.Child * 0.3;
            var points40Procent = (int)Levels.Child * 0.4;
            var points50Procent = (int)Levels.Child * 0.5;
            var points60Procent = (int)Levels.Child * 0.6;
            var points70Procent = (int)Levels.Child * 0.7;
            var points80Procent = (int)Levels.Child * 0.8;
            var points90Procent = (int)Levels.Child * 0.9;
            var points100Procent = (int)Levels.Child * 1;

            if (player.LevelChildPoints <= points10Procent) progressMeterImage = "progressMeter0.png";
            else if (player.LevelChildPoints > points10Procent && player.LevelChildPoints <= points20Procent) progressMeterImage = "progressMeter10.png";
            else if (player.LevelChildPoints > points20Procent && player.LevelChildPoints <= points30Procent) progressMeterImage = "progressMeter20.png";
            else if (player.LevelChildPoints > points30Procent && player.LevelChildPoints <= points40Procent) progressMeterImage = "progressMeter30.png";
            else if (player.LevelChildPoints > points40Procent && player.LevelChildPoints <= points50Procent) progressMeterImage = "progressMeter40.png";
            else if (player.LevelChildPoints > points50Procent && player.LevelChildPoints <= points60Procent) progressMeterImage = "progressMeter50.png";
            else if (player.LevelChildPoints > points60Procent && player.LevelChildPoints <= points70Procent) progressMeterImage = "progressMeter60.png";
            else if (player.LevelChildPoints > points70Procent && player.LevelChildPoints <= points80Procent) progressMeterImage = "progressMeter70.png";
            else if (player.LevelChildPoints > points80Procent && player.LevelChildPoints <= points90Procent) progressMeterImage = "progressMeter80.png";
            else if (player.LevelChildPoints > points90Procent && player.LevelChildPoints <= points100Procent) progressMeterImage = "progressMeter90.png";
            else progressMeterImage = "progressMeter100.png";

            return progressMeterImage;
        }
    }
}
