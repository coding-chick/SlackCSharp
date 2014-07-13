namespace CodingChick.SlackAPI.Base
{
    public enum MessageType
    {
        [ParamValue("hello")]
        Hello,
        [ParamValue("message")]
        Message,
        [ParamValue("presence_changed")]
        PresenceChanged,
    }
}