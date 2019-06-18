namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 链接商品查询接口【申请】--请求参数
    /// 链接商品查询接口
    /// jd.union.open.goods.link.query
    /// </summary>
    public class JdUnionOpenGoodsLinkQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsLinkQueryRequest() { }

        public JdUnionOpenGoodsLinkQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string method => "jd.union.open.goods.link.query";

        protected override string ParamName => "goodsReq";

        /// <summary>
        /// 描述：链接
        /// 必填：true
        /// 例如：https://item.jd.com/product/12473772.html
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 描述：子联盟ID（需要联系运营开通权限才能拿到数据）
        /// 必填：true
        /// 例如：618_18_c35***e6a
        /// </summary>
        public string subUnionId { get; set; }
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
        /// 必填：true
        /// 例如：12473772
        /// </summary>
        public long skuId { get; set; }
        /// <summary>
        /// 描述：productId
        /// 必填：true
        /// 例如：11484833
        /// </summary>
        public long productId { get; set; }
        /// <summary>
        /// 描述：图片集，逗号','分割，首张为主图
        /// 必填：true
        /// 例如：http://img14.360buyimg.com/ads/jfs/t25954/302/2427470833/110079/25edd6bf/5be5569aN4cab581d.jpg,http://img14.360buyimg.com/ads/jfs/t29152/135/448393735/356276/f377ac44/5bf3de8cNaec7256a.jpg
        /// </summary>
        public string images { get; set; }
        /// <summary>
        /// 描述：商品名称
        /// 必填：true
        /// 例如：蔡康永的情商课：为你自己活一次（继《说话之道》热销400万册后，蔡康永再次奉上“内心强大之道
        /// </summary>
        public string skuName { get; set; }
        /// <summary>
        /// 描述：京东价，单位：元
        /// 必填：true
        /// 例如：37.4
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// 描述：佣金比例，单位：%
        /// 必填：true
        /// 例如：10.0
        /// </summary>
        public double cosRatio { get; set; }
        /// <summary>
        /// 描述：短链接
        /// 必填：true
        /// 例如：https://u.jd.com/JMIOpg
        /// </summary>
        public string shortUrl { get; set; }
        /// <summary>
        /// 描述：店铺id
        /// 必填：true
        /// 例如：1000005647
        /// </summary>
        public string shopId { get; set; }
        /// <summary>
        /// 描述：店铺名称
        /// 必填：true
        /// 例如：博集天卷
        /// </summary>
        public string shopName { get; set; }
        /// <summary>
        /// 描述：30天引单量
        /// 必填：true
        /// 例如：3000
        /// </summary>
        public long sales { get; set; }
        /// <summary>
        /// 描述：是否自营，g：自营，p：pop
        /// 必填：true
        /// 例如：g
        /// </summary>
        public string isSelf { get; set; }
    }
}

