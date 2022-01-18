using MedGame.Models;
using System;
using System.Timers;

namespace MedGame.GameLogic
{
    public class GamePlay
    {
        public static Player Player = new Player();

        public static Timer MeditationTimer { get; set; } = new Timer();

        public static void StartMeditation()
        {
            MeditationTimer = new Timer();
            MeditationTimer.Interval = 1000;
            MeditationTimer.Elapsed += (object sender, ElapsedEventArgs e) => { Player.TotalMinutesMeditatedNow++; };
            MeditationTimer.Start();
        }

        public static void StopMeditation()
        {
            MeditationTimer.Stop();

            if (GameScoreCounter.CheckSameDate(Player))
            {
                Player.Points += Player.TotalMinutesMeditatedNow;
            }
            else
            {
                Player = GameScoreCounter.CalculateMeditationScore(Player, Player.TotalMinutesMeditatedNow, Player.Multiplicator);
            }

            Player.TotalMinutesMeditatedToday += Player.TotalMinutesMeditatedNow;
            Player.TotalMinutesMeditated += Player.TotalMinutesMeditatedNow;
            Player.TotalDaysMeditated = (Player.TotalMinutesMeditated / 1440);
            Player.TotalHoursMeditated = (Player.TotalMinutesMeditated / 60);

            Player.TotalMinutesMissed = 0;
            Player.Health = 144;

            Player.TotalHoursMissed = 0;
            Player.TotalMinutesMeditatedNow = 0;
            Player.LastDateMeditated = DateTime.Now;
            Player.Level = LevelCounter.CheckLevel(Player.Points);
            Player.PunishDay1 = false;
            Player.PunishDay2 = false;
            Player.PunishDay3 = false;
            Player.PunishDay4 = false;
        }
    }
}
