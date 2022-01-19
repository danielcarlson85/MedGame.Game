using SQLite;
using System;

namespace MedGame.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Levels Level { get; set; } = Levels.Baby;
        public double Points { get; set; } = 0;
        public DateTime LastDateMeditated { get; set; } = new DateTime();
        public DateTime LastDateLoggedIn { get; set; } = new DateTime();
        public double Health { get; set; } = 72;
        public double Multiplicator { get; set; } = 1;
        public string HttpResult { get; set; } = string.Empty;
        public string PlayerMessage { get; set; } = string.Empty;
        public double TotalMinutesMeditated { get; set; } = 0;

        public static Player CreateNewPlayer()
        {
            throw new NotImplementedException();
        }

        public double TotalMinutesMeditatedToday { get; set; } = 0;
        public double TotalDaysMeditatedInRow { get; set; } = 1;
        public double TotalHoursMissed { get; set; } = 0;
        public double TotalMinutesMeditatedNow { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;

        public static Player CreateNewPlayer(string email)
        {
            return new Player()
            {
                Email = email,
                Health = 72,
                HttpResult = string.Empty,
                LastDateMeditated = DateTime.Now,
                Level = Levels.Baby,
                Multiplicator = 1,
                Password = string.Empty,
                PlayerMessage = string.Empty,
                Points = 1,
                TotalDaysMeditatedInRow = 1,
                TotalHoursMissed = 0,
                TotalMinutesMeditated = 0,
                TotalMinutesMeditatedToday = 0,
                Address = string.Empty,
                Birthday = string.Empty,
                Name = string.Empty,
                Gender = string.Empty,
                LastDateLoggedIn = DateTime.Now,
                TotalMinutesMeditatedNow = 0
            };
        }
    }


}