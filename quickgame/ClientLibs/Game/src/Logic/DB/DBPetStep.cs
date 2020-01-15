
/*----------------------------------------------------------------
// 文件名： DBPetStep.cs
// 文件功能描述： 宠物进阶表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBPetStep : DBSqliteTableResource
    {
        
        public class DBPetStepItem
        {
            public uint Id;
            public uint Step;
            public uint Exp;
            public List<DBTextResource.DBAttrItem> SelfAttr;    //魔仆属性加成
            public List<DBTextResource.DBAttrItem> OwnerAttr; //角色属性加成
            public List<DBTextResource.DBGoodsItem> CostArray;  //进阶消耗

        }
        public class OneDBPetStep
        {
            public uint Id;
            //public uint MaxStep;    //最大的等阶
            public Dictionary<uint, DBPetStepItem> OneDBPetStepArray;
        }

        /// <summary>
        /// key: 消耗的物品ID，value：升级的守护ID
        /// </summary>
        Dictionary<uint, uint> mCostInfos = null; //消耗表

        //Dictionary<uint, Dictionary<uint, DBPetStepItem> > mInfos = new Dictionary<uint, Dictionary<uint, DBPetStepItem>>();

        public Dictionary<uint, OneDBPetStep> mInfos = new Dictionary<uint, OneDBPetStep>();   //所有的宠物表的排序后的列表
        public DBPetStep(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            mCostInfos.Clear();
            mCostInfos = null;
        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            mCostInfos.Clear();

            DBPetStepItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBPetStepItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Step = DBTextResource.ParseUI_s(GetReaderString(reader, "step"), 0);
                        info.SelfAttr = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "self_attr"));
                        info.OwnerAttr = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "owner_attr"));
                        info.CostArray = DBTextResource.ParseDBGoodsItem(GetReaderString(reader, "cost"));
                        if (mInfos.ContainsKey(info.Id) == false)
                        {
                            OneDBPetStep one_pet_step = new OneDBPetStep();
                            one_pet_step.Id = info.Id;
                            //one_pet_step.MaxStep = 0;
                            one_pet_step.OneDBPetStepArray = new Dictionary<uint, DBPetStepItem>();
                            mInfos.Add(one_pet_step.Id, one_pet_step);
                        }
                        //if (mInfos[info.Id].MaxStep < info.Step)
                        //    mInfos[info.Id].MaxStep = info.Step;
                        
                        mInfos[info.Id].OneDBPetStepArray[info.Step] = info;

                        if (info.CostArray != null && info.CostArray.Count > 0)
                        {
                            if(mCostInfos.ContainsKey(info.CostArray[0].goods_id) == false)
                                mCostInfos[info.CostArray[0].goods_id] = info.Id;
                        }
                    }
                }
            }
        }

        public DBPetStepItem GetOneInfo(uint pet_id, uint step)
        {
            OneDBPetStep one_pet_step;
            if (!mInfos.TryGetValue(pet_id, out one_pet_step))
            {
                one_pet_step = new OneDBPetStep();
                one_pet_step.Id = pet_id;
                one_pet_step.OneDBPetStepArray = new Dictionary<uint, DBPetStepItem>();
                mInfos.Add(one_pet_step.Id, one_pet_step);
            }


            Dictionary<uint, DBPetStepItem> dic = one_pet_step.OneDBPetStepArray;
            DBPetStepItem info = null;
            if (!dic.TryGetValue(step, out info))
            {
                string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" AND {0}.{3}=\"{4}\"  ", mTableName, "id", pet_id.ToString(), "step", step.ToString());
                var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(mFileName, mTableName, query_str);
                if (table_reader == null)
                {
                    dic[step] = null;
                    return null;
                }

                if (!table_reader.HasRows)
                {
                    dic[step] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                if (!table_reader.Read())
                {
                    dic[step] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                info = new DBPetStepItem();

                info.Id = DBTextResource.ParseUI_s(GetReaderString(table_reader, "id"), 0);
                info.Step = DBTextResource.ParseUI_s(GetReaderString(table_reader, "step"), 0);
                info.SelfAttr = DBTextResource.ParseDBAttrItems(GetReaderString(table_reader, "self_attr"));
                info.OwnerAttr = DBTextResource.ParseDBAttrItems(GetReaderString(table_reader, "owner_attr"));
                info.CostArray = DBTextResource.ParseDBGoodsItem(GetReaderString(table_reader, "cost"));

                dic.Add(step, info);

                table_reader.Close();
                table_reader.Dispose();

                Debug.Log("load pet step " + pet_id + "  " + step); 
            }
            return info;
        }

        public uint GetMaxStep(uint pet_id)
        {
            DBPet dbPet = DBManager.GetInstance().GetDB<DBPet>();

            DBPet.PetInfo petInfo = dbPet.GetOnePetInfo(pet_id);

            if (petInfo == null)
            {
                return 0;
            }
            return petInfo.MaxStep;
        }

        public uint GetPetIdByCostGoodsId(uint goods_id)
        {
            if (mCostInfos == null)
            {
                DBPet dbPet = DBManager.GetInstance().GetDB<DBPet>();
                mCostInfos = new Dictionary<uint, uint>();
                foreach (var item in dbPet.Infos)
                {
                    var petId = item.Value.Id;
                    DBPetStepItem info = GetOneInfo(petId, 1);
                    if (info.CostArray != null && info.CostArray.Count > 0)
                    {
                        if (mCostInfos.ContainsKey(info.CostArray[0].goods_id) == false)
                            mCostInfos[info.CostArray[0].goods_id] = info.Id;
                    }
                }
            }

            if (mCostInfos.ContainsKey(goods_id))
                return mCostInfos[goods_id];
            return 0;
        }
    }
}
