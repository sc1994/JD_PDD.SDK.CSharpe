using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Common;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
            var config = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();

            _appKey = config.GetSection("JdSdk")?["AppKey"];
            _appSecret = config.GetSection("JdSdk")?["AppSecret"];
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
        /// url前缀
        /// </summary>
        private readonly string _baseUrl = "https://router.jd.com/api";

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
        private string _paramJson;

        /// <summary>
        /// 首字符小写
        /// </summary>
        /// <returns></returns>
        private string FirstLower(string source)
            => source[0].ToString().ToLower() + source.Substring(1);

        protected async Task<TResponse> PostAsync<TResponse>()
            where TResponse : JdBaseResponse
        {
            var signParams = new Dictionary<string, string>
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
                signParams.Add("access_token", _accessToken);
            }

            var properties = GetType().GetProperties()
                                      .Where(x => x.Name != nameof(DebugInfo))
                                      .ToDictionary(x => FirstLower(x.Name), x => x.GetValue(this));
            var whereProperties = properties.Where(x => x.Value != default)
                                            .ToDictionary(x => x.Key, x => x.Value);
            if (properties.Count > 1)
            {
                _paramJson = JsonConvert.SerializeObject(new Dictionary<string, object>
                {
                    {ParamName, whereProperties}
                }); // 自计算需要传入的参数，减少model的代码体积
            }
            else if (properties.Count == 1)
            {
                _paramJson = JsonConvert.SerializeObject(new Dictionary<string, object>
                {
                    {ParamName, whereProperties.FirstOrDefault().Value}
                });
            }
            else
            {
                _paramJson = $"{{\"{ParamName}\":{{}}";
            }

            var urlParams = string.Empty;
            foreach (var item in signParams)
            {
                urlParams += $"&{item.Key}={HttpUtility.UrlEncode(item.Value.ToString(), Encoding.UTF8)}";
            }

            signParams.Add("param_json", _paramJson); // param json 参与加密但是不参与url
            var sign = Sign.SignToMd5(signParams, _appSecret);
            urlParams += "&sign=" + sign;

            var url = _baseUrl + "?" + urlParams.TrimStart('&');
            Debug.WriteLine(url);
            Debug.WriteLine($"param_json={HttpUtility.UrlEncode(_paramJson, Encoding.UTF8)}");
            var async = await url
                        .WithHeader("Content-Type", "application/x-www-form-urlencoded")
                        .PostStringAsync($"param_json={HttpUtility.UrlEncode(_paramJson, Encoding.UTF8)}");

            var @string = await async.Content.ReadAsStringAsync();
            Debug.WriteLine(@string);
            try
            {
                var flag = JsonConvert.DeserializeObject<Dictionary<string, JdResponseResultEntity>>(@string).First();
                var value = flag.Value;
                if (value.Code != "0") throw new Exception(@string);
                DebugInfo = new
                {
                    Url = url,
                    Request = _paramJson,
                    Response = @string
                };
                return JsonConvert.DeserializeObject<TResponse>(value.Result);
            }
            catch (Exception ex)
            {
                DebugInfo = new
                {
                    Url = url,
                    Request = _paramJson,
                    ex
                };
                //throw new Exception($"{@string}\r\n-----------------------------\r\n{ex}");
                return default;
            }
        }
    }
}