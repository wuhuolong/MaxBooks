
/*----------------------------------------------------------------
// 文件名： DBBaptizeColorPool.cs
// 文件功能描述： 洗练属性颜色库配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBBaptizeColorPool : DBSqliteTableResource
    {
        public class DBBaptizeColorPoolInfo
        {
            public uint Color;          // 颜色
            public uint AttrRatioMin;   // 属性占比(区间)最小
            public uint AttrRatio;      // 属性占比(区间)
        }
        
        public Dictionary<uint, DBBaptizeColorPoolInfo> mInfos = new Dictionary<uint, DBBaptizeColorPoolInfo>();

        public DBBaptizeColorPool(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            DBBaptizeColorPoolInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBBaptizeColorPoolInfo();

                        info.Color = DBTextResource.ParseUI_s(GetReaderString(reader, "color"), 0);
                        info.AttrRatioMin = DBTextResource.ParseUI_s(GetReaderString(reader, "attr_ratio_min"), 0);
                        info.AttrRatio = DBTextResource.ParseUI_s(GetReaderString(reader, "attr_ratio"), 0);

                        mInfos[info.Color] = info;
                    }
                }
            }
        }

        /// <summary>
        /// 获取一个洗练属性颜色信息
        /// </summary>
        /// <param name="posId"></param>
        /// <returns></returns>
        public DBBaptizeColorPoolInfo GetOneInfo(uint id)
        {
            DBBaptizeColorPoolInfo info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }
            return null;
        }


        /// <summary>
        /// 所有洗练属性颜色信息
        /// </summary>
        public Dictionary<uint, DBBaptizeColorPoolInfo> AllInfos
        {
            get
            {
                return mInfos;
            }
        }
    }
}
