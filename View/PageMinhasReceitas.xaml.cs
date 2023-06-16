using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CookSmart.Models;
using CookSmart.ViewModels;
using System.Reflection.Metadata;

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
        MinhasReceitasVM mr = new MinhasReceitasVM();
        receitassalvas.ItemsSource = mr.ReceitasSalvas;
        receitascriadas.ItemsSource = mr.ReceitasCriadas; 
    }

    private void ListView_Refreshing(object sender, EventArgs e)
    {
        MinhasReceitasVM mr = new MinhasReceitasVM();
        receitassalvas.ItemsSource = mr.ReceitasSalvas;
        receitascriadas.ItemsSource = mr.ReceitasCriadas;
        rv.IsRefreshing = false;
    }

    private async void SwipeItem_Invoked(object sender, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)sender;
        ModelCardapios currentItem = (ModelCardapios)swipeItem.BindingContext;
        if (currentItem != null)
        {
            ReceitasCriadas Receita = new ReceitasCriadas();
            Receita.Delete(currentItem);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            string text = "Item excluído";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 15;

            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    private async void SwipeItem_Invoked_1(object sender, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)sender;
        ModelCardapios currentItem = (ModelCardapios)swipeItem.BindingContext;
        if (currentItem != null)
        {
            ReceitasSalvas Receita = new ReceitasSalvas();
            Receita.Delete(currentItem);


            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            string text = "Item excluído";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 15;

            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }
}