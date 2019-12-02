using System;
using System.Collections;

namespace BehaviourTree
{
	public abstract class BehaviourNode
	{
		protected IBehaviourEmployee mEmployee;

		protected BehaviourReturnCode mReturnCode = BehaviourReturnCode.Success;

		public string Comment
		{
			get;
			set;
		}

		public BehaviourNode(IBehaviourEmployee employee)
		{
			this.mEmployee = employee;
		}

		public static BehaviourNode CreateNode(Hashtable options, IBehaviourEmployee employee)
		{
			bool flag = options == null;
			BehaviourNode result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string text = options.get_Item("type") as string;
				string comment = options.get_Item("comment") as string;
				bool flag2 = text == "Sequence";
				BehaviourNode behaviourNode;
				if (flag2)
				{
					behaviourNode = new BehaviourSequenceNode(options, employee);
				}
				else
				{
					bool flag3 = text == "Selector";
					if (flag3)
					{
						behaviourNode = new BehaviourSelectorNode(options, employee);
					}
					else
					{
						bool flag4 = text == "Action";
						if (flag4)
						{
							behaviourNode = new BehaviourActionNode(options, employee);
						}
						else
						{
							bool flag5 = text == "Conditional";
							if (flag5)
							{
								behaviourNode = new BehaviourConditionalNode(options, employee);
							}
							else
							{
								bool flag6 = text == "Inverter";
								if (flag6)
								{
									behaviourNode = new BehaviourInverterNode(options, employee);
								}
								else
								{
									bool flag7 = text == "Random";
									if (!flag7)
									{
										result = null;
										return result;
									}
									behaviourNode = new BehaviourRandomNode(options, employee);
								}
							}
						}
					}
				}
				bool flag8 = behaviourNode != null;
				if (flag8)
				{
					behaviourNode.Comment = comment;
				}
				result = behaviourNode;
			}
			return result;
		}

		public abstract void Reset(IBehaviourEmployee employee);

		public abstract BehaviourReturnCode Run();
	}
}
