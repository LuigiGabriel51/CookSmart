using Microsoft.Maui.Devices;
using Plugin.LocalNotification;


namespace CookSmart.ToolsApp
{
    internal class Notifications
    {
        public async void NotifyScheduleCooking(DateTime schedule, string text)
        {
            if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false ||
                Battery_EnergySaverStatusChanged())
            {
                //add Um Launcher para as configs
                await LocalNotificationCenter.Current.RequestNotificationPermission();
            }

            var notification = new NotificationRequest
            {
                NotificationId = 100,
                Title = "Agenda de Receitas",
                Description = text,
                Schedule =
            {
                NotifyTime = schedule,
            }
            };
            await LocalNotificationCenter.Current.Show(notification);
        }
        private bool Battery_EnergySaverStatusChanged()
        {
            // Update the variable based on the state
            return Battery.Default.EnergySaverStatus == EnergySaverStatus.On;    
        }

    }
}
