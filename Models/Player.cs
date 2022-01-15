using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedGame.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Levels Level { get; set; } = Levels.Baby;
        public double Points { get; set; } = 0;
        public DateTime LastDateMeditated { get; set; } = DateTime.Now;
        public double Health { get; set; } = 72;
        public double Multiplicator { get; set; } = 1;
        public bool PunishmentHasBeenMade { get; set; } = false;
        public string HttpResult { get; set; } = string.Empty;
        public string PlayerMessage { get; set; } = string.Empty;
        public double TotalMinutesMeditated { get; set; } = 0;
        public double TotalMinutesMeditatedToday { get; set; } = 0;
        public double TotalDaysMeditatedInRow { get; set; } = 1;
        public double TotalHoursMissed { get; set; } = 0;
        public double TotalMinutesMeditatedNow { get; set; } = 0;
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
    }
}