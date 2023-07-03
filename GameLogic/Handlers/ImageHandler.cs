using MedGame.Models;
using System;
using System.Collections.Generic;

namespace MedGame.GameLogic
{
    public class ImageHandler
    {
        public static string GetTamagotchiImage(Player player)
        {
            string tamagotchiImage = string.Empty;

            if (player.Health < 24 && player.Health >= 0)
            {
                tamagotchiImage = player.Level + "_Dead.png";
            }

            else if (player.Health < 48 && player.Health >= 24)
            {
                tamagotchiImage = player.Level + "_Angry.png";
            }

            else if (player.Health < 72 && player.Health >= 48)
            {
                tamagotchiImage = player.Level + "_Annoyed.png";
            }

            else if (player.Health < 96 && player.Health >= 72)
            {
                tamagotchiImage = player.Level + "_VerySad.png";
            }

            else if (player.Health < 120 && player.Health >= 96)
            {
                tamagotchiImage = player.Level + "_Sad.png";
            }

            else
            {
                tamagotchiImage = player.Level + "_Happy.png";
            }

            return tamagotchiImage;
        }

        public static string GetHealthMeter(Player player)
        {
            string healthMeterImage = string.Empty;

            if (player.Health < 24 && player.Health >= 0)
            {
                healthMeterImage = "healthmeterdead.png";
            }

            if (player.Health < 48 && player.Health >= 24)
            {
                healthMeterImage = "healthmeterterminallyill.png";
            }

            if (player.Health < 72 && player.Health >= 48)
            {
                healthMeterImage = "healthmetersick.png";
            }

            if (player.Health < 96 && player.Health >= 72)
            {
                healthMeterImage = "healthmeterangry.png";

            }

            if (player.Health < 120 && player.Health >= 96)
            {
                healthMeterImage = "healthmeterirritated.png";

            }

            if (player.Health >= 120)
            {
                healthMeterImage = "healthmeterzen.png";
            }

            return healthMeterImage;
        }

        public static string GetProgressBarImage(Player player)
        {
            var levelPictures = new Dictionary<Levels, Dictionary<(int min, int max), string>>
            {
                [Levels.Baby] = new Dictionary<(int min, int max), string>
            {
                { (0, 27), "progressMeter0.png" },
                { (28, 55), "progressMeter10.png" },
                { (56, 83), "progressMeter20.png" },
                { (84, 111), "progressMeter30.png" },
                { (112, 139), "progressMeter40.png" },
                { (140, 167), "progressMeter50.png" },
                { (168, 195), "progressMeter60.png" },
                { (196, 223), "progressMeter70.png" },
                { (224, 251), "progressMeter80.png" },
                { (252, 279), "progressMeter90.png" },
                { (280, 300), "progressMeter100.png" }
            
        },
                [Levels.Child] = new Dictionary<(int min, int max), string>
            {
                { ((int)Levels.Baby +0,   (int)Levels.Baby+115), "progressMeter0.png" },        // upp till 0- 10 % av child enum value + baby enum value = 280         1150 * 0,1 = 115
                { ((int)Levels.Baby +116, (int)Levels.Baby+230), "progressMeter10.png" },       //  upp till 10- 20 % av child enum value + baby enum value = 230       1150 * 0,2 = 230
                { ((int)Levels.Baby +231, (int)Levels.Baby+345), "progressMeter20.png" },       // etc
                { ((int)Levels.Baby +346, (int)Levels.Baby+460), "progressMeter30.png" },
                { ((int)Levels.Baby +461, (int)Levels.Baby+575), "progressMeter40.png" },
                { ((int)Levels.Baby +576, (int)Levels.Baby+690), "progressMeter50.png" },
                { ((int)Levels.Baby +691, (int)Levels.Baby+805), "progressMeter60.png" },
                { ((int)Levels.Baby +806, (int)Levels.Baby+920), "progressMeter70.png" },
                { ((int)Levels.Baby +921, (int)Levels.Baby+1135), "progressMeter80.png" },
                { ((int)Levels.Baby +1136,(int)Levels.Baby+ 1150), "progressMeter90.png" },
                    }
            };

            if (levelPictures.TryGetValue(player.Level, out var rangePictureMap))
            {
                foreach (var kvp in rangePictureMap)
                {
                    var range = kvp.Key;
                    var picture = kvp.Value;

                    if (player.Points >= range.min && player.Points <= range.max)
                    {
                        return picture;
                    }
                }
            }

            return "progressMeter100.png";
        }
    }
}
