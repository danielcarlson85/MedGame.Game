﻿using MedGame.Models;
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
                Player = GameScoreCounter.CalculateMeditationScoreOnSameDay(Player, Player.TotalMinutesMeditatedNow);
            }
            else
            {
                Player = GameScoreCounter.CalculateMeditationScore(Player, Player.TotalMinutesMeditatedNow, Player.Multiplicator);
            }

            Player.TotalMinutesMissed = 0;
            Player.MultiplicatorPunishmentHasBeenMade = false;
            Player.Level = LevelCounter.CheckLevel(Player.Points);
        }
    }
}
