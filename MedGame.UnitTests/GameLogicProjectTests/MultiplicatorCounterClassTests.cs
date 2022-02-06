using MedGame.GameLogic;
using System;
using Xunit;

namespace MedGame.GameLogicProject
{
    public class MultiplicatorCounterClassTests
    {
        [Fact]
        public void CalculateMissedDatesShouldReturn2()
        {
            var days = DateCounters.CalculateMissedDates(new DateTime(2019, 01, 14), new DateTime(2019, 01, 16));

            Assert.Equal(2, days);
        }

        [Fact]
        public void CalculateMissedMinutesShouldReturn2880()
        {
            var minutes = TimeCounters.CalculateMissedMinutes(new DateTime(2019, 01, 12), new DateTime(2019, 01, 14));

            Assert.Equal(2880, minutes);
        }
    }
}
