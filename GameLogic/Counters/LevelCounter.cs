using MedGame.Models;

namespace MedGame.GameLogic
{
    public class LevelCounter
    {
        public static Levels CheckLevel(double playerPoints)
        {
            Levels level;

            if (playerPoints >= 0 && playerPoints <= (int)Levels.Baby) { level = Levels.Baby; }
            else if (playerPoints >= (int)Levels.Baby && playerPoints <= (int)Levels.Child) { level = Levels.Child; }
            else if (playerPoints >= (int)Levels.Child && playerPoints <= (int)Levels.Teenager) { level = Levels.Teenager; }
            else if (playerPoints >= (int)Levels.Teenager && playerPoints <= (int)Levels.Pupil) { level = Levels.Pupil; }
            else if (playerPoints >= (int)Levels.Pupil && playerPoints <= (int)Levels.YoungAdult) { level = Levels.YoungAdult; }
            else if (playerPoints >= (int)Levels.YoungAdult && playerPoints <= (int)Levels.Adult) { level = Levels.Adult; }
            else if (playerPoints >= (int)Levels.Adult && playerPoints <= (int)Levels.OldAdult) { level = Levels.OldAdult; }
            else if (playerPoints >= (int)Levels.OldAdult && playerPoints <= (int)Levels.Old) { level = Levels.Old; }
            else if (playerPoints >= (int)Levels.Old && playerPoints <= (int)Levels.Master) { level = Levels.Master; }
            else if (playerPoints >= (int)Levels.Master && playerPoints <= (int)Levels.Munk) { level = Levels.Munk; }
            else level = Levels.God;

            return level;
        }

        public static void GeLevelPointsWithMultiplicator(Player player, double totalMinutesMeditatedNow, double multiplicator)
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


        public static void GetLevelPointsWithoutMultiplicator(Player player, double totalMinutesMeditatedNow)
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

    }
}