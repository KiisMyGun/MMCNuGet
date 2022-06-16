using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace MMC.Helper
{
    /// <summary>
    /// 文本解析
    /// </summary>
    public static class TextParsing
    {
        /// <summary>
        /// Json数据进行key，value合并。
        /// 例如：
        /// {"颜色":"淡黄色","规格":"300ml","口味":"蜂蜜"},
        /// {"颜色":"透明","规格":"350ml","口味":"柠檬"},
        /// {"颜色":"淡粉红","规格":"400ml","口味":"水蜜桃"}
        /// =>
        /// {"颜色":["淡黄色","透明","淡粉红"],"规格":["300ml","350ml","400ml"],"口味":["蜂蜜","柠檬","水蜜桃"]}
        /// <paramref name="jsonData"/>
        /// </summary>
        /// <returns></returns>
        public static string MergeJsonKeyValue(string[] jsonData)
        {
            Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>();
            var groupItems = jsonData?.Select(f => f)
                        ?.Select(f => f
                            ?.Replace('{', ' ')
                            ?.Replace('}', ' ')
                            ?.Trim()?.Split(','))
                        ?.SelectMany(f => f);

            foreach (var items in groupItems)
            {
                var item = items
                            ?.Replace('"', ' ')
                            ?.Split(':')
                            ?.Select(f => f.Trim())
                            ?.ToArray();
                if (item is null || item.Length != 2)
                    continue;
                if (keyValuePairs.ContainsKey(item[0]))
                {
                    if (!keyValuePairs[item[0]].Contains(item[1]))
                        keyValuePairs[item[0]].Add(item[1]);
                }
                else
                    keyValuePairs.Add(item[0], new List<string> { item[1] });
            }
            return JsonConvert.SerializeObject(keyValuePairs);
        }
    }
}
