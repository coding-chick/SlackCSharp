using Newtonsoft.Json;

namespace CodingChick.SlackAPI.Data
{
    public class Bot
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
        [JsonProperty("icons")]
        public Icons Icons { get; set; }
    }
}