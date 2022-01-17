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
        private IAudioService _audioService;
        public PlayerDatabase Database { get; }

        public bool IsPlaying { get; private set; }

        public PlayPageViewModel()
        {
            Title = "test";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

            _audioService = DependencyService.Get<IAudioService>();
            Database = PlayerDatabase.Instance.GetAwaiter().GetResult();

        }


        //public ICommand OpenWebCommand { get; }

        public void PlayOrStop()
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
            }
            else
            {
                IsPlaying = false;
            }
        }


        public async Task StartOrStopMeditationAsync(string levelAudioFile)
        {
            if (IsPlaying == false)
            {
                await _audioService.PlayAudioFile(levelAudioFile);
                IsPlaying = true;

                GamePlay.StartMeditation();
            }
            else
            {
                IsPlaying = false;
                _audioService.StopAudioFile();
                GamePlay.StopMeditation();

                await Database.UpdateItemAsync(GamePlay.Player);
            }
        }

        public void StopMeditation()
        {
            if (IsPlaying)
            {
                IsPlaying = false;
                _audioService.StopAudioFile();
                GamePlay.StopMeditation();
            }
        }

        public void UpdateUI()
        {
            GameScoreCounter.CalculateSigninScore(GamePlay.Player);
        }
    }
}