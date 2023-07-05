using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;

namespace CookSmart
{
    public class ScheduleCookService : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Console.WriteLine("Alarme");
            string data = intent.GetStringExtra("data");
            RegisterNotification(data);
        }

        private void RegisterNotification(string data)
        {
            NotificationCompat.Builder builder = new NotificationCompat.Builder(Android.App.Application.Context, channelId: "channel01")
                .SetSmallIcon(Resource.Drawable.cozinhando)
                .SetContentTitle("Receita Programada")
                .SetContentText(data)
                .SetPriority(NotificationCompat.PriorityDefault);

            NotificationManagerCompat notification = NotificationManagerCompat.From(Android.App.Application.Context);
            notification.Notify(id: 1, builder.Build());
        }

        public void AddNotification(Context context, Intent intent)
        {
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, 0, intent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);

            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            long triggerTime = SystemClock.ElapsedRealtime() + 10000; // 10 segundos
            alarmManager.SetRepeating(AlarmType.RtcWakeup, triggerTime, intervalMillis: 60000, pendingIntent);

        }
    }
}
