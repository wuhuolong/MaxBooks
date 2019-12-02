// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

using NF.Core.Event.Handler.Support;
using NF.Utils.Trace.Handler;

namespace NF.Core.Event.Handler {
    internal static class TraceEventHandler {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 事件侦听组
        private static TraceListenerGroup ListenerGroup = new TraceListenerGroup();

        // 等待添加的侦听组
        private static TraceListenerGroup WaitToAddGroup = new TraceListenerGroup();

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 添加侦听
        internal static void AddListener( Action<TraceData> listener , int priority ) {
            if( ListenerGroup.CheckRepeated( listener ) || WaitToAddGroup.CheckRepeated( listener ) ) {
                ERROR( "Nero.ManageEvent.AddTraceListener --- 该类型事件无法重复添加同一个侦听函数" );
            }
            WaitToAddGroup.Add( new TraceListener() { Listener = listener , Priority = priority } );
        }

        // 移除侦听
        internal static void RemoveListener( Action<TraceData> listener ) {
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
            if( ListenerGroup.Count > 0 ) {
                List<TraceData> traceDatas = TraceHandler.GetTraceDatas();
                if( traceDatas != null ) {
                    length = traceDatas.Count;
                    for( int i = 0 ; i < length ; i++ ) ListenerGroup.DispatchAll( traceDatas[i] );
                }
            }

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //