using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBFootprint : DBSqliteTableResource
    {
        public class DBFootprintItem
        {
            public uint Id;// 外观id
            public string EffectFile;  // 足迹场景特效路径
            public string LowEffectFile;  // 足迹场景特效路径 低配
            public float DelayTime; // 特效持续时间
            public float CDTime; // 产生间隔时间
            public float MinDistance; // 最小距离

            /// <summary>
            /// 获取合适的资源路径
            /// </summary>
            /// <returns></returns>
            public string SuitablePath(bool is_local_player)
            {
                if (is_local_player)// 本地玩家根据画面设置使用不同的资源
                {
                    if (QualitySetting.GraphicLevel == 2) // 低配
                    {
                        if (string.IsNullOrEmpty(LowEffectFile) == false)
                        {
                            return LowEffectFile;
                        }
                        else
                            return EffectFile;
                    }
                    else // 高、中配
                        return EffectFile;
                }
                else // 其他人使用低配的资源
                {
                    if (string.IsNullOrEmpty(LowEffectFile) == false)
                    {
                        return LowEffectFile;
                    }
                    else
                        return EffectFile;
                }
            }
        }

        private Dictionary<uint, DBFootprintItem> data;

        public static DBFootprint Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBFootprint>();
            }
        }

        public static DBFootprintItem GetFootprintItem(uint id)
        {
            DBFootprintItem data = null;
            if (DBFootprint.Instance.data.TryGetValue(id, out data))
                return data;
            return null;
        }


        public DBFootprint(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBFootprintItem>();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                DBFootprintItem ad = new DBFootprintItem();
                ad.Id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
                ad.EffectFile = GetReaderString(reader, "effect_file");
                ad.LowEffectFile = GetReaderString(reader, "low_effect_file");
                ad.DelayTime = DBTextResource.ParseF(GetReaderString(reader, "delay_time"));
                ad.CDTime = DBTextResource.ParseF(GetReaderString(reader, "cd_time"));
                ad.MinDistance = DBTextResource.ParseF(GetReaderString(reader, "min_distance"));
                data.Add(ad.Id, ad);
            }
        }
    }
}
