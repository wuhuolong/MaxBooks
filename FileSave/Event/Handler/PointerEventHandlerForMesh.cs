// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

using NF.Core.Event.Handler.Support;

namespace NF.Core.Event.Handler {
    internal static class PointerEventHandlerForMesh {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 事件侦听组集合
        private static List<PointerListenerGroupForMesh> ListenerGroups = new List<PointerListenerGroupForMesh>( 128 );

        // 等待添加的侦听组
        private static PointerListenerGroupForMesh WaitToAddGroup = new PointerListenerGroupForMesh();

        // 鼠标状态数据
        private static List<PointerStatusData> MouseStatusData = new List<PointerStatusData>( 128 );

        // 触屏状态数据
        private static List<PointerStatusData> TouchStatusData = new List<PointerStatusData>( 128 );

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 静态初始化
        static PointerEventHandlerForMesh() {
            for( int i = 0 ; i < 3 ; i++ ) MouseStatusData.Add( new PointerStatusData() );
        }

        // 添加侦听
        internal static void AddListener( GameObject target , Action<GameObject , PointerData , RaycastHit> listener , bool ignoreOcclusion , int priority ) {
            if( target == null ) ERROR( "Nero.ManageEvent.AddPointerListenerForMesh --- 侦听对象不能为 null" );
            if( target.transform is RectTransform ) ERROR( "Nero.ManageEvent.AddPointerListenerForMesh --- 侦听对象不是 Mesh 对象 ( target: " + target.name + " )" );
            if( target.GetComponent<Collider>() == null ) ERROR( "Nero.ManageEvent.AddPointerListenerForMesh --- 侦听对象不包含 Collider 组件 ( target: " + target.name + " ) " );
            // 重复侦听检查
            int length = ListenerGroups.Count;
            bool repeated = WaitToAddGroup.CheckRepeated( target , listener );
            if( !repeated ) {
                for( int i = 0 ; i < length ; i++ ) {
                    repeated = ListenerGroups[i].CheckRepeated( target , listener );
                    if( repeated ) break;
                }
            }
            if( repeated ) ERROR( "Nero.ManageEvent.AddPointerListenerForMesh --- 无法为单个侦听对象重复添加同一个侦听函数 ( target: " + target.name + " )" );
            // 创建侦听组
            bool needNewGroup = length == 0;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].Target == target ) break;
                if( i == length - 1 ) needNewGroup = true;
            }
            if( needNewGroup ) ListenerGroups.Add( new PointerListenerGroupForMesh() { Target = target } );
            // 加入等待添加的侦听组
            WaitToAddGroup.Add( new PointerListenerForMesh() { Target = target , Listener = listener , IgnoreOcclusion = ignoreOcclusion , Priority = priority } );
        }

        // 移除侦听
        internal static void RemoveListener( GameObject target , Action<GameObject , PointerData , RaycastHit> listener ) {
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
                    if( ListenerGroups[i].Target == null || ListenerGroups[i].ClearNullElement() == 0 ) ListenerGroups.RemoveAt( i );
                }
            }

            // 派发
            if( NeroConfig.Event.PointerInputType == PointerInputType.Mouse ) HandleMouseInput();
            if( NeroConfig.Event.PointerInputType == PointerInputType.Touch ) HandleTouchInput();

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 处理鼠标输入
        private static void HandleMouseInput() {

            // 获取当前帧碰撞列表
            MouseStatusData[0].NowHits = EventSystem.current.IsPointerOverGameObject() ?
                new RaycastHit[0] : Physics.RaycastAll( Camera.main.ScreenPointToRay( Input.mousePosition ) , NeroConfig.Event.PointerEventRaycastDistanceForMesh );

            PointerListenerGroupForMesh group;
            int nowHitsCount = MouseStatusData[0].NowHits.Length;
            int prevHitsCount = MouseStatusData[0].PrevHits.Length;

            // 初始化指针事件数据
            PointerData pointerData = new PointerData() {
                InputType = PointerInputType.Mouse ,
                X = (int)Input.mousePosition.x ,
                Y = (int)Input.mousePosition.y
            };

            // 获取当前帧焦点目标
            MouseStatusData[0].NowFocus = FindFocusObjectByDistance( MouseStatusData[0].NowHits );

            // 更新事件组碰撞数据
            UpdateListenerGroupHitData( pointerData , MouseStatusData[0] );

            // 判断按下
            for( int i = 0 ; i < 3 ; i++ ) {
                if( Input.GetMouseButtonDown( i ) ) {
                    MouseStatusData[i].IsDown = true;
                    for( int j = 0 ; j < nowHitsCount ; j++ ) {
                        group = FindGroupByGameObject( MouseStatusData[0].NowHits[j].collider.gameObject );
                        if( group != null ) {
                            // 派发 Down 事件
                            pointerData.PointerID = -i - 1;
                            pointerData.EventType = PointerEventType.Down;
                            group.DispatchAll( pointerData , group.Target == MouseStatusData[0].NowFocus , false );
                            // 添加 Drag 状态
                            group.DragStatus.Add( new PointerDragStatusForMesh() {
                                PointerID = pointerData.PointerID ,
                                BeginDragHasFocus = group.Target == MouseStatusData[0].NowFocus ,
                                PrevX = pointerData.X ,
                                PrevY = pointerData.Y
                            } );
                        }
                        // 记录按下的对象以及按下时是否拥有焦点
                        MouseStatusData[i].PrevDownObjects.Add( MouseStatusData[0].NowHits[j].collider.gameObject );
                        MouseStatusData[i].PrevDownObjectsFocusStatus.Add( group == null ? false : group.Target == MouseStatusData[0].NowFocus );
                    }
                }
            }

            // 判断松开
            for( int i = 0 ; i < 3 ; i++ ) {
                if( !Input.GetMouseButton( i ) && MouseStatusData[i].IsDown ) { // 解决程序在非焦点状态下松开鼠标
                    MouseStatusData[i].IsDown = false;
                    int length = MouseStatusData[i].PrevDownObjects.Count;
                    for( int j = 0 ; j < length ; j++ ) {
                        group = FindGroupByGameObject( MouseStatusData[i].PrevDownObjects[j] );
                        if( group != null ) {
                            // 派发 Up 事件
                            pointerData.PointerID = -i - 1;
                            pointerData.EventType = PointerEventType.Up;
                            group.DispatchAll( pointerData , MouseStatusData[i].PrevDownObjectsFocusStatus[j] , false );
                            // 派发 Click 事件
                            for( int k = 0 ; k < nowHitsCount ; k++ ) {
                                if( group.Target == MouseStatusData[0].NowHits[k].collider.gameObject ) {
                                    pointerData.EventType = PointerEventType.Click;
                                    group.DispatchAll( pointerData , group.Target == MouseStatusData[0].NowFocus , false );
                                    break;
                                }
                            }
                            // 移除 Drag 状态
                            int dragCount = group.DragStatus.Count;
                            for( int k = dragCount - 1 ; k >= 0 ; k-- ) {
                                if( group.DragStatus[k].PointerID == pointerData.PointerID ) {
                                    group.DragStatus.RemoveAt( k );
                                    break;
                                }
                            }
                        }
                    }
                    // 移除所有被记录按下的对象以及按下时是否拥有焦点
                    MouseStatusData[i].PrevDownObjects.Clear();
                    MouseStatusData[i].PrevDownObjectsFocusStatus.Clear();
                }
            }

            // 判断滑入和滑出并缓存当前帧数据
            pointerData.PointerID = -1;
            CheckEnterAndExit( pointerData , MouseStatusData[0] );

        }

        // 处理触屏输入
        private static void HandleTouchInput() {
            int touchesCount = Input.touches.Length;
            for( int s = 0 ; s < touchesCount ; s++ ) {

                // 获取触屏状态缓存索引
                int index = -1;
                int touchID = Input.touches[s].fingerId;
                if( Input.touches[s].phase == TouchPhase.Began ) {
                    TouchStatusData.Add( new PointerStatusData() { PointerID = touchID } );
                    index = TouchStatusData.Count - 1;
                } else {
                    int length = TouchStatusData.Count;
                    for( int i = 0 ; i < length ; i++ ) {
                        if( TouchStatusData[i].PointerID == touchID ) {
                            index = i;
                            break;
                        }
                    }
                }

                // 获取当前帧碰撞列表
                TouchStatusData[index].NowHits = new RaycastHit[0];
                if( !EventSystem.current.IsPointerOverGameObject( touchID ) && Input.touches[s].phase != TouchPhase.Ended && Input.touches[s].phase != TouchPhase.Canceled ) {
                    TouchStatusData[index].NowHits = Physics.RaycastAll( Camera.main.ScreenPointToRay( Input.touches[s].position ) , NeroConfig.Event.PointerEventRaycastDistanceForMesh );
                }

                PointerListenerGroupForMesh group;
                int nowHitsCount = TouchStatusData[index].NowHits.Length;
                int prevHitsCount = TouchStatusData[index].PrevHits.Length;

                // 初始化指针事件数据
                PointerData pointerData = new PointerData() {
                    InputType = PointerInputType.Touch ,
                    PointerID = touchID ,
                    X = (int)Input.touches[s].position.x ,
                    Y = (int)Input.touches[s].position.y
                };

                // 获取当前帧焦点目标
                TouchStatusData[index].NowFocus = FindFocusObjectByDistance( TouchStatusData[index].NowHits );

                // 更新事件组碰撞数据
                UpdateListenerGroupHitData( pointerData , TouchStatusData[index] );

                // 判断按下
                if( Input.touches[s].phase == TouchPhase.Began ) {
                    for( int i = 0 ; i < nowHitsCount ; i++ ) {
                        group = FindGroupByGameObject( TouchStatusData[index].NowHits[i].collider.gameObject );
                        if( group != null ) {
                            // 派发 Down 事件
                            pointerData.EventType = PointerEventType.Down;
                            group.DispatchAll( pointerData , group.Target == TouchStatusData[index].NowFocus , false );
                            // 添加 Drag 状态
                            group.DragStatus.Add( new PointerDragStatusForMesh() {
                                BeginDragHasFocus = group.Target == TouchStatusData[index].NowFocus ,
                                PrevX = pointerData.X ,
                                PrevY = pointerData.Y
                            } );
                        }
                        // 记录按下的对象以及按下时是否拥有焦点
                        TouchStatusData[index].PrevDownObjects.Add( TouchStatusData[index].NowHits[i].collider.gameObject );
                        TouchStatusData[index].PrevDownObjectsFocusStatus.Add( group == null ? false : group.Target == TouchStatusData[index].NowFocus );
                    }
                }

                // 判断松开
                if( Input.touches[s].phase == TouchPhase.Ended || Input.touches[s].phase == TouchPhase.Canceled ) {
                    int length = TouchStatusData[index].PrevDownObjects.Count;
                    for( int i = 0 ; i < length ; i++ ) {
                        group = FindGroupByGameObject( TouchStatusData[index].PrevDownObjects[i] );
                        if( group != null ) {
                            // 派发 Up 事件
                            pointerData.EventType = PointerEventType.Up;
                            group.DispatchAll( pointerData , TouchStatusData[index].PrevDownObjectsFocusStatus[i] , false );
                            // 派发 Click 事件
                            for( int j = 0 ; j < nowHitsCount ; j++ ) {
                                if( group.Target == TouchStatusData[index].NowHits[j].collider.gameObject ) {
                                    pointerData.EventType = PointerEventType.Click;
                                    group.DispatchAll( pointerData , group.Target == TouchStatusData[index].NowFocus , false );
                                    break;
                                }
                            }
                            // 移除 Drag 状态
                            int dragCount = group.DragStatus.Count;
                            for( int j = dragCount - 1 ; j >= 0 ; j-- ) {
                                if( group.DragStatus[j].PointerID == pointerData.PointerID ) {
                                    group.DragStatus.RemoveAt( j );
                                    break;
                                }
                            }
                        }
                    }
                }

                // 判断滑入和滑出并缓存当前帧数据
                CheckEnterAndExit( pointerData , TouchStatusData[index] );

                // 移除结束的触屏状态数据
                if( Input.touches[s].phase == TouchPhase.Ended || Input.touches[s].phase == TouchPhase.Canceled ) TouchStatusData.RemoveAt( index );

            }
        }

        // 更新事件组碰撞数据 ( 鼠标与触屏共用 )
        private static void UpdateListenerGroupHitData( PointerData pointerData , PointerStatusData statusData ) {

            int nowHitsCount = statusData.NowHits.Length;
            int groupCount = ListenerGroups.Count;
            for( int i = 0 ; i < groupCount ; i++ ) {
                if( ListenerGroups[i].Target != null ) {
                    for( int j = 0 ; j < nowHitsCount ; j++ ) {
                        if( ListenerGroups[i].Target == statusData.NowHits[j].collider.gameObject ) {
                            // 判断是否要派发 Cover 事件并更新碰撞数据
                            bool dispatchCover = false;
                            if( pointerData.InputType == PointerInputType.Mouse ) {
                                dispatchCover = ListenerGroups[i].MouseRaycastHit.point != statusData.NowHits[j].point;
                                pointerData.PointerID = -1;
                                ListenerGroups[i].MouseRaycastHit = statusData.NowHits[j];
                            } else if( pointerData.InputType == PointerInputType.Touch ) {
                                dispatchCover = ListenerGroups[i].TouchRaycastHits[pointerData.PointerID].point != statusData.NowHits[j].point;
                                ListenerGroups[i].TouchRaycastHits[pointerData.PointerID] = statusData.NowHits[j];
                            }
                            // 派发 Cover 事件
                            if( dispatchCover ) {
                                pointerData.EventType = PointerEventType.Cover;
                                ListenerGroups[i].DispatchAll( pointerData , ListenerGroups[i].Target == statusData.NowFocus , false );
                            }
                            break;
                        }
                    }
                    // 派发 Drag 事件
                    int dragCount = ListenerGroups[i].DragStatus.Count;
                    for( int j = 0 ; j < dragCount ; j++ ) {
                        if( ListenerGroups[i].DragStatus[j].PrevX != pointerData.X || ListenerGroups[i].DragStatus[j].PrevY != pointerData.Y ) {
                            ListenerGroups[i].DragStatus[j].PrevX = pointerData.X;
                            ListenerGroups[i].DragStatus[j].PrevY = pointerData.Y;
                            pointerData.PointerID = ListenerGroups[i].DragStatus[j].PointerID;
                            pointerData.EventType = PointerEventType.Drag;
                            ListenerGroups[i].DispatchAll( pointerData , ListenerGroups[i].DragStatus[j].BeginDragHasFocus , false );
                        }
                    }
                }
            }

        }

        // 判断滑入滑出事件 ( 鼠标与触屏共用 )
        private static void CheckEnterAndExit( PointerData pointerData , PointerStatusData statusData ) {

            PointerListenerGroupForMesh group;
            int nowHitsCount = statusData.NowHits.Length;
            int prevHitsCount = statusData.PrevHits.Length;

            // 判断滑入
            bool enter = false;
            for( int i = 0 ; i < nowHitsCount ; i++ ) {
                enter = true;
                for( int j = 0 ; j < prevHitsCount ; j++ ) {
                    if( statusData.NowHits[i].collider == statusData.PrevHits[j].collider ) {
                        enter = false;
                        break;
                    }
                }
                if( enter ) {
                    group = FindGroupByGameObject( statusData.NowHits[i].collider.gameObject );
                    if( group != null ) {
                        // 派发 Enter 事件
                        pointerData.EventType = PointerEventType.Enter;
                        group.DispatchAll( pointerData , group.Target == statusData.NowFocus , false );
                    }
                }
            }

            // 判断滑出
            bool exit = false;
            for( int i = 0 ; i < prevHitsCount ; i++ ) {
                exit = true;
                for( int j = 0 ; j < nowHitsCount ; j++ ) {
                    if( statusData.PrevHits[i].collider == statusData.NowHits[j].collider ) {
                        exit = false;
                        break;
                    }
                }
                if( exit ) {
                    if( statusData.PrevHits[i].collider != null ) { // 上一帧数据可能被释放，需要 null 判断
                        group = FindGroupByGameObject( statusData.PrevHits[i].collider.gameObject );
                        if( group != null ) {
                            // 派发 Exit 事件
                            pointerData.EventType = PointerEventType.Exit;
                            group.DispatchAll( pointerData , group.Target == statusData.PrevFocus , false );
                        }
                    }
                }
            }

            // 判断因焦点改变而产生的滑入和滑出事件
            if( !enter && !exit && statusData.PrevFocus != statusData.NowFocus ) {
                group = FindGroupByGameObject( statusData.NowFocus );
                if( group != null ) {
                    // 派发 Enter 事件
                    pointerData.EventType = PointerEventType.Enter;
                    group.DispatchAll( pointerData , true , true );

                }
                group = FindGroupByGameObject( statusData.PrevFocus );
                if( group != null ) {
                    // 派发 Exit 事件
                    pointerData.EventType = PointerEventType.Exit;
                    group.DispatchAll( pointerData , true , true );
                }
            }

            // 缓存当前帧数据
            statusData.PrevHits = statusData.NowHits;
            statusData.PrevFocus = statusData.NowFocus;

        }

        // 根据距离获得焦点对象
        private static GameObject FindFocusObjectByDistance( RaycastHit[] raycastHits ) {
            GameObject NowFocus = null;
            float minDistance = float.MaxValue;
            int length = raycastHits.Length;
            for( int i = 0 ; i < length ; i++ ) {
                if( raycastHits[i].distance <= minDistance ) {
                    minDistance = raycastHits[i].distance;
                    NowFocus = raycastHits[i].collider.gameObject;
                }
            }
            return NowFocus;
        }

        // 根据侦听对象查找事件组
        private static PointerListenerGroupForMesh FindGroupByGameObject( GameObject target ) {
            if( target == null ) return null;
            int length = ListenerGroups.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( ListenerGroups[i].Target == target ) return ListenerGroups[i];
            }
            return null;
        }

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //