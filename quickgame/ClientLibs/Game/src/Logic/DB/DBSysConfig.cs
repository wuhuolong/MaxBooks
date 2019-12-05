//------------------------------------------------------------------------------
// File : DBSysGroupConfig.cs
// Desc : 系统开放的表
// Author : raorui
// Date : 2016.9.27 comments
//------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text.RegularExpressions;

namespace xc
{
    [wxb.Hotfix]
    public class DBSysConfig : DBSqliteTableResource
    {
        public enum ESysTaskType : byte
        {
            SYS_TASK_TYPE_NONE = 0,
            SYS_TASK_TYPE_ACCEPT = 1,
            SYS_TASK_TYPE_FINISH = 2,
        }

        public enum ESysBtnPos : byte
        {
            NONE = 0,

            /// <summary>
            ///  左下方可展开的系统按钮组
            /// </summary>
            SYS_LBBTN_POS = 1,

            /// <summary>
            /// 右上方的系统按钮组
            /// </summary>
            SYS_TRBTN_POS = 2,

            /// <summary>
            /// 右侧的系统按钮组
            /// </summary>
            SYS_RIGHT_POS = 3,
        }

        public enum ESysBtnFixType : byte
        {
            NOT_FIX = 0,
            FIX = 1,
            FIX_WHEN_REDPOINT = 2,
        }

        public class SysConfig : IComparable
        {
            public uint Id { get; protected set; }
            public ushort Level { get; protected set; }
            public ESysTaskType TaskType { get; protected set; }
            public uint TaskId { get; set; }
            public ESysBtnPos Pos { get; set; } // 按钮组的位置
            public uint SubPos { get; set; } // 子位置(表示右上角按钮组的行数)
            public ESysBtnFixType FixedPos { get; set; } // 按钮的位置是否固定(0:不固定,1:固定,2:有红点时固定)
            public bool ShowBg { get; set; } // 是否显示按钮背景
            public bool IsActivity { get; set; } // 是否是活动类型的系统
            public uint MainMapSysBtnId { get; set; }//主界面按钮id有可能会进入
            public string Desc { get; protected set; }
            public string BtnSprite { get; protected set; }
            public string BtnText { get; protected set; }
            public byte SortOrder { get; protected set; }
            public bool RedSpot { get; set; }
            public uint TransferLimit { get; set; }
            public string NotOpenTips { get; set; } //未开启系统提示 2018/4/11
            public string Title { get; set; }
            public bool InitNeedShow { get; set; }//是否一开始要在ui上显示
            public bool NeedAnim { get; set; }//是否要动画
            public int PatchId { get; set; }//分包id
            public bool HideBtnWhenActNotOpen { get; set; }//活动不开启的时候隐藏按钮
            public uint SysIdClosePresent { get; set; }//指定系统开启的时候关闭当前系统
            public uint TabOrder { get; set; }//页签排序
            public List<uint> DropDown { get; set; }//下拉系统列表
            public uint DropDownType { get; set; }//下拉系统列表类型
            public List<string> UIBehavior { get; set; }//系统按钮功能脚本
            public string TimeLimitStr { get; set; }
            public bool CustomCondition { get; set; }//自定义开启条件

            private DateTime timeLimit;

            /// <summary>
            /// 系统是否已经开放
            /// </summary>
            public bool IsOpened
            {
                get
                {
                    return SysConfigManager.Instance.CheckSysHasOpened(Id);
                }
            }

