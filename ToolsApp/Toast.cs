using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace CookSmart.ToolsApp
{
    public class ToastMake
    {
        public async Task ShowToatAsync(string text)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string Text = text;
            ToastDuration duration = ToastDuration.Long;
            double fontSize = 15;

            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
        public async Task ShowSnackBar(string text)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.White,
                TextColor = Colors.Red,
                ActionButtonTextColor = Colors.Black,
                CornerRadius = new CornerRadius(10),
                Font = Microsoft.Maui.Font.SystemFontOfSize(12),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(12),
                CharacterSpacing = 0.5
            };
            string actionButtonText = "OK";
            Action action = () => { };
            TimeSpan duration = TimeSpan.FromSeconds(2);

            var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        }
    }
}
