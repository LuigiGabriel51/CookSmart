using CommunityToolkit.Mvvm.ComponentModel;
using CookSmart.Models;

namespace CookSmart.ViewModels
{
    public class PetiscosVM : ObservableObject
    {
        ConvertCardapio cc = new ConvertCardapio();
        public List<ModelCardapios> Petiscos { get; set; }
        public PetiscosVM() => Petiscos = CardapiosProntos.CardapioPetiscos;
    }
}
