using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Flurl.Http;
using Newtonsoft.Json;

namespace Tool
{
    partial class Program
    {
        static async Task Main()
        {
            Console.WriteLine("1-京东");
            Console.WriteLine("2-拼多多");
            var type = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("获取全部接口");

            if (type.KeyChar == '1')
            {
                var allApiJson = await "https://union.jd.com/api/apiDoc/categoryList"
                           .PostStringAsync("{}").Result
                           .Content.ReadAsStringAsync();

                var allApi = JsonConvert.DeserializeObject<JdAllApi>(allApiJson);
                Directory.CreateDirectory("../Jd.Sdk/Apis");
                foreach (var item in allApi.Data[0].Apis)
                {
                    var code = await GetJdCode(item.ApiId);
                    var className = code.FirstOrDefault(x => x.Trim().StartsWith("public class ") && x.EndsWith("Request : JdBaseRequest"));
                    if (className != default)
                    {
                        var flatCode = FlatCode(code);
                        var apiName = className.Trim().Split(' ')[2].Replace("Request", "");
                        File.WriteAllLines($"../Jd.Sdk/Apis/{apiName}.cs", flatCode);
                        Console.WriteLine();
                        Console.WriteLine("[Fact]");
                        Console.WriteLine($"public async void Test_{apiName}()");
                        Console.WriteLine("{");
                        Console.WriteLine($"var req = new {apiName}Request(_appKey, _appSecret)");
                        Console.WriteLine("{");
                        Console.WriteLine("// todo 参数");
                        Console.WriteLine("};");
                        Console.WriteLine("var res = await req.InvokeAsync();");
                        Console.WriteLine("_output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));");
                        Console.WriteLine("Assert.True(res.Code == 200);");
                        Console.WriteLine("}");
                    }
                    // Console.WriteLine("SUCCESS：" + item.ApiName);
                }
            }
            else if (type.KeyChar == '2')
            {
                var allApiJson = await "https://open-api.pinduoduo.com/pop/doc/info/list/byCat"
                    .PostJsonAsync(new { id = 12 }).Result
                    .Content.ReadAsStringAsync();

                var allApi = JsonConvert.DeserializeObject<PddApiList>(allApiJson);
                Directory.CreateDirectory("../Pdd.Sdk/Apis");
                foreach (var item in allApi.Result.DocList)
                {
                    var code = await GetPddCode(item.Id);
                    var apiName = string.Join("", item.Id.Split('.').Select(UpperFirst));
                    var flatCode = FlatCode(code);
                    Console.WriteLine("[Fact]");
                    Console.WriteLine($"public async Task Test_{apiName}()");
                    Console.WriteLine("{");
                    Console.WriteLine($"var req = new {apiName}Request(_clientId, _clientSecret)");
                    Console.WriteLine("{");
                    Console.WriteLine("// todo");
                    Console.WriteLine("};");
                    Console.WriteLine("var res = await req.InvokeAsync();");
                    Console.WriteLine("_output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));");
                    Console.WriteLine("Assert.True(res != default);");
                    Console.WriteLine("}");
                    File.WriteAllLines($"../Pdd.Sdk/Apis/{apiName}.cs", flatCode);
                }

                // var code = await GetPddCode("pdd.ddk.cms.prom.url.generate");
            }
            Console.WriteLine("回车结束...");
            Console.ReadLine();
        }


        /// <summary>
        /// 扁平 代码 调整嵌套类
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        static string[] FlatCode(string[] source)
        {
            var copy = new List<string>(source.AsEnumerable());
            var nestClass = source.Where(x => GetStartContinuous(x, ' ').Length >= 8 && x.Trim().StartsWith("public class")).ToArray();
            var toEnds = new List<string[]>();
            foreach (var item in nestClass.OrderByDescending(x => GetStartContinuous(x, ' ').Length))
            {
                var start = copy
                            .ToList()
                            .IndexOf(item)
                            - 3;
                var end = copy
                            .Skip(start).ToList()
                            .IndexOf(GetStartContinuous(item, ' ') + "}")
                            + 1;
                toEnds.Add(copy.Skip(start).Take(end).ToArray());
                copy.RemoveRange(start, end);
            }
            copy.RemoveAt(copy.Count - 2);
            foreach (var item in toEnds)
            {
                var allLength = item.Select(x => GetStartContinuous(x, ' ').Length)
                                    .Where(x => x > 4)
                                    .ToArray();
                var max = allLength.Max();
                var min = allLength.Min();
                var temp = item.Select((x, i) =>
                {
                    var l = GetStartContinuous(x, ' ').Length;
                    if (l == min)
                        return "    " + x.Trim();
                    else if (l == max)
                        return "        " + x.Trim();
                    return default;
                }).Where(x => x != default);
                copy.AddRange(temp);
            }
            copy.Add("}");
            copy.Add("");
            return copy.ToArray();
        }

        /// <summary>
        /// 获取连续头部指定内容
        /// </summary>
        /// <param name="source"></param>
        /// <param name="@char"></param>
        /// <returns></returns>
        static string GetStartContinuous(string source, char @char)
        {
            var result = string.Empty;
            foreach (var c in source)
            {
                if (c != @char) break;
                result += c;
            }
            return result;
        }

        /// <summary>
        /// 首字符大写
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        static string UpperFirst(string that)
        {
            return that[0].ToString().ToUpper() + that.Substring(1);
        }

        /// <summary>
        /// 切换类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static string SwitchType(string type)
        {
            switch (type.ToLower())
            {
                case "bool":
                case "boolean": return "bool?";
                case "int":
                case "integer": return "int?";
                case "integer[]": return "int[]";
                case "long": return "long?";
                case "double": return "double?";
                case "map": return "System.Collections.Generic.Dictionary<string, object>";
                default: return type.ToLower();
            }
        }
    }
}