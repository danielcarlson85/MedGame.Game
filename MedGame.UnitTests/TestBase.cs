using MedGame.Models;
using System;

namespace MedGame.UnitTests
{
    public class TestBase
    {
        internal static Player Player = new()
        {
            Email = "info@danielcarlson.net",
            Health = 100,
            Level = Levels.Baby,
            Points = 100,
            LastDateMeditated = DateTime.Now.AddDays(-1),
            Multiplicator = 1,
            TotalDaysMeditatedInRow = 1,
            TotalMinutesMissed = 0,
            TotalMinutesMeditated = 100,
            TotalMinutesMeditatedToday = 1,
        };
    }
}
