using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        private readonly ITestOutputHelper _output;
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
                Type = 1,
                Time = DateTime.Now.ToString("yyyyMMddHHmm"),
                PageSize = 10,
                PageNo = 1
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200);
        }

        [Fact]
        public async void Test_JdUnionOpenGoodsJingfenQuery()
        {
            var req = new JdUnionOpenGoodsJingfenQueryRequest(_appKey, _appSecret)
            {
                PageSize = 10,
                EliteId = 1,
                PageIndex = 1,
                Sort = "asc",
                SortName = "price"
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200);
        }

        [Fact]
        public async void Test_JdUnionOpenGoodsLinkQuery()
        {
            var req = new JdUnionOpenGoodsLinkQueryRequest(_appKey, _appSecret)
            {
                Url = "https://item.jd.com/product/12473772.html",
                SubUnionId = "1_2_3_4"
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200 || res.Code == 403);
        }

        [Fact]
        public async void Test_JdUnionOpenGoodsBigfieldQuery()
        {
            var req = new JdUnionOpenGoodsBigfieldQueryRequest(_appKey, _appSecret)
            {
                SkuIds = new[] { 12473772L }
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200 || res.Code == 403);
        }

        [Fact]
        public async void Test_JdUnionOpenGoodsQuery()
        {
            var req = new JdUnionOpenGoodsQueryRequest(_appKey, _appSecret);
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200);
        }

        [Fact]
        public async void Test_JdUnionOpenCouponQuery()
        {
            var first = await GetFirstGoods();
            if (first == default) return;

            var req = new JdUnionOpenCouponQueryRequest(_appKey, _appSecret)
            {
                CouponUrls = first.CouponInfo.CouponList.Select(x => x.Link).ToArray()
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200);
        }

        [Fact]
        public async void Test_JdUnionOpenCategoryGoodsGet()
        {
            var req = new JdUnionOpenCategoryGoodsGetRequest(_appKey, _appSecret)
            {
                Grade = 0,
                ParentId = 1342
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200);
        }

        [Fact]
        public async void Test_JdUnionOpenGoodsStupriceQuery()
        {
            var req = new JdUnionOpenGoodsStupriceQueryRequest(_appKey, _appSecret);
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200 || res.Code == 403);
        }

        [Fact]
        public async void Test_JdUnionOpenGoodsSeckillQuery()
        {
            var req = new JdUnionOpenGoodsSeckillQueryRequest(_appKey, _appSecret);
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200 || res.Code == 403);
        }

        [Fact]
        public async void Test_JdUnionOpenGoodsPromotiongoodsinfoQuery()
        {
            var req = new JdUnionOpenGoodsPromotiongoodsinfoQueryRequest(_appKey, _appSecret)
            {
                SkuIds = "5225346,7275691"
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200);
        }

        [Fact]
        public async void Test_JdUnionOpenPromotionBysubunionidGet()
        {
            var req = new JdUnionOpenPromotionBysubunionidGetRequest(_appKey, _appSecret)
            {
                MaterialId = "https://wqitem.jd.com/item/view?sku=23484023378"
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200);
        }

        [Fact]
        public async void Test_JdUnionOpenPromotionByunionidGet()
        {
            var req = new JdUnionOpenPromotionByunionidGetRequest(_appKey, _appSecret)
            {
                MaterialId = "https://wqitem.jd.com/item/view?sku=23484023378",
                UnionId = 10000618
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200 || res.Code == 403);
        }

        [Fact]
        public async void Test_JdUnionOpenPromotionCommonGet()
        {
            var req = new JdUnionOpenPromotionCommonGetRequest(_appKey, _appSecret)
            {
                MaterialId = "https://wqitem.jd.com/item/view?sku=23484023378",
                SiteId = "435676"
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200 || res.Code == 2001701);
        }

        [Fact]
        public async void Test_JdUnionOpenUserPidGet()
        {
            var req = new JdUnionOpenUserPidGetRequest(_appKey, _appSecret)
            {
                UnionId = 10000618,
                ChildUnionId = 61800001,
                MediaName = "huhu",
                PromotionType = 1
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            //Assert.True(res.Code == 200 || res.Code == 1040); 接口未上线无法断言
        }

        [Fact]
        public async void Test_JdUnionOpenPositionCreate()
        {
            var req = new JdUnionOpenPositionCreateRequest(_appKey, _appSecret)
            {
                UnionId = 10000618,
                Type = 1,
                Key = "1",
                SpaceNameList = new[] { "夏日优选" },
                UnionType = 1
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200 || res.Code == 403);
        }

        [Fact]
        public async void Test_JdUnionOpenPositionQuery()
        {
            var req = new JdUnionOpenPositionQueryRequest(_appKey, _appSecret)
            {
                // todo 参数
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200 || res.Code == 403);
        }

        [Fact]
        public async void Test_JdUnionOpenCouponImportation()
        {
            var first = await GetFirstGoods();
            if (first == default) return;
            var link = first.CouponInfo.CouponList.Select(x => x.Link).FirstOrDefault();
            if (link == null) return;

            var req = new JdUnionOpenCouponImportationRequest(_appKey, _appSecret)
            {
                CouponLink = link,
                SkuId = Convert.ToInt64(HttpUtility.ParseQueryString(link.Split('?')[1])["roleId"])
            };
            var res = await req.InvokeAsync();
            _output.WriteLine(JsonConvert.SerializeObject(req.DebugInfo, Formatting.Indented));
            Assert.True(res.Code == 200 || res.Code == 403);
        }

        private async Task<JdUnionOpenGoodsQueryResponse> GetFirstGoods()
        {
            var goods = await new JdUnionOpenGoodsQueryRequest(_appKey, _appSecret).InvokeAsync();
            var first = goods.Data.FirstOrDefault(x => x.CouponInfo != null && x.CouponInfo.CouponList.Any());
            return first;
        }
    }
}
