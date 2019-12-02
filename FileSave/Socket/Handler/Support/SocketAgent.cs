// --- NERO ABYSS. ----------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static QuickTool;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

using NF.Core.Socket.Enum;
using System.Diagnostics;

namespace NF.Core.Socket.Handler.Support {
    // 套接字代理
    internal class SocketAgent {

        // --- ( Static ) Field & Property ----------------------------------------------------------------------------------------------------------------------------------- //

        // 缓冲区大小
        private static readonly int BufferSize = BufferHandler.BufferSize;

        // --- Field & Property ---------------------------------------------------------------------------------------------------------------------------------------------- //

        // 父级频道对象
        internal SocketChannel ParentChannel { get; set; }

        // 是否已连接 ( CAS )
        private int ConnectedCAS;

        // 是否已释放 ( CAS )
        private int DisposedCAS;

        // 内部 Socket 对象
        private readonly System.Net.Sockets.Socket InnerSocket;
        private int InnerSocketLockRoot;

        // 异步处理参数
        private readonly SocketAsyncEventArgs ConnectArgs;
        private readonly SocketAsyncEventArgs SendArgs;

        // --- 发送 --- //

        // 是否发送中
        private bool Sending;

        // 等待发送的消息队列
        private readonly List<SocketMessage> SendMessageQueue = new List<SocketMessage>();
        private int SendMessageQueueLockRoot;

        // 当前正在发送的消息
        private SocketMessage SendingMessage;
        private readonly byte[] SendingMessageHeader = new byte[6];

        // 剩余发送步骤数
        private int RemainingSendSteps;

        // --- 接收 --- //

        // 接收到的消息队列
        private readonly List<SocketMessage> ReceiveMessageQueue = new List<SocketMessage>();

        // 当前正在接收的消息
        private SocketMessage ReceivingMessage;
        private readonly byte[] ReceivingMessageHeader = new byte[6];
        private int ReceivingMessageHeaderPos = 0;
        private int ReceivingMessageExpectLength = 0;

        // 接收缓冲区
        private byte[] ReceiveBuffer;

        // 消息侦听列表
        private readonly List<SocketMessageListener>[] MessageListeners;

        // --- ( Static ) Public Function ------------------------------------------------------------------------------------------------------------------------------------ //

        // --- ( Static ) Internal & Protected Function ---------------------------------------------------------------------------------------------------------------------- //

        // --- ( Static ) Private Function ----------------------------------------------------------------------------------------------------------------------------------- //

        // --- Public Function ----------------------------------------------------------------------------------------------------------------------------------------------- //

        // --- Internal & Protected Function --------------------------------------------------------------------------------------------------------------------------------- //

        // 创建套接字代理 ( 频道 )
        internal SocketAgent( string host , SocketChannel parentChannel ) {
            InnerSocket = new System.Net.Sockets.Socket( AddressFamily.InterNetwork , SocketType.Stream , ProtocolType.Tcp );
            ParentChannel = parentChannel;
            // 解析主机地址
            string[] hostStrings = host.Split( ":".ToCharArray() );
            if( hostStrings.Length < 2 || !IPAddress.TryParse( hostStrings[0] , out IPAddress ip ) || !ushort.TryParse( hostStrings[1] , out ushort port ) ) {
                ERROR( "Nero.ManageSocket.AddSocketChannel --- host 格式错误, 解析失败" ,
                "channel : " + ParentChannel.ChannelIndex ,
                "host : " + ParentChannel.ChannelHost );
            } else {
                MessageListeners = new List<SocketMessageListener>[65536];
                ReceiveBuffer = BufferHandler.GetBuffer();
                SendArgs = new SocketAsyncEventArgs();
                SendArgs.Completed += new EventHandler<SocketAsyncEventArgs>( ( object o , SocketAsyncEventArgs e ) => {
                    if( e.SocketError == SocketError.Success ) { SendMessageBody(); } else { Disconnect(); }
                } );
                ConnectArgs = new SocketAsyncEventArgs() { RemoteEndPoint = new IPEndPoint( ip , port ) };
                ConnectArgs.Completed += new EventHandler<SocketAsyncEventArgs>( ( object o , SocketAsyncEventArgs e ) => {
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK ( SpinLock )
                    // Lock objects : SocketChannelHandler.DelayedOperations
                    LOCK( ref SocketChannelHandler.DelayedOperationsLockRoot );
                    try {
                        if( ConnectArgs.SocketError == SocketError.Success ) {
                            ConnectedCAS = 1;
                            SYSTEM( "Socket Channel - 套接字频道连接成功" , "Channel - " + ParentChannel.ChannelIndex , "Host - " + ParentChannel.ChannelHost );
                            // 添加套接字频道连接成功延迟操作
                            SocketChannelHandler.DelayedOperations.Add( new SocketChannelOperation() {
                                Type = DelayedOperationType.ConnectionCompleted ,
                                ChannelIndex = ParentChannel.ChannelIndex
                            } );
                        } else {
                            WARNING( "Socket Channel - 套接字频道连接失败" , "Channel - " + ParentChannel.ChannelIndex , "Host - " + ParentChannel.ChannelHost );
                            // 添加套接字频道连接失败延迟操作
                            SocketChannelHandler.DelayedOperations.Add( new SocketChannelOperation() {
                                Type = DelayedOperationType.ConnectionFailed ,
                                ChannelIndex = ParentChannel.ChannelIndex ,
                                TargetChannel = ParentChannel
                            } );
                        }
                    } finally { UNLOCK( ref SocketChannelHandler.DelayedOperationsLockRoot ); }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK ( SpinLock )
                    ConnectArgs.Dispose();
                } );
                if( !InnerSocket.ConnectAsync( ConnectArgs ) ) {
                    ConnectedCAS = 1;
                    SYSTEM( "Socket Channel - 套接字频道连接成功" , "Channel - " + ParentChannel.ChannelIndex , "Host - " + ParentChannel.ChannelHost );
                    // 添加套接字频道连接成功延迟操作 ( 同步完成, 无需重复进 SocketChannelHandler.DelayedOperations 锁 )
                    SocketChannelHandler.DelayedOperations.Add( new SocketChannelOperation() {
                        Type = DelayedOperationType.ConnectionCompleted ,
                        ChannelIndex = ParentChannel.ChannelIndex
                    } );
                    ConnectArgs.Dispose();
                }
            }
        }

