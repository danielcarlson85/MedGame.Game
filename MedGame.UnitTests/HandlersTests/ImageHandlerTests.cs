using MedGame.GameLogic;
using MedGame.Models;
using System.Reflection.Emit;
using Xunit;

namespace MedGame.UnitTests
{
    public class ImageHandlerTests
    {
        [Theory]
        [InlineData(23, Levels.Baby, "Sick.png")]
        [InlineData(47, Levels.Baby, "VerySad.png")]
        [InlineData(71, Levels.Baby, "Crying.png")]
        [InlineData(95, Levels.Baby, "Sad.png")]
        [InlineData(119, Levels.Baby, "Annoyed.png")]
        [InlineData(121, Levels.Baby, "Zen.png")]
        [InlineData(23, Levels.Child, "Sick.png")]
        [InlineData(47, Levels.Child, "VerySad.png")]
        [InlineData(71, Levels.Child, "Crying.png")]
        [InlineData(95, Levels.Child, "Sad.png")]
        [InlineData(119, Levels.Child, "Annoyed.png")]
        [InlineData(121, Levels.Child, "Zen.png")]
        [InlineData(23, Levels.Teenager, "Sick.png")]
        [InlineData(47, Levels.Teenager,"VerySad.png")]
        [InlineData(71, Levels.Teenager,"Crying.png")]
        [InlineData(95, Levels.Teenager,"Sad.png")]
        [InlineData(119, Levels.Teenager, "Annoyed.png")]
        [InlineData(121, Levels.Teenager, "Zen.png")]
        [InlineData(23, Levels.Adult, "Sick.png")]
        [InlineData(47, Levels.Adult,"VerySad.png")]
        [InlineData(71, Levels.Adult,"Crying.png")]
        [InlineData(95, Levels.Adult,"Sad.png")]
        [InlineData(119, Levels.Adult, "Annoyed.png")]
        [InlineData(121, Levels.Adult, "Zen.png")]
        public void GetTamagotchiImage_Dependent_on_health_and_level_Baby(int health, Levels level, string imageName)
        {
            Player player = new() { Health = health, Level = level };
            var result = ImageHandler.GetTamagotchiImage(player);
            var fullImageName = level + "_" + imageName;
            Assert.Equal(fullImageName, result);
        }

        [Theory]
        [InlineData(23, "healthmeterdead.png")]
        [InlineData(47, "healthmeterterminallyill.png")]
        [InlineData(71, "healthmetersick.png")]
        [InlineData(95, "healthmeterangry.png")]
        [InlineData(119, "healthmeterirritated.png")]
        [InlineData(121, "healthmeterzen.png")]
        public void GetHealthMeter(int health, string imageName)
        {
            Player player = new() { Health = health };
            var result = ImageHandler.GetHealthMeter(player);
            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(1, Levels.Baby, "progressMeter0.png")]
        [InlineData(27, Levels.Baby, "progressMeter0.png")]
        [InlineData(28, Levels.Baby, "progressMeter10.png")]
        [InlineData(55, Levels.Baby, "progressMeter10.png")]
        [InlineData(56, Levels.Baby, "progressMeter20.png")]
        [InlineData(83, Levels.Baby, "progressMeter20.png")]
        [InlineData(84, Levels.Baby, "progressMeter30.png")]
        [InlineData(111, Levels.Baby, "progressMeter30.png")]
        [InlineData(112, Levels.Baby, "progressMeter40.png")]
        [InlineData(139, Levels.Baby, "progressMeter40.png")]
        [InlineData(140, Levels.Baby, "progressMeter50.png")]
        [InlineData(167, Levels.Baby, "progressMeter50.png")]
        [InlineData(168, Levels.Baby, "progressMeter60.png")]
        [InlineData(195, Levels.Baby, "progressMeter60.png")]
        [InlineData(196, Levels.Baby, "progressMeter70.png")]
        [InlineData(223, Levels.Baby, "progressMeter70.png")]
        [InlineData(224, Levels.Baby, "progressMeter80.png")]
        [InlineData(251, Levels.Baby, "progressMeter80.png")]
        [InlineData(252, Levels.Baby, "progressMeter90.png")]
        [InlineData(279, Levels.Baby, "progressMeter90.png")]
        [InlineData(280, Levels.Baby, "progressMeter100.png")]
        [InlineData(281, Levels.Baby, "progressMeter100.png")]

        public void GetProgressBarImage(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points , Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }
    }
}