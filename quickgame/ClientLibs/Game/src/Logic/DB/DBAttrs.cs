/*----------------------------------------------------------------
// 文件名： DBAttrs.cs
// 文件功能描述： 属性表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBAttrs : DBSqliteTableResource
    {
        
        public class DBAttrsItem
        {
            public uint Id;             // id
            public uint AtkGroup;       //攻击组ID(同一个ID，合并显示，且属性名为“攻击”)
            public string Macro;       //宏
        }

        public class DBAtkGroupItem
        {
            public uint GroupId;
            public List<DBAttrsItem> ItemArray;

            static string AttackPropName = null;
            public string GetPropName()
            {
                if (AttackPropName == null)
                    AttackPropName = xc.DBConstText.GetText("COMMON_ATTR_ATTACK_GROUP_NAME");
                return AttackPropName;
            }
        }
        Dictionary<uint, DBAttrsItem> mInfos = new Dictionary<uint, DBAttrsItem>();

        //KEY为atk_group组ID
        Dictionary<uint, DBAtkGroupItem> mAtkGroupItemArray = new Dictionary<uint, DBAtkGroupItem>();
        public DBAttrs(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            mAtkGroupItemArray.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            mAtkGroupItemArray.Clear();
            DBAttrsItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBAttrsItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.AtkGroup = DBTextResource.ParseUI_s(GetReaderString(reader, "atk_group"), 0);
                        info.Macro = GetReaderString(reader, "macro");
                        mInfos.Add(info.Id, info);
                        if(info.AtkGroup != 0)
                        {
                            if(mAtkGroupItemArray.ContainsKey(info.AtkGroup) == false)
                            {
                                DBAtkGroupItem tmp = new DBAtkGroupItem();
                                tmp.GroupId = info.AtkGroup;
                                tmp.ItemArray = new List<DBAttrsItem>();
                                mAtkGroupItemArray.Add(info.AtkGroup, tmp);
                            }
                            mAtkGroupItemArray[info.AtkGroup].ItemArray.Add(info);

                        }
                    }
                }
            }
            List<uint> removeGroupIdArray = new List<uint>();
            foreach (var item in mAtkGroupItemArray)
            {
                if (item.Value.ItemArray.Count != 2)
                    removeGroupIdArray.Add(item.Key);
            }

            for (int index = 0; index < removeGroupIdArray.Count; ++index)
            {
                mAtkGroupItemArray.Remove(removeGroupIdArray[index]);
            }
        }

        public DBAttrsItem GetOneItem(uint attr_id)
        {
            DBAttrsItem info;
            if (mInfos.TryGetValue(attr_id, out info))
            {
                return info;
            }
            return null;
        }

        public DBAtkGroupItem GetAtkGroupItem(ActorAttribute actor_attr)
        {
            if (actor_attr == null)
                return null;
            foreach(var item in mAtkGroupItemArray)
            {
                if (actor_attr.ContainsKey(item.Value.ItemArray[0].Id) == false)
                    continue;
                return item.Value;
            }
            return null;
        }

        public string GetAtkStr(ActorAttribute actor_attr, DBAtkGroupItem atk_item)
        {
            if (actor_attr == null || atk_item == null)
                return "";
            IActorAttribute value_1_data = actor_attr.GetAttr(atk_item.ItemArray[0].Id);
            IActorAttribute value_2_data = actor_attr.GetAttr(atk_item.ItemArray[1].Id);
            if (value_1_data == null && value_2_data == null)
                return "";
            long value_1 = 0;
            if(value_1_data != null)
                value_1 = value_1_data.Value;
            long value_2 = 0;
            if (value_2_data != null)
                value_2 = value_2_data.Value;
            return GetGroupStr(value_1, value_2);
        }

        public string GetGroupStr(long value_1, long value_2)
        {
            if (value_1 == value_2)
                return string.Format("{0}", value_1);
            else if (value_1 < value_2)
                return string.Format("{0} - {1}", value_1, value_2);
            else
                return string.Format("{0} - {1}", value_2, value_1);
        }

        public bool IsAtkGroupAttr(uint attr_id)
        {
            DBAttrsItem item = GetOneItem(attr_id);
            if (item == null)
                return false;
            if (item.AtkGroup != 0)
                return true;
            return false;
        }
    }
}
