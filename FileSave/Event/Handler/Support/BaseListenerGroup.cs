// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NF.Core.Event.Handler.Support {
    internal class BaseListenerGroup<L> where L : BaseListener {

        // --- Field & Property ------------------------------------------------------------------------------------------------------------------------------------------- //

        // 侦听个数
        internal int Count => InnerList.Count;

        // 根据索引操作侦听
        internal L this[int index] { get => InnerList[index]; set => InnerList[index] = value; }

        // 内部列表
        private List<L> InnerList = new List<L>( 128 );

        // --- Public & Protected Function -------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal Function ------------------------------------------------------------------------------------------------------------------------------------------ //

        // 添加侦听 ( 自动根据侦听优先级排序 )
        internal void Add( L listener ) {
            if( listener == null ) return;
            if( InnerList.Count == 0 ) {
                InnerList.Add( listener );
            } else {
                int length = InnerList.Count;
                for( int i = length - 1 ; i >= 0 ; i-- ) {
                    if( InnerList[i] != null && InnerList[i].Priority >= listener.Priority ) {
                        InnerList.Insert( i + 1 , listener );
                        break;
                    } else if( i == 0 ) {
                        InnerList.Insert( 0 , listener );
                    }
                }
            }
        }

        // 根据索引移除侦听
        internal void RemoveAt( int index ) => InnerList.RemoveAt( index );

        // 派发事件至所有侦听 ( 如重写此函数，在派发后操作侦听必须加入 null 判断 )
        internal virtual void DispatchAll( params object[] args ) {
            int length = InnerList.Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( InnerList[i] != null ) InnerList[i].Dispatch( args );
            }
        }

        // 清理空元素，并返回剩余元素数
        internal virtual int ClearNullElement() {
            int length = InnerList.Count;
            for( int i = length - 1 ; i >= 0 ; i-- ) {
                if( InnerList[i] == null ) InnerList.RemoveAt( i );
            }
            return InnerList.Count;
        }

        // --- Private Function ------------------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //