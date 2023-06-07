using CommunityToolkit.Mvvm.ComponentModel;
using CookSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmart.ViewModels
{
    public  class DocesVM: ObservableObject
    {
        private ConvertCardapio Convert = new ConvertCardapio();
        public List<ModelCardapios> Doces { get; set; }
        public DocesVM() {
            Doces = Convert.CardapioDoces();
        }
    }
}
