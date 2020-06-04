using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Pdd.Sdk
{
    public abstract class PddBaseRequest
    {
        /// <summary>
        /// 必填
        /// UNIX时间戳，单位秒，需要与拼多多服务器时间差值在10分钟内
        /// </summary>
        protected readonly string _timestamp;

        /// <summary>
        /// 必填
        /// client_secret
        /// </summary>
        private readonly string _clientSecret;

        /// <summary>
        /// 必填
        /// POP分配给应用的client_id
        /// </summary>
        private readonly string _clientId;

        protected PddBaseRequest()
        {
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
            _timestamp = Time.GetTimeStampSecond();
            _clientId = config.GetSection("Pdd.Sdk")["ClientId"];
            _clientSecret = config.GetSection("Pdd.Sdk")["ClientSecret"];
        }

        protected PddBaseRequest(string clientId, string clientSecret)
        {
            _timestamp = Time.GetTimeStampSecond();
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        private const string _baseUrl = "http://gw-api.pinduoduo.com/api/router";

        /// <summary>
        /// 必填
        /// API接口名称
        /// </summary>
        protected abstract string Type { get; }

        /// <summary>
        /// 不必填
        /// 通过code获取的access_token(无需授权的接口，该字段不参与sign签名运算)
        /// </summary>
        protected string AccessToken { get; set; }

        public object DebugInfo { get; private set; }

        protected async Task<TResponse> PostAsync<TResponse>()
            where TResponse : PddBaseResponse
        {
            var dicParams = new Dictionary<string, string>
            {
                { "timestamp", _timestamp },
                { "client_id", _clientId },
                { "type", Type },
                { "data_type", "JSON" },
                { "version", "V1" }
            };

            var dicDerive = GetType()
                .GetProperties()
                .Where(x =>
                {
                    if (x.Name == nameof(DebugInfo)) return false;
                    var val = x.GetValue(this);
                    if (val is string str)
                    {
                        return !string.IsNullOrWhiteSpace(str);
                    }
                    return val != null;
                })
                .ToDictionary(
                    x => ConvertExtend.UpperToUnderline(x.Name), x => x.GetValue(this).ToString());

            foreach (var item in dicDerive)
            {
                dicParams.Add(item.Key, item.Value);
            }
            var sign = Sign.SignToMd5(dicParams.ToDictionary(x => x.Key, x => x.Value), _clientSecret);
            var urlParams = $"?sign={sign}";
            foreach (var item in dicParams)
            {
                urlParams += $"&{item.Key}={HttpUtility.UrlEncode(item.Value, Encoding.UTF8)}";
            }

            var url = _baseUrl + urlParams;
            Debug.WriteLine(url);
            var async = await url.PostStringAsync(string.Empty);
            var @string = await async.Content.ReadAsStringAsync();
            Debug.WriteLine(@string);
            try
            {
                if (@string.Contains("\"error_response\":{\"error_msg\":\"")) // todo 有注入的风险
                {
                    var resError = JsonConvert.DeserializeObject<KeyValuePair<string, string>>(@string);
                    DebugInfo = new
                    {
                        url,
                        resError
                    };
                    return default;
                }
                var res = JsonConvert.DeserializeObject<Dictionary<string, TResponse>>(@string);
                DebugInfo = new
                {
                    url,
                    res
                };
                return res.First().Value;
            }
            catch (Exception ex)
            {
                DebugInfo = new
                {
                    url,
                    @string,
                    ex
                };
                return default;
            }
        }
    }

    public abstract class PddPageBaseRequest : PddBaseRequest
    {
        /// <summary>
        /// 必填
        /// 页大小
        /// </summary>
        /// <value></value>
        public int PageSize { get; set; }
        /// <summary>
        /// 必填
        /// 页
        /// </summary>
        /// <value></value>
        public int Page { get; set; }
    }
}