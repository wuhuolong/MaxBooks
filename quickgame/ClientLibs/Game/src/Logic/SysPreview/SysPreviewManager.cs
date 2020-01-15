//---------------------------------------------
// File: SysPreviewManager.cs
// Desc: 系统预览管理
// Author: XiongWei
// Date: 2018.6.19
//---------------------------------------------

using System.Collections.Generic;
using xc.protocol;
using Net;

namespace xc
{
    [wxb.Hotfix]
    public class SysPreviewManager : xc.Singleton<SysPreviewManager>
    {
        private List<uint> mRewardSysIds;

        public SysPreviewManager()
        {
            mRewardSysIds = new List<uint>();
        }
        
        // APIs
        public void RegisterAllMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_SYS_PREVIEW_REWARDED_LISTS, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_SYS_PREVIEW_REWARD, HandleServerData);
        }

        public void Reset()
        {
            mRewardSysIds.Clear();
        }

        public uint GetCurrentSysId()
        {
            var db_sys_preview = DBManager.GetInstance().GetDB<DBSysPreview>();
            foreach (KeyValuePair<uint, DBSysPreview.DBSysPreviewInfo> kv in db_sys_preview.Data)
            {
                uint sysId = kv.Key;

                var transferLevel = 0;
                object[] param = { };
                System.Type[] returnType = { typeof(int) };
                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "TransferMgr_GetTransferLevel", param, returnType);
                if (objs != null && objs.Length > 0)
                {
                    if (objs[0] != null)
                    {
                        transferLevel = (int)objs[0];
                    }
                }
                if (sysId == GameConst.SYS_OPEN_TRANSFER && transferLevel > 0)
                {
                    continue;
                }
                    
                if (SysConfigManager.Instance.CheckSysHasOpened(sysId) && !HasGetReward(sysId))
                {
                    return sysId;
                }
                else if (!SysConfigManager.Instance.CheckSysHasOpened(sysId) && !HasGetReward(sysId))
                {
                    return sysId;
                }
            }
            return 0;
        }

        public bool HasGetReward(uint sysId)
        {
            return mRewardSysIds.Contains(sysId);
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
                case NetMsg.MSG_SYS_PREVIEW_REWARDED_LISTS: // 已领奖励的系统
                    {
                        var pack = S2CPackBase.DeserializePack<S2CSysPreviewRewardedLists>(data);
                        mRewardSysIds = pack.sys_ids;
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_PREVIEW_REWARDED_LISTS, new CEventBaseArgs());
                    }
                    break;
                case NetMsg.MSG_SYS_PREVIEW_REWARD: // 应答领取奖励
                    {
                        var pack = S2CPackBase.DeserializePack<S2CSysPreviewReward>(data);
                        mRewardSysIds.Add(pack.sys_id);
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_PREVIEW_REWARD, new CEventBaseArgs(pack.sys_id));
                    }
                    break;
            }
        }
    }
}