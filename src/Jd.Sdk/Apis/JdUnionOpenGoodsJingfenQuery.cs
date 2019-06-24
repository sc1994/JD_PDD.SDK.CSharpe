using System.Threading.Tasks;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 京粉精选商品查询接口--请求参数
    /// 京东联盟精选优质商品，每日更新，可通过频道ID查询各个频道下的精选商品。
    /// jd.union.open.goods.jingfen.query
    /// https://union.jd.com/openplatform/api/739
    /// </summary>
    public class JdUnionOpenGoodsJingfenQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsJingfenQueryRequest() { }

        public JdUnionOpenGoodsJingfenQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.goods.jingfen.query";

        protected override string ParamName => "goodsReq";

        public async Task<JdBaseResponse<JdUnionOpenGoodsJingfenQueryResponse[]>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenGoodsJingfenQueryResponse[]>>();

        /// <summary>
        /// 描述：1-好券商品,2-京粉APP-jingdong.超级大卖场,3-小程序-jingdong.好券商品,4-京粉APP-jingdong.主题聚惠1-jingdong.服装运动,5-京粉APP-jingdong.主题聚惠2-jingdong.精选家电,6-京粉APP-jingdong.主题聚惠3-jingdong.超市,7-京粉APP-jingdong.主题聚惠4-jingdong.居家生活,10-9.9专区,11-品牌好货-jingdong.潮流范儿,12-品牌好货-jingdong.精致生活,13-品牌好货-jingdong.数码先锋,14-品牌好货-jingdong.品质家电,15-京仓配送,16-公众号-jingdong.好券商品,17-公众号-jingdong.9.9,18-公众号-jingdong.京东配送
        /// 例如：11
        /// 必填
        /// </summary>
        public int EliteId { get; set; }
        /// <summary>
        /// 描述：页码
        /// 例如：1
        /// 必填
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 描述：每页数量，默认20，上限50
        /// 例如：20
        /// 必填
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 描述：排序字段(price：单价, commissionShare：佣金比例, commission：佣金， inOrderCount30DaysSku：sku维度30天引单量，comments：评论数，goodComments：好评数)
        /// 例如：price
        /// 必填
        /// </summary>
        public string SortName { get; set; }
        /// <summary>
        /// 描述：asc,desc升降序,默认降序
        /// 例如：desc
        /// 必填
        /// </summary>
        public string Sort { get; set; }
    }



    /// <summary>
    /// 京粉精选商品查询接口--响应参数
    /// 京东联盟精选优质商品，每日更新，可通过频道ID查询各个频道下的精选商品。
    /// jd.union.open.goods.jingfen.query
    /// </summary>
    public class JdUnionOpenGoodsJingfenQueryResponse
    {
        /// <summary>
        /// 描述：类目信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsJingfenQuery_categoryinfo categoryInfo { get; set; }
        /// <summary>
        /// 类目信息
        /// </summary>
        public class JdUnionOpenGoodsJingfenQuery_categoryinfo
        {
            /// <summary>
            /// 描述：一级类目ID
            /// 例如：6144
            /// </summary>
            public long Cid1 { get; set; }
            /// <summary>
            /// 描述：一级类目名称
            /// 例如：珠宝首饰
            /// </summary>
            public string Cid1Name { get; set; }
            /// <summary>
            /// 描述： 二级类目ID
            /// 例如：12041
            /// </summary>
            public long Cid2 { get; set; }
            /// <summary>
            /// 描述：二级类目名称
            /// 例如：木手串/把件
            /// </summary>
            public string Cid2Name { get; set; }
            /// <summary>
            /// 描述：三级类目ID
            /// 例如：12052
            /// </summary>
            public long Cid3 { get; set; }
            /// <summary>
            /// 描述：三级类目名称
            /// 例如：其他
            /// </summary>
            public string Cid3Name { get; set; }
        }
        /// <summary>
        /// 描述：评论数
        /// 例如：999
        /// </summary>
        public long Comments { get; set; }
        /// <summary>
        /// 描述：佣金信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsJingfenQuery_commissioninfo commissionInfo { get; set; }
        /// <summary>
        /// 佣金信息
        /// </summary>
        public class JdUnionOpenGoodsJingfenQuery_commissioninfo
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
        /// 描述：优惠券信息，返回内容为空说明该SKU无可用优惠券
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsJingfenQuery_couponinfo couponInfo { get; set; }
        /// <summary>
        /// 优惠券信息，返回内容为空说明该SKU无可用优惠券
        /// </summary>
        public class JdUnionOpenGoodsJingfenQuery_couponinfo
        {
            /// <summary>
            /// 描述：优惠券合集
            /// 例如：
            /// </summary>
            public JdUnionOpenGoodsJingfenQuery_coupon[] couponList { get; set; }
            /// <summary>
            /// 优惠券合集
            /// </summary>
            public class JdUnionOpenGoodsJingfenQuery_coupon
            {
                /// <summary>
                /// 描述：券种类 (优惠券种类：0 - 全品类，1 - 限品类（自营商品），2 - 限店铺，3 - 店铺限商品券)
                /// 例如：3
                /// </summary>
                public int BindType { get; set; }
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
                public int PlatformType { get; set; }
                /// <summary>
                /// 描述：券消费限额
                /// 例如：39
                /// </summary>
                public double Quota { get; set; }
                /// <summary>
                /// 描述：领取开始时间(时间戳，毫秒)
                /// 例如：1532921782000
                /// </summary>
                public long GetStartTime { get; set; }
                /// <summary>
                /// 描述：券领取结束时间(时间戳，毫秒)
                /// 例如：1532921782000
                /// </summary>
                public long GetEndTime { get; set; }
                /// <summary>
                /// 描述：券有效使用开始时间(时间戳，毫秒)
                /// 例如：1532921782000
                /// </summary>
                public long UseStartTime { get; set; }
                /// <summary>
                /// 描述：券有效使用结束时间(时间戳，毫秒)
                /// 例如：1532921782000
                /// </summary>
                public long UseEndTime { get; set; }
            }
        }
        /// <summary>
        /// 描述：商品好评率
        /// 例如：99
        /// </summary>
        public double GoodCommentsShare { get; set; }
        /// <summary>
        /// 描述：图片信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsJingfenQuery_imageinfo imageInfo { get; set; }
        /// <summary>
        /// 图片信息
        /// </summary>
        public class JdUnionOpenGoodsJingfenQuery_imageinfo
        {
            /// <summary>
            /// 描述：图片合集
            /// 例如：
            /// </summary>
            public JdUnionOpenGoodsJingfenQuery_urlinfo[] imageList { get; set; }
            /// <summary>
            /// 图片合集
            /// </summary>
            public class JdUnionOpenGoodsJingfenQuery_urlinfo
            {
                /// <summary>
                /// 描述：图片链接地址，第一个图片链接为主图链接
                /// 例如：http://img14.360buyimg.com/ads/jfs/t22495/56/628456568/380476/9befc935/5b39fb01N7d1af390.jpg
                /// </summary>
                public string Url { get; set; }
            }
        }
        /// <summary>
        /// 描述：30天引单数量
        /// 例如：6018
        /// </summary>
        public long InOrderCount30Days { get; set; }
        /// <summary>
        /// 描述：商品落地页
        /// 例如：item.jd.com/26898778009.html
        /// </summary>
        public string MaterialUrl { get; set; }
        /// <summary>
        /// 描述：价格信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsJingfenQuery_priceinfo priceInfo { get; set; }
        /// <summary>
        /// 价格信息
        /// </summary>
        public class JdUnionOpenGoodsJingfenQuery_priceinfo
        {
            /// <summary>
            /// 描述：无线价格
            /// 例如：39.9
            /// </summary>
            public double Price { get; set; }
        }
        /// <summary>
        /// 描述：店铺信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsJingfenQuery_shopinfo shopInfo { get; set; }
        /// <summary>
        /// 店铺信息
        /// </summary>
        public class JdUnionOpenGoodsJingfenQuery_shopinfo
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
            public long ShopId { get; set; }
        }
        /// <summary>
        /// 描述：商品ID
        /// 例如：26898778009
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        /// 描述：商品名称
        /// 例如：便携式女士香水持久淡香小样 初见系列香水 遇见时光
        /// </summary>
        public string SkuName { get; set; }
        /// <summary>
        /// 描述：是否爆款，1：是，0：否
        /// 例如：1
        /// </summary>
        public int IsHot { get; set; }
        /// <summary>
        /// 描述：spuid，其值为同款商品的主skuid
        /// 例如：3491692
        /// </summary>
        public long Spuid { get; set; }
        /// <summary>
        /// 描述：品牌code
        /// 例如：7998
        /// </summary>
        public string BrandCode { get; set; }
        /// <summary>
        /// 描述： 品牌名
        /// 例如：悍途（Humtto）
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// 描述：g=自营，p=pop
        /// 例如：g
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 描述：拼购信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsJingfenQuery_pingouinfo pinGouInfo { get; set; }
        /// <summary>
        /// 拼购信息
        /// </summary>
        public class JdUnionOpenGoodsJingfenQuery_pingouinfo
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
            public long PingouTmCount { get; set; }
            /// <summary>
            /// 描述：拼购落地页url
            /// 例如：https://wq.jd.com/pingou_api/GetAutoTuan?sku_id=35097232463&amp;from=cps
            /// </summary>
            public string PingouUrl { get; set; }
        }
        /// <summary>
        /// 描述：资源信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsJingfenQuery_resourceinfo resourceInfo { get; set; }
        /// <summary>
        /// 资源信息
        /// </summary>
        public class JdUnionOpenGoodsJingfenQuery_resourceinfo
        {
            /// <summary>
            /// 描述：频道id
            /// 例如：11
            /// </summary>
            public int EliteId { get; set; }
            /// <summary>
            /// 描述：频道名称
            /// 例如：品牌好货-潮流范儿
            /// </summary>
            public string EliteName { get; set; }
        }
        /// <summary>
        /// 描述：30天引单数量(sku维度)
        /// 例如：100
        /// </summary>
        public long InOrderCount30DaysSku { get; set; }
    }
}