        // 发送消息
        internal void SendMessage( SocketMessage message ) {
            if( DisposedCAS == 1 ) {
                ERROR( "Nero.ManageSocket.SendMessage --- 目标套接字频道已断开并释放, 无法发送套接字消息" ,
                "channel : " + ParentChannel.ChannelIndex ,
                "protocol : " + message.Info.InternalProtocol );
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK ( SpinLock )
            // Lock objects : SendMessageQueue
            LOCK( ref SendMessageQueueLockRoot );
            try {
                SendMessageQueue.Add( message );
            } finally { UNLOCK( ref SendMessageQueueLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK ( SpinLock )
        }

        // 添加消息侦听 ( 返回侦听是否重复 )
        internal bool AddMessageListener( ushort protocol , Action<SocketMessage> listener ) {
            if( DisposedCAS == 1 ) {
                ERROR( "Nero.ManageSocket.AddMessageListener --- 目标套接字频道已断开并释放, 无法添加消息侦听" ,
                "channel : " + ParentChannel.ChannelIndex ,
                "protocol : " + protocol ,
                "listener : " + listener.Method.Name );
            }
            if( MessageListeners[protocol] == null ) {
                MessageListeners[protocol] = new List<SocketMessageListener>() { new SocketMessageListener() { ListenerAction = listener } };
            } else {
                int length = MessageListeners[protocol].Count;
                for( int i = 0 ; i < length ; i++ ) {
                    if( MessageListeners[protocol][i].ListenerAction == listener ) return true;
                }
                MessageListeners[protocol].Add( new SocketMessageListener() { ListenerAction = listener } );
            }
            return false;
        }

        // 移除消息侦听
        internal void RemoveMessageListener( ushort protocol , Action<SocketMessage> listener ) {
            if( DisposedCAS == 1 ) {
                ERROR( "Nero.ManageSocket.RemoveMessageListener --- 目标套接字频道已断开并释放, 无法移除消息侦听" ,
                "channel : " + ParentChannel.ChannelIndex ,
                "protocol : " + protocol ,
                "listener : " + listener.Method.Name );
            }
            if( MessageListeners[protocol] == null ) return;
            int length = MessageListeners[protocol].Count;
            for( int i = 0 ; i < length ; i++ ) {
                if( MessageListeners[protocol][i].ListenerAction == listener ) {
                    MessageListeners[protocol].RemoveAt( i );
                    if( MessageListeners[protocol].Count == 0 ) MessageListeners[protocol] = null;
                    return;
                }
            }
        }

        // 断开连接
        internal void Disconnect() {
            if( Interlocked.CompareExchange( ref ConnectedCAS , 0 , 1 ) == 1 ) { // CAS
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK ( SpinLock )
                // Lock objects : SocketChannelHandler.DelayedOperations
                LOCK( ref SocketChannelHandler.DelayedOperationsLockRoot );
                try {
                    // 添加套接字频道断开操作
                    SocketChannelHandler.DelayedOperations.Add( new SocketChannelOperation() {
                        Type = DelayedOperationType.Disconnected ,
                        ChannelIndex = ParentChannel.ChannelIndex ,
                        TargetChannel = ParentChannel
                    } );
                } finally { UNLOCK( ref SocketChannelHandler.DelayedOperationsLockRoot ); }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK ( SpinLock )
            }
        }

        // 释放对象
        internal void Dispose() {
            if( Interlocked.CompareExchange( ref DisposedCAS , 1 , 0 ) == 0 ) { // CAS
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK ( SpinLock )
                // Lock objects : InnerSocket
                LOCK( ref InnerSocketLockRoot );
                try {
                    if( InnerSocket.Connected ) InnerSocket.Shutdown( SocketShutdown.Both );
                    InnerSocket.Close();
                } finally { UNLOCK( ref InnerSocketLockRoot ); }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK ( SpinLock )
                if( ConnectArgs != null ) ConnectArgs.Dispose();
                if( SendArgs != null ) SendArgs.Dispose();
                if( ReceivingMessage != null ) ReceivingMessage.Dispose();
                if( SendingMessage != null ) SendingMessage.Dispose();
                // 归还缓冲区
                BufferHandler.RecyclingBuffer( ReceiveBuffer );
                ReceiveBuffer = null;
                // 清空并释放接收消息队列
                int length = ReceiveMessageQueue.Count;
                for( int i = 0 ; i < length ; i++ ) ReceiveMessageQueue[i].Dispose();
                ReceiveMessageQueue.RemoveRange( 0 , length );
                // 清空并释放发送消息队列
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK ( SpinLock )
                // Lock objects : SendMessageQueue
                LOCK( ref SendMessageQueueLockRoot );
                try {
                    length = SendMessageQueue.Count;
                    for( int i = 0 ; i < length ; i++ ) SendMessageQueue[i].Dispose();
                    SendMessageQueue.RemoveRange( 0 , length );
                } finally { UNLOCK( ref SendMessageQueueLockRoot ); }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK ( SpinLock )
            }
        }

        // 开始接收消息
        internal void StartReceiveMessage() {
            if( ConnectedCAS == 1 && !InnerSocket.Connected ) Disconnect();
            if( ConnectedCAS == 0 || DisposedCAS == 1 || InnerSocket.Available == 0 ) return;
            // 解析消息
            try {
                while( InnerSocket.Available > 0 ) ParseMessage();
            } catch { Disconnect(); }
            // 调用侦听
            while( ReceiveMessageQueue.Count > 0 ) {
                SocketMessage message = ReceiveMessageQueue[0];
                ReceiveMessageQueue.RemoveAt( 0 );
                if( MessageListeners[message.Info.Protocol] != null ) {
                    int length = MessageListeners[message.Info.Protocol].Count;
                    for( int i = 0 ; i < length ; i++ ) {
                        if( i == 0 ) {
                            InvokeListener( MessageListeners[message.Info.Protocol][i] , message );
                        } else {
                            SocketMessage clone = message.Clone();
                            InvokeListener( MessageListeners[message.Info.Protocol][i] , clone );
                            clone.Dispose();
                        }
                    }
                }
                message.Dispose();
            }
        }

        // 开始发送消息
        internal void StartSendMessage() {
            if( ConnectedCAS == 1 && !InnerSocket.Connected ) Disconnect();
            if( ConnectedCAS == 0 || DisposedCAS == 1 || Sending ) return;
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK ( SpinLock )
            // Lock objects : SendMessageQueue
            LOCK( ref SendMessageQueueLockRoot );
            try {
                if( SendMessageQueue.Count == 0 ) return;
            } finally { UNLOCK( ref SendMessageQueueLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK ( SpinLock )
            Sending = true;
            SendMessageHeader();
        }

        // --- Private Function ---------------------------------------------------------------------------------------------------------------------------------------------- //

        // 解析消息
        private void ParseMessage() {
            int receiveCount = InnerSocket.Receive( ReceiveBuffer , InnerSocket.Available > BufferSize ? BufferSize : InnerSocket.Available , SocketFlags.None );
            int bufferOffset = 0;
            while( true ) {
                if( bufferOffset == receiveCount ) break;
                if( ReceivingMessageHeaderPos != 6 ) {
                    // 读取消息头
                    if( receiveCount - bufferOffset >= 6 - ReceivingMessageHeaderPos ) {
                        // 数据充足
                        Array.Copy( ReceiveBuffer , bufferOffset , ReceivingMessageHeader , ReceivingMessageHeaderPos , 6 - ReceivingMessageHeaderPos );
                        bufferOffset += 6 - ReceivingMessageHeaderPos;
                        ReceivingMessageHeaderPos = 6;
                        ReceivingMessageExpectLength = BitConverter.ToInt32( ReceivingMessageHeader , 2 );
                        if( ReceivingMessageExpectLength < 0 ) {
                            Disconnect();
                            return;
                        }
                        ReceivingMessage = ReceivingMessageExpectLength > 0 ? new SocketMessage() : new SocketMessage( false ); // 性能优化, 空消息不拉取缓冲区
                        ReceivingMessage.Info.InternalProtocol = BitConverter.ToUInt16( ReceivingMessageHeader , 0 );
                    } else {
                        // 数据不足
                        Array.Copy( ReceiveBuffer , bufferOffset , ReceivingMessageHeader , ReceivingMessageHeaderPos , receiveCount - bufferOffset );
                        ReceivingMessageHeaderPos += receiveCount - bufferOffset;
                        break;
                    }
                } else {
                    // 读取消息内容
                    if( receiveCount - bufferOffset >= ReceivingMessageExpectLength - ReceivingMessage.Length ) {
                        // 数据充足
                        if( ReceivingMessageExpectLength > 0 ) {
                            bufferOffset += ReceivingMessage.CopyFromBytes( ReceiveBuffer , bufferOffset , ReceivingMessageExpectLength - ReceivingMessage.Length );
                        }
                        ReceivingMessage.Info.InternalChannel = ParentChannel.ChannelIndex;
                        ReceivingMessage.Info.Status = SocketMessageStatus.Received;
                        ReceivingMessage.Position = 0;
                        ReceiveMessageQueue.Add( ReceivingMessage );
                        ReceivingMessage = null;
                        ReceivingMessageHeaderPos = 0;
                    } else {
                        // 数据不足
                        ReceivingMessage.CopyFromBytes( ReceiveBuffer , bufferOffset , receiveCount - bufferOffset );
                        break;
                    }
                }
            }
        }

        // 发送消息头
        private void SendMessageHeader() {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK ( SpinLock )
            // Lock objects : SendMessageQueue
            LOCK( ref SendMessageQueueLockRoot );
            try {
                if( SendMessageQueue.Count == 0 ) {
                    // 消息全部发送完毕, 重置发送状态
                    Sending = false;
                    return;
                }
                SendingMessage = SendMessageQueue[0];
                SendMessageQueue.RemoveAt( 0 );
            } finally { UNLOCK( ref SendMessageQueueLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK ( SpinLock )
            // 计算剩余发送步骤数
            RemainingSendSteps = SendingMessage.Length == 0 ? 0 : SendingMessage.Buffers.Count;
            Array.Copy( BitConverter.GetBytes( SendingMessage.Info.InternalProtocol ) , 0 , SendingMessageHeader , 0 , 2 );
            Array.Copy( BitConverter.GetBytes( SendingMessage.Length ) , 0 , SendingMessageHeader , 2 , 4 );
            SendArgs.SetBuffer( SendingMessageHeader , 0 , 6 );
            try {
                if( !InnerSocket.SendAsync( SendArgs ) ) SendMessageBody();
            } catch { Disconnect(); }
        }

        // 发送消息体
        private void SendMessageBody() {
            if( RemainingSendSteps == 0 ) {
                SendingMessage.Dispose();
                SendMessageHeader();
                return;
            }
            try {
                if( RemainingSendSteps == 1 ) {
                    SendArgs.SetBuffer( SendingMessage.Buffers[SendingMessage.Buffers.Count - RemainingSendSteps] , 0 , SendingMessage.Length % BufferSize );
                } else {
                    SendArgs.SetBuffer( SendingMessage.Buffers[SendingMessage.Buffers.Count - RemainingSendSteps] , 0 , BufferSize );
                }
                RemainingSendSteps--;
                if( !InnerSocket.SendAsync( SendArgs ) ) SendMessageBody();
            } catch { Disconnect(); }
        }

        // 调用侦听
        private void InvokeListener( SocketMessageListener listener , SocketMessage message ) {
            listener.InvokeSW.Restart();
            listener.ListenerAction( message );
            listener.LTC = listener.InvokeSW.Elapsed.TotalMilliseconds;
            listener.ATC = ( listener.ATC * listener.InvokeCount + listener.LTC ) / ( listener.InvokeCount + 1 );
            if( listener.HTC < listener.LTC ) listener.HTC = listener.LTC;
            listener.InvokeCount++;
        }

    }
}

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //