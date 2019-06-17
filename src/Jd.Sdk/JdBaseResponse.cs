using Common;

namespace Jd.Sdk
{
    /// <summary>
    /// 响应基类
    /// </summary>
    public abstract class JdBaseResponse 
    {
        public string apiCodeEnum { get; set; } = string.Empty;

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
        public int code { get; set; }

        /// <summary>
        /// 结果信息，明细请参照code描述
        /// </summary>
        public string message { get; set; } = string.Empty;

        public string requestId { get; set; } = string.Empty;

        /// <summary>
        /// 弱类型的（当不需要处理数据的时候）
        /// </summary>
        public object data { get; set; }
    }

    /// <summary>
    /// 响应基类
    /// 需要指定data内容
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JdBaseResponse<T> : JdBaseResponse
    {
        public new T data { get; set; }
    }

    public class JdResponseResultEntity
    {
        public string result { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
    }
}