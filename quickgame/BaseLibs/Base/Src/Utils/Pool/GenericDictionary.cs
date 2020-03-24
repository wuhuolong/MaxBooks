using System;
using System.Collections.Generic;
using UnityEngine;

namespace SGameEngine
{
    public static partial class Pool<TKey, TValue>
    {
        public const int MaxCapacity = 100;

        public static class Dictionary
        {
            public static int Count { get; private set; }
            private static Queue<Dictionary<TKey, TValue>> Pool;


            static Dictionary()
            {
                Pool = new Queue<Dictionary<TKey, TValue>>();
            }

            public static Dictionary<TKey, TValue> New()
            {
                if (++Count > MaxCapacity)
                    Debug.LogError(DateTime.Now + "\t超预设容量！" + typeof(TKey).FullName + ", " + typeof(TValue).FullName);

                Dictionary<TKey, TValue> dict;

                if (Pool.Count > 0)
                    dict = Pool.Dequeue();
                else
                    dict = new Dictionary<TKey, TValue>();

                return dict;
            }

            public static void Free(ref Dictionary<TKey, TValue> dict)
            {
                Free(dict);
                dict = null;
            }

            public static void Free(Dictionary<TKey, TValue> dict)
            {
                if (--Count < 0)
                    throw new Exception(typeof(TKey).FullName + ", " + typeof(TValue).FullName);

                dict.Clear();
                Pool.Enqueue(dict);
            }
        }
    }
}