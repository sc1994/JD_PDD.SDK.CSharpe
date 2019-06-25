using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 关键词商品查询接口【申请】--请求参数
    /// 查询商品及优惠券信息，返回的结果可调用转链接口生成单品或二合一推广链接。支持按SKUID、关键词、优惠券基本属性、是否拼购、是否爆款等条件查询，建议不要同时传入SKUID和其他字段，以获得较多的结果。支持按价格、佣金比例、佣金、引单量等维度排序。
    /// jd.union.open.goods.query
    /// https://union.jd.com/openplatform/api/628
    /// </summary>
    public class JdUnionOpenGoodsQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsQueryRequest() { }

        public JdUnionOpenGoodsQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.goods.query";

        protected override string ParamName => "goodsReqDTO";

        public async Task<JdBaseResponse<JdUnionOpenGoodsQueryResponse[]>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenGoodsQueryResponse[]>>();

        /// <summary>
        /// 不必填
        /// 描述：一级类目id
        /// 例如：737
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Cid1 { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：二级类目id
        /// 例如：738
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Cid2 { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：三级类目id
        /// 例如：739
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Cid3 { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：页码
        /// 例如：1
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? PageIndex { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：每页数量，单页数最大30，默认20 
        /// 例如：20
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? PageSize { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：skuid集合(一次最多支持查询100个sku)，数组类型开发时记得加[]
        /// 例如：5225346,7275691
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long[] SkuIds { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：关键词，字数同京东商品名称一致，目前未限制
        /// 例如：手机
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Keyword { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：商品价格下限
        /// 例如：16.88
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Pricefrom { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：商品价格上限
        /// 例如：19.95
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Priceto { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：佣金比例区间开始
        /// 例如：10
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? CommissionShareStart { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：佣金比例区间结束
        /// 例如：50
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? CommissionShareEnd { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：商品类型：自营[g]，POP[p]
        /// 例如：g
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Owner { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：排序字段(price：单价, commissionShare：佣金比例, commission：佣金， inOrderCount30Days：30天引单量， inOrderComm30Days：30天支出佣金)
        /// 例如：price
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SortName { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：asc,desc升降序,默认降序
        /// 例如：desc
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Sort { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：是否是优惠券商品，1：有优惠券，0：无优惠券
        /// 例如：1
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? IsCoupon { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：是否是拼购商品，1：拼购商品，0：非拼购商品
        /// 例如：1
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? IsPG { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：拼购价格区间开始
        /// 例如：16.88
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double PingouPriceStart { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：拼购价格区间结束
        /// 例如：19.95
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double PingouPriceEnd { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：是否是爆款，1：爆款商品，0：非爆款商品
        /// 例如：1
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? IsHot { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：品牌code
        /// 例如：7998
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string BrandCode { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：店铺Id
        /// 例如：45619
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? ShopId { get; set; }
    }



    /// <summary>
    /// 关键词商品查询接口【申请】--响应参数
    /// 查询商品及优惠券信息，返回的结果可调用转链接口生成单品或二合一推广链接。支持按SKUID、关键词、优惠券基本属性、是否拼购、是否爆款等条件查询，建议不要同时传入SKUID和其他字段，以获得较多的结果。支持按价格、佣金比例、佣金、引单量等维度排序。
    /// jd.union.open.goods.query
    /// </summary>
    public class JdUnionOpenGoodsQueryResponse
    {
        /// <summary>
        /// 描述：类目信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Categoryinfo CategoryInfo { get; set; }
        /// <summary>
        /// 描述：评论数
        /// 例如：250
        /// </summary>
        public long? Comments { get; set; }
        /// <summary>
        /// 描述：佣金信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Commissioninfo CommissionInfo { get; set; }
        /// <summary>
        /// 描述：优惠券信息，返回内容为空说明该SKU无可用优惠券
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Couponinfo CouponInfo { get; set; }
        /// <summary>
        /// 描述：商品好评率
        /// 例如：99
        /// </summary>
        public double GoodCommentsShare { get; set; }
        /// <summary>
        /// 描述：图片信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Imageinfo ImageInfo { get; set; }
        /// <summary>
        /// 描述：30天引单数量
        /// 例如：6018
        /// </summary>
        public long? InOrderCount30Days { get; set; }
        /// <summary>
        /// 描述：是否自营 (1 : 是, 0 : 否)，后续会废弃，请用owner
        /// 例如：1
        /// </summary>
        public int? IsJdSale { get; set; }
        /// <summary>
        /// 描述：商品落地页
        /// 例如：item.jd.com/26898778009.html
        /// </summary>
        public string MaterialUrl { get; set; }
        /// <summary>
        /// 描述：价格信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Priceinfo PriceInfo { get; set; }
        /// <summary>
        /// 描述：店铺信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Shopinfo ShopInfo { get; set; }
        /// <summary>
        /// 描述：商品ID
        /// 例如：26898778009
        /// </summary>
        public long? SkuId { get; set; }
        /// <summary>
        /// 描述：商品名称
        /// 例如：便携式女士香水持久淡香小样 初见系列香水 遇见时光
        /// </summary>
        public string SkuName { get; set; }
        /// <summary>
        /// 描述：是否爆款，1：是，0：否
        /// 例如：1
        /// </summary>
        public int? IsHot { get; set; }
        /// <summary>
        /// 描述：spuid，其值为同款商品的主skuid
        /// 例如：3491692
        /// </summary>
        public long? Spuid { get; set; }
        /// <summary>
        /// 描述：品牌code
        /// 例如：7998
        /// </summary>
        public string BrandCode { get; set; }
        /// <summary>
        /// 描述：品牌名
        /// 例如：悍途（Humtto）
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// 描述：g=自营，p=pop
        /// 例如：g
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 描述：已废弃，请使用pinGouInfo
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Pinggouinfo PingGouInfo { get; set; }
        /// <summary>
        /// 描述：拼购信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Pingouinfo PinGouInfo { get; set; }
    }

    /// <summary>
    /// 优惠券合集
    /// </summary>
    public class JdUnionOpenGoodsQuery_Coupon
    {
        /// <summary>
        /// 描述：券种类 (优惠券种类：0 - 全品类，1 - 限品类（自营商品），2 - 限店铺，3 - 店铺限商品券)
        /// 例如：3
        /// </summary>
        public int? BindType { get; set; }
        /// <summary>
        /// 描述：券面额
        /// 例如：30
        /// </summary>
        public double Discount { get; set; }
        /// <summary>
        /// 描述：券链接
        /// 例如：http://coupon.jd.com/ilink/couponActiveFront/front_index.action?XXXXXXX
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 描述：券使用平台 (平台类型：0 - 全平台券，1 - 限平台券)
        /// 例如：0
        /// </summary>
        public int? PlatformType { get; set; }
        /// <summary>
        /// 描述：券消费限额
        /// 例如：39
        /// </summary>
        public double Quota { get; set; }
        /// <summary>
        /// 描述：领取开始时间(时间戳，毫秒)
        /// 例如：1532921782000
        /// </summary>
        public long? GetStartTime { get; set; }
        /// <summary>
        /// 描述：券领取结束时间(时间戳，毫秒)
        /// 例如：1532921782000
        /// </summary>
        public long? GetEndTime { get; set; }
        /// <summary>
        /// 描述：券有效使用开始时间(时间戳，毫秒)
        /// 例如：1532921782000
        /// </summary>
        public long? UseStartTime { get; set; }
        /// <summary>
        /// 描述：券有效使用结束时间(时间戳，毫秒)
        /// 例如：1532921782000
        /// </summary>
        public long? UseEndTime { get; set; }
    }
    /// <summary>
    /// 图片合集
    /// </summary>
    public class JdUnionOpenGoodsQuery_Urlinfo
    {
        /// <summary>
        /// 描述：图片链接地址，第一个图片链接为主图链接
        /// 例如：http://img14.360buyimg.com/ads/jfs/t22495/56/628456568/380476/9befc935/5b39fb01N7d1af390.jpg
        /// </summary>
        public string Url { get; set; }
    }
    /// <summary>
    /// 类目信息
    /// </summary>
    public class JdUnionOpenGoodsQuery_Categoryinfo
    {
        /// <summary>
        /// 描述：一级类目ID
        /// 例如：6144
        /// </summary>
        public long? Cid1 { get; set; }
        /// <summary>
        /// 描述：一级类目名称
        /// 例如：珠宝首饰
        /// </summary>
        public string Cid1Name { get; set; }
        /// <summary>
        /// 描述：二级类目ID
        /// 例如：12041
        /// </summary>
        public long? Cid2 { get; set; }
        /// <summary>
        /// 描述：二级类目名称
        /// 例如：木手串/把件
        /// </summary>
        public string Cid2Name { get; set; }
        /// <summary>
        /// 描述：三级类目ID
        /// 例如：12052
        /// </summary>
        public long? Cid3 { get; set; }
        /// <summary>
        /// 描述：三级类目名称
        /// 例如：其他
        /// </summary>
        public string Cid3Name { get; set; }
    }
    /// <summary>
    /// 佣金信息
    /// </summary>
    public class JdUnionOpenGoodsQuery_Commissioninfo
    {
        /// <summary>
        /// 描述：佣金
        /// 例如：22.68
        /// </summary>
        public double Commission { get; set; }
        /// <summary>
        /// 描述：佣金比例
        /// 例如：50
        /// </summary>
        public double CommissionShare { get; set; }
    }
    /// <summary>
    /// 优惠券信息，返回内容为空说明该SKU无可用优惠券
    /// </summary>
    public class JdUnionOpenGoodsQuery_Couponinfo
    {
        /// <summary>
        /// 描述：优惠券合集
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Coupon[] CouponList { get; set; }
    }
    /// <summary>
    /// 图片信息
    /// </summary>
    public class JdUnionOpenGoodsQuery_Imageinfo
    {
        /// <summary>
        /// 描述：图片合集
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_Urlinfo[] ImageList { get; set; }
    }
    /// <summary>
    /// 价格信息
    /// </summary>
    public class JdUnionOpenGoodsQuery_Priceinfo
    {
        /// <summary>
        /// 描述：无线价格
        /// 例如：39.9
        /// </summary>
        public double Price { get; set; }
    }
    /// <summary>
    /// 店铺信息
    /// </summary>
    public class JdUnionOpenGoodsQuery_Shopinfo
    {
        /// <summary>
        /// 描述：店铺名称（或供应商名称）
        /// 例如：XXXX旗舰店
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 描述：店铺Id
        /// 例如：45619
        /// </summary>
        public int? ShopId { get; set; }
    }
    /// <summary>
    /// 已废弃，请使用pinGouInfo
    /// </summary>
    public class JdUnionOpenGoodsQuery_Pinggouinfo
    {
        /// <summary>
        /// 描述：拼购价格
        /// 例如：39.9
        /// </summary>
        public double PingouPrice { get; set; }
        /// <summary>
        /// 描述：拼购成团所需人数
        /// 例如：2
        /// </summary>
        public long? PingouTmCount { get; set; }
        /// <summary>
        /// 描述：拼购落地页url
        /// 例如：https://wq.jd.com/pingou_api/GetAutoTuan?sku_id=35097232463&amp;from=cps
        /// </summary>
        public string PingouUrl { get; set; }
    }
    /// <summary>
    /// 拼购信息
    /// </summary>
    public class JdUnionOpenGoodsQuery_Pingouinfo
    {
        /// <summary>
        /// 描述：拼购价格
        /// 例如：39.9
        /// </summary>
        public double PingouPrice { get; set; }
        /// <summary>
        /// 描述：拼购成团所需人数
        /// 例如：2
        /// </summary>
        public long? PingouTmCount { get; set; }
        /// <summary>
        /// 描述：拼购落地页url
        /// 例如：https://wq.jd.com/pingou_api/GetAutoTuan?sku_id=35097232463&amp;from=cps
        /// </summary>
        public string PingouUrl { get; set; }
        /// <summary>
        /// 描述：拼购开始时间(时间戳，毫秒)
        /// 例如：1546444800000
        /// </summary>
        public long? PingouStartTime { get; set; }
        /// <summary>
        /// 描述：拼购结束时间(时间戳，毫秒)
        /// 例如：1548604800000
        /// </summary>
        public long? PingouEndTime { get; set; }
    }
}

