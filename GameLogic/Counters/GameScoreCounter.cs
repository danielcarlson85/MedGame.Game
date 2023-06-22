using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public static class GameScoreCounter
    {
        public static Player CalculateSigninScore(Player player)
        {
            player.LastDateLoggedIn = DateTime.Now;
            player.TotalMinutesMissed = TimeCounters.CalculateMissedMinutes(player.LastDateMeditated, DateTime.Now);
            player.TotalHoursMissed = TimeCounters.CalculateMissedHours(player.LastDateMeditated, DateTime.Now);
            player.Health = CalculateHealth(player);
            player.Level = LevelCounter.CheckLevel(player);

            player.Multiplicator = MultiplicatorCounter.CalculateMultiplicatorFromDates(player);      //Check punishment int/double

            return player;
        }

        public static Player CalculateSigninScoreWithoutPunishment(Player player)
        {
            player.LastDateLoggedIn = DateTime.Now;
            player.TotalMinutesMissed = TimeCounters.CalculateMissedMinutes(player.LastDateMeditated, DateTime.Now);

            return player;
        }

        public static Player CalculateMeditationScore(Player player)
        {
            player.TotalMinutesMeditatedToday += player.TotalMinutesMeditatedNow;
            player.TotalMinutesMeditated += player.TotalMinutesMeditatedNow;
            player.Health = 144;
            player.LastDateMeditated = DateTime.Now;
            SetPoints(player, true);
            player.Multiplicator += 1;

            return player;
        }

        public static Player CalculateMeditationScoreOnSameDay(Player player)
        {
            player.TotalMinutesMeditatedToday += player.TotalMinutesMeditatedNow;
            player.TotalMinutesMeditated += player.TotalMinutesMeditatedNow;
            player.Health = 144;
            player.LastDateMeditated = DateTime.Now;
            SetPoints(player, false);

            return player;
        }


        public static double CalculateHealth(Player player)
        {
            var totalHoursSinceLastMeditation = (DateTime.Now - player.LastDateMeditated).TotalHours;

            var totalHealth = (144 - totalHoursSinceLastMeditation);

            if (totalHealth <= 0)
            {
                totalHealth = 0;
            }

            return totalHealth;
        }

        public static bool CheckIfPunishmentHasBeenMade(Player player)
        {
            if (player.LastDateLoggedIn.Date == DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }

        private static void SetPoints(Player player, bool isMultiplicatorEnabled)
        {
            if (isMultiplicatorEnabled)
            {
                player.Points += player.TotalMinutesMeditatedNow * player.Multiplicator;
            }
            else
            {
                player.Points += player.TotalMinutesMeditatedNow;
            }
        }
    }
}
