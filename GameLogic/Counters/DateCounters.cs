using MedGame.Models;
using System;

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
                player.TotalDaysMeditatedInRow = 1;
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

        public static string ConvertToMinutesAndSecondsReadableTime(int timestamp)
        {
            TimeSpan t = TimeSpan.FromSeconds(timestamp);
            string time = t.ToString(@"mm\:ss");
            return time;
        }
    }
}
