using CookSmart.Models;
using CookSmart.View.PagesCategoria;

namespace CookSmart.View;

public partial class PageVerMais : ContentPage
{

    public PageVerMais(string title, List<ModelCardapios> Recomendados)
    {
        InitializeComponent();
        Title = title;
        List<RecomendadoPorCategoria> binding = new List<RecomendadoPorCategoria>()
        {
            new RecomendadoPorCategoria(){Title="Recomenda��o de Drinks e Coquet�is", recomendados = Recomendados[0]},
            new RecomendadoPorCategoria(){Title="Recomenda��o de Almo�os e Jantares", recomendados = Recomendados[1]},
            new RecomendadoPorCategoria(){Title="Recomenda��o de Caf� da Manh� e Brunch", recomendados = Recomendados[2]},
            new RecomendadoPorCategoria(){Title="Recomenda��o de Aperitivos e Petiscos", recomendados = Recomendados[3]},
            new RecomendadoPorCategoria(){Title="Recomenda��o de Sobremesas e Doces", recomendados = Recomendados[4]},
            new RecomendadoPorCategoria(){Title="Recomenda��o de Pratos Veganos e Vegetarianos", recomendados = Recomendados[5]},
        };
        recomendacoes.ItemsSource = binding;
    }
    public class RecomendadoPorCategoria
    {
        public string Title { get; set; }
        public ModelCardapios recomendados { get; set; }
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Frame binding = (Frame)sender;
        RecomendadoPorCategoria cardapio = (RecomendadoPorCategoria)binding.BindingContext;
        var novaPagina = new PageOpenCardapio(cardapio.recomendados, cardapio.Title);
        Shell.SetTitleView(novaPagina, null);
        Navigation.PushAsync(novaPagina);
    }
}
