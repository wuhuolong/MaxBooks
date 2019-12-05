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
    public enum SexType : byte
    {
        BOY = 1,
        GIRL
    }

    public class VocationInfo
    {
        public uint vocation; // 表格id
        public string name;// 职业名字
        public string head_image; //头像名字
        public string big_head_image; //头像名字
        public string vocation_image; //职业对应的图标名字
        public string vocation_image_select; //职业对应的图标名字
        public string vocation_desc; //职业对应描述的物体名字
        public string create_sound; // 创建角色时候播放的声音
        public SexType sex_type; // 角色的性别类型
        public string common_skill_icon_main;   //主界面的普攻图标
        public string boss_chip_slot_name;  //碎片手上挂点
        public AnimatorCullingMode animator_cull_mode; //animator裁剪方式
        //public Vector3 mount_offset;    //坐骑场景偏移值
        public List<string> audios;//角色展示的音效
    }
    
    public class DBVocationInfo : DBSqliteTableResource
    {
        private Dictionary<uint, VocationInfo> m_VocationInfos;
        
        static DBVocationInfo mInstance;
        public static DBVocationInfo Instance
        {
            get{
                return mInstance;
            }
        }
        
        public DBVocationInfo(string name, string path)
            : base(name, path)
        {
            mInstance = this;
        }

        const int DefaultVocationID = 0;
        public VocationInfo GetVocationInfo(uint vocation)
        {
            VocationInfo data;
            if(!m_VocationInfos.TryGetValue(vocation, out data))
            {
                data = m_VocationInfos[DefaultVocationID];
                GameDebug.LogError("VocationType error, ID: " + vocation);
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

            m_VocationInfos = new Dictionary<uint, VocationInfo>();
            while (reader.Read())
            {
                var vocation = DBTextResource.ParseUI(GetReaderString(reader, "vocation"));
                
                VocationInfo data = new VocationInfo();
                data.vocation = vocation;
                data.name = GetReaderString(reader, "name");
                data.head_image = GetReaderString(reader, "head_image");
                data.big_head_image = GetReaderString(reader, "big_head_image");
                data.vocation_image = GetReaderString(reader, "vocation_image");
                data.vocation_image_select = GetReaderString(reader, "vocation_image_select");
                data.vocation_desc = GetReaderString(reader, "vocation_desc");
                data.create_sound = GetReaderString(reader, "create_sound");
                data.sex_type = (SexType)DBTextResource.ParseUI_s(GetReaderString(reader, "sex"),1);
                data.common_skill_icon_main = GetReaderString(reader, "common_skill_icon_main");
                data.boss_chip_slot_name = GetReaderString(reader, "boss_chip_slot_name");
                data.animator_cull_mode = (AnimatorCullingMode)DBTextResource.ParseUI_s(GetReaderString(reader, "animator_cull_mode"), (uint)AnimatorCullingMode.CullCompletely);
                //data.mount_offset = DBTextResource.ParseVector3(GetReaderString(reader, "mount_offset"));
                string rawAudio = GetReaderString(reader, "audios");
                data.audios = new List<string>();
                if (!string.IsNullOrEmpty(rawAudio))
                {
                    rawAudio = rawAudio.Replace(" ", "");
                    rawAudio = rawAudio.TrimStart('{');
                    rawAudio = rawAudio.TrimEnd('}');
                    data.audios.AddRange(rawAudio.Split(','));
                }
                m_VocationInfos[vocation] = data;
            }
        }
    }
}
