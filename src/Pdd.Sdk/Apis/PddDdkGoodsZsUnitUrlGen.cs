using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多进宝转链接口--请求参数
    /// 本功能适用于采集群等场景。将其他推广者的推广链接转换成自己的；通过此api，可以将他人的招商推广链接，转换成自己的招商推广链接。
    /// pdd.ddk.goods.zs.unit.url.gen
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.goods.zs.unit.url.gen
    /// </summary>
    public class PddDdkGoodsZsUnitUrlGenRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.goods.zs.unit.url.gen";

        public PddDdkGoodsZsUnitUrlGenRequest() { }

        public PddDdkGoodsZsUnitUrlGenRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkGoodsZsUnitUrlGenResponse> InvokeAsync()
            => await PostAsync<PddDdkGoodsZsUnitUrlGenResponse>();
        /// <summary>
        /// 必填
        /// 需转链的链接
        /// </summary>
        public string SourceUrl { get; set; }
        /// <summary>
        /// 必填
        /// 渠道id
        /// </summary>
        public string Pid { get; set; }
    }


    /// <summary>
    /// 多多进宝转链接口--响应参数
    /// 本功能适用于采集群等场景。将其他推广者的推广链接转换成自己的；通过此api，可以将他人的招商推广链接，转换成自己的招商推广链接。
    /// </summary>
    public class PddDdkGoodsZsUnitUrlGenResponse : PddBaseResponse
    {
        /// <summary>
        /// goods_zs_unit_generate_response
        /// </summary>
        [JsonProperty("goods_zs_unit_generate_response")]
        public PddDdkGoodsZsUnitUrlGen_GoodsZsUnitGenerateResponse GoodsZsUnitGenerateResponse { get; set; }
    }

    /// <summary>
    /// goods_zs_unit_generate_response
    /// </summary>
    public class PddDdkGoodsZsUnitUrlGen_GoodsZsUnitGenerateResponse
    {
        /// <summary>
        /// 单人团推广长链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 单人团推广短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
        /// <summary>
        /// 推广长链接（唤起拼多多app）
        /// </summary>
        [JsonProperty("mobile_url")]
        public string MobileUrl { get; set; }
        /// <summary>
        /// 推广短链接（可唤起拼多多app）
        /// </summary>
        [JsonProperty("mobile_short_url")]
        public string MobileShortUrl { get; set; }
        /// <summary>
        /// 双人团推广长链接
        /// </summary>
        [JsonProperty("multi_group_url")]
        public string MultiGroupUrl { get; set; }
        /// <summary>
        /// 双人团推广短链接
        /// </summary>
        [JsonProperty("multi_group_short_url")]
        public string MultiGroupShortUrl { get; set; }
        /// <summary>
        /// 推广长链接（可唤起拼多多app）
        /// </summary>
        [JsonProperty("multi_group_mobile_url")]
        public string MultiGroupMobileUrl { get; set; }
        /// <summary>
        /// 推广短链接（唤起拼多多app）
        /// </summary>
        [JsonProperty("multi_group_mobile_short_url")]
        public string MultiGroupMobileShortUrl { get; set; }
    }
}

