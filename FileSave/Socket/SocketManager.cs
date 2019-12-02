// --- NERO ABYSS. ----------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static QuickTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using NF.Core.Socket.Handler;

/// <summary> 资源管理 </summary>
[EditorBrowsable( EditorBrowsableState.Never )]
public sealed class SocketManager : HOIM {

    // --- ( Static ) Field & Property --------------------------------------------------------------------------------------------------------------------------------------- //

    // --- Field & Property -------------------------------------------------------------------------------------------------------------------------------------------------- //

    // --- ( Static ) Public Function ---------------------------------------------------------------------------------------------------------------------------------------- //

    // --- ( Static ) Internal & Protected Function -------------------------------------------------------------------------------------------------------------------------- //

    // 帧循环
    internal static void FrameLoop() => SocketChannelHandler.FrameLoop();

    // 开始发送消息
    internal static void StartSendMessage() => SocketChannelHandler.StartSendMessage();

    // --- ( Static ) Private Function --------------------------------------------------------------------------------------------------------------------------------------- //

    // --- Public Function --------------------------------------------------------------------------------------------------------------------------------------------------- //

    /// <summary> 添加套接字频道 </summary>
    /// <param name="type">频道类型</param>
    /// <param name="channel">套接字频道号( 0 ~ 65535 )</param>
    /// <param name="host">主机地址及端口</param>
    /// <param name="listener">套接字频道事件侦听函数</param>
    public void AddSocketChannel( ushort channel , string host , Action<SocketChannelEvent> listener ) =>
        SocketChannelHandler.AddSocketChannel( channel , host , listener );

    /// <summary> 移除套接字频道 ( 频道将强制移除, 且不会触发任何频道事件 ) </summary>
    /// <param name="channel">套接字频道( 0 ~ 65535 )</param>
    public void RemoveSocketChannel( ushort channel ) =>
        SocketChannelHandler.RemoveSocketChannel( channel );

    /// <summary> 添加套接字消息侦听 </summary>
    /// <param name="channel">套接字频道号( 0 ~ 65535 )</param>
    /// <param name="protocol">套接字消息所使用的数据协议号( 0 ~ 65535 )</param>
    /// <param name="listener">套接字消息侦听函数</param>
    public void AddMessageListener( ushort channel , ushort protocol , Action<SocketMessage> listener ) =>
        SocketChannelHandler.AddMessageListener( channel , protocol , listener );

    /// <summary> 移除套接字消息侦听 </summary>
    /// <param name="channel">套接字频道号</param>
    /// <param name="protocol">套接字消息所使用的数据协议号( 0 ~ 65535 )</param>
    /// <param name="listener">套接字消息侦听函数</param>
    public void RemoveMessageListener( ushort channel , ushort protocol , Action<SocketMessage> listener ) =>
        SocketChannelHandler.RemoveMessageListener( channel , protocol , listener );

    /// <summary> 发送套接字消息 </summary>
    /// <param name="channel">套接字频道号</param>
    /// <param name="protocol">套接字消息所使用的数据协议号( 0 ~ 65535 )</param>
    /// <param name="message">套接字消息内容</param>
    public void SendMessage( ushort channel , ushort protocol , SocketMessage message = null ) =>
        SocketChannelHandler.SendMessage( channel , protocol , message );

    // --- Internal & Protected Function ------------------------------------------------------------------------------------------------------------------------------------- //

    internal SocketManager() { }

    // --- Private Function -------------------------------------------------------------------------------------------------------------------------------------------------- //

}

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //