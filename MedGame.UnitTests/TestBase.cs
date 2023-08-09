using MedGame.Mobile.Services;
using MedGame.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MedGame.UnitTests
{
    public class TestBase : IAsyncLifetime
    {
        public PlayerDatabase _database = new();

        public static Player Player { get; set; } = new();

        public async Task InitializeAsync()
        {
            Player = CreateNewPlayer();

            _database = await PlayerDatabase.Instance;
            await _database.DeleteAllItemsAsync();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public Player CreateNewPlayer()
        {
            return new Player()
            {
                Email = "test@test.net",
                Health = 100,
                Level = Levels.Baby,
                Points = 100,
                LastDateMeditated = OnlineDateTime.Now.AddDays(-1),
                Multiplicator = 1,
                TotalDaysMeditatedInRow = 1,
                TotalMinutesMissed = 0,
                TotalMinutesMeditated = 100,
                TotalMinutesMeditatedToday = 1,
                Address = "Testvägen1",
                Birthday = "testBirthday",
                Gender = "TestGender",
                Password = "pass",
                PunishDay1 = true,
                PunishDay2 = true,
                PunishDay3 = true,
                PunishDay4 = true,
                PunishDay5 = true,
                HttpResult = "test",
                Id = new Random().Next(0, 100000),
                LastDateLoggedIn = OnlineDateTime.Now,
                MaxTotalDaysMeditatedInRow = 1,
                Name = "Test",
                PlayerMessage = "test",
                ProgressMeter = "test",
                TotalHoursMissed = 0,
                TotalMinutesMeditatedNow = 0
            };
        }
    }
}