
/*----------------------------------------------------------------
// 文件名： DBRedPoint.cs
// 文件功能描述： 小红点表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    [wxb.Hotfix]
    public class DBRedPoint : DBSqliteTableResource
    {
        public class DBRedPointItem
        {
            public uint Id;
            public List<uint> ParentIds;    //父节点集合

            //后面是根据配表生成
            public List<uint> ChildIds; //子节点集合

            //游戏逻辑赋值
            public bool IsVisible = false;  //小红点是否可见
            public GameObject obj;      //小红点对应的GameObject
        }
        Dictionary<uint, DBRedPointItem> mInfos = new Dictionary<uint, DBRedPointItem>();

        public DBRedPoint(string strName, string strPath)
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

            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        uint id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        List<uint> parentIds = DBTextResource.ParseArrayUint(GetReaderString(reader, "parentIds"), ",");
                        AddRedPointData(id, parentIds);
                    }
                }
            }
        }

        public void AddRedPointData(uint id, List<uint> parentIds)
        {
            DBRedPointItem info = null;
            if (mInfos.TryGetValue(id, out info) == false)
            {
                info = GetNewRedPoint(id, null);
                mInfos[info.Id] = info;
            }

            if(parentIds != null)
            {
                for (int index = 0; index < parentIds.Count; ++index)
                {
                    uint parent_id = parentIds[index];
                    
                    if (mInfos.ContainsKey(parent_id) == false)
                        AddRedPointData(parent_id, null);
                    if (IsParent(id, parent_id))
                    {
                        //已经父子节点，无需继续添加
                        continue;
                    }
                    if (IsParent(parent_id, id))
                    {
                        //已经父子节点，且会死循环，严禁添加
                        GameDebug.LogError(string.Format("[AddRedPointData]parent = {0} child = {1}",
                            parent_id, id));
                        continue;
                    }
                    if (mInfos[info.Id].ParentIds == null)
                        mInfos[info.Id].ParentIds = new List<uint>();
                    if (mInfos[info.Id].ParentIds.Contains(parent_id) == false)
                        mInfos[info.Id].ParentIds.Add(parent_id);
                    if (mInfos[parent_id].ChildIds == null)
                        mInfos[parent_id].ChildIds = new List<uint>();
                    if (mInfos[parent_id].ChildIds.Contains(id) == false)
                    {
                        mInfos[parent_id].ChildIds.Add(id);
                    }
                    RedPointDataMgr.Instance.RefreshRedPointVisible(parent_id);
                }
            }
        }

        /// <summary>
        /// 判定 id 是否是 parent_id 的子节点
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parent_id"></param>
        /// <returns></returns>
        bool IsParent(uint id, uint parent_id, uint iteration = 0)
        {
            if (iteration >= 10)
            {
                GameDebug.LogError("redpoint layer over 10: id = " + id + ", parent_id = " + parent_id);
                return false;
            }
            DBRedPointItem item = GetRedPointItem(id);
            if (item == null)
                return false;
            if (item.ParentIds == null || item.ParentIds.Count == 0)
                return false;
            for(int index = 0; index < item.ParentIds.Count; ++index)
            {
                if (item.ParentIds[index] == parent_id)
                    return true;
                else if (IsParent(item.ParentIds[index], parent_id, iteration + 1))
                    return true;
            }
            return false;
        }

        DBRedPointItem GetNewRedPoint(uint id, List<uint> parentIds)
        {
            DBRedPointItem info = new DBRedPointItem();
            info.Id = id;
            info.ParentIds = parentIds;
            return info;
        }
        public DBRedPointItem GetRedPointItem(uint id)
        {
            DBRedPointItem item;
            if (mInfos.TryGetValue(id, out item) == false)
                return null;
            return item;
        }

        public void ClearData()
        {
            if (mInfos == null)
                return;
            foreach(var item in mInfos)
            {
                item.Value.IsVisible = false;
                
                // 处理断线重连，主界面小红点显示问题
                if (null != item.Value.obj)
                {
                    item.Value.obj.SetActive(false);
                }
            }
        }
    }
}

