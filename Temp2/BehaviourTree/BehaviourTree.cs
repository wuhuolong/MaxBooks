using System;
using System.Collections;

namespace BehaviourTree
{
	public class BehaviourTree
	{
		private string mName;

		private BehaviourNode mRootNode;

		private IBehaviourEmployee mEmployee;

		public BehaviourTree(string name, Hashtable options, IBehaviourEmployee employee)
		{
			this.mName = name;
			this.mEmployee = employee;
			this.mRootNode = BehaviourNode.CreateNode(options, employee);
		}

		public BehaviourReturnCode Run()
		{
			bool flag = this.mRootNode != null;
			BehaviourReturnCode result;
			if (flag)
			{
				result = this.mRootNode.Run();
			}
			else
			{
				result = BehaviourReturnCode.Success;
			}
			return result;
		}

		public string GetName()
		{
			return this.mName;
		}

		public void Reset(IBehaviourEmployee employee)
		{
			this.mEmployee = employee;
			this.mRootNode.Reset(employee);
		}
	}
}
