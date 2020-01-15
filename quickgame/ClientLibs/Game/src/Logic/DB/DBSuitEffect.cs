//----------------------------------------------------------------
// File： DBSuitEffect.cs
// Desc： 套装特效表
// Author: raorui
// Date: 2017.10.27
//----------------------------------------------------------------
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSuitEffect : DBSqliteTableResource
    {
        public class SuitEffectInfo
        {
            public uint id;// 套装特效的id
            public uint effect_type; // 套装特效的类型(1: 装备 2: 武器)
            public List<BindInfo> bind_infos;
        }

        /// <summary>
        /// 特效绑定的数据
        /// </summary>
        public class BindInfo
        {
            public uint model_id; // 模型表中的id
            public uint low_model_id; // 低配模型表中的id
            public uint ui_model_id; // ui模型表中的id
            public string bind_node; // 绑定骨骼的名字
        }

        Dictionary<uint, SuitEffectInfo> mSuitEffectInfos = new Dictionary<uint, SuitEffectInfo>();
        
        public DBSuitEffect(string strName, string strPath) : base(strName, strPath)
        {
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            base.Unload();
            mSuitEffectInfos.Clear();
        }

        SuitEffectInfo GetItemInfo(uint id)
        {
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mSuitEffectInfos[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mSuitEffectInfos[id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }


            SuitEffectInfo info = new SuitEffectInfo();
            info.id = id;
            info.effect_type = DBTextResource.ParseUI(GetReaderString(reader, "effect_type"));
            int effect_count = DBTextResource.ParseI(GetReaderString(reader, "effect_count"));
            info.bind_infos = new List<BindInfo>(effect_count);

            for (int i = 0; i < effect_count; ++i)
            {
                var bind_info = new BindInfo();
                bind_info.model_id = DBTextResource.ParseUI(GetReaderString(reader, "model_id_" + (i + 1)));
                bind_info.low_model_id = DBTextResource.ParseUI(GetReaderString(reader, "low_model_id_" + (i + 1)));
                bind_info.ui_model_id = DBTextResource.ParseUI(GetReaderString(reader, "ui_model_id_" + (i + 1)));
                if (bind_info.ui_model_id == 0)
                {
                    bind_info.ui_model_id = bind_info.model_id;
                }
                bind_info.bind_node = GetReaderString(reader, "bind_node_" + (i + 1));
                info.bind_infos.Add(bind_info);
            }

            mSuitEffectInfos[info.id] = info;

            reader.Close();
            reader.Dispose();
            return info;
        }

        public SuitEffectInfo GetEffectInfo(uint effect_id)
        {
            SuitEffectInfo info = null;
            if (!mSuitEffectInfos.TryGetValue(effect_id, out info))
                info = GetItemInfo(effect_id);

            return info;
        }
    }
}
