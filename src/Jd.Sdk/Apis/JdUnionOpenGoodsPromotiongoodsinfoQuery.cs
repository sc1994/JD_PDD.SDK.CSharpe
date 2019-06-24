using System.Threading.Tasks;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 获取推广商品信息接口--请求参数
    /// 通过SKUID查询推广商品的名称、主图、类目、价格、物流、是否自营、30天引单数量等详细信息，支持批量获取。通常用于在媒体侧展示商品详情。
    /// jd.union.open.goods.promotiongoodsinfo.query
    /// https://union.jd.com/openplatform/api/563
    /// </summary>
    public class JdUnionOpenGoodsPromotiongoodsinfoQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsPromotiongoodsinfoQueryRequest() { }

        public JdUnionOpenGoodsPromotiongoodsinfoQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.goods.promotiongoodsinfo.query";

        protected override string ParamName => "skuIds";

        protected override object Param => SkuIds;

        /// <summary>
        /// 描述：京东skuID串，逗号分割，最多100个（非常重要 请大家关注：如果输入的sk串中某个skuID的商品不在推广中[就是没有佣金]，返回结果中不会包含这个商品的信息
        /// 例如：5225346,7275691
        /// 必填
        /// </summary>
        public string SkuIds { get; set; }

        public async Task<JdBaseResponse<JdUnionOpenGoodsPromotiongoodsinfoQueryResponse[]>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenGoodsPromotiongoodsinfoQueryResponse[]>>();

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
        /// 例如：61861866
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        /// 描述：商品单价即京东价
        /// 例如：89
        /// </summary>
        public double UnitPrice { get; set; }
        /// <summary>
        /// 描述：商品落地页
        /// 例如：http://item.jd.com/10000000.html
        /// </summary>
        public string MaterialUrl { get; set; }
        /// <summary>
        /// 描述：推广结束日期(时间戳，毫秒)
        /// 例如：32472115200000
        /// </summary>
        public long EndDate { get; set; }
        /// <summary>
        /// 描述：是否支持运费险(1:是,0:否)
        /// 例如：0
        /// </summary>
        public int IsFreeFreightRisk { get; set; }
        /// <summary>
        /// 描述：是否包邮(1:是,0:否,2:自营商品遵从主站包邮规则)
        /// 例如：1
        /// </summary>
        public int IsFreeShipping { get; set; }
        /// <summary>
        /// 描述：无线佣金比例
        /// 例如：25
        /// </summary>
        public double CommisionRatioWl { get; set; }
        /// <summary>
        /// 描述：PC佣金比例
        /// 例如：25
        /// </summary>
        public double CommisionRatioPc { get; set; }
        /// <summary>
        /// 描述：图片地址
        /// 例如：http://img14.360buyimg.com/n1/jfs/t18901/86/XXXXXXXX/498446/725fedfc/5af7c7e1N8b133379.jpg
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 描述：商家ID
        /// 例如：16815866
        /// </summary>
        public long Vid { get; set; }
        /// <summary>
        /// 描述：一级类目名称
        /// 例如：母婴
        /// </summary>
        public string CidName { get; set; }
        /// <summary>
        /// 描述：商品无线京东价（单价为-1表示未查询到该商品单价）
        /// 例如：89
        /// </summary>
        public double WlUnitPrice { get; set; }
        /// <summary>
        /// 描述：二级类目名称
        /// 例如：童装
        /// </summary>
        public string Cid2Name { get; set; }
        /// <summary>
        /// 描述：是否秒杀(1:是,0:否)
        /// 例如：0
        /// </summary>
        public int IsSeckill { get; set; }
        /// <summary>
        /// 描述：二级类目ID
        /// 例如：11842
        /// </summary>
        public long Cid2 { get; set; }
        /// <summary>
        /// 描述：三级类目名称
        /// 例如：裙子
        /// </summary>
        public string Cid3Name { get; set; }
        /// <summary>
        /// 描述：30天引单数量 
        /// 例如：703
        /// </summary>
        public long InOrderCount { get; set; }
        /// <summary>
        /// 描述：三级类目ID
        /// 例如：11225
        /// </summary>
        public long Cid3 { get; set; }
        /// <summary>
        /// 描述：店铺ID
        /// 例如：168168
        /// </summary>
        public long ShopId { get; set; }
        /// <summary>
        /// 描述：是否自营(1:是,0:否)
        /// 例如：1
        /// </summary>
        public int IsJdSale { get; set; }
        /// <summary>
        /// 描述：商品名称
        /// 例如：童装女童连衣裙儿童裙子大童女装2018夏季新品公主裙 横条纹款 130码（正码）
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 描述：推广开始日期（时间戳，毫秒）
        /// 例如：1529251200000
        /// </summary>
        public long StartDate { get; set; }
        /// <summary>
        /// 描述：一级类目ID
        /// 例如：1319
        /// </summary>
        public long Cid { get; set; }
    }
}

