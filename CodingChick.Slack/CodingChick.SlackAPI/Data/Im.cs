namespace CodingChick.SlackAPI.Data
{
    public class Im
    {
        public string id { get; set; }
        public string user { get; set; }
        public int created { get; set; }
        public string last_read { get; set; }
        public Message latest { get; set; }
        public int unread_count { get; set; }
        public bool is_open { get; set; }
    }
}