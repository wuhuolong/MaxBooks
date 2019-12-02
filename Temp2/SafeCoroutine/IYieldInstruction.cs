using System;

namespace SafeCoroutine
{
	public interface IYieldInstruction
	{
		bool Update(float delta_time);
	}
}
