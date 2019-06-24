using System.Threading.Tasks;

namespace Jd.Sdk.Apis
{
    /// <summary>
    /// 订单查询接口--请求参数
    /// 查询推广订单及佣金信息，会随着订单状态变化更新数据，支持按下单时间、完成时间或状态更新时间查询，通常可按更新时间每分钟调用一次来获取订单的最新状态。支持subunionid、推广位、PID、工具商角色订单查询。功能相当于原宙斯接口的订单查询、 查询引入订单、查询业绩订单、工具商订单查询、工具商引入数据查询接口、工具商业绩数据查询接口、PID订单查询、PID引入订单查询、PID业绩订单查询。
    /// jd.union.open.order.query
    /// https://union.jd.com/openplatform/api/650
    /// </summary>
    public class JdUnionOpenOrderQueryRequest : JdBaseRequest
    {
        public JdUnionOpenOrderQueryRequest() { }

        public JdUnionOpenOrderQueryRequest(string appKey, string appSecret, string accessToken = null) : base(appKey, appSecret, accessToken) { }

        protected override string Method => "jd.union.open.order.query";

        protected override string ParamName => "orderReq";

        public async Task<JdBasePageResponse<JdUnionOpenOrderQueryResponse[]>> InvokeAsync()
            => await PostAsync<JdBasePageResponse<JdUnionOpenOrderQueryResponse[]>>();

        /// <summary>
        /// 描述：页码，返回第几页结果
        /// 例如：1
        /// 必填
        /// </summary>
        public int PageNo { get; set; }
        /// <summary>
        /// 描述：每页包含条数，上限为500
        /// 例如：20
        /// 必填
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 描述：订单时间查询类型(1：下单时间，2：完成时间，3：更新时间)
        /// 例如：1
        /// 必填
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 描述：查询时间，建议使用分钟级查询，格式：yyyyMMddHH、yyyyMMddHHmm或yyyyMMddHHmmss，如201811031212 的查询范围从12:12:00--12:12:59
        /// 例如：201811031212
        /// 必填
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 描述：子站长ID（需要联系运营开通PID账户权限才能拿到数据），childUnionId和key不能同时传入
        /// 例如：61800001
        /// 不必填
        /// </summary>
        public long ChildUnionId { get; set; }
        /// <summary>
        /// 描述：其他推客的授权key，查询工具商订单需要填写此项，childUnionid和key不能同时传入
        /// 例如：
        /// 不必填
        /// </summary>
        public string Key { get; set; }
    }



