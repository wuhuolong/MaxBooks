// --- NERO ABYSS. ----------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static QuickTool;
using System;
using System.Collections.Generic;
using NF.Core.Socket.Handler;
using System.Text;
using System.Threading;

/// <summary> 套接字消息 </summary>
public sealed class SocketMessage : HOIM {

    // --- ( Static ) Field & Property --------------------------------------------------------------------------------------------------------------------------------------- //

    // 缓冲区大小
    private static readonly int BufferSize = BufferHandler.BufferSize;

    // --- Field & Property -------------------------------------------------------------------------------------------------------------------------------------------------- //

    /// <summary> 套接字消息附带信息 </summary>
    public SocketMessageInfo Info { get; } = new SocketMessageInfo();

    // 数据长度
    internal int Length { get; private set; }

    // 读写位置
    internal int Position {
        get => PrivatePosition;
        set {
            PrivatePosition = value;
            BufferIndex = PrivatePosition / BufferSize;
            BufferPosition = PrivatePosition % BufferSize;
        }
    }
    private int PrivatePosition;

    // 缓冲区组
    internal List<byte[]> Buffers;

    // 是否已释放 ( CAS )
    private int DisposedCAS;

    // 缓冲区读写索引
    private int BufferIndex;

    // 缓冲区读写位置
    private int BufferPosition;

    // 读取数据起始索引
    private int ReadDataStartIndex;

    // 是否为克隆消息
    private readonly bool IsCloneMessage;


    // --- ( Static ) Public Function ---------------------------------------------------------------------------------------------------------------------------------------- //

    // --- ( Static ) Internal & Protected Function -------------------------------------------------------------------------------------------------------------------------- //

    // --- ( Static ) Private Function --------------------------------------------------------------------------------------------------------------------------------------- //

    // --- Public Function --------------------------------------------------------------------------------------------------------------------------------------------------- //

    /// <summary> 创建套接字消息 </summary>
    public SocketMessage() => Buffers = new List<byte[]>() { BufferHandler.GetBuffer() };

    /// <summary> 从套接字消息中读取一个布尔值 </summary>
    public bool ReadBool() => ReadData( 1 )[ReadDataStartIndex] == 0 ? false : true;

    /// <summary> 从套接字消息中读取一个无符号字节 ( 0 ~ 255 ) </summary>
    public byte ReadByte() => ReadData( 1 )[ReadDataStartIndex];

    /// <summary> 从套接字消息中读取一段指定长度的字节数据 </summary>
    /// <param name="count">需要读取的数据长度 ( 单位 : byte )</param>
    public byte[] ReadBytes( int count ) => ReadData( count , true );

    /// <summary> 从套接字消息中读取一个带符号的 16 位整数 ( -32768 ~ 32767 ) </summary>
    public short ReadShort() => BitConverter.ToInt16( ReadData( 2 ) , ReadDataStartIndex );

    /// <summary> 从套接字消息中读取一个带符号的 32 位整数 ( -2147483648～2147483647 ) </summary>
    public int ReadInt() => BitConverter.ToInt32( ReadData( 4 ) , ReadDataStartIndex );

    /// <summary> 从套接字消息中读取一个带符号的 64 位整数 ( -2^63 ~ 2^63-1 ) </summary>
    public long ReadLong() => BitConverter.ToInt64( ReadData( 8 ) , ReadDataStartIndex );

    /// <summary> 从套接字消息中读取一个 IEEE 754 单精度（32 位）浮点数 </summary>
    public float ReadFloat() => BitConverter.ToSingle( ReadData( 4 ) , ReadDataStartIndex );

    /// <summary> 从套接字消息中读取一个 IEEE 754 双精度（64 位）浮点数 </summary>
    public double ReadDouble() => BitConverter.ToDouble( ReadData( 8 ) , ReadDataStartIndex );

    /// <summary> 从套接字消息中读取一个无符号的 16 位整数 ( 0 ~ 65535 ) </summary>
    public ushort ReadUnsignedShort() => BitConverter.ToUInt16( ReadData( 2 ) , ReadDataStartIndex );

    /// <summary> 从套接字消息中读取一个无符号的 32 位整数 ( 0 ~ 4294967295 ) </summary>
    public uint ReadUnsignedInt() => BitConverter.ToUInt32( ReadData( 4 ) , ReadDataStartIndex );

