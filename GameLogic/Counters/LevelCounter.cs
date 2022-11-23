using MedGame.Models;

namespace MedGame.GameLogic
{
    public class LevelCounter
    {
        public static Levels CheckLevel(Player player)
        {
            Levels level;

            if (player.Points >= 0 && player.Points <= (int)Levels.Baby) { level = Levels.Baby; }
            else if (player.Points >= (int)Levels.Baby && player.Points <= (int)Levels.Child) { level = Levels.Child; }
            else if (player.Points >= (int)Levels.Child && player.Points <= (int)Levels.Teenager) { level = Levels.Teenager; }
            else if (player.Points >= (int)Levels.Teenager && player.Points <= (int)Levels.Pupil) { level = Levels.Pupil; }
            else if (player.Points >= (int)Levels.Pupil && player.Points <= (int)Levels.YoungAdult) { level = Levels.YoungAdult; }
            else if (player.Points >= (int)Levels.YoungAdult && player.Points <= (int)Levels.Adult) { level = Levels.Adult; }
            else if (player.Points >= (int)Levels.Adult && player.Points <= (int)Levels.OldAdult) { level = Levels.OldAdult; }
            else if (player.Points >= (int)Levels.OldAdult && player.Points <= (int)Levels.Old) { level = Levels.Old; }
            else if (player.Points >= (int)Levels.Old && player.Points <= (int)Levels.Master) { level = Levels.Master; }
            else if (player.Points >= (int)Levels.Master && player.Points <= (int)Levels.Munk) { level = Levels.Munk; }
            else level = Levels.God;

            return level;
        }

        public static void GeLevelPointsWithMultiplicator(Player player)
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
        }


        public static void GetLevelPointsWithoutMultiplicator(Player player)
        {
            if (player.Level == Levels.Baby) player.LevelBabyPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.Child) player.LevelChildPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.Teenager) player.LevelTeenagerPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.Pupil) player.LevelPupilPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.YoungAdult) player.LevelYoungAdultPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.Adult) player.LevelAdultPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.OldAdult) player.LevelOldAdultPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.Old) player.LevelOldPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.Master) player.LevelMasterPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.Munk) player.LevelMunkPoints += player.TotalMinutesMeditatedNow;
            if (player.Level == Levels.God) player.LevelGodPoints += player.TotalMinutesMeditatedNow;
        }

    }
}