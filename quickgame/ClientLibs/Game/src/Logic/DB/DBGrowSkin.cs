
/*----------------------------------------------------------------
// 文件名： DBGrowSkin.cs
// 文件功能描述： 皮肤成长表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGrowSkin : DBSqliteTableResource
    {
        public enum SkinUnLockType
        {
            None = 0,
            WhenOpenFunc = 1,
            GrowLevel = 2,      //前置成长等级
            CostGoods = 3,      //消耗道具
        }

        public class DBGrowSkinItem
        {
            public uint GrowType;         // 成长类型
            public uint Id;             //皮肤ID
            public string Name;         //名字
            public string Desc;         //描述
            public SkinUnLockType UnlockType;   //解锁类型
            //public uint UnlockPlayerLevel;  //解锁需要的玩家等级
            public uint UnlockGrowLevel = 0;        //解锁需要的成长等级
            public List<DBPet.UnLockGoodsCondition> UnLockGoodsConditionArray;           //解锁需要的解锁物品
            public string UnlockDesc;   //解锁说明
            public uint Quality;    //品质
            public uint SortId; //排序ID
            public uint ActorId;   //角色ID

            public Vector3 ModelLocalPos;
            public Vector3 ModelLocalScale;
            public Vector3 ModelLocalScaleGoods;
            public Vector3 ModelLocalAngles;
            public Vector3 ModelParentDefaultAngles;
            public Vector3 ModelParentLocalPos;
            public Vector3 ModelCameraOffset;
            //             public Vector3 ModelCameraRotate;
            public Vector3 ModelDefaultAngle;


            public Vector3 ModelSceneOffset;


            public Vector3 SurfaceOffset;    //外观界面模型位置调整
            public Vector3 GetOffset;    //获得界面模型位置调整
            public List<DBTextResource.DBAttrItem> AttrArray; //属性
            public string IdleActionWhenRiding; //骑乘时，玩家站立动作
            public string RunActionWhenRiding;  //骑乘时，玩家跑步动作

            public Vector3 SceneModelOffset; //场景上，模型的偏移值
        }
        Dictionary<uint, Dictionary<uint, DBGrowSkinItem>> mInfos = new Dictionary<uint, Dictionary<uint, DBGrowSkinItem>>();
        Dictionary<uint, List<DBGrowSkinItem>> mSortInfos = new Dictionary<uint, List<DBGrowSkinItem>>();
        Dictionary<uint, List<DBGrowSkinItem>> mNormalDegreeSortInfos = new Dictionary<uint, List<DBGrowSkinItem>>();//常规等阶排序

        bool mLoaded = false; //惰性加载

        public DBGrowSkin(string strName, string strPath)
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
            mInfos.Clear();
            mSortInfos.Clear();
            mNormalDegreeSortInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            mSortInfos.Clear();
            mNormalDegreeSortInfos.Clear();
            DBGrowSkinItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBGrowSkinItem();
                        info.GrowType = DBTextResource.ParseUI_s(GetReaderString(reader, "type"), 0);
                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Name = GetReaderString(reader, "name");
                        info.Desc = GetReaderString(reader, "desc");         //描述
                        info.UnlockType = (SkinUnLockType)DBTextResource.ParseUI_s(GetReaderString(reader, "unlock_type"), 0);      //解锁方式
                        if (info.UnlockType == SkinUnLockType.WhenOpenFunc)
                        {
                            //info.UnlockPlayerLevel = DBTextResource.ParseUI_s(GetReaderString(reader, "unlock_condition"), 0);          //解锁条件
                        }
                        else if (info.UnlockType == SkinUnLockType.CostGoods)
                        {
                            info.UnLockGoodsConditionArray = new List<DBPet.UnLockGoodsCondition>();
                            List<List<uint>> str_array = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "unlock_condition"));
                            for (int index = 0; index < str_array.Count; ++index)
                            {
                                if (str_array[index].Count >= 2)
                                {
                                    DBPet.UnLockGoodsCondition tmp_item = new DBPet.UnLockGoodsCondition();
                                    tmp_item.goods_id = str_array[index][0];
                                    tmp_item.goods_num = str_array[index][1];
                                    info.UnLockGoodsConditionArray.Add(tmp_item);
                                }
                                else
                                {
                                    GameDebug.LogError(string.Format("There is error unlock_condition (id = {0}) in data_grow_skin", info.Id));
                                }
                            }
                        }
                        else if (info.UnlockType == SkinUnLockType.GrowLevel)
                        {
                            info.UnlockGrowLevel = DBTextResource.ParseUI_s(GetReaderString(reader, "unlock_condition"), 0);          //解锁条件
                        }
                        else
                        {

                        }

                        info.UnlockDesc = GetReaderString(reader, "unlock_desc");   //解锁说明
                        info.SortId = DBTextResource.ParseUI_s(GetReaderString(reader, "sort_id"), 0);   //排序ID
                        info.Quality = DBTextResource.ParseUI_s(GetReaderString(reader, "quality"), 0);   //品质
                        info.ActorId = DBTextResource.ParseUI_s(GetReaderString(reader, "actor_id"), 0);   //角色ID
                        info.ModelLocalPos = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_pos"));
                        info.ModelLocalScale = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_scale"));
                        info.ModelLocalScaleGoods = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_scale_goods"));
                        info.ModelLocalAngles = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_angles"));
                        info.ModelParentDefaultAngles = DBTextResource.ParseVector3(GetReaderString(reader, "model_parent_default_angles"));
                        info.ModelParentLocalPos = DBTextResource.ParseVector3(GetReaderString(reader, "model_parent_local_pos"));
                        info.ModelCameraOffset = DBTextResource.ParseVector3(GetReaderString(reader, "model_camera_offset"));
                        info.ModelDefaultAngle = DBTextResource.ParseVector3(GetReaderString(reader, "model_default_angle"));

                        info.ModelSceneOffset = DBTextResource.ParseVector3(GetReaderString(reader, "model_scene_offset"));
                        info.SurfaceOffset = DBTextResource.ParseVector3(GetReaderString(reader, "surfaceOffset"));
                        info.GetOffset = DBTextResource.ParseVector3(GetReaderString(reader, "getOffset"));
                        info.AttrArray = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "attr"));   //属性加成
                        info.IdleActionWhenRiding = GetReaderString(reader, "idleActionWhenRiding");
                        info.RunActionWhenRiding = GetReaderString(reader, "runActionWhenRiding");
                        info.SceneModelOffset = DBTextResource.ParseVector3(GetReaderString(reader, "sceneModelOffset"));
                        if (mInfos.ContainsKey(info.GrowType) == false)
                            mInfos.Add(info.GrowType, new Dictionary<uint, DBGrowSkinItem>());
                        mInfos[info.GrowType][info.Id] = info;

                        if (mSortInfos.ContainsKey(info.GrowType) == false)
                            mSortInfos.Add(info.GrowType, new List<DBGrowSkinItem>());
                        mSortInfos[info.GrowType].Add(info);

                        if (info.UnlockType == SkinUnLockType.WhenOpenFunc || info.UnlockType == SkinUnLockType.GrowLevel)
                        {
                            if (mNormalDegreeSortInfos.ContainsKey(info.GrowType) == false)
                                mNormalDegreeSortInfos.Add(info.GrowType, new List<DBGrowSkinItem>());
                            mNormalDegreeSortInfos[info.GrowType].Add(info);
                        }
                    }

                    foreach (var item in mSortInfos)
                    {
                        item.Value.Sort((a, b) =>
                        {
                            if (a.SortId < b.SortId)
                                return -1;
                            else if (a.SortId > b.SortId)
                                return 1;

                            if (a.Id < b.Id)
                                return -1;
                            else if (a.Id > b.Id)
                                return 1;
                            return 0;
                        });
                    }

                    foreach (var item in mNormalDegreeSortInfos)
                    {
                        item.Value.Sort((a, b) =>
                        {
                            if (a.UnlockType == SkinUnLockType.WhenOpenFunc)
                            {
                                if (b.UnlockType != SkinUnLockType.WhenOpenFunc)
                                {
                                    return -1;
                                }
                            }
                            else
                            {
                                if (b.UnlockType == SkinUnLockType.WhenOpenFunc)
                                    return 1;
                                else
                                {
                                    if (a.UnlockGrowLevel < b.UnlockGrowLevel)
                                        return -1;
                                    else if (a.UnlockGrowLevel > b.UnlockGrowLevel)
                                        return 1;
                                    return 0;
                                }
                            }
                            if (a.Id < b.Id)
                                return -1;
                            else if (a.Id > b.Id)
                                return 1;
                            return 0;
                        });
                    }
                }
            }
        }

        public DBGrowSkinItem GetOneItem(uint grow_type, uint id)
        {
            CheckAndLoad();

            Dictionary<uint, DBGrowSkinItem> info_array;
            if (mInfos.TryGetValue(grow_type, out info_array) == false)
            {
                return null;
            }
            DBGrowSkinItem info;
            if (info_array != null && info_array.TryGetValue(id, out info))
            {
                return info;
            }
            return null;
        }

        public List<DBGrowSkinItem> GetSortItemArray(uint grow_type)
        {
            CheckAndLoad();

            List<DBGrowSkinItem> info_array;
            if (mSortInfos.TryGetValue(grow_type, out info_array) == false)
            {
                return null;
            }
            return info_array;
        }

        public DBGrowSkinItem GetNextDegreeItem(uint grow_type, uint cur_grow_level)
        {
            CheckAndLoad();

            List<DBGrowSkinItem> info_array;
            if (mNormalDegreeSortInfos.TryGetValue(grow_type, out info_array) == false)
            {
                return null;
            }
            if (info_array == null)
                return null;

            for (int index = 0; index < info_array.Count; ++index)
            {
                if (info_array[index].UnlockGrowLevel > cur_grow_level)
                {
                    return info_array[index];
                }
            }
            return null;
        }

        public DBGrowSkinItem GetOneSkinInfoByGoodsId(uint goods_id)
        {
            CheckAndLoad();

            foreach (var item in mInfos)
            {
                foreach (var item2 in item.Value)
                {
                    if (item2.Value.UnlockType != SkinUnLockType.CostGoods)
                        continue;
                    if (item2.Value.UnLockGoodsConditionArray == null)
                        continue;
                    for (int index = 0; index < item2.Value.UnLockGoodsConditionArray.Count; ++index)
                    {
                        if (item2.Value.UnLockGoodsConditionArray[index].goods_id == goods_id)
                            return item2.Value;
                    }
                }
            }

            return null;
        }

        private void CheckAndLoad()
        {
            if(mLoaded)
            {
                return;
            }
            SqliteDataReader reader = DBManager.Instance.ExecuteSqliteQueryToReader(mFileName, mTableName, "SELECT * FROM " + mTableName);
            ParseData(reader);

            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }

            mLoaded = true;
        }
    }
}
