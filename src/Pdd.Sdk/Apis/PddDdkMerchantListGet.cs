using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多客查店铺列表接口--请求参数
    /// 多多客查店铺列表接口
    /// pdd.ddk.merchant.list.get
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.merchant.list.get
    /// </summary>
    public class PddDdkMerchantListGetRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.merchant.list.get";

        public PddDdkMerchantListGetRequest() { }

        public PddDdkMerchantListGetRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkMerchantListGetResponse> InvokeAsync()
            => await PostAsync<PddDdkMerchantListGetResponse>();
        /// <summary>
        /// 不必填
        /// 店铺id
        /// </summary>
        public long[] MallIdList { get; set; }
        /// <summary>
        /// 不必填
        /// 店铺类型
        /// </summary>
        public int[] MerchantTypeList { get; set; }
        /// <summary>
        /// 不必填
        /// 查询范围0----商品拼团价格区间；1----商品券后价价格区间；2----佣金比例区间；3----优惠券金额区间；4----加入多多进宝时间区间；5----销量区间；6----佣金金额区间
        /// </summary>
        public int? QueryRangeStr { get; set; }
        /// <summary>
        /// 不必填
        /// 商品类目ID，使用pdd.goods.cats.get接口获取
        /// </summary>
        public long? CatId { get; set; }
        /// <summary>
        /// 不必填
        /// 是否有优惠券 （0 所有；1 必须有券。）
        /// </summary>
        public int? HasCoupon { get; set; }
        /// <summary>
        /// 不必填
        /// 每页数量
        /// </summary>
        public int? PageNumber { get; set; }
        /// <summary>
        /// 不必填
        /// 分页数
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 不必填
        /// 筛选范围
        /// </summary>
        public string RangeVoList { get; set; }
    }


    /// <summary>
    /// 多多客查店铺列表接口--响应参数
    /// 多多客查店铺列表接口
    /// </summary>
    public class PddDdkMerchantListGetResponse : PddBaseResponse
    {
        /// <summary>
        /// total
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; }
        /// <summary>
        /// 店铺券列表
        /// </summary>
        [JsonProperty("mall_search_info_vo_list")]
        public PddDdkMerchantListGet_MallSearchInfoVoList[] MallSearchInfoVoList { get; set; }
    }

    /// <summary>
    /// 商品详情列表
    /// </summary>
    public class PddDdkMerchantListGet_GoodsDetailVoList
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_at")]
        public long? CreateAt { get; set; }
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
        /// 商品详情图
        /// </summary>
        [JsonProperty("goods_gallery_urls")]
        public string[] GoodsGalleryUrls { get; set; }
        /// <summary>
        /// 商品售卖件数
        /// </summary>
        [JsonProperty("sold_quantity")]
        public long? SoldQuantity { get; set; }
        /// <summary>
        /// 商品最小成团价（单位为分）
        /// </summary>
        [JsonProperty("min_group_price")]
        public long? MinGroupPrice { get; set; }
        /// <summary>
        /// 商品单买价（单位为分）
        /// </summary>
        [JsonProperty("min_normal_price")]
        public long? MinNormalPrice { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        [JsonProperty("mall_name")]
        public string MallName { get; set; }
        /// <summary>
        /// 店铺类型，1-个人，2-企业，3-旗舰店，4-专卖店，5-专营店，6-普通店
        /// </summary>
        [JsonProperty("merchant_type")]
        public int? MerchantType { get; set; }
        /// <summary>
        /// 商品类目
        /// </summary>
        [JsonProperty("category_id")]
        public long? CategoryId { get; set; }
        /// <summary>
        /// 商品类目名
        /// </summary>
        [JsonProperty("category_name")]
        public string CategoryName { get; set; }
        /// <summary>
        /// 商品标签
        /// </summary>
        [JsonProperty("opt_id")]
        public long? OptId { get; set; }
        /// <summary>
        /// 商品标签名
        /// </summary>
        [JsonProperty("opt_name")]
        public string OptName { get; set; }
        /// <summary>
        /// 商品标签列表
        /// </summary>
        [JsonProperty("opt_ids")]
        public int[] OptIds { get; set; }
        /// <summary>
        /// 商品类目列表
        /// </summary>
        [JsonProperty("cat_ids")]
        public int[] CatIds { get; set; }
        /// <summary>
        /// 商品所在店铺是否开通全店推广 0：否，1：是
        /// </summary>
        [JsonProperty("mall_cps")]
        public int? MallCps { get; set; }
        /// <summary>
        /// 商品是否有优惠券（指单品券）
        /// </summary>
        [JsonProperty("has_coupon")]
        public bool? HasCoupon { get; set; }
        /// <summary>
        /// 使用优惠券的门槛金额（单位为分）
        /// </summary>
        [JsonProperty("coupon_min_order_amount")]
        public long? CouponMinOrderAmount { get; set; }
        /// <summary>
        /// 优惠券面额（单位为分）
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
        /// 优惠券开始时间
        /// </summary>
        [JsonProperty("coupon_start_time")]
        public long? CouponStartTime { get; set; }
        /// <summary>
        /// 优惠券结束时间
        /// </summary>
        [JsonProperty("coupon_end_time")]
        public long? CouponEndTime { get; set; }
        /// <summary>
        /// 佣金比（单位为分）
        /// </summary>
        [JsonProperty("promotion_rate")]
        public long? PromotionRate { get; set; }
        /// <summary>
        /// 商品评分
        /// </summary>
        [JsonProperty("goods_eval_score")]
        public double? GoodsEvalScore { get; set; }
        /// <summary>
        /// 商品评价数
        /// </summary>
        [JsonProperty("goods_eval_count")]
        public long? GoodsEvalCount { get; set; }
        /// <summary>
        /// 类目id
        /// </summary>
        [JsonProperty("cat_id")]
        public long? CatId { get; set; }
        /// <summary>
        /// 商品描述评分
        /// </summary>
        [JsonProperty("avg_desc")]
        public long? AvgDesc { get; set; }
        /// <summary>
        /// 商品物流评分
        /// </summary>
        [JsonProperty("avg_lgst")]
        public long? AvgLgst { get; set; }
        /// <summary>
        /// 商品服务评分
        /// </summary>
        [JsonProperty("avg_serv")]
        public long? AvgServ { get; set; }
        /// <summary>
        /// 描述评分击败同类店铺百分比
        /// </summary>
        [JsonProperty("desc_pct")]
        public double? DescPct { get; set; }
        /// <summary>
        /// 物流评分击败同类店铺百分比
        /// </summary>
        [JsonProperty("lgst_pct")]
        public double? LgstPct { get; set; }
        /// <summary>
        /// 服务评分击败同类店铺百分比
        /// </summary>
        [JsonProperty("serv_pct")]
        public double? ServPct { get; set; }
    }
    /// <summary>
    /// 店铺券列表
    /// </summary>
    public class PddDdkMerchantListGet_MallSearchInfoVoList
    {
        /// <summary>
        /// 店铺id
        /// </summary>
        [JsonProperty("mall_id")]
        public long? MallId { get; set; }
        /// <summary>
        /// 商品详情列表
        /// </summary>
        [JsonProperty("goods_detail_vo_list")]
        public PddDdkMerchantListGet_GoodsDetailVoList[] GoodsDetailVoList { get; set; }
    }
}