            /// <summary>
            /// 是否需要等待其他条件完成后再进行系统开放动画播放
            /// 比如: 坐骑激活的时候先弹出激活界面，关闭之后再飞系统开启图标
            /// </summary>
            public bool IsWaitingSystem
            {
                get
                {
                    if (Id == GameConst.SYS_OPEN_RIDE)
                    {
                        return true;
                    }
                    if (Id == GameConst.SYS_OPEN_GOD_WARE)
                    {
                        return true;
                    }
                    else if (TransferLimit > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }

            /// <summary>
            /// 等待其他条件完成后再进行系统开放动画播放
            /// </summary>
            public bool IsWaitFinished
            {
                get
                {
                    if (IsWaitingSystem == false)
                        return true;

                    if (Id == GameConst.SYS_OPEN_RIDE)
                        return LocalPlayerManager.Instance.IsFinishOpenMountAnim();
                    else if (Id == GameConst.SYS_OPEN_GOD_WARE)
                    {
                        return GodWareHelper.GetHasFinishShowGodWare();
                    }
                    else if (TransferLimit > 0)
                    {
                        return TransferHelper.HasFinishShowTransferSuc(TransferLimit);
                    }
                    else
                        return false;
                }
            }

            /// <summary>
            /// 开启时间戳
            /// </summary>
            public DateTime TimeLimit
            {
                get
                {
                    if (TimeLimitStr != "" && timeLimit.Year == 1 && timeLimit.Month == 1 && timeLimit.Day == 1)
                    {
                        TimeLimitStr = TimeLimitStr.Replace(" ", "");
                        var matchs = Regex.Matches(TimeLimitStr, @"\{(\w+),(\d+),\{(\d+),(\d+),(\d+)\}\}");
                        Dictionary<uint, float> list = new Dictionary<uint, float>();
                        foreach (Match _match in matchs)
                        {
                            if (_match.Success)
                            {
                                string type = _match.Groups[1].Value;
                                if (type == "open")
                                {
                                    DateTime ServerOpenDateTime = xc.Game.Instance.ServerOpenDateTime;
                                    int day = DBTextResource.ParseI(_match.Groups[2].Value);
                                    int hour = DBTextResource.ParseI(_match.Groups[3].Value);
                                    int min = DBTextResource.ParseI(_match.Groups[4].Value);
                                    int sec = DBTextResource.ParseI(_match.Groups[5].Value);
                                    timeLimit = new DateTime(ServerOpenDateTime.Year, ServerOpenDateTime.Month, ServerOpenDateTime.Day, hour, min, sec);
                                    timeLimit = timeLimit.AddDays(day-1);
                                }
                            }
                        }
                    }
                    return timeLimit;
                }
            }

            /// <summary>
            /// 开服天数限制
            /// </summary>
            public uint TimeLimitDay
            {
                get
                {
                    if (string.IsNullOrEmpty(TimeLimitStr))
                    {
                        return 0;
                    }
                    TimeLimitStr = TimeLimitStr.Replace(" ", "");
                    var matchs = Regex.Matches(TimeLimitStr, @"\{(\w+),(\d+),\{(\d+),(\d+),(\d+)\}\}");
                    Dictionary<uint, float> list = new Dictionary<uint, float>();
                    foreach (Match _match in matchs)
                    {
                        if (_match.Success)
                        {
                            string type = _match.Groups[1].Value;
                            if (type == "open")
                            {
                                return DBTextResource.ParseUI(_match.Groups[2].Value);
                            }
                        }
                        return 0;
                    }
                    return 0;
                }
            }

            public static byte NONE_ID = 0;

            public SysConfig(uint id)
            {
                Id = id;
                RedSpot = false;
            }

            public void Init(ushort lv, ESysTaskType task_type, uint task_id, ESysBtnPos pos, uint sub_pos, ESysBtnFixType fixed_pos, bool show_bg, bool is_activity,
                string desc, string btn_sprite, string btn_text, byte sort_order, uint transfer_limit, string not_open_tips ,string sys_title ,uint main_ui_id)
            {
                Level = lv;
                TaskType = task_type;
                TaskId = task_id;
                Pos = pos;
                SubPos = sub_pos;
                FixedPos = fixed_pos;
                ShowBg = show_bg;
                IsActivity = is_activity;
                Desc = desc;
                BtnSprite = btn_sprite;
                BtnText = btn_text;
                SortOrder = sort_order;
                TransferLimit = transfer_limit;
                NotOpenTips = not_open_tips;
                Title = sys_title;
                MainMapSysBtnId = main_ui_id;
            }

            public int CompareTo(object obj)
            {
                var config = obj as SysConfig;
                if (config == null)
                {
                    return -1;
                }

                /*var a = Level.CompareTo(config.Level);
                if (a != 0)
                    return a;*/

                // 在主ui上没有图标的排在后面
                if (Pos == ESysBtnPos.NONE && config.Pos != ESysBtnPos.NONE)
                    return 1;
                else if (Pos != ESysBtnPos.NONE && config.Pos == ESysBtnPos.NONE)
                    return -1;

                // 固定位置排在前面
                if (FixedPos == ESysBtnFixType.FIX && config.FixedPos != ESysBtnFixType.FIX)
                    return -1;
                else if (FixedPos != ESysBtnFixType.FIX && config.FixedPos == ESysBtnFixType.FIX)
                    return 1;

                var a = SortOrder.CompareTo(config.SortOrder);
                if (a != 0)
                    return a;

                return Id.CompareTo(config.Id);
            }
        }

        private List<SysConfig> mConfigList;

        /// <summary>
        /// 系统列表
        /// </summary>
        private Dictionary<uint, SysConfig> mConfigMap;

        /// <summary>
        /// 系统关系表(key: 系统id, value: key系统开启的时候要关闭的系统id列表)
        /// </summary>
        private Dictionary<uint, List<uint>> mConfigRelation;

        static DBSysConfig mInstance;
        public static DBSysConfig Instance
        {
            get
            {
                return mInstance;
            }
        }

        public DBSysConfig(string strName, string strPath)
            : base(strName, strPath)
        {
            mInstance = this;
            mConfigList = new List<SysConfig>();
            mConfigMap = new Dictionary<uint, SysConfig>();
            mConfigRelation = new Dictionary<uint, List<uint>>();
        }

        public override void Unload()
        {
            base.Unload();
            mConfigList.Clear();
            mConfigMap.Clear();
            mConfigRelation.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if(reader == null || !reader.HasRows)
            {
                return;
            }

            SysConfig config = null;
            while (reader.Read())
            {
                var id = DBTextResource.ParseUI(GetReaderString(reader, "sys_id"));
                config = new SysConfig(id);
                var sys_title = GetReaderString(reader, "sys_title");

                var level = DBTextResource.ParseUS_s(GetReaderString(reader, "lv_open"), 0);
                string taskTypeStr = GetReaderString(reader, "task_limit");
                if (string.IsNullOrEmpty(taskTypeStr))
                {
                    taskTypeStr = "0";
                }
                var task_type = (ESysTaskType)Enum.Parse(typeof(ESysTaskType), taskTypeStr);
                var task_id = DBTextResource.ParseUI_s(GetReaderString(reader, "task_args"), 0);
                string positionStr = GetReaderString(reader, "position");
                if (string.IsNullOrEmpty(positionStr))
                {
                    positionStr = "0";
                }
                var pos = (ESysBtnPos)Enum.Parse(typeof(ESysBtnPos), positionStr);
                uint sub_pos = DBTextResource.ParseUI_s(GetReaderString(reader, "sub_pos"), 0);
                string fixedPosStr = GetReaderString(reader, "fixed_pos");
                if (string.IsNullOrEmpty(fixedPosStr))
                {
                    fixedPosStr = "0";
                }
                var is_fixed = (ESysBtnFixType)DBTextResource.ParseUI_s(fixedPosStr, 1);
                bool show_bg = DBTextResource.ParseUI_s(GetReaderString(reader, "show_bg"), 0) == 1;
                uint is_activity = DBTextResource.ParseUI_s(GetReaderString(reader, "is_activity"), 0);
                var desc = GetReaderString(reader, "desc");
                var btn_sprite = GetReaderString(reader, "btn_spr");
                var btn_text = GetReaderString(reader, "btn_text");
                var sort_order = DBTextResource.ParseBT_s(GetReaderString(reader, "sort_order"), 0);
                var transfer_limit = DBTextResource.ParseUI_s(GetReaderString(reader, "transfer_limit"), 0);
                var not_open_tips = GetReaderString(reader, "not_open_tips");
                var main_ui_btn_id = DBTextResource.ParseUI_s(GetReaderString(reader, "main_ui_btn_id"), 0);

                config.Init(level, task_type, task_id, pos, sub_pos, is_fixed, show_bg, is_activity == 1,  desc, btn_sprite, btn_text, sort_order, transfer_limit, not_open_tips, sys_title, main_ui_btn_id);
                config.NeedAnim = DBTextResource.ParseUI_s(GetReaderString(reader, "is_need_anim"), 0) == 0 ? false : true;
                
                if (pos == ESysBtnPos.NONE) // 当在主ui上没有按钮图标的时候，也一定不需要播放开启的动画
                {
                    if(config.NeedAnim)
                    {
                        config.NeedAnim = false;
                        GameDebug.LogError(string.Format("sys:{0} 在主ui上没有图标, 却配置了开启动画", id));
                    }
                }

                config.InitNeedShow = DBTextResource.ParseUI_s(GetReaderString(reader, "is_need_show"), 0) == 0 ? false : true;
                config.PatchId = DBTextResource.ParseI_s(GetReaderString(reader, "patch_id"), 0);
                config.HideBtnWhenActNotOpen = DBTextResource.ParseUI_s(GetReaderString(reader, "hide_btn_when_act_not_open"), 0) == 0 ? false : true;
                config.SysIdClosePresent = DBTextResource.ParseUI_s(GetReaderString(reader, "sys_id_close_present"), 0);

                // 如果有系统开放关联配置，需要将数据存在另外的字典中
                if (config.SysIdClosePresent != 0)
                {
                    List<uint> notifySysIdList = null;
                    if(!mConfigRelation.TryGetValue(config.SysIdClosePresent, out notifySysIdList))
                    {
                        notifySysIdList = new List<uint>();
                        mConfigRelation[config.SysIdClosePresent] = notifySysIdList;
                    }

                    if (!notifySysIdList.Contains(config.Id))
                        notifySysIdList.Add(config.Id);
                }
                config.TabOrder = DBTextResource.ParseUI_s(GetReaderString(reader, "tab_order"), 0);
                config.DropDown = DBTextResource.ParseArrayUint(GetReaderString(reader, "drop_down"), ",");
                config.DropDownType = DBTextResource.ParseUI(GetReaderString(reader, "drop_down_type"));
                config.UIBehavior = DBTextResource.ParseArrayString(GetReaderString(reader, "ui_behavior"));
                config.TimeLimitStr = GetReaderString(reader, "time_limit");
                config.CustomCondition = DBTextResource.ParseUI_s(GetReaderString(reader, "custom_condition"), 0) == 0 ? false : true;

                mConfigList.Add(config);
                mConfigMap[config.Id] = config;
            }

            mConfigList.Sort();
        }

        /// <summary>
        /// 获取所有系统开放的设置
        /// </summary>
        public List<SysConfig> GetAllSysConfig()
        {
            return mConfigList;
        }

        // APIS
        public SysConfig GetConfigById(uint sys_id)
        {
            SysConfig config = null;
            mConfigMap.TryGetValue(sys_id, out config);
            return config;
        }

        /// <summary>
        /// 获取系统sys_id开启的时候需要关闭的系统列表
        /// </summary>
        /// <param name="sys_id"></param>
        /// <returns></returns>
        public List<uint> GetRelationSysById(uint sys_id)
        {
            List<uint> sysList = null;
            mConfigRelation.TryGetValue(sys_id, out sysList);
            return sysList;
        }

        /// <summary>
        /// 获取第一个主id的config
        /// </summary>
        /// <param name="mainId"></param>
        /// <returns></returns>
        public SysConfig GetFirstMainId(uint mainId)
        {
            SysConfig firstConfig = null;
            foreach (SysConfig config in mConfigList)
            {
                if (config.MainMapSysBtnId == mainId)
                {
                    firstConfig = config;
                }
                if (config.Id == mainId)    //如果id相等直接返回
                {
                    return config;
                }
            }
            return firstConfig;
        }

        /// <summary>
        /// 某个系统未开启时是否显示锁
        /// </summary>
        /// <param name="sys_id"></param>
        /// <returns></returns>
        public bool IsShowLock(uint sys_id)
        {
            SysConfig sysConfig = GetConfigById(sys_id);
            if (sysConfig == null)
            {
                return false;
            }
            else
            {
                return sysConfig.InitNeedShow;
            }
        }
    }
}

