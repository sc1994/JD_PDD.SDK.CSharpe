using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 秒杀商品查询接口【申请】--请求参数
    /// 根据SKUID、类目等信息查询秒杀商品信息，秒杀商品的价格通常为近期低价，有利于促成购买。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.goods.seckill.query
    /// https://union.jd.com/openplatform/api/667
    /// </summary>
    public class JdUnionOpenGoodsSeckillQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsSeckillQueryRequest() { }

        public JdUnionOpenGoodsSeckillQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.goods.seckill.query";

        protected override string ParamName => "goodsReq";

        public async Task<JdBaseResponse<JdUnionOpenGoodsSeckillQueryResponse[]>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenGoodsSeckillQueryResponse[]>>();

        /// <summary>
        /// 不必填
        /// 描述：sku id集合，长度最大30
        /// 例如：2622752,2112918
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long[] SkuIds { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：页码，默认1
        /// 例如：1
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? PageIndex { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：每页数量最大30，默认30
        /// 例如：30
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? PageSize { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：是否返回未开始秒杀商品。1=返回，0=不返回
        /// 例如：1
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? IsBeginSecKill { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：秒杀价区间开始（单位：元）
        /// 例如：100
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double SecKillPriceFrom { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：秒杀价区间结束
        /// 例如：1000
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double SecKillPriceTo { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：一级类目
        /// 例如：9192
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Cid1 { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：二级类目
        /// 例如：9194
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Cid2 { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：三级类目
        /// 例如：9226
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Cid3 { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：g=自营，p=pop
        /// 例如：g
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Owner { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：佣金比例区间开始
        /// 例如：2.5
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double CommissionShareFrom { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：佣金比例区间结束
        /// 例如：15
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double CommissionShareTo { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：排序字段，可为空。  （默认搜索综合排序。允许的排序字段：seckillPrice、commissionShare、inOrderCount30Days、inOrderComm30Days）
        /// 例如：seckillPrice
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SortName { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：desc=降序，asc=升序，可为空（默认降序）
        /// 例如：desc
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Sort { get; set; }
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
        /// 例如：EFE防辐射眼镜
        /// </summary>
        public string SkuName { get; set; }
        /// <summary>
        /// 描述：商品id
        /// 例如：11373310172
        /// </summary>
        public long? SkuId { get; set; }
        /// <summary>
        /// 描述：图片url
        /// 例如：jfs/t22312/48/1318588624/95503/53cbeb88/5b24d5b4N212e96a1.jpg
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 描述：是秒杀。1：是商品  0：非秒杀商品
        /// 例如：1
        /// </summary>
        public int? IsSecKill { get; set; }
        /// <summary>
        /// 描述：原价
        /// 例如：179
        /// </summary>
        public double OriPrice { get; set; }
        /// <summary>
        /// 描述：秒杀价
        /// 例如：79
        /// </summary>
        public double SecKillPrice { get; set; }
        /// <summary>
        /// 描述：秒杀开始展示时间（时间戳：毫秒）
        /// 例如：1533211200000
        /// </summary>
        public long? SecKillStartTime { get; set; }
        /// <summary>
        /// 描述：秒杀结束时间（时间戳：毫秒）
        /// 例如：1533297599000
        /// </summary>
        public long? SecKillEndTime { get; set; }
        /// <summary>
        /// 描述：一级类目id
        /// 例如：1315
        /// </summary>
        public long? Cid1Id { get; set; }
        /// <summary>
        /// 描述：二级类目id
        /// 例如：1346
        /// </summary>
        public long? Cid2Id { get; set; }
        /// <summary>
        /// 描述：三级类目id
        /// 例如：12019
        /// </summary>
        public long? Cid3Id { get; set; }
        /// <summary>
        /// 描述：一级类目名称
        /// 例如：服饰内衣
        /// </summary>
        public string Cid1Name { get; set; }
        /// <summary>
        /// 描述：二级类目名称
        /// 例如：服饰配件
        /// </summary>
        public string Cid2Name { get; set; }
        /// <summary>
        /// 描述：三级类目名称
        /// 例如：防辐射眼镜
        /// </summary>
        public string Cid3Name { get; set; }
        /// <summary>
        /// 描述：通用佣金比例，百分比
        /// 例如：23.0
        /// </summary>
        public double CommissionShare { get; set; }
        /// <summary>
        /// 描述：通用佣金
        /// 例如：18.17
        /// </summary>
        public double Commission { get; set; }
        /// <summary>
        /// 描述：是否自营。g=自营，p=pop
        /// 例如：p
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 描述：30天引入订单量（spu）
        /// 例如：1688
        /// </summary>
        public long? InOrderCount30Days { get; set; }
        /// <summary>
        /// 描述：30天支出佣金（spu）
        /// 例如：15856.54
        /// </summary>
        public double InOrderComm30Days { get; set; }
        /// <summary>
        /// 描述：京东价
        /// 例如：138.0
        /// </summary>
        public double JdPrice { get; set; }
    }

}

