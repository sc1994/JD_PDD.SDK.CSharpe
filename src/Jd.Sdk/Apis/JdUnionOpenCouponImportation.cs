using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 优惠券导入【申请】--请求参数
    /// 将商品SKUID和领券链接导入，之后其他媒体均可通过联盟开放平台搜索到该商品和优惠券。通常适用于招商媒体。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.coupon.importation
    /// https://union.jd.com/openplatform/api/696
    /// </summary>
    public class JdUnionOpenCouponImportationRequest : JdBaseRequest
    {
        public JdUnionOpenCouponImportationRequest() { }

        public JdUnionOpenCouponImportationRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.coupon.importation";

        protected override string ParamName => "couponReq";

        public async Task<JdBaseResponse> InvokeAsync()
            => await PostAsync<JdBaseResponse>();

        /// <summary>
        /// 必填
        /// 描述：商品ID
        /// 例如：23335727609
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? SkuId { get; set; }
        /// <summary>
        /// 必填
        /// 描述：优惠券链接
        /// 例如：http://coupon.jd.com/ilink/get/get_coupon.action?XXXXXXX
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CouponLink { get; set; }
    }



    //--------------------------------------
    // 返回值没有data内容，直接使用基础响应基类
    //--------------------------------------
}

