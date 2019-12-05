//----------------------------------------
// File: CooldownManager.cs
// Desc: 本地玩家的cd管理器
// Author: raorui
// Date: 2017.9.1
//----------------------------------------
using System;
using System.Collections.Generic;
using Utils;
using xc.protocol;
using Net;

namespace xc
{
    [wxb.Hotfix]
    public class CooldownManager : xc.Singleton<CooldownManager>
    {
        Dictionary<uint, uint> m_SkillCDInfo = new Dictionary<uint, uint>();// 服务器发送的特殊的技能的lifetime(因为一些特殊机制会修改某些技能的cd时间)

        public void Reset()
        {
            m_SkillCDInfo.Clear();
        }

        /// <summary>
        /// 从服务端获取技能的cd时间
        /// </summary>
        /// <param name="skill_id"></param>
        /// <returns></returns>
        public uint GetCDFromServer(uint skill_id)
        {
            uint cd_life_time = 0;
            m_SkillCDInfo.TryGetValue(skill_id, out cd_life_time);
            return cd_life_time;
        }

        /// <summary>
        /// 获取技能的cd时间
        /// </summary>
        /// <param name="skill_id"></param>
        /// <returns></returns>
        public uint GetCD(uint skill_id)
        {
            uint cd_life_time = 0;
            if (m_SkillCDInfo.TryGetValue(skill_id, out cd_life_time))
                return cd_life_time;
            else// 服务端数据中没有则从表格中获取
            {
                DBSkillSev skill_db = DBManager.GetInstance().GetDB<DBSkillSev>();
                if (skill_db == null)
                {
                    GameDebug.LogError("skill database not exsit!");
                    return 0;
                }

                DBSkillSev.SkillInfoSev skill_info = skill_db.GetSkillInfo(skill_id);
                if (skill_info == null)
                {
                    GameDebug.LogError("skillInfo is null! type_idx: " + skill_id);
                    return 0;
                }
                else
                   return (uint)UnityEngine.Mathf.Max(skill_info.CDTime, 0);
            }

        }

        /// <summary>
        /// 注册所有网络消息
        /// </summary>
        public void RegisterAllMessage()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_SKILL_CLEAR_CD, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_SKILLS_CD, HandleServerData);
        }

        public void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_NWAR_SKILL_CLEAR_CD:// 清除本地玩家的技能cd
                    {
                        S2CNwarSkillClearCd clearCd = S2CPackBase.DeserializePack<S2CNwarSkillClearCd>(data);
                        if (clearCd.uuid == Game.GetInstance().LocalPlayerID.obj_idx)
                        {
                            Actor localplayer = Game.GetInstance().GetLocalPlayer();
                            if (localplayer != null)
                            {
                                for (int i = 0; i < clearCd.skill_ids.Count; ++i)
                                {
                                    localplayer.CDCtrl.RemoveCD(clearCd.skill_ids[i]);
                                }
                            }
                        }
                        else
                            GameDebug.LogError("Not need rev others clear cd");
                    }
                    break;
                case NetMsg.MSG_SKILLS_CD: // 服务端更新技能的cd
                    {
                        S2CSkillsCd skills_cd = S2CPackBase.DeserializePack<S2CSkillsCd>(data);
                        foreach (var cd_info in skills_cd.sks)
                        {
                            m_SkillCDInfo[cd_info.id] = cd_info.cd;
                        }
                    }
                    break;
            }
        }
    }
}
