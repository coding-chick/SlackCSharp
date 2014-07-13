using Newtonsoft.Json;

namespace CodingChick.SlackAPI.Data
{
    public class Im
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("created")]
        public int Created { get; set; }
        [JsonProperty("last_read")]
        public string LastRead { get; set; }
        [JsonProperty("latest")]
        public SlackMessage Latest { get; set; }
        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }
        [JsonProperty("is_open")]
        public bool IsOpen { get; set; }
    }
}