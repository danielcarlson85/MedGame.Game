using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public class MultiplicatorCounter
    {
        public static double CalculateMultiplicator(double totalMinutesMissed, double currentMultiplicatorPoints)
        {
            double multiplicatorTemp;

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

            return multiplicatorTemp;
        }

        internal static double CalculateMultiplicatorFromHealth(Player player)
        {
            if (player.Health <= 120 && player.Health >= 96 && (player.PunishDay1 == false))
            {
                //       x =             100                  * 0.9  = 90
                player.Multiplicator *= 0.9;
                player.PunishDay1 = true;
            }

            if (player.Health < 96 && player.Health > 72 && (player.PunishDay2 == false))
            {

                player.Multiplicator *= 0.85;
                player.PunishDay2 = true;
            }

            if (player.Health < 72 && player.Health > 48 && (player.PunishDay3 == false))
            {
                player.Multiplicator *= 0.60;
                player.PunishDay3 = true;
            }

            if (player.Health < 48 && player.Health > 24 && (player.PunishDay4 == false))
            {
                player.Multiplicator *= 0.50;
                player.PunishDay4 = true;
            }

            if (player.Health < 24 && (player.PunishDay5 == false))
            {
                player.Multiplicator /= 2;
                player.PunishDay5 = true;
            }

            if (player.Multiplicator < 1)
            {
                player.Multiplicator = 1;
            }

            return player.Multiplicator;
        }

        internal static double CalculateMultiplicatorFromDays(Player player)
        {
            if (player.Health <= 120 && player.Health >= 96 && (player.PunishDay1 == false))
            {
                //       x =             100                  * 0.9  = 90
                player.Multiplicator *= 0.9;
                player.PunishDay1 = true;
            }

            if (player.Health < 96 && player.Health > 72 && (player.PunishDay2 == false))
            {

                player.Multiplicator *= 0.85;
                player.PunishDay2 = true;
            }

            if (player.Health < 72 && player.Health > 48 && (player.PunishDay3 == false))
            {
                player.Multiplicator *= 0.60;
                player.PunishDay3 = true;
            }

            if (player.Health < 48 && player.Health > 24 && (player.PunishDay4 == false))
            {
                player.Multiplicator *= 0.50;
                player.PunishDay4 = true;
            }

            if (player.Health < 24 && (player.PunishDay5 == false))
            {
                player.Multiplicator /= 2;
                player.PunishDay5 = true;
            }

            if (player.Multiplicator < 1)
            {
                player.Multiplicator = 1;
            }

            return player.Multiplicator;
        }

        public static double CalculateMultiplicatorFromDates(Player player)
        {
            var oneDayMiss = DateTime.Now.AddDays(-1).Date;
            var towDayMiss = DateTime.Now.AddDays(-2).Date;
            var treeDayMiss = DateTime.Now.AddDays(-3).Date;
            var fourDayMiss = DateTime.Now.AddDays(-4).Date;
            var fiveDayMiss = DateTime.Now.AddDays(-5).Date;


            if (player.LastDateMeditated.Date == oneDayMiss && (player.PunishDay1 == false))
            {
                player.Multiplicator *= 0.8;
                player.PunishDay1 = true;
            }

            else if (player.LastDateMeditated.Date == towDayMiss && (player.PunishDay2 == false))
            {
                player.Multiplicator *= 0.6;
                player.PunishDay2 = true;
            }

            else if (player.LastDateMeditated.Date == treeDayMiss && (player.PunishDay3 == false))
            {
                player.Multiplicator *= 0.4;
                player.PunishDay3 = true;
            }

            else if (player.LastDateMeditated.Date == fourDayMiss && (player.PunishDay4 == false))
            {
                player.Multiplicator *= 0.2;
                player.PunishDay4 = true;
            }
            else if (player.LastDateMeditated.Date == fiveDayMiss && (player.PunishDay5 == false))
            {
                player.Multiplicator *= 0.1;
                player.PunishDay4 = true;
            }

            if (player.Multiplicator < 1)
            {
                player.Multiplicator = 1;
            }

            return player.Multiplicator;
        }
    }

}