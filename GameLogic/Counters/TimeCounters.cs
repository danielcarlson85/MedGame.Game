using System;

namespace MedGame.GameLogic
{
    public static class TimeCounters
    {
        public static double CalculateMissedMinutes(DateTime lastDateMeditated, DateTime currentHour)
        {
            var totalMinutesMissed = (currentHour - lastDateMeditated).TotalMinutes;
            if (totalMinutesMissed < 0) totalMinutesMissed = 0;

            return totalMinutesMissed;
        }

        public static double CalculateMissedHours(DateTime lastDateMeditated, DateTime currentHour)
        {
            var totalHoursMissed = (currentHour - lastDateMeditated).TotalHours;
            if (totalHoursMissed < 0) { totalHoursMissed = 0; }
            return totalHoursMissed;
        }

        public static bool HasMeditatedEnoughTime(int timeMeditatedInSeconds, int fileLengthInSeconds)
        {
            var totalSecondsMeditatedInFile = fileLengthInSeconds - 10;

            if (timeMeditatedInSeconds > totalSecondsMeditatedInFile)
            {
                return true;
            }

            return false;
        }
    }
}
