using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 学生价商品查询接口【申请】--请求参数
    /// 根据SKUID、类目等信息查询学生价商品信息，通常用于校园推广。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.goods.stuprice.query
    /// https://union.jd.com/openplatform/api/666
    /// </summary>
    public class JdUnionOpenGoodsStupriceQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsStupriceQueryRequest() { }

        public JdUnionOpenGoodsStupriceQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.goods.stuprice.query";

        protected override string ParamName => "goodsReq";

        public async Task<JdBaseResponse<JdUnionOpenGoodsStupriceQueryResponse[]>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenGoodsStupriceQueryResponse[]>>();

        /// <summary>
        /// 不必填
        /// 描述：sku id集合，长度30。如果传值，忽略其他查询条件
        /// 例如：4236736,12332117
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
        /// 描述：学生专享价区间开始（单位：元）
        /// 例如：100
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double StuPriceFrom { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：学生专享价区间结束（单位：元）
        /// 例如：1000
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double StuPriceTo { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：一级类目
        /// 例如：670
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Cid1 { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：二级类目
        /// 例如：699
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? Cid2 { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：三级类目
        /// 例如：702
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
        /// 描述： 排序字段，默认搜索综合排序。允许的排序字段：stuPrice、commissionShare、inOrderCount30Days、inOrderComm30Days
        /// 例如：stuPrice
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
    /// 学生价商品查询接口【申请】--响应参数
    /// 根据SKUID、类目等信息查询学生价商品信息，通常用于校园推广。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.goods.stuprice.query
    /// </summary>
    public class JdUnionOpenGoodsStupriceQueryResponse
    {
        /// <summary>
        /// 描述：商品名称
        /// 例如：蛋卷头卷发棒
        /// </summary>
        public string SkuName { get; set; }
        /// <summary>
        /// 描述：商品id
        /// 例如：4722722
        /// </summary>
        public long? SkuId { get; set; }
        /// <summary>
        /// 描述：图片url
        /// 例如：jfs/t20533/3/360228532/173527/3108cb63/5b0bb83fNc54e6800.jpg
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 描述：是否学生价商品。  1：是学生价商品。  0：不是学生价商品。
        /// 例如：1
        /// </summary>
        public int? IsStuPrice { get; set; }
        /// <summary>
        /// 描述：京东价
        /// 例如：69.9
        /// </summary>
        public double JdPrice { get; set; }
        /// <summary>
        /// 描述：学生专享价
        /// 例如：56.0
        /// </summary>
        public double StudentPrice { get; set; }
        /// <summary>
        /// 描述：专享价促销开始时间（时间戳：毫秒）
        /// 例如：1535644800000
        /// </summary>
        public long? StuPriceStartTime { get; set; }
        /// <summary>
        /// 描述：专享价促销结束时间（时间戳：毫秒）
        /// 例如：1532361600000
        /// </summary>
        public long? StuPriceEndTime { get; set; }
        /// <summary>
        /// 描述：一级类目id
        /// 例如：737
        /// </summary>
        public long? Cid1Id { get; set; }
        /// <summary>
        /// 描述：二级类目id
        /// 例如：1276
        /// </summary>
        public long? Cid2Id { get; set; }
        /// <summary>
        /// 描述：三级类目id
        /// 例如：12400
        /// </summary>
        public long? Cid3Id { get; set; }
        /// <summary>
        /// 描述：一级类目名称
        /// 例如：家用电器
        /// </summary>
        public string Cid1Name { get; set; }
        /// <summary>
        /// 描述：二级类目名称
        /// 例如：个护健康
        /// </summary>
        public string Cid2Name { get; set; }
        /// <summary>
        /// 描述：三级类目名称
        /// 例如：卷/直发器
        /// </summary>
        public string Cid3Name { get; set; }
        /// <summary>
        /// 描述：通用佣金比例，百分比
        /// 例如：7.0
        /// </summary>
        public double CommissionShare { get; set; }
        /// <summary>
        /// 描述：通用佣金
        /// 例如：3.92
        /// </summary>
        public double Commission { get; set; }
        /// <summary>
        /// 描述：是否自营。g=自营，p=pop
        /// 例如：g
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 描述：30天引入订单量（spu）
        /// 例如：2552
        /// </summary>
        public long? InOrderCount30Days { get; set; }
        /// <summary>
        /// 描述：30天支出佣金（spu）
        /// 例如：3910.81
        /// </summary>
        public double InOrderComm30Days { get; set; }
    }
}

