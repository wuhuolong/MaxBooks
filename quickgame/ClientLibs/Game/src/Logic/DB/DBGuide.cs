//---------------------------------------
// File:    GuideData.cs
// Desc:    引导组的表格
// Author:  Raorui
// Date:    2017.9.21
//---------------------------------------
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class GuideData : IComparable
    {
        /// <summary>
        ///  引导组触发的枚举
        /// </summary>
        public enum GuideTrigger
        {
            TRIGER_LEVELE = 1, // 角色等级触发
            TRIGER_CAN_ACCEPT, //有可接取的任务
            TRIGER_TASK_FINISH, // 完成任务触发
            TRIGER_CAN_SUBMIT, // 有可提交任务触发
            TRIGER_ENTER_INSTANCE, // 进入指定的副本
            TRIGER_ADD_GOODS, // 获得了指定物品
            TRIGER_GUIDE_FINISH, // 完成了指定的新手引导
            TRIGER_ADD_SOUL, // 获得了指定ID的武魂
            TRIGER_FURY_ENOUGH, // 怒气技能可释放
        }

        /// <summary>
        /// 引导id
        /// </summary>
        public uint Id;

        /// <summary>
        /// 优先级
        /// </summary>
        public ushort Priority;

        /// <summary>
        /// 需求系统
        /// </summary>
        public uint PreSys;

        /// <summary>
        /// 需求等级
        /// </summary>
        public uint MinLevel;

        /// <summary>
        /// 需求的副本类型
        /// </summary>
        public int InstanceType;

        /// <summary>
        /// 需求的副本子类型
        /// </summary>
        public int InstanceSubType;

        /// <summary>
        /// 最大等级（大于这个等级不引导）
        /// </summary>
        public uint MaxLevel;

        /// <summary>
        /// 触发的条件
        /// </summary>
        public GuideTrigger TriggerType;

        /// <summary>
        /// 触发的参数
        /// </summary>
        public List<uint> TriggerParams;

        /// <summary>
        /// 引导结束后是否自动挂机
        /// </summary>
        public bool AutoFightWhenFinish;

        /// <summary>
        /// 引导结束后要播放的剧情
        /// </summary>
        public uint TimelineWhenFinish = 0;

        /// <summary>
        /// 引导结束且返回主界面后是否执行主线任务
        /// </summary>
        public bool GuideMainTaskWhenFinishAndReturnMainWnd;

        bool m_IsFinish = false;

        /// <summary>
        /// 开始引导时的服务器时间戳(用于打点日志)
        /// </summary>
        public uint StartTime = 0;

        /// <summary>
        /// 开始引导时的角色等级(用于打点日志)
        /// </summary>
        public uint StartPlayerLevel = 1;

        /// <summary>
        /// 是否完成了
        /// </summary>
        public bool IsFinished
        {
            get
            {
                return m_IsFinish;
            }

            set
            {
                m_IsFinish = value;
            }
        }

        //等于返回0值，大于返回大于0的值，小于返回小于0的值。
        public int CompareTo(object obj)
        {
            if(obj == null)
                return -1;

            GuideData guide = (GuideData)obj;
            int ret = Priority.CompareTo(guide.Priority);
            if (ret != 0)
                return ret;
            else
                return Id.CompareTo(guide.Id);
        }
    }

    public class DBGuide : DBSqliteTableResource
    {
        public Dictionary<uint, GuideData> Guides { get; private set; }
        public List<GuideData> GuideList { get; private set; }

        public DBGuide(string strName, string strPath)
            : base(strName, strPath)
        {
            Guides = new Dictionary<uint, GuideData>();
            GuideList = new List<GuideData>();
        }

        public override void Load()
        {
            base.Load();
        }

        public override void Unload()
        {
            base.Unload();
            Guides.Clear();
            GuideList.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                var guide = new GuideData();

                guide.Id = DBTextResource.ParseUI(GetReaderString(reader, "guide_id"));
                guide.Priority = DBTextResource.ParseUS(GetReaderString(reader, "priority"));
                guide.PreSys = DBTextResource.ParseUI(GetReaderString(reader, "sys"));
                guide.MinLevel = DBTextResource.ParseUI(GetReaderString(reader, "min_level"));
                guide.MaxLevel = DBTextResource.ParseUI(GetReaderString(reader, "max_level"));
                guide.InstanceType = DBTextResource.ParseI_s(GetReaderString(reader, "inst_type"), -1);
                guide.InstanceSubType = DBTextResource.ParseI_s(GetReaderString(reader, "inst_sub_type"), -1);
                guide.TriggerType = (GuideData.GuideTrigger)Enum.Parse(typeof(GuideData.GuideTrigger), GetReaderString(reader, "trigger_type"));
                guide.TriggerParams = new List<uint>();
                string[] param =TextHelper.GetListFromString(GetReaderString(reader, "trigger_params"));
                if(param != null)
                {
                    foreach(string s in param)
                    {
                        guide.TriggerParams.Add(DBTextResource.ParseUI_s(s, 0));
                    }
                }

                string rawStr = GetReaderString(reader, "auto_fight_when_finish");
                if (string.IsNullOrEmpty(rawStr) == true || rawStr.Equals("0") == true)
                {
                    guide.AutoFightWhenFinish = false;
                }
                else
                {
                    guide.AutoFightWhenFinish = true;
                }

                guide.TimelineWhenFinish = DBTextResource.ParseUI_s(GetReaderString(reader, "timeline_when_finish"), 0);

                rawStr = GetReaderString(reader, "guide_main_task_when_finish_and_return_main_wnd");
                if (string.IsNullOrEmpty(rawStr) == true || rawStr.Equals("0") == true)
                {
                    guide.GuideMainTaskWhenFinishAndReturnMainWnd = false;
                }
                else
                {
                    guide.GuideMainTaskWhenFinishAndReturnMainWnd = true;
                }

                guide.IsFinished = false;

                Guides.Add(guide.Id, guide);
                GuideList.Add(guide);
            }

            GuideList.Sort();
        }

        // APIs
        public void Reset()
        {
            foreach (var guide in GuideList)
            {
                guide.IsFinished = false;
                guide.StartPlayerLevel = 1;
                guide.StartTime = 0;
            }
        }

        public void ResetGuide(uint guide_id)
        {
            var guide = GetGuideById(guide_id);
            if (guide != null)
                guide.IsFinished = false;
        }

        /// <summary>
        /// 获取所有可执行的系统新手指引
        /// </summary>
        /// <returns></returns>
        public List<GuideData> GetActiveGuides()
        {
            var active_guides_list = new List<GuideData>();
            var sys_config_manager = SysConfigManager.GetInstance();
            foreach (var guide in GuideList)
            {
                if (!guide.IsFinished)
                {
                    // 检查等级条件
                    if (guide.MinLevel > 1u)
                    {
                        if (LocalPlayerManager.Instance.LocalActorAttribute == null || LocalPlayerManager.Instance.LocalActorAttribute.Level < guide.MinLevel)
                        {
                            continue;
                        }
                    }
                    if (guide.MaxLevel > 0u)
                    {
                        if (LocalPlayerManager.Instance.LocalActorAttribute == null || LocalPlayerManager.Instance.LocalActorAttribute.Level > guide.MaxLevel)
                        {
                            continue;
                        }
                    }

                    // 检查副本类型条件
                    if(guide.InstanceType != -1)
                    {
                        if (InstanceManager.Instance.InstanceType != guide.InstanceType)
                            continue;
                        if (guide.InstanceSubType != -1)
                        {
                            if (InstanceManager.Instance.InstanceSubType != guide.InstanceSubType)
                                continue;
                        }
                    }
                    
                    // 检查任务条件
                    if (guide.TriggerType == GuideData.GuideTrigger.TRIGER_CAN_ACCEPT)// 已接取任务
                    {
                        uint task_id = 0;
                        if (guide.TriggerParams.Count > 0)
                        {
                            task_id = guide.TriggerParams[0];
                        }

                        if (task_id > 0)
                        {
                            if (!TaskHelper.IsTaskAccepted(task_id))
                                continue;
                        }
                    }
                    else if (guide.TriggerType == GuideData.GuideTrigger.TRIGER_TASK_FINISH)// 任务已完成
                    {
                        uint task_id = 0;
                        if (guide.TriggerParams.Count > 0)
                        {
                           task_id = guide.TriggerParams[0];
                        }

                        if (task_id > 0)
                        {
                            if (!GuideManager.Instance.IsTaskFinished(task_id))
                                continue;
                        }
                    }
                    else if(guide.TriggerType == GuideData.GuideTrigger.TRIGER_CAN_SUBMIT)// 任务可提交
                    {
                        uint task_id = 0;
                        if (guide.TriggerParams.Count > 0)
                        {
                            task_id = guide.TriggerParams[0];
                        }

                        if (task_id > 0)
                        {
                            if (!TaskHelper.IsTaskCanSubmit(task_id))
                                continue;
                        }
                    }
                    else if(guide.TriggerType == GuideData.GuideTrigger.TRIGER_ENTER_INSTANCE)// 进入指定副本
                    {
                        uint instance_id = 0;
                        if (guide.TriggerParams.Count > 0)
                        {
                            instance_id = guide.TriggerParams[0];
                        }

                        if (instance_id > 0)
                        {
                            uint cur_inst_id = 0;
                            if (InstanceManager.Instance.InstanceInfo != null)
                                cur_inst_id = InstanceManager.Instance.InstanceInfo.mId;

                            if (cur_inst_id != instance_id)
                                continue;

                            // 当前副本有剧情,未播放过并且没播放完毕的时候需要等剧情播放后再进行新手引导
                            uint timeline_id = DBInstance.Instance.GetInstanceStartTimeline(instance_id);
                            if (timeline_id != 0 && TimelineManager.Instance.IsInstanceStartTimelinePlayed(string.Format("{0}_{1}", instance_id,timeline_id)) == false
                                && GuideManager.Instance.IsTimelineFinish(timeline_id) == false)
                            {
                                continue;
                            }
                        }
                    }
                    else if(guide.TriggerType == GuideData.GuideTrigger.TRIGER_ADD_GOODS)// 获得指定物品
                    {
                        if (guide.TriggerParams.Count > 0)
                        {
                            bool has_goods = false;
                            foreach (var goods_id in guide.TriggerParams)
                            {
                                if (goods_id > 0)
                                {
                                    if (ItemManager.Instance.ExistGoods(goods_id))
                                    {
                                        has_goods = true;
                                        break;
                                    }
                                }
                            }

                            if (has_goods == false)
                                continue;
                        }
                    }
                    else if (guide.TriggerType == GuideData.GuideTrigger.TRIGER_ADD_SOUL)// 获得指定武魂物品
                    {
                        if (guide.TriggerParams.Count > 0)
                        {
                            bool exist_soul = false;
                            foreach (var soul_id in guide.TriggerParams)
                            {
                                if (soul_id > 0)
                                {
                                    if (ItemManager.Instance.ExistSoul(soul_id))
                                    {
                                        exist_soul = true;
                                        break;
                                    }
                                }
                            }

                            if (exist_soul == false)
                                continue;
                        }
                    }
                    else if(guide.TriggerType == GuideData.GuideTrigger.TRIGER_FURY_ENOUGH)// 怒气技能可释放
                    {
                        if (FuryButton.IsFurySkillReady() == false)
                            continue;
                    }
                    else if(guide.TriggerType == GuideData.GuideTrigger.TRIGER_GUIDE_FINISH)// 完成了指定的新手引导
                    {
                        uint guide_id = 0;
                        if (guide.TriggerParams.Count > 0)
                        {
                            guide_id = guide.TriggerParams[0];
                        }

                        if (guide_id > 0)
                        {
                            if (IsGuideFinish(guide_id) == false)
                                continue;
                        }
                    }

                    // 检查系统开放条件
                    if (guide.PreSys == 0)
                    {
                        active_guides_list.Add(guide);
                    }
                    else if (sys_config_manager.IsSysOpened(guide.PreSys))
                    {
                        active_guides_list.Add(guide);
                    }
                }
            }

            //active_guides_list.Sort(); 已经排序
            return active_guides_list;
        }

        public GuideData GetGuideById(uint guideId)
        {
            if (!Guides.ContainsKey(guideId))
            {
                return null;
            }
            return Guides [guideId];
        }

        /// <summary>
        /// 指定的新手引导是否已经完成
        /// </summary>
        /// <param name="guide_id"></param>
        /// <returns></returns>
        public bool IsGuideFinish(uint guide_id)
        {
            GuideData guide = null;
            if (Guides.TryGetValue(guide_id, out guide))
            {
                return guide.IsFinished;
            }
            else
                return false;
        }

        public void FinishAllSysGuide()
        {
            foreach (var guide in GuideList)
            {
                guide.IsFinished = true;
            }
        }
    }
}