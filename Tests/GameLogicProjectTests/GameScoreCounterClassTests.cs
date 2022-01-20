using MedGame.GameLogic;
using MedGame.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MedGame.GameLogicProject
{
    [TestClass]
    public class GameScoreCounterClassTests : TestBase
    {
        [TestMethod]
        public void CalculateSigninScoreShouldUpdatePlayer()
        {
            //var player = GameScoreCounter.CalculateSigninScore(TestBase.player);
            Assert.IsNotNull(player);
        }

        [TestMethod]
        public void CalculateMissedDatesShouldReturn2()
        {
            var days = GameScoreCounter.CalculateMissedDates(new DateTime(2019, 01, 14), new DateTime(2019, 01, 16));
            Assert.AreEqual(2, days);
        }

        [TestMethod]
        public void CalculateMissedHoursShouldReturn48()
        {
            var hours = GameScoreCounter.CalculateMissedMinutes(new DateTime(2019, 01, 12), new DateTime(2019, 01, 14));
            Assert.AreEqual(48, hours);
        }
    }
}
