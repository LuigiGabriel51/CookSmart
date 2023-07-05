using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using CookSmart.Models;
using CookSmart.ToolsApp;

namespace CookSmart
{
    [Service(ForegroundServiceType = Android.Content.PM.ForegroundService.TypeDataSync)]
    public class DemoServices : Service, IServicesTeste
    {
        private Handler handler;
        private Action runnable;
        private bool isServiceRunning;

        public int BadgNumber { get; private set; }
        NotificationManager Manager;

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            if (intent.Action == "START_SERVICE")
            {
                System.Diagnostics.Debug.WriteLine("Servico iniciado");
                StartTask();
            }
            else if (intent.Action == "STOP_SERVICE")
            {
                System.Diagnostics.Debug.WriteLine("Servico Finalizado");
                StopTask();
                StopForeground(true);
                StopSelfResult(startId);
            }
            return StartCommandResult.NotSticky;
        }
        public void Start()
        {
            Intent startIntent = new Intent(Android.App.Application.Context, typeof(DemoServices));
            startIntent.SetAction("START_SERVICE");
            Android.App.Application.Context.StartService(startIntent);
        }
        public void Stop()
        {
            Intent stopIntent = new Intent(Android.App.Application.Context, typeof(DemoServices));
            stopIntent.SetAction("STOP_SERVICE");
            Android.App.Application.Context.StopService(stopIntent);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1422:Validate platform compatibility", Justification = "<Pendente>")]
        private void RegisterNotification(string data, string data2)
        {
            Manager = (GetSystemService(Context.NotificationService) as NotificationManager)!;
            createNotificationChannel(Manager);
            Notification notification = new Notification.Builder(this, "1000")
                .SetContentTitle("Receita programada")
                .SetSubText(data2)
                .SetContentText(data)
                .SetVibrate(new long[] { 1000, 1000, 1000, 1000, 1000 })
                .SetSmallIcon(Resource.Drawable.agenda)
                .SetOngoing(true)
                .Build();
            StartForeground(1, notification);
        }

        private NotificationChannel? createNotificationChannel(NotificationManager notificationMnaManager)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O) return null;

            NotificationChannel channel = new NotificationChannel("1000", "notification", NotificationImportance.Default);
            notificationMnaManager.CreateNotificationChannel(channel);

            return channel;
        }

        private void StartTask()
        {
            handler = new Handler();
            runnable = new Action(() =>
            {
                try
                {
                    if (BadgNumber == 0)
                    {
                        ReceitasProgramadas receitas = new();
                        var Receitas = receitas.List();
                        var result = Receitas.Where(receita =>
                            receita.date.Date == DateTime.Now.Date &&
                            receita.date.Hour == DateTime.Now.Hour &&
                            receita.date.Minute > DateTime.Now.Minute &&
                            DateTime.Now.Minute > receita.date.Minute - 5);
                        if (result.Count() == 0) { BadgNumber = 1; }
                        foreach (var r in result)
                        {
                            Notifications notifications = new();
                            string text = $"Você organizou uma receita deliciosa de {r.Nome}";
                            string text2 = $"para: {r.date:dd/MM/yyyy} às {r.date:HH:mm}.";
                            RegisterNotification(text, text2);
                        }
                    }
                    else
                    {
                        BadgNumber = 0;



                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na verificação das receitas programadas: {ex.Message}");
                }

                handler.PostDelayed(runnable, TimeSpan.FromSeconds(30).Milliseconds);
            });
            handler.PostDelayed(runnable, TimeSpan.FromSeconds(30).Milliseconds);

            isServiceRunning = true;
        }

        private void StopTask()
        {
            if (handler != null && isServiceRunning)
            {
                handler.RemoveCallbacks(runnable);
                isServiceRunning = false;
            }
        }
    }
}
