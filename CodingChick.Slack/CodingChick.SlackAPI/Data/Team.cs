namespace CodingChick.SlackAPI.Data
{
    public class Team
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email_domain { get; set; }
        public string domain { get; set; }
        public int msg_edit_window_mins { get; set; }
        public TeamPreferences prefs { get; set; }
        public bool over_storage_limit { get; set; }
    }
}