// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class PointerListenerForUI : BaseListener {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 侦听对象
        internal GameObject Target { get; set; }

        // 事件侦听函数
        internal Action<GameObject , PointerData> Listener { get; set; }

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 派发事件 ( 重写 )
        internal override void Dispatch( params object[] args ) => Listener.Invoke( (GameObject)args[0] , (PointerData)args[1] );

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //
