using MedGame.GameLogic;
using MedGame.Models;
using Xunit;

namespace MedGame.GameLogicProject
{
    public class LevelCounterClassTests
    {

        Player player = new();

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
        [InlineData(29)]
        [InlineData(115)]
        public void CheckLevelShouldReturnChild(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Child, Level);
        }

        [Theory]
        [InlineData(116)]
        [InlineData(252)]
        public void CheckLevelShouldReturnTeenager(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Teenager, Level);
        }

        [Theory]
        [InlineData(253)]
        [InlineData(437)]
        public void CheckLevelShouldReturnPupil(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Pupil, Level);
        }

        [Theory]
        [InlineData(438)]
        [InlineData(672)]
        public void CheckLevelShouldReturnYoungAdult(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.YoungAdult, Level); 
        }

        [Theory]
        [InlineData(673)]
        [InlineData(955)]
        public void CheckLevelShouldReturnAdult(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Adult, Level);
        }

        [Theory]
        [InlineData(956)]
        [InlineData(1288)]
        public void CheckLevelShouldReturnOldAdult(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.OldAdult, Level);
        }

        [Theory]
        [InlineData(1289)]
        [InlineData(1669)]
        public void CheckLevelShouldReturnOld(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Old, Level);
        }

        [Theory]
        [InlineData(1670)]
        [InlineData(2100)]
        public void CheckLevelShouldReturnMaster(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Master, Level);
        }

        [Theory]
        [InlineData(2101)]
        [InlineData(2579)]
        public void CheckLevelShouldReturnMunk(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.Munk, Level);
        }


        [Theory]
        [InlineData(2580)]
        [InlineData(3108)]
        public void CheckLevelShouldReturnGod(int point)
        {
            player.Points = point;

            Levels Level = LevelCounter.CheckLevel(player);
            Assert.Equal(Levels.God, Level);
        }
    }
}
