namespace Common
{
    public class ConvertExtend
    {
        /// <summary>
        /// 大写转下划线
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string UpperToUnderline(string source)
        {
            var result = string.Empty;
            foreach (var item in source)
            {
                if (item >= 65 && item <= 90)
                {
                    var temp = string.Empty;
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        temp = "_";
                    }
                    result += temp + item.ToString().ToLower();
                }
                else
                {
                    result += item.ToString();
                }
            }
            return result;
        }

        /// <summary>
        /// 下划线转大写
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string UnderlineToUpper(string source)
        {
            var result = string.Empty;
            var toUpper = false;
            foreach (var item in source)
            {
                if (item == '_' && !string.IsNullOrWhiteSpace(result))
                {
                    toUpper = true;
                }
                else
                {
                    if (toUpper || string.IsNullOrWhiteSpace(result))
                    {
                        result += item.ToString().ToUpper();
                        toUpper = false;
                    }
                    else
                    {
                        result += item.ToString();
                    }
                }
            }
            return result;
        }
    }
}