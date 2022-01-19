using MedGame.GameLogic;
using MedGame.Mobile.Services;
using System;
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

        internal async Task DeleteAllPlayers()
        {
            await Database.DeleteAllItemsAsync();
        }

        public async Task SavePlayer()
        {
            var playsers = await Database.GetItemsAsync();


            var playerToUpdate = await Database.GetPlayerByEmailAsync(GamePlay.Player.Email);



            playerToUpdate.Name = Name;
            playerToUpdate.Address = Address;
            playerToUpdate.Gender = Gender;
            playerToUpdate.Birthday = Birthday;

            await Database.UpdateItemAsync(playerToUpdate);
            GamePlay.Player = playerToUpdate;
        }
    }
}