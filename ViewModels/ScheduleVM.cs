using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookSmart.Models;
using CookSmart.ToolsApp;

namespace CookSmart.ViewModels
{
    public class ScheduleVM : ObservableObject
    {
        private ConvertCardapio Convert = new ConvertCardapio();
        private List<ModelCardapios> _cardapios;
        public List<ModelCardapios> Cardapios {
            get { return _cardapios; }
            set { SetProperty(ref _cardapios, value); }
        }

        private DateTime _schedule;
        public DateTime Schedule
        {
            get { return _schedule; }
            set { SetProperty(ref _schedule, value); }
        }
        private TimeSpan _timespan;
        public TimeSpan Timespan
        {
            get { return _timespan; }
            set { SetProperty(ref _timespan, value); }
        }
        public ModelCardapios ItemSchedule { get; set; }
        public List<ModelScheduleCook> Receitasprogramadas { get; set; }
        public DateTime mintime { get; set; }
        public DateTime maxtime { get; set; }
        public IAsyncRelayCommand SaveSchedule { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ScheduleVM()
        {
            getCardapios();
            SaveSchedule = new AsyncRelayCommand(Save);
            mintime = DateTime.Now;
            Receitasprogramadas = GetReceitasProgramadas();
            maxtime = DateTime.Now.AddMonths(3);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        private async Task Save()
        {

            ToastMake toast = new();
            if (AddCook())
            {
                await toast.ShowToatAsync($"Receita Programada para o dia {Schedule:yyyy/MM/d} às {Timespan}");
            }
            else await toast.ShowSnackBar($"Selecione uma data e uma receita para adicionar");
        }

        private void getCardapios()
        {
            List<ModelCardapios> CardapiosGerais = new List<ModelCardapios>();
            List<ModelCardapios> drinks = Convert.CardapioDrinks();
            List<ModelCardapios> almocos = Convert.CardapioAlmoco();
            List<ModelCardapios> doces = Convert.CardapioDoces();
            List<ModelCardapios> petiscos = Convert.CardapioPetiscos();
            List<ModelCardapios> veganos = Convert.CardapioVegano();
            List<ModelCardapios> cafes = Convert.CardapioCafe();
            drinks.ForEach(drink => CardapiosGerais.Add(drink));
            almocos.ForEach(almoco => CardapiosGerais.Add(almoco));
            doces.ForEach(doce => CardapiosGerais.Add(doce));
            petiscos.ForEach(petisco => CardapiosGerais.Add(petisco));
            veganos.ForEach(vegano => CardapiosGerais.Add(vegano));
            cafes.ForEach(cafe => CardapiosGerais.Add(cafe));
            Cardapios =  CardapiosGerais;
        }

        private bool AddCook()
        {
            if (ItemSchedule != null)
            {
                ModelScheduleCook receitas_programada = new()
                {
                    Nome = ItemSchedule.Nome,
                    image = ItemSchedule.image,
                    date = Schedule + Timespan,
                };
                ReceitasProgramadas receitas = new();
                receitas.Create(receitas_programada);
                return true;
            }
            return false;
        }

        private static List<ModelScheduleCook> GetReceitasProgramadas()
        {
            ReceitasProgramadas receitas = new();
            return receitas.List();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
