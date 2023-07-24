using MedGame.Models;

namespace MedGame.GameLogic.Handlers
{
    public class NotificationHandler
    {
        public static (string title, string text) GetHealthNotification(Player player)
        {
            string healthMeterText = string.Empty;
            string healthMeterTitle = string.Empty;

            if (player.Health < 24 && player.Health >= 0)
            {
                healthMeterTitle = "Angry";
                healthMeterText = $"Your {player.Level} is soon very sad, please meditate before that happens";
            }

            if (player.Health < 48 && player.Health >= 24)
            {
                healthMeterTitle = "Annoyed";
                healthMeterText = $"Your {player.Level} is soon annoyed, please meditate before that happens";
            }

            if (player.Health < 72 && player.Health >= 48)
            {
                healthMeterTitle = "Sad";
                healthMeterText = $"Your {player.Level} is soon sad, please meditate before that happens";
            }

            if (player.Health < 96 && player.Health >= 72)
            {
                healthMeterTitle = "Irritated";
                healthMeterText = $"Your {player.Level} is soon irritated, please meditate before that happens";
            }

            if (player.Health < 120 && player.Health >= 96)
            {
                healthMeterTitle = "Very sad";
                healthMeterText = $"Your {player.Level} is soon very sad, please meditate before that happens";
            }

            if (player.Health >= 120)
            {
                healthMeterTitle = "Zen";
                healthMeterText = $"Your {player.Level} is in zen, please continue as you do";
            }

            return (healthMeterText, healthMeterTitle);
        }
    }
}
