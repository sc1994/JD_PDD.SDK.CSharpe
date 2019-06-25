using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 通过subUnionId获取推广链接【申请】--请求参数
    /// 通过商品链接、领券链接、活动链接获取普通推广链接或优惠券二合一推广链接，支持传入subunionid参数，可用于区分媒体自身的用户ID。需向cps-qxsq@jd.com申请权限。功能同宙斯接口的优惠券,商品二合一转接API-通过subUnionId获取推广链接、联盟微信手q通过subUnionId获取推广链接。
    /// jd.union.open.promotion.bysubunionid.get
    /// https://union.jd.com/openplatform/api/634
    /// </summary>
    public class JdUnionOpenPromotionBysubunionidGetRequest : JdBaseRequest
    {
        public JdUnionOpenPromotionBysubunionidGetRequest() { }

        public JdUnionOpenPromotionBysubunionidGetRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.promotion.bysubunionid.get";

        protected override string ParamName => "promotionCodeReq";

        public async Task<JdBaseResponse<JdUnionOpenPromotionBysubunionidGetResponse>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenPromotionBysubunionidGetResponse>>();

        /// <summary>
        /// 必填
        /// 描述：推广物料链接，建议链接使用微Q前缀，能较好适配微信手Q页面
        /// 例如：https://wqitem.jd.com/item/view?sku=23484023378
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MaterialId { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：子联盟ID（需要联系运营开通权限才能拿到数据）
        /// 例如：618_18_c35***e6a
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SubUnionId { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：推广位ID
        /// 例如：6
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? PositionId { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：子帐号身份标识，格式为子站长ID_子站长网站ID_子站长推广位ID
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
        /// <summary>
        /// 不必填
        /// 描述：转链类型，1：长链， 2 ：短链 ，3： 长链+短链，默认短链
        /// 例如：1
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? ChainType { get; set; }
    }



    /// <summary>
    /// 通过subUnionId获取推广链接【申请】--响应参数
    /// 通过商品链接、领券链接、活动链接获取普通推广链接或优惠券二合一推广链接，支持传入subunionid参数，可用于区分媒体自身的用户ID。需向cps-qxsq@jd.com申请权限。功能同宙斯接口的优惠券,商品二合一转接API-通过subUnionId获取推广链接、联盟微信手q通过subUnionId获取推广链接。
    /// jd.union.open.promotion.bysubunionid.get
    /// </summary>
    public class JdUnionOpenPromotionBysubunionidGetResponse
    {
        /// <summary>
        /// 描述：生成的推广目标链接，以短链接形式，有效期60天
        /// 例如：https://u.jd.com/XXXXX
        /// </summary>
        public string ShortURL { get; set; }
        /// <summary>
        /// 描述：生成推广目标的长链，长期有效
        /// 例如：https://union-click.jd.com/jdc?e=XXXXXX&amp;p=XXXXXXXXXXX
        /// </summary>
        public string ClickURL { get; set; }
    }

}

