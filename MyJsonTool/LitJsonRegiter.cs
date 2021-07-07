using LitJson;
using System;
using System.Text.RegularExpressions;

namespace MyJsonTool
{
    /// <summary>
    /// 无法使用float,请使用double
    /// </summary>
    public static class LitJsonRegiter
    {

        /// <summary>
        /// 序列化的类无法使用float,请使用double
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public static string ToJson<T>(this T t)
        {
            return JsonMapper.ToJson(t).Code();
        }
        /// <summary>
        /// 序列化的类无法使用float,请使用double
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象</param>
        /// <param name="PrettyPrint">是否格式化</param>
        /// <returns>json文本</returns>
        public static string ToJson<T>(this T t, bool PrettyPrint)
        {
            return JsonMapper.ToJson(t, PrettyPrint).Code();
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json文本</param>
        /// <returns>对象</returns>
        public static T ToObject<T>(this string json)
        {
            T result = default(T);
            try
            {
                result = JsonMapper.ToObject<T>(json);
            }
            catch (Exception)
            {
                result = default(T);
            }
            return result;
        }

        /// <summary>
        /// 修正可能出现的问题
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Code(this string str)
        {
            str = new Regex("(?i)\\\\[uU]([0-9a-f]{4})").Replace(str, (Match m) => ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString());
            return str;
        }
    }
}
