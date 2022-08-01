using MedGame.Models;
using System;
using System.Threading;
using System.Timers;

namespace MedGame.GameLogic
{
    public class GamePlay
    {
        public static Player Player = new Player();
        public static int totalMinutesMeditatedNow = 0;

        public static void StopMeditation(bool hasMeditatedEnough)
        {
            if (hasMeditatedEnough)
            {
                if (DateCounters.CheckSameDate(Player))
                {
                    Player = GameScoreCounter.CalculateMeditationScoreOnSameDay(Player, Player.TotalMinutesMeditatedNow);
                }
                else
                {
                    Player = GameScoreCounter.CalculateMeditationScore(Player, Player.TotalMinutesMeditatedNow, Player.Multiplicator);
                }
            }
            

            Player.TotalDaysMeditatedInRow = DateCounters.GetTotalDaysInRow(Player);
            Player.MaxTotalDaysMeditatedInRow = DateCounters.GetMaxTotalDaysMeditatedInRow(Player);

            Player.LastDateMeditated = DateTime.Now;
            Player.Health = 144;
            Player.TotalMinutesMissed = 0;
            Player.TotalHoursMissed = 0;
            Player.TotalMinutesMeditatedNow = 0;
            Player.TotalMinutesMeditated = 0;
            Player.Level = LevelCounter.CheckLevel(Player.Points);
            Player.PunishDay1 = false;
            Player.PunishDay2 = false;
            Player.PunishDay3 = false;
            Player.PunishDay4 = false;
        }
    }
}
