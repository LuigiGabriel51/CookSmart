using CookSmart.Models;
using CookSmart.ToolsApp;
using CookSmart.ViewModels;

namespace CookSmart.View;

public partial class ScheduleCook : ContentPage
{
    public ScheduleCook()
    {
        Task.Delay(2000);
        InitializeComponent();
    }
    private void ListView_Refreshing(object sender, EventArgs e)
    {
        ScheduleVM sVM = new();
        receitasprogramada.ItemsSource = sVM.Receitasprogramadas;
        receitasprogramada.IsRefreshing = false;
        receitasprogramada.SelectedItem = null;
        date.Date = default;
        time.Time = default;
    }

    private async void SwipeItem_Invoked_1(object sender, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)sender;
        ModelScheduleCook currentItem = (ModelScheduleCook)swipeItem.BindingContext;
        if (currentItem != null)
        {
            ReceitasProgramadas Receita = new ReceitasProgramadas();
            Receita.Delete(currentItem);

            string text = "Item excluído";
            ToastMake toast = new();
            await toast.ShowToatAsync(text);
        }
    }

    private void AvailableRecipesListView_Scrolled(object sender, ScrolledEventArgs e)
    {

    }
}