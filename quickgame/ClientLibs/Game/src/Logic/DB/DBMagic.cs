using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    [wxb.Hotfix]
    public class DBMagic : DBSqliteTableResource
    {
        public class DBMagicItem
        {
            public uint Id;
            public int SortId;
            public string Name;  // 法宝名 
            public string IconName;  // 图标名 
            public uint Color; // 法宝品质

            public List<DBTextResource.DBAttrItem> AssistAttrs; // 助战属性
            public List<uint> SkillList; // 助战技能 
        }

        public List<DBMagicItem> SortData = new List<DBMagicItem>();

        public Dictionary<uint, DBMagicItem> data; 

        public DBMagic(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBMagicItem>();
        }

        public static DBMagic Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBMagic>();
            }
        }

        public DBMagicItem GetData(uint id)
        {
            DBMagicItem ad = null;
            data.TryGetValue(id, out ad);
            return ad;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                DBMagicItem ad = new DBMagicItem();
                ad.Id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
                ad.SortId = DBTextResource.ParseI(GetReaderString(reader, "sort"));
                ad.Name = GetReaderString(reader, "name");
                ad.IconName = GetReaderString(reader, "icon_name");
                ad.Color = DBTextResource.ParseUI(GetReaderString(reader, "color"));
                ad.AssistAttrs = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "attrs"));
                ad.SkillList = DBTextResource.ParseArrayUint(GetReaderString(reader, "skills"), ",");

                data.Add(ad.Id, ad);
                SortData.Add(ad);
            }

            SortData.Sort((a, b) =>
            {
                if (a.SortId < b.SortId)
                    return -1;
                else if (a.SortId > b.SortId)
                    return 1;
                return 0;
            });
        }

        /// <summary>
        /// 获取法宝自身评分
        /// </summary>
        /// <param name="magicId"></param>
        public int GetMagicSelfScore(uint magicId)
        {
            var magicInfo = GetData(magicId);
            if (magicInfo == null)
                return 0;

            ActorAttribute attr = new ActorAttribute();

            foreach(var v in magicInfo.AssistAttrs)
            {
                attr.Add(v.attr_id, v.attr_num);
            }

            return xc.Equip.EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.EquipBase, attr);
        }

        public override void Unload()
        {
            data.Clear();
        }
    }
}