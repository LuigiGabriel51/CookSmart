using CommunityToolkit.Mvvm.ComponentModel;
using CookSmart.Models;

namespace CookSmart.ViewModels
{
    public class AlmocoVM : ObservableObject
    {
        ConvertCardapio ConvertCardapio = new ConvertCardapio();
        public List<ModelCardapios> Almocos { get; set; }
        public AlmocoVM()
        {
            Almocos = ConvertCardapio.CardapioAlmoco();
        }
    }
}
