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
            GamePlay.StartMeditation();
            Assert.True(GamePlay.MeditationTimer.Enabled);
        }

        [Fact]
        public void StopMeditationShouldStopTimer()
        {
            GamePlay.StartMeditation();
            GamePlay.StopMeditation(true);
            Assert.False(GamePlay.MeditationTimer.Enabled);
        }
    }
}
