﻿using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public static class GameScoreCounter
    {
        public static Player CalculateSigninScore(Player player)
        {
            player.LastDateLoggedIn = DateTime.Now;
            player.TotalMinutesMissed = CalculateMissedMinutes(player.LastDateMeditated, DateTime.Now);
            player.TotalHoursMissed = CalculateMissedHours(player.LastDateMeditated, DateTime.Now);
            player.Multiplicator = MultiplicatorCounter.CalculateMultiplicator(player.TotalMinutesMissed, player.Multiplicator);      //Check punishment int/double
            player.Health = CalculateHealth(player);

            return player;
        }

        public static Player CalculateSigninScoreWithoutPunishment(Player player)
        {
            player.LastDateLoggedIn = DateTime.Now;
            player.TotalMinutesMissed = CalculateMissedMinutes(player.LastDateMeditated, DateTime.Now);

            return player;
        }


        public static int CalculateMissedDates(DateTime LastDateMeditated, DateTime todaysDate)
        {
            int totalDaysMissed = (todaysDate.Date - LastDateMeditated.Date).Days;
            if (totalDaysMissed <= 0) return 0;

            return totalDaysMissed;
        }

        public static double CalculateMissedMinutes(DateTime lastDateMeditated, DateTime currentHour)
        {
            var totalMinutesMissed = (currentHour - lastDateMeditated).TotalMinutes;
            return totalMinutesMissed;
        }

        public static double CalculateMissedHours(DateTime lastDateMeditated, DateTime currentHour)
        {
            var totalHoursMissed = (currentHour - lastDateMeditated).TotalHours;
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
            player.Health = 72;

            return player;
        }

        public static Player CalculateMeditationScoreOnSameDay(Player player, double totalMinutesMeditatedNow)
        {
            player.LastDateMeditated = DateTime.Now;
            player.TotalMinutesMeditatedToday += totalMinutesMeditatedNow;
            player.TotalMinutesMeditated += totalMinutesMeditatedNow;
            player.TotalMinutesMeditatedNow = 0;
            player.Points += totalMinutesMeditatedNow;
            player.Health = 72;


            return player;
        }

        public static double CalculateHealth(Player player)
        {
            var totalHoursSinceLastMeditation = (DateTime.Now-player.LastDateMeditated).TotalHours;

            var totalHealth = (72 - totalHoursSinceLastMeditation);

            return totalHealth;
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
