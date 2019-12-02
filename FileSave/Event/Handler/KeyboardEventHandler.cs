// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

using NF.Core.Event.Handler.Support;

namespace NF.Core.Event.Handler {
    internal static class KeyboardEventHandler {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 事件侦听组集合
        private static List<KeyboardListenerGroup> ListenerGroups = new List<KeyboardListenerGroup>( 128 );

        // 等待添加的侦听组
        private static KeyboardListenerGroup WaitToAddGroup = new KeyboardListenerGroup();

        // 键盘按键状态缓存
        private static bool AnyKeyCache = false;

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 添加侦听
        internal static void AddListener( KeyCode keyCode , Action<KeyCode , KeyboardEventType> listener , int priority ) {
            // 重复侦听检查
            int length = ListenerGroups.Count;
            bool repeated = WaitToAddGroup.CheckRepeated( keyCode , listener );
            if( !repeated ) {
                for( int i = 0 ; i < length ; i++ ) {
                    repeated = ListenerGroups[i].CheckRepeated( keyCode , listener );
                    if( repeated ) break;
                }
            }
            if( repeated ) ERROR( "Nero.ManageEvent.AddKeyboardListener --- 无法为单个键盘按键重复添加同一个侦听函数 ( keyCode: " + keyCode + " )" );
            // 创建侦听组
            bool needNewGroup = length == 0;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].Key == keyCode ) break;
                if( i == length - 1 ) needNewGroup = true;
            }
            if( needNewGroup ) ListenerGroups.Add( new KeyboardListenerGroup() { Key = keyCode } );
            // 加入等待添加的侦听组
            WaitToAddGroup.Add( new KeyboardListener() { Key = keyCode , Listener = listener , Priority = priority } );
        }

        // 移除侦听
        internal static void RemoveListener( KeyCode keyCode , Action<KeyCode , KeyboardEventType> listener ) {
            if( WaitToAddGroup.CheckRepeated( keyCode , listener , true ) ) return;
            int length = ListenerGroups.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].CheckRepeated( keyCode , listener , true ) ) return;
            }
        }

        // 主线程循环
        internal static void MainThreadUpdate() {

            // 添加
            int length = WaitToAddGroup.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( WaitToAddGroup[0] != null ) {
                    int groupCount = ListenerGroups.Count;
                    for( int j = 0 ; j < groupCount ; j++ ) {
                        if( ListenerGroups[j].Key == WaitToAddGroup[0].Key ) {
                            ListenerGroups[j].Add( WaitToAddGroup[0] );
                            break;
                        }
                    }
                }
                WaitToAddGroup.RemoveAt( 0 );
            }

            // 清理
            if( NeroDriver.NeedClear ) {
                length = ListenerGroups.Count;
                for( int i = length - 1 ; i >= 0 ; i-- ) {
                    if( ListenerGroups[i].ClearNullElement() == 0 ) ListenerGroups.RemoveAt( i );
                }
            }

            // 派发
            if( Input.anyKey || ( !Input.anyKey && AnyKeyCache ) ) {
                AnyKeyCache = Input.anyKey;
                length = ListenerGroups.Count;
                for( int i = 0 ; i < length ; i++ ) {
                    if( ListenerGroups[i].KeyIsDown != Input.GetKey( ListenerGroups[i].Key ) ) {
                        ListenerGroups[i].KeyIsDown = !ListenerGroups[i].KeyIsDown;
                        ListenerGroups[i].DispatchAll(
                            ListenerGroups[i].Key ,
                            ListenerGroups[i].KeyIsDown ? KeyboardEventType.Down : KeyboardEventType.Up );
                    } else if( ListenerGroups[i].KeyIsDown ) {
                        ListenerGroups[i].DispatchAll( ListenerGroups[i].Key , KeyboardEventType.HoldDown );
                    }
                }
            }

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //