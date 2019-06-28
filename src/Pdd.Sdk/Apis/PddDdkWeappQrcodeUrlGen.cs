using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 多多客生成单品推广小程序二维码url--请求参数
    /// 多多客生成单品推广小程序二维码url
    /// pdd.ddk.weapp.qrcode.url.gen
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.weapp.qrcode.url.gen
    /// </summary>
    public class PddDdkWeappQrcodeUrlGenRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.weapp.qrcode.url.gen";

        public PddDdkWeappQrcodeUrlGenRequest() { }

        public PddDdkWeappQrcodeUrlGenRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkWeappQrcodeUrlGenResponse> InvokeAsync()
            => await PostAsync<PddDdkWeappQrcodeUrlGenResponse>();
        /// <summary>
        /// 必填
        /// 推广位ID
        /// </summary>
        public string PId { get; set; }
        /// <summary>
        /// 必填
        /// 商品ID，仅支持单个查询
        /// </summary>
        public long[] GoodsIdList { get; set; }
        /// <summary>
        /// 不必填
        /// 自定义参数，为链接打上自定义标签。自定义参数最长限制64个字节。
        /// </summary>
        public string CustomParameters { get; set; }
        /// <summary>
        /// 不必填
        /// 招商多多客ID
        /// </summary>
        public long? ZsDuoId { get; set; }
    }


    /// <summary>
    /// 多多客生成单品推广小程序二维码url--响应参数
    /// 多多客生成单品推广小程序二维码url
    /// </summary>
    public class PddDdkWeappQrcodeUrlGenResponse : PddBaseResponse
    {
        /// <summary>
        /// response
        /// </summary>
        [JsonProperty("weapp_qrcode_generate_response")]
        public PddDdkWeappQrcodeUrlGen_WeappQrcodeGenerateResponse WeappQrcodeGenerateResponse { get; set; }
    }

    /// <summary>
    /// response
    /// </summary>
    public class PddDdkWeappQrcodeUrlGen_WeappQrcodeGenerateResponse
    {
        /// <summary>
        /// 单品推广小程序二维码url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

