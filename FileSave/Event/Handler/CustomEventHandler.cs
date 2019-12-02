// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

using NF.Core.Event.Handler.Support;

namespace NF.Core.Event.Handler {
    internal static class CustomEventHandler {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        // 事件侦听组集合
        private static List<CustomEventListenerGroup> ListenerGroups = new List<CustomEventListenerGroup>( 128 );

        // 等待添加的侦听组
        private static CustomEventListenerGroup WaitToAddGroup = new CustomEventListenerGroup();

        // 自定义事件缓存
        private static List<CustomEvent> CustomEventCache = new List<CustomEvent>( 128 );

        // --- Public & Protected Function ------------------------------------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- //

        // 添加侦听
        internal static void AddListener( string customEventType , Action<object> listener , bool autoRemove , int priority ) {
            byte[] eventType = customEventType.Replace( " " , "" ).ToUpper().ToBytes();
            // 重复侦听检查
            int length = ListenerGroups.Count;
            bool repeated = WaitToAddGroup.CheckRepeated( eventType , listener );
            if( !repeated ) {
                for( int i = 0 ; i < length ; i++ ) {
                    repeated = ListenerGroups[i].CheckRepeated( eventType , listener );
                    if( repeated ) break;
                }
            }
            if( repeated ) ERROR( "Nero.ManageEvent.AddCustomEventListener --- 无法为单个自定义事件重复添加同一个侦听函数 ( customEventType: " + customEventType + " ) " );
            // 创建侦听组
            bool needNewGroup = length == 0;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].EventType.Compare( eventType ) ) break;
                if( i == length - 1 ) needNewGroup = true;
            }
            if( needNewGroup ) ListenerGroups.Add( new CustomEventListenerGroup() { EventType = eventType } );
            // 加入等待添加的侦听组
            WaitToAddGroup.Add( new CustomEventListener() { EventType = eventType , Listener = listener , AutoRemove = autoRemove , Priority = priority } );
        }

        // 移除侦听
        internal static void RemoveListener( string customEventType , Action<object> listener ) {
            byte[] eventType = customEventType.Replace( " " , "" ).ToUpper().ToBytes();
            if( WaitToAddGroup.CheckRepeated( eventType , listener , true ) ) return;
            int length = ListenerGroups.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].CheckRepeated( eventType , listener , true ) ) return;
            }
        }

        // 派发自定义事件
        internal static void DispatchEvent( string customEventType , object data ) =>
            CustomEventCache.Add( new CustomEvent() { EventType = customEventType.Replace( " " , "" ).ToUpper().ToBytes() , Data = data } );

        // 主线程循环
        internal static void MainThreadUpdate() {

            // 添加
            int length = WaitToAddGroup.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( WaitToAddGroup[0] != null ) {
                    int groupCount = ListenerGroups.Count;
                    for( int j = 0 ; j < groupCount ; j++ ) {
                        if( ListenerGroups[j].EventType.Compare( WaitToAddGroup[0].EventType ) ) {
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
            length = CustomEventCache.Count;
            for( int i = 0 ; i < length ; i++ ) {
                int groupCount = ListenerGroups.Count;
                for( int j = 0 ; j < groupCount ; j++ ) {
                    if( ListenerGroups[j].EventType.Compare( CustomEventCache[0].EventType ) ) {
                        ListenerGroups[j].DispatchAll( CustomEventCache[0].Data );
                        break;
                    }
                }
                CustomEventCache.RemoveAt( 0 );
            }

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

    }
}

// ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
