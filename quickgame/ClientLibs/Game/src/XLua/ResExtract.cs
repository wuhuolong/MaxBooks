using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

/// <summary>
/// 资源打包类，将bundle文件存放成一个文件集合
/// </summary>
public class ResExtract
{
    // HearInfo
    // HeadSize(4 byte) + isBinary(1 byts) + (fileNameLength(1 byte) + fileNameData + fileOffset(4 byte))
    public class HeadInfo
    {
        public int headSize;
        public bool isBinary;
        public Dictionary<string, int> fileOffsets = new Dictionary<string, int>();
    }

    /// <summary>
    /// 所有文件的数据
    /// </summary>
    byte[] mTotalBytes;

    /// <summary>
    /// 文件的总数
    /// </summary>
    int mFileCount = 0;

    /// <summary>
    /// 已经获取的文件数据
    /// </summary>
    Dictionary<string, byte[]> mFileBytes = new Dictionary<string, byte[]>();

    /// <summary>
    /// 文件头信息
    /// </summary>
    HeadInfo mHeadInfo;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="unpackPath"></param>
    public ResExtract(byte[] bytes)
    {
        mTotalBytes = bytes;

        int headSize = BitConverter.ToInt32(bytes, 0);
        bool isBinary = BitConverter.ToBoolean(bytes, 4);

        mHeadInfo = new HeadInfo();
        mHeadInfo.headSize = headSize;
        mHeadInfo.isBinary = isBinary;

        // 获取文件名和文件位置
        int fileCount = 0;
        int index = 5;
        while (index < headSize + 4)
        {
            var fileNameLength = (byte)BitConverter.ToChar(bytes, index);
            index += 1;

            var fileName = Encoding.UTF8.GetString(bytes, index, fileNameLength);
            index += fileNameLength;

            var fileOffset = BitConverter.ToInt32(bytes, index);
            index += 4;

            mHeadInfo.fileOffsets[fileName] = fileOffset;
            fileCount++;
        }

        mFileCount = fileCount;
    }

    /// <summary>
    /// 获取指定文件的二进制数据
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public byte[] GetFileBytes(string fileName)
    {
        if (mHeadInfo == null)
        {
            Debug.LogError("HeadInfo is null");
            return null;
        }

        int fileOffset = 0;
        byte[] fileBytes = null;
        if (!mFileBytes.TryGetValue(fileName, out fileBytes))
        {
            if (mHeadInfo.fileOffsets.TryGetValue(fileName, out fileOffset))
            {
                var fileBytesLen = BitConverter.ToInt32(mTotalBytes, fileOffset);
                fileBytes = new byte[fileBytesLen];
                Array.Copy(mTotalBytes, fileOffset + 4, fileBytes, 0, fileBytesLen);
                mFileBytes[fileName] = fileBytes;
                //Debug.Log("lua extract count:" + mFileBytes.Count);
            }
            else
                Debug.LogError("GetFileBytes cannot find file: " + fileName);
        }

        return fileBytes;
    }

    /// <summary>
    /// 是否存在指定的文件
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public bool IsExistFile(string fileName)
    {
        if (mHeadInfo == null)
        {
            Debug.LogError("HeadInfo is null");
            return false;
        }

        return mHeadInfo.fileOffsets.ContainsKey(fileName);
    }

    public bool IsBinary
    {
        get
        {
            if (mHeadInfo != null)
                return mHeadInfo.isBinary;
            else
                return false;
        }
    }
    /// <summary>
    /// 销毁
    /// </summary>
    public void Destroy()
    {
        if(mFileBytes != null)
        {
            mFileBytes.Clear();
            mFileBytes = null;
        }
        
        mFileCount = 0;
        if(mHeadInfo != null)
        {
            mHeadInfo.fileOffsets.Clear();
            mHeadInfo = null;
        }

        mTotalBytes = null;
    }

    static int SwapInt32(int n)
    {
        return (int)(((SwapInt16((short)n) & 0xffff) << 0x10) | (SwapInt16((short)(n >> 0x10)) & 0xffff));
    }

    static short SwapInt16(short n)
    {
        return (short)(((n & 0xff) << 8) | ((n >> 8) & 0xff));
    }
}