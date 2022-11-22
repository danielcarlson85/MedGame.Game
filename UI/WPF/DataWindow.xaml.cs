using MedGame.GameLogic;
using MedGame.Services;
using System;

using System.Windows;
using System.Windows.Threading;


namespace MedGame.UI.WPF
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

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
                "TotalMinutesMeditatedNow: " + GameModels.Player.TotalMinutesMeditatedNow.ToString() + "\n" +
                "TotalMinutesMeditatedToday: " + GameModels.Player.TotalMinutesMeditatedToday.ToString() + "\n" +
                "TotalDaysMeditatedInRow: " + GameModels.Player.TotalDaysMeditatedInRow.ToString() + "\n" +
                "TotalMinutesMeditated: " + GameModels.Player.TotalMinutesMeditated.ToString() + "\n" +
                "TotalHoursMissed: " + GameModels.Player.TotalMinutesMissed + "\n" +
                 "\n" +
                "Health: " + GameModels.Player.Health.ToString() + "\n" +
                "Points: " + GameModels.Player.Points.ToString() + "\n" +
                "Level: " + GameModels.Player.Level.ToString() + "\n" +
                "LastDateMeditated: " + GameModels.Player.LastDateMeditated.ToString() + "\n" +
                "Multiplicator: " + GameModels.Player.Multiplicator.ToString() + "\n" +
                "Password: " + GameModels.Player.Password.ToString() + "\n" +
                 "\n" +
                "Name: " + GameModels.Player.Name + "\n" +
                "Password: " + GameModels.Player.Password + "\n" +
                "PlayerMessage: " + GameModels.Player.PlayerMessage + "\n" +
                "Address: " + GameModels.Player.Address + "\n" +
                "Birthday: " + GameModels.Player.Birthday + "\n" +
                "Gender: " + GameModels.Player.Gender + "\n" +
                "HttpResult: " + GameModels.Player.HttpResult + "\n" +
                 "\n" +
                "Email: " + GameModels.Player.Email.ToString();
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
            //GameScoreCounter.CalculateSigninScore(GamePlay.Player);
        }
    }
}