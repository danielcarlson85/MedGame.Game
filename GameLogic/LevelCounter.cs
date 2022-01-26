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
    }
}