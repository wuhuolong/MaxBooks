using System;
using System.Collections.Generic;

namespace SGameEngine
{
	public struct ScopeList<T> : IDisposable
	{
		public List<T> List
		{
			get;
			private set;
		}

		public ScopeList(int capacity)
		{
			this.List = Pool<T>.List.New(capacity);
		}

		void IDisposable.Dispose()
		{
			bool flag = this.List == null;
			if (flag)
			{
				throw new Exception("肯定用了默认构造！");
			}
			Pool<T>.List.Free(this.List);
			this.List = null;
		}
	}
}
