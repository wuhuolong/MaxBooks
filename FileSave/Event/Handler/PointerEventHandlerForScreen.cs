// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

using NF.Core.Event.Handler.Support;

namespace NF.Core.Event.Handler {
    internal static class PointerEventHandlerForScreen {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 事件侦听组
        private static PointerListenerGroupForScreen ListenerGroup = new PointerListenerGroupForScreen();

        // 等待添加的侦听组
        private static PointerListenerGroupForScreen WaitToAddGroup = new PointerListenerGroupForScreen();

        // 鼠标状态数据
        private static List<PointerStatusData> MouseStatusData = new List<PointerStatusData>( 128 );

        // 触屏状态数据
        private static List<PointerStatusData> TouchStatusData = new List<PointerStatusData>( 128 );

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 静态初始化
        static PointerEventHandlerForScreen() {
            for( int i = 0 ; i < 3 ; i++ ) MouseStatusData.Add( new PointerStatusData() );
            for( int i = 0 ; i < 20 ; i++ ) TouchStatusData.Add( new PointerStatusData() );
        }

        // 添加侦听
        internal static void AddListener( Action<PointerData> listener , int priority ) {
            if( ListenerGroup.CheckRepeated( listener ) || WaitToAddGroup.CheckRepeated( listener ) ) {
                ERROR( "Nero.ManageEvent.AddPointerListenerForScreen --- 该类型事件无法重复添加同一个侦听函数" );
            }
            WaitToAddGroup.Add( new PointerListenerForScreen() { Listener = listener , Priority = priority } );
        }

        // 移除侦听
        internal static void RemoveListener( Action<PointerData> listener ) {
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
            if( NeroConfig.Event.PointerInputType == PointerInputType.Mouse ) MouseInputDispatch();
            if( NeroConfig.Event.PointerInputType == PointerInputType.Touch ) TouchInputDispatch();

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 鼠标输入派发
        private static void MouseInputDispatch() {
            MouseStatusData[0].NowX = (int)Input.mousePosition.x;
            MouseStatusData[0].NowY = (int)Input.mousePosition.y;
            for( int i = 0 ; i < 3 ; i++ ) {
                if( Input.GetMouseButtonDown( i ) && !EventSystem.current.IsPointerOverGameObject() ) {
                    // 按下
                    MouseStatusData[i].IsDown = true;
                    ListenerGroup.DispatchAll( new PointerData() {
                        InputType = PointerInputType.Mouse ,
                        EventType = PointerEventType.Down ,
                        PointerID = -i - 1 , X = MouseStatusData[0].NowX , Y = MouseStatusData[0].NowY
                    } );
                } else if( MouseStatusData[i].IsDown ) {
                    if( !Input.GetMouseButtonUp( i ) && NeroDriver.HasFocus ) {
                        // 拖拽
                        if( MouseStatusData[i].PrevX != MouseStatusData[0].NowX || MouseStatusData[i].PrevY != MouseStatusData[0].NowY ) {
                            ListenerGroup.DispatchAll( new PointerData() {
                                InputType = PointerInputType.Mouse ,
                                EventType = PointerEventType.Drag ,
                                PointerID = -i - 1 , X = MouseStatusData[0].NowX , Y = MouseStatusData[0].NowY
                            } );
                        }
                    } else {
                        // 松开
                        MouseStatusData[i].IsDown = false;
                        ListenerGroup.DispatchAll( new PointerData() {
                            InputType = PointerInputType.Mouse ,
                            EventType = PointerEventType.Up ,
                            PointerID = -i - 1 , X = MouseStatusData[0].NowX , Y = MouseStatusData[0].NowY
                        } );
                    }
                }
                MouseStatusData[i].PrevX = MouseStatusData[0].NowX;
                MouseStatusData[i].PrevY = MouseStatusData[0].NowY;
            }
        }

        // 触屏输入派发
        private static void TouchInputDispatch() {
            int touchesCount = Input.touches.Length;
            for( int i = 0 ; i < touchesCount ; i++ ) {
                int touchID = Input.touches[i].fingerId;
                TouchStatusData[touchID].NowX = (int)Input.touches[i].position.x;
                TouchStatusData[touchID].NowY = (int)Input.touches[i].position.y;
                if( Input.touches[i].phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject( touchID ) ) {
                    // 按下
                    TouchStatusData[touchID].IsDown = true;
                    ListenerGroup.DispatchAll( new PointerData() {
                        InputType = PointerInputType.Touch ,
                        EventType = PointerEventType.Down ,
                        PointerID = touchID , X = TouchStatusData[touchID].NowX , Y = TouchStatusData[touchID].NowY
                    } );
                } else if( TouchStatusData[touchID].IsDown ) {
                    if( !( Input.touches[i].phase == TouchPhase.Ended || Input.touches[i].phase == TouchPhase.Canceled ) && NeroDriver.HasFocus ) {
                        // 拖拽
                        if( TouchStatusData[touchID].PrevX != TouchStatusData[touchID].NowX || TouchStatusData[touchID].PrevY != TouchStatusData[touchID].NowY ) {
                            ListenerGroup.DispatchAll( new PointerData() {
                                InputType = PointerInputType.Touch ,
                                EventType = PointerEventType.Drag ,
                                PointerID = touchID , X = TouchStatusData[touchID].NowX , Y = TouchStatusData[touchID].NowY
                            } );
                        }
                    } else {
                        // 松开
                        TouchStatusData[touchID].IsDown = false;
                        ListenerGroup.DispatchAll( new PointerData() {
                            InputType = PointerInputType.Touch ,
                            EventType = PointerEventType.Up ,
                            PointerID = touchID , X = TouchStatusData[touchID].NowX , Y = TouchStatusData[touchID].NowY
                        } );
                    }
                }
                TouchStatusData[touchID].PrevX = TouchStatusData[touchID].NowX;
                TouchStatusData[touchID].PrevY = TouchStatusData[touchID].NowY;
            }
        }

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //