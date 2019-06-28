using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using Common;
using System.Collections.Generic;

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
            var code = new StringBuilder();
            code.AppendLine("using System.Threading.Tasks;");
            code.AppendLine("using Newtonsoft.Json;");
            code.AppendLine();
            code.AppendLine("namespace Pdd.Sdk.Apis");
            code.AppendLine("{");
            code.AppendLine("    /// <summary>");
            code.AppendLine($"    /// {root.result.apiName}--请求参数");
            code.AppendLine($"    /// {root.result.usageScenarios}");
            code.AppendLine($"    /// {id}");
            code.AppendLine($"    /// https://open.pinduoduo.com/#/apidocument/port?id={id}");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public class {className}Request : PddBaseRequest");
            code.AppendLine("    {");
            code.AppendLine($"        protected override string Type => \"{id}\";");
            code.AppendLine();
            code.AppendLine($"        public {className}Request() {{ }}");
            code.AppendLine();
            code.AppendLine($"        public {className}Request(string clientId, string clientSecret) : base(clientId, clientSecret) {{ }}");
            code.AppendLine();
            code.AppendLine($"        public async Task<{className}Response> InvokeAsync()");
            code.AppendLine($"            => await PostAsync<{className}Response>();");
            foreach (var item in root.result.requestParamList.Where(x => x.parentId == 0))
            {
                GetPddParamStereoscopic(
                    item,
                    root.result.requestParamList,
                    className,
                    "        ",
                    true,
                    ref code);
            }
            code.AppendLine("    }");
            code.AppendLine();
            code.AppendLine();
            code.AppendLine("    /// <summary>");
            code.AppendLine($"    /// {root.result.apiName}--响应参数");
            code.AppendLine($"    /// {root.result.usageScenarios}");
            code.AppendLine("    /// </summary>");
            code.AppendLine($"    public class {className}Response : PddBaseResponse");
            code.AppendLine("    {");
            IEnumerable<PddResponseparamlist> responseList;
            if (root.result.responseParamList.Any(x => x.paramName == "total"))
            {
                responseList = root.result.responseParamList.Where(x => x.parentId == 1);
            }
            else
            {
                responseList = root.result.responseParamList.Where(x => x.parentId == 0);
            }
            foreach (var item in responseList)
            {
                GetPddParamStereoscopic(
                    new PddRequestparamlist(item),
                    root.result.responseParamList.Select(x => new PddRequestparamlist(x)).ToArray(),
                    className,
                    "        ",
                    false,
                    ref code);
            }
            code.AppendLine("    }");
            code.AppendLine("}");
            var lines = code.ToString().Split("\r\n");
            return lines.ToArray();
        }

        static void GetPddParamStereoscopic(
            PddRequestparamlist item,
            PddRequestparamlist[] all,
            string className,
            string spacing,
            bool isRequest,
            ref StringBuilder code)
        {
            code.AppendLine($"{spacing}/// <summary>");
            if (item.isMust != -1 && isRequest)
            {
                code.AppendLine($"{spacing}/// {(item.isMust == 0 ? "不必填" : "必填")}");
            }
            code.AppendLine($"{spacing}/// {item.paramDesc}");
            if (isRequest && !string.IsNullOrWhiteSpace(item.defaultValue))
            {
                code.AppendLine($"{spacing}/// 默认值：{item.defaultValue}");
            }
            if (!string.IsNullOrWhiteSpace(item.example))
            {
                code.AppendLine($"{spacing}/// 例如：{item.example}");
            }
            code.AppendLine($"{spacing}/// </summary>");

            var currentNodes = all.Where(x => x.parentId == item.id).ToArray();

            if (currentNodes.Any())
            {
                var tempName = string.Join("", item.paramName.Split('_').Select(UpperFirst));
                var tempSymbol = item.paramType.Replace("OBJECT", "");
                if (!isRequest)
                {
                    code.AppendLine($"{spacing}[JsonProperty(\"{item.paramName}\")]");
                }
                code.AppendLine($"{spacing}public {className}_{tempName}{tempSymbol} {ConvertExtend.UnderlineToUpper(item.paramName)} {{ get; set; }}");
                code.AppendLine($"{spacing}/// <summary>");
                code.AppendLine($"{spacing}/// {item.paramDesc}");
                code.AppendLine($"{spacing}/// </summary>");
                code.AppendLine($"{spacing}public class {className}_{tempName}");
                code.AppendLine($"{spacing}{{");
                foreach (var that in currentNodes)
                {
                    GetPddParamStereoscopic(
                        that,
                        all,
                        className,
                        spacing + "    ",
                        isRequest,
                        ref code);
                }
                code.AppendLine($"{spacing}}}");
            }
            else
            {
                if (!isRequest)
                {
                    code.AppendLine($"{spacing}[JsonProperty(\"{item.paramName}\")]");
                }
                code.AppendLine($"{spacing}public {SwitchType(item.paramType)} {ConvertExtend.UnderlineToUpper(item.paramName)} {{ get; set; }}");
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

    public partial class PddApiList
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("errorCode")]
        public long ErrorCode { get; set; }

        [JsonProperty("errorMsg")]
        public object ErrorMsg { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("catName")]
        public string CatName { get; set; }

        [JsonProperty("docList")]
        public DocList[] DocList { get; set; }
    }

    public partial class DocList
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("scopeName")]
        public string ScopeName { get; set; }

        [JsonProperty("scopeNameId")]
        public long ScopeNameId { get; set; }

        [JsonProperty("apiName")]
        public string ApiName { get; set; }

        [JsonProperty("usageScenarios")]
        public string UsageScenarios { get; set; }

        [JsonProperty("createdAt")]
        public long CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonProperty("scopeTips")]
        public string ScopeTips { get; set; }
    }

    public partial class PddApiList
    {
        public static PddApiList FromJson(string json) => JsonConvert.DeserializeObject<PddApiList>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PddApiList self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}