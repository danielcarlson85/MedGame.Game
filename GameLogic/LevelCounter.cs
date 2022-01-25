using MedGame.Models;

namespace MedGame.GameLogic
{
    public class LevelCounter
    {
        public static Levels CheckLevel(double playerPoints)
        {
            if (playerPoints >= 0 && playerPoints <= (int)Levels.Baby) { return Levels.Baby; }
            else if (playerPoints >= (int)Levels.Baby && playerPoints <= (int)Levels.Child) { return Levels.Child; }
            else if (playerPoints >= (int)Levels.Child && playerPoints <= (int)Levels.Teenager) { return Levels.Teenager; }
            else if (playerPoints >= (int)Levels.Teenager && playerPoints <= (int)Levels.Pupil) { return Levels.Pupil; }
            else if (playerPoints >= (int)Levels.Pupil && playerPoints <= (int)Levels.YoungAdult) { return Levels.YoungAdult; }
            else if (playerPoints >= (int)Levels.YoungAdult && playerPoints <= (int)Levels.Adult) { return Levels.Adult; }
            else if (playerPoints >= (int)Levels.Adult && playerPoints <= (int)Levels.OldAdult) { return Levels.OldAdult; }
            else if (playerPoints >= (int)Levels.OldAdult && playerPoints <= (int)Levels.Old) { return Levels.Old; }
            else if (playerPoints >= (int)Levels.Old && playerPoints <= (int)Levels.Master) { return Levels.Master; }
            else if (playerPoints >= (int)Levels.Master && playerPoints <= (int)Levels.Munk) { return Levels.Munk; }
            else return Levels.God;
        }
    }
}