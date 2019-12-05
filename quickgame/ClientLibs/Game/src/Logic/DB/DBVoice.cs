using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
namespace xc
{
    public class DBVoice : DBSqliteTableResource
    {
        private static string VoiceTableName = "data_voice";

        class VoiceInfo
        {
            public uint Id;
            public string Path;
        }

        private Dictionary<uint, VoiceInfo> mData = new Dictionary<uint, VoiceInfo>();

        public DBVoice(string strName, string strPath)
          : base(strName, strPath)
        {
        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            base.Unload();

            mData.Clear();

        }

        private VoiceInfo GetOneVoiceInfo(uint id)
        {
            VoiceInfo info;
            if (!mData.TryGetValue(id, out info))
            {
                string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" ", VoiceTableName, "id", id.ToString());
                var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, VoiceTableName, query_str);
                if (table_reader == null)
                {
                    mData[id] = null;
                    return null;
                }

                if (!table_reader.HasRows)
                {
                    mData[id] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                if (!table_reader.Read())
                {
                    mData[id] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                info = new VoiceInfo();

                info.Id = DBTextResource.ParseUI_s(GetReaderString(table_reader, "id"), 0);
                info.Path = GetReaderString(table_reader, "res_path");

                mData.Add(id, info);

                table_reader.Close();
                table_reader.Dispose();
            }
            return info;
        }

        public string GetVoicePath(uint id)
        {
            // 东南亚版非简体中文不播放语音
            if (Const.Region == RegionType.SEASIA && Const.Language != LanguageType.SIMPLE_CHINESE)
            {
                return "";
            }

            VoiceInfo info = GetOneVoiceInfo(id);
            if (info != null)
            {
                return info.Path;
            }
            return "";
        }
     
    }
}
