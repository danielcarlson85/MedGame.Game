using MedGame.GameLogic;

namespace MedGame.UI.Mobile.ViewModels
{
    public class SharePageViewModel : BaseViewModel
    {
        public SharePageViewModel()
        {
            Title = "test";

            LabelPlayerInfo =
                "TotalMinutesMeditatedNow: " + GamePlay.Player.TotalMinutesMeditatedNow.ToString() + "\n" +
                "TotalMinutesMeditatedToday: " + GamePlay.Player.TotalMinutesMeditatedToday.ToString() + "\n" +
                "TotalDaysMeditatedInRow: " + GamePlay.Player.TotalDaysMeditatedInRow.ToString() + "\n" +
                "TotalMinutesMeditated: " + GamePlay.Player.TotalMinutesMeditated.ToString() + "\n" +
                "TotalHoursMissed: " + GamePlay.Player.TotalHoursMissed + "\n" +
                 "\n" +
                "Health: " + GamePlay.Player.Health.ToString() + "\n" +
                "Points: " + GamePlay.Player.Points.ToString() + "\n" +
                "Level: " + GamePlay.Player.Level.ToString() + "\n" +
                "LastDateMeditated: " + GamePlay.Player.LastDateMeditated.ToString() + "\n" +
                "Multiplicator: " + GamePlay.Player.Multiplicator.ToString() + "\n" +
                "Password: " + GamePlay.Player.Password.ToString() + "\n" +
                 "\n" +
                 "\n" +
                "Name: " + GamePlay.Player.Name + "\n" +
                "Password: " + GamePlay.Player.Password + "\n" +
                "PlayerMessage: " + GamePlay.Player.PlayerMessage + "\n" +
                "Address: " + GamePlay.Player.Address + "\n" +
                "Birthday: " + GamePlay.Player.Birthday + "\n" +
                "Gender: " + GamePlay.Player.Gender + "\n" +
                "HttpResult: " + GamePlay.Player.HttpResult + "\n" +
                "Email: " + GamePlay.Player.Email.ToString();


        }

        string labelPlayerInfo = string.Empty;
        public string LabelPlayerInfo
        {
            get { return labelPlayerInfo; }
            set { SetProperty(ref labelPlayerInfo, value); }
        }
    }
}