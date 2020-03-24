using System;
using System.Collections.Generic;
using UnityEngine;

namespace SGameEngine
{
    public static partial class Pool<T>
    {
        public const int MaxCapacity = 100;

        public static class HashSet
        {
            public static int Count { get; private set; }
            private static Queue<HashSet<T>> Pool;


            static HashSet()
            {
                Pool = new Queue<HashSet<T>>();

            }

            public static HashSet<T> New()
            {
                if (++Count > MaxCapacity)
                    Debug.LogError(DateTime.Now + "\t超预设容量！" + typeof(T).FullName);

                HashSet<T> hashset;

                if (Pool.Count > 0)
                    hashset = Pool.Dequeue();
                else
                    hashset = new HashSet<T>();

                return hashset;
            }

            public static void Free(ref HashSet<T> hashset)
            {
                Free(hashset);
                hashset = null;
            }

            public static void Free(HashSet<T> hashset)
            {
                if (--Count < 0)
                    throw new Exception(typeof(T).FullName);

                hashset.Clear();
                Pool.Enqueue(hashset);
            }
        }
    }
}