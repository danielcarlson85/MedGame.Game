﻿using WSAudioApp.Droid.Implementations;
using Android.Media;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedGame.UI.Mobile.Interfaces;
using MedGame.GameLogic;

[assembly: Dependency(typeof(AudioServiceImplementation))]
namespace WSAudioApp.Droid.Implementations
{
    public class AudioServiceImplementation : IAudioService
    {
        private MediaPlayer _mediaPlayer;
        public async Task PlayAudioFile(string fileName)
        {
            _mediaPlayer = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            _mediaPlayer.Prepared += (s, e) =>
            {
                _mediaPlayer.Start();
            };
            
            _mediaPlayer.Completion += MediaPlayer_Completion;
            await _mediaPlayer.SetDataSourceAsync(fd.FileDescriptor, fd.StartOffset, fd.Length);
            _mediaPlayer.Prepare();

        }

        private void MediaPlayer_Completion(object sender, System.EventArgs e)
        {
            GamePlay.StopMeditation(true);
        }

        public void StopAudioFile()
        {
            _mediaPlayer.Stop();
        }

        public  int GetCurrentTimeStamp()
        {
            return (_mediaPlayer.CurrentPosition / 1000);
        }

        public int GetFileDurationTime()
        {
            return (_mediaPlayer.Duration / 1000);
        }
    }
}