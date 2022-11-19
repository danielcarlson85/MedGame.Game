﻿using MedGame.Models;
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
            player.Level = LevelCounter.CheckLevel(player.Points);

            player.Multiplicator = MultiplicatorCounter.CalculateMultiplicatorFromDates(player);      //Check punishment int/double

            return player;
        }

        public static Player CalculateSigninScoreWithoutPunishment(Player player)
        {
            player.LastDateLoggedIn = DateTime.Now;
            player.TotalMinutesMissed = TimeCounters.CalculateMissedMinutes(player.LastDateMeditated, DateTime.Now);

            return player;
        }

        public static Player CalculateMeditationScore(Player player, double totalMinutesMeditatedNow, double multiplicator)
        {
            player.TotalMinutesMeditatedToday += totalMinutesMeditatedNow;
            player.TotalMinutesMeditated += totalMinutesMeditatedNow;
            player.Points += (totalMinutesMeditatedNow * multiplicator);
            player.Multiplicator += 1;
            LevelCounter.GeLevelPointsWithMultiplicator(player, totalMinutesMeditatedNow, multiplicator);

            return player;
        }

      

        public static Player CalculateMeditationScoreOnSameDay(Player player, double totalMinutesMeditatedNow)
        {
            player.TotalMinutesMeditatedToday += totalMinutesMeditatedNow;
            player.TotalMinutesMeditated += totalMinutesMeditatedNow;
            player.Points += totalMinutesMeditatedNow;

            LevelCounter.GetLevelPointsWithoutMultiplicator(player, totalMinutesMeditatedNow);

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
    }
}