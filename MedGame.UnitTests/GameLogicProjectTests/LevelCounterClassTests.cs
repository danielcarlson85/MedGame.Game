using MedGame.GameLogic;
using MedGame.Models;
using Xunit;

namespace MedGame.GameLogicProject
{
    public class LevelCounterClassTests
    {
        readonly Player player = new();

        [Theory]
        [InlineData(0)]
        [InlineData(28)]
        public void CheckLevelShouldReturnBaby(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Baby, Level);
        }

        [Theory]
        [InlineData(281)]
        [InlineData(1150)]
        public void CheckLevelShouldReturnChild(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Child, Level);
        }

        [Theory]
        [InlineData(1151)]
        [InlineData(2520)]
        public void CheckLevelShouldReturnTeenager(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Teenager, Level);
        }

        [Theory]
        [InlineData(2521)]
        [InlineData(4370)]
        public void CheckLevelShouldReturnAdult(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Adult, Level);
        }

        [Theory]
        [InlineData(4371)]
        [InlineData(6720)]
        public void CheckLevelShouldReturnMaster(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Master, Level);
        }

        [Theory]
        [InlineData(6721)]
        [InlineData(9500)]
        public void CheckLevelShouldReturnMunk(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Munk, Level);
        }


        [Theory]
        [InlineData(25791)]
        [InlineData(31080)]
        public void CheckLevelShouldReturnGod(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.God, Level);
        }
    }
}
