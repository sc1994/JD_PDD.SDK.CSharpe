using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 运营频道商品查询API--请求参数
    /// 运营频道商品查询
    /// pdd.ddk.goods.recommend.get
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.goods.recommend.get
    /// </summary>
    public class PddDdkGoodsRecommendGetRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.goods.recommend.get";

        public PddDdkGoodsRecommendGetRequest() { }

        public PddDdkGoodsRecommendGetRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkGoodsRecommendGetResponse> InvokeAsync()
            => await PostAsync<PddDdkGoodsRecommendGetResponse>();
        /// <summary>
        /// 不必填
        /// 从多少位置开始请求；默认值 ： 0
        /// </summary>
        public int? Offset { get; set; }
        /// <summary>
        /// 不必填
        /// 请求数量；默认值 ： 400
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// 不必填
        /// 频道类型；0, "1.9包邮", 1, "今日爆款", 2, "品牌清仓", 非必填 ,默认是1
        /// </summary>
        public int? ChannelType { get; set; }
        /// <summary>
        /// 不必填
        /// 推广位id
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// 不必填
        /// 自定义参数
        /// </summary>
        public string CustomParameters { get; set; }
    }


    /// <summary>
    /// 运营频道商品查询API--响应参数
    /// 运营频道商品查询
    /// </summary>
    public class PddDdkGoodsRecommendGetResponse : PddBaseResponse
    {
        /// <summary>
        /// total
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; }
        /// <summary>
        /// 列表
        /// </summary>
        [JsonProperty("list")]
        public PddDdkGoodsRecommendGet_List[] List { get; set; }
    }

    /// <summary>
    /// 列表
    /// </summary>
    public class PddDdkGoodsRecommendGet_List
    {
        /// <summary>
        /// 二维码主图
        /// </summary>
        [JsonProperty("qr_code_image_url")]
        public string QrCodeImageUrl { get; set; }
        /// <summary>
        /// 编辑锁定
        /// </summary>
        [JsonProperty("lock_edit")]
        public string LockEdit { get; set; }
        /// <summary>
        /// 代理人
        /// </summary>
        [JsonProperty("broker")]
        public string Broker { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        [JsonProperty("rank")]
        public string Rank { get; set; }
        /// <summary>
        /// 今日成交量
        /// </summary>
        [JsonProperty("sale_num_today")]
        public long? SaleNumToday { get; set; }
        /// <summary>
        /// 成交量
        /// </summary>
        [JsonProperty("sale_num24")]
        public long? SaleNum24 { get; set; }
        /// <summary>
        /// 服务评分击败同类店铺百分比
        /// </summary>
        [JsonProperty("serv_pct")]
        public double? ServPct { get; set; }
        /// <summary>
        /// 物流评分击败同类店铺百分比
        /// </summary>
        [JsonProperty("lgst_pct")]
        public double? LgstPct { get; set; }
        /// <summary>
        /// 描述评分击败同类店铺百分比
        /// </summary>
        [JsonProperty("desc_pct")]
        public double? DescPct { get; set; }
        /// <summary>
        /// 服务评分
        /// </summary>
        [JsonProperty("avg_serv")]
        public long? AvgServ { get; set; }
        /// <summary>
        /// 物流评分
        /// </summary>
        [JsonProperty("avg_lgst")]
        public long? AvgLgst { get; set; }
        /// <summary>
        /// 描述评分
        /// </summary>
        [JsonProperty("avg_desc")]
        public long? AvgDesc { get; set; }
        /// <summary>
        /// 分享描述
        /// </summary>
        [JsonProperty("share_desc")]
        public string ShareDesc { get; set; }
        /// <summary>
        /// 商品类目id
        /// </summary>
        [JsonProperty("cat_id")]
        public string CatId { get; set; }
        /// <summary>
        /// 商品评价数量
        /// </summary>
        [JsonProperty("goods_eval_count")]
        public long? GoodsEvalCount { get; set; }
        /// <summary>
        /// 商品评价分
        /// </summary>
        [JsonProperty("goods_eval_score")]
        public double? GoodsEvalScore { get; set; }
        /// <summary>
        /// 市场服务费
        /// </summary>
        [JsonProperty("market_fee")]
        public long? MarketFee { get; set; }
        /// <summary>
        /// 商品等级
        /// </summary>
        [JsonProperty("goods_rate")]
        public long? GoodsRate { get; set; }
        /// <summary>
        /// 优惠券金额
        /// </summary>
        [JsonProperty("coupon_price")]
        public long? CouponPrice { get; set; }
        /// <summary>
        /// 佣金比例,千分比
        /// </summary>
        [JsonProperty("promotion_rate")]
        public long? PromotionRate { get; set; }
        /// <summary>
        /// 优惠券失效时间,UNIX时间戳
        /// </summary>
        [JsonProperty("coupon_end_time")]
        public long? CouponEndTime { get; set; }
        /// <summary>
        /// 优惠券生效时间,UNIX时间戳
        /// </summary>
        [JsonProperty("coupon_start_time")]
        public long? CouponStartTime { get; set; }
        /// <summary>
        /// 优惠券剩余数量
        /// </summary>
        [JsonProperty("coupon_remain_quantity")]
        public long? CouponRemainQuantity { get; set; }
        /// <summary>
        /// 优惠券总数量
        /// </summary>
        [JsonProperty("coupon_total_quantity")]
        public long? CouponTotalQuantity { get; set; }
        /// <summary>
        /// 优惠券面额,单位为分
        /// </summary>
        [JsonProperty("coupon_discount")]
        public long? CouponDiscount { get; set; }
        /// <summary>
        /// 优惠券门槛价格,单位为分
        /// </summary>
        [JsonProperty("coupon_min_order_amount")]
        public long? CouponMinOrderAmount { get; set; }
        /// <summary>
        /// 优惠券id
        /// </summary>
        [JsonProperty("coupon_id")]
        public long? CouponId { get; set; }
        /// <summary>
        /// 商品是否带券,true-带券,false-不带券
        /// </summary>
        [JsonProperty("has_coupon")]
        public bool? HasCoupon { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        [JsonProperty("goods_type")]
        public int? GoodsType { get; set; }
        /// <summary>
        /// 商品一~四级类目ID列表
        /// </summary>
        [JsonProperty("cat_ids")]
        public long[] CatIds { get; set; }
        /// <summary>
        /// 商品一~四级标签类目ID列表
        /// </summary>
        [JsonProperty("opt_ids")]
        public long[] OptIds { get; set; }
        /// <summary>
        /// 商品标签名
        /// </summary>
        [JsonProperty("opt_name")]
        public string OptName { get; set; }
        /// <summary>
        /// 商品标签类目ID,使用pdd.goods.opt.get获取
        /// </summary>
        [JsonProperty("opt_id")]
        public string OptId { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        [JsonProperty("category_name")]
        public string CategoryName { get; set; }
        /// <summary>
        /// 类目id
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryId { get; set; }
        /// <summary>
        /// 商家类型
        /// </summary>
        [JsonProperty("merchant_type")]
        public string MerchantType { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        [JsonProperty("mall_name")]
        public string MallName { get; set; }
        /// <summary>
        /// 商家id
        /// </summary>
        [JsonProperty("mall_id")]
        public long? MallId { get; set; }
        /// <summary>
        /// 最小单买价格，单位分
        /// </summary>
        [JsonProperty("min_normal_price")]
        public long? MinNormalPrice { get; set; }
        /// <summary>
        /// 最小成团价格，单位分
        /// </summary>
        [JsonProperty("min_group_price")]
        public long? MinGroupPrice { get; set; }
        /// <summary>
        /// 商品实际价格
        /// </summary>
        [JsonProperty("goods_fact_price")]
        public long? GoodsFactPrice { get; set; }
        /// <summary>
        /// 商品标准价格
        /// </summary>
        [JsonProperty("goods_mark_price")]
        public long? GoodsMarkPrice { get; set; }
        /// <summary>
        /// 销售量
        /// </summary>
        [JsonProperty("sold_quantity")]
        public long? SoldQuantity { get; set; }
        /// <summary>
        /// 商品详情图列表
        /// </summary>
        [JsonProperty("goods_gallery_urls")]
        public string GoodsGalleryUrls { get; set; }
        /// <summary>
        /// 商品主图
        /// </summary>
        [JsonProperty("goods_image_url")]
        public string GoodsImageUrl { get; set; }
        /// <summary>
        /// 商品缩略图
        /// </summary>
        [JsonProperty("goods_thumbnail_url")]
        public string GoodsThumbnailUrl { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        [JsonProperty("goods_desc")]
        public string GoodsDesc { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("goods_name")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [JsonProperty("goods_id")]
        public long? GoodsId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_at")]
        public long? CreateAt { get; set; }
        /// <summary>
        /// 模糊销量
        /// </summary>
        [JsonProperty("sales_tip")]
        public string SalesTip { get; set; }
    }
}

