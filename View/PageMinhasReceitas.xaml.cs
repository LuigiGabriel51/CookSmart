using CookSmart.ViewModels;

namespace CookSmart.View;

public partial class PageMinhasReceitas : ContentPage
{
    public PageMinhasReceitas()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var novaPagina = new PageNovaReceita();
        Navigation.PushAsync(novaPagina);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        MinhasReceitasVM vM = new MinhasReceitasVM();
        if(vM.ReceitasSalvas == null) {
            emptyS.IsVisible = true;
        }
        else { emptyS.IsVisible = false;  }
        if (vM.ReceitasCriadas == null)
        {
            emptyC.IsVisible = true;
        }
        else { emptyC.IsVisible=false; }
    }

    private void ListView_Refreshing(object sender, EventArgs e)
    {
        Task.Delay(3000);
        receitascriadas.IsRefreshing = false;
        receitassalvas.IsRefreshing = false;
    }
}