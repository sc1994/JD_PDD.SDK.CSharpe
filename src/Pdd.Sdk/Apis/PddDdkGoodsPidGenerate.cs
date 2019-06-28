using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 创建多多进宝推广位--请求参数
    /// 创建多多进宝推广位
    /// pdd.ddk.goods.pid.generate
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.goods.pid.generate
    /// </summary>
    public class PddDdkGoodsPidGenerateRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.goods.pid.generate";

        public PddDdkGoodsPidGenerateRequest() { }

        public PddDdkGoodsPidGenerateRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkGoodsPidGenerateResponse> InvokeAsync()
            => await PostAsync<PddDdkGoodsPidGenerateResponse>();
        /// <summary>
        /// 必填
        /// 要生成的推广位数量，默认为10，范围为：1~100
        /// </summary>
        public long? Number { get; set; }
        /// <summary>
        /// 不必填
        /// 推广位名称，例如["1","2"]
        /// </summary>
        public string[] PIdNameList { get; set; }
    }


    /// <summary>
    /// 创建多多进宝推广位--响应参数
    /// 创建多多进宝推广位
    /// </summary>
    public class PddDdkGoodsPidGenerateResponse : PddBaseResponse
    {
        /// <summary>
        /// response
        /// </summary>
        [JsonProperty("p_id_generate_response")]
        public PddDdkGoodsPidGenerate_PIdGenerateResponse PIdGenerateResponse { get; set; }
    }

    /// <summary>
    /// 多多进宝推广位对象列表
    /// </summary>
    public class PddDdkGoodsPidGenerate_PIdList
    {
        /// <summary>
        /// 推广位名称
        /// </summary>
        [JsonProperty("pid_name")]
        public string PidName { get; set; }
        /// <summary>
        /// 调用方推广位ID
        /// </summary>
        [JsonProperty("p_id")]
        public string PId { get; set; }
        /// <summary>
        /// 推广位创建时间
        /// </summary>
        [JsonProperty("create_time")]
        public long? CreateTime { get; set; }
    }
    /// <summary>
    /// response
    /// </summary>
    public class PddDdkGoodsPidGenerate_PIdGenerateResponse
    {
        /// <summary>
        /// 多多进宝推广位对象列表
        /// </summary>
        [JsonProperty("p_id_list")]
        public PddDdkGoodsPidGenerate_PIdList[] PIdList { get; set; }
    }
}

