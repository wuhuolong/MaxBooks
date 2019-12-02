// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

using NF.Core.Event.Handler.Support;

namespace NF.Core.Event.Handler {
    internal static class FocusEventHandler {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        // 事件侦听组
        private static FocusListenerGroup ListenerGroup = new FocusListenerGroup();

        // 等待添加的侦听组
        private static FocusListenerGroup WaitToAddGroup = new FocusListenerGroup();

        // 程序焦点事件缓存
        private static List<bool> FocusEventCache = new List<bool>( 128 );

        // --- Public & Protected Function ------------------------------------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- //

        // 添加侦听
        internal static void AddListener( Action<bool> listener , int priority ) {
            if( ListenerGroup.CheckRepeated( listener ) || WaitToAddGroup.CheckRepeated( listener ) ) {
                ERROR( "Nero.ManageEvent.AddFocusListener --- 该类型事件无法重复添加同一个侦听函数" );
            }
            WaitToAddGroup.Add( new FocusListener() { Listener = listener , Priority = priority } );
        }

        // 移除侦听
        internal static void RemoveListener( Action<bool> listener ) {
            if( !ListenerGroup.CheckRepeated( listener , true ) ) WaitToAddGroup.CheckRepeated( listener , true );
        }

        // 派发程序焦点事件
        internal static void DispatchEvent( bool focusStatus ) => FocusEventCache.Add( focusStatus );

        // 主线程循环
        internal static void MainThreadUpdate() {

            // 添加
            int length = WaitToAddGroup.Count;
            for( int i = 0 ; i < length ; i++ ) {
                ListenerGroup.Add( WaitToAddGroup[0] );
                WaitToAddGroup.RemoveAt( 0 );
            }

            // 清理
            if( NeroDriver.NeedClear ) ListenerGroup.ClearNullElement();

            // 派发
            length = FocusEventCache.Count;
            for( int i = 0 ; i < length ; i++ ) {
                ListenerGroup.DispatchAll( FocusEventCache[0] );
                FocusEventCache.RemoveAt( 0 );
            }

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

    }
}

// ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
