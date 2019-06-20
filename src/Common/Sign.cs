using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

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
        public static string SignToMd5(Dictionary<string, object> @params, string secret)
        {
            var sortDic = new SortedDictionary<string, object>(@params);
            var query = new StringBuilder(secret);
            foreach (var item in sortDic)
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
