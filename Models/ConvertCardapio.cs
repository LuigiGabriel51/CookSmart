using Newtonsoft.Json.Linq;

namespace CookSmart.Models
{
    public class ConvertCardapio
    {
        public ConvertCardapio()
        {
            LoadMauiAsset();
        }
        public string Cardapios { get; set; }
        public List<ModelCardapios> CardapioDrinks()
        {
            var jObject = JObject.Parse(Cardapios);
            var cardapioDrinks = jObject["CardapioDrinks"];
            List<ModelCardapios> drinks = new List<ModelCardapios>();
            foreach (var i in cardapioDrinks)
            {
                foreach (var j in i)
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

        public List<ModelCardapios> CardapioDoces()
        {
            var jObject = JObject.Parse(Cardapios);
            var SobremesaDoces = jObject["SobremesaDoces"];
            List<ModelCardapios> Doces = new List<ModelCardapios>();
            foreach (var i in SobremesaDoces)
            {
                foreach (var j in i)
                {
                    ModelCardapios lista = j.ToObject<ModelCardapios>();
                    Doces.Add(lista);
                }
            }
            Console.WriteLine(Doces);
            return Doces;
        }

        public List<ModelCardapios> CardapioVegano()
        {
            var jObject = JObject.Parse(Cardapios);
            var Pveganos = jObject["CardapioVegetariano"];
            List<ModelCardapios> pveganos = new List<ModelCardapios>();
            foreach (var i in Pveganos)
            {
                foreach (var j in i)
                {
                    ModelCardapios lista = j.ToObject<ModelCardapios>();
                    pveganos.Add(lista);
                }
            }
            Console.WriteLine(pveganos);
            return pveganos;
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
        public ModelCardapios cardapios { get; set; }
    }
}
