using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 生成商城-频道推广链接--请求参数
    /// 生成商城推广链接接口
    /// pdd.ddk.cms.prom.url.generate
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.cms.prom.url.generate
    /// </summary>
    public class PddDdkCmsPromUrlGenerateRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.cms.prom.url.generate";

        public PddDdkCmsPromUrlGenerateRequest() { }

        public PddDdkCmsPromUrlGenerateRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkCmsPromUrlGenerateResponse> InvokeAsync()
            => await PostAsync<PddDdkCmsPromUrlGenerateResponse>();
        /// <summary>
        /// 不必填
        /// 是否生成短链接，true-是，false-否
        /// 例如：true
        /// </summary>
        public bool? GenerateShortUrl { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成手机跳转链接。true-是，false-否，默认false
        /// 例如：true
        /// </summary>
        public bool? GenerateMobile { get; set; }
        /// <summary>
        /// 不必填
        /// 单人团多人团标志。true-多人团，false-单人团 默认false
        /// 例如：true
        /// </summary>
        public bool? MultiGroup { get; set; }
        /// <summary>
        /// 不必填
        /// 自定义参数，为链接打上自定义标签。自定义参数最长限制64个字节。
        /// 例如：tag
        /// </summary>
        public string CustomParameters { get; set; }
        /// <summary>
        /// 不必填
        /// 是否唤起微信客户端， 默认false 否，true 是
        /// 例如：false
        /// </summary>
        public bool? GenerateWeappWebview { get; set; }
        /// <summary>
        /// 必填
        /// 唤起微信app推广短链接
        /// 例如：http://test.url
        /// </summary>
        public bool? WeAppWebViewShortUrl { get; set; }
        /// <summary>
        /// 必填
        /// 唤起微信app推广链接
        /// 例如：http://test.url
        /// </summary>
        public bool? WeAppWebViewUrl { get; set; }
        /// <summary>
        /// 不必填
        /// 0, "1.9包邮"；1, "今日爆款"； 2, "品牌清仓"； 4,"PC端专属商城"
        /// 例如：0
        /// </summary>
        public int? ChannelType { get; set; }
        /// <summary>
        /// 必填
        /// 推广位列表，例如：["60005_612"]
        /// </summary>
        public string[] PIdList { get; set; }
    }


    /// <summary>
    /// 生成商城-频道推广链接--响应参数
    /// 生成商城推广链接接口
    /// </summary>
    public class PddDdkCmsPromUrlGenerateResponse : PddBaseResponse
    {
        /// <summary>
        /// total
        /// 例如：100
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; }
        /// <summary>
        /// 链接列表
        /// </summary>
        [JsonProperty("url_list")]
        public PddDdkCmsPromUrlGenerate_UrlList[] UrlList { get; set; }
    }

    /// <summary>
    /// 双人团链接列表
    /// </summary>
    public class PddDdkCmsPromUrlGenerate_MultiUrlList
    {
        /// <summary>
        /// 双人团唤醒拼多多app长链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 双人团唤醒拼多多app短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 双人团唤醒微信链接
        /// </summary>
        [JsonProperty("we_app_web_view_url")]
        public string WeAppWebViewUrl { get; set; }
        /// <summary>
        /// 双人团长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 双人团短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 双人团唤醒微信短链接
        /// </summary>
        [JsonProperty("we_app_web_view_short_url")]
        public string WeAppWebViewShortUrl { get; set; }
    }
    /// <summary>
    /// 单人团链接列表
    /// </summary>
    public class PddDdkCmsPromUrlGenerate_SingleUrlList
    {
        /// <summary>
        /// 唤醒拼多多app长链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 唤醒拼多多app短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 唤醒微信链接
        /// </summary>
        [JsonProperty("we_app_web_view_url")]
        public string WeAppWebViewUrl { get; set; }
        /// <summary>
        /// 长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 唤醒微信短链接
        /// </summary>
        [JsonProperty("we_app_web_view_short_url")]
        public string WeAppWebViewShortUrl { get; set; }
    }
    /// <summary>
    /// 链接列表
    /// </summary>
    public class PddDdkCmsPromUrlGenerate_UrlList
    {
        /// <summary>
        /// 多人团唤醒微信推广长链接
        /// </summary>
        [JsonProperty("multi_we_app_web_view_url")]
        public string MultiWeAppWebViewUrl { get; set; }
        /// <summary>
        /// 双人团链接列表
        /// </summary>
        [JsonProperty("multi_url_list")]
        public PddDdkCmsPromUrlGenerate_MultiUrlList MultiUrlList { get; set; }
        /// <summary>
        /// 多人团唤醒拼多多app链接
        /// </summary>
        [JsonProperty("multi_group_mobile_short_url")]
        public string MultiGroupMobileShortUrl { get; set; }
        /// <summary>
        /// 唤醒拼多多app链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// CPSsign
        /// 例如：CM1891891_26364337_0c06f43f39cc6829be275d7067c31db5
        /// </summary>
        [JsonProperty("sign")]
        public string Sign { get; set; }
        /// <summary>
        /// 多人团唤醒微信推广短链接
        /// </summary>
        [JsonProperty("multi_we_app_web_view_short_url")]
        public string MultiWeAppWebViewShortUrl { get; set; }
        /// <summary>
        /// 多人团唤醒拼多多app长链接
        /// </summary>
        [JsonProperty("multi_group_mobile_url")]
        public string MultiGroupMobileUrl { get; set; }
        /// <summary>
        /// h5长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// h5短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 单人团链接列表
        /// </summary>
        [JsonProperty("single_url_list")]
        public PddDdkCmsPromUrlGenerate_SingleUrlList SingleUrlList { get; set; }
        /// <summary>
        /// 多人团长链
        /// </summary>
        [JsonProperty("multi_group_url")]
        public string MultiGroupUrl { get; set; }
        /// <summary>
        /// 多人团短链
        /// </summary>
        [JsonProperty("multi_group_short_url")]
        public string MultiGroupShortUrl { get; set; }
        /// <summary>
        /// 唤醒拼多多app短链
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 唤醒微信长链
        /// </summary>
        [JsonProperty("we_app_web_view_url")]
        public string WeAppWebViewUrl { get; set; }
        /// <summary>
        /// 唤醒微信短链
        /// </summary>
        [JsonProperty("we_app_web_view_short_url")]
        public string WeAppWebViewShortUrl { get; set; }
    }
}

