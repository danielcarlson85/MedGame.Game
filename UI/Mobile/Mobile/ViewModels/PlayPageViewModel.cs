using MedGame.UI.Mobile.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.ViewModels
{
    public class PlayPageViewModel : BaseViewModel
    {
        private IAudioService _audioService;

        public PlayPageViewModel()
        {
            Title = "test";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

            _audioService = DependencyService.Get<IAudioService>();
        }

        public bool IsPlaying { get; private set; }

        //public ICommand OpenWebCommand { get; }

        public void PlayOrStop()
        {
            if (!IsPlaying)
            {
                _audioService.PlayAudioFile("Level1d1.mp3");
                IsPlaying = true;
            }
            else
            {
                _audioService.StopAudioFile();
                IsPlaying = false;
            }
        }
    }
}