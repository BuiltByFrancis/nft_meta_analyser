using Newtonsoft.Json;
using System.Collections.Generic;

namespace NFTAnalyser.Models
{
    public class NFTData
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "dna")]
        public string Dna { get; set; }

        [JsonProperty(PropertyName = "edition")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        public double Date { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public IEnumerable<NFTTrait> Traits { get; set; }

        public NFTData()
        {
            Name = "Unknown";
            Description = "Unknown";
            Image = "Unknown";
            Dna = "Unknown";
            Traits = new List<NFTTrait>();
        }
    }
}
