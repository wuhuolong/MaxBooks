using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;
using Net;

namespace Net
{
	// 作为 Client to Server 协议定义的基类
	public class C2SPackBase
	{
		private ushort protocol;
		ByteArray msgData;

		public C2SPackBase(ushort h)
		{
			msgData = new ByteArray();
			protocol = h;

			msgData.Put((ushort)protocol);// MsgID
		}

        ~C2SPackBase()
        {
            if(msgData != null)
            {
                msgData.Clear();
                msgData = null;
            }
        }

        /// <summary>
        /// Serializes the msg pack.
        /// </summary>
        /// <returns>The pack.</returns>
        /// <param name="c2sPack">C2s pack.</param>
        public byte[] SerializePack<T>(T c2sPack)
		{
            byte[] serialData = null;
            using (MemoryStream m = new MemoryStream())
			{
				Serializer.Serialize<T>(m, c2sPack);
				m.Position = 0;
				
				serialData = new byte[m.Length];
				m.Read(serialData, 0, (int)m.Length);
			}

			if (serialData != null)
				msgData.Put(serialData);

			return msgData.GetData();
		}

        /// <summary>
        /// 编辑器中模拟网络消息使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="c2sPack"></param>
        /// <returns></returns>
        public byte[] SerializePackT<T>(T c2sPack)
        {
            byte[] serialData = null;
            using (MemoryStream m = new MemoryStream())
            {
                Serializer.Serialize<T>(m, c2sPack);
                m.Position = 0;

                serialData = new byte[m.Length];
                m.Read(serialData, 0, (int)m.Length);
            }
        
            return serialData;
        }

        public byte[] SerializeLuaPack(byte[] serialData)
        {
            msgData.Put(serialData);
            return msgData.GetData();
        }
    };
	
	// 作为 Server to Client 协议定义的基类
	public class S2CPackBase
	{
        //private ushort protocol;

        /// <summary>
        /// Deserializes the pack.
        /// </summary>
        /// <returns>The pack.</returns>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T DeserializePack<T>(byte[] data)
		{
			//protocol = Utils.BitConverter.ToUInt16(data, 0);
					
			T s2c_pack = default(T);
			using (MemoryStream m = new MemoryStream(data))
			{
                s2c_pack = Serializer.Deserialize<T>(m);
			}

			return s2c_pack;
		}

        public static object DeserializePack(byte[] data, System.Type type)
        {
            object s2cPack;
            using (MemoryStream m = new MemoryStream(data))
            {
                s2cPack = ProtoBuf.Meta.RuntimeTypeModel.Default.Deserialize(m, null, type);
            }
            return s2cPack;
        }

        public static object DeserializeSendPack(byte[] data, System.Type type)
        {
            int hearSize = sizeof(ushort);
            byte[] packet = new byte[data.Length - hearSize];
            System.Array.Copy(data, hearSize, packet, 0, data.Length - hearSize);

            object s2cPack;
            using (MemoryStream m = new MemoryStream(packet)) {
                s2cPack = ProtoBuf.Meta.RuntimeTypeModel.Default.Deserialize(m, null, type);
            }

            return s2cPack;
        }
    }
}

