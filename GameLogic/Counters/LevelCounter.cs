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
            else if (player.Points >= (int)Levels.Teenager && player.Points <= (int)Levels.Adult) { level = Levels.Adult; }
            else if (player.Points >= (int)Levels.Adult && player.Points <= (int)Levels.Master) { level = Levels.Master; }
            else if (player.Points >= (int)Levels.Master && player.Points <= (int)Levels.Munk) { level = Levels.Munk; }
            else level = Levels.God;

            return level;
        }
    }
}