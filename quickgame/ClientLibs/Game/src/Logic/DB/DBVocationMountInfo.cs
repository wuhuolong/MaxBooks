
/*******************************************************************/
//   Desc : 职业特定属性表
//   Author : raorui
//   Date   : 2015.10.15
/*******************************************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text;

namespace xc
{
    

    public class VocationMountInfo
    {
        public class OnRideActionInfo
        {
            public Vector3 mount_offset_dict;
            public float self_height;
            public float self_center_height;

        }
        public uint vocation; // 表格id
        //public Dictionary<string, Vector3> mount_offset_dict;    //坐骑场景偏移值
        public Dictionary<string, OnRideActionInfo> rider_self_height_dict;    //在坐骑上，人物模型自身的高度(若找不到，则使用Prefab中的高度)
        
    }

    public class DBVocationMountInfo : DBSqliteTableResource
    {
        private Dictionary<uint, VocationMountInfo> m_VocationMountInfos;

        private List<string> mount_action_name_array = null;

        static DBVocationMountInfo mInstance;
        public static DBVocationMountInfo Instance
        {
            get
            {
                return mInstance;
            }
        }

        public override void Load()
        {
            if(mount_action_name_array == null)
            {
                mount_action_name_array = GameConstHelper.GetStringList("GAME_VOCATION_MOUNT_INFO_ROW_NAME");
            }
            base.Load();
        }


        public DBVocationMountInfo(string name, string path)
            : base(name, path)
        {
            mInstance = this;
        }

        public VocationMountInfo GetVocationMountInfo(uint vocation)
        {
            VocationMountInfo data;
            if (!m_VocationMountInfos.TryGetValue(vocation, out data))
            {
                return null;
            }
            return data;
        }

        public override void Unload()
        {
            base.Unload();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }
            //List<string> mount_action_name_array = new List<string>(){ "rideidle", "rideidle01", "rideidle02", "rideidle03", "rideidle04", "rideidle06" };
            m_VocationMountInfos = new Dictionary<uint, VocationMountInfo>();
            while (reader.Read())
            {
                var vocation = DBTextResource.ParseUI(GetReaderString(reader, "vocation"));
                VocationMountInfo data = new VocationMountInfo();
                //data.mount_offset_dict = new Dictionary<string, Vector3>();
                data.rider_self_height_dict = new Dictionary<string, VocationMountInfo.OnRideActionInfo>();
                for (int index = 0; index < mount_action_name_array.Count; ++index)
                {
                    List<string> list_str  = DBTextResource.ParseArrayString(GetReaderString(reader, mount_action_name_array[index]), ";");
                    if (list_str == null || list_str.Count == 0)
                        continue;
                    data.rider_self_height_dict[mount_action_name_array[index]] = new VocationMountInfo.OnRideActionInfo();
                    VocationMountInfo.OnRideActionInfo tmp_info = data.rider_self_height_dict[mount_action_name_array[index]];
                    if (list_str.Count >= 1)
                        tmp_info.mount_offset_dict = DBTextResource.ParseVector3(list_str[0]);
                    if (list_str.Count >= 2)
                    {
                        Vector2 v2  = DBTextResource.ParseVector2(list_str[1]);
                        tmp_info.self_center_height = v2.x;
                        tmp_info.self_height = v2.y;
                    }  
                }

                
                m_VocationMountInfos[vocation] = data;
            }
        }

        public Vector3 GetMountOffset(uint vocation, string action_name)
        {
            VocationMountInfo data = GetVocationMountInfo(vocation);
            if (data == null)
                return Vector3.zero;
            if (data.rider_self_height_dict.ContainsKey(action_name))
                return data.rider_self_height_dict[action_name].mount_offset_dict;
            return Vector3.zero;
        }

        public float GetSelfHeightOnRiding(uint vocation, string action_name)
        {
            VocationMountInfo data = GetVocationMountInfo(vocation);
            if (data == null)
                return 0;
            if (data.rider_self_height_dict.ContainsKey(action_name))
                return data.rider_self_height_dict[action_name].self_height;
            return 0;
        }
    }

}
