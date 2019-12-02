using System;

namespace BehaviourTree
{
	public interface IBehaviourEmployee
	{
		BehaviourReturnCode RunAction(string action, object[] parameters);

		bool RunCondition(string condition, object[] parameters);

		float RunGetProperty(string property);
	}
}
