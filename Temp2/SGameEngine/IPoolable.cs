using System;

namespace SGameEngine
{
	public interface IPoolable
	{
		void OnGetFromPool();

		void OnFreeToPool();
	}
}
