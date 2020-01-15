﻿// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

using NF.Core.Event.Handler.Support;

namespace NF.Core.Event.Handler {
    internal static class CollisionEventHandler {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        // 事件侦听组集合
        private static List<CollisionListenerGroup> ListenerGroups = new List<CollisionListenerGroup>( 128 );

        // 等待添加的侦听组
        private static CollisionListenerGroup WaitToAddGroup = new CollisionListenerGroup();

        // --- Public & Protected Function ------------------------------------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- //

        // 添加侦听
        internal static void AddListener( GameObject target , Action<GameObject , CollisionEventType , Collision> listener , int priority ) {
            if( target == null ) ERROR( "Nero.ManageEvent.AddCollisionListener --- 侦听对象不能为 null" );
            if( target.GetComponent<Collider>() == null ) ERROR( "Nero.ManageEvent.AddCollisionListener --- 侦听对象不包含 Collider 组件 ( target: " + target.name + " ) " );
            // 重复侦听检查
            int length = ListenerGroups.Count;
            bool repeated = WaitToAddGroup.CheckRepeated( target , listener );
            if( !repeated ) {
                for( int i = 0 ; i < length ; i++ ) {
                    repeated = ListenerGroups[i].CheckRepeated( target , listener );
                    if( repeated ) break;
                }
            }
            if( repeated ) ERROR( "Nero.ManageEvent.AddCollisionListener --- 无法为单个侦听对象重复添加同一个侦听函数 ( target: " + target.name + " )" );
            // 创建侦听组，绑定派发者组件
            bool needNewGroup = length == 0;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].Target == target ) break;
                if( i == length - 1 ) needNewGroup = true;
            }
            if( needNewGroup ) {
                ListenerGroups.Add( new CollisionListenerGroup() { Target = target } );
                if( target.GetComponent<CollisionEventDispatcher>() == null ) {
                    target.AddComponent<CollisionEventDispatcher>().ListenerGroupBinding = ListenerGroups[ListenerGroups.Count - 1];
                }
            }
            // 加入等待添加的侦听组
            WaitToAddGroup.Add( new CollisionListener() { Target = target , Listener = listener , Priority = priority } );
        }

        // 移除侦听
        internal static void RemoveListener( GameObject target , Action<GameObject , CollisionEventType , Collision> listener ) {
            if( target == null || WaitToAddGroup.CheckRepeated( target , listener , true ) ) return;
            int length = ListenerGroups.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].CheckRepeated( target , listener , true ) ) return;
            }
        }

        // 主线程循环
        internal static void MainThreadUpdate() {

            // 添加
            int length = WaitToAddGroup.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( WaitToAddGroup[0] != null && WaitToAddGroup[0].Target != null ) {
                    int groupCount = ListenerGroups.Count;
                    for( int j = 0 ; j < groupCount ; j++ ) {
                        if( ListenerGroups[j].Target == WaitToAddGroup[0].Target ) {
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
                    if( ListenerGroups[i].Target == null ) {
                        ListenerGroups.RemoveAt( i );
                    } else if( ListenerGroups[i].ClearNullElement() == 0 ) {
                        ListenerGroups[i].Target.GetComponent<CollisionEventDispatcher>().Dispose();
                        ListenerGroups.RemoveAt( i );
                    }
                }
            }

            // 派发
            length = ListenerGroups.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].Target != null ) {
                    int eventCount = ListenerGroups[i].CollisionEventCache.Count;
                    for( int j = 0 ; j < eventCount ; j++ ) {
                        ListenerGroups[i].DispatchAll(
                            ListenerGroups[i].Target ,
                            ListenerGroups[i].CollisionEventCache[0].EventType ,
                            ListenerGroups[i].CollisionEventCache[0].CollisionData );
                        ListenerGroups[i].CollisionEventCache.RemoveAt( 0 );
                    }
                }
            }

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //

    }
}

// ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //