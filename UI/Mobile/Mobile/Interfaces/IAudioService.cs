using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedGame.UI.Mobile.Interfaces
{
    public interface IAudioService
    {
        void PlayAudioFile(string fileName);
        void StopAudioFile();
    }
}
