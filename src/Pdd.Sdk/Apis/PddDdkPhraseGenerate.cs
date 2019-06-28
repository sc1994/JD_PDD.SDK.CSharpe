using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 生成多多口令接口--请求参数
    /// 生成多多口令接口
    /// pdd.ddk.phrase.generate
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.phrase.generate
    /// </summary>
    public class PddDdkPhraseGenerateRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.phrase.generate";

        public PddDdkPhraseGenerateRequest() { }

        public PddDdkPhraseGenerateRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkPhraseGenerateResponse> InvokeAsync()
            => await PostAsync<PddDdkPhraseGenerateResponse>();
        /// <summary>
        /// 必填
        /// 推广位ID
        /// </summary>
        public string PId { get; set; }
        /// <summary>
        /// 必填
        /// 商品ID，仅支持单个查询, json 字符串 例子：[1112]
        /// </summary>
        public long[] GoodsIdList { get; set; }
        /// <summary>
        /// 不必填
        /// 是否多人团
        /// </summary>
        public bool? MultiGroup { get; set; }
        /// <summary>
        /// 不必填
        /// 自定义参数
        /// </summary>
        public string CustomParameters { get; set; }
        /// <summary>
        /// 不必填
        /// 招商多多客ID
        /// </summary>
        public long? ZsDuoId { get; set; }
        /// <summary>
        /// 不必填
        /// 1-大图弹框 2-对话弹框
        /// </summary>
        public int? Style { get; set; }
    }


    /// <summary>
    /// 生成多多口令接口--响应参数
    /// 生成多多口令接口
    /// </summary>
    public class PddDdkPhraseGenerateResponse : PddBaseResponse
    {
        /// <summary>
        /// 口令列表
        /// </summary>
        [JsonProperty("promotion_phrase_list")]
        public PddDdkPhraseGenerate_PromotionPhraseList[] PromotionPhraseList { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        [JsonProperty("total")]
        public int? Total { get; set; }
    }

    /// <summary>
    /// 口令列表
    /// </summary>
    public class PddDdkPhraseGenerate_PromotionPhraseList
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [JsonProperty("goods_id")]
        public long? GoodsId { get; set; }
        /// <summary>
        /// 口令
        /// </summary>
        [JsonProperty("phrase")]
        public string Phrase { get; set; }
    }
}

