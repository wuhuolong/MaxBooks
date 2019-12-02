// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class KeyboardListenerGroup : BaseListenerGroup<KeyboardListener> {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 侦听按键键值
        internal KeyCode Key { get; set; }

        // 按键状态
        internal bool KeyIsDown { get; set; } = false;

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 检查重复侦听
        internal bool CheckRepeated( KeyCode keyCode , Action<KeyCode , KeyboardEventType> listener , bool killRepeated = false ) {
            int length = Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( this[i] != null && this[i].Key == keyCode && this[i].Listener == listener ) {
                    if( killRepeated ) this[i] = null;
                    return true;
                }
            }
            return false;
        }

        // 派发事件至所有侦听 ( 重写 )
        internal override void DispatchAll( params object[] args ) {
            if( Nero.ManageEvent.EnableAllKeyboardListener ) base.DispatchAll( args );
        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //