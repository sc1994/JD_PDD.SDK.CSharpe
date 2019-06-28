using Newtonsoft.Json;

namespace Pdd.Sdk
{
    public abstract class PddBaseResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}