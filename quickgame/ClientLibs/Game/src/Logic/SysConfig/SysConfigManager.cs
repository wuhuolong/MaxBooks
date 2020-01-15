//---------------------------------------------
// File: SysConfigManager.cs
// Desc: 系统开放管理类
// Author: raorui 重构
// Date: 2017.11.16
//---------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xc;
using xc.ui;
using xc.protocol;
using Net;

namespace xc
{
    /// <summary>
    /// 系统开放管理器
    /// </summary>
    [wxb.Hotfix]
    public class SysConfigManager : xc.Singleton<SysConfigManager>
    {
        /// <summary>
        /// 已经开放的系统列表(活动关闭时从其中移除)
        /// </summary>
        private List<DBSysConfig.SysConfig> mOpenSysList;

        /// <summary>
        /// 已经开放的系统字典(活动关闭时从其中移除)
        /// </summary>
        private Dictionary<uint, DBSysConfig.SysConfig> mOpenSysDic;

        /// <summary>
        /// 播放系统开放动画的系统，需要放到waiting list中按顺序执行
        /// </summary>
        private List<DBSysConfig.SysConfig> mWaitingSysList;

        /// <summary>
        /// 已经关闭的系统列表
        /// </summary>
        private List<DBSysConfig.SysConfig> mClosedSysList;

        /// <summary>
        /// 需要等待的网络消息
        /// </summary>
        private Dictionary<ushort, bool> mWaitNetMsg;

        /// <summary>
        /// 记录已经开放系统的id列表(不考虑活动关闭的情况)
        /// </summary>
        private List<uint> mRawOpenSysIds;

        public bool SkipSysOpen = false;

        public SysConfigManager()
        {
            mOpenSysList = new List<DBSysConfig.SysConfig>();
            mOpenSysDic = new Dictionary<uint, DBSysConfig.SysConfig>();
            mWaitingSysList = new List<DBSysConfig.SysConfig>();
            mClosedSysList = new List<DBSysConfig.SysConfig>();
            mWaitNetMsg = new Dictionary<ushort, bool>();
            mRawOpenSysIds = new List<uint>();
        }
        
