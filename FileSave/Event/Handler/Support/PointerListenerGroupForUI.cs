// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class PointerListenerGroupForUI : BaseListenerGroup<PointerListenerForUI> {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 侦听对象
        internal GameObject Target { get; set; }

        // 指针事件缓存列表
        internal List<PointerData> PointerEventCache { get; set; } = new List<PointerData>( 128 );

        // 指针滑过状态组
        internal List<PointerCoverStatusForUI> CoverStatus { get; set; } = new List<PointerCoverStatusForUI>( 128 );

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 检查重复侦听
        internal bool CheckRepeated( GameObject target , Action<GameObject , PointerData> listener , bool killRepeated = false ) {
            int length = Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( this[i] != null && this[i].Target == target && this[i].Listener == listener ) {
                    if( killRepeated ) this[i] = null;
                    return true;
                }
            }
            return false;
        }

        // 派发事件至所有侦听 ( 重写 )
        internal override void DispatchAll( params object[] args ) {
            if( Nero.ManageEvent.EnableAllPointerListenerForUI ) base.DispatchAll( args );
        }

        // 接收指针事件
        internal void OnEnter( BaseEventData data ) => CachePointerEvent( PointerEventType.Enter , (PointerEventData)data );
        internal void OnExit( BaseEventData data ) => CachePointerEvent( PointerEventType.Exit , (PointerEventData)data );
        internal void OnDown( BaseEventData data ) => CachePointerEvent( PointerEventType.Down , (PointerEventData)data );
        internal void OnUp( BaseEventData data ) => CachePointerEvent( PointerEventType.Up , (PointerEventData)data );
        internal void OnClick( BaseEventData data ) => CachePointerEvent( PointerEventType.Click , (PointerEventData)data );
        internal void OnDrag( BaseEventData data ) => CachePointerEvent( PointerEventType.Drag , (PointerEventData)data );

        // 检查 Cover 状态
        internal void CheckCoverStatus() {
            int coverCount = CoverStatus.Count;
            for( int i = 0 ; i < coverCount ; i++ ) {
                if( CoverStatus[i].PointerID < 0 ) {
                    // 鼠标判断
                    int NowX = (int)Input.mousePosition.x;
                    int NowY = (int)Input.mousePosition.y;
                    if( CoverStatus[i].PrevX != NowX || CoverStatus[i].PrevY != NowY ) {
                        CoverStatus[i].PrevX = NowX;
                        CoverStatus[i].PrevY = NowY;
                        PointerEventCache.Add( new PointerData() {
                            InputType = PointerInputType.Mouse , EventType = PointerEventType.Cover ,
                            PointerID = -1 , X = NowX , Y = NowY
                        } );
                    }
                } else {
                    // 触屏判断
                    int touchCount = Input.touches.Length;
                    for( int j = 0 ; j < touchCount ; j++ ) {
                        if( CoverStatus[i].PointerID == Input.touches[j].fingerId ) {
                            int NowX = (int)Input.touches[j].position.x;
                            int NowY = (int)Input.touches[j].position.y;
                            if( CoverStatus[i].PrevX != NowX || CoverStatus[i].PrevY != NowY ) {
                                CoverStatus[i].PrevX = NowX;
                                CoverStatus[i].PrevY = NowY;
                                PointerEventCache.Add( new PointerData() {
                                    InputType = PointerInputType.Touch , EventType = PointerEventType.Cover ,
                                    PointerID = CoverStatus[i].PointerID , X = NowX , Y = NowY
                                } );
                            }
                            break;
                        }
                    }
                }
            }
        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 缓存指针事件
        private void CachePointerEvent( PointerEventType type , PointerEventData data ) {
            PointerData pointerData = new PointerData() {
                InputType = data.pointerId < 0 ? PointerInputType.Mouse : PointerInputType.Touch ,
                EventType = type ,
                PointerID = data.pointerId ,
                X = (int)data.position.x ,
                Y = (int)data.position.y
            };
            PointerEventCache.Add( pointerData );
            if( pointerData.EventType == PointerEventType.Enter ) {
                // 添加 Cover 状态
                CoverStatus.Add( new PointerCoverStatusForUI() {
                    PointerID = pointerData.InputType == PointerInputType.Mouse ? -1 : pointerData.PointerID ,
                    PrevX = pointerData.X ,
                    PrevY = pointerData.Y
                } );
            } else if( pointerData.EventType == PointerEventType.Exit ) {
                // 移除 Cover 状态
                int coverCount = CoverStatus.Count;
                for( int i = coverCount - 1 ; i >= 0 ; i-- ) {
                    if( CoverStatus[i].PointerID == pointerData.PointerID ) {
                        CoverStatus.RemoveAt( i );
                        break;
                    }
                }
            }

        }

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //