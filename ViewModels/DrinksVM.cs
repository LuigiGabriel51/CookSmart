using CommunityToolkit.Mvvm.ComponentModel;

namespace CookSmart.Models
{
    public class Drinks : ObservableObject
    {
        ConvertCardapio ConvertCardapio = new ConvertCardapio();
        public List<ModelCardapios> DrinksDisp { get; set; }

        public Drinks()
        {
           DrinksDisp = ConvertCardapio.CardapioDrinks();
        }
    }

    public class ModelCardapios
    {
        public string Nome { get; set; }
        public string image { get; set; }
        public string Descricao { get; set; }
        public string Modo_preparo { get; set; }
        public string Ingredientes { get; set; }
        public int Tempo_preparo { get; set; }
    }
}
