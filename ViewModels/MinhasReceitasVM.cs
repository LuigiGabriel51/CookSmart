using CookSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmart.ViewModels
{
    public class MinhasReceitasVM
    {
        private ConvertCardapio Convert = new ConvertCardapio();
        public List<ModelCardapios> Doces { get; set; }
        public MinhasReceitasVM()
        {
            Doces = Convert.CardapioDoces();
        }
    }
}
