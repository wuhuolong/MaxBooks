//************************************
//  CommonTool.cs
//  通用的一些辅助函数
//  @Raorui
//  2017.4.25
//************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography; 
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using UnityEngine;
using SGameEngine;

namespace xc
{
    [wxb.Hotfix]
    public class CommonTool : UnityEngine.Object
    {
        static string m_time_format_houras_hours = string.Empty;
        static string m_time_format_houras_minutes = string.Empty;
        static string m_time_format_houras_seconds = string.Empty;

        static string m_time_format_hour = string.Empty;
        static string m_time_format_min = string.Empty;
        static string m_time_format_sec = string.Empty;

        public static string BytesToUtf8(byte[] total)
        {
            byte[] result = total;

            if (total.Length <= 0)
            {
                return string.Empty;
            }

            int start_idx = 0;
            int bytes_num = total.Length;
            if (total[0] == 0xef && total[1] == 0xbb && total[2] == 0xbf)
            {
                // utf8文件的前三个字节为特殊占位符，要跳过
                start_idx = 3;
                bytes_num -= 3;
            }

            string utf8string = System.Text.Encoding.UTF8.GetString(result, start_idx, bytes_num);
            return utf8string;
        }

        /// <summary>
        /// 根据规则返回字符串的长度(汉字+1,英文和数字+0.5)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public float GetWordLenByRule(string str)
        {
            var utf8_parse = new Utils.Utf8Parse(str);
            return utf8_parse.GetWordLenByRule();
        }

        static public string GetMD5(string v)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(v);
            return GetMD5(data);
        }

