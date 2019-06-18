namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 关键词商品查询接口【申请】--请求参数
    /// 查询商品及优惠券信息，返回的结果可调用转链接口生成单品或二合一推广链接。支持按SKUID、关键词、优惠券基本属性、是否拼购、是否爆款等条件查询，建议不要同时传入SKUID和其他字段，以获得较多的结果。支持按价格、佣金比例、佣金、引单量等维度排序。
    /// jd.union.open.goods.query
    /// </summary>
    public class JdUnionOpenGoodsQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsQueryRequest() { }

        public JdUnionOpenGoodsQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string method => "jd.union.open.goods.query";

        protected override string ParamName => "goodsReqDTO";

        /// <summary>
        /// 描述：一级类目id
        /// 必填：false
        /// 例如：737
        /// </summary>
        public long cid1 { get; set; }
        /// <summary>
        /// 描述：二级类目id
        /// 必填：false
        /// 例如：738
        /// </summary>
        public long cid2 { get; set; }
        /// <summary>
        /// 描述：三级类目id
        /// 必填：false
        /// 例如：739
        /// </summary>
        public long cid3 { get; set; }
        /// <summary>
        /// 描述：页码
        /// 必填：false
        /// 例如：1
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 描述：每页数量，单页数最大30，默认20 
        /// 必填：false
        /// 例如：20
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 描述：skuid集合(一次最多支持查询100个sku)，数组类型开发时记得加[]
        /// 必填：false
        /// 例如：5225346,7275691
        /// </summary>
        public long[] skuIds { get; set; }
        /// <summary>
        /// 描述：关键词，字数同京东商品名称一致，目前未限制
        /// 必填：false
        /// 例如：手机
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 描述：商品价格下限
        /// 必填：false
        /// 例如：16.88
        /// </summary>
        public double pricefrom { get; set; }
        /// <summary>
        /// 描述：商品价格上限
        /// 必填：false
        /// 例如：19.95
        /// </summary>
        public double priceto { get; set; }
        /// <summary>
        /// 描述：佣金比例区间开始
        /// 必填：false
        /// 例如：10
        /// </summary>
        public int commissionShareStart { get; set; }
        /// <summary>
        /// 描述：佣金比例区间结束
        /// 必填：false
        /// 例如：50
        /// </summary>
        public int commissionShareEnd { get; set; }
        /// <summary>
        /// 描述：商品类型：自营[g]，POP[p]
        /// 必填：false
        /// 例如：g
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 描述：排序字段(price：单价, commissionShare：佣金比例, commission：佣金， inOrderCount30Days：30天引单量， inOrderComm30Days：30天支出佣金)
        /// 必填：false
        /// 例如：price
        /// </summary>
        public string sortName { get; set; }
        /// <summary>
        /// 描述：asc,desc升降序,默认降序
        /// 必填：false
        /// 例如：desc
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 描述：是否是优惠券商品，1：有优惠券，0：无优惠券
        /// 必填：false
        /// 例如：1
        /// </summary>
        public int isCoupon { get; set; }
        /// <summary>
        /// 描述：是否是拼购商品，1：拼购商品，0：非拼购商品
        /// 必填：false
        /// 例如：1
        /// </summary>
        public int isPG { get; set; }
        /// <summary>
        /// 描述：拼购价格区间开始
        /// 必填：false
        /// 例如：16.88
        /// </summary>
        public double pingouPriceStart { get; set; }
        /// <summary>
        /// 描述：拼购价格区间结束
        /// 必填：false
        /// 例如：19.95
        /// </summary>
        public double pingouPriceEnd { get; set; }
        /// <summary>
        /// 描述：是否是爆款，1：爆款商品，0：非爆款商品
        /// 必填：false
        /// 例如：1
        /// </summary>
        public int isHot { get; set; }
        /// <summary>
        /// 描述：品牌code
        /// 必填：false
        /// 例如：7998
        /// </summary>
        public string brandCode { get; set; }
        /// <summary>
        /// 描述：店铺Id
        /// 必填：false
        /// 例如：45619
        /// </summary>
        public int shopId { get; set; }
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
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_categoryinfo categoryInfo { get; set; }
        /// <summary>
        /// 类目信息
        /// </summary>
        public class JdUnionOpenGoodsQuery_categoryinfo
        {
            /// <summary>
            /// 描述：一级类目ID
            /// 必填：true
            /// 例如：6144
            /// </summary>
            public long cid1 { get; set; }
            /// <summary>
            /// 描述：一级类目名称
            /// 必填：true
            /// 例如：珠宝首饰
            /// </summary>
            public string cid1Name { get; set; }
            /// <summary>
            /// 描述：二级类目ID
            /// 必填：true
            /// 例如：12041
            /// </summary>
            public long cid2 { get; set; }
            /// <summary>
            /// 描述：二级类目名称
            /// 必填：true
            /// 例如：木手串/把件
            /// </summary>
            public string cid2Name { get; set; }
            /// <summary>
            /// 描述：三级类目ID
            /// 必填：true
            /// 例如：12052
            /// </summary>
            public long cid3 { get; set; }
            /// <summary>
            /// 描述：三级类目名称
            /// 必填：true
            /// 例如：其他
            /// </summary>
            public string cid3Name { get; set; }
        }
        /// <summary>
        /// 描述：评论数
        /// 必填：true
        /// 例如：250
        /// </summary>
        public long comments { get; set; }
        /// <summary>
        /// 描述：佣金信息
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_commissioninfo commissionInfo { get; set; }
        /// <summary>
        /// 佣金信息
        /// </summary>
        public class JdUnionOpenGoodsQuery_commissioninfo
        {
            /// <summary>
            /// 描述：佣金
            /// 必填：true
            /// 例如：22.68
            /// </summary>
            public double commission { get; set; }
            /// <summary>
            /// 描述：佣金比例
            /// 必填：true
            /// 例如：50
            /// </summary>
            public double commissionShare { get; set; }
        }
        /// <summary>
        /// 描述：优惠券信息，返回内容为空说明该SKU无可用优惠券
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_couponinfo couponInfo { get; set; }
        /// <summary>
        /// 优惠券信息，返回内容为空说明该SKU无可用优惠券
        /// </summary>
        public class JdUnionOpenGoodsQuery_couponinfo
        {
            /// <summary>
            /// 描述：优惠券合集
            /// 必填：true
            /// 例如：
            /// </summary>
            public JdUnionOpenGoodsQuery_coupon[] couponList { get; set; }
            /// <summary>
            /// 优惠券合集
            /// </summary>
            public class JdUnionOpenGoodsQuery_coupon
            {
                /// <summary>
                /// 描述：券种类 (优惠券种类：0 - 全品类，1 - 限品类（自营商品），2 - 限店铺，3 - 店铺限商品券)
                /// 必填：true
                /// 例如：3
                /// </summary>
                public int bindType { get; set; }
                /// <summary>
                /// 描述：券面额
                /// 必填：true
                /// 例如：30
                /// </summary>
                public double discount { get; set; }
                /// <summary>
                /// 描述：券链接
                /// 必填：true
                /// 例如：http://coupon.jd.com/ilink/couponActiveFront/front_index.action?XXXXXXX
                /// </summary>
                public string link { get; set; }
                /// <summary>
                /// 描述：券使用平台 (平台类型：0 - 全平台券，1 - 限平台券)
                /// 必填：true
                /// 例如：0
                /// </summary>
                public int platformType { get; set; }
                /// <summary>
                /// 描述：券消费限额
                /// 必填：true
                /// 例如：39
                /// </summary>
                public double quota { get; set; }
                /// <summary>
                /// 描述：领取开始时间(时间戳，毫秒)
                /// 必填：true
                /// 例如：1532921782000
                /// </summary>
                public long getStartTime { get; set; }
                /// <summary>
                /// 描述：券领取结束时间(时间戳，毫秒)
                /// 必填：true
                /// 例如：1532921782000
                /// </summary>
                public long getEndTime { get; set; }
                /// <summary>
                /// 描述：券有效使用开始时间(时间戳，毫秒)
                /// 必填：true
                /// 例如：1532921782000
                /// </summary>
                public long useStartTime { get; set; }
                /// <summary>
                /// 描述：券有效使用结束时间(时间戳，毫秒)
                /// 必填：true
                /// 例如：1532921782000
                /// </summary>
                public long useEndTime { get; set; }
            }
        }
        /// <summary>
        /// 描述：商品好评率
        /// 必填：true
        /// 例如：99
        /// </summary>
        public double goodCommentsShare { get; set; }
        /// <summary>
        /// 描述：图片信息
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_imageinfo imageInfo { get; set; }
        /// <summary>
        /// 图片信息
        /// </summary>
        public class JdUnionOpenGoodsQuery_imageinfo
        {
            /// <summary>
            /// 描述：图片合集
            /// 必填：true
            /// 例如：
            /// </summary>
            public JdUnionOpenGoodsQuery_urlinfo[] imageList { get; set; }
            /// <summary>
            /// 图片合集
            /// </summary>
            public class JdUnionOpenGoodsQuery_urlinfo
            {
                /// <summary>
                /// 描述：图片链接地址，第一个图片链接为主图链接
                /// 必填：true
                /// 例如：http://img14.360buyimg.com/ads/jfs/t22495/56/628456568/380476/9befc935/5b39fb01N7d1af390.jpg
                /// </summary>
                public string url { get; set; }
            }
        }
        /// <summary>
        /// 描述：30天引单数量
        /// 必填：true
        /// 例如：6018
        /// </summary>
        public long inOrderCount30Days { get; set; }
        /// <summary>
        /// 描述：是否自营 (1 : 是, 0 : 否)，后续会废弃，请用owner
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int isJdSale { get; set; }
        /// <summary>
        /// 描述：商品落地页
        /// 必填：true
        /// 例如：item.jd.com/26898778009.html
        /// </summary>
        public string materialUrl { get; set; }
        /// <summary>
        /// 描述：价格信息
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_priceinfo priceInfo { get; set; }
        /// <summary>
        /// 价格信息
        /// </summary>
        public class JdUnionOpenGoodsQuery_priceinfo
        {
            /// <summary>
            /// 描述：无线价格
            /// 必填：true
            /// 例如：39.9
            /// </summary>
            public double price { get; set; }
        }
        /// <summary>
        /// 描述：店铺信息
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_shopinfo shopInfo { get; set; }
        /// <summary>
        /// 店铺信息
        /// </summary>
        public class JdUnionOpenGoodsQuery_shopinfo
        {
            /// <summary>
            /// 描述：店铺名称（或供应商名称）
            /// 必填：true
            /// 例如：XXXX旗舰店
            /// </summary>
            public string shopName { get; set; }
            /// <summary>
            /// 描述：店铺Id
            /// 必填：true
            /// 例如：45619
            /// </summary>
            public int shopId { get; set; }
        }
        /// <summary>
        /// 描述：商品ID
        /// 必填：true
        /// 例如：26898778009
        /// </summary>
        public long skuId { get; set; }
        /// <summary>
        /// 描述：商品名称
        /// 必填：true
        /// 例如：便携式女士香水持久淡香小样 初见系列香水 遇见时光
        /// </summary>
        public string skuName { get; set; }
        /// <summary>
        /// 描述：是否爆款，1：是，0：否
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int isHot { get; set; }
        /// <summary>
        /// 描述：spuid，其值为同款商品的主skuid
        /// 必填：true
        /// 例如：3491692
        /// </summary>
        public long spuid { get; set; }
        /// <summary>
        /// 描述：品牌code
        /// 必填：true
        /// 例如：7998
        /// </summary>
        public string brandCode { get; set; }
        /// <summary>
        /// 描述：品牌名
        /// 必填：true
        /// 例如：悍途（Humtto）
        /// </summary>
        public string brandName { get; set; }
        /// <summary>
        /// 描述：g=自营，p=pop
        /// 必填：true
        /// 例如：g
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 描述：已废弃，请使用pinGouInfo
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_pinggouinfo pingGouInfo { get; set; }
        /// <summary>
        /// 已废弃，请使用pinGouInfo
        /// </summary>
        public class JdUnionOpenGoodsQuery_pinggouinfo
        {
            /// <summary>
            /// 描述：拼购价格
            /// 必填：true
            /// 例如：39.9
            /// </summary>
            public double pingouPrice { get; set; }
            /// <summary>
            /// 描述：拼购成团所需人数
            /// 必填：true
            /// 例如：2
            /// </summary>
            public long pingouTmCount { get; set; }
            /// <summary>
            /// 描述：拼购落地页url
            /// 必填：true
            /// 例如：https://wq.jd.com/pingou_api/GetAutoTuan?sku_id=35097232463&amp;from=cps
            /// </summary>
            public string pingouUrl { get; set; }
        }
        /// <summary>
        /// 描述：拼购信息
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsQuery_pingouinfo pinGouInfo { get; set; }
        /// <summary>
        /// 拼购信息
        /// </summary>
        public class JdUnionOpenGoodsQuery_pingouinfo
        {
            /// <summary>
            /// 描述：拼购价格
            /// 必填：true
            /// 例如：39.9
            /// </summary>
            public double pingouPrice { get; set; }
            /// <summary>
            /// 描述：拼购成团所需人数
            /// 必填：true
            /// 例如：2
            /// </summary>
            public long pingouTmCount { get; set; }
            /// <summary>
            /// 描述：拼购落地页url
            /// 必填：true
            /// 例如：https://wq.jd.com/pingou_api/GetAutoTuan?sku_id=35097232463&amp;from=cps
            /// </summary>
            public string pingouUrl { get; set; }
            /// <summary>
            /// 描述：拼购开始时间(时间戳，毫秒)
            /// 必填：true
            /// 例如：1546444800000
            /// </summary>
            public long pingouStartTime { get; set; }
            /// <summary>
            /// 描述：拼购结束时间(时间戳，毫秒)
            /// 必填：true
            /// 例如：1548604800000
            /// </summary>
            public long pingouEndTime { get; set; }
        }
    }
}

