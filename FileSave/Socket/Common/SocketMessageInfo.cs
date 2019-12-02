// --- NERO ABYSS. ----------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static QuickTool;
using System;
using System.Collections.Generic;

/// <summary> 套接字消息附带信息 </summary>
public sealed class SocketMessageInfo : HOIM {

    // --- ( Static ) Field & Property --------------------------------------------------------------------------------------------------------------------------------------- //

    // --- Field & Property -------------------------------------------------------------------------------------------------------------------------------------------------- //

    /// <summary> 套接字消息的状态 </summary>
    public SocketMessageStatus Status { get; internal set; } = SocketMessageStatus.WaitToSend;
    internal int StatusLockRoot;

    /// <summary> 套接字消息所使用的频道 </summary>
    public ushort Channel {
        get {
            if( Status != SocketMessageStatus.Received ) ERROR( "SocketMessage.Info.Channel --- 仅接收到的 SocketMessage 对象可访问此属性" );
            return InternalChannel;
        }
    }
    internal ushort InternalChannel;

    /// <summary> 套接字消息使用的数据协议 </summary>
    public ushort Protocol {
        get {
            if( Status != SocketMessageStatus.Received ) ERROR( "SocketMessage.Info.Protocol --- 仅接收到的 SocketMessage 对象可访问此属性" );
            return InternalProtocol;
        }
    }
    internal ushort InternalProtocol;

    // --- ( Static ) Public Function ---------------------------------------------------------------------------------------------------------------------------------------- //

    // --- ( Static ) Internal & Protected Function -------------------------------------------------------------------------------------------------------------------------- //

    // --- ( Static ) Private Function --------------------------------------------------------------------------------------------------------------------------------------- //

    // --- Public Function --------------------------------------------------------------------------------------------------------------------------------------------------- //

    // --- Internal & Protected Function ------------------------------------------------------------------------------------------------------------------------------------- //

    internal SocketMessageInfo() { }

    // --- Private Function -------------------------------------------------------------------------------------------------------------------------------------------------- //

}

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //