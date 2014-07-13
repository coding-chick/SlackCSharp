using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodingChick.SlackAPI.Data
{
    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("created")]
        public int Created { get; set; }
        [JsonProperty("creator")]
        public string Creator { get; set; }
        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }
        [JsonProperty("is_member")]
        public bool IsMember { get; set; }
        [JsonProperty("is_general")]
        public bool IsGeneral { get; set; }
        [JsonProperty("last_read")]
        public string LastRead { get; set; }
        [JsonProperty("latest")]
        public SlackMessage Latest { get; set; }
        [JsonProperty("unread_count")]
        public int UnreadCount { get; set; }
        [JsonProperty("members")]
        public List<string> Members { get; set; }
        [JsonProperty("topic")]
        public Topic Topic { get; set; }
        [JsonProperty("purpose")]
        public Purpose Purpose { get; set; }

        public string WebhookToken { get; set; }
    }
}