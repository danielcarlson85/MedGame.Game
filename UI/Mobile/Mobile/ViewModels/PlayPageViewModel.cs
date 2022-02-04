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
        private readonly PlayerDatabase _database;
        public bool IsPlaying = false;

        public PlayPageViewModel()
        {
            _audioService = DependencyService.Get<IAudioService>();
            _database = PlayerDatabase.Instance.GetAwaiter().GetResult();
        }

        public async void StartOrStopMeditationAsync(ImageButton imageButton)
        {
            if (!IsPlaying)
            {
                await StartMeditation(imageButton);
            }
            else
            {
                //Change this to false when in production
                await StopMeditation(imageButton, true);
            }
        }

        private async Task StartMeditation(ImageButton imageButton)
        {
            imageButton.Source = "pausebutton.png";
            IsPlaying = true;
            var currentAudioFile = AudioHandler.GetCurrentAudioFile(GamePlay.Player);
            await _audioService.PlayAudioFile(currentAudioFile);

            GamePlay.StartMeditation();
        }

        public async Task StopMeditation(ImageButton imageButton, bool isPlayerGettingPoints)
        {
            imageButton.Source = "PlayButtonNew.png";
            _audioService.StopAudioFile();
            IsPlaying = false;

            GamePlay.StopMeditation(isPlayerGettingPoints);
            await _database.UpdateItemAsync(GamePlay.Player);
        }
    }
}