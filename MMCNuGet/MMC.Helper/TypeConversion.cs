using System;
using System.Linq;

using Microsoft.AspNetCore.Http;

namespace MMC.Helper
{
    /// <summary>
    /// 类型转换
    /// </summary>
    public class TypeConversion
    {
        /// <summary>
        /// 表单类型转换实体类型
        /// 常用于：[Consumes("application/x-www-form-urlencoded")] 转换为实体类型
        /// </summary>
        /// <param name="formCollection">表单数据</param>
        /// <param name="type">实体类型</param>
        /// <returns></returns>
        public static Type FromToObject(IFormCollection formCollection, Type type)
        {
            var dic = formCollection.ToDictionary(m => m.Key, n => n.Value);
            if (dic != null && dic.Count > 0)
            {
                var propertyInfos = type.GetProperties();
                foreach (var item in propertyInfos)
                {
                    if (dic.ContainsKey(item.Name))
                        item.SetValue(type, dic[item.Name].ToString());
                }
            }
            return type;
        }
    }
}
