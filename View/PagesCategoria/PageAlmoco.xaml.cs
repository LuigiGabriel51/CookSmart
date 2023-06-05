using CookSmart.Models;

namespace CookSmart.View.PagesCategoria;

public partial class PageAlmoco : ContentPage
{
    public PageAlmoco()
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