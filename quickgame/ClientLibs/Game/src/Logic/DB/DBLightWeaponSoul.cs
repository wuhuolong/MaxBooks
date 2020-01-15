using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBLightWeaponSoul : DBSqliteTableResource
    {
        public class LightWeaponSoul
        {
            public uint GID;
            public uint Pos_Type;    // 部位_光武类型
            public uint Pos_Index;  // 部位_孔位
            public uint ResolveAmount;  // 分解获得魂魄值
            public uint ResolveType;    // 分解对应的类型
            public Dictionary<uint, uint> BasicAttrs;   // 基础属性
        }

        public Dictionary<uint, LightWeaponSoul> data;

        public DBLightWeaponSoul(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, LightWeaponSoul>();
        }

        public static DBLightWeaponSoul Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBLightWeaponSoul>();
            }
        }

        public LightWeaponSoul GetData(uint GID)
        {
            if (data.ContainsKey(GID))
                return data[GID];

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", GID);

            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                data[GID] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                data[GID] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            var soul = new LightWeaponSoul();
            soul.GID = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
            List<uint> Pos = DBTextResource.ParseArrayUint(GetReaderString(reader, "position"), ",");
            soul.Pos_Type = Pos[0];
            soul.Pos_Index = Pos[1];
            var Resolve = DBTextResource.ParseArrayUint(GetReaderString(reader, "break"), ",");
            soul.ResolveType = Resolve[0];
            soul.ResolveAmount = Resolve[1];
            soul.BasicAttrs = DBTextResource.ParseDictionaryUintUint(GetReaderString(reader, "base_attrs"));
            data[GID] = soul;
            reader.Close();
            reader.Dispose();
            return soul;
        }

        public override void Unload()
        {
            data.Clear();
        }
    }
}