using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多客获取爆款排行商品接口--请求参数
    /// 获取热销商品列表
    /// pdd.ddk.top.goods.list.query
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.top.goods.list.query
    /// </summary>
    public class PddDdkTopGoodsListQueryRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.top.goods.list.query";

        public PddDdkTopGoodsListQueryRequest() { }

        public PddDdkTopGoodsListQueryRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkTopGoodsListQueryResponse> InvokeAsync()
            => await PostAsync<PddDdkTopGoodsListQueryResponse>();
        /// <summary>
        /// 不必填
        /// 推广位id
        /// </summary>
        public string PId { get; set; }
        /// <summary>
        /// 不必填
        /// 从多少位置开始请求；默认值 ： 0
        /// </summary>
        public int? Offset { get; set; }
        /// <summary>
        /// 不必填
        /// 1-实时热销榜；2-实时收益榜
        /// </summary>
        public int? SortType { get; set; }
        /// <summary>
        /// 不必填
        /// 请求数量；默认值 ： 400
        /// </summary>
        public int? Limit { get; set; }
    }


    /// <summary>
    /// 多多客获取爆款排行商品接口--响应参数
    /// 获取热销商品列表
    /// </summary>
    public class PddDdkTopGoodsListQueryResponse : PddBaseResponse
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        [JsonProperty("list")]
        public PddDdkTopGoodsListQuery_List[] List { get; set; }
        /// <summary>
        /// 返回商品总数
        /// </summary>
        [JsonProperty("total")]
        public long? Total { get; set; }
    }

    /// <summary>
    /// 商品列表
    /// </summary>
    public class PddDdkTopGoodsListQuery_List
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [JsonProperty("goods_id")]
        public long? GoodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("goods_name")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        [JsonProperty("goods_desc")]
        public string GoodsDesc { get; set; }
        /// <summary>
        /// 商品缩略图
        /// </summary>
        [JsonProperty("goods_thumbnail_url")]
        public string GoodsThumbnailUrl { get; set; }
        /// <summary>
        /// 商品主图
        /// </summary>
        [JsonProperty("goods_image_url")]
        public string GoodsImageUrl { get; set; }
        /// <summary>
        /// 商品轮播图
        /// </summary>
        [JsonProperty("goods_gallery_urls")]
        public string[] GoodsGalleryUrls { get; set; }
        /// <summary>
        /// 已售卖件数
        /// </summary>
        [JsonProperty("sold_quantity")]
        public long? SoldQuantity { get; set; }
        /// <summary>
        /// 最小拼团价（单位为分）
        /// </summary>
        [JsonProperty("min_group_price")]
        public long? MinGroupPrice { get; set; }
        /// <summary>
        /// 最小单买价格（单位为分）
        /// </summary>
        [JsonProperty("min_normal_price")]
        public long? MinNormalPrice { get; set; }
        /// <summary>
        /// 店铺名字
        /// </summary>
        [JsonProperty("mall_name")]
        public string MallName { get; set; }
        /// <summary>
        /// 店铺类型，1-个人，2-企业，3-旗舰店，4-专卖店，5-专营店，6-普通店
        /// </summary>
        [JsonProperty("merchant_type")]
        public int? MerchantType { get; set; }
        /// <summary>
        /// 商品类目ID，使用pdd.goods.cats.get接口获取
        /// </summary>
        [JsonProperty("category_id")]
        public long? CategoryId { get; set; }
        /// <summary>
        /// 商品类目名
        /// </summary>
        [JsonProperty("category_name")]
        public string CategoryName { get; set; }
        /// <summary>
        /// 商品标签ID，使用pdd.goods.opts.get接口获取
        /// </summary>
        [JsonProperty("opt_id")]
        public long? OptId { get; set; }
        /// <summary>
        /// 商品标签名
        /// </summary>
        [JsonProperty("opt_name")]
        public string OptName { get; set; }
        /// <summary>
        /// 商品标签id
        /// </summary>
        [JsonProperty("opt_ids")]
        public long[] OptIds { get; set; }
        /// <summary>
        /// 商品类目id
        /// </summary>
        [JsonProperty("cat_ids")]
        public long[] CatIds { get; set; }
        /// <summary>
        /// 该商品所在店铺是否参与全店推广，0：否，1：是
        /// </summary>
        [JsonProperty("mall_cps")]
        public int? MallCps { get; set; }
        /// <summary>
        /// 商品是否有优惠券 true-有，false-没有
        /// </summary>
        [JsonProperty("has_coupon")]
        public bool? HasCoupon { get; set; }
        /// <summary>
        /// 优惠券门槛价格，单位为分
        /// </summary>
        [JsonProperty("coupon_min_order_amount")]
        public long? CouponMinOrderAmount { get; set; }
        /// <summary>
        /// 优惠券面额，单位为分
        /// </summary>
        [JsonProperty("coupon_discount")]
        public long? CouponDiscount { get; set; }
        /// <summary>
        /// 优惠券总数量
        /// </summary>
        [JsonProperty("coupon_total_quantity")]
        public long? CouponTotalQuantity { get; set; }
        /// <summary>
        /// 优惠券剩余数量
        /// </summary>
        [JsonProperty("coupon_remain_quantity")]
        public long? CouponRemainQuantity { get; set; }
        /// <summary>
        /// 优惠券生效时间，UNIX时间戳
        /// </summary>
        [JsonProperty("coupon_start_time")]
        public long? CouponStartTime { get; set; }
        /// <summary>
        /// 优惠券失效时间，UNIX时间戳
        /// </summary>
        [JsonProperty("coupon_end_time")]
        public long? CouponEndTime { get; set; }
        /// <summary>
        /// 佣金比例，千分比
        /// </summary>
        [JsonProperty("promotion_rate")]
        public long? PromotionRate { get; set; }
        /// <summary>
        /// 商品评价分
        /// </summary>
        [JsonProperty("goods_eval_score")]
        public double? GoodsEvalScore { get; set; }
        /// <summary>
        /// 商品评价数量
        /// </summary>
        [JsonProperty("goods_eval_count")]
        public long? GoodsEvalCount { get; set; }
        /// <summary>
        /// 描述评分
        /// </summary>
        [JsonProperty("avg_desc")]
        public long? AvgDesc { get; set; }
        /// <summary>
        /// 物流评分
        /// </summary>
        [JsonProperty("avg_lgst")]
        public long? AvgLgst { get; set; }
        /// <summary>
        /// 服务评分
        /// </summary>
        [JsonProperty("avg_serv")]
        public long? AvgServ { get; set; }
        /// <summary>
        /// 描述分击败同类店铺百分比
        /// </summary>
        [JsonProperty("desc_pct")]
        public double? DescPct { get; set; }
        /// <summary>
        /// 物流分击败同类店铺百分比
        /// </summary>
        [JsonProperty("lgst_pct")]
        public double? LgstPct { get; set; }
        /// <summary>
        /// 服务分击败同类店铺百分比
        /// </summary>
        [JsonProperty("serv_pct")]
        public double? ServPct { get; set; }
        /// <summary>
        /// 模糊销量
        /// </summary>
        [JsonProperty("sales_tip")]
        public string SalesTip { get; set; }
    }
}

