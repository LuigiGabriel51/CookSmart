using Android.App;
using Android.Content;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookSmart.Models;
using Java.Sql;
using CookSmart.ToolsApp;

namespace CookSmart.Platforms.Android
{
    [Service]
    public class MyBackgroundService : Service
    {
        private int BadgNumber = 0;
        private Handler handler;
        private Action runnable;
        private int interval = 30000; // Intervalo em milissegundos para realizar a verificação (5 segundos no exemplo)

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            handler = new Handler();
            runnable = new Action(DoBackgroundWork);
            handler.PostDelayed(runnable, interval);

            return StartCommandResult.RedeliverIntent;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if (handler != null && runnable != null)
            {
                handler.RemoveCallbacks(runnable);
            }
        }

        private void DoBackgroundWork()
        {
            
            try
            {
                // Realiza a verificação aqui
                if (BadgNumber == 0)
                {
                    ReceitasProgramadas receitas = new();
                    var Receitas = receitas.List();
                    var result = Receitas.Where(receita =>
                    receita.date.Date == DateTime.Now.Date && receita.date.Hour == DateTime.Now.Hour
                    && receita.date.Minute == DateTime.Now.Minute
                    );

                    foreach (var r in result)
                    {
                        Notifications notifications = new();
                        string text = $"Você organizou uma receita deliciosa de {r.Nome} para hoje, no dia {r.date:dd/MM/yyyy} às {r.date:HH:mm}.";
                        notifications.NotifyScheduleCooking(r.date+TimeSpan.FromSeconds(10), text);
                        BadgNumber++;
                    }
                }
                else BadgNumber = 0;           
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na verificação das receitas programadas: {ex.Message}");
            }

            handler.PostDelayed(runnable, interval);
        }

    }
}
