using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookSmart.Models;

namespace CookSmart.ViewModels
{
    public class NovaReceitaVM : ObservableObject
    {
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }
        private string _imageurl;
        public string ImageUrl
        {
            get { return _imageurl; }
            set { SetProperty(ref _imageurl, value); }
        }
        private int _tempopreparo;
        public int TempoPreparo
        {
            get { return _tempopreparo; }
            set { SetProperty(ref _tempopreparo, value); }
        }
        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
        }
        private string _ingredientes;
        public string Ingredientes
        {
            get { return _ingredientes; }
            set { SetProperty(ref _ingredientes, value); }
        }
        private string _modopreparo;
        public string ModoPreparo
        {
            get { return _modopreparo; }
            set { SetProperty(ref _modopreparo, value); }
        }


        public IAsyncRelayCommand Save { get; set; }

        public NovaReceitaVM()
        {
            Save = new AsyncRelayCommand(save);
        }
        private async Task save()
        {
            ModelCardapios NewCardapio = new ModelCardapios()
            {
                Nome = Nome,
                image = ImageUrl,
                Tempo_preparo = TempoPreparo,
                Descricao = Descricao,
                Ingredientes = Ingredientes,
                Modo_preparo = ModoPreparo
            };
            if (Nome != null && ImageUrl != null && TempoPreparo != 0 && Descricao != null && Ingredientes != null && ModoPreparo != null)
            {
                ReceitasCriadas NewReceita = new ReceitasCriadas();
                NewReceita.Create(NewCardapio);
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                string text = "Receita Criada";
                ToastDuration duration = ToastDuration.Long;
                double fontSize = 15;

                var toast = Toast.Make(text, duration, fontSize);
                await toast.Show(cancellationTokenSource.Token);
                Page currentPage = Application.Current.MainPage;

                if (currentPage != null && currentPage.Navigation != null)
                {
                    await currentPage.Navigation.PopAsync();
                }
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                string text = "Preecha os campos para adicionar uma nova receita";
                ToastDuration duration = ToastDuration.Long;
                double fontSize = 20;

                var toast = Toast.Make(text, duration, fontSize);
                await toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}
