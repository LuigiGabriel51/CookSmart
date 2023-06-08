using CookSmart.Models;

namespace CookSmart.View;

public partial class PageVerMais : ContentPage
{

    public PageVerMais(string title, ModelCardapios drink, ModelCardapios almoco, ModelCardapios cafe)
    {
        InitializeComponent();
        Title = title;
        List<RecomendadoPorCategoria> binding = new List<RecomendadoPorCategoria>()
        {
            new RecomendadoPorCategoria(){Title="Recomendação de Drinks e Coquetéis", recomendados = drink },
            new RecomendadoPorCategoria(){Title="Recomendação de Almoços e Jantares", recomendados = almoco},
            new RecomendadoPorCategoria(){Title="Recomendação de Café da Manhã e Brunch", recomendados = cafe}
        };
        recomendacoes.ItemsSource = binding;
    }
    public class RecomendadoPorCategoria
    {
        public string Title { get; set; }
        public ModelCardapios recomendados { get; set; }
    }
}
