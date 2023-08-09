﻿using MedGame.GameLogic;
using MedGame.Models;
using MedGame.UnitTests;
using System;
using Xunit;

namespace MedGame.GameLogicProject
{
    public class GameScoreCounterTests : TestBase
    {
        [Fact]
        public void CalculateSignInScore()
        {
            var player = GameScoreCounter.CalculateSigninScore(TestBase.Player);

            Assert.Equal(OnlineDateTime.Now.Date, player.LastDateLoggedIn.Date);
        }

        [Fact]
        public void CalculateSigninScoreShouldUpdatePlayer()
        {
            var player = GameScoreCounter.CalculateSigninScore(TestBase.Player);
            Assert.NotNull(player);
        }

        [Fact]
        public void CalculateMissedDatesShouldReturn2()
        {
            var days = DateCounters.CalculateMissedDates(new DateTime(2019, 01, 14), new DateTime(2019, 01, 16));
            Assert.Equal(2, days);
        }

        [Fact]
        public void CalculateMissedMinutesShouldReturn2880()
        {
            var hours = TimeCounters.CalculateMissedMinutes(new DateTime(2019, 01, 12), new DateTime(2019, 01, 14));
            Assert.Equal(2880, hours);
        }
    }
}
