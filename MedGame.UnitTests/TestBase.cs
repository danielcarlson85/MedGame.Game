using MedGame.Models;
using System;

namespace MedGame.UnitTests
{
    public class TestBase
    {
        public static Player player = new Player()
        {
            Email = "info@danielcarlson.net",
            Health = 100,
            Level = Levels.Baby,
            Points = 100,
            LastDateMeditated = OnlineDateTime.Now.AddDays(-1),
            Multiplicator = 1,
            TotalDaysMeditatedInRow = 1,
            TotalMinutesMissed = 0,
            TotalMinutesMeditated = 100,
            TotalMinutesMeditatedToday = 1,
        };
    }
}
