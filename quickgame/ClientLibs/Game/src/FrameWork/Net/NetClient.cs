using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using xc;

namespace Net
{
    public enum NetType
    {
        NT_TCP = 1,
        NT_UDP,
    };

	public class NetClient
	{
        protected NetType mNetType = NetType.NT_TCP;

		string mServerIP;
		int mServerPort;
		int mConnectMaxWaitTime = 10000;
		int mConnectWaitTime = 0;
		const int mSocketBuffer = 8 * 1024; // socket缓存区长度
        const int mRingBufferSize = 64 * 1024 + 8 * 1024 + 1024; // 64K 单条协议的最大长度 + socket缓存区长度
        const int mPackBufferSize = 64 * 1024; // 64K 单条协议的最大长度
        const int mDecompressBufferSize = 256 * 1024;// 256K 解压后协议的最大长度

        RingBuffer mRecvBuffer = new RingBuffer(mRingBufferSize); // 环形缓存区
        byte[] mBodyPack = new byte[mPackBufferSize]; // 单个包的Buffer
        byte[] mDecompressBuffer = new byte[mDecompressBufferSize]; // 单个包解压的Buffer

        MutiPacketHelp mMutiPacketHelp = null;
		
		public interface IListener
		{
            void OnNetConnect(NetType netType);

            void OnNetDisconnect(NetType netType, int e);

            void OnNetDataReply(NetType netType, ushort protocol, byte[] data);
		}
		
		public IListener mListener;
		
		public enum ENetState
		{
			ES_UnInit = 0,	// 未连接
			ES_Connecting,	// 正在连接
			ES_Connected,	// 已连接
			ES_Disconnect,	// 断开连接
		}
		protected ENetState mNetState;
		
		public ENetState NetState
		{
			get { return mNetState; }
		}
		
		// Packet header define.
		public struct NetCoreHeader
		{
			public ushort length;	// content's length
            public byte compress; // is pack compressed
		};

		protected object mLock;	// For multi-thread.
		
		protected enum EReplyType
		{
			RT_Connected = 0,
			RT_Disconnect,
			RT_DataReply,
		}
		
		protected struct Reply
		{
			public EReplyType Type;
            public ushort Protocol;
            public byte[] Data;
			public int e;

            public void Clear()
            {
                Data = null;
            }
		}

		protected LinkedList<Reply> mReplyList;
		protected Socket mSocket = null;
		
		public DBEncrypt Encrypt
		{
			get { return mEncrypt; } 
			set { mEncrypt = value; }
		}
			
		protected DBEncrypt mEncrypt;
		private IAsyncResult m_ar_Connect = null;
		private IAsyncResult m_ar_Recv = null;
		private IAsyncResult m_ar_Send = null;
		static protected NetClient msInstance;
		static protected NetClient msCrossInstance;
        static protected NetClient msUDPInstance;
		static protected bool msCrossToggle = false;

		static public bool CrossToggle
		{
			get { return msCrossToggle; }
			set { msCrossToggle = value; }
		}
		
		static public NetClient GetBaseClient()
		{
			if (NetClient.msInstance == null)
			{
                var netClient = new NetClient();
                netClient.mIsCrossClient = false;
                netClient.Encrypt = new DBEncrypt();
                NetClient.msInstance = netClient;
            }
			return NetClient.msInstance;
		}
        
		static public NetClient GetCrossClient()
		{
			if (NetClient.msCrossInstance == null)
			{
                var netClient = new NetClient();
                netClient.mIsCrossClient = true;
                netClient.Encrypt = new DBEncrypt();
                NetClient.msCrossInstance = netClient;
			}
			return NetClient.msCrossInstance;
		}

        static public NetClient BaseClient
        {
            get
            {
                return GetBaseClient();
            }
        }

        static public NetClient CrossClient
        {
            get
            {
                return GetCrossClient();
            }
        }

        static public bool HasCrossClient
        {
            get
            {
                return NetClient.msCrossInstance != null;
            }
        }

        bool mIsCrossClient = false;
		protected NetClient()
		{
			mLock = new object();

			mReplyList = new LinkedList<Reply>();
			mNetState = ENetState.ES_UnInit;
			mMutiPacketHelp = new MutiPacketHelp(this);
		}

