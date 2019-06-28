using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多进宝商品查询--请求参数
    /// 多多进宝商品查询
    /// pdd.ddk.goods.search
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.goods.search
    /// </summary>
    public class PddDdkGoodsSearchRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.goods.search";

        public PddDdkGoodsSearchRequest() { }

        public PddDdkGoodsSearchRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkGoodsSearchResponse> InvokeAsync()
            => await PostAsync<PddDdkGoodsSearchResponse>();
        /// <summary>
        /// 不必填
        /// 商品关键词，与opt_id字段选填一个或全部填写
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 不必填
        /// 商品标签类目ID，使用pdd.goods.opt.get获取
        /// </summary>
        public long? OptId { get; set; }
        /// <summary>
        /// 不必填
        /// 默认值1，商品分页数
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// 不必填
        /// 默认100，每页商品数量
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 不必填
        /// 排序方式:0-综合排序;1-按佣金比率升序;2-按佣金比例降序;3-按价格升序;4-按价格降序;5-按销量升序;6-按销量降序;7-优惠券金额排序升序;8-优惠券金额排序降序;9-券后价升序排序;10-券后价降序排序;11-按照加入多多进宝时间升序;12-按照加入多多进宝时间降序;13-按佣金金额升序排序;14-按佣金金额降序排序;15-店铺描述评分升序;16-店铺描述评分降序;17-店铺物流评分升序;18-店铺物流评分降序;19-店铺服务评分升序;20-店铺服务评分降序;27-描述评分击败同类店铺百分比升序，28-描述评分击败同类店铺百分比降序，29-物流评分击败同类店铺百分比升序，30-物流评分击败同类店铺百分比降序，31-服务评分击败同类店铺百分比升序，32-服务评分击败同类店铺百分比降序
        /// </summary>
        public int? SortType { get; set; }
        /// <summary>
        /// 不必填
        /// 是否只返回优惠券的商品，false返回所有商品，true只返回有优惠券的商品
        /// </summary>
        public bool? WithCoupon { get; set; }
        /// <summary>
        /// 不必填
        /// 筛选范围列表 样例：[{"range_id":0,"range_from":1,"range_to":1500},{"range_id":1,"range_from":1,"range_to":1500}] range_id枚举及描述： 0，最小成团价 1，券后价 2，佣金比例 3，优惠券价格 4，广告创建时间 5，销量 6，佣金金额 7，店铺描述分 8，店铺物流分 9，店铺服务分 10， 店铺描述分击败同行业百分比 11， 店铺物流分击败同行业百分比 12，店铺服务分击败同行业百分比 13，商品分 17 ，优惠券/最小团购价 18，过去两小时pv 19，过去两小时销量
        /// </summary>
        public string RangeList { get; set; }
        /// <summary>
        /// 不必填
        /// 商品类目ID，使用pdd.goods.cats.get接口获取
        /// </summary>
        public long? CatId { get; set; }
        /// <summary>
        /// 不必填
        /// 商品ID列表。例如：[123456,123]，当入参带有goods_id_list字段，将不会以opt_id、 cat_id、keyword维度筛选商品
        /// </summary>
        public long[] GoodsIdList { get; set; }
        /// <summary>
        /// 不必填
        /// 店铺类型，1-个人，2-企业，3-旗舰店，4-专卖店，5-专营店，6-普通店（未传为全部）
        /// </summary>
        public int? MerchantType { get; set; }
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
        /// <summary>
        /// 不必填
        /// 店铺类型数组
        /// </summary>
        public int[] MerchantTypeList { get; set; }
    }


    /// <summary>
    /// 多多进宝商品查询--响应参数
    /// 多多进宝商品查询
    /// </summary>
    public class PddDdkGoodsSearchResponse : PddBaseResponse
    {
        /// <summary>
        /// response
        /// </summary>
        [JsonProperty("goods_search_response")]
        public PddDdkGoodsSearch_GoodsSearchResponse GoodsSearchResponse { get; set; }
    }

    /// <summary>
    /// 商品列表
    /// </summary>
    public class PddDdkGoodsSearch_GoodsList
    {
        /// <summary>
        /// 是否有店铺券
        /// </summary>
        [JsonProperty("has_mall_coupon")]
        public bool? HasMallCoupon { get; set; }
        /// <summary>
        /// 店铺券id
        /// </summary>
        [JsonProperty("mall_coupon_id")]
        public long? MallCouponId { get; set; }
        /// <summary>
        /// 店铺券折扣
        /// </summary>
        [JsonProperty("mall_coupon_discount_pct")]
        public int? MallCouponDiscountPct { get; set; }
        /// <summary>
        /// 最小使用金额
        /// </summary>
        [JsonProperty("mall_coupon_min_order_amount")]
        public int? MallCouponMinOrderAmount { get; set; }
        /// <summary>
        /// 最大使用金额
        /// </summary>
        [JsonProperty("mall_coupon_max_discount_amount")]
        public int? MallCouponMaxDiscountAmount { get; set; }
        /// <summary>
        /// 店铺券总量
        /// </summary>
        [JsonProperty("mall_coupon_total_quantity")]
        public long? MallCouponTotalQuantity { get; set; }
        /// <summary>
        /// 店铺券余量
        /// </summary>
        [JsonProperty("mall_coupon_remain_quantity")]
        public long? MallCouponRemainQuantity { get; set; }
        /// <summary>
        /// 店铺券开始使用时间
        /// </summary>
        [JsonProperty("mall_coupon_start_time")]
        public long? MallCouponStartTime { get; set; }
        /// <summary>
        /// 店铺券结束使用时间
        /// </summary>
        [JsonProperty("mall_coupon_end_time")]
        public long? MallCouponEndTime { get; set; }
        /// <summary>
        /// 创建时间（unix时间戳）
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
        /// <summary>
        /// 活动类型，0-无活动;1-秒杀;3-限量折扣;12-限时折扣;13-大促活动;14-名品折扣;15-品牌清仓;16-食品超市;17-一元幸运团;18-爱逛街;19-时尚穿搭;20-男人帮;21-9块9;22-竞价活动;23-榜单活动;24-幸运半价购;25-定金预售;26-幸运人气购;27-特色主题活动;28-断码清仓;29-一元话费;30-电器城;31-每日好店;32-品牌卡;101-大促搜索池;102-大促品类分会场;
        /// </summary>
        [JsonProperty("activity_type")]
        public int? ActivityType { get; set; }
    }
    /// <summary>
    /// response
    /// </summary>
    public class PddDdkGoodsSearch_GoodsSearchResponse
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        [JsonProperty("goods_list")]
        public PddDdkGoodsSearch_GoodsList[] GoodsList { get; set; }
        /// <summary>
        /// 返回商品总数
        /// </summary>
        [JsonProperty("total_count")]
        public int? TotalCount { get; set; }
    }
}

