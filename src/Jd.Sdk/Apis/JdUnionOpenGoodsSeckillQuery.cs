namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 秒杀商品查询接口【申请】--请求参数
    /// 根据SKUID、类目等信息查询秒杀商品信息，秒杀商品的价格通常为近期低价，有利于促成购买。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.goods.seckill.query
    /// </summary>
    public class JdUnionOpenGoodsSeckillQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsSeckillQueryRequest() { }

        public JdUnionOpenGoodsSeckillQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string method => "jd.union.open.goods.seckill.query";

        protected override string ParamName => "goodsReq";

        /// <summary>
        /// 描述：sku id集合，长度最大30
        /// 必填：false
        /// 例如：2622752,2112918
        /// </summary>
        public long[] skuIds { get; set; }
        /// <summary>
        /// 描述：页码，默认1
        /// 必填：false
        /// 例如：1
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 描述：每页数量最大30，默认30
        /// 必填：false
        /// 例如：30
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 描述：是否返回未开始秒杀商品。1=返回，0=不返回
        /// 必填：false
        /// 例如：1
        /// </summary>
        public int isBeginSecKill { get; set; }
        /// <summary>
        /// 描述：秒杀价区间开始（单位：元）
        /// 必填：false
        /// 例如：100
        /// </summary>
        public double secKillPriceFrom { get; set; }
        /// <summary>
        /// 描述：秒杀价区间结束
        /// 必填：false
        /// 例如：1000
        /// </summary>
        public double secKillPriceTo { get; set; }
        /// <summary>
        /// 描述：一级类目
        /// 必填：false
        /// 例如：9192
        /// </summary>
        public long cid1 { get; set; }
        /// <summary>
        /// 描述：二级类目
        /// 必填：false
        /// 例如：9194
        /// </summary>
        public long cid2 { get; set; }
        /// <summary>
        /// 描述：三级类目
        /// 必填：false
        /// 例如：9226
        /// </summary>
        public long cid3 { get; set; }
        /// <summary>
        /// 描述：g=自营，p=pop
        /// 必填：false
        /// 例如：g
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 描述：佣金比例区间开始
        /// 必填：false
        /// 例如：2.5
        /// </summary>
        public double commissionShareFrom { get; set; }
        /// <summary>
        /// 描述：佣金比例区间结束
        /// 必填：false
        /// 例如：15
        /// </summary>
        public double commissionShareTo { get; set; }
        /// <summary>
        /// 描述：排序字段，可为空。  （默认搜索综合排序。允许的排序字段：seckillPrice、commissionShare、inOrderCount30Days、inOrderComm30Days）
        /// 必填：false
        /// 例如：seckillPrice
        /// </summary>
        public string sortName { get; set; }
        /// <summary>
        /// 描述：desc=降序，asc=升序，可为空（默认降序）
        /// 必填：false
        /// 例如：desc
        /// </summary>
        public string sort { get; set; }
    }



    /// <summary>
    /// 秒杀商品查询接口【申请】--响应参数
    /// 根据SKUID、类目等信息查询秒杀商品信息，秒杀商品的价格通常为近期低价，有利于促成购买。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.goods.seckill.query
    /// </summary>
    public class JdUnionOpenGoodsSeckillQueryResponse
    {
        /// <summary>
        /// 描述：商品名称
        /// 必填：true
        /// 例如：EFE防辐射眼镜
        /// </summary>
        public string skuName { get; set; }
        /// <summary>
        /// 描述：商品id
        /// 必填：true
        /// 例如：11373310172
        /// </summary>
        public long skuId { get; set; }
        /// <summary>
        /// 描述：图片url
        /// 必填：true
        /// 例如：jfs/t22312/48/1318588624/95503/53cbeb88/5b24d5b4N212e96a1.jpg
        /// </summary>
        public string imageUrl { get; set; }
        /// <summary>
        /// 描述：是秒杀。1：是商品  0：非秒杀商品
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int isSecKill { get; set; }
        /// <summary>
        /// 描述：原价
        /// 必填：true
        /// 例如：179
        /// </summary>
        public double oriPrice { get; set; }
        /// <summary>
        /// 描述：秒杀价
        /// 必填：true
        /// 例如：79
        /// </summary>
        public double secKillPrice { get; set; }
        /// <summary>
        /// 描述：秒杀开始展示时间（时间戳：毫秒）
        /// 必填：true
        /// 例如：1533211200000
        /// </summary>
        public long secKillStartTime { get; set; }
        /// <summary>
        /// 描述：秒杀结束时间（时间戳：毫秒）
        /// 必填：true
        /// 例如：1533297599000
        /// </summary>
        public long secKillEndTime { get; set; }
        /// <summary>
        /// 描述：一级类目id
        /// 必填：true
        /// 例如：1315
        /// </summary>
        public long cid1Id { get; set; }
        /// <summary>
        /// 描述：二级类目id
        /// 必填：true
        /// 例如：1346
        /// </summary>
        public long cid2Id { get; set; }
        /// <summary>
        /// 描述：三级类目id
        /// 必填：true
        /// 例如：12019
        /// </summary>
        public long cid3Id { get; set; }
        /// <summary>
        /// 描述：一级类目名称
        /// 必填：true
        /// 例如：服饰内衣
        /// </summary>
        public string cid1Name { get; set; }
        /// <summary>
        /// 描述：二级类目名称
        /// 必填：true
        /// 例如：服饰配件
        /// </summary>
        public string cid2Name { get; set; }
        /// <summary>
        /// 描述：三级类目名称
        /// 必填：true
        /// 例如：防辐射眼镜
        /// </summary>
        public string cid3Name { get; set; }
        /// <summary>
        /// 描述：通用佣金比例，百分比
        /// 必填：true
        /// 例如：23.0
        /// </summary>
        public double commissionShare { get; set; }
        /// <summary>
        /// 描述：通用佣金
        /// 必填：true
        /// 例如：18.17
        /// </summary>
        public double commission { get; set; }
        /// <summary>
        /// 描述：是否自营。g=自营，p=pop
        /// 必填：true
        /// 例如：p
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 描述：30天引入订单量（spu）
        /// 必填：true
        /// 例如：1688
        /// </summary>
        public long inOrderCount30Days { get; set; }
        /// <summary>
        /// 描述：30天支出佣金（spu）
        /// 必填：true
        /// 例如：15856.54
        /// </summary>
        public double inOrderComm30Days { get; set; }
        /// <summary>
        /// 描述：京东价
        /// 必填：true
        /// 例如：138.0
        /// </summary>
        public double jdPrice { get; set; }
    }
}

