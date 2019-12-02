// --- NEROKING.COM ----------------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class CollisionEventDispatcher : MonoBehaviour {

        // --- Field & Property ----------------------------------------------------------------------------------------------------------------------------------------------------- //

        // 绑定的碰撞事件组
        internal CollisionListenerGroup ListenerGroupBinding { get; set; }

        // --- Public & Protected Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // --- Internal Function ---------------------------------------------------------------------------------------------------------------------------------------------------- //

        // --- Private Function ----------------------------------------------------------------------------------------------------------------------------------------------------- //

        // 开始碰撞
        private void OnCollisionEnter( Collision collision ) =>
            ListenerGroupBinding.CollisionEventCache.Add( new CollisionEvent() { EventType = CollisionEventType.Enter , CollisionData = collision } );

        // 结束碰撞
        private void OnCollisionExit( Collision collision ) =>
            ListenerGroupBinding.CollisionEventCache.Add( new CollisionEvent() { EventType = CollisionEventType.Exit , CollisionData = collision } );

        // 保持碰撞
        private void OnCollisionStay( Collision collision ) =>
            ListenerGroupBinding.CollisionEventCache.Add( new CollisionEvent() { EventType = CollisionEventType.Stay , CollisionData = collision } );

    }
}

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
