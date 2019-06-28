using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 用时间段查询推广订单接口--请求参数
    /// 用时间段查询推广订单接口
    /// pdd.ddk.order.list.range.get
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.order.list.range.get
    /// </summary>
    public class PddDdkOrderListRangeGetRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.order.list.range.get";

        public PddDdkOrderListRangeGetRequest() { }

        public PddDdkOrderListRangeGetRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkOrderListRangeGetResponse> InvokeAsync()
            => await PostAsync<PddDdkOrderListRangeGetResponse>();
        /// <summary>
        /// 必填
        /// 支付起始时间，如：2019-05-05 00:00:00
        /// 例如：2019-05-07 00:00:00
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 不必填
        /// 上一次的迭代器id(第一次不填)
        /// </summary>
        public string LastOrderId { get; set; }
        /// <summary>
        /// 不必填
        /// 每次请求多少条，建议300
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 必填
        /// 支付结束时间，如：2019-05-05 00:00:00
        /// 例如：2019-05-07 00:00:00
        /// </summary>
        public string EndTime { get; set; }
    }


    /// <summary>
    /// 用时间段查询推广订单接口--响应参数
    /// 用时间段查询推广订单接口
    /// </summary>
    public class PddDdkOrderListRangeGetResponse : PddBaseResponse
    {
        /// <summary>
        /// order_list_get_response
        /// </summary>
        [JsonProperty("order_list_get_response")]
        public PddDdkOrderListRangeGet_OrderListGetResponse OrderListGetResponse { get; set; }
    }

    /// <summary>
    /// 多多进宝推广位对象列表
    /// </summary>
    public class PddDdkOrderListRangeGet_OrderList
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [JsonProperty("goods_id")]
        public long? GoodsId { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        [JsonProperty("goods_name")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 订单中sku的单件价格，单位为分
        /// </summary>
        [JsonProperty("goods_price")]
        public long? GoodsPrice { get; set; }
        /// <summary>
        /// 购买商品的数量
        /// </summary>
        [JsonProperty("goods_quantity")]
        public long? GoodsQuantity { get; set; }
        /// <summary>
        /// 商品缩略图
        /// </summary>
        [JsonProperty("goods_thumbnail_url")]
        public string GoodsThumbnailUrl { get; set; }
        /// <summary>
        /// 实际支付金额，单位为分
        /// </summary>
        [JsonProperty("order_amount")]
        public long? OrderAmount { get; set; }
        /// <summary>
        /// 订单生成时间，UNIX时间戳
        /// </summary>
        [JsonProperty("order_create_time")]
        public long? OrderCreateTime { get; set; }
        /// <summary>
        /// 成团时间
        /// </summary>
        [JsonProperty("order_group_success_time")]
        public long? OrderGroupSuccessTime { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [JsonProperty("order_modify_at")]
        public long? OrderModifyAt { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        [JsonProperty("order_pay_time")]
        public long? OrderPayTime { get; set; }
        /// <summary>
        /// 推广订单编号
        /// </summary>
        [JsonProperty("order_sn")]
        public string OrderSn { get; set; }
        /// <summary>
        /// 订单状态： -1 未支付; 0-已支付；1-已成团；2-确认收货；3-审核成功；4-审核失败（不可提现）；5-已经结算；8-非多多进宝商品（无佣金订单）
        /// </summary>
        [JsonProperty("order_status")]
        public int? OrderStatus { get; set; }
        /// <summary>
        /// 订单状态描述
        /// </summary>
        [JsonProperty("order_status_desc")]
        public string OrderStatusDesc { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        [JsonProperty("order_verify_time")]
        public long? OrderVerifyTime { get; set; }
        /// <summary>
        /// 推广位ID
        /// </summary>
        [JsonProperty("p_id")]
        public string PId { get; set; }
        /// <summary>
        /// 佣金金额，单位为分
        /// </summary>
        [JsonProperty("promotion_amount")]
        public long? PromotionAmount { get; set; }
        /// <summary>
        /// 佣金比例，千分比
        /// </summary>
        [JsonProperty("promotion_rate")]
        public long? PromotionRate { get; set; }
    }
    /// <summary>
    /// order_list_get_response
    /// </summary>
    public class PddDdkOrderListRangeGet_OrderListGetResponse
    {
        /// <summary>
        /// 多多进宝推广位对象列表
        /// </summary>
        [JsonProperty("order_list")]
        public PddDdkOrderListRangeGet_OrderList[] OrderList { get; set; }
        /// <summary>
        /// last_order_id
        /// </summary>
        [JsonProperty("last_order_id")]
        public string LastOrderId { get; set; }
    }
}

