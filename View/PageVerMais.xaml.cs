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
            new RecomendadoPorCategoria(){Title="Recomenda��o de Drinks e Coquet�is", recomendados = drink },
            new RecomendadoPorCategoria(){Title="Recomenda��o de Almo�os e Jantares", recomendados = almoco},
            new RecomendadoPorCategoria(){Title="Recomenda��o de Caf� da Manh� e Brunch", recomendados = cafe}
        };
        recomendacoes.ItemsSource = binding;
    }
    public class RecomendadoPorCategoria
    {
        public string Title { get; set; }
        public ModelCardapios recomendados { get; set; }
    }
}
