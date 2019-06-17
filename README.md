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

## 使用接口生成工具
- 进入`src/Tool`目录，运行`dotnet run`
- 选择jd或者pdd
- jd需要输入接口id，比如：`https://union.jd.com/openplatform/api/650` 这个接口的id就是650。  
pdd需要传入接口标识，比如：`https://open.pinduoduo.com/#/apidocument/port?id=pdd.ddk.top.goods.list.query`这个接口的标识就是pdd.ddk.top.goods.list.query。
- 生成代码在当前目录的`Codes`文件夹下，以输入的标识命名，重复的命名会覆盖之前的文件。
- 代码不能直接使用，命名空间需要修改，而且有些数据类型使用了大写等问题。理论上只要修改掉报错代码，接口就能调用成功。

## 正确的使用姿势
目前不提供dll直接调用，希望的使用方法是copy基类代码到自己的项目，针对需要使用的接口使用Tool去生成请求响应实体。就这样~

## 缺点
- 采用代码生成无法识别接口的相同部分，也就意味这生成的代码几乎无代码复用。会产生一定程度的重复代码。
- 嵌套的实体会生成嵌套类代码，*一般出现在相应实体中*，会产生贼长的命名。
```c#
public class JdUnionOpenOrderQueryResponse
{
    ...
    public class JdUnionOpenOrderQuery_SkuInfo
    {

    }
    ...
}
```
---
# 更新日志
- 2019年6月17日 增加jd demo