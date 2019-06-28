using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 获取商品基本信息接口--请求参数
    /// 获取商品基本信息
    /// pdd.ddk.goods.basic.info.get
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.goods.basic.info.get
    /// </summary>
    public class PddDdkGoodsBasicInfoGetRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.goods.basic.info.get";

        public PddDdkGoodsBasicInfoGetRequest() { }

        public PddDdkGoodsBasicInfoGetRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkGoodsBasicInfoGetResponse> InvokeAsync()
            => await PostAsync<PddDdkGoodsBasicInfoGetResponse>();
        /// <summary>
        /// 必填
        /// 商品id
        /// </summary>
        public long[] GoodsIdList { get; set; }
    }


    /// <summary>
    /// 获取商品基本信息接口--响应参数
    /// 获取商品基本信息
    /// </summary>
    public class PddDdkGoodsBasicInfoGetResponse : PddBaseResponse
    {
        /// <summary>
        /// response
        /// </summary>
        [JsonProperty("goods_basic_detail_response")]
        public PddDdkGoodsBasicInfoGet_GoodsBasicDetailResponse GoodsBasicDetailResponse { get; set; }
    }

    /// <summary>
    /// list
    /// </summary>
    public class PddDdkGoodsBasicInfoGet_GoodsList
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [JsonProperty("goods_id")]
        public long? GoodsId { get; set; }
        /// <summary>
        /// 最小单买价格，单位分
        /// </summary>
        [JsonProperty("min_normal_price")]
        public long? MinNormalPrice { get; set; }
        /// <summary>
        /// 最小成团价格，单位分
        /// </summary>
        [JsonProperty("min_group_price")]
        public long? MinGroupPrice { get; set; }
        /// <summary>
        /// 商品缩略图
        /// </summary>
        [JsonProperty("goods_pic")]
        public string GoodsPic { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        [JsonProperty("goods_name")]
        public string GoodsName { get; set; }
    }
    /// <summary>
    /// response
    /// </summary>
    public class PddDdkGoodsBasicInfoGet_GoodsBasicDetailResponse
    {
        /// <summary>
        /// list
        /// </summary>
        [JsonProperty("goods_list")]
        public PddDdkGoodsBasicInfoGet_GoodsList[] GoodsList { get; set; }
    }
}

