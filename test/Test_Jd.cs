using System.IO;
using Jd.Sdk.Apis;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace test
{
    public class JdTest
    {
        private readonly string _appKey;
        private readonly string _appSecret;
        ITestOutputHelper _output;
        public JdTest(ITestOutputHelper output)
        {
            var apps = File.ReadAllLines("D:/app.pub");
            _appKey = apps[0];
            _appSecret = apps[1];
            _output = output;
        }

        [Fact]
        public async void Test_JdUnionOpenOrderQuery()
        {
            var req = new JdUnionOpenOrderQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenGoodsJingfenQuery()
        {
            var req = new JdUnionOpenGoodsJingfenQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenGoodsLinkQuery()
        {
            var req = new JdUnionOpenGoodsLinkQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenGoodsBigfieldQuery()
        {
            var req = new JdUnionOpenGoodsBigfieldQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenGoodsQuery()
        {
            var req = new JdUnionOpenGoodsQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenCouponQuery()
        {
            var req = new JdUnionOpenCouponQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenCategoryGoodsGet()
        {
            var req = new JdUnionOpenCategoryGoodsGetRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenGoodsStupriceQuery()
        {
            var req = new JdUnionOpenGoodsStupriceQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenGoodsSeckillQuery()
        {
            var req = new JdUnionOpenGoodsSeckillQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenGoodsPromotiongoodsinfoQuery()
        {
            var req = new JdUnionOpenGoodsPromotiongoodsinfoQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenPromotionBysubunionidGet()
        {
            var req = new JdUnionOpenPromotionBysubunionidGetRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenPromotionByunionidGet()
        {
            var req = new JdUnionOpenPromotionByunionidGetRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenPromotionCommonGet()
        {
            var req = new JdUnionOpenPromotionCommonGetRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenUserPidGet()
        {
            var req = new JdUnionOpenUserPidGetRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenPositionCreate()
        {
            var req = new JdUnionOpenPositionCreateRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenPositionQuery()
        {
            var req = new JdUnionOpenPositionQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
        [Fact]
        public async void Test_JdUnionOpenCouponImportation()
        {
            var req = new JdUnionOpenCouponImportationRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
            Assert.True(res.Code == 200);
        }
    }
}
