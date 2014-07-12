using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodingChick.SlackAPI.Base
{
    public class SlackJsonParser
    {
        private readonly HttpSlackEngine _httpSlackEngine;

        public SlackJsonParser(HttpSlackEngine httpSlackEngine)
        {
            _httpSlackEngine = httpSlackEngine;
        }

        public async Task<T> GetParsedData<T>(string methodName, List<KeyValuePair<string, string>> methodParams)
        {
            if (methodParams == null)
                methodParams = new List<KeyValuePair<string, string>>();

            HttpContent contentResult = await _httpSlackEngine.GetAsyncWithToken(methodName, methodParams);

            var dataResponse = await contentResult.ReadAsStringAsync();

            var parsedDataResponse = JsonConvert.DeserializeObject<T>(dataResponse);
            return parsedDataResponse;
        }

    }
}
