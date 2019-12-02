// --- NEROKING.COM ------------------------------------------------------------------------------------------------------------------------------------------------------- //

using static TraceTool;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;

/// <summary> 字节数组 </summary>
public class ByteArray : NeroObject {

    // --- Field & Property ----------------------------------------------------------------------------------------------------------------------------------------------- //

    /// <summary> 客户端运行平台编码模式 </summary>
    public static EndianMode LocalEndian { get; } = BitConverter.IsLittleEndian == true ? EndianMode.LITTLE : EndianMode.BIG;

    /// <summary> 编码模式( 默认值匹配客户端运行平台编码模式 ) </summary>
    public EndianMode Endian { get; set; } = BitConverter.IsLittleEndian == true ? EndianMode.LITTLE : EndianMode.BIG;

    /// <summary> 字节数组内的总字节数 </summary>
    public int Length => InnerList.Count;

    /// <summary> 字节数组从读写位置 ( Position ) 到数组末尾的字节数 </summary>
    public int Available => InnerList.Count - _Position;

    /// <summary> 字节数组是否被 Zip 压缩 </summary>
    public bool Ziped { get; private set; } = false;

    /// <summary> 字节数组的读写位置 </summary>
    public int Position {
        get { return _Position; }
        set {
            if( value < 0 || value > InnerList.Count || ( InnerList.Count != 0 && value == InnerList.Count ) ) {
                ERROR( "设置 ByteArray 对象的 Position 属性时，赋值超限 ( ByteArray Length: " + Length + " , Target Position: " + value + " )" );
            }
            _Position = value;
        }
    }
    private int _Position = 0;

    /// <summary> 从字节数组读写指定索引位置的字节值 </summary>
    public byte this[int index] {
        get {
            if( index < 0 || index > InnerList.Count || ( InnerList.Count != 0 && index == InnerList.Count ) ) {
                ERROR( "读取 ByteArray 对象指定索引位置的字节数据时，索引超限 ( ByteArray Length: " + Length + " , Read Index: " + index + " )" );
            }
            return InnerList[index];
        }
        set {
            if( index < 0 || index > InnerList.Count || ( InnerList.Count != 0 && index == InnerList.Count ) ) {
                ERROR( "写入 ByteArray 对象指定索引位置的字节数组时，索引超限 ( ByteArray Length: " + Length + " , Write Index: " + index + " )" );
            }
            InnerList[index] = value;
        }
    }

    // 内部列表
    private List<byte> InnerList;

    // --- Public & Protected Function ------------------------------------------------------------------------------------------------------------------------------------ //

    /// <summary> 创建字节数组 </summary>
    /// <param name="bytes">需要填充到字节数组里的字节数据，默认为 null 则创建一个空的字节数组</param>
    public ByteArray( byte[] bytes = null ) => InnerList = bytes != null ? new List<byte>( bytes ) : new List<byte>( 1024 );

