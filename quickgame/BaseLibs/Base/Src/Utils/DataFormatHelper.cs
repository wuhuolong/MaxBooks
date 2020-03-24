using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    public static class DataFormatHelper
    {
        public static Vector3 StringToVector3(string raw)
        {
            raw = raw.Replace("(", "").Replace(")", "");

            string[] results = raw.Split(',');

            if (results.Length < 3)
            {
                return Vector3.zero;
            }

            return new Vector3(float.Parse(results[0]), float.Parse(results[1]), float.Parse(results[2]));
        }

        public static Vector2 StringToVector2(string raw)
        {
            raw = raw.Replace("(", "").Replace(")", "");
            raw = raw.Replace("[", "").Replace("]", "");
            raw = raw.Replace("{", "").Replace("}", "");

            string[] results = raw.Split(',');

            if (results.Length < 2)
            {
                return Vector2.zero;
            }

            return new Vector2(float.Parse(results[0]), float.Parse(results[1]));
        }

        public static Quaternion StringToQuaternion(string raw)
        {
            raw = raw.Replace("(", "").Replace(")", "");

            string[] results = raw.Split(',');

            if (results.Length < 4)
            {
                return Quaternion.identity;
            }

            return new Quaternion(float.Parse(results[0]), float.Parse(results[1]), float.Parse(results[2]), float.Parse(results[3]));
        }

        public static string ContainerToString<T>(T container) where T : IEnumerable
        {
            string result = "(";

            int count = 0;
            foreach (var itr in container)
            {
                result += itr;
                result += ',';

                ++count;
            }

            if (count > 0)
            {
                result = result.Remove(result.Length - 1);
            }

            result += ")";

            return result;
        }

        /// <summary>
        /// 数据库的字段去除中括号解析出ID列表
        /// </summary>
        /// <param name="rawString"></param>
        /// <param name="ids"></param>
        public static void DBRawStringReplaceBracketToIds(string rawString, List<uint> ids)
        {
            if (ids == null || string.IsNullOrEmpty(rawString))
            {
                return;
            }

            rawString = rawString.Replace("[", "");
            rawString = rawString.Replace("]", "");
            rawString = rawString.Replace("{", "");
            rawString = rawString.Replace("}", "");

            string[] rewards = rawString.Split(',');

            foreach (var item in rewards)
            {
                uint rewardId = 0;

                uint.TryParse(item, out rewardId);

                if (rewardId != 0)
                {
                    ids.Add(rewardId);
                }
            }
        }

        /// <summary>
        /// 数据库的字段去除大括号解析出ID列表
        /// </summary>
        /// <param name="rawString"></param>
        /// <param name="ids"></param>
        public static void DBRawStringReplaceBraceToIds(string rawString, List<uint> ids)
        {
            if (ids == null || string.IsNullOrEmpty(rawString))
            {
                return;
            }

            rawString = rawString.Replace("{", "");
            rawString = rawString.Replace("}", "");

            string[] rewards = rawString.Split(',');

            foreach (var item in rewards)
            {
                uint rewardId = 0;

                uint.TryParse(item, out rewardId);

                if (rewardId != 0)
                {
                    ids.Add(rewardId);
                }
            }
        }

        /// <summary>
        /// 数据库的字段去除中括号解析出ID
        /// </summary>
        /// <param name="rawString"></param>
        /// <param name="ids"></param>
        public static void DBRawStringReplaceBracketToId(string rawString, out uint id)
        {
            id = 0;

            if (string.IsNullOrEmpty(rawString))
            {
                return;
            }

            rawString = rawString.Replace("[", "");
            rawString = rawString.Replace("]", "");

            uint.TryParse(rawString, out id);
            return;
        }

        /// <summary>
        /// 得到要返回的某个字段的值从Map中
        /// </summary>
        /// <param name="dbs"></param>
        /// <param name="idName"></param>
        /// <param name="idKey"></param>
        /// <param name="targetName"></param>
        /// <returns></returns>
        public static string GetDBValue(List<Dictionary<string, string>> dbs, string idName, string idKey, string targetName)
        {
            if (dbs == null)
            {
                return string.Empty;
            }

            foreach (var item in dbs)
            {
                string dbIdValue = string.Empty;
                if (item.TryGetValue(idName, out dbIdValue))
                {
                    if (dbIdValue != idKey)
                    {
                        continue;
                    }

                    string result = string.Empty;

                    if (item.TryGetValue(targetName, out result))
                    {
                        return result;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        public static uint GetDBValueByUint(List<Dictionary<string, string>> dbs, string idName, string idKey, string targetName)
        {
            string raw = GetDBValue(dbs, idName, idKey, targetName);

            uint result = 0;
            uint.TryParse(raw, out result);

            return result;
        }

        public static float GetDBValueByFloat(List<Dictionary<string, string>> dbs, string idName, string idKey, string targetName)
        {
            string raw = GetDBValue(dbs, idName, idKey, targetName);

            float result = 0;
            float.TryParse(raw, out result);

            return result;
        }
    }
}