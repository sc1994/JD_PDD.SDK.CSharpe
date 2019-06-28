using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 生成多多进宝频道推广--请求参数
    /// 生成拼多多主站频道推广
    /// pdd.ddk.resource.url.gen
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.resource.url.gen
    /// </summary>
    public class PddDdkResourceUrlGenRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.resource.url.gen";

        public PddDdkResourceUrlGenRequest() { }

        public PddDdkResourceUrlGenRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkResourceUrlGenResponse> InvokeAsync()
            => await PostAsync<PddDdkResourceUrlGenResponse>();
        /// <summary>
        /// 不必填
        /// 自定义参数，为链接打上自定义标签。自定义参数最长限制64个字节
        /// </summary>
        public string CustomParameters { get; set; }
        /// <summary>
        /// 必填
        /// 推广位
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// 不必填
        /// 频道来源：4-限时秒杀,39997-充值中心, 39998-转链type，39999-电器城
        /// </summary>
        public int? ResourceType { get; set; }
        /// <summary>
        /// 不必填
        /// 原链接
        /// </summary>
        public string Url { get; set; }
    }


    /// <summary>
    /// 生成多多进宝频道推广--响应参数
    /// 生成拼多多主站频道推广
    /// </summary>
    public class PddDdkResourceUrlGenResponse : PddBaseResponse
    {
        /// <summary>
        /// resource_url_response
        /// </summary>
        [JsonProperty("resource_url_response")]
        public PddDdkResourceUrlGen_ResourceUrlResponse ResourceUrlResponse { get; set; }
    }

    /// <summary>
    /// 多人团链接
    /// </summary>
    public class PddDdkResourceUrlGen_MultiUrlList
    {
        /// <summary>
        /// 频道推广唤醒拼多多APP短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 频道推广唤醒拼多多APP长链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 频道推广短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 频道推广长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 小程序信息
        /// </summary>
        [JsonProperty("we_app_page_path")]
        public string WeAppPagePath { get; set; }
        /// <summary>
        /// 频道推广唤醒微信短链接
        /// </summary>
        [JsonProperty("we_app_web_view_short_url")]
        public string WeAppWebViewShortUrl { get; set; }
        /// <summary>
        /// 频道推广唤醒微信长链接
        /// </summary>
        [JsonProperty("we_app_web_view_url")]
        public string WeAppWebViewUrl { get; set; }
    }
    /// <summary>
    /// 单人团链接
    /// </summary>
    public class PddDdkResourceUrlGen_SingleUrlList
    {
        /// <summary>
        /// 频道推广唤醒拼多多APP短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 频道推广唤醒拼多多APP长链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 频道推广短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 频道推广长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 小程序信息
        /// </summary>
        [JsonProperty("we_app_page_path")]
        public string WeAppPagePath { get; set; }
        /// <summary>
        /// 频道推广唤醒微信短链接
        /// </summary>
        [JsonProperty("we_app_web_view_short_url")]
        public string WeAppWebViewShortUrl { get; set; }
        /// <summary>
        /// 频道推广唤醒微信长链接
        /// </summary>
        [JsonProperty("we_app_web_view_url")]
        public string WeAppWebViewUrl { get; set; }
    }
    /// <summary>
    /// resource_url_response
    /// </summary>
    public class PddDdkResourceUrlGen_ResourceUrlResponse
    {
        /// <summary>
        /// 多人团链接
        /// </summary>
        [JsonProperty("multi_url_list")]
        public PddDdkResourceUrlGen_MultiUrlList MultiUrlList { get; set; }
        /// <summary>
        /// 单人团链接
        /// </summary>
        [JsonProperty("single_url_list")]
        public PddDdkResourceUrlGen_SingleUrlList SingleUrlList { get; set; }
    }
}

