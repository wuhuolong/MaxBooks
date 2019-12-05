
//#if INCLUDE_GARBAGE_CODE
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//namespace GarbageCodeLib
//{
//    public static class GarbageCodeUtils
//    {
//        private static System.Random random = new System.Random(System.DateTime.Now.Millisecond);
//        private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
//        private static int cosntLen = constant.Length;
//        private static List<int> intSetList = new List<int>();
//        private static List<string> strSetList = new List<string>();
//        private static List<int[]> arrSetList = new List<int[]>();
//        static GarbageCodeUtils()
//        {
//            const int genNum = 10;
//            for (int i = 0; i < genNum; i++)
//            {
//                intSetList.Add(random.Next(100));
//            }
//            for (int i = 0; i < genNum; i++)
//            {
//                int length = random.Next(6, 10);
//                System.Text.StringBuilder sb = new System.Text.StringBuilder();
//                for (int j = 0; j < length; j++)
//                {
//                    sb.Append(constant[random.Next(0, cosntLen)]);
//                }
//                strSetList.Add(sb.ToString());
//            }
//            for (int i = 0; i < genNum; i++)
//            {
//                int num = random.Next(6, 10);
//                List<int> list = new List<int>();
//                for (int j = 0; j < num; j++)
//                {
//                    list.Add(random.Next(100));
//                }
//                arrSetList.Add(list.ToArray());
//            }

//        }

//        public static int GetNumber(int maxV = int.MaxValue)
//        {
//            int idx = random.Next(intSetList.Count);
//            int result = intSetList[idx];
//            if (maxV <= result)
//            {
//                result = maxV - 1;
//            }
//            return result < 0 ? 0 : result;
//        }

//        public static int[] GetArray()
//        {
//            int idx = random.Next(arrSetList.Count);
//            return arrSetList[idx];
//        }

//        public static string GetString()
//        {
//            int idx = random.Next(strSetList.Count);
//            return strSetList[idx];
//        }
//    }
//}

//#endif