using CommunityToolkit.Mvvm.ComponentModel;

namespace CookSmart.ViewModels
{
    public class HomePageVM : ObservableObject
    {
        public List<Categoria> Categorias { get; set; }

        private Categoria drink = new Categoria
        {
            id = 1,
            img = "drink.png",
            nome = "Drinks e Coquetéis"
        };
        private Categoria almoco = new Categoria
        {
            id = 2,
            img = "almoco.png",
            nome = "Almoços e Jantares"
        };
        private Categoria cafe = new Categoria
        {
            id = 3,
            img = "cafe.png",
            nome = "Café da Manhã e Brunch"
        };
        private Categoria aperitivo = new Categoria
        {
            id = 4,
            img = "aperitivo.png",
            nome = "Aperitivos e Petiscos"
        };
        private Categoria sobremesa = new Categoria
        {
            id = 5,
            img = "sobremesa.png",
            nome = "Sobremesas e Doces"
        };
        private Categoria salada = new Categoria
        {
            id = 6,
            img = "salada.png",
            nome = "Pratos Vegetarianos e Veganos"
        };

        public HomePageVM()
        {
            Categorias = new List<Categoria> {
                drink, almoco, cafe, aperitivo, sobremesa, salada
        };
        }
    }
    public class Categoria
    {
        public int id { get; set; }
        public string img { get; set; }
        public string nome { get; set; }
    }
}
