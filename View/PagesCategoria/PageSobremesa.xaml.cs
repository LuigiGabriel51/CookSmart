using CookSmart.Models;

namespace CookSmart.View.PagesCategoria;

public partial class PageSobremesa : ContentPage
{
    public PageSobremesa()
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