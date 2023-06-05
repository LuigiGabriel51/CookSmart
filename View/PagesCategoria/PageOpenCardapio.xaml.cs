namespace CookSmart.View.PagesCategoria;

public partial class PageOpenCardapio : ContentPage
{
	public PageOpenCardapio(object bindingcontext, string title)
	{
		InitializeComponent();
		Title = title;
		BindingContext = bindingcontext;
	}
}