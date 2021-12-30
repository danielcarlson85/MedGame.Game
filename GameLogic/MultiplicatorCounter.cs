namespace MedGame.GameLogic
{
    public class MultiplicatorCounter
    {
        public static double CalculateMultiplicator(double totalHoursMissed, double currentMultiplicatorPoints)
        {
            //Point punishment by reduced multiplicator
            double multiplicatorTemp;
            if (totalHoursMissed >= 24 && totalHoursMissed <= 48)
            {
                multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.80);
            }
            else if (totalHoursMissed >= 48 && totalHoursMissed <= 72)
            {
                multiplicatorTemp = (double)(currentMultiplicatorPoints * 0.50);
            }
            else if (totalHoursMissed > 72)
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