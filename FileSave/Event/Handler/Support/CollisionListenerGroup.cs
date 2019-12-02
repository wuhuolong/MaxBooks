// --- NEROKING.COM ----------------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class CollisionListenerGroup : BaseListenerGroup<CollisionListener> {

        // --- Field & Property ----------------------------------------------------------------------------------------------------------------------------------------------------- //

        // 侦听对象
        internal GameObject Target { get; set; }

        // 碰撞事件缓存列表
        internal List<CollisionEvent> CollisionEventCache { get; set; } = new List<CollisionEvent>( 128 );

        // --- Public & Protected Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // --- Internal Function ---------------------------------------------------------------------------------------------------------------------------------------------------- //

        // 检查重复侦听
        internal bool CheckRepeated( GameObject target , Action<GameObject , CollisionEventType , Collision> listener , bool killRepeated = false ) {
            int length = Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( this[i] != null && this[i].Target == target && this[i].Listener == listener ) {
                    if( killRepeated ) this[i] = null;
                    return true;
                }
            }
            return false;
        }

        // --- Private Function ----------------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
