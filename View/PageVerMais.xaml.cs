using CookSmart.Models;

namespace CookSmart.View;

public partial class PageVerMais : ContentPage
{

    public PageVerMais(string title, ModelCardapios drink, ModelCardapios almoco, ModelCardapios cafe)
	{
		InitializeComponent();
		Title = title;
		List<ModelCardapios> binding = new List<ModelCardapios>() {drink, almoco, cafe};
		recomendacoes.ItemsSource = binding;
	}
}
