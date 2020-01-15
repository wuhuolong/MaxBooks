using System;
using UnityEngine;

namespace Uranus.Runtime
{
    [Serializable]
    public class ColliderCondition : ICondition
    {
        public string OperateName;

        protected override bool Check()
        {
            return Input.GetMouseButtonDown(0);
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public override void OnDestroy()
        {

        }
    }
}
