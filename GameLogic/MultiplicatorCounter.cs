using System;

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
                GamePlay.Player.LastTimeMultiplicatorPunishmentWasMade = DateTime.Now;
            }

            return multiplicatorTemp;
        }

        private void CalculateMultiplicatorPunishmentTime()
        {

        }



        public static double CalculateHealth(double totalMinutesMissed, double currentHealth)
        {
            double multiplicatorTemp = 0;

            if (!GamePlay.Player.HealthPunishmentHasBeenMade)
            {
                //Point punishment by reduced multiplicator
                if (totalMinutesMissed >= 1440 && totalMinutesMissed <= 2880)
                {
                    multiplicatorTemp = (double)(currentHealth - 1);
                }
                else if (totalMinutesMissed > 2880 && totalMinutesMissed <= 4320)
                {
                    multiplicatorTemp = (double)(currentHealth * 0.50);
                }
                else if (totalMinutesMissed > 4320)
                {
                    multiplicatorTemp = 1;
                }

                else
                {
                    multiplicatorTemp = currentHealth;
                }

                GamePlay.Player.MultiplicatorPunishmentHasBeenMade = true;
            }

            return multiplicatorTemp;
        }
    }
}