using MedGame.GameLogic;
using MedGame.Mobile.Services;
using MedGame.UI.Mobile.Interfaces;
using System.Threading.Tasks;
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

            var hasMeditatedEnough = TimeCounters.HasMeditatedEnoughTime(timestamp, filelength);

            bool result;
            if (hasMeditatedEnough)
            {
                result = await Application.Current.MainPage.DisplayAlert("Not meditated enough", "You have not meditated enough to get any points? \nDo you want to quit?", "Yes", "No", FlowDirection.LeftToRight);

                if (result)
                {
                    _audioService.StopAudioFile();
                    GamePlay.StopMeditation(false);
                }
            }
            else
            {
                result = await Application.Current.MainPage.DisplayAlert("Do you want to stop?", "Do you really want to stop the meditation?", "Yes", "No");
                if (result)
                {
                    _audioService.StopAudioFile();
                    GamePlay.StopMeditation(true);
                }
            }

            await _database.UpdateItemAsync(GamePlay.Player);
        }



        public void UpdateUI()
        {
            GameScoreCounter.CalculateSigninScore(GamePlay.Player);
        }
    }
}