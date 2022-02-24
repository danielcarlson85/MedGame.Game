using MedGame.GameLogic;
using MedGame.Models;
using Xunit;

namespace MedGame.UnitTests
{
    public class AudioHandlerTests
    {
        [Theory]
        [InlineData(Levels.Baby)]
        [InlineData(Levels.Child)]
        [InlineData(Levels.Teenager)]
        [InlineData(Levels.Pupil)]
        [InlineData(Levels.YoungAdult)]
        [InlineData(Levels.Adult)]
        [InlineData(Levels.OldAdult)]
        [InlineData(Levels.Old)]
        [InlineData(Levels.Master)]
        [InlineData(Levels.Munk)]
        [InlineData(Levels.God)]
        public void GetCurrentAudioFile_Test(Levels levels)
        {
            Player player = new() { Level = levels };
            var result = AudioHandler.GetCurrentAudioFile(player);

            Assert.StartsWith("Level", result);
        }
    }
}