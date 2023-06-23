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
            new RecomendadoPorCategoria(){Title="Recomendação de Drinks e Coquetéis", recomendados = Recomendados[0]},
            new RecomendadoPorCategoria(){Title="Recomendação de Almoços e Jantares", recomendados = Recomendados[1]},
            new RecomendadoPorCategoria(){Title="Recomendação de Café da Manhã e Brunch", recomendados = Recomendados[2]},
            new RecomendadoPorCategoria(){Title="Recomendação de Aperitivos e Petiscos", recomendados = Recomendados[3]},
            new RecomendadoPorCategoria(){Title="Recomendação de Sobremesas e Doces", recomendados = Recomendados[4]},
            new RecomendadoPorCategoria(){Title="Recomendação de Pratos Veganos e Vegetarianos", recomendados = Recomendados[5]},
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