        static public string GetMD5(byte[] bin)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] encode = md5.ComputeHash(bin);

            string md5Code = System.BitConverter.ToString(encode).ToLower();
            md5Code = md5Code.Replace("-", "");
            return md5Code;
        }

        static public string GetFileMD5(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            int len = (int)fs.Length;
            byte[] data = new byte[len];
            fs.Read(data, 0, len);
            fs.Close();
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string fileMD5 = "";
            foreach (byte b in result)
            {
                string str = System.Convert.ToString(b, 16);
                if (str.Length == 1)
                {
                    str = "0" + str;
                }
                fileMD5 += str;
            }
            return fileMD5;
        }

        /// <summary>
        /// 在_parent节点下创建一个child物体，并将transform归一化
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
		public static GameObject CreateChildGameObject(GameObject _parent, string _name)
		{
			GameObject go = new GameObject(_name);
			if(_parent != null)
			{
				go.transform.parent = _parent.transform;
			}
            NormalizeTransform(go.transform);
			return go;
		}

		//normalize an transform
		private static void NormalizeTransform(Transform _transform)
		{
			_transform.localPosition = Vector3.zero;
			_transform.localRotation = Quaternion.identity;
			_transform.localScale = Vector3.one;
		}

        /// <summary>
        /// 在parent节点下寻找名字为name的transform
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Transform FindChildInHierarchy(Transform parent, string name)
        {
            if (parent == null)
                return null;

            for (int i = 0; i < parent.childCount; i++)
            {
                Transform childTrans = parent.GetChild(i);
                if (childTrans.name == name)
                    return childTrans;
                else
                {
                    Transform t = FindChildInHierarchy(childTrans, name);
                    if (t != null)
                        return t;
                }
            }

            return null;
        }

        /// <summary>
        /// 立即销毁GameObject
        /// </summary>
        /// <param name="obj"></param>
        public static void DestroyObjectImmediate(UnityEngine.Object obj)
        {
            if (obj != null)
            {
                GameObject gameObject = obj as GameObject;
                if (gameObject != null)
                    gameObject.transform.SetParent(null);

                if (!Application.isPlaying)
                {
                    GameObject.DestroyImmediate(obj);
                }
                else
                {
                    GameObject.Destroy(obj);
                }

                obj = null;
            }
        }

        public static string GetDayOfWeekString(DayOfWeek day)
        {
            return string.Format("{0}{1}", DBConstText.GetText("WEEK"), DBConstText.GetText("DAYOFWEEK").Substring((int)day, 1));
        }

        // Note that Color32 and Color implictly convert to each other. You may pass a Color object to this method without first casting it.
        public static string ColorToHex(Color color)
        {
            string hex = (color.r * 255).ToString("X2") + (color.g * 255).ToString("X2") + (color.b * 255).ToString("X2");
            return hex;
        }

        public static Color HexToColor(string hex)
        {
            hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
            hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
            byte a = 255;//assume fully visible unless specified in hex
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            //Only use alpha if the string has enough characters
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return new Color(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
        }

        static void TryInitTimeFormat()
        {
            m_time_format_houras_hours = DBConstText.GetText("TIME_FORMAT_HAS_HOURS");
            m_time_format_houras_minutes = DBConstText.GetText("TIME_FORMAT_HAS_MINUTES");
            m_time_format_houras_seconds = DBConstText.GetText("TIME_FORMAT_HAS_SECONDS");

            m_time_format_hour = DBConstText.GetText("TIME_FORMAT_HOUR"); //时
            m_time_format_min = DBConstText.GetText("TIME_FORMAT_MIN"); //分
            m_time_format_sec = DBConstText.GetText("TIME_FORMAT_SEC"); //秒
        }
        public static string SecondsToStr(int total_seconds)
        {
            if (total_seconds < 0)
                total_seconds = 0;
            int hours = total_seconds / 3600;
            int minutes = (total_seconds - hours * 3600) / 60;
            int seconds = total_seconds % 60;
            if (m_time_format_houras_hours == string.Empty)
                TryInitTimeFormat();
            if(hours > 0)
            {
                return string.Format(m_time_format_houras_hours, hours, minutes, seconds);
            }
            else if(minutes > 0)
            {
                return string.Format(m_time_format_houras_minutes, minutes, seconds);
            }
            else
            {
                return string.Format(m_time_format_houras_seconds, seconds);
            }
        }

        // 数值等于0的时间段不显示，例如3606s-->1小时6秒
        public static string SecondsToStr_2(int total_seconds)
        {
            if (total_seconds < 0)
                total_seconds = 0;

            if (m_time_format_hour == string.Empty)
                TryInitTimeFormat();

            if (0 == total_seconds)
                return string.Format("{0}{1}", total_seconds, m_time_format_sec);

            int hour = total_seconds / 3600;
            int min = (total_seconds - hour * 3600) / 60;
            int sec = total_seconds % 60;

            string ret = "";

            if (hour > 0)
                ret = string.Format("{0}{1}", hour, m_time_format_hour);

            if (min > 0)
                ret = string.Format("{0}{1}{2}", ret, min, m_time_format_min);
                
             
            if (sec > 0)
                ret = string.Format("{0}{1}{2}", ret, sec, m_time_format_sec);

            return ret;
        }

        // 同SecondsToStr_2，只是不显示秒
        public static string SecondsToStr_3(int total_seconds)
        {
            if (total_seconds < 0)
                total_seconds = 0;

            if (m_time_format_hour == string.Empty)
                TryInitTimeFormat();

            if (total_seconds < 60)
                return string.Format("{0}{1}", total_seconds, m_time_format_sec);

            int hour = total_seconds / 3600;
            int min = (total_seconds - hour * 3600) / 60;

            string ret = "";

            if (hour > 0)
                ret = string.Format("{0}{1}", hour, m_time_format_hour);

            if (min > 0)
                ret = string.Format("{0}{1}{2}", ret, min, m_time_format_min);

            return ret;
        }

        // 大于1小时->小时xx分
        // 小于1小时->xx分xx秒
        public static string SecondsToStr_4(int total_seconds)
        {
            if (total_seconds < 0)
                total_seconds = 0;

            int hour = total_seconds / 3600;
            int min = (total_seconds - hour * 3600) / 60;
            int sec = total_seconds % 60;

            string ret = "";
            if (hour > 0)
            {
                ret = string.Format(DBConstText.GetText("OFFLINE_TIME_FORMAT_HAS_HOURS"), hour, min);
            }
            else
            {
                ret = string.Format(DBConstText.GetText("TIME_FORMAT_HAS_MINUTES"), min, sec);
            }
            return ret;
        }

        public static string SecondsToStr_showAllTime(int total_seconds)
        {
            if (total_seconds < 0)
                total_seconds = 0;
            int hours = total_seconds / 3600;
            int minutes = (total_seconds - hours * 3600) / 60;
            int seconds = total_seconds % 60;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }

        static public void SetChildLayer(Transform t, int layer)
        {
            for (int i = 0; i < t.childCount; ++i)
            {
                Transform child = t.GetChild(i);
                child.gameObject.layer = layer;
                SetChildLayer(child, layer);
            }
        }

        /// <summary>
        /// 设置物体的激活状态
        /// </summary>
        /// <param name="game_object"></param>
        /// <param name="active"></param>
        public static void SetActive(GameObject game_object, bool active)
        {
            if (game_object == null)
                return;

            if (game_object.activeSelf != active)
                game_object.SetActive(active);
        }

        public static void RemoveAllChildrenExcept(GameObject parent, string exceptName)
        {
            Transform parentTransform = parent.transform;
            List<Transform> childrenToDestroy = new List<Transform>();
            childrenToDestroy.Clear();
            for (int i = 0; i < parentTransform.childCount; ++i)
            {
                Transform child = parentTransform.GetChild(i);
                if (child.name != exceptName)
                {
                    childrenToDestroy.Add(child);
                }
            }
            foreach (Transform child in childrenToDestroy)
            {
                GameObject.DestroyImmediate(child.gameObject);
            }
        }

        /// <summary>
        /// 获取当前系统时间戳
        /// </summary>
        /// <param name="bflag"></param>
        /// <returns></returns>
        public static long GetCurTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds); ;
        }

        /// <summary>
        /// 取掉字符串中的file://
        /// </summary>
        /// <param name="bundle_url"></param>
        /// <returns></returns>
        public static string WipeFileSprit(string bundle_url)
        {
            string url_no_sprit = "";
            if (bundle_url.IndexOf("file://") == 0)
            {
                url_no_sprit = bundle_url.Substring("file://".Length);
            }
            else
                url_no_sprit = bundle_url;

            return url_no_sprit;
        }

        public static string ParsePrice(float price)
        {
            return ParsePrice(price.ToString());
        }

        /// <summary>
        /// 获取国际化货币单位显示（100,000）
        /// </summary>
        /// <param name="price">价格</param>
        /// <returns></returns>
        public static string ParsePrice(string price)
        {
            if (Const.Region == RegionType.KOREA) {
                var price_str = price;
                var len = price_str.Length;
                while (true) {
                    len -= 3;
                    if (len <= 0) {
                        return price_str;
                    }
                    price_str = price_str.Insert(len, ",");
                }
            }
            else {
                return price;
            }
        }

    }
}
