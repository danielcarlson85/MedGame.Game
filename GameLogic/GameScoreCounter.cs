using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public class GameScoreCounter
    {
        public Player CalculateSigninScore(Player player)
        {
            player.LastDateLoggedIn = DateTime.Now;
            player.TotalMinutesMissed = CalculateMissedMinutes(player.LastDateMeditated, DateTime.Now);
            player.Multiplicator = MultiplicatorCounter.CalculateMultiplicator(player.TotalMinutesMissed, player.Multiplicator);      //Check punishment int/double
            player.Health = CalculateHealth(player);

            return player;
        }

        public Player CalculateSigninScoreWithoutPunishment(Player player)
        {
            player.LastDateLoggedIn = DateTime.Now;
            player.TotalMinutesMissed = CalculateMissedMinutes(player.LastDateMeditated, DateTime.Now);

            return player;
        }


        public int CalculateMissedDates(DateTime LastDateMeditated, DateTime todaysDate)
        {
            int totalDaysMissed = (todaysDate.Date - LastDateMeditated.Date).Days;
            if (totalDaysMissed <= 0) return 0;

            return totalDaysMissed;
        }

        public double CalculateMissedMinutes(DateTime lastDateMeditated, DateTime currentHour)
        {
            var totalMinutesMissed = (currentHour - lastDateMeditated).TotalMinutes;
            return totalMinutesMissed;
        }

        public static Player CalculateMeditationScore(Player player, double totalMinutesMeditatedNow, double multiplicator)
        {
            player.LastDateMeditated = DateTime.Now;
            player.TotalMinutesMeditatedToday += totalMinutesMeditatedNow;
            player.TotalMinutesMeditated += totalMinutesMeditatedNow;
            player.Points += (totalMinutesMeditatedNow * multiplicator);
            player.TotalMinutesMeditatedNow = 0;
            player.Multiplicator += 1;
            player.Health = 72;

            return player;
        }

        public static Player CalculateMeditationScoreOnSameDay(Player player, double TotalMinutesMeditatedNow)
        {
            player.LastDateMeditated = DateTime.Now;
            player.TotalMinutesMeditatedToday += TotalMinutesMeditatedNow;
            player.TotalMinutesMeditated += TotalMinutesMeditatedNow;
            player.TotalMinutesMeditatedNow = 0;
            player.Health = 72;

            return player;
        }

        public static double CalculateHealth(Player player)
        {
            var totalMinutesSinceLasPunishment = (player.LastTimeHealthPunishmentWasMade - DateTime.Now).TotalMinutes;

            player.LastTimeHealthPunishmentWasMade = DateTime.Now;

            return 0;
        }

        public static bool CheckSameDate(Player player)
        {
            if (player.LastDateMeditated.Date == DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }

        public static bool CheckIfPunishmentHasBeenMade(Player player)
        {
            if (player.LastDateLoggedIn.Date == DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }
    }
}
