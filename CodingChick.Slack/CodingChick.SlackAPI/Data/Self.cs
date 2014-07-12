namespace CodingChick.SlackAPI.Data
{
    public class Self
    {
        public string id { get; set; }
        public string name { get; set; }
        public UserPreferences prefs { get; set; }
        public int created { get; set; }
        public string manual_presence { get; set; }
    }
}