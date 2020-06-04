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
        private readonly string _pId;
        public Test_Pdd(ITestOutputHelper output)
        {
            try
            {
                var apps = File.ReadAllLines("D:/app.pub");
                _clientId = apps[2];
                _clientSecret = apps[3];
                _pId = apps[4];
                _output = output;
            }
            catch (System.Exception)
            {

                output.WriteLine("not find app.pub");
            }

        }

        [Fact]
        public async Task Test_PddDdkRpPromUrlGenerate()
        {
            var req = new PddDdkRpPromUrlGenerateRequest(_clientId, _clientSecret)
            {
                GenerateWeappWebview = true,
                PIdList = new[] { _pId }
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkThemeListGet()
        {
            var req = new PddDdkThemeListGetRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkGoodsZsUnitUrlGen()
        {
            var req = new PddDdkGoodsZsUnitUrlGenRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkWeappQrcodeUrlGen()
        {
            var req = new PddDdkWeappQrcodeUrlGenRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkGoodsBasicInfoGet()
        {
            var req = new PddDdkGoodsBasicInfoGetRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkOrderDetailGet()
        {
            var req = new PddDdkOrderDetailGetRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkMallGoodsListGet()
        {
            var req = new PddDdkMallGoodsListGetRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkMallUrlGen()
        {
            var req = new PddDdkMallUrlGenRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkMerchantListGet()
        {
            var req = new PddDdkMerchantListGetRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkPhraseGenerate()
        {
            var req = new PddDdkPhraseGenerateRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkOrderListIncrementGet()
        {
            var req = new PddDdkOrderListIncrementGetRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkThemeGoodsSearch()
        {
            var req = new PddDdkThemeGoodsSearchRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkTopGoodsListQuery()
        {
            var req = new PddDdkTopGoodsListQueryRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkCmsPromUrlGenerate()
        {
            var req = new PddDdkCmsPromUrlGenerateRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkGoodsPromotionUrlGenerate()
        {
            var req = new PddDdkGoodsPromotionUrlGenerateRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkGoodsUnitQuery()
        {
            var req = new PddDdkGoodsUnitQueryRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkGoodsPidGenerate()
        {
            var req = new PddDdkGoodsPidGenerateRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkCouponInfoQuery()
        {
            var req = new PddDdkCouponInfoQueryRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkGoodsSearch()
        {
            var req = new PddDdkGoodsSearchRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkLotteryUrlGen()
        {
            var req = new PddDdkLotteryUrlGenRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkOrderListRangeGet()
        {
            var req = new PddDdkOrderListRangeGetRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkGoodsRecommendGet()
        {
            var req = new PddDdkGoodsRecommendGetRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkThemePromUrlGenerate()
        {
            var req = new PddDdkThemePromUrlGenerateRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkGoodsDetail()
        {
            var req = new PddDdkGoodsDetailRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkResourceUrlGen()
        {
            var req = new PddDdkResourceUrlGenRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
        }
        [Fact]
        public async Task Test_PddDdkGoodsPidQuery()
        {
            var req = new PddDdkGoodsPidQueryRequest(_clientId, _clientSecret)
            {
                // todo
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res != default);
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
