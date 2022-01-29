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
    public class StepCounterViewModel : BaseViewModel
    {
        private readonly IAudioService _audioService;
        public readonly PlayerDatabase _database;

        public bool IsPlaying { get; private set; }

        public StepCounterViewModel()
        {
            Title = "test";

            _audioService = DependencyService.Get<IAudioService>();
            _database = PlayerDatabase.Instance.GetAwaiter().GetResult();

        }

        string stepCounterLabel = string.Empty;
        public string StepCounterLabel
        {
            get { return stepCounterLabel; }
            set { SetProperty(ref stepCounterLabel, value); }
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


        public async Task StartOrStopMeditationAsync()
        {
            if (IsPlaying == false)
            {
                var currentAudioFile = AudioHandler.GetCurrentAudioFile(GamePlay.Player);

                await _audioService.PlayAudioFile(currentAudioFile);
                IsPlaying = true;

                GamePlay.StartMeditation();
            }
            else
            {
                IsPlaying = false;
                _audioService.StopAudioFile();
                GamePlay.StopMeditation();

                await _database.UpdateItemAsync(GamePlay.Player);
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