    /// <summary>
    /// 订单查询接口--响应参数
    /// 查询推广订单及佣金信息，会随着订单状态变化更新数据，支持按下单时间、完成时间或状态更新时间查询，通常可按更新时间每分钟调用一次来获取订单的最新状态。支持subunionid、推广位、PID、工具商角色订单查询。功能相当于原宙斯接口的订单查询、 查询引入订单、查询业绩订单、工具商订单查询、工具商引入数据查询接口、工具商业绩数据查询接口、PID订单查询、PID引入订单查询、PID业绩订单查询。
    /// jd.union.open.order.query
    /// </summary>
    public class JdUnionOpenOrderQueryResponse
    {
        /// <summary>
        /// 描述：订单完成时间(时间戳，毫秒)
        /// 例如：1529271683000
        /// </summary>
        public long FinishTime { get; set; }
        /// <summary>
        /// 描述：下单设备(1:PC,2:无线)
        /// 例如：1
        /// </summary>
        public int OrderEmt { get; set; }
        /// <summary>
        /// 描述：订单ID
        /// 例如：61861861866
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// 描述：下单时间(时间戳，毫秒)
        /// 例如：1529271683000
        /// </summary>
        public long OrderTime { get; set; }
        /// <summary>
        /// 描述：父单的订单ID，仅当发生订单拆分时返回， 0：未拆分，有值则表示此订单为子订单
        /// 例如：66661861866
        /// </summary>
        public long ParentId { get; set; }
        /// <summary>
        /// 描述：订单维度预估结算时间（格式：yyyyMMdd），0：未结算，订单的预估结算时间仅供参考。账号未通过资质审核或订单发生售后，会影响订单实际结算时间。
        /// 例如：20180618
        /// </summary>
        public string PayMonth { get; set; }
        /// <summary>
        /// 描述：下单用户是否为PLUS会员 0：否，1：是
        /// 例如：1
        /// </summary>
        public int Plus { get; set; }
        /// <summary>
        /// 描述：商家ID
        /// 例如：1000066618
        /// </summary>
        public long PopId { get; set; }
        /// <summary>
        /// 描述：订单包含的商品信息列表
        /// 例如：
        /// </summary>
        public JdUnionOpenOrderQuery_skuinfo[] skuList { get; set; }
        /// <summary>
        /// 订单包含的商品信息列表
        /// </summary>
        public class JdUnionOpenOrderQuery_skuinfo
        {
            /// <summary>
            /// 描述：实际计算佣金的金额。订单完成后，会将误扣除的运费券金额更正。如订单完成后发生退款，此金额会更新。
            /// 例如：6.88
            /// </summary>
            public double ActualCosPrice { get; set; }
            /// <summary>
            /// 描述：推客获得的实际佣金（实际计佣金额*佣金比例*最终比例）。如订单完成后发生退款，此金额会更新。
            /// 例如：6.18
            /// </summary>
            public double ActualFee { get; set; }
            /// <summary>
            /// 描述：佣金比例
            /// 例如：2.50
            /// </summary>
            public double CommissionRate { get; set; }
            /// <summary>
            /// 描述：预估计佣金额，即用户下单的金额(已扣除优惠券、白条、支付优惠、进口税，未扣除红包和京豆)，有时会误扣除运费券金额，完成结算时会在实际计佣金额中更正。如订单完成前发生退款，此金额不会更新。
            /// 例如：618.18
            /// </summary>
            public double EstimateCosPrice { get; set; }
            /// <summary>
            /// 描述：推客的预估佣金（预估计佣金额*佣金比例*最终比例），如订单完成前发生退款，此金额不会更新。
            /// 例如：6.18
            /// </summary>
            public double EstimateFee { get; set; }
            /// <summary>
            /// 描述：最终比例（分成比例+补贴比例）
            /// 例如：100.00
            /// </summary>
            public double FinalRate { get; set; }
            /// <summary>
            /// 描述：一级类目ID
            /// 例如：737
            /// </summary>
            public long Cid1 { get; set; }
            /// <summary>
            /// 描述：商品售后中数量
            /// 例如：1
            /// </summary>
            public long FrozenSkuNum { get; set; }
            /// <summary>
            /// 描述：联盟子站长身份标识，格式：子站长ID_子站长网站ID_子站长推广位ID
            /// 例如：618_618_6018
            /// </summary>
            public string Pid { get; set; }
            /// <summary>
            /// 描述：推广位ID,0代表无推广位
            /// 例如：66
            /// </summary>
            public long PositionId { get; set; }
            /// <summary>
            /// 描述：商品单价
            /// 例如：61.8
            /// </summary>
            public double Price { get; set; }
            /// <summary>
            /// 描述：二级类目ID
            /// 例如：738
            /// </summary>
            public long Cid2 { get; set; }
            /// <summary>
            /// 描述：网站ID，0：无网站
            /// 例如：6000618
            /// </summary>
            public long SiteId { get; set; }
            /// <summary>
            /// 描述：商品ID
            /// 例如：5487565
            /// </summary>
            public long SkuId { get; set; }
            /// <summary>
            /// 描述：商品名称
            /// 例如：空气净化器 除雾霾 除甲醛 空气质量屏幕显示 三层净化
            /// </summary>
            public string SkuName { get; set; }
            /// <summary>
            /// 描述：商品数量
            /// 例如：2
            /// </summary>
            public long SkuNum { get; set; }
            /// <summary>
            /// 描述：商品已退货数量
            /// 例如：1
            /// </summary>
            public long SkuReturnNum { get; set; }
            /// <summary>
            /// 描述：分成比例
            /// 例如：90
            /// </summary>
            public double SubSideRate { get; set; }
            /// <summary>
            /// 描述：补贴比例
            /// 例如：10
            /// </summary>
            public double SubsidyRate { get; set; }
            /// <summary>
            /// 描述：三级类目ID
            /// 例如：749
            /// </summary>
            public long Cid3 { get; set; }
            /// <summary>
            /// 描述：PID所属母账号平台名称（原第三方服务商来源）
            /// 例如：**平台
            /// </summary>
            public string UnionAlias { get; set; }
            /// <summary>
            /// 描述：联盟标签数据（整型的二进制字符串(32位)，目前只返回8位：00000001。数据从右向左进行，每一位为1表示符合联盟的标签特征，第1位：京喜红包，第2位：组合推广订单，第3位：拼购订单，第5位：有效首次购订单（00011XXX表示有效首购，最终奖励活动结算金额会结合订单状态判断，以联盟后台对应活动效果数据报表https://union.jd.com/active为准）。例如：00000001:京喜红包订单，00000010:组合推广订单，00000100:拼购订单，00011000:有效首购，00000111：京喜红包+组合推广+拼购等）
            /// 例如：00000100
            /// </summary>
            public string UnionTag { get; set; }
            /// <summary>
            /// 描述：渠道组 1：1号店，其他：京东
            /// 例如：1
            /// </summary>
            public int UnionTrafficGroup { get; set; }
            /// <summary>
            /// 描述：sku维度的有效码（-1：未知,2.无效-拆单,3.无效-取消,4.无效-京东帮帮主订单,5.无效-账号异常,6.无效-赠品类目不返佣,7.无效-校园订单,8.无效-企业订单,9.无效-团购订单,10.无效-开增值税专用发票订单,11.无效-乡村推广员下单,12.无效-自己推广自己下单,13.无效-违规订单,14.无效-来源与备案网址不符,15.待付款,16.已付款,17.已完成,18.已结算（5.9号不再支持结算状态回写展示））注：自2018/7/13起，自己推广自己下单已经允许返佣，故12无效码仅针对历史数据有效
            /// 例如：18
            /// </summary>
            public int ValidCode { get; set; }
            /// <summary>
            /// 描述：子联盟ID(需要联系运营开放白名单才能拿到数据)
            /// 例如：
            /// </summary>
            public string SubUnionId { get; set; }
            /// <summary>
            /// 描述：2：同店；3：跨店
            /// 例如：3
            /// </summary>
            public int TraceType { get; set; }
            /// <summary>
            /// 描述：订单行维度预估结算时间（格式：yyyyMMdd） ，0：未结算。订单的预估结算时间仅供参考。账号未通过资质审核或订单发生售后，会影响订单实际结算时间。
            /// 例如：20180618
            /// </summary>
            public int PayMonth { get; set; }
            /// <summary>
            /// 描述：商家ID，订单行维度
            /// 例如：30871
            /// </summary>
            public long PopId { get; set; }
            /// <summary>
            /// 描述：推客生成推广链接时传入的扩展字段（需要联系运营开放白名单才能拿到数据）。&lt;订单行维度&gt;
            /// 例如：1_1255413_0_XXXX
            /// </summary>
            public string Ext1 { get; set; }
        }
        /// <summary>
        /// 描述：推客的联盟ID
        /// 例如：2018618618
        /// </summary>
        public long UnionId { get; set; }
        /// <summary>
        /// 描述：推客生成推广链接时传入的扩展字段，订单维度（需要联系运营开放白名单才能拿到数据）
        /// 例如：100_618_大促
        /// </summary>
        public string Ext1 { get; set; }
        /// <summary>
        /// 描述：订单维度的有效码（-1：未知,2.无效-拆单,3.无效-取消,4.无效-京东帮帮主订单,5.无效-账号异常,6.无效-赠品类目不返佣,7.无效-校园订单,8.无效-企业订单,9.无效-团购订单,10.无效-开增值税专用发票订单,11.无效-乡村推广员下单,12.无效-自己推广自己下单,13.无效-违规订单,14.无效-来源与备案网址不符,15.待付款,16.已付款,17.已完成,18.已结算（5.9号不再支持结算状态回写展示））注：自2018/7/13起，自己推广自己下单已经允许返佣，故12无效码仅针对历史数据有效
        /// 例如：18
        /// </summary>
        public int ValidCode { get; set; }
    }
}

