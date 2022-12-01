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
            player.Multiplicator += 1;
            player.Health = 144;
            player.LastDateMeditated = DateTime.Now;
            SetPoints(player, true);

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
                if (player.Level == Levels.Baby) player.LevelBabyPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.Child) player.LevelChildPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.Teenager) player.LevelTeenagerPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.Pupil) player.LevelPupilPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.YoungAdult) player.LevelYoungAdultPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.Adult) player.LevelAdultPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.OldAdult) player.LevelOldAdultPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.Old) player.LevelOldPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.Master) player.LevelMasterPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.Munk) player.LevelMunkPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                if (player.Level == Levels.God) player.LevelGodPoints += (player.TotalMinutesMeditatedNow * player.Multiplicator);
                player.Points += player.TotalMinutesMeditatedNow * player.Multiplicator;
            }
            else
            {
                if (player.Level == Levels.Baby) player.LevelBabyPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.Child) player.LevelChildPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.Teenager) player.LevelTeenagerPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.Pupil) player.LevelPupilPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.YoungAdult) player.LevelYoungAdultPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.Adult) player.LevelAdultPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.OldAdult) player.LevelOldAdultPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.Old) player.LevelOldPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.Master) player.LevelMasterPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.Munk) player.LevelMunkPoints += (player.TotalMinutesMeditatedNow);
                if (player.Level == Levels.God) player.LevelGodPoints += (player.TotalMinutesMeditatedNow);
                player.Points += player.TotalMinutesMeditatedNow;
            }
        }
    }
}
