﻿using WSAudioApp.Droid.Implementations;
using Android.Media;
using System.Threading.Tasks;
using Xamarin.Forms;
using MedGame.UI.Mobile.Interfaces;

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
            await _mediaPlayer.SetDataSourceAsync(fd.FileDescriptor, fd.StartOffset, fd.Length);
            _mediaPlayer.Prepare();
        }

        public void StopAudioFile()
        {
            _mediaPlayer.Stop();
        }
    }
}