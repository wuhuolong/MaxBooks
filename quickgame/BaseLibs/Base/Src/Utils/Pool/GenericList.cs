using System;
using System.Collections.Generic;
using UnityEngine;

namespace SGameEngine
{
    public static partial class Pool<T>
    {
        public static class List
        {
            public static int Count { get; private set; }
            private static Queue<List<T>> Pool;

            static List()
            {
                Pool = new Queue<List<T>>();
            }

            public static List<T> New()
            {
                if (++Count > MaxCapacity)
                    Debug.LogError(DateTime.Now + "\t超预设容量！" + typeof(T).FullName);

                List<T> list;

                if (Pool.Count > 0)
                    list = Pool.Dequeue();
                else
                    list = new List<T>();

                return list;
            }

            public static List<T> New(int capacity)
            {
                if (++Count > MaxCapacity)
                    Debug.LogError(DateTime.Now + "\t超预设容量！" + typeof(T).FullName);

                List<T> list;

                if (Pool.Count > 0)
                {
                    list = Pool.Dequeue();
                    if (list.Capacity < capacity)
                        list.Capacity = Mathf.NextPowerOfTwo(capacity);
                }
                else
                    list = new List<T>(Mathf.NextPowerOfTwo(capacity));
                

                return list;
            }

            public static void Free(ref List<T> list)
            {
                Free(list);
                list = null;
            }

            public static void Free(List<T> list)
            {
                if (--Count < 0)
                    throw new Exception(typeof(T).FullName);

                list.Clear();
                Pool.Enqueue(list);
            }
        }
    }

    public struct ScopeList<T> : IDisposable
    {
        public List<T> List { get; private set; }

        public ScopeList(int capacity)
        {
            List = Pool<T>.List.New(capacity);
        }

        void IDisposable.Dispose()
        {
            if (List == null)
                throw new Exception("肯定用了默认构造！");

            Pool<T>.List.Free(List);
            List = null;
        }
    }
}