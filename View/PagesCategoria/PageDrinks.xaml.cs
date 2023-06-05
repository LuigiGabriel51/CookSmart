using CookSmart.Models;

namespace CookSmart.View.PagesCategoria;

public partial class PageDrinks : ContentPage
{
    public PageDrinks()
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