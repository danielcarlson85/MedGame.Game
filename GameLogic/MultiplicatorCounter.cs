namespace MedGame.GameLogic
{
    public class MultiplicatorCounter
    {
        public static double CalculateMultiplicator(double totalMinutesMissed, double currentMultiplicatorPoints)
        {
            //Point punishment by reduced multiplicator
            double multiplicatorTemp;
            if (totalMinutesMissed >= 1440 && totalMinutesMissed <= 2880)
            {
                multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.80);
            }
            else if (totalMinutesMissed > 2880 && totalMinutesMissed <= 4320)
            {
                multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.50);
            }
            else if (totalMinutesMissed > 4320)
            {
                multiplicatorTemp = 1;
            }

            else
            {
                multiplicatorTemp = currentMultiplicatorPoints;
            }

            return multiplicatorTemp;
        }
    }
}