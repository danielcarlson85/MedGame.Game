using MedGame.GameLogic;
using MedGame.Mobile.Services;
using MedGame.Models;
using MedGame.UI.Mobile.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.ViewModels
{
    public class PlayPageViewModel : BaseViewModel
    {
        private readonly IAudioService _audioService;
        public readonly PlayerDatabase _database;

        public bool IsPlaying { get; private set; }

        public PlayPageViewModel()
        {
            Title = "test";

            _audioService = DependencyService.Get<IAudioService>();
            _database = PlayerDatabase.Instance.GetAwaiter().GetResult();

        }

        public async void StartOrStopMeditationAsync()
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;
                await StartMeditation();
            }
            else
            {
                StopMeditation();
                IsPlaying = false;
            }
        }

        private async Task StartMeditation()
        {
            var currentAudioFile = AudioHandler.GetCurrentAudioFile(GamePlay.Player);
            await _audioService.PlayAudioFile(currentAudioFile);

            GamePlay.StartMeditation();
        }

        public async void StopMeditation()
        {
            var timestamp = _audioService.GetCurrentTimeStamp();
            var filelength = _audioService.GetFileDurationTime();

            var hasMeditatedEnugh = TimeCounters.HasMeditatedEnoughTime(timestamp, filelength);

            //Show dialogbox of question if they want to cancel the meditation with/without points


            _audioService.StopAudioFile();
            GamePlay.StopMeditation();
            await _database.UpdateItemAsync(GamePlay.Player);
        }

       

        public void UpdateUI()
        {
            GameScoreCounter.CalculateSigninScore(GamePlay.Player);
        }
    }
}