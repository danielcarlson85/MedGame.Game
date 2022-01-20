using MedGame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedGame.GameLogic
{
    public class DateCounters
    {
        public static int GetTotalDaysInRow(Player player)
        {
            if (player.LastDateMeditated.Date == DateTime.Now.Date.AddDays(-1))
            {
                player.TotalDaysMeditatedInRow++;
            }
            else
            {
                player.TotalDaysMeditatedInRow = 0;
            }

            return player.TotalDaysMeditatedInRow;
        }

        public static bool CheckSameDate(Player player)
        {
            if (player.LastDateMeditated.Date == DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }

        public static int GetMaxTotalDaysMeditatedInRow(Player player)
        {
            if (player.TotalDaysMeditatedInRow > player.MaxTotalDaysMeditatedInRow)
            {
                player.MaxTotalDaysMeditatedInRow = player.TotalDaysMeditatedInRow;
            }

            return player.MaxTotalDaysMeditatedInRow;
        }

        public static int CalculateMissedDates(DateTime LastDateMeditated, DateTime todaysDate)
        {
            int totalDaysMissed = (todaysDate.Date - LastDateMeditated.Date).Days;
            if (totalDaysMissed <= 0) return 0;

            return totalDaysMissed;
        }

        public static double CalculateMissedMinutes(DateTime lastDateMeditated, DateTime currentHour)
        {
            var totalMinutesMissed = (currentHour - lastDateMeditated).TotalMinutes;
            return totalMinutesMissed;
        }

        public static double CalculateMissedHours(DateTime lastDateMeditated, DateTime currentHour)
        {
            var totalHoursMissed = (currentHour - lastDateMeditated).TotalHours;
            return totalHoursMissed;
        }
    }
}
