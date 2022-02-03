using MedGame.GameLogic;
using MedGame.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MedGame.GameLogicProject
{
    [TestClass]
    public class GameClassTests : TestBase
    {
        [TestMethod]
        public void StartMeditationShouldStartTimer()
        {
            GamePlay.StartMeditation();
            Assert.IsTrue(GamePlay.MeditationTimer.Enabled);
        }

        [TestMethod]
        public void StopMeditationShouldStopTimer()
        {
            GamePlay.StartMeditation();
            GamePlay.StopMeditation(true);
            Assert.IsFalse(GamePlay.MeditationTimer.Enabled);
        }
    }
}
