using MedGame.GameLogic;
using MedGame.Mobile.Services;
using MedGame.UI.Mobile.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.ViewModels
{
    public class PlayPageViewModel : BaseViewModel
    {
        private readonly IAudioService _audioService;
        private readonly PlayerDatabase _database;
        public bool IsPlaying = false;

        private string playImage;
        public string PlayImage
        {
            get { return playImage; }
            set { SetProperty(ref playImage, value); }
        }

        private string currentTime;
        public string CurrentTime
        {
            get { return currentTime; }
            set { SetProperty(ref currentTime, value); }
        }

        public PlayPageViewModel()
        {
            _audioService = DependencyService.Get<IAudioService>();
            _database = PlayerDatabase.Instance.GetAwaiter().GetResult();
            PlayImage = "PlayButtonNew.png";
        }

        public async void StartOrStopMeditationAsync()
        {
            if (!IsPlaying)
            {
                await StartMeditation();
            }
            else
            {
                await StopMeditation();
            }
        }

        private async Task StartMeditation()
        {
            PlayImage = "pausebutton.png";
            IsPlaying = true;
            var currentAudioFile = AudioHandler.GetCurrentAudioFile(GamePlay.Player);
            await _audioService.PlayAudioFile(currentAudioFile);
            await ShowTimestamp();
        }

        public async Task StopMeditation()
        {
            var hasMeditatedEnough = TimeCounters.HasMeditatedEnoughTime(_audioService.GetCurrentTimeStamp(), _audioService.GetFileDurationTime());
            GamePlay.Player.TotalMinutesMeditatedNow = _audioService.GetCurrentTimeStamp() / 60; //Change here to set to minutes (/60)
            _audioService.StopAudioFile();
            IsPlaying = false;

            GamePlay.StopMeditation(hasMeditatedEnough);
            await _database.UpdateItemAsync(GamePlay.Player);
        }


        private async Task ShowTimestamp()
        {
            var fileDuration = DateCounters.ConvertToMinutesAndSecondsReadableTime(_audioService.GetFileDurationTime());

            await Task.Run(async () =>
            {
                while (IsPlaying)
                {
                    await Xamarin.Forms.Device.InvokeOnMainThreadAsync(() =>
                    {
                        var timestamp = _audioService.GetCurrentTimeStamp();
                        string time = DateCounters.ConvertToMinutesAndSecondsReadableTime(timestamp);
                        CurrentTime = $"{time} / {fileDuration}";
                        return Task.CompletedTask;
                    });

                    await Task.Delay(100);
                }
            });
        }
    }
}