using StaticShock.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StaticShock.Models
{
    public class PokemonResult
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Pokemon> Pokemons { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }

    public class Pokemon
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
