using System;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

namespace xc
{
    class DBIOSDevice : DBSqliteTableResource
    {
#if UNITY_IPHONE
        private Dictionary<UnityEngine.iOS.DeviceGeneration, uint> mIosDevices = new Dictionary<UnityEngine.iOS.DeviceGeneration, uint>();
#endif

        static DBIOSDevice mInstance;
        public static DBIOSDevice Instance
        {
            get
            {
                return mInstance;
            }
        }

        public DBIOSDevice(string name, string path)
            : base(name, path)
        {
            mInstance = this;
        }

        public override void Unload()
        {
            base.Unload();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

#if UNITY_IPHONE
            mIosDevices.Clear();
            while (reader.Read())
            {
                string id = GetReaderString(reader, "id");
                var quality = DBTextResource.ParseUI(GetReaderString(reader, "quality"));

                var device_type = (UnityEngine.iOS.DeviceGeneration)Enum.Parse(typeof(UnityEngine.iOS.DeviceGeneration), id, true);
                mIosDevices[device_type] = quality;
            }
#endif
        }

#if UNITY_IPHONE
        public uint GetDeviceQuality(UnityEngine.iOS.DeviceGeneration device)
        {
            uint quality = 1;
            mIosDevices.TryGetValue(device, out quality);
            return quality;
        }
#endif
    }
}
