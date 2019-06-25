using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 大字段商品查询接口（内测版）【申请】--请求参数
    /// 大字段商品查询接口（内测版）【申请】
    /// jd.union.open.goods.bigfield.query
    /// https://union.jd.com/openplatform/api/761
    /// </summary>
    public class JdUnionOpenGoodsBigfieldQueryRequest : JdBaseRequest
    {
        public JdUnionOpenGoodsBigfieldQueryRequest() { }

        public JdUnionOpenGoodsBigfieldQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.goods.bigfield.query";

        protected override string ParamName => "goodsReq";

        public async Task<JdBaseResponse<JdUnionOpenGoodsBigfieldQueryResponse[]>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenGoodsBigfieldQueryResponse[]>>();

        /// <summary>
        /// 必填
        /// 描述：skuId集合
        /// 例如：29357345299
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long[] SkuIds { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：查询域集合，不填写则查询全部
        /// 例如：&quot;categoryInfo&quot;,&quot;imageInfo&quot;,&quot;baseBigFieldInfo&quot;,&quot;bookBigFieldInfo&quot;,&quot;videoBigFieldInfo&quot;
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] Fields { get; set; }
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
        /// 例如：1111
        /// </summary>
        public long? SkuId { get; set; }
        /// <summary>
        /// 描述：商品名称
        /// 例如：手机
        /// </summary>
        public string SkuName { get; set; }
        /// <summary>
        /// 描述：目录信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_Categoryinfo CategoryInfo { get; set; }
        /// <summary>
        /// 描述：图片信心
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_Imageinfo ImageInfo { get; set; }
        /// <summary>
        /// 描述：基础大字段信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_Basebigfieldinfo BaseBigFieldInfo { get; set; }
        /// <summary>
        /// 描述：图书大字段信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_Bookbigfieldinfo BookBigFieldInfo { get; set; }
        /// <summary>
        /// 描述：影音大字段信息
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_Videobigfieldinfo VideoBigFieldInfo { get; set; }
    }

    /// <summary>
    /// 图片合集
    /// </summary>
    public class JdUnionOpenGoodsBigfieldQuery_Urlinfo
    {
        /// <summary>
        /// 描述： 图片链接地址，第一个图片链接为主图链接
        /// 例如：http://img14.360buyimg.com/ads/jfs/t22495/56/628456568/380476/9befc935/5b39fb01N7d1af390.jpg
        /// </summary>
        public string Url { get; set; }
    }
    /// <summary>
    /// 目录信息
    /// </summary>
    public class JdUnionOpenGoodsBigfieldQuery_Categoryinfo
    {
        /// <summary>
        /// 描述：一级类目ID
        /// 例如：6144
        /// </summary>
        public long? Cid1 { get; set; }
        /// <summary>
        /// 描述：一级类目名称
        /// 例如：珠宝首饰
        /// </summary>
        public string Cid1Name { get; set; }
        /// <summary>
        /// 描述：二级类目ID
        /// 例如：12041
        /// </summary>
        public long? Cid2 { get; set; }
        /// <summary>
        /// 描述：二级类目名称
        /// 例如：木手串/把件
        /// </summary>
        public string Cid2Name { get; set; }
        /// <summary>
        /// 描述：三级类目ID
        /// 例如：12052
        /// </summary>
        public long? Cid3 { get; set; }
        /// <summary>
        /// 描述：三级类目名称
        /// 例如：其他
        /// </summary>
        public string Cid3Name { get; set; }
    }
    /// <summary>
    /// 图片信心
    /// </summary>
    public class JdUnionOpenGoodsBigfieldQuery_Imageinfo
    {
        /// <summary>
        /// 描述：图片合集
        /// 例如：
        /// </summary>
        public JdUnionOpenGoodsBigfieldQuery_Urlinfo[] ImageList { get; set; }
    }
    /// <summary>
    /// 基础大字段信息
    /// </summary>
    public class JdUnionOpenGoodsBigfieldQuery_Basebigfieldinfo
    {
        /// <summary>
        /// 描述：商品介绍
        /// 例如：
        /// </summary>
        public string Wdis { get; set; }
        /// <summary>
        /// 描述：规格参数
        /// 例如：
        /// </summary>
        public string PropCode { get; set; }
        /// <summary>
        /// 描述：包装清单(仅自营商品)
        /// 例如：
        /// </summary>
        public string WareQD { get; set; }
    }
    /// <summary>
    /// 图书大字段信息
    /// </summary>
    public class JdUnionOpenGoodsBigfieldQuery_Bookbigfieldinfo
    {
        /// <summary>
        /// 描述：媒体评论
        /// 例如：
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// 描述：精彩文摘与插图(插图)
        /// 例如：
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 描述：内容摘要(内容简介)
        /// 例如：
        /// </summary>
        public string ContentDesc { get; set; }
        /// <summary>
        /// 描述：产品描述(相关商品)
        /// 例如：
        /// </summary>
        public string RelatedProducts { get; set; }
        /// <summary>
        /// 描述：编辑推荐
        /// 例如：
        /// </summary>
        public string EditerDesc { get; set; }
        /// <summary>
        /// 描述：目录
        /// 例如：
        /// </summary>
        public string Catalogue { get; set; }
        /// <summary>
        /// 描述：精彩摘要(精彩书摘)
        /// 例如：
        /// </summary>
        public string BookAbstract { get; set; }
        /// <summary>
        /// 描述：作者简介
        /// 例如：
        /// </summary>
        public string AuthorDesc { get; set; }
        /// <summary>
        /// 描述：前言(前言/序言)
        /// 例如：
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 描述：产品特色
        /// 例如：
        /// </summary>
        public string ProductFeatures { get; set; }
    }
    /// <summary>
    /// 影音大字段信息
    /// </summary>
    public class JdUnionOpenGoodsBigfieldQuery_Videobigfieldinfo
    {
        /// <summary>
        /// 描述：评论
        /// 例如：
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// 描述：商品描述(精彩剧照)
        /// 例如：
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 描述：内容摘要(内容简介)
        /// 例如：
        /// </summary>
        public string ContentDesc { get; set; }
        /// <summary>
        /// 描述：编辑推荐
        /// 例如：
        /// </summary>
        public string EditerDesc { get; set; }
        /// <summary>
        /// 描述：目录
        /// 例如：
        /// </summary>
        public string Catalogue { get; set; }
        /// <summary>
        /// 描述：包装清单
        /// 例如：
        /// </summary>
        public string Box_Contents { get; set; }
        /// <summary>
        /// 描述：特殊说明
        /// 例如：
        /// </summary>
        public string Material_Description { get; set; }
        /// <summary>
        /// 描述：说明书
        /// 例如：
        /// </summary>
        public string Manual { get; set; }
        /// <summary>
        /// 描述：产品特色
        /// 例如：
        /// </summary>
        public string ProductFeatures { get; set; }
    }
}

