using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多客生成店铺推广链接API--请求参数
    /// 多多客工具生成店铺推广链接API
    /// pdd.ddk.mall.url.gen
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.mall.url.gen
    /// </summary>
    public class PddDdkMallUrlGenRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.mall.url.gen";

        public PddDdkMallUrlGenRequest() { }

        public PddDdkMallUrlGenRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkMallUrlGenResponse> InvokeAsync()
            => await PostAsync<PddDdkMallUrlGenResponse>();
        /// <summary>
        /// 必填
        /// 店铺id
        /// </summary>
        public long? MallId { get; set; }
        /// <summary>
        /// 必填
        /// 推广位
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成唤起微信客户端链接，true-是，false-否，默认false
        /// </summary>
        public bool? GenerateWeappWebview { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成短链接，true-是，false-否
        /// </summary>
        public bool? GenerateShortUrl { get; set; }
        /// <summary>
        /// 不必填
        /// true--生成多人团推广链接 false--生成单人团推广链接（默认false）1、单人团推广链接：用户访问单人团推广链接，可直接购买商品无需拼团。2、多人团推广链接：用户访问双人团推广链接开团，若用户分享给他人参团，则开团者和参团者的佣金均结算给推手
        /// </summary>
        public bool? MultiGroup { get; set; }
        /// <summary>
        /// 不必填
        /// 自定义参数，为链接打上自定义标签。自定义参数最长限制64个字节
        /// </summary>
        public string CustomParameters { get; set; }
    }


    /// <summary>
    /// 多多客生成店铺推广链接API--响应参数
    /// 多多客工具生成店铺推广链接API
    /// </summary>
    public class PddDdkMallUrlGenResponse : PddBaseResponse
    {
        /// <summary>
        /// mall_coupon_generate_url_response
        /// </summary>
        [JsonProperty("mall_coupon_generate_url_response")]
        public PddDdkMallUrlGen_MallCouponGenerateUrlResponse MallCouponGenerateUrlResponse { get; set; }
    }

    /// <summary>
    /// 推广链接
    /// </summary>
    public class PddDdkMallUrlGen_List
    {
        /// <summary>
        /// 推广长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 推广短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 唤醒拼多多app的推广长链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 唤醒拼多多app的推广短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 唤起微信app推广链接
        /// </summary>
        [JsonProperty("we_app_web_view_url")]
        public string WeAppWebViewUrl { get; set; }
        /// <summary>
        /// 唤起微信app推广短链接
        /// </summary>
        [JsonProperty("we_app_web_view_short_url")]
        public string WeAppWebViewShortUrl { get; set; }
    }
    /// <summary>
    /// mall_coupon_generate_url_response
    /// </summary>
    public class PddDdkMallUrlGen_MallCouponGenerateUrlResponse
    {
        /// <summary>
        /// 推广链接
        /// </summary>
        [JsonProperty("list")]
        public PddDdkMallUrlGen_List[] List { get; set; }
    }
}

