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
        [InlineData(1, Levels.Zero, ProgressMeterConstants.Zero)]
        [InlineData(279, Levels.Zero, ProgressMeterConstants.Ninety)]

        public void GetProgressBarImageForBaby(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(280, Levels.Baby, ProgressMeterConstants.Zero)]
        [InlineData(715, Levels.Baby, ProgressMeterConstants.Fifty)]
        [InlineData(367, Levels.Baby, ProgressMeterConstants.Ten)]
        [InlineData(1063, Levels.Baby, ProgressMeterConstants.Ninety)]
        [InlineData(454, Levels.Baby, ProgressMeterConstants.Twenty)]

        public void Get_ProgressBarImage_For_Baby_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(1151, Levels.Child, ProgressMeterConstants.Zero)]
        [InlineData(2519, Levels.Child, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_Child_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(2520, Levels.Teenager, ProgressMeterConstants.Zero)]
        [InlineData(4369, Levels.Teenager, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_Teenager_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(4370, Levels.Pupil, ProgressMeterConstants.Zero)]
        [InlineData(6719, Levels.Pupil, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_Pupil_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(6720, Levels.YoungAdult, ProgressMeterConstants.Zero)]
        [InlineData(9549, Levels.YoungAdult, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_YoungAdult_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(9550, Levels.Adult, ProgressMeterConstants.Zero)]
        [InlineData(12879, Levels.Adult, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_Adult_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(12880, Levels.OldAdult, ProgressMeterConstants.Zero)]
        [InlineData(16689, Levels.OldAdult, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_OldAdult_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }


        [Theory]
        [InlineData(16690, Levels.Old, ProgressMeterConstants.Zero)]
        [InlineData(20999, Levels.Old, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_Old_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(21000, Levels.Master, ProgressMeterConstants.Zero)]
        [InlineData(25789, Levels.Master, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_Master_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(25790, Levels.Munk, ProgressMeterConstants.Zero)]
        [InlineData(30999, Levels.Munk, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_Munk_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }

        [Theory]
        [InlineData(31080, Levels.God, ProgressMeterConstants.Zero)]
        [InlineData(32999, Levels.God, ProgressMeterConstants.Ninety)]

        public void Get_ProgressBarImage_For_God_Test(int points, Levels level, string imageName)
        {
            Player player = new() { Points = points, Level = level };
            var result = ImageHandler.GetProgressBarImage(player);

            Assert.Equal(imageName, result);
        }
    }
}