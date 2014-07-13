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
        private SlackHttpManager _slackHttpManager;

        public SlackClient(string applicationToken)
        {
            _clientToken = applicationToken;
            var httpSlackEngine = new HttpSlackEngine();
            httpSlackEngine.ApplicationToken = applicationToken;
            _slackJsonParser = new SlackJsonParser();
            _slackHttpManager = new SlackHttpManager(httpSlackEngine, _slackJsonParser);
        }

        private WebSocketEngine _socket;
        private SlackJsonParser _slackJsonParser;
        private Login _loginResponse;

        public WebSocketEngine SlackSocket
        {
            get { return _socket; }
        }

        public Login LoginResponse
        {
            get { return _loginResponse; }
        }

        public async Task Connect(string agent)
        {
            //login to system
            _loginResponse = await _slackHttpManager.GetParsedData<Login>("users.login",
                new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("agent", agent) });

            if (LoginResponse.OK)
            {
                _socket = new WebSocketEngine(LoginResponse.Url, LoginResponse.SvnRev);
            }
        }


        public async Task<bool> PostMessageThroughWebhook(SlackMessage message)
        {
            var messageParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("channel", message.Channel),
                new KeyValuePair<string, string>("text", message.Text),
                new KeyValuePair<string, string>("username", message.User)
            };
            var result = await _slackHttpManager.GetParsedData<Result>("chat.postMessage", messageParams);
            return result.ok;
        }
     
    }
}
