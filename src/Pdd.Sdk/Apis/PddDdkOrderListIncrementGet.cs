using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 最后更新时间段增量同步推广订单信息--请求参数
    /// 按照时间段获取授权多多客下面所有多多客的推广订单信息
    /// pdd.ddk.order.list.increment.get
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.order.list.increment.get
    /// </summary>
    public class PddDdkOrderListIncrementGetRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.order.list.increment.get";

        public PddDdkOrderListIncrementGetRequest() { }

        public PddDdkOrderListIncrementGetRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkOrderListIncrementGetResponse> InvokeAsync()
            => await PostAsync<PddDdkOrderListIncrementGetResponse>();
        /// <summary>
        /// 必填
        /// 最近90天内多多进宝商品订单更新时间--查询时间开始。note：此时间为时间戳，指格林威治时间 1970 年01 月 01 日 00 时 00 分 00 秒(北京时间 1970 年 01 月 01 日 08 时 00 分 00 秒)起至现在的总秒数
        /// </summary>
        public long? StartUpdateTime { get; set; }
        /// <summary>
        /// 必填
        /// 查询结束时间，和开始时间相差不能超过24小时。note：此时间为时间戳，指格林威治时间 1970 年01 月 01 日 00 时 00 分 00 秒(北京时间 1970 年 01 月 01 日 08 时 00 分 00 秒)起至现在的总秒数
        /// </summary>
        public long? EndUpdateTime { get; set; }
        /// <summary>
        /// 不必填
        /// 返回的每页结果订单数，默认为100，范围为10到100，建议使用40~50，可以提高成功率，减少超时数量。
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 不必填
        /// 第几页，从1到10000，默认1，注：使用最后更新时间范围增量同步时，必须采用倒序的分页方式（从最后一页往回取）才能避免漏单问题。
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// 不必填
        /// 是否返回总数，默认为true，如果指定false, 则返回的结果中不包含总记录数，通过此种方式获取增量数据，效率在原有的基础上有80%的提升。
        /// </summary>
        public bool? ReturnCount { get; set; }
    }


    /// <summary>
    /// 最后更新时间段增量同步推广订单信息--响应参数
    /// 按照时间段获取授权多多客下面所有多多客的推广订单信息
    /// </summary>
    public class PddDdkOrderListIncrementGetResponse : PddBaseResponse
    {
        /// <summary>
        /// order_list_get_response
        /// </summary>
        [JsonProperty("order_list_get_response")]
        public PddDdkOrderListIncrementGet_OrderListGetResponse OrderListGetResponse { get; set; }
    }

    /// <summary>
    /// 多多进宝推广位对象列表
    /// </summary>
    public class PddDdkOrderListIncrementGet_OrderList
    {
        /// <summary>
        /// 推广订单编号
        /// </summary>
        [JsonProperty("order_sn")]
        public string OrderSn { get; set; }
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
        /// 商品缩略图
        /// </summary>
        [JsonProperty("goods_thumbnail_url")]
        public string GoodsThumbnailUrl { get; set; }
        /// <summary>
        /// 购买商品的数量
        /// </summary>
        [JsonProperty("goods_quantity")]
        public long? GoodsQuantity { get; set; }
        /// <summary>
        /// 订单中sku的单件价格，单位为分
        /// </summary>
        [JsonProperty("goods_price")]
        public long? GoodsPrice { get; set; }
        /// <summary>
        /// 实际支付金额，单位为分
        /// </summary>
        [JsonProperty("order_amount")]
        public long? OrderAmount { get; set; }
        /// <summary>
        /// 推广位ID
        /// </summary>
        [JsonProperty("p_id")]
        public string PId { get; set; }
        /// <summary>
        /// 佣金比例，千分比
        /// </summary>
        [JsonProperty("promotion_rate")]
        public long? PromotionRate { get; set; }
        /// <summary>
        /// 佣金金额，单位为分
        /// </summary>
        [JsonProperty("promotion_amount")]
        public long? PromotionAmount { get; set; }
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
        /// 订单生成时间，UNIX时间戳
        /// </summary>
        [JsonProperty("order_create_time")]
        public long? OrderCreateTime { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        [JsonProperty("order_pay_time")]
        public long? OrderPayTime { get; set; }
        /// <summary>
        /// 成团时间
        /// </summary>
        [JsonProperty("order_group_success_time")]
        public long? OrderGroupSuccessTime { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        [JsonProperty("order_verify_time")]
        public long? OrderVerifyTime { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [JsonProperty("order_modify_at")]
        public long? OrderModifyAt { get; set; }
        /// <summary>
        /// 自定义参数
        /// </summary>
        [JsonProperty("custom_parameters")]
        public string CustomParameters { get; set; }
    }
    /// <summary>
    /// order_list_get_response
    /// </summary>
    public class PddDdkOrderListIncrementGet_OrderListGetResponse
    {
        /// <summary>
        /// 多多进宝推广位对象列表
        /// </summary>
        [JsonProperty("order_list")]
        public PddDdkOrderListIncrementGet_OrderList[] OrderList { get; set; }
        /// <summary>
        /// 请求到的结果数
        /// </summary>
        [JsonProperty("total_count")]
        public long? TotalCount { get; set; }
    }
}

