//using System;
using Utils;
using System.Collections;
using System.Collections.Generic;

namespace Net
{
	public class ByteArray
	{
		public int mRP;
		private List<byte> mData;
		
		public int Length
		{
			get { return mData.Count; }
		}

		public ByteArray()
		{
			mRP = 0;
			mData = new List<byte>();
		}
		
		public ByteArray(byte[] data)
		{
			mRP = 0;
			mData = new List<byte>(data.Length);
			
			Put(data);
		}

        /// <summary>
        /// 使用data来进行数据填充,旧数据并不删除
        /// </summary>
        /// <param name="data"></param>
        public void FillData(List<byte> data)
        {
            mRP = 0;

            if (data == null)
            {
                mData = new List<byte>();
            }
            else
            {
                if (mData == null)
                    mData = new List<byte>(data);
                else
                {
                    // 如果长度比需要填充的数据长
                    if (mData.Count >= data.Count)
                    {
                        for(int i = 0; i < data.Count; ++i)
                        {
                            mData[i] = data[i];
                        }
                    }
                    else
                    {
                        int j = 0;
                        for (; j < mData.Count; ++j)
                        {
                            mData[j] = data[j];
                        }

                        for(; j < data.Count; ++j)
                        {
                            mData.Add(data[j]);
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// 使用data来进行数据填充,旧数据并不删除
        /// </summary>
        /// <param name="data"></param>
        public void FillData(byte[] data)
        {
            mRP = 0;

            if (data == null)
            {
                mData = new List<byte>();
            }
            else
            {
                if (mData == null)
                    mData = new List<byte>(data);
                else
                {
                    // 如果长度比需要填充的数据长
                    if (mData.Count >= data.Length)
                    {
                        for (int i = 0; i < data.Length; ++i)
                        {
                            mData[i] = data[i];
                        }
                    }
                    else
                    {
                        int j = 0;
                        for (; j < mData.Count; ++j)
                        {
                            mData[j] = data[j];
                        }

                        for (; j < data.Length; ++j)
                        {
                            mData.Add(data[j]);
                        }
                    }
                }
            }

        }

        public void Clear()
		{
			mRP = 0;
			mData.Clear();
		}
		
		public byte[] GetData()
		{
			return mData.ToArray();
		}
		
		public byte[] GetRange(int start, int count)
		{
			return mData.GetRange(start, count).ToArray();
		}
		
		public void Put(byte[] v)
		{
            mData.AddRange(v);
		}

		public void Put(byte[] v, int len)
		{
			for (int i=0; i<v.Length && i<len; i++)
			{
				mData.Add(v [i]);
			}
		}
		
		public void Put(ushort v)
		{
			byte[] _v = BitConverter.GetBytes(v);
			
			Put(_v);
		}

		public void Get(out ushort res, int start)
		{
			byte[] data = mData.GetRange(start, sizeof(ushort)).ToArray();
			
			res = BitConverter.ToUInt16(data, 0);
		}
		
		public void Get(out byte res, int pos)
		{
			res = mData [pos];
		}

		public void Get_(out ushort res)
		{
			Get(out res, mRP);
			mRP += sizeof(ushort);
		}
		
		public void Get_(out byte res)
		{
			Get(out res, mRP);
			mRP += sizeof(byte);
		}
	}
}
