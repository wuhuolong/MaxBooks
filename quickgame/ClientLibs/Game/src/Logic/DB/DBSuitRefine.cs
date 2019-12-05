using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System;

namespace xc
{
    public class DBSuitRefine : DBSqliteTableResource
    {
        public class DBSuitRefineItem
        {
            public string Id; // 唯一id，csv_id
            public uint Pos;  // 部位id
            public uint Step;   //等阶
            public uint Level;  // 精炼等级
            public List<DBTextResource.DBGoodsItem> Cost; // 消耗
            public uint Addition; // 加成

            public string Attrs; // 基础属性
        }

        public Dictionary<string, DBSuitRefineItem> data;
        Dictionary<string, List<string>> mRefinePosMap = new Dictionary<string, List<string>>();

        public DBSuitRefine(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<string, DBSuitRefineItem>();
        }

        public static DBSuitRefine Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBSuitRefine>();
            }
        }

        /// <summary>
        /// 通过csv_id来获取指定的套装精炼数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DBSuitRefineItem GetData(string id)
        {
            DBSuitRefineItem ad = null;
            if (data.TryGetValue(id, out ad))
                return ad;

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "csv_id", id);
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (table_reader == null)
            {
                data[id] = null;
                return null;
            }

            if (!table_reader.HasRows)
            {
                data[id] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            if (!table_reader.Read())
            {
                data[id] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            ad = new DBSuitRefineItem();
            ad.Id = GetReaderString(table_reader, "csv_id");
            ad.Pos = DBTextResource.ParseUI(GetReaderString(table_reader, "pos"));
            ad.Step = DBTextResource.ParseUI(GetReaderString(table_reader, "step"));
            ad.Level = DBTextResource.ParseUI(GetReaderString(table_reader, "lv"));
            ad.Cost = DBTextResource.ParseDBGoodsItem(GetReaderString(table_reader, "costs"));
            ad.Addition = GetReaderUint(table_reader, "addition");

            data[ad.Id] = ad;

            table_reader.Close();
            table_reader.Dispose();

            return ad;
        }

        /// <summary>
        /// 根据装备位置和装备等阶来获取指定的套装精炼数据
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public List<DBSuitRefineItem> GetRefineListByPos(uint pos, uint step)
        {
            var ret = new List<DBSuitRefineItem>();

            uint uPos = pos;
            string pos_step = string.Format("{0}_{1}", uPos, step);

            // 先从缓存中获取
            List<string> csv_ids = null;
            if (mRefinePosMap.TryGetValue(pos_step, out csv_ids))
            {
                for (int i = 0; i < csv_ids.Count; ++i)
                {
                    var info = GetData(csv_ids[i]);
                    if(info != null)
                        ret.Add(info);
                }

                return ret;
            }

            csv_ids = new List<string>();
            mRefinePosMap[pos_step] = csv_ids;

            // 查询符合条件的数据
            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" AND {0}.{3}=\"{4}\"", mTableName, "pos", uPos, "step", step);
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (table_reader == null)
            {
                return ret;
            }

            if (!table_reader.HasRows)
            {
                table_reader.Close();
                table_reader.Dispose();
                return ret;
            }

            // 将查询到的csv_id放入list中
            while (table_reader.Read())
            {
                var id = GetReaderString(table_reader, "csv_id");
                csv_ids.Add(id);
            }

            // 关闭查询
            table_reader.Close();
            table_reader.Dispose();

            // 通过GetData获取精炼数据
            for (int i = 0; i < csv_ids.Count; ++i)
            {
                var info = GetData(csv_ids[i]);
                if (info != null)
                    ret.Add(info);
            }

            return ret;
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            data.Clear();
            mRefinePosMap.Clear();
        }
    }
}