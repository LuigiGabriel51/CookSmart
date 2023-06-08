using CommunityToolkit.Mvvm.ComponentModel;
using CookSmart.Models;

namespace CookSmart.ViewModels
{
    public class MinhasReceitasVM: ObservableObject
    {
        private readonly ReceitasSalvas BDreceitasSalvas;
        private readonly ReceitasCriadas BDreceitasCriadas;

        public List<ModelCardapios> ReceitasSalvas { get; set; }
        public List<ModelCardapios> ReceitasCriadas { get; set; }
        public MinhasReceitasVM()
        {
            BDreceitasSalvas = new ReceitasSalvas();
            BDreceitasCriadas = new ReceitasCriadas();
            ReceitasSalvas = RefreshS(BDreceitasSalvas);
            ReceitasCriadas = RefreshC(BDreceitasCriadas);
        }
        private List<ModelCardapios> RefreshS(ReceitasSalvas BD)
        {
            var receitaList = BD.List();
            return receitaList;
        }
        private List<ModelCardapios> RefreshC(ReceitasCriadas BD)
        {
            var receitaList = BD.List();
            return receitaList;
        }
    }
}
