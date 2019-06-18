namespace Tool
{
    public class JdRootobject
    {
        public int code { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public int apiId { get; set; }
        public string apiName { get; set; }
        public string apiVersion { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public int level { get; set; }
        public int needSign { get; set; }
        public int permission { get; set; }
        public int grantType { get; set; }
        public string resultDemo { get; set; }
        public string useDemo { get; set; }
        public Plist[] plists { get; set; }
        public object syslists { get; set; }
        public Plist[] slists { get; set; }
    }

    public class Plist
    {
        public object sortColumns { get; set; }
        public object groupColumns { get; set; }
        public object selectColumns { get; set; }
        public object ids { get; set; }
        public object where { get; set; }
        public object extraConditions { get; set; }
        public int nodeId { get; set; }
        public int? parentId { get; set; }
        public string dataName { get; set; }
        public string dataType { get; set; }
        public string isRequired { get; set; }
        public string sampleValue { get; set; }
        public string description { get; set; }
        public string apiId { get; set; }
        public string createdUser { get; set; }
        public string modifiedUser { get; set; }
        public long? createTime { get; set; }
        public long? updateTime { get; set; }
    }

    public class JdAllApi
    {
        public int code { get; set; }
        public string message { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public Api[] apis { get; set; }
    }

    public class Api
    {
        public int apiId { get; set; }
        public string apiName { get; set; }
        public string caption { get; set; }
    }
}