using CommunityToolkit.Mvvm.Input;

namespace CookSmart.ViewModels
{
    public class ShellCommands
    {
        public IAsyncRelayCommand BackHome { get; set; }
        public ShellCommands()
        {
            BackHome = new AsyncRelayCommand(backhome);
        }
        private async Task backhome()
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
    }
}
