using MedGame.GameLogic;
using MedGame.Mobile.Services;
using System.Threading.Tasks;

namespace MedGame.UI.Mobile.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        string id = string.Empty;
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
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

        public PlayerDatabase Database { get; }


        public SettingsPageViewModel()
        {
            Database = PlayerDatabase.Instance.GetAwaiter().GetResult();

            Id = GamePlay.Player.Id.ToString();
            Name = GamePlay.Player.Name;
            Email = GamePlay.Player.Email;
            Address = GamePlay.Player.Address;
            Gender = GamePlay.Player.Gender;
            Birthday = GamePlay.Player.Birthday;

        }

        public async Task SavePlayer()
        {
            GamePlay.Player.Email = Email;
            GamePlay.Player.Name = Name;
            GamePlay.Player.Address = Address;
            GamePlay.Player.Gender = Gender;
            GamePlay.Player.Birthday = Birthday;

            await Database.SaveItemAsync(GamePlay.Player);
        }
    }
}