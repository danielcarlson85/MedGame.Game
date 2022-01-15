using AVFoundation;
using Foundation;
using MedGame.UI.Mobile.Interfaces;
using System.IO;
using System.Threading.Tasks;
using WSAudioApp.iOS.Implementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioServiceImplementation))]
namespace WSAudioApp.iOS.Implementations
{
    public class AudioServiceImplementation : IAudioService
    {
        private AVAudioPlayer _mediaPlayer;
        public void PlayAudioFile(string fileName)
        {
            string sFilePath = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
            var url = NSUrl.FromString(sFilePath);
            var _mediaPlayer = AVAudioPlayer.FromUrl(url);
            _mediaPlayer.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
            {
                _mediaPlayer = null;
            };
            _mediaPlayer.Play();
        }

        public void StopAudioFile()
        {
            _mediaPlayer.Stop();
        }
    }
}