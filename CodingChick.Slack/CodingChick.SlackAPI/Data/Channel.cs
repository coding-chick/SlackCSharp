using System.Collections.Generic;

namespace CodingChick.SlackAPI.Data
{
    public class Channel
    {
        public string id { get; set; }
        public string name { get; set; }
        public int created { get; set; }
        public string creator { get; set; }
        public bool is_archived { get; set; }
        public bool is_member { get; set; }
        public bool is_general { get; set; }
        public string last_read { get; set; }
        public Message latest { get; set; }
        public int unread_count { get; set; }
        public List<string> members { get; set; }
        public Topic topic { get; set; }
        public Purpose purpose { get; set; }
    }
}