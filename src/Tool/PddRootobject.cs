namespace Tool
{
    public class JdPddRootobject
    {
        public bool success { get; set; }
        public int errorCode { get; set; }
        public object errorMsg { get; set; }
        public JdResult result { get; set; }
    }

    public class JdResult
    {
        public int id { get; set; }
        public int catId { get; set; }
        public string apiName { get; set; }
        public string scopeName { get; set; }
        public string usageScenarios { get; set; }
        public int needOauth { get; set; }
        public int chargeType { get; set; }
        public int platform { get; set; }
        public object scenesId { get; set; }
        public object scenesName { get; set; }
        public object roleId { get; set; }
        public object roleName { get; set; }
        public object requestCodeExample { get; set; }
        public string responseCodeExample { get; set; }
        public string feeType { get; set; }
        public JdRequestparamlist[] requestParamList { get; set; }
        public JdResponseparamlist[] responseParamList { get; set; }
        public JdErrorparamlist[] errorParamList { get; set; }
        public JdLimiter[] limiters { get; set; }
        public JdPermissionspkg[] permissionsPkgs { get; set; }
        public JdSdkdemo[] sdkDemos { get; set; }
    }

    public class JdRequestparamlist
    {
        public JdRequestparamlist() { }

        public JdRequestparamlist(JdResponseparamlist item)
        {
            id = item.id;
            parentId = item.parentId;
            childrenNum = item.childrenNum;
            paramName = item.paramName;
            paramType = item.paramType;
            example = item.example;
            paramDesc = item.paramDesc;
            isMust = -1;
        }
        public int id { get; set; }
        public int parentId { get; set; }
        public int childrenNum { get; set; }
        public string paramName { get; set; }
        public string paramType { get; set; }
        public int isMust { get; set; }
        public string defaultValue { get; set; }
        public string example { get; set; }
        public string paramDesc { get; set; }
    }

    public class JdResponseparamlist
    {
        public int id { get; set; }
        public int parentId { get; set; }
        public int childrenNum { get; set; }
        public string paramName { get; set; }
        public string paramType { get; set; }
        public object sourcePath { get; set; }
        public string example { get; set; }
        public string paramDesc { get; set; }
    }

    public class JdErrorparamlist
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public string solution { get; set; }
        public string outerErrorCode { get; set; }
    }

    public class JdLimiter
    {
        public int limiterLevel { get; set; }
        public int timeRange { get; set; }
        public int times { get; set; }
    }

    public class JdPermissionspkg
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public JdApptypelist[] appTypeList { get; set; }
    }

    public class JdApptypelist
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class JdSdkdemo
    {
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }
}