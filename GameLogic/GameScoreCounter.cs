using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public class GameScoreCounter
    {
        public Player CalculateSigninScore(Player player)
        {

            player.TotalHoursMissed = CalculateMissedHours(DateTime.Now, player.LastDateMeditated);
            player.Multiplicator = MultiplicatorCounter.CalculateMultiplicator(player.TotalHoursMissed, player.Multiplicator);      //Check punishment int/double
            player.Level = LevelCounter.CheckLevel(player.Points);
            player.PunishmentHasBeenMade = true;

            return player;
        }

        public int CalculateMissedDates(DateTime LastDateMeditated, DateTime todaysDate)
        {
            int totalDaysMissed = (todaysDate.Date - LastDateMeditated.Date).Days;
            if (totalDaysMissed <= 0) return 0;

            return totalDaysMissed;
        }

        public double CalculateMissedHours(DateTime lastDateMeditated, DateTime currentHour)
        {
            var totalHoursMissed = (lastDateMeditated - currentHour).TotalHours;

            return totalHoursMissed;
        }

        public static Player CalculateMeditationScore(Player player, double totalMinutesMeditatedNow, double multiplicator)
        {
            player.LastDateMeditated = DateTime.Now;
            player.TotalMinutesMeditatedToday += totalMinutesMeditatedNow;
            player.TotalMinutesMeditated += totalMinutesMeditatedNow;
            player.Points += (totalMinutesMeditatedNow * multiplicator);
            player.TotalMinutesMeditatedNow = 0;
            player.Multiplicator += 1;

            return player;
        }

        public static Player CalculateMeditationScoreOnSameDay(Player player, double TotalMinutesMeditatedNow)
        {
            player.LastDateMeditated = DateTime.Now;
            player.TotalMinutesMeditatedToday += TotalMinutesMeditatedNow;
            player.TotalMinutesMeditated += TotalMinutesMeditatedNow;
            player.Points += TotalMinutesMeditatedNow;
            player.TotalMinutesMeditatedNow = 0;

            return player;
        }
    }
}
