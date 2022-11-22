using MedGame.GameLogic;
using MedGame.Mobile.Services;
using MedGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        string health = string.Empty;


        public string Health
        {
            get { return health; }
            set { SetProperty(ref health, value); }
        }

        string gender = string.Empty;

        public string Gender
        {
            get { return gender; }
            set { SetProperty(ref gender, value); }
        }

        private string points;
        
        public string Points
        {
            get { return points; }
            set { SetProperty(ref points, value); }
        }

        private string levelPoints;
        
        public string LevelPoints
        {
            get { return levelPoints; }
            set { SetProperty(ref levelPoints, value); }
        }

        public PlayerDatabase Database { get; }

        public SettingsPageViewModel()
        {
            Database = PlayerDatabase.Instance.GetAwaiter().GetResult();

            Id = GameModels.Player.Id.ToString();
            Name = GameModels.Player.Name;
            Email = GameModels.Player.Email;
            Address = GameModels.Player.Address;
            Gender = GameModels.Player.Gender;
            Birthday = GameModels.Player.Birthday;
            Health = GameModels.Player.Health.ToString();
            Points = GameModels.Player.Points.ToString();
        }

        internal async Task DeleteAllPlayers()
        {
            await Database.DeleteAllItemsAsync();
        }

        internal void ResetPlayer(string email)
        {
            GameModels.Player = new Player();
            GameModels.Player = Player.ResetPlayer(email);
        }

        internal async Task<string> GetAllPlayersNameAndId()
        {
            var players = await Database.GetItemsAsync();

            var playersNameAndId = new List<string>();

            foreach (var player in players)
            {
                playersNameAndId.Add($"{player.Id}:{player.Email}");
            }

            var fullPlayersListString = string.Join("\n", playersNameAndId);

            return fullPlayersListString;
        }

        public async Task UpdatePlayer()
        {
            var playerToUpdate = await Database.GetPlayerByEmailAsync(GameModels.Player.Email);

            playerToUpdate.Name = Name;
            playerToUpdate.Address = Address;
            playerToUpdate.Gender = Gender;
            playerToUpdate.Birthday = Birthday;
            playerToUpdate.Health = double.Parse(Health);
            playerToUpdate.Points = double.Parse(Points);
            await Database.UpdateItemAsync(playerToUpdate);
            GameModels.Player = playerToUpdate;
        }
    }
}