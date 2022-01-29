using MedGame.Models;
using System;

namespace MedGame.GameLogic
{
    public static class GameScoreCounter
    {
        public static Player CalculateSigninScore(Player player)
        {
            player.LastDateLoggedIn = DateTime.Now;
            player.TotalMinutesMissed = DateCounters.CalculateMissedMinutes(player.LastDateMeditated, DateTime.Now);
            player.TotalHoursMissed = DateCounters.CalculateMissedHours(player.LastDateMeditated, DateTime.Now);
            player.Health = CalculateHealth(player);
            player.Level = LevelCounter.CheckLevel(player.Points);

            player.Multiplicator = MultiplicatorCounter.CalculateMultiplicatorFromDates(player);      //Check punishment int/double

            return player;
        }

        public static Player CalculateSigninScoreWithoutPunishment(Player player)
        {
            player.LastDateLoggedIn = DateTime.Now;
            player.TotalMinutesMissed = DateCounters.CalculateMissedMinutes(player.LastDateMeditated, DateTime.Now);

            return player;
        }

        public static Player CalculateMeditationScore(Player player, double totalMinutesMeditatedNow, double multiplicator)
        {
            player.TotalMinutesMeditatedToday += totalMinutesMeditatedNow;
            player.TotalMinutesMeditated += totalMinutesMeditatedNow;
            player.Points += (totalMinutesMeditatedNow * multiplicator);
            player.Multiplicator += 1;
            GeLevelPointsWithMultiplicator(player, totalMinutesMeditatedNow, multiplicator);

            return player;
        }

        private static void GeLevelPointsWithMultiplicator(Player player, double totalMinutesMeditatedNow, double multiplicator)
        {
            if (player.Level == Levels.Baby) player.LevelBabyPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.Child) player.LevelChildPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.Teenager) player.LevelTeenagerPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.Pupil) player.LevelPupilPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.YoungAdult) player.LevelYoungAdultPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.Adult) player.LevelAdultPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.OldAdult) player.LevelOldAdultPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.Old) player.LevelOldPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.Master) player.LevelMasterPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.Munk) player.LevelMunkPoints += (totalMinutesMeditatedNow * multiplicator);
            if (player.Level == Levels.God) player.LevelGodPoints += (totalMinutesMeditatedNow * multiplicator);
        }


        private static void GetLevelPointsWithoutMultiplicator(Player player, double totalMinutesMeditatedNow)
        {
            if (player.Level == Levels.Baby) player.LevelBabyPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.Child) player.LevelChildPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.Teenager) player.LevelTeenagerPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.Pupil) player.LevelPupilPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.YoungAdult) player.LevelYoungAdultPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.Adult) player.LevelAdultPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.OldAdult) player.LevelOldAdultPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.Old) player.LevelOldPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.Master) player.LevelMasterPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.Munk) player.LevelMunkPoints += totalMinutesMeditatedNow;
            if (player.Level == Levels.God) player.LevelGodPoints += totalMinutesMeditatedNow;
        }


        public static Player CalculateMeditationScoreOnSameDay(Player player, double totalMinutesMeditatedNow)
        {
            player.TotalMinutesMeditatedToday += totalMinutesMeditatedNow;
            player.TotalMinutesMeditated += totalMinutesMeditatedNow;
            player.Points += totalMinutesMeditatedNow;

            GetLevelPointsWithoutMultiplicator(player, totalMinutesMeditatedNow);

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
