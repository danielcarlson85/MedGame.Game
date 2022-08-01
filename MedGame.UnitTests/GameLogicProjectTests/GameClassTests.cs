using MedGame.GameLogic;
using MedGame.UnitTests;
using Xunit;

namespace MedGame.GameLogicProject
{
    public class GameClassTests : TestBase
    {
        [Fact]
        public void StartMeditationShouldStartTimer()
        {
            GamePlay.StartMeditation(true);
        }

        [Fact]
        public void StopMeditationShouldStopTimer()
        {
            GamePlay.StopMeditation(true);
        }
    }
}
