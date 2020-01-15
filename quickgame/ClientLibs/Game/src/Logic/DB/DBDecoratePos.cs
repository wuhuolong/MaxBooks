using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBDecoratePos : DBSqliteTableResource
    {
        public class DBDecoratePosItem
        {
            public uint Pos;  // 部位id
            public uint SortId;
            public uint LevelId; // 关卡id(开启部位的秘境守护关卡id)
            public string Name; // 部位名

            public List<Vector4> AppendAttrs; // 附魔属性(x, 属性id；y, 属性值;z，解锁所需强化等级;w，解锁所需突破等级)
            public List<Vector2> BreakCosts; // 突破消耗
        }

        public List<DBDecoratePosItem> SortData = new List<DBDecoratePosItem>();

        private Dictionary<uint, DBDecoratePosItem> data;

        public DBDecoratePos(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBDecoratePosItem>();
        }

        public static DBDecoratePos Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBDecoratePos>();
            }
        }

        public DBDecoratePosItem GetData(uint id)
        {
            DBDecoratePosItem ad = null;
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
                DBDecoratePosItem ad = new DBDecoratePosItem();
                ad.Pos = DBTextResource.ParseUI(GetReaderString(reader, "pos_id"));
                ad.Name = GetReaderString(reader, "name");
                ad.SortId = DBTextResource.ParseUI(GetReaderString(reader, "sort_id"));
                ad.LevelId = DBTextResource.ParseUI(GetReaderString(reader, "dgid"));
                ad.AppendAttrs = DBTextResource.ParseArrayVector4(GetReaderString(reader, "attrs"));
                ad.BreakCosts = DBTextResource.ParseArrayVector2(GetReaderString(reader, "break_cost"));

                data.Add(ad.Pos, ad);

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

        public override void Unload()
        {
            data.Clear();
        }
    }
}