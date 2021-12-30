﻿using MedGame.GameLogic;
using MedGame.Services;
using System;

using System.Windows;
using System.Windows.Threading;


namespace MedGame.UI.WPF
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        GameScoreCounter gameScoreCounter = new GameScoreCounter();

        public MainWindow()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (object sender, EventArgs e) => { UpdateUI(); };
            timer.Start();
            InitializeComponent();

        }

        public void UpdateUI()
        {
            try
            {
                LabelPlayer.Content =
                "TotalMinutesMeditatedNow: " + GamePlay.Player.TotalMinutesMeditatedNow.ToString() + "\n" +
                "TotalMinutesMeditatedToday: " + GamePlay.Player.TotalMinutesMeditatedToday.ToString() + "\n" +
                "Health: " + GamePlay.Player.Health.ToString() + "\n" +
                "Level: " + GamePlay.Player.Level.ToString() + "\n" +
                "LastDateMeditated: " + GamePlay.Player.LastDateMeditated.ToString() + "\n" +
                "Multiplicator: " + GamePlay.Player.Multiplicator.ToString() + "\n" +
                "Password: " + GamePlay.Player.Password.ToString() + "\n" +
                "Points: " + GamePlay.Player.Points.ToString() + "\n" +
                "TotalDaysMeditatedInRow: " + GamePlay.Player.TotalDaysMeditatedInRow.ToString() + "\n" +
                "TotalDaysMissed: " + GamePlay.Player.TotalDaysMissed.ToString() + "\n" +
                "TotalMinutesMeditated: " + GamePlay.Player.TotalMinutesMeditated.ToString() + "\n" +
                "TotalHoursMissed: " + GamePlay.Player.TotalHoursMissed + "\n" +
                "Email: " + GamePlay.Player.Email.ToString();
            }
            catch (System.Exception) { }
        }

        private void dateback_Click(object sender, RoutedEventArgs e)
        {
            DateHandler.SetSystemDateTime(DateTime.Now.AddDays(-1));
        }

        private void dateforward_Click(object sender, RoutedEventArgs e)
        {

            DateHandler.SetSystemDateTime(DateTime.Now.AddDays(1));
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            gameScoreCounter.CalculateSigninScore(GamePlay.Player);
        }
    }
}