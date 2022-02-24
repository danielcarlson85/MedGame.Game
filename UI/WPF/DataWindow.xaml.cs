using MedGame.GameLogic;
using MedGame.Services;
using System;

using System.Windows;
using System.Windows.Threading;


namespace MedGame.UI.WPF
{
    public partial class MainWindow : Window
    {
        readonly DispatcherTimer timer = new DispatcherTimer();

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
                "TotalDaysMeditatedInRow: " + GamePlay.Player.TotalDaysMeditatedInRow.ToString() + "\n" +
                "TotalMinutesMeditated: " + GamePlay.Player.TotalMinutesMeditated.ToString() + "\n" +
                "TotalHoursMissed: " + GamePlay.Player.TotalMinutesMissed + "\n" +
                 "\n" +
                "Health: " + GamePlay.Player.Health.ToString() + "\n" +
                "Points: " + GamePlay.Player.Points.ToString() + "\n" +
                "Level: " + GamePlay.Player.Level.ToString() + "\n" +
                "LastDateMeditated: " + GamePlay.Player.LastDateMeditated.ToString() + "\n" +
                "Multiplicator: " + GamePlay.Player.Multiplicator.ToString() + "\n" +
                "Password: " + GamePlay.Player.Password.ToString() + "\n" +
                 "\n" +
                "Name: " + GamePlay.Player.Name + "\n" +
                "Password: " + GamePlay.Player.Password + "\n" +
                "PlayerMessage: " + GamePlay.Player.PlayerMessage + "\n" +
                "Address: " + GamePlay.Player.Address + "\n" +
                "Birthday: " + GamePlay.Player.Birthday + "\n" +
                "Gender: " + GamePlay.Player.Gender + "\n" +
                "HttpResult: " + GamePlay.Player.HttpResult + "\n" +
                 "\n" +
                "Email: " + GamePlay.Player.Email.ToString();
            }
            catch (System.Exception) { }
        }

        private void Dateback_Click(object sender, RoutedEventArgs e)
        {
            DateHandler.SetSystemDateTime(DateTime.Now.AddDays(-1));
        }

        private void Dateforward_Click(object sender, RoutedEventArgs e)
        {

            DateHandler.SetSystemDateTime(DateTime.Now.AddDays(1));
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            //GameScoreCounter.CalculateSigninScore(GamePlay.Player);
        }
    }
}