using Newtonsoft.Json;
using System.Collections.Generic;

namespace StaticShock.Models
{
    public class Pokes
    {
        [JsonProperty("count")]
        public string Id { get; set; }

        [JsonProperty("results")]
        public List<string> Category { get; set; }

    }
}
