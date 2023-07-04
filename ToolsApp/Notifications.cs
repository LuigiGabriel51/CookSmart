using Plugin.LocalNotification;


namespace CookSmart.ToolsApp
{
    internal class Notifications
    {

        public async void NotifyScheduleCooking(DateTime schedule, string text)
        {
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
    }
}
