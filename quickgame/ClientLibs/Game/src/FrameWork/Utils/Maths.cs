using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace xc
{
    namespace Maths
    {
        public class Util
        {
            const uint SecondsInHour = 60 * 60;
            const uint SecondsInDay = 24 * SecondsInHour;
            const uint SecondsInMinute = 60;
            private static double DOUBLEDELTA = 1E-06;

            /// <summary>
            /// 将单位向量转换为单位极坐标
            /// </summary>
            public static float VectorToAngle(Vector2 vec)
            {
                float angle = 0;
                if(vec.x != 0)
                {
                    if(vec.y != 0)
                    {
                        if(vec.x > 0)
                            angle = Mathf.Atan(vec.y/vec.x);
                        else if(vec.y > 0)
                            angle = Mathf.PI - Mathf.Atan(vec.y/-vec.x);
                        else
                            angle = -Mathf.PI - Mathf.Atan(vec.y/-vec.x);
                    }
                    else
                    {
                        if(vec.x > 0)
                            return 0;
                        else
                            return Mathf.PI;
                    }
                }
                else if(vec.y >= 0)
                {
                    angle = Mathf.PI/2.0f;
                }
                else
                    angle = -Mathf.PI/2.0f;

                return angle;
            }

            /// <summary>
            /// 将单位向量转换为单位极坐标, vec的y值不使用，范围为-180~180
            /// </summary>
            public static float VectorToAngle(Vector3 vec)
            {
                float angle = 0;
                if(vec.x != 0)
                {
                    if(vec.z != 0)
                    {
                        if(vec.x > 0)
                            angle = Mathf.Atan(vec.z/vec.x);
                        else if(vec.z > 0)
                            angle = Mathf.PI - Mathf.Atan(vec.z/-vec.x);
                        else
                            angle = -Mathf.PI - Mathf.Atan(vec.z/-vec.x);
                    }
                    else
                    {
                        if(vec.x > 0)
                            return 0;
                        else
                            return Mathf.PI;
                    }
                }
                else if(vec.z >= 0)
                {
                    angle = Mathf.PI/2.0f;
                }
                else
                    angle = -Mathf.PI/2.0f;
                
                return angle;
            }

            /// <summary>
            /// 将单位极坐标转换为单位向量，向量的y值为0
            /// </summary>
            public static Vector3 AngleToVector(float angle)
            {
                Vector3 vec = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                return vec;
            }

            /// <summary>
            /// 将单位极坐标转换为单位向量，向量的y值不变
            /// </summary>
            public static void AngleToVector(float angle, ref Vector3 vec)
            {
                vec.x = Mathf.Cos(angle);
                vec.z = Mathf.Sin(angle);
            }

            /// <summary>
            /// 将单位向量转换为单位极坐标, vec的y值不使用,范围为0~360
            /// </summary>
            public static float VectorToAngleXY(Vector3 vec)
            {
                float angle = 0;
                if(vec.x != 0)
                {
                    if(vec.y != 0)
                    {
                        if(vec.x > 0)
                            angle = Mathf.Atan(vec.y/vec.x);
                        else if(vec.y > 0)
                            angle = Mathf.PI - Mathf.Atan(vec.y/-vec.x);
                        else
                            angle = -Mathf.PI - Mathf.Atan(vec.y/-vec.x);
                    }
                    else
                    {
                        if(vec.x > 0)
                            return 0;
                        else
                            return Mathf.PI;
                    }
                }
                else if(vec.y >= 0)
                {
                    angle = Mathf.PI/2.0f;
                }
                else
                    angle = -Mathf.PI/2.0f;

                return angle + Mathf.PI;
            }

            public static bool Compare(float a, float b)
            {
                return (a == b) || Mathf.Abs(a - b) < DOUBLEDELTA;
            }

            public static bool IsHitHelp(float rate)
            {
                //精确到小数点后三位数
                return IsHitHelp(rate, 1000);
            }
            
            public static bool IsHitHelp(float rate, uint uiFactor)
            {
                uint count = (uint)(rate * uiFactor);
                return (uint)Random_.Range(0, uiFactor - 1) < count ? true : false;
            }
            
            public static void SecondToDay(uint uiSeconds, out uint uiDay, out uint uiRemainSeconds)
            {
                uiDay = uiSeconds / SecondsInDay;
                uiRemainSeconds = uiSeconds - uiDay * SecondsInDay;
            }
            
            public static void SecondToHour(uint uiSeconds, out uint uiHour, out uint uiRemainSeconds)
            {
                uiHour = uiSeconds / SecondsInHour;
                uiRemainSeconds = uiSeconds - uiHour * SecondsInHour;
            }
            
            public static int FindIndexFotInt(int num, int index)
            {
                int _index = 0;
                string str = num.ToString();
                if (index >= str.Length)
                    return 0;
                string _str = str.Substring(index, 1);
                _index = System.Convert.ToInt32(_str);
                return _index;
            }

            public static void SecondToMinute(uint uiSeconds, out uint uiMinute, out uint uiRemainSeconds)
            {
                uiMinute = uiSeconds / SecondsInMinute;
                uiRemainSeconds = uiSeconds % SecondsInMinute;
            }

            public static float[] LineCrossPlanePoint(Vector3 linePos, Vector3 lineDir, Vector3 planePos, Vector3 planeDir)
            {
                float a = Vector3.Dot(lineDir, planeDir);
                if (a == 0)
                    return null;
                
                float[] crossPoint = new float[3];
                float t = planeDir.x * (planePos.x - linePos.x) + planeDir.y * (planePos.y - linePos.y) 
                    + planeDir.z * (planePos.z - linePos.z);
                t /= a;
                
                crossPoint [0] = linePos.x + lineDir.x * t;
                crossPoint [1] = linePos.y + lineDir.y * t;
                crossPoint [2] = linePos.z + lineDir.z * t;
                return crossPoint;
            }

            /// <summary>
            /// 调整rect1的位置，使其不与rect2重叠
            /// </summary>
            /// <returns>The rect position for not overlap.</returns>
            /// <param name="rect1">Rect1.</param>
            /// <param name="rect2">Rect2.</param>
            public static Rect AdjustRectPositionForNotOverlap(Rect rect1, Rect rect2)
            {
                if (rect1.Overlaps(rect2) == false)
                    return rect1;

                if (rect1.y > rect2.y)
                {
                    rect1.y = rect2.y + rect2.height;
                }
                else
                {
                    rect1.y = rect2.y - rect1.height;
                }

                return rect1;
            }

            /// <summary>
            /// 将DateTime类型转换成时间戳
            /// </summary>
            /// <returns>The date time to timestamp.</returns>
            /// <param name="dateTime">Date time.</param>
            public static double ConvertDateTimeToTimestamp(System.DateTime dateTime)
            {
                return ConvertDateTimeToTimestamp(dateTime, false);
            }

            public static double ConvertDateTimeToTimestamp(System.DateTime dateTime, bool isLocalTime)
            {
                double timestamp = 0;
                System.DateTime startTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                if (isLocalTime == false)
                {
                    dateTime = dateTime.ToLocalTime();
                }
                timestamp = (dateTime - startTime.ToLocalTime()).TotalSeconds;
                
                return timestamp;
            }

            /// <summary>
            /// 获取整数的某一位
            /// </summary>
            /// <returns>The integer some bit.</returns>
            /// <param name="input">Input.</param>
            /// <param name="index">Index.</param>
            public static int GetIntegerSomeBit(int input, byte index)
            {
                return input >> index & 1;
            }
        }
        
        public class Random_
        {
            public static Vector2 insideUnitCircle
            {
                get
                {
                    Vector2 res = Vector2.zero;
                    float r = Range(0f, 1.0f);
                    float theta = Range(0f, 1.0f) * 2.0f * Mathf.PI;
                    res.x = Mathf.Cos(theta) * r;
                    res.y = Mathf.Sin(theta) * r;
                    return res;
                }
            }
            
            public static float Range(float min, float max)
            {
                float res = Random.Range(min, max);
                return res;
            }
            
            public static int Range(int min, int max)
            {
                int res = Random.Range(min, max + 1);
                return res;
            }
        }
        
        public class TimeTraslateHMS
        {
            uint muiHour = 0;

            public uint Hour
            {
                get{ return muiHour;}
            }
            
            uint muiMinute = 0;

            public uint Minute
            {
                get{ return muiMinute;}
            }
            
            uint muiSecond = 0;

            public uint Second
            {
                get{ return muiSecond;}
            }
            
            public void InitBySecond(uint uiTimeInSecond)
            {
                Second2HMS(uiTimeInSecond, out muiHour, out muiMinute, out muiSecond);
            }
            
            public override string ToString()
            {
                return string.Format("{0:D2}:{1:D2}:{2:D2}", Hour, Minute, Second);
            }
            
            public static void Second2HMS(uint uiTimeInSecond, out uint uiHour, out uint uiMinute, out uint uiSecond)
            {   
                // second
                uiSecond = uiTimeInSecond % 60;
                if (uiTimeInSecond > uiSecond)
                {
                    uiTimeInSecond -= uiSecond;
                    uiTimeInSecond /= 60;                       
                }
                else
                {
                    uiMinute = 0;
                    uiHour = 0;
                    return;
                }
                
                // minute               
                uiMinute = uiTimeInSecond % 60;
                if (uiTimeInSecond > uiMinute)
                {
                    uiTimeInSecond -= uiMinute; 
                    uiHour = uiTimeInSecond / 60;                   
                }
                else
                {
                    uiHour = 0;
                    return;
                }
            }
            
            public static void Second2DHMS(uint uiTimeInSecond, out uint uiDay, out uint uiHour, out uint uiMinute, out uint uiSecond)
            {
                uiDay = uiTimeInSecond / (60 * 60 * 24);
                uiSecond = uiTimeInSecond % (60 * 60 * 24);
                Second2HMS(uiSecond, out uiHour, out uiMinute, out uiSecond);
            }

            public static string GetFMTTime(decimal fTime)
            {
                decimal mTimeRemainSec = fTime / 1000;
                int sec = (int)(mTimeRemainSec % 60);
                int min = (int)((mTimeRemainSec % 3600) / 60);
                int hour = (int)(mTimeRemainSec / 3600);

                string sec_str;
                if (sec >= 10)
                    sec_str = sec.ToString();
                else
                    sec_str = "0" + sec.ToString();

                string min_str;
                if (min >= 10)
                    min_str = min.ToString();
                else
                    min_str = "0" + min.ToString();

                string hour_str;
                if (hour >= 10)
                    hour_str = hour.ToString();
                else
                    hour_str = "0" + hour.ToString();

                switch (Const.Language)
                {
                    case LanguageType.SIMPLE_CHINESE:
                        if (hour > 0)
                            return string.Format("{0}小时{1}分{2}秒", hour_str, min_str, sec_str);
                        else
                            return string.Format("{0}分{1}秒", min_str, sec_str);
                    case LanguageType.TRADITIONAL_CHINESE:
                        if (hour > 0)
                            return string.Format("{0}小時{1}分{2}秒", hour_str, min_str, sec_str);
                        else
                            return string.Format("{0}分{1}秒", min_str, sec_str);
                    case LanguageType.KOREAN:
                        if (hour > 0)
                            return string.Format("{0}시간 {1}분 {2}초", hour_str, min_str, sec_str);
                        else
                            return string.Format("{0}분 {1}초", min_str, sec_str);
                    case LanguageType.ASIAN_ENGLISH:
                        if (hour > 0)
                            return string.Format("{0}:{1}:{2}", hour_str, min_str, sec_str);
                        else
                            return string.Format("{0}:{1}", min_str, sec_str);
                    case LanguageType.VIETNAMESE:
                        if (hour > 0)
                            return string.Format("{0} giờ {1} phút {2} giây", hour_str, min_str, sec_str);
                        else
                            return string.Format("{0} m {1} s", min_str, sec_str);
                    case LanguageType.THAI:
                        if (hour > 0)
                            return string.Format("{0}ชม.{1}นาที{2}วินาที", hour_str, min_str, sec_str);
                        else
                            return string.Format("{0}นาที{1}วินาที", min_str, sec_str);
                    default:
                        if (hour > 0)
                            return string.Format("{0}小时{1}分{2}秒", hour_str, min_str, sec_str);
                        else
                            return string.Format("{0}分{1}秒", min_str, sec_str);
                }
            }
        }
    }
}
