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
            var hasMeditatedEnough = TimeCounters.HasMeditatedEnoughTime(_audioService.GetCurrentTimeStampInMinutes(), _audioService.GetFileDurationTimeInMinutes());
            GameModels.Player.TotalMinutesMeditatedNow = _audioService.GetCurrentTimeStampInMinutes() / 60; //Change here to set to minutes (/60)
            _audioService.StopAudioFile();
            IsPlaying = false;

            StopMeditation(hasMeditatedEnough);
            await _database.UpdateItemAsync(GameModels.Player);
        }


        private async Task ShowTimestamp()
        {
            var fileDuration = DateCounters.ConvertToMinutesAndSecondsReadableTime(_audioService.GetFileDurationTimeInMinutes());

            await Task.Run(async () =>
            {
                while (IsPlaying)
                {
                    await Xamarin.Forms.Device.InvokeOnMainThreadAsync(() =>
                    {
                        var timestamp = _audioService.GetCurrentTimeStampInMinutes();
                        string time = DateCounters.ConvertToMinutesAndSecondsReadableTime(timestamp);
                        CurrentTime = $"{time} / {fileDuration}";
                        return Task.CompletedTask;
                    });

                    await Task.Delay(100);
                }

                PlayImage = "PlayButtonNew.png";
            });
        }


        public static void StopMeditation(bool hasMeditatedEnough)
        {
            if (hasMeditatedEnough)
            {
                if (DateCounters.CheckSameDate(GameModels.Player))
                {
                    GameModels.Player = GameScoreCounter.CalculateMeditationScoreOnSameDay(GameModels.Player, GameModels.Player.TotalMinutesMeditatedNow);
                }
                else
                {
                    GameModels.Player = GameScoreCounter.CalculateMeditationScore(GameModels.Player, GameModels.Player.TotalMinutesMeditatedNow, GameModels.Player.Multiplicator);
                }
            }


            GameModels.Player.TotalDaysMeditatedInRow = DateCounters.GetTotalDaysInRow(GameModels.Player);
            GameModels.Player.MaxTotalDaysMeditatedInRow = DateCounters.GetMaxTotalDaysMeditatedInRow(GameModels.Player);
            GameModels.Player.TotalMinutesMissed = 0;
            GameModels.Player.TotalHoursMissed = 0;
            GameModels.Player.TotalMinutesMeditatedNow = 0;
            GameModels.Player.TotalMinutesMeditated = 0;
            GameModels.Player.Level = LevelCounter.CheckLevel(GameModels.Player.Points);
            GameModels.Player.PunishDay1 = false;
            GameModels.Player.PunishDay2 = false;
            GameModels.Player.PunishDay3 = false;
            GameModels.Player.PunishDay4 = false;
        }
    }
}