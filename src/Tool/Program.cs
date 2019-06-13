using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System;
using Flurl.Http;
using Newtonsoft.Json;
using System.Web;

namespace Tool
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1-京东");
            Console.WriteLine("2-拼多多");
            var type = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("输入接口标识");
            var key = Console.ReadLine();
            string[] code = null;
            if (type.KeyChar == '1')
            {
                code = await GetJdCode(Convert.ToInt32(key));
                Console.WriteLine(string.Join("", code));
            }
            else if (type.KeyChar == '2')
            {
                code = await GetPddCode(key.Trim());
                Console.WriteLine(string.Join("", code));
            }
            if (code != null)
            {
                Directory.CreateDirectory("Codes");
                File.WriteAllLines($"Codes/{key}.cs", code);
            }
        }


        static async Task<string[]> GetJdCode(int id)
        {
            var sended = await $"https://union.jd.com/api/apiDoc/apiDocInfo?apiId={id}".PostJsonAsync(new object());
            var @string = await sended.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<JdRootobject>(@string);

            var className = string.Join("", root.data.apiName.Split('.').Select(UpperFirst));
            Console.WriteLine(className);
            var code = new StringBuilder();
            code.AppendLine("namespace todo");
            code.AppendLine("{");
            code.AppendLine("/// <summary>");
            code.AppendLine($"/// {root.data.caption}--请求参数");
            code.AppendLine($"/// {root.data.description}");
            code.AppendLine($"/// {root.data.apiName}");
            code.AppendLine("/// </summary>");
            code.AppendLine($"public partial class {className}Request : todo");
            code.AppendLine("{");
            code.AppendLine($"public {className}Request() {{ }}");
            code.AppendLine($"public {className}Request(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) {{ }}");
            code.AppendLine($"protected override string method => \"{root.data.apiName}\";");
            var firstReq = root.data.plists.FirstOrDefault(x => x.dataType.EndsWith("Req"));
            if (firstReq != null)
            {
                code.AppendLine($"protected override string ParamName => \"{firstReq.dataName}\";");
                foreach (var item in root.data.plists.Where(x => x.dataName != "ROOT" && x.dataName != firstReq.dataName))
                {
                    GetJdParamStereoscopic(item, root.data.plists, className, ref code);
                }
            }
            else
            {
                firstReq = root.data.plists.First(x => x.dataName != "ROOT");
                code.AppendLine($"protected override string ParamName => \"{firstReq.dataName}\";");
                code.AppendLine($"protected override object Param => \"{firstReq.dataName}\";");
                code.AppendLine("/// <summary>");
                code.AppendLine($"/// 描述：{firstReq.description}");
                code.AppendLine($"/// 必填：{firstReq.isRequired}");
                code.AppendLine($"/// 例如：{firstReq.sampleValue}");
                code.AppendLine("/// </summary>");
                code.AppendLine($"public {SwitchType(firstReq.dataType)} {firstReq.dataName} {{ get; set; }}");
            }

            code.AppendLine("}");
            code.AppendLine("");
            code.AppendLine("/// <summary>");
            code.AppendLine($"/// {root.data.caption}--响应参数");
            code.AppendLine($"/// {root.data.description}");
            code.AppendLine($"/// {root.data.apiName}");
            code.AppendLine("/// </summary>");
            code.AppendLine($"public partial class {className}Response");
            code.AppendLine("{");
            var firstData = root.data.slists.First(x => x.dataName == "data");
            foreach (var item in root.data.slists.Where(x => x.parentId == firstData.nodeId))
            {
                GetJdParamStereoscopic(item, root.data.slists, className, ref code);
            }
            code.AppendLine("}");
            code.AppendLine("}");
            return code.ToString().Split("\r\n", StringSplitOptions.None);
        }

        static void GetJdParamStereoscopic(
            Plist item,
            Plist[] all,
            string className,
            ref StringBuilder code)
        {
            code.AppendLine("/// <summary>");
            code.AppendLine($"/// 描述：{item.description}");
            code.AppendLine($"/// 必填：{item.isRequired}");
            code.AppendLine($"/// 例如：{item.sampleValue}");
            code.AppendLine("/// </summary>");

            var thats = all.Where(x => x.parentId == item.nodeId);
            if (thats.Any())
            {
                var tempName = item.dataType.Replace("[]", "");
                var tempSymbol = item.dataType.EndsWith("[]") ? "[]" : "";
                code.AppendLine($"public {className}_{tempName}{tempSymbol} {item.dataName} {{ get; set; }}");
                code.AppendLine("/// <summary>");
                code.AppendLine($"/// {item.description}");
                code.AppendLine("/// </summary>");
                code.AppendLine($"public partial class {className}_{tempName}");
                code.AppendLine("{");
                foreach (var that in thats)
                {
                    GetJdParamStereoscopic(that, all, className, ref code);
                }
                code.AppendLine("}");
            }
            else
            {
                code.AppendLine($"public {SwitchType(item.dataType.ToLower())} {item.dataName} {{ get; set; }}");
            }
        }

        static async Task<string[]> GetPddCode(string id)
        {
            var sended = await "https://open-api.pinduoduo.com/pop/doc/info/get".PostJsonAsync(new
            {
                id
            });

            var @string = await sended.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<PddRootobject>(@string);

            var className = root.result.scopeName;
            className = string.Join("", className.Split('.').Select(UpperFirst));
            Console.WriteLine(className);
            var code = new StringBuilder();
            code.AppendLine("namespace SurpriseGamePoll.UnionService");
            code.AppendLine("{");
            code.AppendLine("/// <summary>");
            code.AppendLine($"/// {root.result.apiName}--{root.result.usageScenarios}--请求参数");
            code.AppendLine($"/// {root.result.scopeName}");
            code.AppendLine("/// </summary>");
            code.AppendLine($"public partial class {className}Request : PddDDKBaseRequest");
            code.AppendLine("{");
            foreach (var item in root.result.requestParamList.Where(x => x.parentId == 0))
            {
                GetPddParamStereoscopic(item, root.result.requestParamList, className, ref code);
            }
            code.AppendLine("}");
            code.AppendLine();
            code.AppendLine();
            code.AppendLine();
            code.AppendLine("/// <summary>");
            code.AppendLine($"/// {root.result.apiName}--{root.result.usageScenarios}--响应参数");
            code.AppendLine($"/// {root.result.scopeName}");
            code.AppendLine("/// </summary>");
            code.AppendLine($"public partial class {className}Response");
            code.AppendLine("{");
            foreach (var item in root.result.responseParamList.Where(x => x.parentId == 0))
            {
                GetPddParamStereoscopic(
                    new Requestparamlist(item),
                    root.result.responseParamList.Select(x => new Requestparamlist(x)).ToArray(),
                    className,
                    ref code);
            }
            code.AppendLine("}");
            code.AppendLine("}");
            var lines = code.ToString().Split("\r\n", StringSplitOptions.None);
            return lines.ToArray();
        }
        
        static void GetPddParamStereoscopic(
            Requestparamlist item,
            Requestparamlist[] all,
            string className,
            ref StringBuilder code)
        {
            code.AppendLine("/// <summary>");
            code.AppendLine($"/// 描述：{item.paramDesc}");
            if (item.isMust != -1)
            {
                code.AppendLine($"/// 必填：{item.isMust}");
                code.AppendLine($"/// 默认值：{item.defaultValue}");
            }
            code.AppendLine($"/// 例如：{item.example}");
            code.AppendLine("/// </summary>");

            var thats = all.Where(x => x.parentId == item.id);
            if (thats.Any())
            {
                var tempName = string.Join("", item.paramName.Split('_').Select(UpperFirst));
                var tempSymbol = item.paramType.Replace("OBJECT", "");
                code.AppendLine($"public {className}_{tempName}{tempSymbol} {item.paramName} {{ get; set; }}");
                code.AppendLine("/// <summary>");
                code.AppendLine($"/// {item.paramDesc}");
                code.AppendLine("/// </summary>");
                code.AppendLine($"public partial class {className}_{tempName}");
                code.AppendLine("{");
                foreach (var that in thats)
                {
                    GetPddParamStereoscopic(that, all, className, ref code);
                }
                code.AppendLine("}");
            }
            else
            {
                code.AppendLine($"public {SwitchType(item.paramType.ToLower())} {item.paramName} {{ get; set; }}");
            }
        }

        static string UpperFirst(string that)
        {
            return that[0].ToString().ToUpper() + that.Substring(1);
        }

        static string SwitchType(string type)
        {
            switch (type)
            {
                case "boolean": return "bool";
                case "integer": return "int";
                default: return type;
            }
        }
    }
}