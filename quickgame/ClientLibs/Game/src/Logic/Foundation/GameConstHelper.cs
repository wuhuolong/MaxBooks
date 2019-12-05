using System;
using System.Collections.Generic;
namespace xc
{
    /// <summary>
    /// 只能获取游戏常量，不能获取程序常量
    /// </summary>
    [wxb.Hotfix]
    public class GameConstHelper
    {
        static Dictionary<string, string> mCache = new Dictionary<string, string>();

        public static float GetFloat(string key)
        {
            float result = 0;

            string raw = GetString(key);

            float.TryParse(raw, out result);

            return result;
        }

        public static ushort GetShort(string key)
        {
            ushort result = 0;

            string raw = GetString(key);

            ushort.TryParse(raw, out result);

            return result;
        }

        public static uint GetUint(string key)
        {
            uint result = 0;

            string raw = GetString(key);

            uint.TryParse(raw, out result);

            return result;
        }

        public static int GetInt(string key)
        {
            int result = 0;

            string raw = GetString(key);

            int.TryParse(raw, out result);

            return result;
        }

        public static string GetString(string key)
        {
            string text = "";
            if (mCache.TryGetValue(key, out text))
            {
                return text;
            }

            List<string> ret = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "xg_game", "name", key, "cvalue");
            if (ret == null || ret.Count == 0)
            {
                text = "";
                GameDebug.LogError("Can not find game const value by key: " + key);
            }
            else
                text = ret[0];

            mCache.Add(key, text);
            return text;
        }

        public static List<string> GetStringList(string key)
        { 
            string raw = GetString(key);
//            string[] splits = raw.Split('[', ']', ',');
//            List<string> lst = new List<string>();
//            foreach (string s in splits)
//            {
//                lst.Add(s);
//            }
//            return lst;
            return DBTextResource.ParseArrayString(raw);
        }

        public static string GetRandomStringInStringList(string key)
        {
            List<string> lst = GetStringList(key);
            if (lst.Count == 0)
                return string.Empty;
            return lst[Maths.Random_.Range(0, lst.Count - 1)];
        }

        public static List<uint> GetUintList(string key)
        { 
            string raw = GetString(key);
            string[] splits = raw.Split('[', ']', ',');
            uint v;
            List<uint> lst = new List<uint>();
            foreach (string s in splits)
            {
                if(uint.TryParse(s, out v))
                {
                    lst.Add(v);
                }
            }
            return lst;
        }

        public static List<float> GetFloatList(string key)
        {
            string raw = GetString(key);
            string[] splits = raw.Split('[', ']', ',');
            float v;
            List<float> lst = new List<float>();
            lst.Clear();
            foreach (string s in splits)
            {
                if (float.TryParse(s, out v))
                {
                    lst.Add(v);
                }
            }
            return lst;
        }

        public static List<uint> GetUintListByBrace(string key)
        {
            string raw = GetString(key);
            string[] splits = raw.Split('{', '}', ',');
            uint v;
            List<uint> lst = new List<uint>();
            foreach (string s in splits)
            {
                if (uint.TryParse(s, out v))
                {
                    lst.Add(v);
                }
            }
            return lst;
        }
        public static uint GetRandomUintInStringList(string key)
        {
            List<uint> lst = GetUintList(key);
            if (lst.Count == 0)
                return 0;
            return lst[Maths.Random_.Range(0, lst.Count - 1)];
        }

        // C# 模板编程不支援类似C++泛型的特化，这种函式怎么写?
//         public T GetValue<T>(string key)
//         {
//             
// 
//             DBGame db = DBGame.Instance;
//         }
    }
}