    /// <summary> 从套接字消息中读取一个 UTF-8 编码的字符串 </summary>
    public string ReadString() => Encoding.UTF8.GetString( ReadData( ReadInt() , true ) );

    /// <summary> 向套接字消息的末尾写入一个布尔值 </summary>
    public void WriteBool( bool data ) => WriteData( new byte[1] { data ? ( byte ) 1 : ( byte ) 0 } , 0 , 1 );

    /// <summary> 向套接字消息的末尾写入一个无符号字节 ( 0 ~ 255 ) </summary>
    public void WriteByte( byte data ) => WriteData( new byte[1] { data } , 0 , 1 );

    /// <summary> 向套接字消息的末尾写入一段字节数据 </summary>
    public void WriteBytes( byte[] data ) => WriteData( data , 0 , data.Length );

    /// <summary> 向套接字消息的末尾写入一个带符号的 16 位整数 ( -32768 ~ 32767 ) </summary>
    public void WriteShort( short data ) => WriteData( BitConverter.GetBytes( data ) , 0 , 2 );

    /// <summary> 向套接字消息的末尾写入一个带符号的 32 位整数 ( -2147483648～2147483647 ) </summary>
    public void WriteInt( int data ) => WriteData( BitConverter.GetBytes( data ) , 0 , 4 );

    /// <summary> 向套接字消息的末尾写入一个带符号的 64 位整数 ( -2^63 ~ 2^63-1 ) </summary>
    public void WriteLong( long data ) => WriteData( BitConverter.GetBytes( data ) , 0 , 8 );

    /// <summary> 向套接字消息的末尾写入一个 IEEE 754 单精度（32 位）浮点数 </summary>
    public void WriteFloat( float data ) => WriteData( BitConverter.GetBytes( data ) , 0 , 4 );

    /// <summary> 向套接字消息的末尾读取一个 IEEE 754 双精度（64 位）浮点数 </summary>
    public void WriteDouble( double data ) => WriteData( BitConverter.GetBytes( data ) , 0 , 8 );

    /// <summary> 向套接字消息的末尾写入一个无符号的 16 位整数 ( 0 ~ 65535 ) </summary>
    public void WriteUnsignedShort( ushort data ) => WriteData( BitConverter.GetBytes( data ) , 0 , 2 );

    /// <summary> 向套接字消息的末尾写入一个无符号的 32 位整数 ( 0 ~ 4294967295 ) </summary>
    public void WriteUnsignedInt( uint data ) => WriteData( BitConverter.GetBytes( data ) , 0 , 4 );

    /// <summary> 向套接字消息的末尾写入一个 UTF-8 编码的字符串 </summary>
    public void WriteString( string data ) {
        byte[] stringBytes = Encoding.UTF8.GetBytes( data );
        WriteInt( stringBytes.Length );
        WriteData( stringBytes , 0 , stringBytes.Length );
    }

    // --- Internal & Protected Function ------------------------------------------------------------------------------------------------------------------------------------- //

    // 用于创建克隆消息和空消息
    internal SocketMessage( bool isCloneMessage ) => IsCloneMessage = isCloneMessage;

    // 克隆套接字消息
    internal SocketMessage Clone() {
        SocketMessage clone = new SocketMessage( true ) { Length = Length , Buffers = Buffers };
        clone.Info.Status = Info.Status;
        return clone;
    }

    // 释放套接字消息
    internal void Dispose() {
        if( Interlocked.CompareExchange( ref DisposedCAS , 1 , 0 ) == 0 ) { // CAS
            if( !IsCloneMessage && Buffers != null ) BufferHandler.RecyclingBuffers( Buffers );
            Buffers = null;
            Info.Status = SocketMessageStatus.Disposed;
        }
    }

    // 从字节数组复制数据
    internal int CopyFromBytes( byte[] bytes , int startIndex , int count ) => WriteData( bytes , startIndex , count );

    // --- Private Function -------------------------------------------------------------------------------------------------------------------------------------------------- //

