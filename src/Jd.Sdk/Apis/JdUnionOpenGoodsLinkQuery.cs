using System.Threading.Tasks;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 链接商品查询接口【申请】--请求参数
    /// 链接商品查询接口
    /// jd.union.open.goods.link.query
    /// https://union.jd.com/openplatform/api/762
    /// </summary>
    public class JdUnionOpenGoodsLinkQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsLinkQueryRequest() { }

        public JdUnionOpenGoodsLinkQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.goods.link.query";

        protected override string ParamName => "goodsReq";

        public async Task<JdBaseResponse<JdUnionOpenGoodsLinkQueryResponse[]>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenGoodsLinkQueryResponse[]>>();

        /// <summary>
        /// 必填
        /// 描述：链接
        /// 例如：https://item.jd.com/product/12473772.html
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 必填
        /// 描述：子联盟ID（需要联系运营开通权限才能拿到数据）
        /// 例如：618_18_c35***e6a
        /// </summary>
        public string SubUnionId { get; set; }
    }



    /// <summary>
    /// 链接商品查询接口【申请】--响应参数
    /// 链接商品查询接口
    /// jd.union.open.goods.link.query
    /// </summary>
    public class JdUnionOpenGoodsLinkQueryResponse
    {
        /// <summary>
        /// 描述：skuId
        /// 例如：12473772
        /// </summary>
        public long? SkuId { get; set; }
        /// <summary>
        /// 描述：productId
        /// 例如：11484833
        /// </summary>
        public long? ProductId { get; set; }
        /// <summary>
        /// 描述：图片集，逗号','分割，首张为主图
        /// 例如：http://img14.360buyimg.com/ads/jfs/t25954/302/2427470833/110079/25edd6bf/5be5569aN4cab581d.jpg,http://img14.360buyimg.com/ads/jfs/t29152/135/448393735/356276/f377ac44/5bf3de8cNaec7256a.jpg
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// 描述：商品名称
        /// 例如：蔡康永的情商课：为你自己活一次（继《说话之道》热销400万册后，蔡康永再次奉上“内心强大之道
        /// </summary>
        public string SkuName { get; set; }
        /// <summary>
        /// 描述：京东价，单位：元
        /// 例如：37.4
        /// </summary>
        public double? Price { get; set; }
        /// <summary>
        /// 描述：佣金比例，单位：%
        /// 例如：10.0
        /// </summary>
        public double? CosRatio { get; set; }
        /// <summary>
        /// 描述：短链接
        /// 例如：https://u.jd.com/JMIOpg
        /// </summary>
        public string ShortUrl { get; set; }
        /// <summary>
        /// 描述：店铺id
        /// 例如：1000005647
        /// </summary>
        public string ShopId { get; set; }
        /// <summary>
        /// 描述：店铺名称
        /// 例如：博集天卷
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 描述：30天引单量
        /// 例如：3000
        /// </summary>
        public long? Sales { get; set; }
        /// <summary>
        /// 描述：是否自营，g：自营，p：pop
        /// 例如：g
        /// </summary>
        public string IsSelf { get; set; }
    }

}

