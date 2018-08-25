using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StaticShock.Models;

namespace StaticShock.Services
{
    public class PokeApi
    {
        readonly string _api_pokemon = "http://pokeapi.co/api/v2/pokemon";

        public PokeApi()
        {
        }

        public async Task<List<Pokemon>> getPokemonsAsync()
        {
            var json = await GetJsonData(_api_pokemon);

            var result = JsonConvert.DeserializeObject<PokemonResult>(json);

            return result.Pokemons;
        }

        public async Task<PokemonInformation> getPokemonAsync(string url)
        {
            var json = await GetJsonData(url);

            var result = JsonConvert.DeserializeObject<PokemonInformation>(json);

            return result;
        }

        async Task<string> GetJsonData(string url)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return json;
            }
        }
    }
}
