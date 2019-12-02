// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

using NF.Core.Event.Handler.Support;

namespace NF.Core.Event.Handler {
    internal static class ScreenResizeEventHandler {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 屏幕尺寸缓存
        internal static Vector2 ScreenSizeCache;

        // 事件侦听组
        private static ScreenResizeListenerGroup ListenerGroup = new ScreenResizeListenerGroup();

        // 等待添加的侦听组
        private static ScreenResizeListenerGroup WaitToAddGroup = new ScreenResizeListenerGroup();

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 添加侦听
        internal static void AddListener( Action<int , int> listener , int priority ) {
            if( ListenerGroup.CheckRepeated( listener ) || WaitToAddGroup.CheckRepeated( listener ) ) {
                ERROR( "Nero.ManageEvent.AddScreenResizeListener --- 该类型事件无法重复添加同一个侦听函数" );
            }
            WaitToAddGroup.Add( new ScreenResizeListener() { Listener = listener , Priority = priority } );
        }

        // 移除侦听
        internal static void RemoveListener( Action<int , int> listener ) {
            if( !ListenerGroup.CheckRepeated( listener , true ) ) WaitToAddGroup.CheckRepeated( listener , true );
        }

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
            if( ScreenSizeCache.x != Screen.width || ScreenSizeCache.y != Screen.height ) {
                ScreenSizeCache = new Vector2( Screen.width , Screen.height );
                ListenerGroup.DispatchAll( Screen.width , Screen.height );
            }

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //