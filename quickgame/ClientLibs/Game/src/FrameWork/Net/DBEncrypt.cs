using System;
using System.Collections;
using System.Collections.Generic;
using Net;

namespace Net
{
	public class DBEncrypt
	{
		const int KEY_LEN = 8;
		const int DATA_MIN_LEN = 4;
		const string SECRET_SEND_KEY = "7918cae8";
		const string SECRET_RECV_KEY = "7918cae8";
		byte[] mDynamicSendKey = new byte[KEY_LEN];
        UInt32[] mSendKeyTmp = new UInt32[2];
        byte[] mDynamicRecvKey = new byte[KEY_LEN];
        UInt32[] mRecvKeyTmp = new UInt32[2];
        byte[] mRecvOldkey = new byte[KEY_LEN];

        public DBEncrypt()
		{
			mDynamicSendKey = System.Text.Encoding.ASCII.GetBytes(SECRET_SEND_KEY.ToCharArray());
			mDynamicRecvKey = System.Text.Encoding.ASCII.GetBytes(SECRET_RECV_KEY.ToCharArray());
		}

		void encode(byte[] data, int startIndex, int len, byte[] key)
		{ 
			int i;
			
			data [startIndex + 0] = (byte)(data [startIndex + 0] ^ key [0]);
			
			for (i = 1; i < len; i++)
			{
				data [startIndex + i] = (byte)(data [startIndex + i] ^ data [startIndex + i - 1] ^ key [i & 7]);
			}
			
			data [startIndex + 3] = (byte)(data [startIndex + 3] ^ key [2]);
			data [startIndex + 2] = (byte)(data [startIndex + 2] ^ data [startIndex + 3] ^ key [3]);
			data [startIndex + 1] = (byte)(data [startIndex + 1] ^ data [startIndex + 2] ^ key [4]);
			data [startIndex + 0] = (byte)(data [startIndex + 0] ^ data [startIndex + 1] ^ key [5]);
		}
		
		void decode(byte[] data, int len, byte[] key)
		{
			int count = len - 1;
			
			int i;
			
			data [0] = (byte)(data [0] ^ data [1] ^ key [5]);
			data [1] = (byte)(data [1] ^ data [2] ^ key [4]);
			data [2] = (byte)(data [2] ^ data [3] ^ key [3]);
			data [3] = (byte)(data [3] ^ key [2]);
			
			for (i = count; i > 0; i--)
			{
				data [i] = (byte)(data [i] ^ data [i - 1] ^ key [i & 7]);
			}
			
			data [0] = (byte)(data [0] ^ key [0]);
		}
		
		void change_key(byte[] data, int startIndex, byte[] key, UInt32[] newTmpKey)
		{
			if (key.Length != KEY_LEN)
				return;

			UInt32 uintData = System.BitConverter.ToUInt32(data, startIndex);

			for (int i = 0; i < newTmpKey.Length; ++i)
			{
                newTmpKey[i] = System.BitConverter.ToUInt32(key, i * sizeof(UInt32));
			}

            newTmpKey[0] ^= uintData;
            newTmpKey[1] ^= 0xC3C3C3C3;

			for (int i = 0; i< newTmpKey.Length; ++i)
			{
				byte[] bytes = System.BitConverter.GetBytes(newTmpKey[i]);
				Array.Copy(bytes, 0, key, i * 4, bytes.Length);
			}
		}
		
		public void SendEncode(byte[] data, int startIndex, int len)
        {
			if (len < DATA_MIN_LEN)
				return;

			encode(data, startIndex, len, mDynamicSendKey);
			change_key(data, startIndex, mDynamicSendKey, mSendKeyTmp);
		}

        public void RecvDecode(byte[] data, int len)
		{
			if (len < DATA_MIN_LEN)
				return;
			
			Array.Copy(mDynamicRecvKey, mRecvOldkey, KEY_LEN);
			change_key(data, 0, mDynamicRecvKey, mRecvKeyTmp);
			decode(data, len, mRecvOldkey);
		}

		public void ResetKey()
		{
			mDynamicSendKey = System.Text.Encoding.ASCII.GetBytes(SECRET_SEND_KEY.ToCharArray());
			mDynamicRecvKey = System.Text.Encoding.ASCII.GetBytes(SECRET_RECV_KEY.ToCharArray());
		}
	}
}