        // APIs
        public void RegisterAllMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_SYS_OPEN_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_NOTIFY_SYS_OPEN, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_NOTIFY_SYS_CLOSE, HandleServerData);


            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_OPERATING_ACTIVITY_INIT, OnOperatingActivityInit);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_OPERATING_ACTIVITY_OPEN, OnOperatingActivityOpen);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_OPERATING_ACTIVITY_CLOSE, OnOperatingActivityClose);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ACTIVITY_DAILY, OnActivityStateInit);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ACTIVITY_STATE_CHANGED, OnActivityStateChange);
        }

        public void Reset()
        {
            mOpenSysList.Clear();
            mOpenSysDic.Clear();
            mWaitingSysList.Clear();
            mClosedSysList.Clear();
            mWaitNetMsg.Clear();
            mWaitNetMsg[NetMsg.MSG_PLAYER_SYS_OPEN_INFO] = false;
            mWaitNetMsg[NetMsg.MSG_ACT_YUNYING_OPEN] = false;
            mWaitNetMsg[NetMsg.MSG_ACT_DAILY] = false;
            mRawOpenSysIds.Clear();
            SkipSysOpen = false;
        }

        public void OpenSys(DBSysConfig.SysConfig config, bool fire_evet = true)
        {
            if (mWaitingSysList.Contains(config))
            {
                mWaitingSysList.Remove(config);
            }

            if(!mRawOpenSysIds.Contains(config.Id))
            {
                mRawOpenSysIds.Add(config.Id);
            }

            if (!mOpenSysDic.ContainsKey(config.Id))
            {
                mOpenSysList.Add(config);
                mOpenSysList.Sort();
                mOpenSysDic[config.Id] = config;
            }

            if (fire_evet)
            {

                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_OPEN, new CEventBaseArgs(config));

                // 在野外需要发送特殊的系统开启事件
                if (xc.SceneHelp.Instance.IsInWildInstance())
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SYS_OPEN_POST, new CEventBaseArgs(config.Id));
                }
                else
                    ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_SYS_OPEN_POST, new CEventBaseArgs(config.Id));
            }

        }

        public List<DBSysConfig.SysConfig> GetAllOpenSysList()
        {
            return mOpenSysList;
        }

        public List<DBSysConfig.SysConfig> GetAllWaitingSysList()
        {
            return mWaitingSysList;
        }

        public DBSysConfig.SysConfig GetSysConfigById(uint sys_id)
        {
            var dbSysConfig = DBManager.GetInstance().GetDB<DBSysConfig>();
            return dbSysConfig.GetConfigById(sys_id);

        }

        /// <summary>
        /// 检查传入的系统id是否已开放(活动关闭时也返回false)
        /// </summary>
        /// <param name="sys_id"></param>
        /// <returns></returns>
        public bool CheckSysHasOpened(uint sys_id)
        {
            return CheckSysHasOpened(sys_id, false);
        }

        /// <summary>
        /// 检查传入的系统id是否已开放(排除活动开关的影响)
        /// </summary>
        /// <param name="sys_id"></param>
        /// <returns></returns>
        public bool CheckSysHasOpenIgnoreActivity(uint sys_id)
        {
            var db_sys_config = DBManager.GetInstance().GetDB<DBSysConfig>();
            var config = db_sys_config.GetConfigById(sys_id);
            if (config == null)
            {
                return false;
            }

            bool is_open = false;
            uint id = mRawOpenSysIds.Find(delegate (uint _id) { return sys_id == _id; });
            if (id != 0)
                is_open = true;

            var sys_config = mWaitingSysList.Find(delegate (DBSysConfig.SysConfig _config) { return sys_id == _config.Id; });
            if (sys_config != null)
                is_open = true;

            // 如果后端下发的系统为开启状态，且需要前端加条件，才进入此判断
            if (is_open && config.CustomCondition == true) {
                return GetCustomSysHasOpened(sys_id);
            }

            return is_open;
        }

        public bool CheckSysHasDownloaded(uint sys_id, out int patch_id)
        {
            var sys_config = GetSysConfigById(sys_id);
            if (sys_config != null) {
                patch_id = sys_config.PatchId;
                return xpatch.XPatchManager.Instance.IsPatchDownloaded(patch_id);
            }

            GameDebug.LogError(string.Format("CheckSysHasDownloaded Invalid sys_id == {0}", sys_id));

            // 兼容系统id错误这种异常情况
            patch_id = -1;
            return true;
        }

        public bool IsWaiting()
        {
            return mWaitingSysList.Count > 0;
        }

        /// <summary>
        /// 给定的系统id是否已经开放完毕(不检查WaitingList)
        /// </summary>
        /// <param name="sys_id"></param>
        /// <returns></returns>
        public bool IsSysOpened(uint sys_id)
        {
            var db_sys_config = DBManager.GetInstance().GetDB<DBSysConfig>();
            var config = db_sys_config.GetConfigById(sys_id);
            if (config == null)
            {
                return false;
            }

            bool is_open = false;

            if (mOpenSysDic.TryGetValue(sys_id, out config) && config != null)
            {
                is_open = true;
            }

            return is_open;
        }

        public bool CheckSysHasOpened(uint sys_id, bool need_tips)
        {
            var db_sys_config = DBSysConfig.Instance;// DBManager.GetInstance().GetDB<DBSysConfig>();
            var config = db_sys_config.GetConfigById(sys_id);
            if (config == null)
            {
                return false;
            }

            bool is_open = false;

            DBSysConfig.SysConfig openConfig;
            if (mOpenSysDic.TryGetValue(sys_id, out openConfig) && openConfig != null)
            {
                is_open = true;
            }

            // 再从等待的系统列表中寻找
            if(!is_open)
            {
                var waitSysCount = mWaitingSysList.Count;
                for (int i = 0; i < waitSysCount; ++i)
                {
                    var wait_sys_config = mWaitingSysList[i];
                    if (wait_sys_config == null)
                        continue;

                    if (wait_sys_config.Id == sys_id)
                    {
                        is_open = true;
                        break;
                    }
                }
            }

            // 如果后端下发的系统为开启状态，且需要前端加条件，才进入此判断
            if (is_open && config.CustomCondition == true) {
                return GetCustomSysHasOpened(sys_id);
            }

            if (!is_open && need_tips)
            {
                if(!string.IsNullOrEmpty(config.NotOpenTips))//策划配置的提示
                {
                    UINotice.GetInstance().ShowMessage(config.NotOpenTips);
                }
                else
                {
                    UINotice.GetInstance().ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_95"));
                }
            }

            return is_open;
        }

        /// <summary>
        /// 获取自定义系统开启条件结果
        /// </summary>
        /// <param name="sys_id">系统id</param>
        /// <returns>是否开放</returns>
        private bool GetCustomSysHasOpened(uint sys_id)
        {
            var is_open = false;
            if (LuaScriptMgr.Instance != null) {
                object[] func_param = { sys_id };
                System.Type[] return_type = { typeof(bool) };
                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "SysOpenHelper_GetCustomSysHasOpened", func_param, return_type);
                if (objs != null && objs.Length >= 1) {
                    is_open = (bool)(objs[0]);
                }
            }
            return is_open;
        }

        private DBSysConfig.SysConfig GetSysConfigAt(List<DBSysConfig.SysConfig> list, uint sys_id)
        {
            foreach (var config in list)
            {
                if (config.Id == sys_id)
                {
                    return config;
                }
            }

            return null;
        }

        public DBSysConfig.SysConfig GetWaittingSysConfig(uint sys_id)
        {
            return GetSysConfigAt(mWaitingSysList, sys_id);
        }

        public void MarkRedSpotById(int sys_id, bool red_spot)
        {
            var sys_config = DBManager.Instance.GetDB<DBSysConfig>().GetConfigById((uint)sys_id);
            if (sys_config != null)
            {
                sys_config.RedSpot = red_spot;
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SYS_RED_SPOT_CHANGE, new CEventBaseArgs(sys_config));
            }
        }


        /// <summary>
        /// 获取指定显示位置的系统按钮的最早开放等级
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public uint GetFirstOpenSysByPos(DBSysConfig.ESysBtnPos pos)
        {
            var db_sys_config = DBManager.Instance.GetDB<DBSysConfig>();
            foreach (var sys in db_sys_config.GetAllSysConfig())
            {
                if (sys.Pos == pos)
                    return sys.Level;
            }

            return 0;
        }

        public bool AutoExpandLeft = true;

        public void ForceOpenSys(uint sys_id)
        {
            HandleNotifySysOpen(sys_id);
        }

        public void ForceCloseSys(uint sys_id)
        {
            HandleNotifySysClose(sys_id);
        }

        /// <summary>
        /// 检查包括活动在内所有系统的开启
        /// </summary>
        private void CheckSysOpenCondition()
        {
            bool all_inited = true;
            foreach (var recv in mWaitNetMsg.Values)
            {
                if (recv == false)
                {
                    all_inited = false;
                    break;
                }
            }

            if (all_inited)
            {
                var db_sys_config = DBManager.GetInstance().GetDB<DBSysConfig>();
                foreach (var sys_id in mRawOpenSysIds)
                {
                    //GameDebug.LogRed("初始系统：id=" + sys_id);
                    var sys_config = db_sys_config.GetConfigById(sys_id);
                    if (sys_config != null)
                    {
                        // 活动类型的系统需要检查活动是否开启
                        if (sys_config.IsActivity)
                        {
                            bool is_open = ActivityHelper.IsActivityOpen(sys_config.Id);
                            if (is_open)
                            {
                                mOpenSysList.Add(sys_config);
                                mOpenSysDic[sys_config.Id] = sys_config;
                            }
                            else
                                GameDebug.LogRed(string.Format("系统: id= {0} 对应的活动未开启", sys_id));
                        }
                        else
                        {
                            mOpenSysList.Add(sys_config);
                            mOpenSysDic[sys_config.Id] = sys_config;
                        }
                    }
                    else
                        GameDebug.LogWarning(string.Format("[MSG_PLAYER_SYS_OPEN_INFO] 找不到对应的系统：{0}", sys_id));
                }
                mOpenSysList.Sort();

                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SYS_CONFIG_INIT, null);
            }
        }

        #region 处理网络消息

        /// <summary>
        /// 响应系统开放的网络消息
        /// </summary>
        /// <param name="sys_id"></param>
        public void HandleNotifySysOpen(uint sys_id)
        {
            GameDebug.LogRed("系统开启,ID: " + sys_id);

            var sys_config = DBManager.Instance.GetDB<DBSysConfig>().GetConfigById(sys_id);
            if (sys_config == null)
            {
                List<string> spe_sys_config = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "sys_config", "sys_id", sys_id, "sys_type");
                if (spe_sys_config.Count == 0)
                {
                    GameDebug.LogError("没有对应的系统开放配置,ID: " + sys_id);
                }
                else
                {
                    uint sys_type = 0;
                    uint.TryParse(spe_sys_config[0], out sys_type);

                    if(sys_type == 1)// sys_type为1时表示不通过系统开发逻辑控制的系统(比如怒气技能的开放)
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_SPECIAL, new CEventBaseArgs(sys_id));
                    else
                        GameDebug.LogError("读取对应的系统开放配置时有遗漏,ID: " + sys_id);
                }
                
                return;
            }
            //OpenSys(sys_config);
            var in_close_list = mClosedSysList.Remove(sys_config);
            mClosedSysList.Sort();
            if (in_close_list && sys_id != GameConst.SYS_OPEN_GOD_WARE)
            {
                // 如果是之前已经关闭的系统, 再此开启的时候，不播放动画
                OpenSys(sys_config);
                //ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_RE_OPEN_SYS, new CEventBaseArgs(sys_config));
            }
            else
            {
                if (sys_config.NeedAnim == false)
                {
                    OpenSys(sys_config);
                }
                else
                {
                    DBSysConfig.SysConfig config = mWaitingSysList.Find(delegate (DBSysConfig.SysConfig _config) { return _config.Id == sys_config.Id; });
                    if(config == null)
                        mWaitingSysList.Add(sys_config);
                }
            }

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_OPEN_NOTIFY, new CEventBaseArgs(sys_id));

        }

        /// <summary>
        /// 响应系统关闭的网络消息
        /// </summary>
        /// <param name="sys_id"></param>
        public void HandleNotifySysClose(uint sys_id)
        {
            var sys_config = DBManager.Instance.GetDB<DBSysConfig>().GetConfigById(sys_id);
            if (sys_config == null)
            {
                GameDebug.LogError("本地表没有对应的系统：id=" + sys_id);
                return;
            }

            var in_waiting_list = mWaitingSysList.Remove(sys_config);
            mWaitingSysList.Sort();

            mRawOpenSysIds.Remove(sys_config.Id);

            var in_open_list = mOpenSysList.Remove(sys_config);
            mOpenSysList.Sort();
            mOpenSysDic.Remove(sys_config.Id);

            if (in_waiting_list || in_open_list)
            {
                if(!mClosedSysList.Contains(sys_config))
                    mClosedSysList.Add(sys_config);

                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_CLOSE, new CEventBaseArgs(sys_config));
                // 只有当前关闭的系统是主系统id的时候，才能将系统按钮真正隐藏
                if (sys_config.Id == sys_config.MainMapSysBtnId)
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_BTN_CLOSE, new CEventBaseArgs(sys_config));
            }
        }

        /// <summary>
        /// 系统关闭(运营活动调用)
        /// </summary>
        /// <param name="sys_id"></param>
        private void CloseSys(uint sys_id)
        {
            var sys_config = DBManager.Instance.GetDB<DBSysConfig>().GetConfigById(sys_id);
            if (sys_config == null)
            {
                GameDebug.LogError("本地表没有对应的系统：id=" + sys_id);
                return;
            }

            var in_waiting_list = mWaitingSysList.Remove(sys_config);
            mWaitingSysList.Sort();

            var in_open_list = mOpenSysDic.ContainsKey(sys_config.Id);

            if (in_waiting_list || in_open_list)
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_CLOSE, new CEventBaseArgs(sys_config));
                // 只有当前关闭的系统是主系统id的时候，才能将系统按钮真正隐藏
                if (sys_config.Id == sys_config.MainMapSysBtnId)
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_BTN_CLOSE, new CEventBaseArgs(sys_config));
            }
        }

        /// <summary>
        /// 响应网络消息
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="data"></param>
        private void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_PLAYER_SYS_OPEN_INFO: // 系统开放列表的消息
                    {
                        var pack = S2CPackBase.DeserializePack<S2CPlayerSysOpenInfo>(data);
                        mRawOpenSysIds = pack.sys_ids;


                        //送审 的时候过滤系统
                        AuditManager.Instance.FilterSystemWhenAudit(pack.sys_ids);


                        if(mWaitNetMsg[NetMsg.MSG_PLAYER_SYS_OPEN_INFO] == false)
                        {
                            mWaitNetMsg[NetMsg.MSG_PLAYER_SYS_OPEN_INFO] = true;
                            CheckSysOpenCondition();
                        }
                    }
                    break;
                case NetMsg.MSG_PLAYER_NOTIFY_SYS_CLOSE: // 系统关闭
                    {
                        var pack = S2CPackBase.DeserializePack<S2CPlayerNotifySysClose>(data);
                        for (int i = 0; i < pack.sys_ids.Count; i++)
                        {
                            HandleNotifySysClose(pack.sys_ids[i]);
                        }
                    }
                    break;
                case NetMsg.MSG_PLAYER_NOTIFY_SYS_OPEN: // 系统开启
                    {
                        var pack = S2CPackBase.DeserializePack<S2CPlayerNotifySysOpen>(data);
                        var db_sys_config = DBManager.GetInstance().GetDB<DBSysConfig>();

                        //送审 的时候过滤系统
                        AuditManager.Instance.FilterSystemWhenAudit(pack.sys_ids);

                        bool fire = mWaitingSysList.Count == 0 ?true:false;

                        for (int i = 0; i < pack.sys_ids.Count; i++)
                        {
                            var sys_id = pack.sys_ids[i];
                            var sys_config = db_sys_config.GetConfigById(sys_id);
                            if (sys_config == null)
                                continue;

                            bool is_open = true;
                            if (sys_config.IsActivity) // 活动类型的系统需要检查活动是否开启
                            {
                                is_open = ActivityHelper.IsActivityOpen(sys_config.Id);
                            }

                            if(is_open)
                                HandleNotifySysOpen(sys_id);
                            else// 如果活动未开启，也需要加入到系统开启列表中
                            {
                                if (!mRawOpenSysIds.Contains(sys_id))
                                    mRawOpenSysIds.Add(sys_id);
                            }

                            // 获取需要关闭的系统按钮列表
                            var sysIdList = db_sys_config.GetRelationSysById(sys_id);
                            if(sysIdList != null)
                            {
                                foreach(var id in sysIdList)
                                {
                                    CloseSys(id);
                                }
                            }
                        }

                        mWaitingSysList.Sort();
                        if (fire && mWaitingSysList.Count > 0)
                        {
                            if (SceneHelp.Instance.IsInWildInstance())
                            {
                                TargetPathManager.Instance.StopPlayerAndReset();//有系统开启停止寻路
                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());
                            }
                            else
                                ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());
                        }
                    }
                    break;
            }
        }
        #endregion

        #region 客户端事件
        private void OnOperatingActivityInit(CEventBaseArgs param)
        {
            // 运营活动的开放也会影响系统开放的逻辑
            if (mWaitNetMsg[NetMsg.MSG_ACT_YUNYING_OPEN] == false)
            {
                mWaitNetMsg[NetMsg.MSG_ACT_YUNYING_OPEN] = true;
                CheckSysOpenCondition();
            }
        }

        /// <summary>
        /// 响应运营活动开启的消息
        /// </summary>
        /// <param name="param"></param>
        private void OnOperatingActivityOpen(CEventBaseArgs param)
        {
            // 运营活动的开放也会影响系统开放的逻辑
            if (mWaitNetMsg[NetMsg.MSG_ACT_YUNYING_OPEN])
            {
                uint sys_id = 0;
                uint.TryParse(param.arg.ToString(), out sys_id);
                if (sys_id == 0)
                {
                    GameDebug.LogError("[OnOperatingActivityOpen]sys_id is 0");
                    return;
                }

                var db_sys_config = DBManager.GetInstance().GetDB<DBSysConfig>();
                var sys_config = db_sys_config.GetConfigById(sys_id);
                if (sys_config == null)
                {
                    GameDebug.LogError("[OnOperatingActivityOpen]sys_config is null, id: " + sys_id);
                    return;
                }

                if (!sys_config.IsActivity)
                    return;

                // 需要检查系统开放逻辑
                if (!CheckSysHasOpenIgnoreActivity(sys_config.Id))
                    return;

                bool fire = mWaitingSysList.Count == 0 ? true : false;

                HandleNotifySysOpen(sys_id);

                mWaitingSysList.Sort();
                if (fire && mWaitingSysList.Count > 0)
                {
                    if (SceneHelp.Instance.IsInWildInstance())
                    {
                        TargetPathManager.Instance.StopPlayerAndReset();//有系统开启停止寻路
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());
                    }
                    else
                        ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());
                }
            }
        }

        /// <summary>
        /// 响应运营活动关闭的消息
        /// </summary>
        /// <param name="param"></param>
        private void OnOperatingActivityClose(CEventBaseArgs param)
        {
            // 运营活动的开放也会影响系统开放的逻辑
            if (mWaitNetMsg[NetMsg.MSG_ACT_YUNYING_OPEN])
            {
                uint sys_id = 0;
                uint.TryParse(param.arg.ToString(), out sys_id);
                if (sys_id != 0)
                {
                    var db_sys_config = DBManager.GetInstance().GetDB<DBSysConfig>();
                    var sys_config = db_sys_config.GetConfigById(sys_id);
                    if (sys_config == null)
                    {
                        GameDebug.LogError("[OnOperatingActivityClose]sys_config is null, id: " + sys_id);
                        return;
                    }

                    if (!sys_config.IsActivity)
                        return;

                    // 需要检查系统开放逻辑
                    if (!CheckSysHasOpenIgnoreActivity(sys_config.Id))
                        return;

                    CloseSys(sys_id);
                }
                else
                    GameDebug.LogError("[OnOperatingActivityClose]sys_id is 0");
            }
        }

        /// <summary>
        /// 响应日常活动初始化的消息
        /// </summary>
        /// <param name="param"></param>
        private void OnActivityStateInit(CEventBaseArgs param)
        {
            // 日常活动的开放也会影响系统开放的逻辑
            if (mWaitNetMsg[NetMsg.MSG_ACT_DAILY] == false)
            {
                mWaitNetMsg[NetMsg.MSG_ACT_DAILY] = true;
                CheckSysOpenCondition();
            }
        }

        /// <summary>
        /// 响应活动状态改变的消息
        /// </summary>
        /// <param name="param"></param>
        private void OnActivityStateChange(CEventBaseArgs param)
        {
            // 活动的开放也会影响系统开放的逻辑
            if (mWaitNetMsg[NetMsg.MSG_ACT_YUNYING_OPEN])
            {
                uint sys_id = 0;
                uint.TryParse(param.arg.ToString(), out sys_id);

                if (sys_id != 0)
                {
                    var db_sys_config = DBManager.GetInstance().GetDB<DBSysConfig>();
                    var sys_config = db_sys_config.GetConfigById(sys_id);
                    if (sys_config == null)
                    {
                        GameDebug.LogError("[OnActivityStateChange]sys_config is null, id: " + sys_id);
                        return;
                    }

                    if (!sys_config.IsActivity)
                        return;

                    // 需要检查系统开放逻辑
                    if (!CheckSysHasOpenIgnoreActivity(sys_config.Id))
                        return;

                    bool affect = false; // 是否受活动开启影响
                    bool is_open = false; // 活动是否开启
                    if (LuaScriptMgr.Instance != null)
                    {
                        object[] func_param = { sys_id, "IsOpenEx" };
                        System.Type[] return_type = { typeof(bool), typeof(bool) };
                        object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "ActivityHelper_GetActivityInfo", func_param, return_type);
                        if (objs != null && objs.Length >= 2)
                        {
                            affect = (bool)(objs[0]);
                            is_open = (bool)(objs[1]);
                        }
                    }

                    if(affect)
                    {
                        if (is_open)
                        {
                            bool fire = mWaitingSysList.Count == 0 ? true : false;

                            HandleNotifySysOpen(sys_id);

                            mWaitingSysList.Sort();
                            if (fire && mWaitingSysList.Count > 0)
                            {
                                if (SceneHelp.Instance.IsInWildInstance())
                                {
                                    TargetPathManager.Instance.StopPlayerAndReset();//有系统开启停止寻路
                                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());
                                }
                                else
                                    ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());
                            }
                        }
                        else
                            CloseSys(sys_id);
                    }
                }
                else
                    GameDebug.LogError("[OnActivityStateChange]sys_id is 0");
            }
        }
        #endregion
    }
}
