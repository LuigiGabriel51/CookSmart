using CommunityToolkit.Mvvm.ComponentModel;
using CookSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmart.ViewModels
{
    public class PetiscosVM: ObservableObject
    {
        ConvertCardapio cc = new ConvertCardapio();
        public List<ModelCardapios> Petiscos { get; set; }
        public PetiscosVM() {
            Petiscos = cc.CardapioPetiscos();
        }
    }
}
