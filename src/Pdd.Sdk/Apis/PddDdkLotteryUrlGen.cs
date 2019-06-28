using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多客生成转盘抽免单url--请求参数
    /// 多多客工具生成转盘抽免单url
    /// pdd.ddk.lottery.url.gen
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.lottery.url.gen
    /// </summary>
    public class PddDdkLotteryUrlGenRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.lottery.url.gen";

        public PddDdkLotteryUrlGenRequest() { }

        public PddDdkLotteryUrlGenRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkLotteryUrlGenResponse> InvokeAsync()
            => await PostAsync<PddDdkLotteryUrlGenResponse>();
        /// <summary>
        /// 必填
        /// 推广位
        /// </summary>
        public string[] PidList { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成唤起微信客户端链接，true-是，false-否，默认false
        /// </summary>
        public bool? GenerateWeappWebview { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成短链接，true-是，false-否
        /// </summary>
        public string GenerateShortUrl { get; set; }
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
        /// 是否生成大转盘和主题的小程序推广链接
        /// </summary>
        public bool? GenerateWeApp { get; set; }
    }


    /// <summary>
    /// 多多客生成转盘抽免单url--响应参数
    /// 多多客工具生成转盘抽免单url
    /// </summary>
    public class PddDdkLotteryUrlGenResponse : PddBaseResponse
    {
        /// <summary>
        /// 返回总数
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; }
        /// <summary>
        /// 推广链接
        /// </summary>
        [JsonProperty("url_list")]
        public PddDdkLotteryUrlGen_UrlList[] UrlList { get; set; }
    }

    /// <summary>
    /// 转盘抽免单单人团链接
    /// </summary>
    public class PddDdkLotteryUrlGen_SingleUrlList
    {
        /// <summary>
        /// 转盘抽免单长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 转盘抽免单短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 转盘抽免单唤醒APP长链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 转盘抽免单唤醒APP短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 转盘抽免单唤醒微信长链接
        /// </summary>
        [JsonProperty("we_app_web_view_url")]
        public string WeAppWebViewUrl { get; set; }
        /// <summary>
        /// 转盘抽免单唤醒微信短链接
        /// </summary>
        [JsonProperty("we_app_web_view_short_url")]
        public string WeAppWebViewShortUrl { get; set; }
        /// <summary>
        /// 转盘抽免单小程序短链接
        /// </summary>
        [JsonProperty("we_app_page_path")]
        public string WeAppPagePath { get; set; }
    }
    /// <summary>
    /// 转盘抽免单多人团链接
    /// </summary>
    public class PddDdkLotteryUrlGen_MultiUrlList
    {
        /// <summary>
        /// 转盘抽免单长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 转盘抽免单短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 转盘抽免单唤醒拼多多APP长链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 转盘抽免单唤醒拼多多APP短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 转盘抽免单唤醒微信长链接
        /// </summary>
        [JsonProperty("we_app_web_view_url")]
        public string WeAppWebViewUrl { get; set; }
        /// <summary>
        /// 转盘抽免单唤醒微信短链接
        /// </summary>
        [JsonProperty("we_app_web_view_short_url")]
        public string WeAppWebViewShortUrl { get; set; }
        /// <summary>
        /// 转盘抽免单小程序链接
        /// </summary>
        [JsonProperty("we_app_page_path")]
        public string WeAppPagePath { get; set; }
    }
    /// <summary>
    /// 小程序信息
    /// </summary>
    public class PddDdkLotteryUrlGen_WeAppInfo
    {
        /// <summary>
        /// 小程序ID
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }
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
    }
    /// <summary>
    /// 推广链接
    /// </summary>
    public class PddDdkLotteryUrlGen_UrlList
    {
        /// <summary>
        /// 转盘抽免单单人团链接
        /// </summary>
        [JsonProperty("single_url_list")]
        public PddDdkLotteryUrlGen_SingleUrlList SingleUrlList { get; set; }
        /// <summary>
        /// 转盘抽免单多人团链接
        /// </summary>
        [JsonProperty("multi_url_list")]
        public PddDdkLotteryUrlGen_MultiUrlList MultiUrlList { get; set; }
        /// <summary>
        /// 自定义参数
        /// </summary>
        [JsonProperty("sign")]
        public string Sign { get; set; }
        /// <summary>
        /// 小程序信息
        /// </summary>
        [JsonProperty("we_app_info")]
        public PddDdkLotteryUrlGen_WeAppInfo WeAppInfo { get; set; }
    }
}

