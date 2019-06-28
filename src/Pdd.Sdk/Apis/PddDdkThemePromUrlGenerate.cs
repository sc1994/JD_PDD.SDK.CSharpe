using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多进宝主题推广链接生成--请求参数
    /// 多多进宝主题活动推广链接生成
    /// pdd.ddk.theme.prom.url.generate
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.theme.prom.url.generate
    /// </summary>
    public class PddDdkThemePromUrlGenerateRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.theme.prom.url.generate";

        public PddDdkThemePromUrlGenerateRequest() { }

        public PddDdkThemePromUrlGenerateRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkThemePromUrlGenerateResponse> InvokeAsync()
            => await PostAsync<PddDdkThemePromUrlGenerateResponse>();
        /// <summary>
        /// 必填
        /// 推广位ID
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// 必填
        /// 主题ID列表,例如[1,235]
        /// </summary>
        public long[] ThemeIdList { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成短链接,true-是,false-否
        /// </summary>
        public bool? GenerateShortUrl { get; set; }
        /// <summary>
        /// 不必填
        /// 是否生成手机跳转链接。true-是,false-否,默认false
        /// </summary>
        public bool? GenerateMobile { get; set; }
        /// <summary>
        /// 不必填
        /// 自定义参数,为链接打上自定义标签。自定义参数最长限制64个字节。
        /// </summary>
        public string CustomParameters { get; set; }
        /// <summary>
        /// 不必填
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
        /// 是否生成小程序链接
        /// </summary>
        public bool? GenerateWeApp { get; set; }
    }


    /// <summary>
    /// 多多进宝主题推广链接生成--响应参数
    /// 多多进宝主题活动推广链接生成
    /// </summary>
    public class PddDdkThemePromUrlGenerateResponse : PddBaseResponse
    {
        /// <summary>
        /// 主题活动推广返回对象
        /// </summary>
        [JsonProperty("theme_promotion_url_generate_response")]
        public PddDdkThemePromUrlGenerate_ThemePromotionUrlGenerateResponse ThemePromotionUrlGenerateResponse { get; set; }
    }

    /// <summary>
    /// 小程序信息
    /// </summary>
    public class PddDdkThemePromUrlGenerate_WeAppInfo
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
        public int? UserName { get; set; }
        /// <summary>
        /// 小程序标题
        /// </summary>
        [JsonProperty("title")]
        public int? Title { get; set; }
        /// <summary>
        /// 拼多多小程序id
        /// </summary>
        [JsonProperty("app_id")]
        public int? AppId { get; set; }
    }
    /// <summary>
    /// 主题活动推广url列表
    /// </summary>
    public class PddDdkThemePromUrlGenerate_UrlList
    {
        /// <summary>
        /// 主题活动推广链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 主题活动推广短链
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 主题活动推广移动链接
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 主题活动推广移动短链接
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 主题活动推广开团链接
        /// </summary>
        [JsonProperty("multi_group_url")]
        public string MultiGroupUrl { get; set; }
        /// <summary>
        /// 主题活动推广开团短链接
        /// </summary>
        [JsonProperty("multi_group_short_url")]
        public string MultiGroupShortUrl { get; set; }
        /// <summary>
        /// 主题活动推广开团移动端链接
        /// </summary>
        [JsonProperty("multi_group_mobile_url")]
        public string MultiGroupMobileUrl { get; set; }
        /// <summary>
        /// 主题活动推广开团移动端短链接
        /// </summary>
        [JsonProperty("multi_group_mobile_short_url")]
        public string MultiGroupMobileShortUrl { get; set; }
        /// <summary>
        /// 小程序信息
        /// </summary>
        [JsonProperty("we_app_info")]
        public PddDdkThemePromUrlGenerate_WeAppInfo WeAppInfo { get; set; }
    }
    /// <summary>
    /// 主题活动推广返回对象
    /// </summary>
    public class PddDdkThemePromUrlGenerate_ThemePromotionUrlGenerateResponse
    {
        /// <summary>
        /// 主题活动推广url列表
        /// </summary>
        [JsonProperty("url_list")]
        public PddDdkThemePromUrlGenerate_UrlList[] UrlList { get; set; }
    }
}

