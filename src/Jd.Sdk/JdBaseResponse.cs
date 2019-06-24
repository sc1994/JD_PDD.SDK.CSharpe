namespace Jd.Sdk
{
    /// <summary>
    /// 响应基类
    /// </summary>
    public class JdBaseResponse
    {
        public string ApiCodeEnum { get; set; } = string.Empty;

        /// <summary>
        /// 200:success;
        /// 500:服务端异常;
        /// 400:参数错误;
        /// 401:验证失败;
        /// 403:无访问权限;
        /// 404数据不存在;
        /// 409:数据已存在;
        /// 410:联盟用户不存在，请检查unionId是否正确;
        /// 411:unionId不正确，请检查unionId是否正确;
        /// 2003101:参数异常，skuIds为空;
        /// 2003102:参数异常，sku个数为1-100个;
        /// 2003103:接口异常，没有相关权限;
        /// 2003104:请求商品信息{X}条，成功返回{Y}条, 失败{Z}条;
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 结果信息，明细请参照code描述
        /// </summary>
        public string Message { get; set; } = string.Empty;

        public string RequestId { get; set; } = string.Empty;

        /// <summary>
        /// 弱类型的（当不需要处理数据的时候）
        /// </summary>
        public object Data { get; set; }
    }

    /// <summary>
    /// 响应基类
    /// 需要指定data内容
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JdBaseResponse<T> : JdBaseResponse
    {
        public new T Data { get; set; }
    }

    /// <summary>
    /// 分页基础返回类
    /// </summary>
    public class JdBasePageResponse<T> : JdBaseResponse
    {
        public new T[] Data { get; set; }

        /// <summary>
        /// 是否还有更多,true：还有数据；false:已查询完毕，没有数据
        /// </summary>
        public bool HasMore { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public long TotalCount { get; set; }
    }

    public class JdResponseResultEntity
    {
        public string Result { get; set; }
        public string Code { get; set; }
        public string Msg { get; set; }
    }
}