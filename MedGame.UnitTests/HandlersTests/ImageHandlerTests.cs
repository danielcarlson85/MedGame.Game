using MedGame.GameLogic;
using MedGame.Models;
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
        [InlineData(1, Levels.Baby, ProgressMeterConstants.Zero)]
        [InlineData(28, Levels.Baby, ProgressMeterConstants.Ten)]
        [InlineData(56, Levels.Baby, ProgressMeterConstants.Twenty)]
        [InlineData(84, Levels.Baby, ProgressMeterConstants.Thirty)]
        [InlineData(112, Levels.Baby, ProgressMeterConstants.Forty)]
        [InlineData(140, Levels.Baby, ProgressMeterConstants.Fifty)]
        [InlineData(168, Levels.Baby, ProgressMeterConstants.Sixty)]
        [InlineData(196, Levels.Baby, ProgressMeterConstants.Seventy)]
        [InlineData(224, Levels.Baby, ProgressMeterConstants.Eighty)]
        [InlineData(280, Levels.Baby, ProgressMeterConstants.Ninety)]

        public void GetProgressBarImageForBaby(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(281, Levels.Child, ProgressMeterConstants.Zero)]
        [InlineData(715, Levels.Child, ProgressMeterConstants.Fifty)]
        [InlineData(367, Levels.Child, ProgressMeterConstants.Ten)]
        [InlineData(1063, Levels.Child, ProgressMeterConstants.Ninety)]
        [InlineData(454, Levels.Child, ProgressMeterConstants.Twenty)]

        public void GetProgressBarImageForChild(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(1151, Levels.Teenager, ProgressMeterConstants.Zero)]
        [InlineData(2519, Levels.Teenager, ProgressMeterConstants.Ninety)]

        public void GetProgressBarImageForTeenager(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }
    }
}