using System.Threading.Tasks;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 通过unionId获取推广链接【申请】--请求参数
    /// 工具商媒体帮助子站长获取普通推广链接和优惠券二合一推广链接，可传入PID参数以区分子站长的推广位，该参数可在订单查询接口返回。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.promotion.byunionid.get
    /// </summary>
    public class JdUnionOpenPromotionByunionidGetRequest : JdBaseRequest
    {
        public JdUnionOpenPromotionByunionidGetRequest() { }

        public JdUnionOpenPromotionByunionidGetRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.promotion.byunionid.get";

        protected override string ParamName => "promotionCodeReq";

        public async Task<JdBaseResponse<JdUnionOpenPromotionByunionidGetResponse>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenPromotionByunionidGetResponse>>();

        /// <summary>
        /// 描述：推广物料链接，建议链接使用微Q前缀，能较好适配微信手Q页面
        /// 必填：true
        /// 例如：https://wqitem.jd.com/item/view?sku=23484023378
        /// </summary>
        public string materialId { get; set; }
        /// <summary>
        /// 描述：目标推客的联盟ID
        /// 必填：true
        /// 例如：10000618
        /// </summary>
        public long unionId { get; set; }
        /// <summary>
        /// 描述：新增推广位id （不填的话，为其默认生成一个唯一此接口推广位-名称：微信手Q短链接）
        /// 必填：false
        /// 例如：6
        /// </summary>
        public long positionId { get; set; }
        /// <summary>
        /// 描述：子帐号身份标识，格式为子站长ID_子站长网站ID_子站长推广位ID
        /// 必填：false
        /// 例如：618_618_6018
        /// </summary>
        public string pid { get; set; }
        /// <summary>
        /// 描述：优惠券领取链接，在使用优惠券、商品二合一功能时入参，且materialId须为商品详情页链接
        /// 必填：false
        /// 例如：http://coupon.jd.com/ilink/get/get_coupon.action?XXXXXXX
        /// </summary>
        public string couponUrl { get; set; }
        /// <summary>
        /// 描述：子联盟ID（需要联系运营开通权限才能拿到数据）
        /// 必填：false
        /// 例如：618_18_c35***e6a
        /// </summary>
        public string subUnionId { get; set; }
        /// <summary>
        /// 描述：转链类型，1：长链， 2 ：短链 ，3： 长链+短链，默认短链
        /// 必填：false
        /// 例如：1
        /// </summary>
        public int chainType { get; set; }
    }



    /// <summary>
    /// 通过unionId获取推广链接【申请】--响应参数
    /// 工具商媒体帮助子站长获取普通推广链接和优惠券二合一推广链接，可传入PID参数以区分子站长的推广位，该参数可在订单查询接口返回。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.promotion.byunionid.get
    /// </summary>
    public class JdUnionOpenPromotionByunionidGetResponse
    {
        /// <summary>
        /// 描述：生成的推广目标链接，以短链接形式，有效期60天
        /// 必填：true
        /// 例如：https://u.jd.com/XXXXX
        /// </summary>
        public string shortURL { get; set; }
        /// <summary>
        /// 描述：生成推广目标的长链，长期有效
        /// 必填：true
        /// 例如：https://union-click.jd.com/jdc?e=XXXXXX&amp;p=XXXXXXXXXXX
        /// </summary>
        public string clickURL { get; set; }
    }
}

