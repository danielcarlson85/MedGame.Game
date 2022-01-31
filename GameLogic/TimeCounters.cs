using System;

namespace MedGame.GameLogic
{
    public static class TimeCounters
    {
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
