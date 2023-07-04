using CookSmart.Models;

namespace CookSmart;

public partial class App : Application
{
    public App()
    {

        InitializeComponent();
        IncializeCardapio();
        MainPage = new AppShell();

    }
    public void IncializeCardapio()
    {
        ConvertCardapio convert = new();
        CardapiosProntos.CardapioDrinks = convert.CardapioDrinks();
        CardapiosProntos.CardapioAlmocos = convert.CardapioAlmoco();
        CardapiosProntos.CardapioCafes = convert.CardapioCafe();
        CardapiosProntos.CardapioPetiscos = convert.CardapioPetiscos();
        CardapiosProntos.CardapioDoces = convert.CardapioDoces();
        CardapiosProntos.CardapioVeganos = convert.CardapioVegano();
    }
}
