using MedGame.GameLogic;
using MedGame.Mobile.Services;
using MedGame.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public SignInViewModel()
        {
            Title = "test";
            Database = PlayerDatabase.Instance.GetAwaiter().GetResult();
        }

        public PlayerDatabase Database { get; }



        public async Task<Player> SignUpPlayerAsync(string playerName)
        {
            var foundPlayer = await Database.GetPlayerByEmailAsync(playerName);

            if (foundPlayer == null)
            {
                await Database.SaveItemAsync(Player.CreateNewPlayer(playerName));
            }

            return foundPlayer;
        }

        internal async Task<Player> SignInPlayerByEmailAsync(string text)
        {
            var foundPlayer = await Database.GetPlayerByEmailAsync(text);

            await CheckLoginAsync(foundPlayer);

            return foundPlayer;
        }

        public async Task CheckLoginAsync(Player playerResult)
        {
            if (playerResult != null)
            {
                GamePlay.Player = playerResult;

                if (GamePlay.Player.Email != null)
                {
                    GameScoreCounter.CalculateSigninScore(GamePlay.Player);
                    await Database.UpdateItemAsync(GamePlay.Player);
                }
            }
        }
    }
}