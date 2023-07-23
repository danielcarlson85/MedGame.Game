﻿using MedGame.Models;
using System;
using System.Collections.Generic;

namespace MedGame.GameLogic
{
    public class ImageHandler
    {
        public static string GetTamagotchiImage(Player player)
        {
            string tamagotchiImage;

            if (player.Health >= 0 && player.Health < 24)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.Angry;
            }

            else if (player.Health >= 24 && player.Health < 48)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.VerySad;
            }

            else if (player.Health >= 48 && player.Health < 72)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.Irritated;
            }

            else if (player.Health >= 72 && player.Health < 96)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.Sad;
            }

            else if (player.Health >= 96 && player.Health < 120)
            {
                tamagotchiImage = player.Level + EmotionImagesConstants.Annoyed;
            }

            else
                tamagotchiImage = player.Level + EmotionImagesConstants.Zen;

            return tamagotchiImage;
        }

        public static string GetHealthMeter(Player player)
        {
            string healthMeterImage = string.Empty;

            if (player.Health < 0)
            {
                player.Health = 0;
            }

            if (player.Health >= 0 && player.Health < 24)
            {
                healthMeterImage = HealthMeterConstants.Dead;
            }

            if (player.Health >= 24 && player.Health < 48)
            {
                healthMeterImage = HealthMeterConstants.TerminallyIll;
            }

            if (player.Health >= 48 && player.Health < 72)
            {
                healthMeterImage = HealthMeterConstants.Sick;
            }

            if (player.Health >= 72 && player.Health < 96)
            {
                healthMeterImage = HealthMeterConstants.Angry;

            }

            if (player.Health >= 96 && player.Health < 120)
            {
                healthMeterImage = HealthMeterConstants.Irritated;

            }

            if (player.Health >= 120)
            {
                healthMeterImage = HealthMeterConstants.Zen;
            }

            return healthMeterImage;
        }

        static Levels GetPreviousEnumValue(Levels value)
        {
            Levels[] enumValues = (Levels[])Enum.GetValues(typeof(Levels));
            int currentIndex = Array.IndexOf(enumValues, value);
            if (currentIndex == 0)
                return value;
            return enumValues[currentIndex - 1];
        }

        static Levels GetNextEnumValue(Levels value)
        {
            Levels[] enumValues = (Levels[])Enum.GetValues(typeof(Levels));
            int currentIndex = Array.IndexOf(enumValues, value);
            return enumValues[currentIndex + 1];
        }


        public static string GetProgressBarImage(Player player)
        {
            var currentLevel = player.Level;
            var nextLevel = GetNextEnumValue(player.Level);

            var min = (int)currentLevel;
            var max = (int)nextLevel;



            double tenPercentValue = min + 0.1 * (max - min);
            double twentyPercentValue = min + 0.2 * (max - min);
            double thirtyPercentValue = min + 0.3 * (max - min);
            double fortyPercentValue = min + 0.4 * (max - min);
            double fiftyPercentValue = min + 0.5 * (max - min);
            double sixtyPercentValue = min + 0.6 * (max - min);
            double seventyPercentValue = min + 0.7 * (max - min);
            double eightyPercentValue = min + 0.8 * (max - min);
            double ninetyPercentValue = min + 0.9 * (max - min);
            double oneHundredPercentValue = min + 1 * (max - min);

            Dictionary<Levels, Dictionary<(double min, double max), string>> levelPictures = new Dictionary<Levels, Dictionary<(double min, double max), string>>
            {
                [player.Level] = new Dictionary<(double min, double max), string>
        {
            { (min, tenPercentValue - 1), ProgressMeterConstants.Zero },
            { (tenPercentValue, twentyPercentValue -1), ProgressMeterConstants.Ten },
            { (twentyPercentValue, thirtyPercentValue-1), ProgressMeterConstants.Twenty },
            { (thirtyPercentValue, fortyPercentValue-1), ProgressMeterConstants.Thirty},
            { (fortyPercentValue, fiftyPercentValue-1), ProgressMeterConstants.Forty },
            { (fiftyPercentValue, sixtyPercentValue-1), ProgressMeterConstants.Fifty },
            { (sixtyPercentValue, seventyPercentValue-1), ProgressMeterConstants.Sixty },
            { (seventyPercentValue, eightyPercentValue-1),ProgressMeterConstants.Seventy },
            { (eightyPercentValue, ninetyPercentValue-1), ProgressMeterConstants.Eighty },
            { (ninetyPercentValue, oneHundredPercentValue-1), ProgressMeterConstants.Ninety },

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

            return "default_picture.jpg";
        }
    }
}