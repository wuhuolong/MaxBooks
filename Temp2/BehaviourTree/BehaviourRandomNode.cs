using System;
using System.Collections;
using UnityEngine;

namespace BehaviourTree
{
	public class BehaviourRandomNode : BehaviourNode
	{
		private BehaviourNode mChild;

		private float mProbability = 1f;

		public BehaviourRandomNode(Hashtable options, IBehaviourEmployee employee) : base(employee)
		{
			Hashtable options2 = options.get_Item("child") as Hashtable;
			string text = options.get_Item("probability") as string;
			bool flag = !string.IsNullOrEmpty(text);
			if (flag)
			{
				this.mProbability = Convert.ToSingle(text);
			}
			else
			{
				this.mProbability = 1f;
			}
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
			bool flag = Random.get_value() <= this.mProbability;
			BehaviourReturnCode result;
			if (flag)
			{
				result = this.mChild.Run();
			}
			else
			{
				result = BehaviourReturnCode.Failure;
			}
			return result;
		}
	}
}
