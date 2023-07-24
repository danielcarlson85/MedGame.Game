using System.Threading.Tasks;

namespace MedGame.UI.Mobile.Interfaces
{
    public interface IAudioService
    {
        int GetCurrentTimeStampInSeconds();
        int GetFileDurationTimeInMinutes();
        Task PlayAudioFile(string fileName);
        void StopAudioFile();
    }
}
