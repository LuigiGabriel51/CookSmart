using CommunityToolkit.Mvvm.ComponentModel;
using CookSmart.Models;

namespace CookSmart.ViewModels
{
    public class VeganoVM : ObservableObject
    {
        ConvertCardapio CC = new ConvertCardapio();
        public List<ModelCardapios> Veganos { get; set; }
        public VeganoVM() => Veganos = CardapiosProntos.CardapioVeganos;
    }
}
