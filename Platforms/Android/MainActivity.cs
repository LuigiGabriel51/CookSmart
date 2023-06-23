using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using CookSmart.Platforms.Android;

namespace CookSmart;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize |
    ConfigChanges.Orientation | ConfigChanges.UiMode |
    ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize |
    ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public MainActivity()
    {
    }
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Solicitar permissão para exibir notificações
        if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.WakeLock) != Permission.Granted)
        {
            ActivityCompat.RequestPermissions(this, new[] { Android.Manifest.Permission.WakeLock }, 0);
        }
        // Iniciar o serviço de background
        StartService(new Intent(this, typeof(MyBackgroundService)));
    }
    // Restante do código...
}
