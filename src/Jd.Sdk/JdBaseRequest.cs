using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Common;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jd.Sdk
{
    public abstract class JdBaseRequest
    {
        /// <summary>
        /// 必填 分配给应用的AppKey
        /// </summary>
        private readonly string _appKey;

        /// <summary>
        /// 密钥
        /// </summary>
        private readonly string _appSecret;

        protected JdBaseRequest()
        {
            _appKey = "todo";
            _appSecret = "todo";
            _timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 非必填 通过code获取的access_token(无需授权的接口，Oauth2颁发的动态令牌,暂不支持使用)
        /// </summary>
        private readonly string _accessToken;

        protected JdBaseRequest(string appKey, string appSecret, string accessToken = null)
        {
            _appKey = appKey;
            _appSecret = appSecret;
            _accessToken = accessToken;
            _timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 必填 API接口名称
        /// </summary>
        protected abstract string Method { get; }

        /// <summary>
        /// 业务数据名称
        /// </summary>
        protected abstract string ParamName { get; }

        /// <summary>
        /// 业务数据
        /// </summary>
        protected virtual object Param => this;

        /// <summary>
        /// url前缀
        /// </summary>
        private string _baseUrl = "https://router.jd.com/api";

        /// <summary>
        /// 必填 时间戳，格式为yyyy-MM-dd HH:mm:ss，时区为GMT+8，例如：2018-08-01 13:00:00。API服务端允许客户端请求最大时间误差为10分钟
        /// </summary>
        private readonly string _timestamp;

        /// <summary>
        /// 必填 响应格式。暂时只支持json
        /// </summary>
        private readonly string _format = "json";

        /// <summary>
        /// 必填 API协议版本，可选值：1.0 version
        /// </summary>
        private readonly string _version = "1.0";

        /// <summary>
        /// 必填 签名的摘要算法， md5
        /// </summary>
        private readonly string _signMethod = "md5";

        /// <summary>
        /// 调试信息
        /// </summary>
        [JsonIgnore]
        public object DebugInfo { get; private set; }

        /// <summary>
        /// json内容的业务数据
        /// </summary>
        private string param_json
            => JsonConvert.SerializeObject(
                new Dictionary<string, object> { { ParamName, Param } },
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

        private string GetUrlParams()
        {
            var signParams = new Dictionary<string, object>
            {
                {"method", Method},
                {"app_key", _appKey},
                {"timestamp", _timestamp},
                {"format", _format},
                {"v", _version},
                {"sign_method", _signMethod}
            };
            if (!string.IsNullOrWhiteSpace(_accessToken)) // 如果需要
            {
                signParams.Add(nameof(_accessToken), _accessToken);
            }

            var urlParams = string.Empty;
            foreach (var item in signParams)
            {
                urlParams += $"&{item.Key}={HttpUtility.UrlEncode(item.Value.ToString(), Encoding.UTF8)}";
            }

            signParams.Add(nameof(param_json), param_json); // param json 参与加密但是不参与url
            var sign = Sign.SignToMd5(signParams, _appSecret);
            urlParams += "&sign=" + sign;
            return urlParams.TrimStart('&');
        }

        protected async Task<TResponse> PostAsync<TResponse>()
            where TResponse : JdBaseResponse
        {
            var url = _baseUrl + "?" + GetUrlParams();

            var async = await url
                        .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                        .PostStringAsync($"param_json={HttpUtility.UrlEncode(param_json, Encoding.UTF8)}");

            var @string = await async.Content.ReadAsStringAsync();
            try
            {
                var flag = JsonConvert.DeserializeObject<Dictionary<string, JdResponseResultEntity>>(@string).First();
                var value = flag.Value;
                if (value.Code != "0") throw new Exception(@string);
                DebugInfo = new
                {
                    Url = url,
                    Request = param_json,
                    Response = @string
                };
                return JsonConvert.DeserializeObject<TResponse>(value.Result);
            }
            catch (Exception ex)
            {
                DebugInfo = new
                {
                    Url = url,
                    Request = param_json,
                    ex
                };
                //throw new Exception($"{@string}\r\n-----------------------------\r\n{ex}");
                return default;
            }
        }
    }
}