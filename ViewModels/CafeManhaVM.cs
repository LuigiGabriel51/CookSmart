using CommunityToolkit.Mvvm.ComponentModel;
using CookSmart.Models;

namespace CookSmart.ViewModels
{
    public class CafeManhaVM : ObservableObject
    {
        ConvertCardapio ConvertCardapio = new ConvertCardapio();
        public List<ModelCardapios> CafesManha { get; set; }
        public CafeManhaVM()
        {
            CafesManha = ConvertCardapio.CardapioCafe();
        }
    }
}
