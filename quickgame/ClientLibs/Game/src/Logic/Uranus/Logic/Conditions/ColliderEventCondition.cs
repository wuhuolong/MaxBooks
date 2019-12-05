using System;
using System.Collections.Generic;
using Neptune;
using xc.Dungeon;
using xc;
using UnityEngine;
using FullSerializer;

namespace Uranus.Runtime
{
    public enum ColliderEventType : byte
    {
        NONE = 0,
        ENTER = 1,
        STAY = 1 << 1,
        EXIT = 1 << 2
    }

    /// <summary>
    /// Toggle Condition
    /// </summary>
    [Serializable]
    public class ColliderEventCondition : ICondition
    {
        public int ColliderId;

        /// <summary>
        /// 目标事件类型
        /// </summary>
        public ColliderEventType EventType;

        /// <summary>
        /// 实际上触发了的事件类型
        /// </summary>
        private ColliderEventType curEventType;

        public ColliderEventCondition()
        {
            curEventType = ColliderEventType.NONE;
            EventType = ColliderEventType.ENTER;
        }

        protected override void OnInit()
        {
            var behaviour = ColliderObjectManager.Instance.GetColliderObjectBehaviour(ColliderId);
            if (behaviour != null)
            {
//                 behaviour.ColliderEnterEvent += OnColliderEnterEvent;
//                 behaviour.ColliderStayEvent += OnColliderStayEvent;
//                 behaviour.ColliderExitEvent += OnColliderExitEvent;
            }
        }

        public override void OnDestroy()
        {
            var behaviour = ColliderObjectManager.Instance.GetColliderObjectBehaviour(ColliderId);
            if (behaviour != null)
            {
//                 behaviour.ColliderEnterEvent -= OnColliderEnterEvent;
//                 behaviour.ColliderStayEvent -= OnColliderStayEvent;
//                 behaviour.ColliderExitEvent -= OnColliderExitEvent;
            }
        }

        protected override bool Check()
        {
            bool bRet = false;
            if ((curEventType & EventType) > 0)
            {
                curEventType = ColliderEventType.NONE;
                bRet = true;
            }
            return bRet;
        }

        public void OnColliderEnterEvent(GameObject gameObject)
        {
            if (gameObject.name != "LocalPlayer")
                return;

            curEventType |= ColliderEventType.ENTER;
        }

        public void OnColliderStayEvent(GameObject gameObject)
        {
            if (gameObject.name != "LocalPlayer")
                return;

            curEventType |= ColliderEventType.STAY;
        }

        public void OnColliderExitEvent(GameObject gameObject)
        {
            if (gameObject.name != "LocalPlayer")
                return;

            curEventType |= ColliderEventType.EXIT;
        }
    }
}
