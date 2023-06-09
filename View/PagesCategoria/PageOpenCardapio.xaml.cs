using CookSmart.Models;

namespace CookSmart.View.PagesCategoria;

public partial class PageOpenCardapio : ContentPage
{
    public PageOpenCardapio(object bindingcontext, string title)
    {
        InitializeComponent();
        Title = title;
        BindingContext = bindingcontext;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        ModelCardapios currentItem = (ModelCardapios)button.BindingContext;
        if (currentItem != null)
        {
            ReceitasSalvas NewReceita = new ReceitasSalvas();
            NewReceita.Create(currentItem);
        }
        DisplayAlert("...", "Receita salva", "ok");
    }
}