using System.Collections;

namespace BehaviourTree
{
    public class BehaviourRandomNode : BehaviourNode
    {
        private BehaviourNode mChild;
        private float mProbability = 1.0f;

        public BehaviourRandomNode(Hashtable options, IBehaviourEmployee employee)
            : base(employee)
        {
            Hashtable table = options["child"] as Hashtable;

            string rawProbability = options["probability"] as string;
            if (!string.IsNullOrEmpty(rawProbability))
            {
                mProbability = System.Convert.ToSingle(rawProbability);
            }
            else
            {
                mProbability = 1.0f;
            }

            mChild = BehaviourNode.CreateNode(table, employee);
        }

        public override void Reset(IBehaviourEmployee employee)
        {
            base.mEmployee = employee;

            if (mChild != null)
            {
                mChild.Reset(employee);
            }
        }

        public override BehaviourReturnCode Run()
        {
            if (UnityEngine.Random.value <= mProbability)
            {
                return mChild.Run();
            }

            return BehaviourReturnCode.Failure;
        }
    }
}
