using System.Threading.Tasks;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 查询推广位【申请】--请求参数
    /// 工具商媒体帮助子站长查询推广位。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.position.query
    /// </summary>
    public class JdUnionOpenPositionQueryRequest : JdBaseRequest
    {
        public JdUnionOpenPositionQueryRequest() { }

        public JdUnionOpenPositionQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.position.query";

        protected override string ParamName => "positionReq";

        public async Task<JdBaseResponse<JdUnionOpenPositionQueryResponse>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenPositionQueryResponse>>();

        /// <summary>
        /// 描述：需要查询的目标联盟id
        /// 必填：true
        /// 例如：10000618
        /// </summary>
        public long unionId { get; set; }
        /// <summary>
        /// 描述：目标联盟ID对应的授权key，在联盟推广管理页领取
        /// 必填：true
        /// 例如：
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 描述：联盟推广位类型，1：cps推广位  2：cpc推广位
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int unionType { get; set; }
        /// <summary>
        /// 描述：页码，上限10000
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 描述：每页条数，上限100
        /// 必填：true
        /// 例如：20
        /// </summary>
        public int pageSize { get; set; }
    }



    /// <summary>
    /// 查询推广位【申请】--响应参数
    /// 工具商媒体帮助子站长查询推广位。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.position.query
    /// </summary>
    public class JdUnionOpenPositionQueryResponse
    {
        /// <summary>
        /// 描述：页码
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int pageNo { get; set; }
        /// <summary>
        /// 描述：每页数量
        /// 必填：true
        /// 例如：10
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 描述：返回结果
        /// 必填：true
        /// 例如：
        /// </summary>
        public JdUnionOpenPositionQuery_positionresp[] result { get; set; }
        /// <summary>
        /// 返回结果
        /// </summary>
        public class JdUnionOpenPositionQuery_positionresp
        {
            /// <summary>
            /// 描述：推广位ID
            /// 必填：true
            /// 例如：6188886186
            /// </summary>
            public long id { get; set; }
            /// <summary>
            /// 描述：站点ID，如网站ID/appID/snsID
            /// 必填：true
            /// 例如：0
            /// </summary>
            public long siteId { get; set; }
            /// <summary>
            /// 描述：推广位名称
            /// 必填：true
            /// 例如：test3
            /// </summary>
            public string spaceName { get; set; }
            /// <summary>
            /// 描述：站点类型(1网站推广位2.APP推广位3.社交媒体推广位4.聊天工具推广位)
            /// 必填：true
            /// 例如：4
            /// </summary>
            public long type { get; set; }
        }
        /// <summary>
        /// 描述：总数
        /// 必填：true
        /// 例如：3
        /// </summary>
        public long total { get; set; }
    }
}

