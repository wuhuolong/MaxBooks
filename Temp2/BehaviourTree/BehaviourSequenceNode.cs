using System;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
	public class BehaviourSequenceNode : BehaviourNode
	{
		private List<BehaviourNode> mChildren = new List<BehaviourNode>();

		public BehaviourSequenceNode(Hashtable options, IBehaviourEmployee employee) : base(employee)
		{
			ArrayList arrayList = options.get_Item("queue") as ArrayList;
			bool flag = arrayList == null;
			if (!flag)
			{
				int num;
				for (int i = 0; i < arrayList.get_Count(); i = num + 1)
				{
					BehaviourNode behaviourNode = BehaviourNode.CreateNode(arrayList.get_Item(i) as Hashtable, employee);
					this.mChildren.Add(behaviourNode);
					num = i;
				}
			}
		}

		public override void Reset(IBehaviourEmployee employee)
		{
			this.mEmployee = employee;
			using (List<BehaviourNode>.Enumerator enumerator = this.mChildren.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BehaviourNode current = enumerator.get_Current();
					current.Reset(employee);
				}
			}
		}

		public override BehaviourReturnCode Run()
		{
			BehaviourReturnCode mReturnCode;
			int num;
			for (int i = 0; i < this.mChildren.get_Count(); i = num + 1)
			{
				switch (this.mChildren.get_Item(i).Run())
				{
				case BehaviourReturnCode.Failure:
					this.mReturnCode = BehaviourReturnCode.Failure;
					mReturnCode = this.mReturnCode;
					return mReturnCode;
				case BehaviourReturnCode.Running:
					this.mReturnCode = BehaviourReturnCode.Running;
					mReturnCode = this.mReturnCode;
					return mReturnCode;
				}
				num = i;
			}
			this.mReturnCode = BehaviourReturnCode.Success;
			mReturnCode = this.mReturnCode;
			return mReturnCode;
		}
	}
}
