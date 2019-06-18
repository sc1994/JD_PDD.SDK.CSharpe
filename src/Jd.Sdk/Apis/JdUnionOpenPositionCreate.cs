namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 创建推广位【申请】--请求参数
    /// 工具商媒体帮助多个子站长ID批量创建推广位，每个联盟ID最多创建1万个推广位。其中业务参数key需要由子站长进入联盟官网-推广管理-API权限管理中获取， 有效期60天。需向cps-qxsq@jd.com申请权限。
    /// jd.union.open.position.create
    /// </summary>
    public class JdUnionOpenPositionCreateRequest : JdBaseRequest
    {
        public JdUnionOpenPositionCreateRequest() { }

        public JdUnionOpenPositionCreateRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string method => "jd.union.open.position.create";

        protected override string ParamName => "positionReq";

        /// <summary>
        /// 描述：需要创建的目标联盟id
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
        /// 描述：1：cps推广位  2：cpc推广位
        /// 必填：true
        /// 例如：1
        /// </summary>
        public int unionType { get; set; }
        /// <summary>
        /// 描述：站点类型 1网站推广位2.APP推广位3.社交媒体推广位4.聊天工具推广位5.二维码推广
        /// 必填：true
        /// 例如：4
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 描述：推广位名称集合，英文,分割；上限50
        /// 必填：true
        /// 例如：
        /// </summary>
        public string[] spaceNameList { get; set; }
        /// <summary>
        /// 描述：站点ID，即网站ID/app ID/snsID ,当type传入4以外的值时，siteId为必填
        /// 必填：false
        /// 例如：61800001
        /// </summary>
        public long siteId { get; set; }
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
        /// 必填：true
        /// 例如：&quot;test4&quot;: 6186666082
        /// </summary>
        public System.Collections.Generic.Dictionary<string, object> resultList { get; set; }
        /// <summary>
        /// 描述：站点ID
        /// 必填：true
        /// 例如：1
        /// </summary>
        public long siteId { get; set; }
        /// <summary>
        /// 描述：联盟类型
        /// 必填：true
        /// 例如：4
        /// </summary>
        public long type { get; set; }
        /// <summary>
        /// 描述：联盟ID
        /// 必填：true
        /// 例如：618618
        /// </summary>
        public long unionId { get; set; }
    }
}

