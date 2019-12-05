//------------------------------------------------------------------------------
// File : DBSysGroupConfig.cs
// Desc : 系统开放组的表
// Author : raorui
// Date : 2016.9.27 comments
//------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSysGroupConfig : DBSqliteTableResource
    {
        public class SysGroup : IComparable
        {
            public uint GroupId { get; protected set; }
            public string BtnSprite { get; protected set; }
            public string BtnText { get; protected set; }
            public DBSysConfig.ESysBtnPos Pos { get; protected set; }
            public string EffectName { get; protected set; }

            public List<DBSysConfig.SysConfig> ChildSysConfigs { get; protected set; }

            public uint Level
            {
                get
                {
                    if (FirstSys == null)
                        return uint.MaxValue;

                    return FirstSys.Level;
                }
            }
            public bool RedSpot
            {
                get
                {
                    if (ChildSysConfigs == null)
                        return false;

                    foreach (var sys in ChildSysConfigs)
                        if (sys.RedSpot && sys.IsOpened)
                            return true;

                    return false;
                }
            }

            /// <summary>
            /// 系统是否已经开放
            /// </summary>
            public bool IsOpened
            {
                get
                {
                    foreach (var sys in ChildSysConfigs)
                        if (sys.IsOpened)
                            return true;

                    return false;
                }
            }

            public DBSysConfig.SysConfig FirstSys
            {
                get
                {
                    if (ChildSysConfigs == null)
                        return null;

                    return ChildSysConfigs[0];
                }
            }

            public SysGroup(uint group_id, string btn_sprite, string btn_text, DBSysConfig.ESysBtnPos pos, string effect_name)
            {
                GroupId = group_id;

                BtnSprite = btn_sprite;
                BtnText = btn_text;
                Pos = pos;
                EffectName = effect_name;
            }

            public void AddSysConfig(DBSysConfig.SysConfig sys)
            {
                if (ChildSysConfigs == null)
                    ChildSysConfigs = new List<DBSysConfig.SysConfig>();
                

                ChildSysConfigs.Add(sys);
                ChildSysConfigs.Sort();
            }

            public int CompareTo(object obj)
            {
                var config = obj as SysGroup;
                if (config == null)
                {
                    return 1;
                }
                return Level.CompareTo(config.Level);
            }
        };

        List<SysGroup> mConfigGroupList;

        public DBSysGroupConfig(string strName, string strPath)
            : base(strName, strPath)
        {
            mConfigGroupList = new List<SysGroup>();
        }

        public override void Unload()
        {
            base.Unload();
            mConfigGroupList.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if(reader == null || !reader.HasRows)
            {
                return;
            }

//             var db_sys_config = DBManager.Instance.GetDB<DBSysConfig>();
//             while (reader.Read())
//             {
//                 var id = DBTextResource.ParseUI(GetReaderString(reader, "group_id"));
//                 var pos = (DBSysConfig.ESysBtnPos)Enum.Parse(typeof(DBSysConfig.ESysBtnPos), GetReaderString(reader, "position"));
//                 var btn_sprite = GetReaderString(reader, "btn_spr");
//                 var btn_text = GetReaderString(reader, "btn_text");
//                 var effect_name = GetReaderString(reader, "effect");
// 
//                 var sys_group = new SysGroup(id, btn_sprite, btn_text, pos, effect_name);
// 
//                 var child_list = GetReaderString(reader, "child_sys");
//                 foreach (var sys_id in child_list.Split(','))
//                 {
//                     var config = db_sys_config.GetConfigById(uint.Parse(sys_id));
//                     if (config != null)
//                     {
//                         sys_group.AddSysConfig(config);
//                         config.Group = sys_group;
//                     }
//                 }
// 
//                 mConfigGroupList.Add(sys_group);
//             }
//             mConfigGroupList.Sort();
        }

        /// <summary>
        /// 获取所有的系统组的设置
        /// </summary>
        public List<SysGroup> GetAllSysConfigGroup()
        {
            return mConfigGroupList;
        }
    }
}


