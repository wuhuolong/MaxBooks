using System;
using System.Collections.Generic;
using UnityEngine;

namespace SGameEngine
{
	public static class Pool<TKey, TValue>
	{
		public static class Dictionary
		{
			private static Queue<Dictionary<TKey, TValue>> Pool;

			public static int Count
			{
				get;
				private set;
			}

			static Dictionary()
			{
				Pool<TKey, TValue>.Dictionary.Pool = new Queue<Dictionary<TKey, TValue>>();
			}

			public static Dictionary<TKey, TValue> New()
			{
				int num = Pool<TKey, TValue>.Dictionary.Count + 1;
				Pool<TKey, TValue>.Dictionary.Count = num;
				bool flag = num > 100;
				if (flag)
				{
					Debug.LogError(string.Concat(new object[]
					{
						DateTime.get_Now(),
						"\t超预设容量！",
						typeof(TKey).get_FullName(),
						", ",
						typeof(TValue).get_FullName()
					}));
				}
				bool flag2 = Pool<TKey, TValue>.Dictionary.Pool.get_Count() > 0;
				Dictionary<TKey, TValue> result;
				if (flag2)
				{
					result = Pool<TKey, TValue>.Dictionary.Pool.Dequeue();
				}
				else
				{
					result = new Dictionary<TKey, TValue>();
				}
				return result;
			}

			public static void Free(ref Dictionary<TKey, TValue> dict)
			{
				Pool<TKey, TValue>.Dictionary.Free(dict);
				dict = null;
			}

			public static void Free(Dictionary<TKey, TValue> dict)
			{
				int num = Pool<TKey, TValue>.Dictionary.Count - 1;
				Pool<TKey, TValue>.Dictionary.Count = num;
				bool flag = num < 0;
				if (flag)
				{
					throw new Exception(typeof(TKey).get_FullName() + ", " + typeof(TValue).get_FullName());
				}
				dict.Clear();
				Pool<TKey, TValue>.Dictionary.Pool.Enqueue(dict);
			}
		}

		public const int MaxCapacity = 100;
	}
	public static class Pool<T>
	{
		public static class HashSet
		{
			private static Queue<HashSet<T>> Pool;

			public static int Count
			{
				get;
				private set;
			}

			static HashSet()
			{
				Pool<T>.HashSet.Pool = new Queue<HashSet<T>>();
			}

			public static HashSet<T> New()
			{
				int num = Pool<T>.HashSet.Count + 1;
				Pool<T>.HashSet.Count = num;
				bool flag = num > 100;
				if (flag)
				{
					Debug.LogError(DateTime.get_Now() + "\t超预设容量！" + typeof(T).get_FullName());
				}
				bool flag2 = Pool<T>.HashSet.Pool.get_Count() > 0;
				HashSet<T> result;
				if (flag2)
				{
					result = Pool<T>.HashSet.Pool.Dequeue();
				}
				else
				{
					result = new HashSet<T>();
				}
				return result;
			}

			public static void Free(ref HashSet<T> hashset)
			{
				Pool<T>.HashSet.Free(hashset);
				hashset = null;
			}

			public static void Free(HashSet<T> hashset)
			{
				int num = Pool<T>.HashSet.Count - 1;
				Pool<T>.HashSet.Count = num;
				bool flag = num < 0;
				if (flag)
				{
					throw new Exception(typeof(T).get_FullName());
				}
				hashset.Clear();
				Pool<T>.HashSet.Pool.Enqueue(hashset);
			}
		}

		public static class List
		{
			private static Queue<List<T>> Pool;

			public static int Count
			{
				get;
				private set;
			}

			static List()
			{
				Pool<T>.List.Pool = new Queue<List<T>>();
			}

			public static List<T> New()
			{
				int num = Pool<T>.List.Count + 1;
				Pool<T>.List.Count = num;
				bool flag = num > 100;
				if (flag)
				{
					Debug.LogError(DateTime.get_Now() + "\t超预设容量！" + typeof(T).get_FullName());
				}
				bool flag2 = Pool<T>.List.Pool.get_Count() > 0;
				List<T> result;
				if (flag2)
				{
					result = Pool<T>.List.Pool.Dequeue();
				}
				else
				{
					result = new List<T>();
				}
				return result;
			}

			public static List<T> New(int capacity)
			{
				int num = Pool<T>.List.Count + 1;
				Pool<T>.List.Count = num;
				bool flag = num > 100;
				if (flag)
				{
					Debug.LogError(DateTime.get_Now() + "\t超预设容量！" + typeof(T).get_FullName());
				}
				bool flag2 = Pool<T>.List.Pool.get_Count() > 0;
				List<T> list;
				if (flag2)
				{
					list = Pool<T>.List.Pool.Dequeue();
					bool flag3 = list.get_Capacity() < capacity;
					if (flag3)
					{
						list.set_Capacity(Mathf.NextPowerOfTwo(capacity));
					}
				}
				else
				{
					list = new List<T>(Mathf.NextPowerOfTwo(capacity));
				}
				return list;
			}

			public static void Free(ref List<T> list)
			{
				Pool<T>.List.Free(list);
				list = null;
			}

			public static void Free(List<T> list)
			{
				int num = Pool<T>.List.Count - 1;
				Pool<T>.List.Count = num;
				bool flag = num < 0;
				if (flag)
				{
					throw new Exception(typeof(T).get_FullName());
				}
				list.Clear();
				Pool<T>.List.Pool.Enqueue(list);
			}
		}

		public const int MaxCapacity = 100;
	}
}
