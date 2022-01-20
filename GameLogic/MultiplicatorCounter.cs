namespace MedGame.GameLogic
{
    public class MultiplicatorCounter
    {
        public static double CalculateMultiplicator(double totalMinutesMissed, double currentMultiplicatorPoints)
        {
            double multiplicatorTemp = 0;

            if (!GamePlay.Player.MultiplicatorPunishmentHasBeenMade)
            {
                //Point punishment by reduced multiplicator
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

                GamePlay.Player.MultiplicatorPunishmentHasBeenMade = true;
            }

            return multiplicatorTemp;
        }
    }
}