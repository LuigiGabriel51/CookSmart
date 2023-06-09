namespace CookSmart.View;

public partial class PageNovaReceita : ContentPage
{
    public PageNovaReceita()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Receita Criada", "Uma nova receita foi adicionada ao Livro de receitas.", "ok");
        Navigation.PopAsync();
    }
}