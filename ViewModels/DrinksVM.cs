using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace CookSmart.Models
{
    public class Drinks : ObservableObject
    {
        ConvertCardapio ConvertCardapio = new ConvertCardapio();
        public List<ModelCardapios> DrinksDisp { get; set; }

        public Drinks() => DrinksDisp = ConvertCardapio.CardapioDrinks();
    }

    public class ModelCardapios
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string image { get; set; }
        public string Descricao { get; set; }
        public string Modo_preparo { get; set; }
        public string Ingredientes { get; set; }
        public int Tempo_preparo { get; set; }
    }
}
