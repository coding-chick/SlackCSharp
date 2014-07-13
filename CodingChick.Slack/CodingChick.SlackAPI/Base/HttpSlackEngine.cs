using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodingChick.SlackAPI.Base
{
    public class HttpSlackEngine
    {
        private HttpClientAccessor _httpClientAccessor;

        public string BaseApiAddress
        {
            get
            {
                return "https://slack.com/api/";
            }
        }

        public string ApplicationToken { get; set; }

        public HttpSlackEngine()
        {
            _httpClientAccessor = new HttpClientAccessor();
        }

        //TODO: this works with API address
        public async Task<HttpContent> GetAsyncWithToken(string method, List<KeyValuePair<string, string>> queryParams)
        {
            queryParams.Add(new KeyValuePair<string, string>("token", ApplicationToken));
            var result = await CallGetAsync(method, queryParams);
            return result;
        }


        private async Task<HttpContent> CallGetAsync(string method, List<KeyValuePair<string, string>> queryParams)
        {
            string finalAddress = HttpUtilityHelper.CreateFullAddess(BaseApiAddress, method, queryParams);
            var result = await _httpClientAccessor.GetAsync(finalAddress);
            return result;
        }


       
    }
}
