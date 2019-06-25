using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 获取通用推广链接--请求参数
    /// 网站/APP来获取的推广链接，功能同宙斯接口的自定义链接转换、 APP领取代码接口通过商品链接、活动链接获取普通推广链接，支持传入subunionid参数，可用于区分媒体自身的用户ID。
    /// jd.union.open.promotion.common.get
    /// https://union.jd.com/openplatform/api/691
    /// </summary>
    public class JdUnionOpenPromotionCommonGetRequest : JdBaseRequest
    {
        public JdUnionOpenPromotionCommonGetRequest() { }

        public JdUnionOpenPromotionCommonGetRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.promotion.common.get";

        protected override string ParamName => "promotionCodeReq";

        public async Task<JdBaseResponse<JdUnionOpenPromotionCommonGetResponse>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenPromotionCommonGetResponse>>();

        /// <summary>
        /// 必填
        /// 描述：推广物料
        /// 例如：https://item.jd.com/23484023378.html
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MaterialId { get; set; }
        /// <summary>
        /// 必填
        /// 描述：站点ID是指在联盟后台的推广管理中的网站Id、APPID（通用转链接口禁止使用社交媒体id入参）
        /// 例如：435676
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SiteId { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：推广位id
        /// 例如：6
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? PositionId { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：子联盟ID（需要联系运营开通权限才能拿到数据）
        /// 例如：618_18_c35***e6a
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SubUnionId { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：推客生成推广链接时传入的扩展字段（查看订单对应字段信息，需要联系运营开放白名单才能看到）
        /// 例如：100_618_618
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Ext1 { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：请勿再使用，后续会移除此参数，请求成功一律返回https协议链接
        /// 例如：已废弃
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Protocol { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：联盟子站长身份标识，格式：子站长ID_子站长网站ID_子站长推广位ID
        /// 例如：618_618_6018
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Pid { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：优惠券领取链接，在使用优惠券、商品二合一功能时入参，且materialId须为商品详情页链接
        /// 例如：http://coupon.jd.com/ilink/get/get_coupon.action?XXXXXXX
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CouponUrl { get; set; }
    }



    /// <summary>
    /// 获取通用推广链接--响应参数
    /// 网站/APP来获取的推广链接，功能同宙斯接口的自定义链接转换、 APP领取代码接口通过商品链接、活动链接获取普通推广链接，支持传入subunionid参数，可用于区分媒体自身的用户ID。
    /// jd.union.open.promotion.common.get
    /// </summary>
    public class JdUnionOpenPromotionCommonGetResponse
    {
        /// <summary>
        /// 描述：生成的目标推广链接，长期有效
        /// 例如：http://union-click.jd.com/jdc?XXXXXXXXXX
        /// </summary>
        public string ClickURL { get; set; }
    }

}

