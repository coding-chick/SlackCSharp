using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodingChick.SlackAPI.Data
{
    public class Login
    {
        [JsonProperty("ok")]
        public bool OK { get; set; }
        [JsonProperty("self")]
        public Self Self { get; set; }
        [JsonProperty("team")]
        public Team Team { get; set; }
        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }
        [JsonProperty("groups")]
        public List<object> Groups { get; set; }
        [JsonProperty("ims")]
        public List<Im> Ims { get; set; }
        [JsonProperty("users")]
        public List<User> Users { get; set; }
        [JsonProperty("bots")]
        public List<Bot> Bots { get; set; }
        [JsonProperty("svn_rev")]
        public string SvnRev { get; set; }
        [JsonProperty("min_svn_rev")]
        public int MinSvnRev { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
