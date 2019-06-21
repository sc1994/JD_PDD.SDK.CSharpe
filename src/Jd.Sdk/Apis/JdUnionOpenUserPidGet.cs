using System.Threading.Tasks;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 获取PID--请求参数
    /// 工具商媒体帮助子站长创建PID，该参数可在媒体和子站长之间建立关联，并通过获取推广链接、订单查询来跟踪。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.user.pid.get
    /// </summary>
    public class JdUnionOpenUserPidGetRequest : JdBaseRequest
    {
        public JdUnionOpenUserPidGetRequest() { }

        public JdUnionOpenUserPidGetRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.user.pid.get";

        protected override string ParamName => "pidReq";

        public async Task<JdBaseResponse<JdUnionOpenUserPidGetResponse>> InvokeAsync()
            => await PostAsync<JdBaseResponse<JdUnionOpenUserPidGetResponse>>();

        /// <summary>
        /// 描述：联盟ID
        /// 必填：true
        /// 例如：10000618
        /// </summary>
        public long unionId { get; set; }
        /// <summary>
        /// 描述：子站长ID
        /// 必填：true
        /// 例如：61800001
        /// </summary>
        public long childUnionId { get; set; }
        /// <summary>
        /// 描述：推广类型,1APP推广 2聊天工具推广 
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int promotionType { get; set; }
        /// <summary>
        /// 描述：子站长的推广位名称，如不存在则创建，不填则由联盟根据母账号信息创建 
        /// 必填：false
        /// 例如：
        /// </summary>
        public string positionName { get; set; }
        /// <summary>
        /// 描述：媒体名称，即子站长的app应用名称，推广方式为app推广时必填，且app名称必须为已存在的app名称 
        /// 必填：true
        /// 例如：huhu
        /// </summary>
        public string mediaName { get; set; }
    }



    /// <summary>
    /// 获取PID--响应参数
    /// 工具商媒体帮助子站长创建PID，该参数可在媒体和子站长之间建立关联，并通过获取推广链接、订单查询来跟踪。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.user.pid.get
    /// </summary>
    public class JdUnionOpenUserPidGetResponse
    {
    }
}

