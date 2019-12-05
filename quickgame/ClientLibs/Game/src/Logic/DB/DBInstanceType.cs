//----------------------------------------------------------------
// File： DBInstanceType.cs
// Desc：存储副本类型从字符串到uint的映射数据
// Author: raorui
// Date: 2017.10.17
//----------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    class DBInstanceType : DBSqliteTableResource
    {
        public static DBInstanceType Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBInstanceType>();
            }
        }

        public DBInstanceType(string name, string path) : base(name, path)
        { }

        Dictionary<string, uint> mInstanceTypeMap = new Dictionary<string, uint>();
        Dictionary<uint, string> mInstanceConstMap = new Dictionary<uint, string>();

        protected override void ParseData(SqliteDataReader reader)
        {
            mInstanceTypeMap.Clear();
            mInstanceConstMap.Clear();
            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string war_type = GetReaderString(reader, "war_type");
                    uint war_const = DBTextResource.ParseUI_s(GetReaderString(reader, "war_const"), 0);

                    mInstanceTypeMap[war_type] = war_const;
                    mInstanceConstMap[war_const] = war_type;
                }
            }
        }

        /// <summary>
        /// 获取副本类型对应的常量
        /// </summary>
        /// <param name="war_type"></param>
        /// <returns></returns>
        public uint GetTypeConst(string war_type)
        {
            uint war_const = 0;
            mInstanceTypeMap.TryGetValue(war_type, out war_const);

            return war_const;
        }

        /// <summary>
        /// 获取副本类型对应的字符串
        /// </summary>
        /// <param name="war_type"></param>
        /// <returns></returns>
        public string GetInstanceType(uint war_const)
        {
            string war_type = "";
            mInstanceConstMap.TryGetValue(war_const, out war_type);

            return war_type;
        }
    }
}
