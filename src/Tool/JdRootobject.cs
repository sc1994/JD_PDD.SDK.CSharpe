using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;

namespace Tool
{
    partial class Program
    {
        static async Task<string[]> GetJdCode(int id)
        {
            var sender = await $"https://union.jd.com/api/apiDoc/apiDocInfo?apiId={id}".PostJsonAsync(new object());
            var @string = await sender.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<JdRootObject>(@string);

            var className = string.Join("", root.Data.ApiName.Split('.').Select(UpperFirst));
            var code = new StringBuilder();
            code.AppendLine("using System.Threading.Tasks;");
            code.AppendLine();
            code.AppendLine("namespace Jd.Sdk.Apis");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine($"    /// {root.Data.Caption}--请求参数");
            code.AppendLine($"    /// {root.Data.Description.Trim()}");
            code.AppendLine($"    /// {root.Data.ApiName.Trim()}");
            code.AppendLine($"    /// https://union.jd.com/openplatform/api/{id}");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public class {className}Request : JdBaseRequest");
            code.AppendLine("    {");
            code.AppendLine($"        public {className}Request() {{ }}");
            code.AppendLine();
            code.AppendLine($"        public {className}Request(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) {{ }}");
            code.AppendLine();
            code.AppendLine($"        protected override string Method => \"{root.Data.ApiName}\";");
            code.AppendLine();
            var firstReq = root.Data.PLists.FirstOrDefault(x => x.DataType.EndsWith("Req"));
            if (firstReq == null)
            {
                firstReq = root.Data.PLists.First(x => x.DataName != "ROOT");

                code.AppendLine("        /// <summary>");
                code.AppendLine($"        /// {(firstReq.IsRequired.Trim() == "true" ? "必填" : "不必填")}");
                code.AppendLine($"        /// 描述：{firstReq.Description.Trim()}");
                code.AppendLine($"        /// 例如：{firstReq.SampleValue.Trim()}");
                code.AppendLine("        /// </summary>");
                code.AppendLine($"        public {SwitchType(firstReq.DataType)} {UpperFirst(firstReq.DataName)} {{ get; set; }}");
                code.AppendLine();
            }

            code.AppendLine($"        protected override string ParamName => \"{firstReq.DataName}\";");
            code.AppendLine();

            var isPage = root.Data.SLists.Any(x => x.DataName == "hasMore")
                ? "JdBasePageResponse"
                : "JdBaseResponse";
            var firstData = root.Data.SLists.FirstOrDefault(x => x.DataName == "data");
            var isArray = string.Empty;
            if (firstData != default)
            {
                isArray = firstData.DataType.EndsWith("[]")
                    ? $"<{className}Response[]>"
                    : $"<{className}Response>";
            }
            else
            {

            }
            code.AppendLine($"        public async Task<{isPage}{isArray}> InvokeAsync()");
            code.AppendLine($"            => await PostAsync<{isPage}{isArray}>();");
            code.AppendLine();

            foreach (var item in root.Data.PLists.Where(x => x.DataName != "ROOT" && x.DataName != firstReq.DataName))
            {
                GetJdParamStereoscopic(item, root.Data.PLists, className, "        ", true, ref code);
            }

            code.AppendLine("    }");
            code.AppendLine();
            code.AppendLine();
            code.AppendLine();

            if (firstData != default)
            {

                code.AppendLine("    /// <summary>");
                code.AppendLine($"    /// {root.Data.Caption}--响应参数");
                code.AppendLine($"    /// {root.Data.Description.Trim()}");
                code.AppendLine($"    /// {root.Data.ApiName.Trim()}");
                code.AppendLine("    /// </summary>");
                code.AppendLine($"    public class {className}Response");
                code.AppendLine("    {");
                foreach (var item in root.Data.SLists.Where(x => x.ParentId == firstData.NodeId))
                {
                    GetJdParamStereoscopic(item, root.Data.SLists, className, "        ", false, ref code);
                }
                code.AppendLine("    }");
            }
            else
            {
                code.AppendLine("    //--------------------------------------");
                code.AppendLine("    // 返回值没有data内容，直接使用基础响应基类");
                code.AppendLine("    //--------------------------------------");
            }
            code.AppendLine("}");
            return code.ToString().Split("\r\n");
        }

        static void GetJdParamStereoscopic(
            JdPlist item,
            JdPlist[] all,
            string className,
            string spacing,
            bool isRequest,
            ref StringBuilder code)
        {
            code.AppendLine($"{spacing}/// <summary>");
            if (isRequest)
            {
                code.AppendLine($"{spacing}/// {(item.IsRequired.Trim() == "true" ? "必填" : "不必填")}");
            }
            code.AppendLine($"{spacing}/// 描述：{item.Description}");
            code.AppendLine($"{spacing}/// 例如：{item.SampleValue}");
            code.AppendLine($"{spacing}/// </summary>");

            var currentNodes = all.Where(x => x.ParentId == item.NodeId).ToArray();

            if (currentNodes.Any())
            {
                var tempName = item.DataType.Replace("[]", "").ToLower();
                var tempSymbol = item.DataType.EndsWith("[]") ? "[]" : "";
                code.AppendLine($"{spacing}public {className}_{UpperFirst(tempName)}{tempSymbol} {UpperFirst(item.DataName)} {{ get; set; }}");
                code.AppendLine($"{spacing}/// <summary>");
                code.AppendLine($"{spacing}/// {item.Description}");
                code.AppendLine($"{spacing}/// </summary>");
                code.AppendLine($"{spacing}public class {className}_{UpperFirst(tempName)}");
                code.AppendLine($"{spacing}{{");
                foreach (var that in currentNodes)
                {
                    GetJdParamStereoscopic(that, all, className, spacing + "    ", isRequest, ref code);
                }
                code.AppendLine($"{spacing}}}");
            }
            else
            {
                code.AppendLine($"{spacing}public {SwitchType(item.DataType)} {UpperFirst(item.DataName)} {{ get; set; }}");
            }
        }
    }

    public class JdRootObject
    {
        public JdData Data { get; set; }
    }

    public class JdData
    {
        public string ApiName { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public JdPlist[] PLists { get; set; }
        public JdPlist[] SLists { get; set; }
    }

    public class JdPlist
    {
        public int NodeId { get; set; }
        public int? ParentId { get; set; }
        public string DataName { get; set; }
        public string DataType { get; set; }
        public string IsRequired { get; set; }
        public string SampleValue { get; set; }
        public string Description { get; set; }
    }

    public class JdAllApi
    {
        public JdDatum[] Data { get; set; }
    }

    public class JdDatum
    {
        public JdApi[] Apis { get; set; }
    }

    public class JdApi
    {
        public int ApiId { get; set; }
        public string ApiName { get; set; }
    }
}