    // 读取数据
    private byte[] ReadData( int count , bool needReturnSingleArray = false ) {
        if( Info.Status == SocketMessageStatus.Disposed ) {
            ERROR( "SocketMessage 对象已释放, 无法进行读取操作" ,
            "Channel : " + Info.Channel ,
            "Protocol : " + Info.Protocol );
        } else if( Info.Status == SocketMessageStatus.WaitToSend ) {
            ERROR( "等待发送的 SocketMessage 对象无法进行读取操作" );
        } else if( Info.Status == SocketMessageStatus.Sending ) {
            ERROR( "正在发送的 SocketMessage 对象无法进行读取操作" );
        } else if( count > Length - Position ) {
            throw new Exception( "因遇到数据尾, 对 SocketMessage 对象的读取操作失败 ( Channel : " + Info.Channel + " , Protocol : " + Info.Protocol + " )" );
        }
        if( count < BufferSize - BufferPosition ) {
            // 当前缓冲区剩余数据足够读取
            if( needReturnSingleArray ) {
                // 需要返回独立数组
                byte[] readBytes = new byte[count];
                Array.Copy( Buffers[BufferIndex] , BufferPosition , readBytes , 0 , count );
                ReadDataStartIndex = 0;
                Position += count;
                return readBytes;
            } else {
                // 不需要返回独立数组 ( 优化性能 )
                ReadDataStartIndex = BufferPosition;
                Position += count;
                return Buffers[BufferIndex];
            }
        } else {
            // 当前缓冲区剩余数据不足读取
            // 读完当前缓冲区
            int readCount = count;
            byte[] readBytes = new byte[readCount];
            int readBytesPosition = BufferSize - BufferPosition; // 临时充当长度计数
            Array.Copy( Buffers[BufferIndex] , BufferPosition , readBytes , 0 , readBytesPosition );
            BufferIndex++;
            readCount -= readBytesPosition;
            // 循环读取完整缓冲区
            while( readCount >= BufferSize ) {
                Array.Copy( Buffers[BufferIndex] , 0 , readBytes , readBytesPosition , BufferSize );
                BufferIndex++;
                readBytesPosition += BufferSize;
                readCount -= BufferSize;
            }
            // 读取剩余数据
            if( readCount > 0 ) Array.Copy( Buffers[BufferIndex] , 0 , readBytes , readBytesPosition , readCount );
            ReadDataStartIndex = 0;
            Position += count;
            return readBytes;
        }
    }

    // 写入数据
    private int WriteData( byte[] bytes , int startIndex , int count ) {
        if( Info.Status == SocketMessageStatus.Disposed ) {
            ERROR( "SocketMessage 对象已释放, 无法进行写入操作" );
        } else if( Info.Status == SocketMessageStatus.Sending ) {
            ERROR( "正在发送的 SocketMessage 对象无法进行写入操作" ,
            "Channel : " + Info.Channel ,
            "Protocol : " + Info.Protocol );
        } else if( Info.Status == SocketMessageStatus.Received ) {
            ERROR( "接收到的 SocketMessage 对象无法进行写入操作" ,
            "Channel : " + Info.Channel ,
            "Protocol : " + Info.Protocol );
        }
        if( count < BufferSize - BufferPosition ) {
            // 当前缓冲区剩余空间足够写入
            Array.Copy( bytes , startIndex , Buffers[BufferIndex] , BufferPosition , count );
            Position += count;
            Length += count;
        } else {
            // 当前缓冲区剩余空间不足写入
            // 写完当前缓冲区
            int writeCount = count;
            int sourceBytesPosition = BufferSize - BufferPosition; // 临时充当长度计数
            Array.Copy( bytes , startIndex , Buffers[BufferIndex] , BufferPosition , sourceBytesPosition );
            Buffers.Add( BufferHandler.GetBuffer() );
            BufferIndex++;
            writeCount -= sourceBytesPosition;
            // 循环写入完整缓冲区
            while( writeCount >= BufferSize ) {
                Array.Copy( bytes , sourceBytesPosition + startIndex , Buffers[BufferIndex] , 0 , BufferSize );
                Buffers.Add( BufferHandler.GetBuffer() );
                BufferIndex++;
                sourceBytesPosition += BufferSize;
                writeCount -= BufferSize;
            }
            // 写入剩余数据
            if( writeCount > 0 ) Array.Copy( bytes , sourceBytesPosition + startIndex , Buffers[BufferIndex] , 0 , writeCount );
            Position += count;
            Length += count;
        }
        return count;
    }

}

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //