using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChick.SlackAPI.Data;
using WebSocket4Net;

namespace CodingChick.SlackAPI.Base
{
    public delegate void ChatMessageEventHandler(object source, ChatMessageEventArgs e);

    public class ChatMessageEventArgs : EventArgs
    {
        public SlackMessage SlackMessage { get; set; }
    }

    public class WebSocketEngine : IDisposable
    {
        WebSocket _webSocket;

        public event ChatMessageEventHandler OnChatMessageRecieved;
        public event ChatMessageEventHandler OnChannelMessageRecieved;

        Dictionary<string, Action<SlackMessage>> _messagesActions;
        private bool _helloRecieved;

        public WebSocketEngine(string url, string svnRev)
        {
            Connect(url, svnRev);
        }

        public bool HelloRecieved
        {
            get { return _helloRecieved; }
        }

        public void Connect(string url, string svnRev)
        {
            _webSocket = new WebSocket(
                string.Format("{0}?svn_rev={1}&login_with_boot_data-0-{2}&on_login-0-{2}&connect-1-{2}",
                    url, svnRev,
                    DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds));

            _webSocket.MessageReceived += WebSocketOnMessageReceived;
            _webSocket.Open();
            _messagesActions = new Dictionary<string, Action<SlackMessage>>()
            {
                {"message", message => SendChatMessage(message)},
                {"hello", message => HandleHelloMessage(message)},
            };
        }

        private void HandleHelloMessage(SlackMessage message)
        {
            _helloRecieved = true;
        }

        private void WebSocketOnMessageReceived(object sender, MessageReceivedEventArgs messageReceivedEventArgs)
        {
            var parser = new SlackJsonParser();
            var parsedMessage = parser.ParseDataResponse<SlackMessage>(messageReceivedEventArgs.Message);

            Action<SlackMessage> action;
            if (_messagesActions.TryGetValue(parsedMessage.Type, out action))
            {
                action.Invoke(parsedMessage);
            }
        }

        private void SendChatMessage(SlackMessage parsedMessage)
        {
            if (OnChatMessageRecieved != null)
            {
                OnChatMessageRecieved(this, new ChatMessageEventArgs()
                {
                    SlackMessage = new SlackMessage()
                    {
                        Text = parsedMessage.Text,
                        Channel = parsedMessage.Channel,
                        TimeStamp = parsedMessage.TimeStamp,
                        User = parsedMessage.User    
                    }
                });
            }
        }

        public void Dispose()
        {
            if (_webSocket != null)
            {
                _webSocket.Close("done");
            }

            OnChatMessageRecieved = null;
        }
    }
}
