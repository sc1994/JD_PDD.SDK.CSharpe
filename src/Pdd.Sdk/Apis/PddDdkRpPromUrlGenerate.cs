using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 生成红包推广链接--请求参数
    /// 生成红包推广链接接口
    /// pdd.ddk.rp.prom.url.generate
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.rp.prom.url.generate
    /// </summary>
    public class PddDdkRpPromUrlGenerateRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.rp.prom.url.generate";

        public PddDdkRpPromUrlGenerateRequest() { }

        public PddDdkRpPromUrlGenerateRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkRpPromUrlGenerateResponse> InvokeAsync()
            => await PostAsync<PddDdkRpPromUrlGenerateResponse>();
        /// <summary>
        /// 不必填
        /// 是否生成短链接。true-是，false-否，默认false
        /// </summary>
        public bool? GenerateShortUrl { get; set; }
        /// <summary>
        /// 必填
        /// 推广位列表，例如：["60005_612"]
        /// </summary>
        public string[] PIdList { get; set; }
        /// <summary>
        /// 不必填
        /// 自定义参数，为链接打上自定义标签。自定义参数最长限制64个字节。
        /// </summary>
        public string CustomParameters { get; set; }
        /// <summary>
        /// 必填
        /// 是否唤起微信客户端， 默认false 否，true 是
        /// </summary>
        public bool? GenerateWeappWebview { get; set; }
        /// <summary>
        /// 不必填
        /// 唤起微信app推广短链接
        /// </summary>
        public bool? WeAppWebViewShortUrl { get; set; }
        /// <summary>
        /// 不必填
        /// 唤起微信app推广链接
        /// </summary>
        public bool? WeAppWebWiewUrl { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成小程序推广
        /// </summary>
        public bool? GenerateWeApp { get; set; }
    }


    /// <summary>
    /// 生成红包推广链接--响应参数
    /// 生成红包推广链接接口
    /// </summary>
    public class PddDdkRpPromUrlGenerateResponse : PddBaseResponse
    {
        /// <summary>
        /// 红包推广链接返回对象
        /// </summary>
        [JsonProperty("rp_promotion_url_generate_response")]
        public PddDdkRpPromUrlGenerate_RpPromotionUrlGenerateResponse RpPromotionUrlGenerateResponse { get; set; }
    }

    /// <summary>
    /// url_list
    /// </summary>
    public class PddDdkRpPromUrlGenerate_UrlList
    {
        /// <summary>
        /// 红包推广链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 红包推广短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 红包推广移动链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 红包推广移动短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 红包推广多人团链接
        /// </summary>
        [JsonProperty("multi_group_url")]
        public string MultiGroupUrl { get; set; }
        /// <summary>
        /// 红包推广多人团短链接
        /// </summary>
        [JsonProperty("multi_group_short_url")]
        public string MultiGroupShortUrl { get; set; }
        /// <summary>
        /// 红包推广多人团移动链接
        /// </summary>
        [JsonProperty("multi_group_mobile_url")]
        public string MultiGroupMobileUrl { get; set; }
        /// <summary>
        /// 红包推广多人团移动短链接
        /// </summary>
        [JsonProperty("multi_group_mobile_short_url")]
        public string MultiGroupMobileShortUrl { get; set; }
    }
    /// <summary>
    /// 红包推广链接返回对象
    /// </summary>
    public class PddDdkRpPromUrlGenerate_RpPromotionUrlGenerateResponse
    {
        /// <summary>
        /// url_list
        /// </summary>
        [JsonProperty("url_list")]
        public PddDdkRpPromUrlGenerate_UrlList[] UrlList { get; set; }
    }
}

