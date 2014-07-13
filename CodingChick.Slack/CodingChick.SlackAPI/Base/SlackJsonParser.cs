using Newtonsoft.Json;

namespace CodingChick.SlackAPI.Base
{
    public class SlackJsonParser
    {
        public T ParseDataResponse<T>(string dataResponse)
        {
            var parsedDataResponse = JsonConvert.DeserializeObject<T>(dataResponse);
            return parsedDataResponse;
        }

        public string GetJson<T>(T objectToSerialize) 
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}