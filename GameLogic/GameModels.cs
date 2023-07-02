using MedGame.Models;
using MedGame.Services;
using System;
using System.Threading;
using System.Timers;

namespace MedGame.GameLogic
{
    public class GameModels
    {
        public static Player Player = new Player();

        public static DateTime DateTimeUtc { get; set; } = OnlineDateTime.UtcNow;

    }
}