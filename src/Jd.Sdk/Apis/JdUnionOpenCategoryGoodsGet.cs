namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 商品类目查询--请求参数
    /// 根据商品的父类目id查询子类目id信息，通常用获取各级类目对应关系，以便将推广商品归类。业务参数parentId、grade都输入0可查询所有一级类目ID，之后再用其作为parentId查询其子类目。
    /// jd.union.open.category.goods.get
    /// </summary>
    public class JdUnionOpenCategoryGoodsGetRequest : JdBaseRequest
    {
        public JdUnionOpenCategoryGoodsGetRequest() { }

        public JdUnionOpenCategoryGoodsGetRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.category.goods.get";

        protected override string ParamName => "req";

        /// <summary>
        /// 描述：父类目id(一级父类目为0) 
        /// 必填：true
        /// 例如：1342
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 描述：类目级别(类目级别 0，1，2 代表一、二、三级类目)
        /// 必填：true
        /// 例如：2
        /// </summary>
        public int grade { get; set; }
    }



    /// <summary>
    /// 商品类目查询--响应参数
    /// 根据商品的父类目id查询子类目id信息，通常用获取各级类目对应关系，以便将推广商品归类。业务参数parentId、grade都输入0可查询所有一级类目ID，之后再用其作为parentId查询其子类目。
    /// jd.union.open.category.goods.get
    /// </summary>
    public class JdUnionOpenCategoryGoodsGetResponse
    {
        /// <summary>
        /// 描述：类目Id
        /// 必填：true
        /// 例如：1350
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 描述：类目名称
        /// 必填：true
        /// 例如：针织衫
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 描述：类目级别(类目级别 0，1，2 代表一、二、三级类目)
        /// 必填：true
        /// 例如：2
        /// </summary>
        public int grade { get; set; }
        /// <summary>
        /// 描述：父类目Id
        /// 必填：true
        /// 例如：1342
        /// </summary>
        public int parentId { get; set; }
    }
}

