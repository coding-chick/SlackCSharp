namespace CodingChick.SlackAPI.Data
{
    public class Message
    {
        public string type { get; set; }
        public string user { get; set; }
        public string text { get; set; }
        public string ts { get; set; }
        public string subtype { get; set; }
    }
}