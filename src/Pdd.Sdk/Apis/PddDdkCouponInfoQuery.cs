using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 查询优惠券信息--请求参数
    /// 查询优惠券信息
    /// pdd.ddk.coupon.info.query
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.coupon.info.query
    /// </summary>
    public class PddDdkCouponInfoQueryRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.coupon.info.query";

        public PddDdkCouponInfoQueryRequest() { }

        public PddDdkCouponInfoQueryRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkCouponInfoQueryResponse> InvokeAsync()
            => await PostAsync<PddDdkCouponInfoQueryResponse>();
        /// <summary>
        /// 必填
        /// 优惠券id
        /// </summary>
        public string[] CouponIds { get; set; }
    }


    /// <summary>
    /// 查询优惠券信息--响应参数
    /// 查询优惠券信息
    /// </summary>
    public class PddDdkCouponInfoQueryResponse : PddBaseResponse
    {
        /// <summary>
        /// ddk_coupon_info_query
        /// </summary>
        [JsonProperty("ddk_coupon_info_query_response")]
        public PddDdkCouponInfoQuery_DdkCouponInfoQueryResponse DdkCouponInfoQueryResponse { get; set; }
    }

    /// <summary>
    /// list
    /// </summary>
    public class PddDdkCouponInfoQuery_List
    {
        /// <summary>
        /// 优惠券结束时间
        /// </summary>
        [JsonProperty("coupon_end_time")]
        public long? CouponEndTime { get; set; }
        /// <summary>
        /// 优惠券id
        /// </summary>
        [JsonProperty("coupon_id")]
        public string CouponId { get; set; }
        /// <summary>
        /// 优惠券开始时间
        /// </summary>
        [JsonProperty("coupon_start_time")]
        public long? CouponStartTime { get; set; }
        /// <summary>
        /// 优惠券类型, 45:多多进宝商品优惠券  87:淘客定向商品券  204:招商商品优惠券  225:店铺折扣券
        /// </summary>
        [JsonProperty("coupon_type")]
        public int? CouponType { get; set; }
        /// <summary>
        /// 优惠券面额 单位：分
        /// </summary>
        [JsonProperty("discount")]
        public long? Discount { get; set; }
        /// <summary>
        /// 优惠券总量
        /// </summary>
        [JsonProperty("init_quantity")]
        public long? InitQuantity { get; set; }
        /// <summary>
        /// 优惠券剩余数量
        /// </summary>
        [JsonProperty("remain_quantity")]
        public long? RemainQuantity { get; set; }
    }
    /// <summary>
    /// ddk_coupon_info_query
    /// </summary>
    public class PddDdkCouponInfoQuery_DdkCouponInfoQueryResponse
    {
        /// <summary>
        /// list
        /// </summary>
        [JsonProperty("list")]
        public PddDdkCouponInfoQuery_List[] List { get; set; }
    }
}

