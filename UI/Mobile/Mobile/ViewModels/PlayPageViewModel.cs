using MedGame.GameLogic;
using MedGame.Models;
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

        public bool IsPlaying { get; private set; }


        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public PlayPageViewModel()
        {
            Title = "test";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

            _audioService = DependencyService.Get<IAudioService>();
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


        public void StartMeditation(string levelAudioFile)
        {
            if (IsPlaying == false)
            {
                _audioService.PlayAudioFile(levelAudioFile);
                IsPlaying = true;

                GamePlay.StartMeditation();
            }
            else
            {
                IsPlaying = false;
                _audioService.StopAudioFile();
                GamePlay.StopMeditation();
                // await FileHandler.SavePlayerToFile(GamePlay.Player, GamePlay.Player.Email.MakeFullFileName());
            }
        }
    }
}