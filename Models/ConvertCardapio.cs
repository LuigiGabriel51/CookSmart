using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSmart.Models
{
    public class ConvertCardapio
    {
        public ConvertCardapio() { 
            LoadMauiAsset();
        }
        public string Cardapios { get; set; }
        public List<ModelCardapios> CardapioDrinks()
        {
            var jObject = JObject.Parse(Cardapios);
            var cardapioDrinks = jObject["CardapioDrinks"];
            List<ModelCardapios> drinks = new List<ModelCardapios>();
            foreach(var i in cardapioDrinks)
            {
                foreach(var j in i)
                {
                    ModelCardapios lista = j.ToObject<ModelCardapios>();
                    drinks.Add(lista);
                }
            }
            Console.WriteLine(drinks);
            return drinks; 
        }



        public List<ModelCardapios> CardapioAlmoco()
        {
            var jObject = JObject.Parse(Cardapios);
            var cardapioDrinks = jObject["CardapioAlmoco"];
            List<ModelCardapios> almocos = new List<ModelCardapios>();
            foreach (var i in cardapioDrinks)
            {
                foreach (var j in i)
                {
                    ModelCardapios lista = j.ToObject<ModelCardapios>();
                    almocos.Add(lista);
                }
            }
            Console.WriteLine(almocos);
            return almocos;
        }



        public List<ModelCardapios> CardapioCafe()
        {
            var jObject = JObject.Parse(Cardapios); 
            var cardapioDrinks = jObject["CardapioCafe"];
            List<ModelCardapios> cafe = new List<ModelCardapios>();
            foreach (var i in cardapioDrinks)
            {
                foreach (var j in i)
                {
                    ModelCardapios lista = j.ToObject<ModelCardapios>();
                    cafe.Add(lista);
                }
            }
            Console.WriteLine(cafe);
            return cafe;
        }

        public List<ModelCardapios> CardapioPetiscos()
        {
            var jObject = JObject.Parse(Cardapios);
            var Cardapiopetiscos = jObject["CardapioPetiscos"];
            List<ModelCardapios> Petiscos = new List<ModelCardapios>();
            foreach (var i in Cardapiopetiscos)
            {
                foreach (var j in i)
                {
                    ModelCardapios lista = j.ToObject<ModelCardapios>();
                    Petiscos.Add(lista);
                }
            }
            Console.WriteLine(Petiscos);
            return Petiscos;
        }



        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("Cardapio.json");
            using var reader = new StreamReader(stream);

            Cardapios = reader.ReadToEnd();
        }


    }
    public class Modelo
    {
        public ModelCardapios cardapios{ get; set; }
    }
}
