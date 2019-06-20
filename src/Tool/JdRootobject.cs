namespace Tool
{
    public class JdRootObject
    {
        public JdData Data { get; set; }
    }

    public class JdData
    {
        public string ApiName { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public JdPlist[] PLists { get; set; }
        public JdPlist[] SLists { get; set; }
    }

    public class JdPlist
    {
        public int NodeId { get; set; }
        public int? ParentId { get; set; }
        public string DataName { get; set; }
        public string DataType { get; set; }
        public string IsRequired { get; set; }
        public string SampleValue { get; set; }
        public string Description { get; set; }
    }

    public class JdAllApi
    {
        public JdDatum[] Data { get; set; }
    }

    public class JdDatum
    {
        public JdApi[] Apis { get; set; }
    }

    public class JdApi
    {
        public int ApiId { get; set; }
        public string ApiName { get; set; }
    }
}