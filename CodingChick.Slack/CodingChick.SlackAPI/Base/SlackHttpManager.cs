using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodingChick.SlackAPI.Base
{
    public class SlackHttpManager
    {
        private readonly HttpSlackEngine _httpSlackEngine;
        private readonly SlackJsonParser _slackJsonParser;

        public SlackHttpManager(HttpSlackEngine httpSlackEngine, SlackJsonParser slackJsonParser)
        {
            _httpSlackEngine = httpSlackEngine;
            _slackJsonParser = slackJsonParser;
        }

        public async Task<T> GetParsedData<T>(string methodName, List<KeyValuePair<string, string>> methodParams)
        {
            if (methodParams == null)
                methodParams = new List<KeyValuePair<string, string>>();

            HttpContent contentResult = await _httpSlackEngine.GetAsyncWithToken(methodName, methodParams);

            var dataResponse = await contentResult.ReadAsStringAsync();

            var parsedDataResponse = _slackJsonParser.ParseDataResponse<T>(dataResponse);
            return parsedDataResponse;
        }
    }
}
