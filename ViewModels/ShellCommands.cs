using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
