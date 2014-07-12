namespace CodingChick.SlackAPI.Data
{
    public class TeamPreferences
    {
        public int msg_edit_window_mins { get; set; }
        public bool allow_message_deletion { get; set; }
        public bool hide_referers { get; set; }
        public bool display_real_names { get; set; }
        public string auth_mode { get; set; }
    }
}