using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多进宝推广链接生成--请求参数
    /// 生成普通商品推广链接
    /// pdd.ddk.goods.promotion.url.generate
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.goods.promotion.url.generate
    /// </summary>
    public class PddDdkGoodsPromotionUrlGenerateRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.goods.promotion.url.generate";

        public PddDdkGoodsPromotionUrlGenerateRequest() { }

        public PddDdkGoodsPromotionUrlGenerateRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkGoodsPromotionUrlGenerateResponse> InvokeAsync()
            => await PostAsync<PddDdkGoodsPromotionUrlGenerateResponse>();
        /// <summary>
        /// 必填
        /// 推广位ID
        /// </summary>
        public string PId { get; set; }
        /// <summary>
        /// 必填
        /// 商品ID，仅支持单个查询
        /// </summary>
        public long[] GoodsIdList { get; set; }
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
        /// 自定义参数，为链接打上自定义标签。自定义参数最长限制64个字节。
        /// </summary>
        public string CustomParameters { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成唤起微信客户端链接，true-是，false-否，默认false
        /// </summary>
        public bool? GenerateWeappWebview { get; set; }
        /// <summary>
        /// 不必填
        /// 招商多多客ID
        /// </summary>
        public long? ZsDuoId { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成小程序推广
        /// </summary>
        public bool? GenerateWeApp { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成微博推广链接
        /// 默认值：false
        /// 例如：false
        /// </summary>
        public bool? GenerateWeiboappWebview { get; set; }
    }


    /// <summary>
    /// 多多进宝推广链接生成--响应参数
    /// 生成普通商品推广链接
    /// </summary>
    public class PddDdkGoodsPromotionUrlGenerateResponse : PddBaseResponse
    {
        /// <summary>
        /// response
        /// </summary>
        [JsonProperty("goods_promotion_url_generate_response")]
        public PddDdkGoodsPromotionUrlGenerate_GoodsPromotionUrlGenerateResponse GoodsPromotionUrlGenerateResponse { get; set; }
    }

    /// <summary>
    /// 小程序信息
    /// </summary>
    public class PddDdkGoodsPromotionUrlGenerate_WeAppInfo
    {
        /// <summary>
        /// 小程序图片
        /// </summary>
        [JsonProperty("we_app_icon_url")]
        public string WeAppIconUrl { get; set; }
        /// <summary>
        /// Banner图
        /// </summary>
        [JsonProperty("banner_url")]
        public string BannerUrl { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("desc")]
        public string Desc { get; set; }
        /// <summary>
        /// 来源名
        /// </summary>
        [JsonProperty("source_display_name")]
        public string SourceDisplayName { get; set; }
        /// <summary>
        /// 小程序path值
        /// </summary>
        [JsonProperty("page_path")]
        public string PagePath { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// 小程序标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// 拼多多小程序id
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }
    }
    /// <summary>
    /// 多多进宝推广链接对象列表
    /// </summary>
    public class PddDdkGoodsPromotionUrlGenerate_GoodsPromotionUrlList
    {
        /// <summary>
        /// 唤起微信app推广短链接
        /// </summary>
        [JsonProperty("we_app_web_view_short_url")]
        public string WeAppWebViewShortUrl { get; set; }
        /// <summary>
        /// 唤起微信app推广链接
        /// </summary>
        [JsonProperty("we_app_web_view_url")]
        public string WeAppWebViewUrl { get; set; }
        /// <summary>
        /// 唤醒拼多多app的推广短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 唤醒拼多多app的推广长链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 推广短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 推广长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 小程序信息
        /// </summary>
        [JsonProperty("we_app_info")]
        public PddDdkGoodsPromotionUrlGenerate_WeAppInfo WeAppInfo { get; set; }
        /// <summary>
        /// 微博推广短链接
        /// </summary>
        [JsonProperty("weibo_app_web_view_short_url")]
        public string WeiboAppWebViewShortUrl { get; set; }
        /// <summary>
        /// 微博推广链接
        /// </summary>
        [JsonProperty("weibo_app_web_view_url")]
        public string WeiboAppWebViewUrl { get; set; }
    }
    /// <summary>
    /// response
    /// </summary>
    public class PddDdkGoodsPromotionUrlGenerate_GoodsPromotionUrlGenerateResponse
    {
        /// <summary>
        /// 多多进宝推广链接对象列表
        /// </summary>
        [JsonProperty("goods_promotion_url_list")]
        public PddDdkGoodsPromotionUrlGenerate_GoodsPromotionUrlList[] GoodsPromotionUrlList { get; set; }
    }
}

