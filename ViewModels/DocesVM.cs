using CommunityToolkit.Mvvm.ComponentModel;
using CookSmart.Models;

namespace CookSmart.ViewModels
{
    public class DocesVM : ObservableObject
    {
        private ConvertCardapio Convert = new ConvertCardapio();
        public List<ModelCardapios> Doces { get; set; }
        public DocesVM()
        {
            Doces = Convert.CardapioDoces();
        }
    }
}
