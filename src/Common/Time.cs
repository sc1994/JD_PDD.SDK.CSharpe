using System;

namespace Common
{
    public class Time
    {
        public static string GetTimeStampSecond(int length = 10)
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            if (length == 10)
            {
                return Convert.ToInt64(ts.TotalSeconds).ToString();
            }
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
    }
}