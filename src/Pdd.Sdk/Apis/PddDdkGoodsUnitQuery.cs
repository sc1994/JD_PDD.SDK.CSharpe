using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 查询商品的推广计划--请求参数
    /// 查询商品的推广计划
    /// pdd.ddk.goods.unit.query
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.goods.unit.query
    /// </summary>
    public class PddDdkGoodsUnitQueryRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.goods.unit.query";

        public PddDdkGoodsUnitQueryRequest() { }

        public PddDdkGoodsUnitQueryRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkGoodsUnitQueryResponse> InvokeAsync()
            => await PostAsync<PddDdkGoodsUnitQueryResponse>();
        /// <summary>
        /// 必填
        /// 商品id
        /// </summary>
        public long? GoodsId { get; set; }
        /// <summary>
        /// 不必填
        /// 招商duoId
        /// </summary>
        public long? ZsDuoId { get; set; }
    }


    /// <summary>
    /// 查询商品的推广计划--响应参数
    /// 查询商品的推广计划
    /// </summary>
    public class PddDdkGoodsUnitQueryResponse : PddBaseResponse
    {
        /// <summary>
        /// ddk_goods_unit_query_response
        /// </summary>
        [JsonProperty("ddk_goods_unit_query_response")]
        public PddDdkGoodsUnitQuery_DdkGoodsUnitQueryResponse DdkGoodsUnitQueryResponse { get; set; }
    }

    /// <summary>
    /// ddk_goods_unit_query_response
    /// </summary>
    public class PddDdkGoodsUnitQuery_DdkGoodsUnitQueryResponse
    {
        /// <summary>
        /// 优惠券结束时间，单位：秒
        /// </summary>
        [JsonProperty("coupon_end_time")]
        public long? CouponEndTime { get; set; }
        /// <summary>
        /// 优惠券id
        /// </summary>
        [JsonProperty("coupon_id")]
        public string CouponId { get; set; }
        /// <summary>
        /// 优惠券开始时间，单位：秒
        /// </summary>
        [JsonProperty("coupon_start_time")]
        public long? CouponStartTime { get; set; }
        /// <summary>
        /// 优惠券面额，单位：厘
        /// </summary>
        [JsonProperty("discount")]
        public int? Discount { get; set; }
        /// <summary>
        /// 优惠券总数量
        /// </summary>
        [JsonProperty("init_quantity")]
        public long? InitQuantity { get; set; }
        /// <summary>
        /// 商品的佣金比例，单位：千分位，比如100，表示10%
        /// </summary>
        [JsonProperty("rate")]
        public int? Rate { get; set; }
        /// <summary>
        /// 优惠券剩余数量
        /// </summary>
        [JsonProperty("remain_quantity")]
        public long? RemainQuantity { get; set; }
        /// <summary>
        /// 商品的推广计划类型，1-通用推广，2-专属推广，3-招商推广，4-全店推广
        /// </summary>
        [JsonProperty("unit_type")]
        public int? UnitType { get; set; }
    }
}

