using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;

namespace Tool
{
    partial class Program
    {
        static async Task<string[]> GetPddCode(string id)
        {
            var sender = await "https://open-api.pinduoduo.com/pop/doc/info/get".PostJsonAsync(new { id });

            var @string = await sender.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<PddRootobject>(@string);

            var className = root.result.scopeName;
            className = string.Join("", className.Split('.').Select(UpperFirst));
            Console.WriteLine(className);
            var code = new StringBuilder();
            code.AppendLine("namespace todo");
            code.AppendLine("{");
            code.AppendLine("/// <summary>");
            code.AppendLine($"/// {root.result.apiName}--{root.result.usageScenarios}--请求参数");
            code.AppendLine($"/// {root.result.scopeName}");
            code.AppendLine("/// </summary>");
            code.AppendLine($"public class {className}Request : BaseRequest");
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
            code.AppendLine($"public class {className}Response");
            code.AppendLine("{");
            foreach (var item in root.result.responseParamList.Where(x => x.parentId == 0))
            {
                GetPddParamStereoscopic(
                    new PddRequestparamlist(item),
                    root.result.responseParamList.Select(x => new PddRequestparamlist(x)).ToArray(),
                    className,
                    ref code);
            }
            code.AppendLine("}");
            code.AppendLine("}");
            var lines = code.ToString().Split("\r\n");
            return lines.ToArray();
        }

        static void GetPddParamStereoscopic(
            PddRequestparamlist item,
            PddRequestparamlist[] all,
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

            var currentNodes = all.Where(x => x.parentId == item.id).ToArray();

            if (currentNodes.Any())
            {
                var tempName = string.Join("", item.paramName.Split('_').Select(UpperFirst));
                var tempSymbol = item.paramType.Replace("OBJECT", "");
                code.AppendLine($"public {className}_{tempName}{tempSymbol} {item.paramName} {{ get; set; }}");
                code.AppendLine("/// <summary>");
                code.AppendLine($"/// {item.paramDesc}");
                code.AppendLine("/// </summary>");
                code.AppendLine($"public class {className}_{tempName}");
                code.AppendLine("{");
                foreach (var that in currentNodes)
                {
                    GetPddParamStereoscopic(that, all, className, ref code);
                }
                code.AppendLine("}");
            }
            else
            {
                code.AppendLine($"public {SwitchType(item.paramType)} {item.paramName} {{ get; set; }}");
            }
        }
    }


    public class PddRootobject
    {
        public bool success { get; set; }
        public int errorCode { get; set; }
        public object errorMsg { get; set; }
        public PddResult result { get; set; }
    }

    public class PddResult
    {
        public int id { get; set; }
        public int catId { get; set; }
        public string apiName { get; set; }
        public string scopeName { get; set; }
        public string usageScenarios { get; set; }
        public int needOauth { get; set; }
        public int chargeType { get; set; }
        public int platform { get; set; }
        public object scenesId { get; set; }
        public object scenesName { get; set; }
        public object roleId { get; set; }
        public object roleName { get; set; }
        public object requestCodeExample { get; set; }
        public string responseCodeExample { get; set; }
        public string feeType { get; set; }
        public PddRequestparamlist[] requestParamList { get; set; }
        public PddResponseparamlist[] responseParamList { get; set; }
        public PddErrorparamlist[] errorParamList { get; set; }
        public PddJdLimiter[] limiters { get; set; }
        public PddJdPermissionspkg[] permissionsPkgs { get; set; }
        public PddJdSdkdemo[] sdkDemos { get; set; }
    }

    public class PddRequestparamlist
    {
        public PddRequestparamlist() { }

        public PddRequestparamlist(PddResponseparamlist item)
        {
            id = item.id;
            parentId = item.parentId;
            childrenNum = item.childrenNum;
            paramName = item.paramName;
            paramType = item.paramType;
            example = item.example;
            paramDesc = item.paramDesc;
            isMust = -1;
        }
        public int id { get; set; }
        public int parentId { get; set; }
        public int childrenNum { get; set; }
        public string paramName { get; set; }
        public string paramType { get; set; }
        public int isMust { get; set; }
        public string defaultValue { get; set; }
        public string example { get; set; }
        public string paramDesc { get; set; }
    }

    public class PddResponseparamlist
    {
        public int id { get; set; }
        public int parentId { get; set; }
        public int childrenNum { get; set; }
        public string paramName { get; set; }
        public string paramType { get; set; }
        public object sourcePath { get; set; }
        public string example { get; set; }
        public string paramDesc { get; set; }
    }

    public class PddErrorparamlist
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public string solution { get; set; }
        public string outerErrorCode { get; set; }
    }

    public class PddJdLimiter
    {
        public int limiterLevel { get; set; }
        public int timeRange { get; set; }
        public int times { get; set; }
    }

    public class PddJdPermissionspkg
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public PddJdApptypelist[] appTypeList { get; set; }
    }

    public class PddJdApptypelist
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class PddJdSdkdemo
    {
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }
}