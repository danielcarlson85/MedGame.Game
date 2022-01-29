using Android;
using Android.App;
using Android.Graphics;
using AndroidX.Core.App;
using MedGame.UI.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Not.Droid.AndroidNotification))]
namespace Not.Droid
{
    public class AndroidNotification : INotification
    {
        const string channel_id = "default";
        const string channel_name = "Default";
        int notify_index = 0;

        public void Send(string title, string message)
        {
            NotificationManager manager = (NotificationManager)Android.App.Application.Context.GetSystemService(Android.App.Application.NotificationService);

            var channelNameJava = new Java.Lang.String(channel_name);
            var channel = new NotificationChannel(channel_id, channelNameJava, NotificationImportance.High)
            {
                Description = "Channel Description"
            };

            manager.CreateNotificationChannel(channel);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(Android.App.Application.Context, channel_id)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetLargeIcon(BitmapFactory.DecodeResource(Android.App.Application.Context.Resources, Resource.Drawable.IcMediaPlay))
                .SetSmallIcon(Resource.Drawable.IcMediaPlay)
                .SetPriority((int)NotificationPriority.High)
                .SetVisibility((int)NotificationVisibility.Public);
                //.SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate);

            Notification notification = builder.Build();
            manager.Notify(notify_index++, notification);
        }
    }
}