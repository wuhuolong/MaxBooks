using System;
using System.Collections.Generic;
using UnityEngine;

namespace SGameEngine
{
	public class ObjectPool
	{
		private List<IPoolable> objs;

		private int maxCap;

		private Func<IPoolable> factory;

		public ObjectPool(Func<IPoolable> factory, int maxCap = 100)
		{
			bool flag = factory == null;
			if (flag)
			{
				Debug.LogError("factory is null");
			}
			else
			{
				this.objs = new List<IPoolable>();
				this.factory = factory;
				this.maxCap = maxCap;
			}
		}

		public void SetFactoryFunction(Func<IPoolable> factory)
		{
			this.factory = factory;
		}

		public void Free(IPoolable obj)
		{
			bool flag = obj == null;
			if (flag)
			{
				Debug.LogError("poolable object is nil");
			}
			else
			{
				bool flag2 = this.objs.get_Count() >= this.maxCap;
				if (!flag2)
				{
					obj.OnFreeToPool();
					this.objs.Add(obj);
				}
			}
		}

		public IPoolable Get()
		{
			bool flag = this.objs.get_Count() == 0;
			IPoolable result;
			if (flag)
			{
				result = this.factory.Invoke();
			}
			else
			{
				IPoolable poolable = this.objs.get_Item(this.objs.get_Count() - 1);
				this.objs.RemoveAt(this.objs.get_Count() - 1);
				poolable.OnGetFromPool();
				result = poolable;
			}
			return result;
		}

		public void ClearAll()
		{
			this.objs.Clear();
		}
	}
}
