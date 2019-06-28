using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多进宝主题商品查询--请求参数
    /// 多多进宝主题商品查询
    /// pdd.ddk.theme.goods.search
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.theme.goods.search
    /// </summary>
    public class PddDdkThemeGoodsSearchRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.theme.goods.search";

        public PddDdkThemeGoodsSearchRequest() { }

        public PddDdkThemeGoodsSearchRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkThemeGoodsSearchResponse> InvokeAsync()
            => await PostAsync<PddDdkThemeGoodsSearchResponse>();
        /// <summary>
        /// 必填
        /// 主题ID
        /// </summary>
        public long? ThemeId { get; set; }
    }


    /// <summary>
    /// 多多进宝主题商品查询--响应参数
    /// 多多进宝主题商品查询
    /// </summary>
    public class PddDdkThemeGoodsSearchResponse : PddBaseResponse
    {
        /// <summary>
        /// 返回商品总数
        /// </summary>
        [JsonProperty("total")]
        public long? Total { get; set; }
        /// <summary>
        /// 商品列表对象
        /// </summary>
        [JsonProperty("goods_list")]
        public PddDdkThemeGoodsSearch_GoodsList[] GoodsList { get; set; }
    }

    /// <summary>
    /// 商品列表对象
    /// </summary>
    public class PddDdkThemeGoodsSearch_GoodsList
    {
        /// <summary>
        /// 商品编码
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
        /// 商品详情图列表
        /// </summary>
        [JsonProperty("goods_gallery_urls")]
        public string[] GoodsGalleryUrls { get; set; }
        /// <summary>
        /// 已售卖件数
        /// </summary>
        [JsonProperty("sold_quantity")]
        public long? SoldQuantity { get; set; }
        /// <summary>
        /// 最小拼团价格,单位为分
        /// </summary>
        [JsonProperty("min_group_price")]
        public long? MinGroupPrice { get; set; }
        /// <summary>
        /// 最小单买价格,单位为分
        /// </summary>
        [JsonProperty("min_normal_price")]
        public long? MinNormalPrice { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        [JsonProperty("mall_name")]
        public string MallName { get; set; }
        /// <summary>
        /// 商品标签类目ID,使用pdd.goods.opt.get获取
        /// </summary>
        [JsonProperty("opt_id")]
        public long? OptId { get; set; }
        /// <summary>
        /// 商品标签名
        /// </summary>
        [JsonProperty("opt_name")]
        public string OptName { get; set; }
        /// <summary>
        /// 商品一~四级类目ID列表
        /// </summary>
        [JsonProperty("cat_ids")]
        public int[] CatIds { get; set; }
        /// <summary>
        /// 商品是否带券,true-带券,false-不带券
        /// </summary>
        [JsonProperty("has_coupon")]
        public bool? HasCoupon { get; set; }
        /// <summary>
        /// 优惠券门槛价格,单位为分
        /// </summary>
        [JsonProperty("coupon_min_order_amount")]
        public long? CouponMinOrderAmount { get; set; }
        /// <summary>
        /// 优惠券面额,单位为分
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
        /// 优惠券生效时间,UNIX时间戳
        /// </summary>
        [JsonProperty("coupon_start_time")]
        public long? CouponStartTime { get; set; }
        /// <summary>
        /// 优惠券失效时间,UNIX时间戳
        /// </summary>
        [JsonProperty("coupon_end_time")]
        public long? CouponEndTime { get; set; }
        /// <summary>
        /// 佣金比例,千分比
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
        /// 模糊销量
        /// </summary>
        [JsonProperty("sales_tip")]
        public string SalesTip { get; set; }
    }
}

