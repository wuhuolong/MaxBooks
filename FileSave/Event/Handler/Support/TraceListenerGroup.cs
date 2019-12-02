// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class TraceListenerGroup : BaseListenerGroup<TraceListener> {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 检查重复侦听
        internal bool CheckRepeated( Action<TraceData> listener , bool killRepeated = false ) {
            int length = Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( this[i] != null && this[i].Listener == listener ) {
                    if( killRepeated ) this[i] = null;
                    return true;
                }
            }
            return false;
        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //
