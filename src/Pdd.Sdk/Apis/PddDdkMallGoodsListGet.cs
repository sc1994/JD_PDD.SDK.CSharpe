namespace Pdd.Sdk.Apis
{
    /// <summary>
    /// 查询店铺商品
    /// pdd.ddk.mall.goods.list.get
    /// https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.top.goods.list.query
    /// </summary>
    public class PddDdkMallGoodsListGetRequest : PddBaseRequest
    {
        protected override string Type { get; } = "pdd.ddk.mall.goods.list.get";
    }
}