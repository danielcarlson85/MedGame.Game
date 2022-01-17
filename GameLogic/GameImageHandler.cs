﻿using MedGame.Models;

namespace MedGame.GameLogic
{
    public class GameImageHandler
    {
        public static string GetHealthMeter(Player player)
        {
            string healthMeterImage = string.Empty;

            if (player.Health <= 144 && player.Health >= 120)
            {
                healthMeterImage = "healthmeterzen.png";
            }

            if (player.Health < 120 && player.Health > 96)
            {
                healthMeterImage = "healthmeterirritated.png";

            }

            if (player.Health < 96 && player.Health > 72)
            {
                healthMeterImage = "healthmeterangry.png";

            }

            if (player.Health < 72 && player.Health > 48)
            {
                healthMeterImage = "healthmetersick.png";
            }

            if (player.Health < 48 && player.Health > 24)
            {
                healthMeterImage = "healthmeterterminallyill.png";
            }
            if (player.Health < 24 && player.Health > 0)
            {
                healthMeterImage = "healthmeterdead.png";
            }

            return healthMeterImage;
        }
    }
}