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
        public static int totalMinutesMeditatedNow = 0;
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
            var currentAudioFile = AudioHandler.GetCurrentAudioFile(GameModels.Player);
            await _audioService.PlayAudioFile(currentAudioFile);
            await ShowTimestamp();
        }

        public async Task StopMeditation()
        {
            var hasMeditatedEnough = TimeCounters.HasMeditatedEnoughTime(_audioService.GetCurrentTimeStampInSeconds(), _audioService.GetFileDurationTimeInMinutes());
            _audioService.StopAudioFile();
            IsPlaying = false;

            //SetMeditationPoints(hasMeditatedEnough);
            SetMeditationPoints(true);
            await _database.UpdateItemAsync(GameModels.Player);
        }


        private async Task ShowTimestamp()
        {
            var fileDuration = DateCounters.ConvertToMinutesAndSecondsReadableTime(_audioService.GetFileDurationTimeInMinutes());

            await Task.Run(async () =>
            {
                while (IsPlaying)
                {
                    await Device.InvokeOnMainThreadAsync(() =>
                    {
                        var timestamp = _audioService.GetCurrentTimeStampInSeconds();
                        string time = DateCounters.ConvertToMinutesAndSecondsReadableTime((int)timestamp);
                        CurrentTime = $"{time} / {fileDuration}";
                        return Task.CompletedTask;
                    });

                    await Task.Delay(1000);
                }

                PlayImage = "PlayButtonNew.png";
            });
        }


        public void SetMeditationPoints(bool hasMeditatedEnough)
        {
            GameModels.Player.TotalMinutesMeditatedNow = _audioService.GetCurrentTimeStampInSeconds();

            if (hasMeditatedEnough && DateCounters.CheckSameDate(GameModels.Player))
            {
                GameModels.Player = GameScoreCounter.CalculateMeditationScore(GameModels.Player);
            }
            else
            {
                GameModels.Player = GameScoreCounter.CalculateMeditationScoreOnSameDay(GameModels.Player);
            }


            GameModels.Player.TotalDaysMeditatedInRow = DateCounters.GetTotalDaysInRow(GameModels.Player);
            GameModels.Player.MaxTotalDaysMeditatedInRow = DateCounters.GetMaxTotalDaysMeditatedInRow(GameModels.Player);
            GameModels.Player.TotalMinutesMissed = 0;
            GameModels.Player.TotalHoursMissed = 0;
            GameModels.Player.TotalMinutesMeditatedNow = 0;
            GameModels.Player.TotalMinutesMeditated = 0;
            GameModels.Player.Level = LevelCounter.CheckLevel(GameModels.Player);
            GameModels.Player.PunishDay1 = false;
            GameModels.Player.PunishDay2 = false;
            GameModels.Player.PunishDay3 = false;
            GameModels.Player.PunishDay4 = false;
        }
    }
}