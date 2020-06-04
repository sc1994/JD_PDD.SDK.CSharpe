using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System;

namespace Common
{
    public class Sign
    {
        /// <summary>
        /// sign to md5
        /// </summary>
        /// <param name="params"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static string SignToMd5(Dictionary<string, string> @params, string secret)
        {
            var query = new StringBuilder(secret);
            foreach (var item in @params.OrderBy(x => x.Key, StringComparer.Ordinal))
            {
                if (string.IsNullOrEmpty(item.Key)) continue;
                query.Append(item.Key).Append(item.Value);
            }
            query.Append(secret);
            var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            return string.Join("", bytes.Select(x => x.ToString("X2")));
        }
    }
}
