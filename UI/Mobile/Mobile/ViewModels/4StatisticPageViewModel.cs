using MedGame.GameLogic;
using MedGame.Mobile.Services;
using System;
using System.Threading.Tasks;
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
        
        string maxTotalDaysMeditatedInRow = string.Empty;
        public string MaxTotalDaysMeditatedInRow
        {
            get { return maxTotalDaysMeditatedInRow; }
            set { SetProperty(ref maxTotalDaysMeditatedInRow, value); }
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

        string totalMinutesMissed = string.Empty;
        public string TotalMinutesMissed
        {
            get { return totalMinutesMissed; }
            set { SetProperty(ref totalMinutesMissed, value); }
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

        public PlayerDatabase Database { get; }


        public StatisticPageViewModel()
        {
            Title = "test";
            Database = PlayerDatabase.Instance.GetAwaiter().GetResult();

            UpdateUI();
        }

        public void UpdateUI()
        {
            GameScoreCounter.CalculateSigninScore(GameModels.Player);

            MaxTotalDaysMeditatedInRow = "Max Total Days Meditated In Row: " + GameModels.Player.MaxTotalDaysMeditatedInRow.ToString();
            TotalDaysMeditatedInRow = "Total Days Meditated In Row: " + GameModels.Player.TotalDaysMeditatedInRow.ToString();
            TotalMinutesMissed = "Total Minutes Missed: " + GameModels.Player.TotalMinutesMissed.ToString();
            TotalHoursMissed = "Total Hours Missed: " + GameModels.Player.TotalHoursMissed.ToString();
            TotalMinutesMeditatedNow = "Total Minutes Meditated Now: " + GameModels.Player.TotalMinutesMeditatedNow.ToString();
            TotalMinutesMeditatedToday = "Total Minutes Meditated Today: " + GameModels.Player.TotalMinutesMeditatedToday.ToString();
            Points = GameModels.Player.Points.ToString();
            Health = "Health: "+GameModels.Player.Health.ToString();
            Email = "Email: " + GameModels.Player.Email.ToString();
            Gender = "Gender: " + GameModels.Player.Gender.ToString();
            Birthday = "Birthday: " + GameModels.Player.Birthday.ToString();
            Address = "Address: " + GameModels.Player.Address.ToString();
            Password = "Password: " + GameModels.Player.Password.ToString();
            Multiplicator = GameModels.Player.Multiplicator.ToString();
            LastDateMeditated = "Last Date Meditated: " + GameModels.Player.LastDateMeditated.ToString();
            Level = "Level: " + GameModels.Player.Level.ToString();
            Name = "Name: " + GameModels.Player.Name.ToString();
        }

        public async Task UpdatePlayer()
        {
            var playerToUpdate = await Database.GetPlayerByEmailAsync(GameModels.Player.Email);;
            playerToUpdate.Points = double.Parse(Points);
            playerToUpdate.Multiplicator = double.Parse(Multiplicator);

            await Database.UpdateItemAsync(playerToUpdate);
            GameModels.Player = playerToUpdate;
        }
    }
}