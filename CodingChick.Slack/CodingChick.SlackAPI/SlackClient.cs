using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChick.SlackAPI.Base;
using CodingChick.SlackAPI.Data;
using WebSocket4Net;


namespace CodingChick.SlackAPI
{
    public class SlackClient
    {
        private readonly string _clientToken;
        private SlackJsonParser _slackJsonParser;

        public SlackClient(string applicationToken)
        {
            _clientToken = applicationToken;
            var httpSlackEngine = new HttpSlackEngine();
            httpSlackEngine.ApplicationToken = applicationToken;
            _slackJsonParser = new SlackJsonParser(httpSlackEngine);
        }

        private WebSocketEngine _socket;

        public WebSocketEngine SlackSocket
        {
            get { return _socket; }
        }

        public async Task Connect(string agent)
        {
            //login to system
            var loginResponse = await _slackJsonParser.GetParsedData<Login>("users.login",
                new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("agent", agent) });

            if (loginResponse.ok)
            {
                _socket = new WebSocketEngine(loginResponse.url, loginResponse.svn_rev);
            }
        }

     
    }
}
