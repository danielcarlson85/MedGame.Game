using MedGame.Models;
using System;
using System.Timers;

namespace MedGame.GameLogic
{
    public class GamePlay
    {
        public static Player Player = new Player();
        public static int totalMinutesMeditatedNow = 0;

        public static Timer MeditationTimer { get; set; } = new Timer();

        public static void StartMeditation()
        {
            MeditationTimer = new Timer
            {
                Interval = 1000
            };
            MeditationTimer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                Player.TotalMinutesMeditatedNow++;
            };
            MeditationTimer.Start();

        }

        public static void StopMeditation()
        {
            MeditationTimer.Stop();

            if (DateCounters.CheckSameDate(Player))
            {
                Player = GameScoreCounter.CalculateMeditationScoreOnSameDay(Player, Player.TotalMinutesMeditatedNow);
            }
            else
            {
                Player = GameScoreCounter.CalculateMeditationScore(Player, Player.TotalMinutesMeditatedNow, Player.Multiplicator);
            }

            Player.TotalDaysMeditatedInRow = DateCounters.GetTotalDaysInRow(Player);
            Player.MaxTotalDaysMeditatedInRow = DateCounters.GetMaxTotalDaysMeditatedInRow(Player);

            Player.LastDateMeditated = DateTime.Now;
            Player.Health = 144;
            Player.TotalMinutesMissed = 0;
            Player.TotalHoursMissed = 0;
            Player.TotalMinutesMeditatedNow = 0;
            Player.Level = LevelCounter.CheckLevel(Player.Points);
            Player.PunishDay1 = false;
            Player.PunishDay2 = false;
            Player.PunishDay3 = false;
            Player.PunishDay4 = false;
        }
    }
}
