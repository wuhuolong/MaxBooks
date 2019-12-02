// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class PointerListenerGroupForMesh : BaseListenerGroup<PointerListenerForMesh> {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 侦听对象
        internal GameObject Target { get; set; }

        // 鼠标射线碰撞数据
        internal RaycastHit MouseRaycastHit { get; set; }

        // 触屏射线碰撞数据组 ( 索引为TouchID )
        internal RaycastHit[] TouchRaycastHits { get; set; } = new RaycastHit[20];

        // 指针拖拽状态组
        internal List<PointerDragStatusForMesh> DragStatus { get; set; } = new List<PointerDragStatusForMesh>( 128 );

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 检查重复侦听
        internal bool CheckRepeated( GameObject target , Action<GameObject , PointerData , RaycastHit> listener , bool killRepeated = false ) {
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
            if( Target == null ) return;

            // 装箱参数
            PointerData pointerData = (PointerData)args[0];
            bool isFocus = (bool)args[1]; // 事件派发时 侦听对象是否为焦点
            bool onlyChangeFocus = (bool)args[2]; // 是否仅因为焦点变换而产生的滑入或滑出事件 ( 只对 IgnoreOcclusion 属性为 false 的对象有效 )

            // 派发事件
            if( !Nero.ManageEvent.EnableAllPointerListenerForMesh ) return;
            int length = Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( this[i] != null ) {
                    if( ( onlyChangeFocus && !this[i].IgnoreOcclusion ) || ( !onlyChangeFocus && ( ( !this[i].IgnoreOcclusion && isFocus ) || this[i].IgnoreOcclusion ) ) ) {
                        this[i].Listener( Target , pointerData , pointerData.InputType == PointerInputType.Mouse ? MouseRaycastHit : TouchRaycastHits[pointerData.PointerID] );
                    }
                }
            }

        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //