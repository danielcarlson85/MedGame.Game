using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public class MultiplicatorCounter
    {
        public static double CalculateMultiplicator(double totalMinutesMissed, double currentMultiplicatorPoints)
        {
            double multiplicatorTemp = 0;

            //Point punishment by reduced multiplicator
            if (totalMinutesMissed >= 1440 && totalMinutesMissed <= 2880)
            {
                multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.80);
            }
            else if (totalMinutesMissed > 2880 && totalMinutesMissed <= 4320)
            {
                multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.50);
            }
            else if (totalMinutesMissed > 4320)
            {
                multiplicatorTemp = 1;
            }

            else
            {
                multiplicatorTemp = currentMultiplicatorPoints;
            }

            GamePlay.Player.MultiplicatorPunishmentHasBeenMade = true;
            GamePlay.Player.LastTimeMultiplicatorPunishmentWasMade = DateTime.Now;
            return multiplicatorTemp;

        }

        internal static double CalculateMultiplicatorFromHealth(Player player)
        {
            if (player.Health <= 120 && player.Health >= 96 && (player.Punish1Day == false))
            {
                player.Multiplicator = player.Multiplicator * 0.8;
                player.Punish1Day = true;
            }

            if (player.Health < 96 && player.Health > 72 && (player.Punish2Day == false))
            {
                player.Multiplicator = player.Multiplicator * 0.6;
                player.Punish2Day = true;
            }

            if (player.Health < 72 && player.Health > 48 && (player.Punish3Day == false))
            {
                player.Multiplicator = player.Multiplicator * 0.4;
                player.Punish3Day = true;
            }

            if (player.Health < 48 && player.Health > 24 && (player.Punish4Day == false))
            {
                player.Multiplicator = player.Multiplicator * 0.2;
                player.Punish4Day = true;
            }

            if (player.Health < 24)
            {
                player.Multiplicator = 1;
            }

            if (player.Multiplicator < 1)
            {
                player.Multiplicator = 1;
            }

            return player.Multiplicator;
        }
    }
}