        /// <summary>
        /// 根据传入的IPV4地址获取模拟的IPV6地址
        /// </summary>
        /// <param name="serverIp"></param>
        /// <param name="newServerIp"></param>
        /// <param name="ipType"></param>
        void GetIPType(String serverIp, out String newServerIp, out AddressFamily ipType)
        {
            ipType = AddressFamily.InterNetwork;
            newServerIp = serverIp;
            try
            {
                string mIPv6 = DBOSManager.getOSBridge().getIPv6(serverIp);
                if (!string.IsNullOrEmpty(mIPv6))
                {
                    string[] tmpStr = System.Text.RegularExpressions.Regex.Split(mIPv6, "&&");
                    if (tmpStr != null && tmpStr.Length >= 2)
                    {
                        string ipTypeStr = tmpStr[1];
                        if (ipTypeStr == "ipv6")
                        {
                            newServerIp = tmpStr[0];
                            ipType = AddressFamily.InterNetworkV6;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                GameDebug.LogError("GetIPv6 error:" + e);
            }
            
        }

		public void Start(string ip, int port)
		{
			lock (mLock)
			{
				if (mNetState == ENetState.ES_Connected || mNetState == ENetState.ES_Connecting)
					return;
				
                if(mEncrypt != null)
				    mEncrypt.ResetKey();
				mRecvBuffer.Clear();
				mNetState = ENetState.ES_UnInit;
				
				if (mSocket == null)
                {
                    AddressFamily address_family = AddressFamily.InterNetwork;

                    // get ip from host
                    try
                    {
                        bool addressParsed = false;
                        var host_address = Dns.GetHostAddresses(ip);
                        if (host_address.Length > 0)
                        {
                            foreach (var ip_address in host_address)
                            {
                                if (ip_address.AddressFamily == AddressFamily.InterNetworkV6)
                                {
                                    ip = ip_address.ToString();
                                    addressParsed = true;
                                    break;
                                }

                                if (!addressParsed && ip_address.AddressFamily == AddressFamily.InterNetwork)
                                {
                                    ip = ip_address.ToString();
                                    addressParsed = true;
                                }
                            }
                        }

                        if (!addressParsed)
                            ip = "0.0.0.0";
                    }
                    catch (Exception e)
                    {
                        UnityEngine.Debug.LogError(e.Message);
                        ip = "0.0.0.0";
                    }

                    // get ipv6 address
                    String new_server_ip = "";
                    GetIPType(ip, out new_server_ip, out address_family);
                    if (!string.IsNullOrEmpty(new_server_ip))
                        ip = new_server_ip;

                    UnityEngine.Debug.Log("begin connnect ip: " + ip + ":" + port);

                    if (mNetType == NetType.NT_TCP)
                        mSocket = new Socket(address_family, SocketType.Stream, ProtocolType.Tcp);
                    else
                        mSocket = new Socket(address_family, SocketType.Dgram, ProtocolType.Udp);
                }
				
				if (ip == mServerIP && port == mServerPort && mSocket.Connected)
				{
                    mListener.OnNetConnect(mNetType);
					return;
				}
			
				mServerIP = ip;
				mServerPort = port;
				Connect();
				
				mNetState = ENetState.ES_Connecting;
				mConnectWaitTime = 0;
			}
		}
		
		void Clear()
		{
			if (m_ar_Connect != null)
				m_ar_Connect.AsyncWaitHandle.Close();
			if (m_ar_Recv != null)
				m_ar_Recv.AsyncWaitHandle.Close();
			if (m_ar_Send != null)
				m_ar_Send.AsyncWaitHandle.Close();
			
            if(mEncrypt != null)
			    mEncrypt.ResetKey();

			mRecvBuffer.Clear();
            mMutiPacketHelp.Clear();// 断开网络连接的时候同时把之前没有发送的缓存清除
            mReplyList.Clear();
		}
		
		public void Stop()
		{
			lock (mLock)
			{
				Clear();
				
				if (mSocket != null)
				{
#if UNITY_ANDROID
                    if (Const.Region != RegionType.CHINA)
                    {
                        if (mSocket.Connected)
                            mSocket.Shutdown(SocketShutdown.Both);
                    }
#endif
                    mSocket.Close();	
					mSocket = null;
				}
				mNetState = ENetState.ES_UnInit;
			}
		}
		
		public class MutiPacketHelp
		{
			NetClient mParent;
			ByteArray mCacheData = new ByteArray();
			
			public MutiPacketHelp(NetClient p)
			{
				mParent = p;
			}
			
			public void Push(byte[] data)
            {
                if(mCacheData.Length <= 0)
                {
                    // Fill total len.
                    mCacheData.Put((ushort)data.Length);
                }

                // Fill content len.
                mCacheData.Put((ushort)data.Length);
                // Fill real content.
                mCacheData.Put(data, data.Length);
            }
			
			public void Send()
			{
                if (mCacheData.Length <= 0)
					return;
				
                var cache_data = mCacheData.GetData();
                var data_len = cache_data.Length - sizeof(ushort);

                // 发送包的内容整体加密，Encrypt为空时，表示不加密
                if (mParent.Encrypt != null)
                    mParent.Encrypt.SendEncode(cache_data, sizeof(ushort), data_len);

                // |--总长(2)--|--single len--|--single packet...--|
                var len_bytes = Utils.BitConverter.GetBytes((ushort)data_len); // 赋值总长数据
                Array.Copy(len_bytes, cache_data, len_bytes.Length);

                mParent.Send(cache_data);

                // 发送完后，清除数据
                mCacheData.Clear();
            }

            public void Clear()
            {
                mCacheData.Clear();
            }
		}

		private void SendData(byte[] oriData)
		{
			if (mSocket == null)
				return;

			mMutiPacketHelp.Push(oriData);
		}

		public void SendData<T>(ushort protocol, T c2sPack)
		{
#if UNITY_EDITOR
            if (GlobalConfig.Instance.IsDebugMode)
               GameDebug.Log(string.Format("C------>S:{0},({1},{2}) ", protocol, mServerIP, mServerPort));

#elif TEST_HOST && UNITY_ANDROID
            var pack_recorder = xc.Game.Instance.PackRecorder;
            if (!pack_recorder.NotRecordDict.ContainsKey(protocol)) {
                GameDebug.Log(string.Format("C------>S:{0},({1},{2}) ", protocol, mServerIP, mServerPort));
            }
#endif

            C2SPackBase c2sPackBase = new C2SPackBase(protocol);
			byte[] sendData = c2sPackBase.SerializePack(c2sPack);
			SendData(sendData);

#if UNITY_STANDALONE_WIN
            Game.Instance.PackRecorder.RecordSendPack(protocol, sendData);
#endif
        }

        public void SendData(ushort protocol, object c2sPack)
        {
#if UNITY_EDITOR
            if (GlobalConfig.Instance.IsDebugMode)
                GameDebug.Log(string.Format("C------>S:{0},({1},{2}) ", protocol, mServerIP, mServerPort));
#elif TEST_HOST && UNITY_ANDROID
            GameDebug.Log(string.Format("C------>S:{0},({1},{2}) ", protocol, mServerIP, mServerPort));
#endif
            C2SPackBase c2sPackBase = new C2SPackBase(protocol);
            byte[] sendData = c2sPackBase.SerializePack(c2sPack);
            SendData(sendData);

#if UNITY_STANDALONE_WIN
            Game.Instance.PackRecorder.RecordSendPack(protocol, sendData);
#endif
        }

        public void SendLuaData(ushort protocol, byte[] data)
        {
#if UNITY_EDITOR
            if (GlobalConfig.Instance.IsDebugMode)
                GameDebug.Log(string.Format("C------>S:{0},({1},{2}) ", protocol, mServerIP, mServerPort));
#elif TEST_HOST && UNITY_ANDROID
            GameDebug.Log(string.Format("C------>S:{0},({1},{2}) ", protocol, mServerIP, mServerPort));
#endif
            var c2sPackBase = new C2SPackBase(protocol);
            var sendData = c2sPackBase.SerializeLuaPack(data);
            SendData(sendData);

#if UNITY_STANDALONE_WIN
            Game.Instance.PackRecorder.RecordSendPack(protocol, sendData);
#endif
        }

        protected void Connect()
		{
            //var address = Dns.GetHostAddresses(mServerIP);
            //m_ar_Connect = mSocket.BeginConnect(address, mServerPort, new AsyncCallback(_scb_connect), mSocket);

            IPAddress ipAddress = IPAddress.Parse(mServerIP);
			IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, mServerPort);
            UnityEngine.Debug.Log("begin connnect ip2: " + mServerIP + ":" + mServerPort);
            m_ar_Connect = mSocket.BeginConnect(ipEndpoint, new AsyncCallback(_scb_connect), mSocket);
		}
		
		protected void Recv()
		{
			try
			{
				byte[] buf = new byte[mSocketBuffer];
				this.m_ar_Recv = mSocket.BeginReceive(buf, 0, mSocketBuffer, SocketFlags.None, new AsyncCallback(this._scb_recv), buf);
			} catch (SocketException e)
			{
				this.OnDisconnect(e.ErrorCode);
			}
		}
		
		protected void Send(byte[] data)
		{
			try
			{
				this.m_ar_Send = mSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(this._scb_send), mSocket);
			}
            catch (SocketException e)
			{
				this.OnDisconnect(e.ErrorCode);
			}
		}

        protected void _scb_send(IAsyncResult ar)
		{
			try
			{
				ar.AsyncWaitHandle.Close();
				((Socket)ar.AsyncState).EndSend(ar);
				this.m_ar_Send = null;
				
			}
            catch (SocketException e)
			{
				this.OnDisconnect(e.ErrorCode);
			}
		}

        protected void _scb_recv(IAsyncResult ar)
		{
			try
			{
				ar.AsyncWaitHandle.Close();
				byte[] buf = (byte[])ar.AsyncState;
				int len = mSocket.EndReceive(ar);
				this.m_ar_Recv = null;
				if (len > 0)
				{
                    mRecvBuffer.WriteBuffer(buf, 0, len);
					
					int proc = OnSplitPacket();
					if (proc > 0)
						mRecvBuffer.Remove(proc);
                    
					mSocket.BeginReceive(buf, 0, mSocketBuffer, SocketFlags.None, new AsyncCallback(this._scb_recv), buf);
				}
				else //说明网络断开, len = 0
				{	
					this.OnDisconnect(0);
				}
			}
            catch (SocketException e)
			{
                GameDebug.LogError(string.Format("_scb_recv SocketException message = {0}, errorcode = {1}", e.Message, e.ErrorCode));
                this.OnDisconnect(e.ErrorCode);
			}
		}
		
		protected void _scb_connect(IAsyncResult ar)
		{
			try
			{
                UnityEngine.Debug.Log("_scb_connect");

                ar.AsyncWaitHandle.Close();
				mSocket.EndConnect(ar);
				this.m_ar_Connect = null;
				
				this.OnConnect();
				
				//mSocket.Blocking = false;
				if (mSocket != null)
				{
					//mSocket.ReceiveTimeout = 0xbb8;
					mSocket.SendTimeout = 0xbb8;
					mSocket.ReceiveBufferSize = mSocketBuffer;
				}
				this.Recv();
			}
            catch (SocketException e)
			{
                UnityEngine.Debug.LogError("_scb_connect error: " + e.Message);
                this.OnDisconnect(e.ErrorCode);
			}
		}
		
		protected void OnConnect()
		{
			lock (mLock)
			{
				mNetState = ENetState.ES_Connected;
				
				Reply reply = new Reply();
				reply.Type = EReplyType.RT_Connected;
				mReplyList.AddLast(reply);
			}
		}
		
		protected void OnDisconnect(int e)
		{
			lock (mLock)
			{
                //GameDebug.Log("OnDisconnect");
				mNetState = ENetState.ES_Disconnect;
				Reply reply = new Reply();
				reply.Type = EReplyType.RT_Disconnect;
				reply.e = e;
				mReplyList.AddLast(reply);
			}
		}
		
        /// <summary>
        /// 获取包头的长度
        /// </summary>
        /// <returns></returns>
		int get_header_size()
		{
            return sizeof(ushort) + sizeof(byte);
		}
		
        /// <summary>
        /// 获取网络包的总长
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
		int get_packet_total_len(NetCoreHeader h)
		{
            return get_header_size() + h.length;
		}

        NetCoreHeader mHeadInfo = new NetCoreHeader();
        byte[] mHeadBuff = new byte[sizeof(ushort) + sizeof(byte)];
        ByteArray mHeadBytes = new ByteArray();

        protected int OnSplitPacket()
		{
            int size_remain = mRecvBuffer.Count;

            int header_size = get_header_size();
			int read = 0;
			
			while (size_remain > header_size)	// Recv data len must contain one header at least.
			{
                mRecvBuffer.ReadBuffer(mHeadBuff, read, 0, header_size);

                // Get header info.
                mHeadBytes.FillData(mHeadBuff);
                mHeadBytes.Get_(out mHeadInfo.length);
                mHeadBytes.Get_(out mHeadInfo.compress);
		
				// Get packet's len.
				int packet_len = get_packet_total_len(mHeadInfo);
				
				if (packet_len <= size_remain)
				{
                    mRecvBuffer.ReadBuffer(mBodyPack, read + header_size, 0, mHeadInfo.length);

                    ParseMutiPack(mBodyPack, mHeadInfo.compress == 1, mHeadInfo.length);
		
					size_remain -= packet_len;
					read += packet_len;
				}
				else
				{
					// Wait for more data.
					break;
				}
			}
		
			return read;
		}

        LZ4Sharp.ILZ4Decompressor mDecompress;

        /// <summary>
        /// 进行多包的解析
        /// </summary>
        /// <param name="body"></param>
        /// <param name="compress"></param>
        /// <param name="len"></param>
        protected void ParseMutiPack(byte[] body, bool compress, int len)
		{
            // 多包整体解密
            if(mEncrypt != null)
                mEncrypt.RecvDecode(body, len);

            int decompress_size = 0;// 解压后的数据大小
            byte[] decompress_date = null;
            if (compress)
            {
                if (mDecompress == null)
                    mDecompress = LZ4Sharp.LZ4DecompressorFactory.CreateNew();

                decompress_size = mDecompress.Decompress(body, 0, mDecompressBuffer, 0, len);
                decompress_date = mDecompressBuffer;
            }
            else
            {
                decompress_size = len;
                decompress_date = body;
            }
			
            int remain_buf = decompress_size;
            int cur_idx = 0;
            while(cur_idx < remain_buf)
			{
                ushort sinle_pack_len = Utils.BitConverter.ToUInt16(decompress_date, cur_idx);
				OnDataReply(decompress_date, cur_idx + sizeof(ushort), sinle_pack_len);

                cur_idx +=(sinle_pack_len+sizeof(ushort));
			}
		}
		
		protected void OnDataReply(byte[] data,int start_index, int len)
		{
			lock (mLock)
			{
				Reply reply = new Reply();
				reply.Type = EReplyType.RT_DataReply;
                reply.Protocol = Utils.BitConverter.ToUInt16(data, start_index);
                reply.Data = new byte[len-2];
                Array.Copy(data, start_index + 2, reply.Data, 0, len - 2);

				mReplyList.AddLast(reply);
			}
		}
		
		public void Update()
		{
			if (mListener == null)
				return;
			
			lock (mLock)
			{	
				if (mNetState == ENetState.ES_Connecting)
				{
					mConnectWaitTime += (int)(UnityEngine.Time.deltaTime * 1000.0f);
					if (mConnectWaitTime > mConnectMaxWaitTime)
					{
						mNetState = ENetState.ES_Disconnect;
						if (mSocket != null)
						{
#if UNITY_ANDROID
                            if (Const.Region != RegionType.CHINA)
                            {
                                if (mSocket.Connected)
                                    mSocket.Shutdown(SocketShutdown.Both);
                            }
#endif
                            mSocket.Close();							
							mSocket = null;
						}
						
						mListener.OnNetDisconnect(mNetType, -1);
					}
				}
				
				if (mNetState == ENetState.ES_Connected && mSocket != null && !mSocket.Connected)
					this.OnDisconnect(-1);
				
				while (mReplyList.Count > 0)
				{
					LinkedListNode<Reply> replyNode = mReplyList.First;
					switch (replyNode.Value.Type)
					{
						case EReplyType.RT_Connected:
                            mListener.OnNetConnect(mNetType);
							break;
						
						case EReplyType.RT_Disconnect:
                            mListener.OnNetDisconnect(mNetType, replyNode.Value.e);
							break;
						
						case EReplyType.RT_DataReply:
                            mListener.OnNetDataReply(mNetType, replyNode.Value.Protocol, replyNode.Value.Data);
							break;
					
						default:
							break;
					}

                    replyNode.Value.Clear();
                    mReplyList.RemoveFirst();
				}
				
				if (mNetState == ENetState.ES_Disconnect)
					Clear();
				
				if (mSocket != null)
					mMutiPacketHelp.Send();
			}
		}
	}
}