using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Common;
using Flurl.Http;
using Newtonsoft.Json;

namespace Jd.Sdk
{
    /// <summary>
    /// 请求基类
    /// 例外：
    ///     如果需要请求参数属性唯一（比如：jd.union.open.coupon.query）则需重写：Param，将Param指向唯一的属性
    /// </summary>
    public abstract class BaseApiRequest
    {
        public BaseApiRequest()
        {
            app_key = "todo";
            app_secret = "todo";
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public BaseApiRequest(string appKey, string appSecret, string accessToken = null)
        {
            app_key = appKey;
            app_secret = appSecret;
            access_token = accessToken;
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private string _baseUrl = "https://router.jd.com/api";

        /// <summary>
        /// 必填 API接口名称
        /// </summary>
        protected abstract string method { get; }

        /// <summary>
        /// 业务数据名称
        /// </summary>
        /// <value></value>
        protected abstract string ParamName { get; }

        /// <summary>
        /// 必填 分配给应用的AppKey
        /// </summary>
        private string app_key { get; }

        /// <summary>
        /// 密钥
        /// </summary>
        private string app_secret { get; }

        /// <summary>
        /// 业务数据
        /// </summary>
        protected virtual object Param => this;

        /// <summary>
        /// 非必填 通过code获取的access_token(无需授权的接口，Oauth2颁发的动态令牌,暂不支持使用)
        /// </summary>
        protected virtual string access_token { get; set; }

        /// <summary>
        /// 必填 时间戳，格式为yyyy-MM-dd HH:mm:ss，时区为GMT+8，例如：2018-08-01 13:00:00。API服务端允许客户端请求最大时间误差为10分钟
        /// </summary>
        private string timestamp { get; set; }

        /// <summary>
        /// 必填 响应格式。暂时只支持json
        /// </summary>
        private string format { get; set; } = "json";

        /// <summary>
        /// 必填 API协议版本，可选值：1.0 version
        /// </summary>
        private string v { get; set; } = "1.0";

        /// <summary>
        /// 必填 签名的摘要算法， md5
        /// </summary>
        private string sign_method { get; set; } = "md5";

        /// <summary>
        /// json内容的业务数据
        /// </summary>
        private string param_json
            => JsonConvert.SerializeObject(new Dictionary<string, object>() { { ParamName, Param } });

        private string GetUrlParams()
        {
            var signParams = new Dictionary<string, object>
            {
                {nameof(method), method},
                {nameof(app_key), app_key},
                {nameof(timestamp), timestamp},
                {nameof(format), format},
                {nameof(v), v},
                {nameof(sign_method), sign_method}
            };
            if (!string.IsNullOrWhiteSpace(access_token)) // 如果需要
            {
                signParams.Add(nameof(access_token), access_token);
            }

            var urlParams = string.Empty;
            foreach (var item in signParams)
            {
                urlParams += $"&{item.Key}={HttpUtility.UrlEncode(item.Value.ToString(), Encoding.UTF8)}";
            }

            signParams.Add(nameof(param_json), param_json); // param json 参与加密但是不参与url
            var sign = Sign.SignToMd5(signParams, app_secret);
            urlParams += "&sign=" + sign;
            return urlParams.TrimStart('&');
        }

        public virtual async Task<TResponse> PostAsync<TResponse>()
            where TResponse : BaseApiResponse
        {
            var url = _baseUrl + "?" + GetUrlParams();

            var @async = await url
                        .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                        .PostStringAsync($"param_json={HttpUtility.UrlEncode(param_json, Encoding.UTF8)}");

            var @string = await @async.Content.ReadAsStringAsync();
            try
            {
                var flag = JsonConvert.DeserializeObject<Dictionary<string, ResultEntity>>(@string).First();
                var value = flag.Value;
                return JsonConvert.DeserializeObject<TResponse>(value.result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{@string}\r\n-----------------------------\r\n{ex}");
            }
        }
    }

    /// <summary>
    /// 响应基类
    /// </summary>
    public class BaseApiResponse
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
    public class BaseApiResponse<T> : BaseApiResponse
    {
        public new T data { get; set; }
    }

    public class ResultEntity
    {
        public string result { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
    }
}



