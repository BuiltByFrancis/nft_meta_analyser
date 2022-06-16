using Newtonsoft.Json;

namespace NFTAnalyser.Models
{
    public class NFTTrait
    {
        [JsonProperty(PropertyName = "trait_type")]
        public string Trait { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        public NFTTrait()
        {
            Trait = "Unknown";
            Value = "Unknown";
        }
    }
}
