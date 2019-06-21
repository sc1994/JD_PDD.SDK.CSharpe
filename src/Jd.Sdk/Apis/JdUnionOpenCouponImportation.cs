using System.Threading.Tasks;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 优惠券导入【申请】--请求参数
    /// 将商品SKUID和领券链接导入，之后其他媒体均可通过联盟开放平台搜索到该商品和优惠券。通常适用于招商媒体。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.coupon.importation
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
        /// 描述：商品ID
        /// 必填：true
        /// 例如：23335727609
        /// </summary>
        public long skuId { get; set; }
        /// <summary>
        /// 描述：优惠券链接
        /// 必填：true
        /// 例如：http://coupon.jd.com/ilink/get/get_coupon.action?XXXXXXX
        /// </summary>
        public string couponLink { get; set; }
    }



    //--------------------------------------
    // 返回值没有data内容，直接使用基础响应基类
    //--------------------------------------
}

