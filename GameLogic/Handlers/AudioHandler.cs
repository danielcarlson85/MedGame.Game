using MedGame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedGame.GameLogic
{
    public class AudioHandler
    {
        public static string GetCurrentAudioFile(Player player)
        {
            if (player.Level == Levels.Baby ) { return "Level1d1.mp3"; }
            if (player.Level == Levels.Child) { return "Level1d2.mp3"; }
            if (player.Level == Levels.Teenager) { return "Level1d3.mp3"; }
            if (player.Level == Levels.Adult) { return "Level1d4.mp3"; }
            if (player.Level == Levels.Master) { return "Level1d5.mp3"; }
            if (player.Level == Levels.Munk) { return "Level1d6.mp3"; }
            if (player.Level == Levels.God) { return "Level1d7.mp3"; }

            return "short.mp3";
        }
    }
}
