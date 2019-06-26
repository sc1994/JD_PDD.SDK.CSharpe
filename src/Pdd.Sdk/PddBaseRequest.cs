using System.Threading.Tasks;
using Common;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

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

        private readonly string _baseUrl = "";

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

        /// <summary>
        /// 必填
        /// API输入参数签名结果，签名算法参考开放平台接入指南第三部分底部。
        /// /// </summary>
        protected string Sign { get; set; }

        //protected async Task<TResponse> PostAsync<TResponse>()
        //{
        //    var url = _baseUrl;
        //    var async = url.PostStringAsync(string.Empty);

        //}
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