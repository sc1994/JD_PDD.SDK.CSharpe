namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 大字段商品查询接口（内测版）【申请】--请求参数
    /// 大字段商品查询接口（内测版）【申请】
    /// jd.union.open.goods.bigfield.query
    /// </summary>
    public class JdUnionOpenGoodsBigfieldQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsBigfieldQueryRequest() { }

        public JdUnionOpenGoodsBigfieldQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string method => "jd.union.open.goods.bigfield.query";

        protected override string ParamName => "goodsReq";

        /// <summary>
        /// 描述：skuId集合
        /// 必填：true
        /// 例如：29357345299
        /// </summary>
        public long[] skuIds { get; set; }
        /// <summary>
        /// 描述：查询域集合，不填写则查询全部
        /// 必填：false
        /// 例如：&quot;categoryInfo&quot;,&quot;imageInfo&quot;,&quot;baseBigFieldInfo&quot;,&quot;bookBigFieldInfo&quot;,&quot;videoBigFieldInfo&quot;
        /// </summary>
        public string[] fields { get; set; }
    }



    /// <summary>
    /// 大字段商品查询接口（内测版）【申请】--响应参数
    /// 大字段商品查询接口（内测版）【申请】
    /// jd.union.open.goods.bigfield.query
    /// </summary>
    public class JdUnionOpenGoodsBigfieldQueryResponse
    {
        /// <summary>
        /// 描述：skuId
        /// 必填：true
        /// 例如：1111
        /// </summary>
        public long skuId { get; set; }
        /// <summary>
        /// 描述：商品名称
        /// 必填：true
        /// 例如：手机
        /// </summary>
        public string skuName { get; set; }
        /// <summary>
        /// 描述：目录信息
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_categoryinfo categoryInfo { get; set; }
        /// <summary>
        /// 目录信息
        /// </summary>
        public class JdUnionOpenGoodsBigfieldQuery_categoryinfo
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
        /// 描述：图片信心
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_imageinfo imageInfo { get; set; }
        /// <summary>
        /// 图片信心
        /// </summary>
        public class JdUnionOpenGoodsBigfieldQuery_imageinfo
        {
            /// <summary>
            /// 描述：图片合集
            /// 必填：true
            /// 例如：
            /// </summary>
            public JdUnionOpenGoodsBigfieldQuery_urlinfo[] imageList { get; set; }
            /// <summary>
            /// 图片合集
            /// </summary>
            public class JdUnionOpenGoodsBigfieldQuery_urlinfo
            {
                /// <summary>
                /// 描述： 图片链接地址，第一个图片链接为主图链接
                /// 必填：true
                /// 例如：http://img14.360buyimg.com/ads/jfs/t22495/56/628456568/380476/9befc935/5b39fb01N7d1af390.jpg
                /// </summary>
                public string url { get; set; }
            }
        }
        /// <summary>
        /// 描述：基础大字段信息
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_basebigfieldinfo baseBigFieldInfo { get; set; }
        /// <summary>
        /// 基础大字段信息
        /// </summary>
        public class JdUnionOpenGoodsBigfieldQuery_basebigfieldinfo
        {
            /// <summary>
            /// 描述：商品介绍
            /// 必填：true
            /// 例如：
            /// </summary>
            public string wdis { get; set; }
            /// <summary>
            /// 描述：规格参数
            /// 必填：true
            /// 例如：
            /// </summary>
            public string propCode { get; set; }
            /// <summary>
            /// 描述：包装清单(仅自营商品)
            /// 必填：true
            /// 例如：
            /// </summary>
            public string wareQD { get; set; }
        }
        /// <summary>
        /// 描述：图书大字段信息
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_bookbigfieldinfo bookBigFieldInfo { get; set; }
        /// <summary>
        /// 图书大字段信息
        /// </summary>
        public class JdUnionOpenGoodsBigfieldQuery_bookbigfieldinfo
        {
            /// <summary>
            /// 描述：媒体评论
            /// 必填：true
            /// 例如：
            /// </summary>
            public string comments { get; set; }
            /// <summary>
            /// 描述：精彩文摘与插图(插图)
            /// 必填：true
            /// 例如：
            /// </summary>
            public string image { get; set; }
            /// <summary>
            /// 描述：内容摘要(内容简介)
            /// 必填：true
            /// 例如：
            /// </summary>
            public string contentDesc { get; set; }
            /// <summary>
            /// 描述：产品描述(相关商品)
            /// 必填：true
            /// 例如：
            /// </summary>
            public string relatedProducts { get; set; }
            /// <summary>
            /// 描述：编辑推荐
            /// 必填：true
            /// 例如：
            /// </summary>
            public string editerDesc { get; set; }
            /// <summary>
            /// 描述：目录
            /// 必填：true
            /// 例如：
            /// </summary>
            public string catalogue { get; set; }
            /// <summary>
            /// 描述：精彩摘要(精彩书摘)
            /// 必填：true
            /// 例如：
            /// </summary>
            public string bookAbstract { get; set; }
            /// <summary>
            /// 描述：作者简介
            /// 必填：true
            /// 例如：
            /// </summary>
            public string authorDesc { get; set; }
            /// <summary>
            /// 描述：前言(前言/序言)
            /// 必填：true
            /// 例如：
            /// </summary>
            public string introduction { get; set; }
            /// <summary>
            /// 描述：产品特色
            /// 必填：true
            /// 例如：
            /// </summary>
            public string productFeatures { get; set; }
        }
        /// <summary>
        /// 描述：影音大字段信息
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_videobigfieldinfo videoBigFieldInfo { get; set; }
        /// <summary>
        /// 影音大字段信息
        /// </summary>
        public class JdUnionOpenGoodsBigfieldQuery_videobigfieldinfo
        {
            /// <summary>
            /// 描述：评论
            /// 必填：true
            /// 例如：
            /// </summary>
            public string comments { get; set; }
            /// <summary>
            /// 描述：商品描述(精彩剧照)
            /// 必填：true
            /// 例如：
            /// </summary>
            public string image { get; set; }
            /// <summary>
            /// 描述：内容摘要(内容简介)
            /// 必填：true
            /// 例如：
            /// </summary>
            public string contentDesc { get; set; }
            /// <summary>
            /// 描述：编辑推荐
            /// 必填：true
            /// 例如：
            /// </summary>
            public string editerDesc { get; set; }
            /// <summary>
            /// 描述：目录
            /// 必填：true
            /// 例如：
            /// </summary>
            public string catalogue { get; set; }
            /// <summary>
            /// 描述：包装清单
            /// 必填：true
            /// 例如：
            /// </summary>
            public string box_Contents { get; set; }
            /// <summary>
            /// 描述：特殊说明
            /// 必填：true
            /// 例如：
            /// </summary>
            public string material_Description { get; set; }
            /// <summary>
            /// 描述：说明书
            /// 必填：true
            /// 例如：
            /// </summary>
            public string manual { get; set; }
            /// <summary>
            /// 描述：产品特色
            /// 必填：true
            /// 例如：
            /// </summary>
            public string productFeatures { get; set; }
        }
    }
}

