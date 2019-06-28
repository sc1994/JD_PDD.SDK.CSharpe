using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 查询已经生成的推广位信息--请求参数
    /// 查询已经生成的推广位信息
    /// pdd.ddk.goods.pid.query
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.goods.pid.query
    /// </summary>
    public class PddDdkGoodsPidQueryRequest : PddBaseRequest
    {
        protected override string Type => "pdd.ddk.goods.pid.query";

        public PddDdkGoodsPidQueryRequest() { }

        public PddDdkGoodsPidQueryRequest(string clientId, string clientSecret) : base(clientId, clientSecret) { }

        public async Task<PddDdkGoodsPidQueryResponse> InvokeAsync()
            => await PostAsync<PddDdkGoodsPidQueryResponse>();
        /// <summary>
        /// 不必填
        /// 返回的页数
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// 不必填
        /// 返回的每页推广位数量
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 不必填
        /// 推广位id列表
        /// </summary>
        public string[] PidList { get; set; }
    }


    /// <summary>
    /// 查询已经生成的推广位信息--响应参数
    /// 查询已经生成的推广位信息
    /// </summary>
    public class PddDdkGoodsPidQueryResponse : PddBaseResponse
    {
        /// <summary>
        /// response
        /// </summary>
        [JsonProperty("p_id_query_response")]
        public PddDdkGoodsPidQuery_PIdQueryResponse PIdQueryResponse { get; set; }
    }

    /// <summary>
    /// 多多进宝推广位对象列表
    /// </summary>
    public class PddDdkGoodsPidQuery_PIdList
    {
        /// <summary>
        /// 推广位生成时间
        /// </summary>
        [JsonProperty("create_time")]
        public long? CreateTime { get; set; }
        /// <summary>
        /// 推广位名称
        /// </summary>
        [JsonProperty("pid_name")]
        public string PidName { get; set; }
        /// <summary>
        /// 推广位ID
        /// </summary>
        [JsonProperty("p_id")]
        public string PId { get; set; }
    }
    /// <summary>
    /// response
    /// </summary>
    public class PddDdkGoodsPidQuery_PIdQueryResponse
    {
        /// <summary>
        /// 多多进宝推广位对象列表
        /// </summary>
        [JsonProperty("p_id_list")]
        public PddDdkGoodsPidQuery_PIdList[] PIdList { get; set; }
        /// <summary>
        /// 返回推广位总数
        /// </summary>
        [JsonProperty("total_count")]
        public long? TotalCount { get; set; }
    }
}

