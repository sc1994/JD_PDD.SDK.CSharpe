namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 获取推广商品信息接口--请求参数
    /// 通过SKUID查询推广商品的名称、主图、类目、价格、物流、是否自营、30天引单数量等详细信息，支持批量获取。通常用于在媒体侧展示商品详情。
    /// jd.union.open.goods.promotiongoodsinfo.query
    /// </summary>
    public class JdUnionOpenGoodsPromotiongoodsinfoQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsPromotiongoodsinfoQueryRequest() { }

        public JdUnionOpenGoodsPromotiongoodsinfoQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string method => "jd.union.open.goods.promotiongoodsinfo.query";

        protected override string ParamName => "skuIds";

        protected override object Param => skuIds;

        /// <summary>
        /// 描述：京东skuID串，逗号分割，最多100个（非常重要 请大家关注：如果输入的sk串中某个skuID的商品不在推广中[就是没有佣金]，返回结果中不会包含这个商品的信息
        /// 必填：true
        /// 例如：5225346,7275691
        /// </summary>
        public string skuIds { get; set; }

    }



    /// <summary>
    /// 获取推广商品信息接口--响应参数
    /// 通过SKUID查询推广商品的名称、主图、类目、价格、物流、是否自营、30天引单数量等详细信息，支持批量获取。通常用于在媒体侧展示商品详情。
    /// jd.union.open.goods.promotiongoodsinfo.query
    /// </summary>
    public class JdUnionOpenGoodsPromotiongoodsinfoQueryResponse
    {
        /// <summary>
        /// 描述：商品ID
        /// 必填：true
        /// 例如：61861866
        /// </summary>
        public long skuId { get; set; }
        /// <summary>
        /// 描述：商品单价即京东价
        /// 必填：true
        /// 例如：89
        /// </summary>
        public double unitPrice { get; set; }
        /// <summary>
        /// 描述：商品落地页
        /// 必填：true
        /// 例如：http://item.jd.com/10000000.html
        /// </summary>
        public string materialUrl { get; set; }
        /// <summary>
        /// 描述：推广结束日期(时间戳，毫秒)
        /// 必填：true
        /// 例如：32472115200000
        /// </summary>
        public long endDate { get; set; }
        /// <summary>
        /// 描述：是否支持运费险(1:是,0:否)
        /// 必填：true
        /// 例如：0
        /// </summary>
        public int isFreeFreightRisk { get; set; }
        /// <summary>
        /// 描述：是否包邮(1:是,0:否,2:自营商品遵从主站包邮规则)
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int isFreeShipping { get; set; }
        /// <summary>
        /// 描述：无线佣金比例
        /// 必填：true
        /// 例如：25
        /// </summary>
        public double commisionRatioWl { get; set; }
        /// <summary>
        /// 描述：PC佣金比例
        /// 必填：true
        /// 例如：25
        /// </summary>
        public double commisionRatioPc { get; set; }
        /// <summary>
        /// 描述：图片地址
        /// 必填：true
        /// 例如：http://img14.360buyimg.com/n1/jfs/t18901/86/XXXXXXXX/498446/725fedfc/5af7c7e1N8b133379.jpg
        /// </summary>
        public string imgUrl { get; set; }
        /// <summary>
        /// 描述：商家ID
        /// 必填：true
        /// 例如：16815866
        /// </summary>
        public long vid { get; set; }
        /// <summary>
        /// 描述：一级类目名称
        /// 必填：true
        /// 例如：母婴
        /// </summary>
        public string cidName { get; set; }
        /// <summary>
        /// 描述：商品无线京东价（单价为-1表示未查询到该商品单价）
        /// 必填：true
        /// 例如：89
        /// </summary>
        public double wlUnitPrice { get; set; }
        /// <summary>
        /// 描述：二级类目名称
        /// 必填：true
        /// 例如：童装
        /// </summary>
        public string cid2Name { get; set; }
        /// <summary>
        /// 描述：是否秒杀(1:是,0:否)
        /// 必填：true
        /// 例如：0
        /// </summary>
        public int isSeckill { get; set; }
        /// <summary>
        /// 描述：二级类目ID
        /// 必填：true
        /// 例如：11842
        /// </summary>
        public long cid2 { get; set; }
        /// <summary>
        /// 描述：三级类目名称
        /// 必填：true
        /// 例如：裙子
        /// </summary>
        public string cid3Name { get; set; }
        /// <summary>
        /// 描述：30天引单数量 
        /// 必填：true
        /// 例如：703
        /// </summary>
        public long inOrderCount { get; set; }
        /// <summary>
        /// 描述：三级类目ID
        /// 必填：true
        /// 例如：11225
        /// </summary>
        public long cid3 { get; set; }
        /// <summary>
        /// 描述：店铺ID
        /// 必填：true
        /// 例如：168168
        /// </summary>
        public long shopId { get; set; }
        /// <summary>
        /// 描述：是否自营(1:是,0:否)
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int isJdSale { get; set; }
        /// <summary>
        /// 描述：商品名称
        /// 必填：true
        /// 例如：童装女童连衣裙儿童裙子大童女装2018夏季新品公主裙 横条纹款 130码（正码）
        /// </summary>
        public string goodsName { get; set; }
        /// <summary>
        /// 描述：推广开始日期（时间戳，毫秒）
        /// 必填：true
        /// 例如：1529251200000
        /// </summary>
        public long startDate { get; set; }
        /// <summary>
        /// 描述：一级类目ID
        /// 必填：true
        /// 例如：1319
        /// </summary>
        public long cid { get; set; }
    }
}

