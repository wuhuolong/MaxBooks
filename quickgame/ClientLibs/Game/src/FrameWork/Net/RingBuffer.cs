//-----------------------------------------------
// File: RingBuffer.cs
// Desc: 环形缓存区
// Author: raorui
// Date: 2018.11.6
//-----------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Net
{
    public class RingBuffer
    {
        /// <summary>
        /// 存放内存的数组
        /// </summary>
        private byte[] mBuffer;

        /// <summary>
        /// 数据开始索引
        /// </summary>
        private int mStartIndex;

        /// <summary>
        /// 数据结束索引,指向数据末尾后的元素
        /// </summary>
        private int mEndIndex;

        /// <summary>
        /// 当前存放数据的字节数
        /// </summary>
        private int mDataCount;

        public RingBuffer(int bufferSize)
        {
            mStartIndex = 0;
            mEndIndex = 0;
            mDataCount = 0;
            mBuffer = new byte[bufferSize];
        }

        /// <summary>
        /// 当前数据的字节数
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get
            {
                return mDataCount;
            }
        }

        public void Clear()
        {
            mDataCount = 0;
            mStartIndex = 0;
            mEndIndex = 0;
        }

        /// <summary>
        /// 将数据写入环形缓存区结尾
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset">buffer的offset索引</param>
        /// <param name="count">buffer的字节数</param>
        public void WriteBuffer(byte[] buffer, int offset, int count)
        {
            var remainCount = mBuffer.Length - mDataCount;

            if (remainCount >= count)// 剩余空间足够
            {
                if (mEndIndex + count < mBuffer.Length)// 数据结束索引还未到结尾
                {
                    Array.Copy(buffer, offset, mBuffer, mEndIndex, count);

                    mEndIndex += count;
                    mDataCount += count;
                }
                else// 数据结束索引超出结尾
                {
                    var overflowLen = (mEndIndex + count) - mBuffer.Length; // 超出索引长度
                    var endBufferLen = count - overflowLen; // 填充在末尾的数据长度
                    Array.Copy(buffer, offset, mBuffer, mEndIndex, endBufferLen);

                    // 结束索引重置为0
                    mEndIndex = 0;
                    mDataCount += endBufferLen;

                    // overflowLen为0时，表示缓存区刚好填满,否则需要继续拷贝剩余的数据
                    if (overflowLen != 0)
                    {
                        offset += endBufferLen;
                        Array.Copy(buffer, offset, mBuffer, mEndIndex, overflowLen);
                        mEndIndex += overflowLen;
                        mDataCount += overflowLen;
                    }
                }
            }
            else// 缓存溢出，暂不处理
            {
                
            }
        }

        /// <summary>
        /// 从起始位置开始,读取指定大小的数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="startIndex">缓冲区的开始位置</param>
        /// <param name="offset">buffer的offset索引</param>
        /// <param name="count">buffer的字节数</param>
        public void ReadBuffer(byte[] buffer, int startIndex, int offset, int count)
        {
            if (count > mDataCount)// 超出当前缓存数据大小
                return;

            // 计算数据开始的索引位置
            var dataIndex = mStartIndex + startIndex;
            if (dataIndex >= mBuffer.Length)
            {
                dataIndex = dataIndex - mBuffer.Length;
            }

            if (dataIndex + count < mBuffer.Length)// 读取数据未到缓存区结尾
            {
                Array.Copy(mBuffer, dataIndex, buffer, offset, count);
            }
            else
            {
                var overflowLen = (dataIndex + count) - mBuffer.Length;// 超出索引长度
                var endBufferLen = count - overflowLen;// 末尾的数据长度
                Array.Copy(mBuffer, dataIndex, buffer, offset, endBufferLen);

                // overflowLen为0时，表示缓存区刚好填满,否则需要继续从0开始拷贝剩余的数据
                if (overflowLen != 0)
                {
                    offset += endBufferLen;
                    Array.Copy(mBuffer, 0, buffer, offset, overflowLen);
                }
            }
        }

        /// <summary>
        /// 从起始位置开始,清除指定大小的数据
        /// </summary>
        /// <param name="count"></param>
        public void Remove(int count)
        {
            if (count >= mDataCount) // 如果需要清理的数据大于缓存数据大小，则全部清理
            {
                mDataCount = 0;
                mStartIndex = 0;
                mEndIndex = 0;
            }
            else
            {
                if (mStartIndex + count >= mBuffer.Length)
                {
                    mStartIndex = (mStartIndex + count) - mBuffer.Length;
                }
                else
                {
                    mStartIndex += count;
                }

                mDataCount -= count;
            }
        }
    }
}