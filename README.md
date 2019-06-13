# JD_PDD.SDK.CSharpe

京东和拼多多用`c#`干净的实现开放api，使用`netstandard2.0`。  

解决`json`对应`class`的复杂嵌套关系。尽量让代码足够清晰。  

---
## Feature
无需关心jd或者pdd的调用规则，只需关心 **业务** 请求响应参数 。

针对需要补充的系统参数，在继承`BaseRequest`之后，会有未实现的异常。

生成注释完善的请求响应实体，统一使用方法名的规范命名规则
```c#
/// <summary>
/// 商品类目查询--请求参数
/// 根据商品的父类目id查询子类目id信息，通常用获取各级类目对应关系，以便将推广商品归类。业务参数parentId、grade都输入0可查询所有一级类目ID，之后再用其作为parentId查询其子类目。
/// jd.union.open.category.goods.get
/// </summary>
public partial class JdUnionOpenCategoryGoodsGetRequest : BaseRequest
{
    /// <summary>
    /// 描述：父类目id(一级父类目为0) 
    /// 必填：true
    /// 例如：1342
    /// </summary>
    public int parentId { get; set; }
    .
    .
    .
}

/// <summary>
/// 商品类目查询--响应参数
/// 根据商品的父类目id查询子类目id信息，通常用获取各级类目对应关系，以便将推广商品归类。业务参数parentId、grade都输入0可查询所有一级类目ID，之后再用其作为parentId查询其子类目。
/// jd.union.open.category.goods.get
/// </summary>
public partial class JdUnionOpenCategoryGoodsGetResponse
{
    /// <summary>
    /// 描述：类目Id
    /// 必填：true
    /// 例如：1350
    /// </summary>
    public int id { get; set; }
    .
    .
    .
}
```
支持默认和可传入的appkey等主要参数
```c#
public JdUnionOpenCategoryGoodsGetRequest() { }
public JdUnionOpenCategoryGoodsGetRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }
```

一句话调用
```c#
await new JdUnionOpenCategoryGoodsGetRequest(...).PostAsync<TResponse>();
```
