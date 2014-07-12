using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;

namespace CodingChick.SlackAPI.Base
{
    public delegate void ChatMessageEventHandler(object source, ChatMessageEventArgs e);

    public class ChatMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    public class WebSocketEngine : IDisposable
    {
        WebSocket _webSocket;

        public event ChatMessageEventHandler OnMessageRecieved;
        
        public WebSocketEngine(string url, string svnRev)
        {
            _webSocket = new WebSocket(
                string.Format("{0}?svn_rev={1}&login_with_boot_data-0-{2}&on_login-0-{2}&connect-1-{2}",
                    url, svnRev,
                    DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds));

            _webSocket.MessageReceived += WebSocketOnMessageReceived;
            _webSocket.Open();
        }

        private void WebSocketOnMessageReceived(object sender, MessageReceivedEventArgs messageReceivedEventArgs)
        {
            if (OnMessageRecieved != null)
            {
                OnMessageRecieved(this, new ChatMessageEventArgs(){Message = messageReceivedEventArgs.Message});
            }
        }

        public void Dispose()
        {
            if (_webSocket != null)
            {
                _webSocket.Close("done");
            }

            OnMessageRecieved = null;
        }
    }
}
