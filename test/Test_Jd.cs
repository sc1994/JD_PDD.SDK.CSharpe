using System.IO;
using Jd.Sdk;
using Jd.Sdk.Apis;
using Xunit;

namespace test
{
    public class JdTest
    {
        private readonly string _appKey;
        private readonly string _appSecret;

        public JdTest()
        {
            var apps = File.ReadAllLines("D:/app.pub");
            _appKey = apps[0];
            _appSecret = apps[1];
        }

        [Fact]
        public async void Test_JdUnionOpenCategoryGoodsGet()
        {
            var req = new JdUnionOpenCategoryGoodsGetRequest(_appKey, _appSecret);
            var res = await req.PostAsync<JdBaseResponse<JdUnionOpenCategoryGoodsGetResponse[]>>();
            Assert.True(res.Data.Length > 0);
        }
    }
}
