// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class TriggerEventDispatcher : MonoBehaviour {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 绑定的触发器事件组
        internal TriggerListenerGroup ListenerGroupBinding { get; set; }

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 开始触发器
        private void OnTriggerEnter( Collider collider ) =>
            ListenerGroupBinding.TriggerEventCache.Add( new TriggerEvent() { EventType = TriggerEventType.Enter , ActiveTarget = collider.gameObject } );

        // 结束触发器
        private void OnTriggerExit( Collider collider ) =>
            ListenerGroupBinding.TriggerEventCache.Add( new TriggerEvent() { EventType = TriggerEventType.Exit , ActiveTarget = collider.gameObject } );

        // 保持触发器
        private void OnTriggerStay( Collider collider ) =>
            ListenerGroupBinding.TriggerEventCache.Add( new TriggerEvent() { EventType = TriggerEventType.Stay , ActiveTarget = collider.gameObject } );

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //
