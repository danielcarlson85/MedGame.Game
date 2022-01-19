using MedGame.GameLogic;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.ViewModels
{
    public class StatisticPageViewModel : BaseViewModel
    {
        string totalMinutesMeditatedNow = string.Empty;
        public string TotalMinutesMeditatedNow
        {
            get { return totalMinutesMeditatedNow; }
            set { SetProperty(ref totalMinutesMeditatedNow, value); }
        }

        string totalMinutesMeditatedToday = string.Empty;
        public string TotalMinutesMeditatedToday
        {
            get { return totalMinutesMeditatedToday; }
            set { SetProperty(ref totalMinutesMeditatedToday, value); }
        }

        string totalDaysMeditatedInRow = string.Empty;
        public string TotalDaysMeditatedInRow
        {
            get { return totalDaysMeditatedInRow; }
            set { SetProperty(ref totalDaysMeditatedInRow, value); }
        }

        string totalMinutesMeditated = string.Empty;
        public string TotalMinutesMeditated
        {
            get { return totalMinutesMeditated; }
            set { SetProperty(ref totalMinutesMeditated, value); }
        }

        string totalHoursMissed = string.Empty;
        public string TotalHoursMissed
        {
            get { return totalHoursMissed; }
            set { SetProperty(ref totalHoursMissed, value); }
        }

        string health = string.Empty;
        public string Health
        {
            get { return health; }
            set { SetProperty(ref health, value); }
        }

        string points = string.Empty;
        public string Points
        {
            get { return points; }
            set { SetProperty(ref points, value); }
        }

        string level = string.Empty;
        public string Level
        {
            get { return level; }
            set { SetProperty(ref level, value); }
        }

        string lastDateMeditated = string.Empty;
        public string LastDateMeditated
        {
            get { return lastDateMeditated; }
            set { SetProperty(ref lastDateMeditated, value); }
        }

        string multiplicator = string.Empty;
        public string Multiplicator
        {
            get { return multiplicator; }
            set { SetProperty(ref multiplicator, value); }
        }

        string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }


        string playerMessage = string.Empty;
        public string PlayerMessage
        {
            get { return playerMessage; }
            set { SetProperty(ref playerMessage, value); }
        }


        string address = string.Empty;
        public string Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }


        string birthday = string.Empty;
        public string Birthday
        {
            get { return birthday; }
            set { SetProperty(ref birthday, value); }
        }


        string gender = string.Empty;
        public string Gender
        {
            get { return gender; }
            set { SetProperty(ref gender, value); }
        }


        string httpResult = string.Empty;
        public string HttpResult
        {
            get { return httpResult; }
            set { SetProperty(ref httpResult, value); }
        }

        string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public StatisticPageViewModel()
        {
            Title = "test";

            UpdateUI();
        }

        public void UpdateUI()
        {
            TotalDaysMeditatedInRow = "TotalDaysMeditatedInRow: " + GamePlay.Player.TotalDaysMeditatedInRow.ToString();
            TotalHoursMissed = "TotalHoursMissed: " + GamePlay.Player.TotalHoursMissed.ToString();
            TotalMinutesMeditated = "TotalMinutesMeditated: " + GamePlay.Player.TotalMinutesMeditated.ToString();
            TotalMinutesMeditatedNow = "TotalMinutesMeditatedNow: " + GamePlay.Player.TotalMinutesMeditatedNow.ToString();
            TotalMinutesMeditatedToday = "TotalMinutesMeditatedToday: " + GamePlay.Player.TotalMinutesMeditatedToday.ToString();
            Points = "Points: " + GamePlay.Player.Points.ToString();
            Health = "Health: " + GamePlay.Player.Health.ToString();
            Email = "Email: " + GamePlay.Player.Email.ToString();
            HttpResult = "HttpResult: " + GamePlay.Player.HttpResult;
            Gender = "Gender: " + GamePlay.Player.Gender.ToString();
            Birthday = "Birthday: " + GamePlay.Player.Birthday.ToString();
            Address = "Address: " + GamePlay.Player.Address.ToString();
            PlayerMessage = "PlayerMessage: " + GamePlay.Player.PlayerMessage.ToString();
            Password = "Password: " + GamePlay.Player.Password.ToString();
            Multiplicator = "Multiplicator: " + GamePlay.Player.Multiplicator.ToString();
            LastDateMeditated = "LastDateMeditated: " + GamePlay.Player.LastDateMeditated.ToString();
            Level = "Level: " + GamePlay.Player.Level.ToString();
            Name = "Name: " + GamePlay.Player.Name.ToString();

        }
    }
}