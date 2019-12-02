// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

using NF.Core.Event.Handler.Support;

namespace NF.Core.Event.Handler {
    internal static class PointerEventHandlerForUI {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 事件侦听组集合
        private static List<PointerListenerGroupForUI> ListenerGroups = new List<PointerListenerGroupForUI>( 128 );

        // 等待添加的侦听组
        private static PointerListenerGroupForUI WaitToAddGroup = new PointerListenerGroupForUI();

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 添加侦听
        internal static void AddListener( GameObject target , Action<GameObject , PointerData> listener , int priority ) {
            if( target == null ) ERROR( "Nero.ManageEvent.AddPointerListenerForUI --- 侦听对象不能为 null" );
            if( !( target.transform is RectTransform ) ) ERROR( "Nero.ManageEvent.AddPointerListenerForUI --- 侦听对象不是 UGUI 对象 ( target: " + target.name + " )" );
            // 重复侦听检查
            int length = ListenerGroups.Count;
            bool repeated = WaitToAddGroup.CheckRepeated( target , listener );
            if( !repeated ) {
                for( int i = 0 ; i < length ; i++ ) {
                    repeated = ListenerGroups[i].CheckRepeated( target , listener );
                    if( repeated ) break;
                }
            }
            if( repeated ) ERROR( "Nero.ManageEvent.AddPointerListenerForUI --- 无法为单个侦听对象重复添加同一个侦听函数 ( target: " + target.name + " )" );
            // 创建侦听组，绑定触发组件
            bool needNewGroup = length == 0;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].Target == target ) break;
                if( i == length - 1 ) needNewGroup = true;
            }
            if( needNewGroup ) {
                ListenerGroups.Add( new PointerListenerGroupForUI() { Target = target } );
                if( target.GetComponent<EventTrigger>() == null ) {
                    EventTrigger eventTrigger = target.AddComponent<EventTrigger>();
                    eventTrigger.triggers.Add( new EventTrigger.Entry() { eventID = EventTriggerType.PointerEnter , callback = new EventTrigger.TriggerEvent() } );
                    eventTrigger.triggers.Add( new EventTrigger.Entry() { eventID = EventTriggerType.PointerExit , callback = new EventTrigger.TriggerEvent() } );
                    eventTrigger.triggers.Add( new EventTrigger.Entry() { eventID = EventTriggerType.PointerDown , callback = new EventTrigger.TriggerEvent() } );
                    eventTrigger.triggers.Add( new EventTrigger.Entry() { eventID = EventTriggerType.PointerUp , callback = new EventTrigger.TriggerEvent() } );
                    eventTrigger.triggers.Add( new EventTrigger.Entry() { eventID = EventTriggerType.PointerClick , callback = new EventTrigger.TriggerEvent() } );
                    eventTrigger.triggers.Add( new EventTrigger.Entry() { eventID = EventTriggerType.Drag , callback = new EventTrigger.TriggerEvent() } );
                    eventTrigger.triggers[0].callback.AddListener( ListenerGroups[ListenerGroups.Count - 1].OnEnter );
                    eventTrigger.triggers[1].callback.AddListener( ListenerGroups[ListenerGroups.Count - 1].OnExit );
                    eventTrigger.triggers[2].callback.AddListener( ListenerGroups[ListenerGroups.Count - 1].OnDown );
                    eventTrigger.triggers[3].callback.AddListener( ListenerGroups[ListenerGroups.Count - 1].OnUp );
                    eventTrigger.triggers[4].callback.AddListener( ListenerGroups[ListenerGroups.Count - 1].OnClick );
                    eventTrigger.triggers[5].callback.AddListener( ListenerGroups[ListenerGroups.Count - 1].OnDrag );
                }
            }
            // 加入等待添加的侦听组
            WaitToAddGroup.Add( new PointerListenerForUI() { Target = target , Listener = listener , Priority = priority } );
        }

        // 移除侦听
        internal static void RemoveListener( GameObject target , Action<GameObject , PointerData> listener ) {
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
                        ListenerGroups[i].Target.GetComponent<EventTrigger>().Dispose();
                        ListenerGroups.RemoveAt( i );
                    }
                }
            }

            // 派发
            length = ListenerGroups.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].Target != null ) {
                    ListenerGroups[i].CheckCoverStatus(); // 检查 Cover 状态
                    int eventCount = ListenerGroups[i].PointerEventCache.Count;
                    for( int j = 0 ; j < eventCount ; j++ ) {
                        ListenerGroups[i].DispatchAll( ListenerGroups[i].Target , ListenerGroups[i].PointerEventCache[0] );
                        ListenerGroups[i].PointerEventCache.RemoveAt( 0 );
                    }
                }
            }

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //