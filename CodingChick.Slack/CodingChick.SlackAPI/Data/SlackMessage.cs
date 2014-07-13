using Newtonsoft.Json;

namespace CodingChick.SlackAPI.Data
{
    public class SlackMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("ts")]
        public string TimeStamp { get; set; }
        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
        
        [JsonProperty("channel")]
        public string Channel { get; set; }

    }
}