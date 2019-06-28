using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多进宝主题列表查询--请求参数
    /// 查询多多进宝主题列表
    /// pdd.ddk.theme.list.get
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.theme.list.get
    /// </summary>
    public class PddDdkThemeListGetRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.theme.list.get";

        public PddDdkThemeListGetRequest() { }

        public PddDdkThemeListGetRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkThemeListGetResponse> InvokeAsync()
            => await PostAsync<PddDdkThemeListGetResponse>();
        /// <summary>
        /// 不必填
        /// 返回的一页数据数量
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 不必填
        /// 返回的页码
        /// </summary>
        public int? Page { get; set; }
    }


    /// <summary>
    /// 多多进宝主题列表查询--响应参数
    /// 查询多多进宝主题列表
    /// </summary>
    public class PddDdkThemeListGetResponse : PddBaseResponse
    {
        /// <summary>
        /// 返回的元素数量
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; }
        /// <summary>
        /// 返回的主题列表
        /// </summary>
        [JsonProperty("theme_list")]
        public PddDdkThemeListGet_ThemeList[] ThemeList { get; set; }
    }

    /// <summary>
    /// 返回的主题列表
    /// </summary>
    public class PddDdkThemeListGet_ThemeList
    {
        /// <summary>
        /// 主题ID
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; set; }
        /// <summary>
        /// 主题图片
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        /// <summary>
        /// 主题名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 主题包含的商品数量
        /// </summary>
        [JsonProperty("goods_num")]
        public long? GoodsNum { get; set; }
    }
}

