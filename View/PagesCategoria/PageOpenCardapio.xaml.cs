using CookSmart.Models;
using CookSmart.ToolsApp;

namespace CookSmart.View.PagesCategoria;

public partial class PageOpenCardapio : ContentPage
{
    public PageOpenCardapio(object bindingcontext, string title)
    {
        InitializeComponent();
        Title = title;
        BindingContext = bindingcontext;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        ModelCardapios currentItem = (ModelCardapios)button.BindingContext;
        if (currentItem != null)
        {
            ReceitasSalvas NewReceita = new ReceitasSalvas();
            NewReceita.Create(currentItem);
            ToastMake toast = new ToastMake();
            await toast.ShowToatAsync("Receita adicionada ao livro de receitas");
        }
    }
}