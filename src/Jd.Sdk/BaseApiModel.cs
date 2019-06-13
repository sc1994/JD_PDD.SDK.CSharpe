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
                        // .WithHeader("Accept", "text/xml,text/javascript,text/html")
                        // .WithHeader("User-Agent", "360buy-sdk-java")
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

    public class BaseApiResponse
    {

    }

    public class ResultEntity
    {
        public string result { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
    }
}



