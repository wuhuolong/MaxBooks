using System;
using System.Collections;

namespace BehaviourTree
{
	public class BehaviourInverterNode : BehaviourNode
	{
		private BehaviourNode mChild;

		public BehaviourInverterNode(Hashtable options, IBehaviourEmployee employee) : base(employee)
		{
			Hashtable options2 = options.get_Item("child") as Hashtable;
			this.mChild = BehaviourNode.CreateNode(options2, employee);
		}

		public override void Reset(IBehaviourEmployee employee)
		{
			this.mEmployee = employee;
			bool flag = this.mChild != null;
			if (flag)
			{
				this.mChild.Reset(employee);
			}
		}

		public override BehaviourReturnCode Run()
		{
			BehaviourReturnCode result;
			switch (this.mChild.Run())
			{
			case BehaviourReturnCode.Failure:
				result = BehaviourReturnCode.Success;
				break;
			case BehaviourReturnCode.Success:
				result = BehaviourReturnCode.Failure;
				break;
			case BehaviourReturnCode.Running:
				result = BehaviourReturnCode.Running;
				break;
			default:
				result = BehaviourReturnCode.Success;
				break;
			}
			return result;
		}
	}
}
