namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 优惠券领取情况查询接口【申请】--请求参数
    /// 通过领券链接查询优惠券的平台、面额、期限、可用状态、剩余数量等详细信息，通常用于和商品信息一起展示优惠券券信息。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.coupon.query
    /// </summary>
    public class JdUnionOpenCouponQueryRequest : JdBaseRequest
    {
        public JdUnionOpenCouponQueryRequest() { }

        public JdUnionOpenCouponQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.coupon.query";

        protected override string ParamName => "couponUrls";

        protected override object Param => couponUrls;

        /// <summary>
        /// 描述：优惠券链接集合；上限10（GET请求）；上限50（POST请求或SDK调用）
        /// 必填：true
        /// 例如：http://coupon.jd.com/ilink/get/get_coupon.action?XXXXXXX
        /// </summary>
        public string[] couponUrls { get; set; }

    }



    /// <summary>
    /// 优惠券领取情况查询接口【申请】--响应参数
    /// 通过领券链接查询优惠券的平台、面额、期限、可用状态、剩余数量等详细信息，通常用于和商品信息一起展示优惠券券信息。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.coupon.query
    /// </summary>
    public class JdUnionOpenCouponQueryResponse
    {
        /// <summary>
        /// 描述：券领取结束时间(时间戳，毫秒)
        /// 必填：true
        /// 例如：1532966460000
        /// </summary>
        public long takeEndTime { get; set; }
        /// <summary>
        /// 描述：券领取开始时间(时间戳，毫秒)
        /// 必填：true
        /// 例如：1531065600000
        /// </summary>
        public long takeBeginTime { get; set; }
        /// <summary>
        /// 描述：券剩余张数
        /// 必填：true
        /// 例如：9990
        /// </summary>
        public long remainNum { get; set; }
        /// <summary>
        /// 描述：券有效状态
        /// 必填：true
        /// 例如：是
        /// </summary>
        public string yn { get; set; }
        /// <summary>
        /// 描述：券总张数
        /// 必填：true
        /// 例如：10000
        /// </summary>
        public long num { get; set; }
        /// <summary>
        /// 描述：券消费限额
        /// 必填：true
        /// 例如：15
        /// </summary>
        public double quota { get; set; }
        /// <summary>
        /// 描述：券链接
        /// 必填：true
        /// 例如：http://coupon.jd.com/ilink/get/get_coupon.action?XXXXXXXXXXX
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// 描述：券面额
        /// 必填：true
        /// 例如：10
        /// </summary>
        public double discount { get; set; }
        /// <summary>
        /// 描述：券有效使用开始时间(时间戳，毫秒)
        /// 必填：true
        /// 例如：1531065600000
        /// </summary>
        public long beginTime { get; set; }
        /// <summary>
        /// 描述：券有效使用结束时间(时间戳，毫秒)
        /// 必填：true
        /// 例如：1533052799000
        /// </summary>
        public long endTime { get; set; }
        /// <summary>
        /// 描述：券使用平台
        /// 必填：true
        /// 例如：全平台
        /// </summary>
        public string platform { get; set; }
    }
}

