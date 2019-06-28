using System.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;
using Pdd.Sdk.Apis;
using Xunit;
using Xunit.Abstractions;

namespace test
{
    public class Test_Pdd
    {
        private readonly ITestOutputHelper _output;
        private readonly string _clientId;
        private readonly string _clientSecret;
        public Test_Pdd(ITestOutputHelper output)
        {
            var apps = File.ReadAllLines("D:/app.pub");
            _clientId = apps[2];
            _clientSecret = apps[3];
            _output = output;
        }

        [Fact]
        public async Task Test_PddDdkMallGoodsListGet()
        {
            var req = new PddDdkTopGoodsListQueryRequest(_clientId, _clientSecret)
            {
                Offset = 1,
                Limit = 10
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.List.Any());
        }

        [Fact]
        public void Test_UpperToUnderline()
        {
            var str = "ABcDeF";
            var r = ConvertExtend.UpperToUnderline(str);
            _output.WriteLine(r);
            Assert.True(r == "a_bc_de_f");
        }

        [Fact]
        public void Test_UnderlineToUpper()
        {
            var str = "a_bc_de_f";
            var r = ConvertExtend.UnderlineToUpper(str);
            _output.WriteLine(r);
            Assert.True(r == "ABcDeF");
        }
    }
}