    /// <summary> 以 byte[] 形式复制并返回该字节数组的全部字节数据 ( 此方法既不受 Position 属性影响 , 也不会改变 Position 属性 ) </summary>
    public byte[] ToArray() => InnerList.ToArray();

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个布尔值 </summary>
    public bool ReadBool() {
        CheckZiped();
        CheckAvailable( 1 );
        try { return InnerList[_Position] == 0 ? false : true; } finally { _Position += 1; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个无符号字节 ( 0 ~ 255 ) </summary>
    public byte ReadByte() {
        CheckZiped();
        CheckAvailable( 1 );
        try { return InnerList[_Position]; } finally { _Position += 1; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一段指定长度的字节数据 </summary>
    /// <param name="readCount"> 需要读取的数据长度 </param>
    /// <param name="targetBytes">目标 byte[] 对象，默认为 null 时自动创建一个 byte[] 对象写入数据并返回</param>
    /// <param name="targetIndex">目标 byte[] 对象的写入位置，默认为 0</param>
    public byte[] ReadBytes( int readCount , byte[] targetBytes = null , int targetIndex = 0 ) {
        if( readCount <= 0 ) ERROR( "对 ByteArray 对象执行 ReadBytes 操作时，参数 readCount 必须大于 0 " );
        CheckZiped();
        CheckAvailable( readCount );
        targetBytes = targetBytes ?? ( new byte[readCount] );
        InnerList.CopyTo( _Position , targetBytes , targetIndex , readCount );
        try { return targetBytes; } finally { _Position += readCount; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个带符号的 16 位整数 ( -32768 ~ 32767 ) </summary>
    public short ReadShort() {
        CheckZiped();
        CheckAvailable( 2 );
        try { return BitConverter.ToInt16( MatchEndian( InnerList.GetRange( _Position , 2 ).ToArray() ) , 0 ); } finally { _Position += 2; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个带符号的 32 位整数 ( -2147483648～2147483647 ) </summary>
    public int ReadInt() {
        CheckZiped();
        CheckAvailable( 4 );
        try { return BitConverter.ToInt32( MatchEndian( InnerList.GetRange( _Position , 4 ).ToArray() ) , 0 ); } finally { _Position += 4; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个带符号的 64 位整数 ( -2^63 ~ 2^63-1 ) </summary>
    public long ReadLong() {
        CheckZiped();
        CheckAvailable( 8 );
        try { return BitConverter.ToInt64( MatchEndian( InnerList.GetRange( _Position , 8 ).ToArray() ) , 0 ); } finally { _Position += 8; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个 IEEE 754 单精度 ( 32 位 )浮点数 </summary>
    public float ReadFloat() {
        CheckZiped();
        CheckAvailable( 4 );
        try { return BitConverter.ToSingle( MatchEndian( InnerList.GetRange( _Position , 4 ).ToArray() ) , 0 ); } finally { _Position += 4; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个 IEEE 754 双精度 ( 64 位 )浮点数 </summary>
    public double ReadDouble() {
        CheckZiped();
        CheckAvailable( 8 );
        try { return BitConverter.ToDouble( MatchEndian( InnerList.GetRange( _Position , 8 ).ToArray() ) , 0 ); } finally { _Position += 8; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个无符号的 16 位整数 ( 0 ~ 65535 ) </summary>
    public ushort ReadUnsignedShort() {
        CheckZiped();
        CheckAvailable( 2 );
        try { return BitConverter.ToUInt16( MatchEndian( InnerList.GetRange( _Position , 2 ).ToArray() ) , 0 ); } finally { _Position += 2; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个无符号的 32 位整数 ( 0 ~ 4294967295 ) </summary>
    public uint ReadUnsignedInt() {
        CheckZiped();
        CheckAvailable( 4 );
        try { return BitConverter.ToUInt32( MatchEndian( InnerList.GetRange( _Position , 4 ).ToArray() ) , 0 ); } finally { _Position += 4; }
    }

    /// <summary> 从字节数组的读写位置 ( Position ) 读取一个 UTF-8 编码的字符串 ( 实现：先读取一个 int 作为字符串的字节数，再根据字节数读取字符串内容 ) </summary>
    public string ReadString() {
        CheckZiped();
        // 读取长度
        CheckAvailable( 4 );
        int readCount = BitConverter.ToInt32( MatchEndian( InnerList.GetRange( _Position , 4 ).ToArray() ) , 0 );
        _Position += 4;
        // 读取内容
        CheckAvailable( readCount );
        try { return Encoding.UTF8.GetString( MatchEndian( InnerList.GetRange( _Position , readCount ).ToArray() ) ); } finally { _Position += readCount; }
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一个布尔值 </summary>
    public void WriteBool( bool data ) {
        CheckZiped();
        InnerList.Insert( _Position , data ? (byte)1 : (byte)0 );
        _Position += 1;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一个无符号字节 ( 0 ~ 255 ) </summary>
    public void WriteByte( byte data ) {
        CheckZiped();
        InnerList.Insert( _Position , data );
        _Position += 1;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一段字节数据 </summary>
    public void WriteBytes( byte[] data ) {
        CheckZiped();
        InnerList.InsertRange( _Position , data );
        _Position += data.Length;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一个带符号的 16 位整数 ( -32768 ~ 32767 ) </summary>
    public void WriteShort( short data ) {
        CheckZiped();
        InnerList.InsertRange( _Position , MatchEndian( BitConverter.GetBytes( data ) ) );
        _Position += 2;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一个带符号的 32 位整数 ( -2147483648～2147483647 ) </summary>
    public void WriteInt( int data ) {
        CheckZiped();
        InnerList.InsertRange( _Position , MatchEndian( BitConverter.GetBytes( data ) ) );
        _Position += 4;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一个带符号的 64 位整数 ( -2^63 ~ 2^63-1 ) </summary>
    public void WriteLong( long data ) {
        CheckZiped();
        InnerList.InsertRange( _Position , MatchEndian( BitConverter.GetBytes( data ) ) );
        _Position += 8;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一个 IEEE 754 单精度 ( 32 位 )浮点数 </summary>
    public void WriteFloat( float data ) {
        CheckZiped();
        InnerList.InsertRange( _Position , MatchEndian( BitConverter.GetBytes( data ) ) );
        _Position += 4;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 读取一个 IEEE 754 双精度 ( 64 位 )浮点数 </summary>
    public void WriteDouble( double data ) {
        CheckZiped();
        InnerList.InsertRange( _Position , MatchEndian( BitConverter.GetBytes( data ) ) );
        _Position += 8;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一个无符号的 16 位整数 ( 0 ~ 65535 ) </summary>
    public void WriteUnsignedShort( ushort data ) {
        CheckZiped();
        InnerList.InsertRange( _Position , MatchEndian( BitConverter.GetBytes( data ) ) );
        _Position += 2;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一个无符号的 32 位整数 ( 0 ~ 4294967295 ) </summary>
    public void WriteUnsignedInt( uint data ) {
        CheckZiped();
        InnerList.InsertRange( _Position , MatchEndian( BitConverter.GetBytes( data ) ) );
        _Position += 4;
    }

    /// <summary> 向字节数组的读写位置 ( Position ) 写入一个 UTF-8 编码的字符串 ( 实现：先写入一个 int 作为字符串的字节数，再根据字节数写入字符串内容 ) </summary>
    public void WriteString( string data ) {
        CheckZiped();
        // 读取内容
        byte[] stringBytes = Encoding.UTF8.GetBytes( data );
        // 写入长度
        InnerList.InsertRange( _Position , MatchEndian( BitConverter.GetBytes( stringBytes.Length ) ) );
        _Position += 4;
        // 写入内容
        InnerList.InsertRange( _Position , stringBytes );
        _Position += stringBytes.Length;
    }

    /// <summary> 以 GZip 算法压缩字节数组 ( 压缩操作会使 Position 属性重置为 0 )</summary>
    public void ZipCompress() {
        CheckZiped();
        Ziped = true;
        MemoryStream inputStream = new MemoryStream();
        GZipOutputStream outputStream = new GZipOutputStream( inputStream );
        outputStream.Write( InnerList.ToArray() , 0 , InnerList.Count );
        InnerList = new List<byte>( inputStream.ToArray() );
        inputStream.Close();
        outputStream.Close();
        _Position = 0;
    }

    /// <summary> 以 GZip 算法解压字节数组 ( 解压操作会使 Position 属性重置为 0 )</summary>
    public void ZipDecompress() {
        if( !Ziped ) ERROR( "该 ByteArray 对象未压缩，无法执行解压操作" );
        Ziped = false;
        GZipInputStream inputStream = new GZipInputStream( new MemoryStream( InnerList.ToArray() ) );
        MemoryStream outputStream = new MemoryStream();
        byte[] readBytes = new byte[4096];
        int readBytesCount = 0;
        while( ( readBytesCount = inputStream.Read( readBytes , 0 , readBytes.Length ) ) > 0 ) outputStream.Write( readBytes , 0 , readBytesCount );
        InnerList = new List<byte>( outputStream.ToArray() );
        inputStream.Close();
        outputStream.Close();
        _Position = 0;
    }

    // --- Internal Function ---------------------------------------------------------------------------------------------------------------------------------------------- //

    // --- Private Function ----------------------------------------------------------------------------------------------------------------------------------------------- //

    // 检查可读字节数
    private void CheckAvailable( int readCount ) {
        if( readCount < 0 || readCount > Available ) ERROR( "因遇到数据尾，对 ByteArray 对象的读取操作失败" );
    }

    // 检查是否压缩
    private void CheckZiped() {
        if( Ziped ) ERROR( "该 ByteArray 对象已使用 ZipCompress 方法压缩，请先使用 ZipDecompress 方法解压后再执行其他操作" );
    }

    // 匹配编码模式
    private byte[] MatchEndian( byte[] bytes ) {
        if( Endian != LocalEndian ) Array.Reverse( bytes );
        return bytes;
    }

}

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ //