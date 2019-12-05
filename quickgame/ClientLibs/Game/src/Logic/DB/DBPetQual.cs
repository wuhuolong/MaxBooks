
/*----------------------------------------------------------------
// 文件名： DBPetQual.cs
// 文件功能描述： 宠物升品表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBPetQual : DBSqliteTableResource
    {
        private static string PetQualTableName = "data_pet_qual";


        public class DBPetQualItem
        {
            public uint Id;
            public uint Qual;
            public uint Exp;
            public uint GetExp; //消耗一次获得的经验值
            //public List<DBTextResource.DBAttrItem> SelfAttr;    //魔仆属性加成
            public List<DBTextResource.DBAttrItem> OwnerAttr; //角色属性加成
            public List<DBTextResource.DBGoodsItem> CostArray;  //进阶消耗

        }
        //public class OneDBPetQual
        //{
        //    public uint Id;
        //    public uint MaxQual;    //最大的等阶
        //    public Dictionary<uint, DBPetQualItem> OneDBPetQualArray;
        //}
        //public Dictionary<uint, OneDBPetQual> mInfos = new Dictionary<uint, OneDBPetQual>();   //所有的宠物表的排序后的列表

        private Dictionary<uint, Dictionary<uint, DBPetQualItem>> mInfosDic = new Dictionary<uint, Dictionary<uint, DBPetQualItem>>();


        public DBPetQual(string strName, string strPath)
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

            mInfosDic.Clear();

        }

        //protected override void ParseData(SqliteDataReader reader)
        //{
        //    mInfos.Clear();


        //    DBPetQualItem info;
        //    if (reader != null)
        //    {
        //        if (reader.HasRows == true)
        //        {
        //            while (reader.Read())
        //            {
        //                info = new DBPetQualItem();

        //                info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
        //                info.Qual = DBTextResource.ParseUI_s(GetReaderString(reader, "qual"), 0);
        //                info.Exp = DBTextResource.ParseUI_s(GetReaderString(reader, "exp"), 0);
        //                info.GetExp = DBTextResource.ParseUI_s(GetReaderString(reader, "get_exp"), 0);
        //                info.OwnerAttr = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "attr"));
        //                info.CostArray = DBTextResource.ParseDBGoodsItem(GetReaderString(reader, "cost"));
        //                if (mInfos.ContainsKey(info.Id) == false)
        //                {
        //                    OneDBPetQual one_pet_qual = new OneDBPetQual();
        //                    one_pet_qual.Id = info.Id;
        //                    one_pet_qual.MaxQual = 0;
        //                    one_pet_qual.OneDBPetQualArray = new Dictionary<uint, DBPetQualItem>();
        //                    mInfos.Add(one_pet_qual.Id, one_pet_qual);
        //                }
        //                if (mInfos[info.Id].MaxQual < info.Qual)
        //                    mInfos[info.Id].MaxQual = info.Qual;

        //                mInfos[info.Id].OneDBPetQualArray[info.Qual] = info;
        //            }
        //        }
        //    }
        //}

        public DBPetQualItem GetOneInfo(uint pet_id, uint qual)
        {
            Dictionary<uint, DBPetQualItem> dic;
            if (!mInfosDic.TryGetValue(pet_id, out dic))
            {
                dic = new Dictionary<uint, DBPetQualItem>();
                mInfosDic.Add(pet_id, dic);
            }

            DBPetQualItem item;
            if (!dic.TryGetValue(qual, out item))
            {
                string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" AND {0}.{3}=\"{4}\"  ", PetQualTableName, "id", pet_id.ToString(), "qual", qual.ToString());
                var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, PetQualTableName, query_str);
                if (table_reader == null)
                {
                    dic[qual] = null;
                    return null;
                }

                if (!table_reader.HasRows)
                {
                    dic[qual] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                if (!table_reader.Read())
                {
                    dic[qual] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                item = new DBPetQualItem();

                item.Id = DBTextResource.ParseUI_s(GetReaderString(table_reader, "id"), 0);
                item.Qual = DBTextResource.ParseUI_s(GetReaderString(table_reader, "qual"), 0);
                item.Exp = DBTextResource.ParseUI_s(GetReaderString(table_reader, "exp"), 0);
                item.GetExp = DBTextResource.ParseUI_s(GetReaderString(table_reader, "get_exp"), 0);
                item.OwnerAttr = DBTextResource.ParseDBAttrItems(GetReaderString(table_reader, "attr"));
                item.CostArray = DBTextResource.ParseDBGoodsItem(GetReaderString(table_reader, "cost"));

                dic.Add(qual, item);

                table_reader.Close();
                table_reader.Dispose();

            }
            return item;
        }




        public uint GetMaxQual(uint pet_id)
        {
            DBPet dbPet = DBManager.GetInstance().GetDB<DBPet>();

            DBPet.PetInfo petInfo = dbPet.GetOnePetInfo(pet_id);

            if(petInfo == null)
            {
                return 0;
            }
            return petInfo.MaxQual;
        }
    }
}
