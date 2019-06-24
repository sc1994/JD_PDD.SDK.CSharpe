using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 创建推广位【申请】--请求参数
    /// 工具商媒体帮助多个子站长ID批量创建推广位，每个联盟ID最多创建1万个推广位。其中业务参数key需要由子站长进入联盟官网-推广管理-API权限管理中获取， 有效期60天。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.position.create
    /// https://union.jd.com/openplatform/api/655
    /// </summary>
    public class JdUnionOpenPositionCreateRequest : JdBaseRequest
    {
        public JdUnionOpenPositionCreateRequest() { }

        public JdUnionOpenPositionCreateRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.position.create";

        protected override string ParamName => "positionReq";

        public async Task<JdBaseResponse<JdUnionOpenPositionCreateResponse>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenPositionCreateResponse>>();

        /// <summary>
        /// 必填
        /// 描述：需要创建的目标联盟id
        /// 例如：10000618
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? UnionId { get; set; }
        /// <summary>
        /// 必填
        /// 描述：目标联盟ID对应的授权key，在联盟推广管理页领取
        /// 例如：
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Key { get; set; }
        /// <summary>
        /// 必填
        /// 描述：1：cps推广位  2：cpc推广位
        /// 例如：1
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? UnionType { get; set; }
        /// <summary>
        /// 必填
        /// 描述：站点类型 1网站推广位2.APP推广位3.社交媒体推广位4.聊天工具推广位5.二维码推广
        /// 例如：4
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Type { get; set; }
        /// <summary>
        /// 必填
        /// 描述：推广位名称集合，英文,分割；上限50
        /// 例如：
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] SpaceNameList { get; set; }
        /// <summary>
        /// 不必填
        /// 描述：站点ID，即网站ID/app ID/snsID ,当type传入4以外的值时，siteId为必填
        /// 例如：61800001
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? SiteId { get; set; }
    }



    /// <summary>
    /// 创建推广位【申请】--响应参数
    /// 工具商媒体帮助多个子站长ID批量创建推广位，每个联盟ID最多创建1万个推广位。其中业务参数key需要由子站长进入联盟官网-推广管理-API权限管理中获取， 有效期60天。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.position.create
    /// </summary>
    public class JdUnionOpenPositionCreateResponse
    {
        /// <summary>
        /// 描述：推广位结果集合
        /// 例如：&quot;test4&quot;: 6186666082
        /// </summary>
        public System.Collections.Generic.Dictionary<string, object> ResultList { get; set; }
        /// <summary>
        /// 描述：站点ID
        /// 例如：1
        /// </summary>
        public long? SiteId { get; set; }
        /// <summary>
        /// 描述：联盟类型
        /// 例如：4
        /// </summary>
        public long? Type { get; set; }
        /// <summary>
        /// 描述：联盟ID
        /// 例如：618618
        /// </summary>
        public long? UnionId { get; set; }
    }
}

