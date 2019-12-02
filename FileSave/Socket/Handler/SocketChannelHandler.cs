// --- NERO ABYSS. ----------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static QuickTool;
using System;
using System.Collections.Generic;

using NF.Core.Socket.Enum;
using NF.Core.Socket.Handler.Support;

namespace NF.Core.Socket.Handler {
    // 套接字频道处理程序
    internal static class SocketChannelHandler {

        // --- ( Static ) Field & Property ----------------------------------------------------------------------------------------------------------------------------------- //

        // 延迟操作列表
        internal static readonly List<SocketChannelOperation> DelayedOperations = new List<SocketChannelOperation>();
        internal static int DelayedOperationsLockRoot;

        // 频道组
        private static readonly SocketChannel[] Channels = new SocketChannel[65536];
        private static int ChannelsLockRoot;

        private static readonly List<Action> Actions = new List<Action>();

        // --- ( Static ) Public Function ------------------------------------------------------------------------------------------------------------------------------------ //

        // --- ( Static ) Internal & Protected Function ---------------------------------------------------------------------------------------------------------------------- //

        // 添加套接字频道
        internal static void AddSocketChannel( ushort channel , string host , Action<SocketChannelEvent> listener ) {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : DelayedOperations
            LOCK( ref DelayedOperationsLockRoot );
            try {
                int length = DelayedOperations.Count;
                for( int i = 0 ; i < length ; i++ ) {
                    if( DelayedOperations[i].Type == DelayedOperationType.AddSocketChannel && DelayedOperations[i].ChannelIndex == channel ) {
                        ERROR( "Nero.ManageSocket.AddSocketChannel --- 目标频道已存在, 无法执行添加操作" ,
                        "channel : " + channel ,
                        "host" + host );
                    }
                }
                DelayedOperations.Add( new SocketChannelOperation() {
                    Type = DelayedOperationType.AddSocketChannel ,
                    ChannelIndex = channel ,
                    ChannelHost = host ,
                    ChannelListener = listener
                } );
            } finally { UNLOCK( ref DelayedOperationsLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK
        }

        // 移除套接字频道
        internal static void RemoveSocketChannel( ushort channel ) {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : DelayedOperations
            LOCK( ref DelayedOperationsLockRoot );
            try {
                int length = DelayedOperations.Count;
                for( int i = length - 1 ; i >= 0 ; i-- ) {
                    if( DelayedOperations[i].ChannelIndex == channel &&
                        ( DelayedOperations[i].Type == DelayedOperationType.AddSocketChannel || DelayedOperations[i].Type == DelayedOperationType.RemoveSocketChannel ) ) {
                        // 同时移除所有匹配的 Add 和 Remove 的延迟操作
                        DelayedOperations.RemoveAt( i );
                    }
                }
                DelayedOperations.Add( new SocketChannelOperation() {
                    Type = DelayedOperationType.RemoveSocketChannel ,
                    ChannelIndex = channel
                } );
            } finally { UNLOCK( ref DelayedOperationsLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK
        }

        // 添加套接字消息侦听
        internal static void AddMessageListener( ushort channel , ushort protocol , Action<SocketMessage> listener ) {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : DelayedOperations
            LOCK( ref DelayedOperationsLockRoot );
            try {
                int length = DelayedOperations.Count;
                for( int i = 0 ; i < length ; i++ ) {
                    if( DelayedOperations[i].ChannelIndex == channel &&
                        DelayedOperations[i].Protocol == protocol &&
                        DelayedOperations[i].MessageListener == listener ) {
                        if( DelayedOperations[i].Type == DelayedOperationType.AddMessageListener ) {
                            ERROR( "Nero.ManageSocket.AddMessageListener --- 目标套接字频道无法在一个数据协议下重复添加同一个消息侦听" ,
                            "channel : " + channel ,
                            "protocol : " + protocol ,
                            "listener : " + listener.Method.Name );
                        }
                    }
                }
                DelayedOperations.Add( new SocketChannelOperation() {
                    Type = DelayedOperationType.AddMessageListener ,
                    ChannelIndex = channel ,
                    Protocol = protocol ,
                    MessageListener = listener
                } );
            } finally { UNLOCK( ref DelayedOperationsLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK
        }

        // 移除套接字消息侦听
        internal static void RemoveMessageListener( ushort channel , ushort protocol , Action<SocketMessage> listener ) {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : DelayedOperations
            LOCK( ref DelayedOperationsLockRoot );
            try {
                int length = DelayedOperations.Count;
                for( int i = length - 1 ; i >= 0 ; i-- ) {
                    if( DelayedOperations[i].ChannelIndex == channel &&
                        DelayedOperations[i].Protocol == protocol &&
                        DelayedOperations[i].MessageListener == listener &&
                        ( DelayedOperations[i].Type == DelayedOperationType.AddMessageListener ||
                        DelayedOperations[i].Type == DelayedOperationType.RemoveMessageListener ) ) {
                        // 同时移除所有匹配的 Add 和 Remove 的延迟操作
                        DelayedOperations.RemoveAt( i );
                    }
                }
                DelayedOperations.Add( new SocketChannelOperation() {
                    Type = DelayedOperationType.RemoveMessageListener ,
                    ChannelIndex = channel ,
                    Protocol = protocol ,
                    MessageListener = listener
                } );
            } finally { UNLOCK( ref DelayedOperationsLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK
        }

        // 发送套接字消息
        internal static void SendMessage( ushort channel , ushort protocol , SocketMessage message ) {
            if( message == null ) {
                message = new SocketMessage( false ); // 性能优化, 空消息不拉取缓冲区
            } else {
                bool needClone = false;
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
                // Lock objects : message.Info.Status
                LOCK( ref message.Info.StatusLockRoot );
                try {
                    if( message.Info.Status == SocketMessageStatus.WaitToSend ) {
                        message.Info.Status = SocketMessageStatus.Sending;
                    } else if( message.Info.Status == SocketMessageStatus.Sending ) {
                        needClone = true;
                    } else if( message.Info.Status == SocketMessageStatus.Received ) {
                        ERROR( "Nero.ManageSocket.SendMessage --- SocketMessage 对象接收自远端, 请创建新的 SocketMessage 对象用于消息发送" ,
                        "channel : " + channel ,
                        "protocol : " + protocol );
                    } else if( message.Info.Status == SocketMessageStatus.Disposed ) {
                        ERROR( "Nero.ManageSocket.SendMessage --- SocketMessage 对象已被释放, 请创建新的 SocketMessage 对象用于消息发送" ,
                        "channel : " + channel ,
                        "protocol : " + protocol );
                    }
                } finally { UNLOCK( ref message.Info.StatusLockRoot ); }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK
                if( needClone ) message = message.Clone();
            }
            message.Info.InternalProtocol = protocol;
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : Channels
            LOCK( ref ChannelsLockRoot );
            try {
                if( Channels[channel] == null ) {
                    ERROR( "Nero.ManageSocket.SendMessage --- 目标频道不存在, 无法发送套接字消息" ,
                    "channel : " + channel ,
                    "protocol : " + protocol );
                }
                Channels[channel].Agent.SendMessage( message );
            } finally { UNLOCK( ref ChannelsLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK
        }

        // 帧循环
        internal static void FrameLoop() {

            int length;
            // 处理延迟操作
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : DelayedOperations
            LOCK( ref DelayedOperationsLockRoot );
            try {

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
                // Lock objects : Channels
                LOCK( ref ChannelsLockRoot );
                try {

                    // 处理 RemoveSocketChannel
                    length = DelayedOperations.Count;
                    for( int i = length - 1 ; i >= 0 ; i-- ) {
                        if( DelayedOperations[i].Type == DelayedOperationType.RemoveSocketChannel ) {
                            if( Channels[DelayedOperations[i].ChannelIndex] != null ) {
                                Channels[DelayedOperations[i].ChannelIndex].Agent.Dispose();
                                Channels[DelayedOperations[i].ChannelIndex] = null;
                            }
                            DelayedOperations.RemoveAt( i );
                        }
                    }

                    // 处理 AddSocketChannel
                    length = DelayedOperations.Count;
                    for( int i = length - 1 ; i >= 0 ; i-- ) {
                        if( DelayedOperations[i].Type == DelayedOperationType.AddSocketChannel ) {
                            if( Channels[DelayedOperations[i].ChannelIndex] != null ) {
                                ERROR( "Nero.ManageSocket.AddSocketChannel --- 目标频道已存在, 无法执行添加操作" ,
                                "channel : " + DelayedOperations[i].ChannelIndex ,
                                "host" + DelayedOperations[i].ChannelHost );
                            } else {
                                Channels[DelayedOperations[i].ChannelIndex] = new SocketChannel() {
                                    ChannelIndex = DelayedOperations[i].ChannelIndex ,
                                    ChannelHost = DelayedOperations[i].ChannelHost ,
                                    ChannelListener = DelayedOperations[i].ChannelListener
                                };
                                Channels[DelayedOperations[i].ChannelIndex].Initialization();
                            }
                            DelayedOperations.RemoveAt( i );
                        }
                    }

                } finally { UNLOCK( ref ChannelsLockRoot ); }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK

                // 处理 ConnectionCompleted
                length = DelayedOperations.Count;
                for( int i = length - 1 ; i >= 0 ; i-- ) {
                    if( DelayedOperations[i].Type == DelayedOperationType.ConnectionCompleted ) {
                        if( Channels[DelayedOperations[i].ChannelIndex] != null ) {
                            AddListenerAction( Channels[DelayedOperations[i].ChannelIndex].ChannelListener , new SocketChannelEvent() {
                                EventType = SocketChannelEventType.ConnectionCompleted ,
                                EventChannel = DelayedOperations[i].ChannelIndex
                            } );
                        }
                        DelayedOperations.RemoveAt( i );
                    }
                }

            } finally { UNLOCK( ref DelayedOperationsLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK

            // 调用方法 ( ConnectionCompleted )
            InvokeActions();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : DelayedOperations
            LOCK( ref DelayedOperationsLockRoot );
            try {

                // 处理 ConnectionFailed / Disconnected
                length = DelayedOperations.Count;
                for( int i = length - 1 ; i >= 0 ; i-- ) {
                     if( DelayedOperations[i].Type == DelayedOperationType.ConnectionFailed ) {
                        if( Channels[DelayedOperations[i].ChannelIndex] != null ) {
                            AddListenerAction( Channels[DelayedOperations[i].ChannelIndex].ChannelListener , new SocketChannelEvent() {
                                EventType = SocketChannelEventType.ConnectionFailed ,
                                EventChannel = DelayedOperations[i].ChannelIndex
                            } , DelayedOperations[i].TargetChannel.Agent.Dispose );
                        } else {
                            Actions.Add( DelayedOperations[i].TargetChannel.Agent.Dispose );
                        }
                        DelayedOperations.RemoveAt( i );
                    } else if( DelayedOperations[i].Type == DelayedOperationType.Disconnected ) {
                        if( Channels[DelayedOperations[i].ChannelIndex] != null ) {
                            AddListenerAction( Channels[DelayedOperations[i].ChannelIndex].ChannelListener , new SocketChannelEvent() {
                                EventType = SocketChannelEventType.Disconnected ,
                                EventChannel = DelayedOperations[i].ChannelIndex
                            } , DelayedOperations[i].TargetChannel.Agent.Dispose );
                        } else {
                            Actions.Add( DelayedOperations[i].TargetChannel.Agent.Dispose );
                        }
                        DelayedOperations.RemoveAt( i );
                    }
                }

            } finally { UNLOCK( ref DelayedOperationsLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK

            // 调用方法 ( ConnectionFailed / Disconnected )
            InvokeActions();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - LOCK
            // Lock objects : DelayedOperations
            LOCK( ref DelayedOperationsLockRoot );
            try {

                // 处理 RemoveMessageListener
                length = DelayedOperations.Count;
                for( int i = length - 1 ; i >= 0 ; i-- ) {
                    if( DelayedOperations[i].Type == DelayedOperationType.RemoveMessageListener ) {
                        if( Channels[DelayedOperations[i].ChannelIndex] != null ) {
                            Channels[DelayedOperations[i].ChannelIndex].Agent.RemoveMessageListener( DelayedOperations[i].Protocol , DelayedOperations[i].MessageListener );
                        }
                        DelayedOperations.RemoveAt( i );
                    }
                }

                // 处理 AddMessageListener
                length = DelayedOperations.Count;
                for( int i = length - 1 ; i >= 0 ; i-- ) {
                    if( DelayedOperations[i].Type == DelayedOperationType.AddMessageListener ) {
                        if( Channels[DelayedOperations[i].ChannelIndex] != null ) {
                            if( Channels[DelayedOperations[i].ChannelIndex].Agent.AddMessageListener( DelayedOperations[i].Protocol , DelayedOperations[i].MessageListener ) ) {
                                ERROR( "Nero.ManageSocket.AddMessageListener --- 目标远程频道无法在一个数据协议下重复添加同一个消息侦听" ,
                                "channel : " + DelayedOperations[i].TargetChannel ,
                                "protocol : " + DelayedOperations[i].Protocol ,
                                "listener : " + DelayedOperations[i].MessageListener.Method.Name );
                            }
                        }
                        DelayedOperations.RemoveAt( i );
                    }
                }

            } finally { UNLOCK( ref DelayedOperationsLockRoot ); }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////// - UNLOCK

            // 接收消息
            for( int i = 0 ; i < 65536 ; i++ ) {
                if( Channels[i] != null ) Channels[i].Agent.StartReceiveMessage();
            }

        }

        // 开始发送消息
        internal static void StartSendMessage() {

            // 发送消息
            for( int i = 0 ; i < 65536 ; i++ ) {
                if( Channels[i] != null ) Channels[i].Agent.StartSendMessage();
            }

        }

        // --- ( Static ) Private Function ----------------------------------------------------------------------------------------------------------------------------------- //

        // 添加侦听方法
        private static void AddListenerAction( Action<SocketChannelEvent> listener , SocketChannelEvent socketChannelEvent , Action beforeAction = null ) {
            if( beforeAction == null ) {
                Actions.Add( () => listener( socketChannelEvent ) );
            } else {
                Actions.Add( () => {
                    beforeAction();
                    listener( socketChannelEvent );
                } );
            }
        }

        // 调用方法
        private static void InvokeActions() {
            int length = Actions.Count;
            for( int i = 0 ; i < length ; i++ ) Actions[i]?.Invoke();
            Actions.RemoveRange( 0 , length );
        }

    }
}

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //