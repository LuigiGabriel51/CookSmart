using CookSmart.Models;
using CookSmart.View.PagesCategoria;

namespace CookSmart.View;

public partial class HomePage : ContentPage
{
    ModelCardapios recomendado = new ModelCardapios();
    ConvertCardapio ConvertCardapio = new ConvertCardapio();
    public HomePage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int argumento = (int)button.CommandParameter;
        switch (argumento)
        {
            case 1:
                System.Threading.Thread.Sleep(100);
                await Shell.Current.GoToAsync("////TopCategorias/PageDrinks");
                break;
            case 2:
                System.Threading.Thread.Sleep(100);
                await Shell.Current.GoToAsync("////TopCategorias/PageAlmoco");
                break;
            case 3:
                System.Threading.Thread.Sleep(100);
                await Shell.Current.GoToAsync("////TopCategorias/PageCafe");
                break;
            case 4:
                System.Threading.Thread.Sleep(100);
                await Shell.Current.GoToAsync("////TopCategorias/PageAperitivo");
                break;
            case 5:
                System.Threading.Thread.Sleep(100);
                await Shell.Current.GoToAsync("////TopCategorias/PageSobremesa");
                break;
            case 6:
                System.Threading.Thread.Sleep(100);
                await Shell.Current.GoToAsync("////TopCategorias/PageSalada");
                break;
            default:
                break;
        }

    }
    public ModelCardapios Recomendacao()
    {
        List<ModelCardapios> recomendacaoDrink = ConvertCardapio.CardapioDrinks();
        List<ModelCardapios> recomendacaoAlmoco = ConvertCardapio.CardapioAlmoco();
        List<ModelCardapios> recomendacaoCafe = ConvertCardapio.CardapioCafe();
        List<ModelCardapios> recomendacaoPetisco = ConvertCardapio.CardapioPetiscos();
        List<ModelCardapios> recomendacaoDoces = ConvertCardapio.CardapioDoces();
        List<ModelCardapios> recomendacaoVegano = ConvertCardapio.CardapioVegano();

        Random random = new Random();
        int escolhido = random.Next(67);
        List<ModelCardapios> RecomendacaoDia = new List<ModelCardapios>();

        RecomendacaoDia = recomendacaoDrink
            .Concat(recomendacaoAlmoco)
            .Concat(recomendacaoCafe)
            .Concat(recomendacaoPetisco)
            .Concat(recomendacaoDoces)
            .Concat(recomendacaoVegano).ToList();

        return RecomendacaoDia[escolhido];
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (DailyTaskManager.CanExecuteTask())
        {
            recomendado = Recomendacao();
            frameRecomendacao.BindingContext = recomendado;
        }

    }



    public static class DailyTaskManager
    {
        private static DateTime LastExecutionDate = DateTime.MinValue;

        public static bool CanExecuteTask()
        {
            DateTime currentDate = DateTime.Today;

            if (currentDate > LastExecutionDate)
            {
                LastExecutionDate = currentDate;
                return true;
            }

            return false;
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        var novaPagina = new PageOpenCardapio(recomendado, recomendado.Nome);
        Navigation.PushAsync(novaPagina);
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Random random = new();
        var recomendadoDrink = ConvertCardapio.CardapioDrinks()[random.Next(11)];
        var recomendadoAlmoco = ConvertCardapio.CardapioAlmoco()[random.Next(11)];
        var recomendadoCafe = ConvertCardapio.CardapioCafe()[random.Next(12)];
        var recomendadoPetisco = ConvertCardapio.CardapioPetiscos()[random.Next(11)];
        var recomendadoDoce = ConvertCardapio.CardapioDoces()[random.Next(11)];
        var recomendadoVegano = ConvertCardapio.CardapioVegano()[random.Next(11)];

        List<ModelCardapios> Recomendacoes = new()
        {
            recomendadoDrink,recomendadoAlmoco,recomendadoCafe,recomendadoPetisco,recomendadoDoce,recomendadoVegano
        };

        var novaPagina = new PageVerMais("Recomendações por Categoria", Recomendacoes);
        Navigation.PushAsync(novaPagina);
    }


}
