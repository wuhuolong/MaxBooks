// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class IntervalListenerGroup : BaseListenerGroup<IntervalListener> {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 检查重复侦听
        internal bool CheckRepeated( Action listener , bool killRepeated = false ) {
            int length = Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( this[i] != null && this[i].Listener == listener ) {
                    if( killRepeated ) this[i] = null;
                    return true;
                }
            }
            return false;
        }

        // 派发事件至所有侦听 ( 重写 )
        internal override void DispatchAll( params object[] args ) {
            int length = Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( this[i] != null ) {
                    this[i].RunningTime += Nero.FTC;
                    if( this[i].RunningTime > this[i].Interval ) {
                        // 计算派发次数
                        int round = (int)Math.Floor( this[i].RunningTime / this[i].Interval );
                        if( !this[i].InfiniteLoop ) {
                            if( this[i].Times <= 0 ) {
                                round = 0;
                                this[i].Listener = null;
                            } else if( round > this[i].Times ) {
                                round = this[i].Times;
                            }
                            this[i].Times -= round;
                        }
                        // 派发事件
                        for( int j = 0 ; j < round ; j++ ) {
                            if( this[i] != null ) this[i].Dispatch();
                        }
                        // 存回余下时间 ( 派发后操作侦听必须加入 null 判断 )
                        if( this[i] != null ) this[i].RunningTime = this[i].RunningTime % this[i].Interval;
                    }
                }
            }
        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //
