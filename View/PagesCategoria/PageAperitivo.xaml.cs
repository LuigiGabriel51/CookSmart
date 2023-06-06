using CookSmart.Models;

namespace CookSmart.View.PagesCategoria;

public partial class PageAperitivo : ContentPage
{
    public PageAperitivo()
    {
        InitializeComponent();
    }
    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedItem = e.SelectedItem as ModelCardapios;
        var novaPagina = new PageOpenCardapio(selectedItem, selectedItem.Nome);
        Navigation.PushAsync(novaPagina);
    }
}