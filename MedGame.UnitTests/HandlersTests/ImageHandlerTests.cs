using MedGame.GameLogic;
using MedGame.Models;
using System.Reflection.Emit;
using Xunit;

namespace MedGame.UnitTests
{
    public class ImageHandlerTests
    {
        [Theory]
        [InlineData(23, Levels.Baby, EmotionImagesConstants.Angry)]
        [InlineData(47, Levels.Baby, EmotionImagesConstants.VerySad)]
        [InlineData(71, Levels.Baby, EmotionImagesConstants.Irritated)]
        [InlineData(95, Levels.Baby, EmotionImagesConstants.Sad)]
        [InlineData(119, Levels.Baby, EmotionImagesConstants.Annoyed)]
        [InlineData(121, Levels.Baby, EmotionImagesConstants.Zen)]
        [InlineData(23, Levels.Child, EmotionImagesConstants.Angry)]
        [InlineData(47, Levels.Child, EmotionImagesConstants.VerySad)]
        [InlineData(71, Levels.Child, EmotionImagesConstants.Irritated)]
        [InlineData(95, Levels.Child, EmotionImagesConstants.Sad)]
        [InlineData(119, Levels.Child, EmotionImagesConstants.Annoyed)]
        [InlineData(121, Levels.Child, EmotionImagesConstants.Zen)]
        [InlineData(23, Levels.Teenager, EmotionImagesConstants.Angry)]
        [InlineData(47, Levels.Teenager, EmotionImagesConstants.VerySad)]
        [InlineData(71, Levels.Teenager, EmotionImagesConstants.Irritated)]
        [InlineData(95, Levels.Teenager, EmotionImagesConstants.Sad)]
        [InlineData(119, Levels.Teenager, EmotionImagesConstants.Annoyed)]
        [InlineData(121, Levels.Teenager, EmotionImagesConstants.Zen)]
        [InlineData(23, Levels.Adult, EmotionImagesConstants.Angry)]
        [InlineData(47, Levels.Adult, EmotionImagesConstants.VerySad)]
        [InlineData(71, Levels.Adult, EmotionImagesConstants.Irritated)]
        [InlineData(95, Levels.Adult, EmotionImagesConstants.Sad)]
        [InlineData(119, Levels.Adult, EmotionImagesConstants.Annoyed)]
        [InlineData(121, Levels.Adult, EmotionImagesConstants.Zen)]
        public void GetTamagotchiImage_Dependent_on_health_and_level_Baby(int health, Levels level, string imageName)
        {
            Player player = new() { Health = health, Level = level };
            var result = ImageHandler.GetTamagotchiImage(player);
            var fullImageName = level + imageName;
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
        [InlineData(0, Levels.Baby, "progressMeter0.png")]
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
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }
    }
}