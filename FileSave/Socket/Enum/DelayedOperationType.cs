// --- NERO ABYSS. -------------------------------------------------------------------------------------------------------------------------------------------------------- //

namespace NF.Core.Socket.Enum {
    // 延迟操作类型
    internal enum DelayedOperationType {

        // 添加套接字频道
        AddSocketChannel = 0,

        // 移除套接字频道
        RemoveSocketChannel = 1,

        // 添加消息侦听
        AddMessageListener = 2,

        // 移除消息侦听
        RemoveMessageListener = 3,

        // 套接字频道连接完成
        ConnectionCompleted = 4,

        // 套接字频道连接失败
        ConnectionFailed = 5,

        // 套接字频道已断开
        Disconnected = 6

    }
}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //