// --- NEROKING.COM ----------------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class CustomEventListenerGroup : BaseListenerGroup<CustomEventListener> {

        // --- Field & Property ----------------------------------------------------------------------------------------------------------------------------------------------------- //

        // 自定义事件类型
        internal byte[] EventType { get; set; }

        // --- Public & Protected Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // --- Internal Function ---------------------------------------------------------------------------------------------------------------------------------------------------- //

        // 检查重复侦听
        internal bool CheckRepeated( byte[] eventType , Action<object> listener , bool killRepeated = false ) {
            int length = Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( this[i] != null && this[i].EventType.Compare( eventType ) && this[i].Listener == listener ) {
                    if( killRepeated ) this[i] = null;
                    return true;
                }
            }
            return false;
        }

        // 派发事件至所有侦听 ( 重写 )
        internal override void DispatchAll( params object[] args ) {
            int length = Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( this[i] != null ) {
                    this[i].Dispatch( args[0] );
                    // 实现自动移除侦听 ( 派发后操作侦听必须加入 null 判断 )
                    if( this[i] != null && this[i].AutoRemove ) this[i] = null;
                }
            }
        }

        // --- Private Function ----------------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
