using MedGame.Models;

namespace MedGame.GameLogic
{
    public class ProgressBarHandler
    {

        public static string GetProgressBarImage(Player player, Levels level)
        {
            string progressMeterImage;

            var points0Procent = (int)level * 1;
            var points10Procent = (int)level * 1.1;
            var points20Procent = (int)level * 1.2;
            var points30Procent = (int)level * 1.3;
            var points40Procent = (int)level * 1.4;
            var points50Procent = (int)level * 1.5;
            var points60Procent = (int)level * 1.6;
            var points70Procent = (int)level * 1.7;
            var points80Procent = (int)level * 1.8;
            var points90Procent = (int)level * 1.9;


            if (player.Points > points0Procent && player.Points <= points10Procent) progressMeterImage = "progressMeter0.png";
            else if (player.Points > points10Procent && player.Points <= points20Procent) progressMeterImage = "progressMeter10.png";
            else if (player.Points > points20Procent && player.Points <= points30Procent) progressMeterImage = "progressMeter20.png";
            else if (player.Points > points30Procent && player.Points <= points40Procent) progressMeterImage = "progressMeter30.png";
            else if (player.Points > points40Procent && player.Points <= points50Procent) progressMeterImage = "progressMeter40.png";
            else if (player.Points > points50Procent && player.Points <= points60Procent) progressMeterImage = "progressMeter50.png";
            else if (player.Points > points60Procent && player.Points <= points70Procent) progressMeterImage = "progressMeter60.png";
            else if (player.Points > points70Procent && player.Points <= points80Procent) progressMeterImage = "progressMeter70.png";
            else if (player.Points > points80Procent && player.Points <= points90Procent) progressMeterImage = "progressMeter80.png";
            else progressMeterImage = "progressMeter100.png";

            return progressMeterImage;
        }
    }
}