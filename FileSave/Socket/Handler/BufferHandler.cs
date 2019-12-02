// --- NERO ABYSS. ----------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static QuickTool;
using System;
using System.Collections.Generic;

namespace NF.Core.Socket.Handler {
    // 缓冲区处理程序
    internal static class BufferHandler {

        // --- ( Static ) Field & Property ----------------------------------------------------------------------------------------------------------------------------------- //

        // 缓冲区大小
        internal static readonly int BufferSize = 4096;

        // 缓冲区池
        private static readonly List<byte[]> BufferPool = new List<byte[]>();
        private static int BufferPoolLockRoot;

        // --- ( Static ) Public Function ------------------------------------------------------------------------------------------------------------------------------------ //

        // 静态初始化
        static BufferHandler() { for( int i = 0 ; i < 1024 ; i++ ) BufferPool.Add( new byte[BufferSize] ); }

        // --- ( Static ) Internal & Protected Function ---------------------------------------------------------------------------------------------------------------------- //

        // 获取缓冲区
        internal static byte[] GetBuffer() {
            byte[] buffer = null;
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : BufferPool
            LOCK( ref BufferPoolLockRoot );
            try {
                if( BufferPool.Count > 0 ) {
                    buffer = BufferPool[BufferPool.Count - 1];
                    BufferPool.RemoveAt( BufferPool.Count - 1 );
                }
            } finally { UNLOCK( ref BufferPoolLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK
            return buffer ?? new byte[BufferSize];
        }

        // 回收缓冲区组
        internal static void RecyclingBuffer( byte[] buffer ) {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : BufferPool
            LOCK( ref BufferPoolLockRoot );
            try {
                BufferPool.Add( buffer );
            } finally { UNLOCK( ref BufferPoolLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK
        }

        // 回收缓冲区组
        internal static void RecyclingBuffers( List<byte[]> buffers ) {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : BufferPool
            LOCK( ref BufferPoolLockRoot );
            try {
                BufferPool.AddRange( buffers );
            } finally { UNLOCK( ref BufferPoolLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK
        }

        // --- ( Static ) Private Function ----------------------------------------------------------------------------------------------------------------------------------- //

    }
}

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //