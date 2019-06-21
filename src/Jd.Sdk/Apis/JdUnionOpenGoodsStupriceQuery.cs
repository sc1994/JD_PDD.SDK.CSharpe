using System.Threading.Tasks;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 学生价商品查询接口【申请】--请求参数
    /// 根据SKUID、类目等信息查询学生价商品信息，通常用于校园推广。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.goods.stuprice.query
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
        /// 描述：sku id集合，长度30。如果传值，忽略其他查询条件
        /// 必填：false
        /// 例如：4236736,12332117
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
        /// 描述：学生专享价区间开始（单位：元）
        /// 必填：false
        /// 例如：100
        /// </summary>
        public double stuPriceFrom { get; set; }
        /// <summary>
        /// 描述：学生专享价区间结束（单位：元）
        /// 必填：false
        /// 例如：1000
        /// </summary>
        public double stuPriceTo { get; set; }
        /// <summary>
        /// 描述：一级类目
        /// 必填：false
        /// 例如：670
        /// </summary>
        public long cid1 { get; set; }
        /// <summary>
        /// 描述：二级类目
        /// 必填：false
        /// 例如：699
        /// </summary>
        public long cid2 { get; set; }
        /// <summary>
        /// 描述：三级类目
        /// 必填：false
        /// 例如：702
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
        /// 描述： 排序字段，默认搜索综合排序。允许的排序字段：stuPrice、commissionShare、inOrderCount30Days、inOrderComm30Days
        /// 必填：false
        /// 例如：stuPrice
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
    /// 学生价商品查询接口【申请】--响应参数
    /// 根据SKUID、类目等信息查询学生价商品信息，通常用于校园推广。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.goods.stuprice.query
    /// </summary>
    public class JdUnionOpenGoodsStupriceQueryResponse
    {
        /// <summary>
        /// 描述：商品名称
        /// 必填：true
        /// 例如：蛋卷头卷发棒
        /// </summary>
        public string skuName { get; set; }
        /// <summary>
        /// 描述：商品id
        /// 必填：true
        /// 例如：4722722
        /// </summary>
        public long skuId { get; set; }
        /// <summary>
        /// 描述：图片url
        /// 必填：true
        /// 例如：jfs/t20533/3/360228532/173527/3108cb63/5b0bb83fNc54e6800.jpg
        /// </summary>
        public string imageUrl { get; set; }
        /// <summary>
        /// 描述：是否学生价商品。  1：是学生价商品。  0：不是学生价商品。
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int isStuPrice { get; set; }
        /// <summary>
        /// 描述：京东价
        /// 必填：true
        /// 例如：69.9
        /// </summary>
        public double jdPrice { get; set; }
        /// <summary>
        /// 描述：学生专享价
        /// 必填：true
        /// 例如：56.0
        /// </summary>
        public double studentPrice { get; set; }
        /// <summary>
        /// 描述：专享价促销开始时间（时间戳：毫秒）
        /// 必填：true
        /// 例如：1535644800000
        /// </summary>
        public long stuPriceStartTime { get; set; }
        /// <summary>
        /// 描述：专享价促销结束时间（时间戳：毫秒）
        /// 必填：true
        /// 例如：1532361600000
        /// </summary>
        public long stuPriceEndTime { get; set; }
        /// <summary>
        /// 描述：一级类目id
        /// 必填：true
        /// 例如：737
        /// </summary>
        public long cid1Id { get; set; }
        /// <summary>
        /// 描述：二级类目id
        /// 必填：true
        /// 例如：1276
        /// </summary>
        public long cid2Id { get; set; }
        /// <summary>
        /// 描述：三级类目id
        /// 必填：true
        /// 例如：12400
        /// </summary>
        public long cid3Id { get; set; }
        /// <summary>
        /// 描述：一级类目名称
        /// 必填：true
        /// 例如：家用电器
        /// </summary>
        public string cid1Name { get; set; }
        /// <summary>
        /// 描述：二级类目名称
        /// 必填：true
        /// 例如：个护健康
        /// </summary>
        public string cid2Name { get; set; }
        /// <summary>
        /// 描述：三级类目名称
        /// 必填：true
        /// 例如：卷/直发器
        /// </summary>
        public string cid3Name { get; set; }
        /// <summary>
        /// 描述：通用佣金比例，百分比
        /// 必填：true
        /// 例如：7.0
        /// </summary>
        public double commissionShare { get; set; }
        /// <summary>
        /// 描述：通用佣金
        /// 必填：true
        /// 例如：3.92
        /// </summary>
        public double commission { get; set; }
        /// <summary>
        /// 描述：是否自营。g=自营，p=pop
        /// 必填：true
        /// 例如：g
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 描述：30天引入订单量（spu）
        /// 必填：true
        /// 例如：2552
        /// </summary>
        public long inOrderCount30Days { get; set; }
        /// <summary>
        /// 描述：30天支出佣金（spu）
        /// 必填：true
        /// 例如：3910.81
        /// </summary>
        public double inOrderComm30Days { get; set; }
    }
}

