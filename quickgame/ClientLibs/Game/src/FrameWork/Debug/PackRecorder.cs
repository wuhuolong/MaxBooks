using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace xc
{
    /// <summary>
    /// 消息包记录
    /// </summary>
    public class PackRecorder
    {
        public class PackData
        {
            public static readonly JsonSerializerSettings settings = new JsonSerializerSettings();

            public enum EPackType
            {
                Send = 1,
                Recv = 2,
            }

            public ushort Protocol { get; protected set; }
            public object Pack { get; protected set; }
            public EPackType PackType { get; protected set; }

            public bool isJsonify = false;
            public Type Type;
            public string jsonStr;

            public bool isJsonify2 = false;
            public string jsonStr2;

            public PackData(ushort protocol, object pack, EPackType pack_type, Type type)
            {
                Protocol = protocol;
                Pack = pack;
                PackType = pack_type;
                this.Type = type;
            }

            public string GetJson()
            {
                if (isJsonify)
                {
                    return jsonStr;
                }
                else
                {
                    isJsonify = true;
                    settings.Formatting = Formatting.Indented;
                    jsonStr = JsonConvert.SerializeObject(Pack, Type, settings);
                    return jsonStr;
                }
            }

            public string GetJson2()
            {
                if (isJsonify2)
                {
                    return jsonStr2;
                }
                else
                {
                    isJsonify2 = true;
                    settings.Formatting = Formatting.None;
                    jsonStr2 = JsonConvert.SerializeObject(Pack, Type, settings);
                    return jsonStr2;
                }
            }
        }

        /// <summary>
        /// 是否暂停记录
        /// </summary>
        public bool Pause { get; set; }

        /// <summary>
        /// 协议DLL
        /// </summary>
        //public Assembly ProtoStandDllAssembly { get; protected set; }

        /// <summary>
        /// 协议号 -> 包类型
        /// </summary>
        public Dictionary<ushort, System.Type> Protocol2RecvType { get; protected set; }
        public Dictionary<ushort, System.Type> Protocol2SendType { get; protected set; }

        /// <summary>
        /// 记录的所有协议包
        /// </summary>
        public List<PackData> RecvedPackList { get; protected set; }

        /// <summary>
        /// 过滤的协议号
        /// </summary>
        public Dictionary<ushort, bool> NotRecordDict { get; protected set; }

        private string mLogFilePath = Application.dataPath + "/../msg_log.txt";

        public bool EnableLogFile { get; set; }

        public PackRecorder()
        {
#if UNITY_STANDALONE_WIN && !UNITY_MOBILE_LOCAL
            InitAutoGenPack();

            // 创建日志文件
            if (File.Exists(mLogFilePath) == true)
            {
                File.Delete(mLogFilePath);
            }
            File.Create(mLogFilePath);
#endif

            Pause = true;
            EnableLogFile = false;
            RecvedPackList = new List<PackData>();
            NotRecordDict = new Dictionary<ushort, bool>()
            {
                { 10998, true }, // MSG_ACC_HEART_MWAR
                { 10999, true }, // S2CAccHeart
                { 10002, true }, // S2CsysDebug
                { 30002, true }, // S2CsysDebug
                { 10997, true }, // S2CAccPing
                { 14982, true }, // S2CMwarDebugPos
                { 14983, true }, // S2CMwarDebugLine
                { 14201, true }, // S2CWarMove
                { 14205, true }, // S2CWarMoveStop
                { 14101, true }, // S2CWarAppear
                { 14102, true }, // S2CWarDisappear
            };
        }

        protected void InitAutoGenPack()
        {
            //if (ProtoStandDllAssembly == null) {
            //    ProtoStandDllAssembly = Assembly.Load("ProtoStandDll");
            //}

            if (Protocol2RecvType == null) {
                Protocol2RecvType = new Dictionary<ushort, System.Type>();
                Protocol2SendType = new Dictionary<ushort, System.Type>();

                // 遍历NetMsg类型下所有的协议号
                var net_msg_type = typeof(xc.protocol.NetMsg);
                foreach (var field in net_msg_type.GetFields()) {
                    if (field.FieldType == typeof(ushort)) {
                        var protocol = (ushort)field.GetValue(null);

                        // 生成类型名
                        // 举例：将成员名 MSG_EASY_LOGIN 转为类型名 Net.S2CEasyLogin
                        var sb = new StringBuilder();
                        var tokens = field.Name.Split('_');
                        for (var i = 1; i < tokens.Length; ++i) {
                            var token = tokens[i];
                            sb.Append(token[0]);
                            // 首个字符为数字的时候第二个字符为大写，其余小写；否则除首字符外其余字符全部小写
                            if (token[0] < 48 || token[0] > 57)
                            {
                                sb.Append(token.Substring(1).ToLower());
                            }
                            else
                            {
                                sb.Append(token.Substring(1, 1));
                                sb.Append(token.Substring(2));
                            }
                        }

                        var recv_type = System.Type.GetType("Net.S2C" + sb.ToString());
                        if (recv_type != null) {
                            Protocol2RecvType[protocol] = recv_type;
                        }

                        var send_type = System.Type.GetType("Net.C2S" + sb.ToString());
                        if (send_type != null) {
                            Protocol2SendType[protocol] = send_type;
                        }
                    }
                }
            }
        }

        public void RecordRecvPack(ushort protocol, byte[] data)
        {
            if (!IsEnableRecord() && !IsEnableLogFile())
            {
                return;
            }

            System.Type pack_type;
            if (Protocol2RecvType.TryGetValue(protocol, out pack_type)) {
                var pack = Net.S2CPackBase.DeserializePack(data, pack_type);
                var pack_data = new PackData(protocol, pack, PackData.EPackType.Recv, pack_type);

                OnLogPackData(pack_data);

#if UNITY_EDITOR
                bool not_record = false;
                if (NotRecordDict.TryGetValue(protocol, out not_record) && not_record)
                {
                    return;
                }
                RecvedPackList.Add(pack_data);
                OnRecordPackData(pack_data);
#endif
            }
        }

        private void OnRecordPackData(PackData pack_data)
        {
            if (!IsEnableRecord())
            {
                return;
            }

            var window = MainGame.debugWindow;
            if (window != null)
            {
                window.AddMsg(pack_data);
            }
        }

        /// <summary>
        /// 输出到日志文件
        /// </summary>
        /// <param name="pack_data"></param>
        private void OnLogPackData(PackData pack_data)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(mLogFilePath, true))
            {
                string timeStr = DateHelper.GetServerDateTime().ToString();
                string packTypeStr = "";
                if (pack_data.PackType == PackData.EPackType.Send)
                {
                    packTypeStr = "c2s";
                }
                else
                {
                    packTypeStr = "s2c";
                }
                file.WriteLine(timeStr + " " + packTypeStr + " " + pack_data.Protocol + " " + pack_data.Type.ToString() + " " + ": " + pack_data.GetJson2());
                file.Close();
            }
        }

        public void RecordSendPack(ushort protocol, byte[] data)
        {
            if (!IsEnableRecord() && !IsEnableLogFile())
            {
                return;
            }

            System.Type pack_type;
            if (Protocol2SendType.TryGetValue(protocol, out pack_type)) {
                var pack = Net.S2CPackBase.DeserializeSendPack(data, pack_type);
                var pack_data = new PackData(protocol, pack, PackData.EPackType.Send, pack_type);

                OnLogPackData(pack_data);

#if UNITY_EDITOR
                bool not_record = false;
                if (NotRecordDict.TryGetValue(protocol, out not_record) && not_record)
                {
                    return;
                }
                RecvedPackList.Add(pack_data);
                OnRecordPackData(pack_data);
#endif

            }
        }

        public void RecordSendPack(ushort protocol, object pack)
        {
            if (!IsEnableRecord() && !IsEnableLogFile())
            {
                return;
            }

            System.Type pack_type;
            if (Protocol2SendType.TryGetValue(protocol, out pack_type))
            {
                var pack_data = new PackData(protocol, pack, PackData.EPackType.Send, pack_type);

                OnLogPackData(pack_data);

#if UNITY_EDITOR
                bool not_record = false;
                if (NotRecordDict.TryGetValue(protocol, out not_record) && not_record)
                {
                    return;
                }
                RecvedPackList.Add(pack_data);
                OnRecordPackData(pack_data);
#endif
            }
        }

        public List<PackData> GetAllPackList()
        {
            return this.RecvedPackList;
        }


        public void Clear()
        {
            this.RecvedPackList.Clear();
        }

        private bool IsEnableRecord()
        {
#if UNITY_STANDALONE_WIN && !UNITY_MOBILE_LOCAL
            return !Pause;
#else
            return false;
#endif
        }

        /// <summary>
        /// 是否记录到文件
        /// </summary>
        /// <returns></returns>
        private bool IsEnableLogFile()
        {
#if UNITY_STANDALONE_WIN && !UNITY_MOBILE_LOCAL
            return EnableLogFile;
#else
            return false;
#endif
        }

    }
}
