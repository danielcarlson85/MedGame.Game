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
                healthMeterTitle = "Warning";
                healthMeterText = $"Your {player.Level} is soon dead, please meditate before that happens";
            }

            if (player.Health < 48 && player.Health >= 24)
            {
                healthMeterTitle = "Info";
                healthMeterText = $"Your {player.Level} is soon terminally sick, please meditate before that happens";
            }

            if (player.Health < 72 && player.Health >= 48)
            {
                healthMeterTitle = "Sick";
                healthMeterText = $"Your {player.Level} is soon sick, please meditate before that happens";
            }

            if (player.Health < 96 && player.Health >= 72)
            {
                healthMeterTitle = "Angry";
                healthMeterText = $"Your {player.Level} is angry, please meditate before that happens";
            }

            if (player.Health < 120 && player.Health >= 96)
            {
                healthMeterTitle = "Irritated";
                healthMeterText = $"Your {player.Level} is irritated, please meditate before that happens";
            }

            if (player.Health >= 120)
            {
                healthMeterTitle = "Feeling well";
                healthMeterText = $"Your {player.Level} is feeling well, please continue as you do";
            }

            return (healthMeterText, healthMeterTitle);
        }
    }
}
