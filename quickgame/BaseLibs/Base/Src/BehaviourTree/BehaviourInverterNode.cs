using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
    public class BehaviourInverterNode : BehaviourNode
    {
        private BehaviourNode mChild;

        public BehaviourInverterNode(Hashtable options, IBehaviourEmployee employee)
            : base(employee)
        {
            Hashtable table = options["child"] as Hashtable;

            mChild = BehaviourNode.CreateNode(table, employee);
        }

        public override void Reset(IBehaviourEmployee employee)
        {
            base.mEmployee = employee;
            
            if(mChild != null)
            {
                mChild.Reset(employee);
            }
        }

        public override BehaviourReturnCode Run()
        {
            switch (mChild.Run())
            {
                case BehaviourReturnCode.Failure:
                    return BehaviourReturnCode.Success;
                case BehaviourReturnCode.Success:
                    return BehaviourReturnCode.Failure;
                case BehaviourReturnCode.Running:
                    return BehaviourReturnCode.Running;
            }

            return BehaviourReturnCode.Success;
        }
    }
}
