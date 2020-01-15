//----------------------------------------------------------------
// File： DBInstanceTypeControl.cs
// Desc：副本类型作为key，进行不同情况的特殊处理
// Author: raorui
// Date: 2017.10.17
//----------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBInstanceTypeControl : DBSqliteTableResource
    {
        public static DBInstanceTypeControl Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBInstanceTypeControl>();
            }
        }

        /// <summary>
        /// 副本类型和特殊控制字段
        /// </summary>
        public class InstanceTypeInfo
        {
            public uint m_WarType; // 副本类型 
            public uint m_WarSubType; // 副本子类型
            public bool m_PrecedentPlayer; // 目标选择时候是否优先选择玩家
            public bool m_CannotHidePlayer; // 不能隐藏其他玩家
            public bool m_PKLevelLimit; // pv模式中没有等级限制
            public bool m_UsePKMode; // 使用pv模式来筛选可攻击目标
            public bool m_NoShowAtkCampTips; // 攻击同一阵营玩家不飘字
            public bool m_IgnoreClickPlayer; // 是否屏蔽点击其他玩家后弹出的详情界面
            public bool m_ForceShowHpBar; // 强制显示玩家的血条
            public List<KeyValuePair<uint, uint>> m_ForbidUseGoodsTypes; // 禁止使用的道具类型列表
            public bool m_ForbidChangePk; // 禁止改变PK模式
            public bool m_ForbidOpenWorldMap; // 禁止打开世界地图界面
            public bool m_HideHpBar;    //是否隐藏玩家血条
            public bool m_HideCamp; //是否隐藏阵营标识
            public bool m_ForbidPet; //是否禁止魔仆
            public bool m_HideTeam; //是否隐藏组队标记
            public bool m_ForbidTeam; //是否场景中禁止组队
            public bool m_HidePvpHpBar; //是否隐藏pvp血条
            public bool m_AutoPickDrop; //是否自动拾取掉落
            public bool m_IsShowAutoFightingGotExp; //是否显示挂机经验效率
            public List<uint> m_ShowDanmakuChatChannels;    // 显示弹幕的聊天频道列表
            public uint m_ActId;    // 对应的活动id
            public string m_ExitTips;   // 中途退出提示
            public bool m_is_can_exit;  //是否可以退出（针对野外场景）
            public bool m_ForbidJumpOutAnimationOut; //从该副本跳出时禁止切出动作
            public bool m_ForbidJumpOutAnimationIn; //跳入该副本时禁止切出动作
            public bool m_PlayJumpOutAnimationTeamIn;   //组队进入该副本时播放切出动画
            public bool m_HideCount;   //是否隐藏副本结束倒计时
            public bool m_ForbidElfin;   //是否隐藏小精灵
            public bool m_ForbidMagicPet;   //是否隐藏神宠
            public string m_replace_name;//替换其他玩家的名字
            public bool m_BanShortCutWin;   //禁止显示快捷穿戴弹框
            public bool m_BanBossNoticeWin;    //禁止弹出BOSS刷新弹窗    
            public bool m_BanMarriageNoticeWin;    //禁止弹出结婚相关弹窗    
            public bool m_hide_guild;//屏蔽帮派显示
            public bool m_hide_mate;//屏蔽伴侣显示
            public bool m_NoFlyShoe;    // 不可使用飞鞋
            public bool m_AutoCollect;  //是否自动采集
            public bool m_DoNotPatrol;  //挂机时候如果没有目标是否不要巡逻
            public bool m_ShowServerName;   // 是否在跨服状态下显示服务器名字
            public bool m_ClearCd;   // 是否清除CD
            public uint m_MinPlayerCount; //最小同屏人数
        }

        Dictionary<uint, InstanceTypeInfo> mInstanceTypeControls = new Dictionary<uint, InstanceTypeInfo>();

        public DBInstanceTypeControl(string name, string path) : base(name, path)
        { }

        public override void Load()
        {
            IsLoaded = true;
        }

        InstanceTypeInfo GetItemInfo(uint warType, uint warSubType)
        {
            uint key = MakeKey(warType, warSubType);
            var war_type = "";
            if (warType== GameConst.WAR_TYPE_DUNGEON)
            {
                war_type = "WAR_TYPE_DUNGEON";
            }
            else if (warType == GameConst.WAR_TYPE_WILD)
            {
                war_type = "WAR_TYPE_WILD";
            }
            var war_sub_type = DBInstanceType.Instance.GetInstanceType(warSubType);
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" AND {0}.{3}=\"{4}\"", mTableName, "war_type", war_type, "war_subtype", war_sub_type);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInstanceTypeControls[key] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInstanceTypeControls[key] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            var info = new InstanceTypeInfo();

            info.m_WarType = warType;
            info.m_WarSubType = warSubType;
            info.m_PrecedentPlayer = DBTextResource.ParseUI_s(GetReaderString(reader, "precedent_player"), 0) == 1;
            info.m_CannotHidePlayer = DBTextResource.ParseUI_s(GetReaderString(reader, "cannot_hide_player"), 0) == 1;
            info.m_PKLevelLimit = DBTextResource.ParseUI_s(GetReaderString(reader, "pk_lv_limit"), 0) == 1;
            info.m_UsePKMode = DBTextResource.ParseUI_s(GetReaderString(reader, "use_pk_mode"), 0) == 1;
            info.m_NoShowAtkCampTips = DBTextResource.ParseUI_s(GetReaderString(reader, "no_show_atk_camp_tips"), 0) == 1;
            info.m_IgnoreClickPlayer = DBTextResource.ParseUI_s(GetReaderString(reader, "ignore_click_player"), 0) == 1;
            info.m_ForceShowHpBar = DBTextResource.ParseUI_s(GetReaderString(reader, "force_show_hp_bar"), 0) == 1;
            info.m_ForbidUseGoodsTypes = DBTextResource.ParseArrayKeyValuePairUintUint(GetReaderString(reader, "forbid_use_goods_types"));
            info.m_ForbidChangePk = DBTextResource.ParseUI_s(GetReaderString(reader, "forbid_change_pk"), 0) == 1;
            info.m_ShowDanmakuChatChannels = DBTextResource.ParseArrayUint(GetReaderString(reader, "show_danmaku_switch"), ",");
            info.m_ForbidOpenWorldMap = DBTextResource.ParseUI_s(GetReaderString(reader, "forbid_open_world_map"), 0) == 1;
            info.m_HideHpBar = DBTextResource.ParseUI_s(GetReaderString(reader, "hide_hp_bar"), 0) == 1;
            info.m_HideCamp = DBTextResource.ParseUI_s(GetReaderString(reader, "hide_camp"), 0) == 1;
            info.m_ForbidPet = DBTextResource.ParseUI_s(GetReaderString(reader, "forbid_pet"), 0) == 1;
            info.m_HideTeam = DBTextResource.ParseUI_s(GetReaderString(reader, "hide_team"), 0) == 1;
            info.m_ForbidTeam = DBTextResource.ParseUI_s(GetReaderString(reader, "forbid_team"), 0) == 1;
            info.m_HidePvpHpBar = DBTextResource.ParseUI_s(GetReaderString(reader, "hide_pvp_hp_bar"), 0) == 1;
            info.m_AutoPickDrop = DBTextResource.ParseUI_s(GetReaderString(reader, "auto_pick_drop"), 0) == 1;
            info.m_IsShowAutoFightingGotExp = DBTextResource.ParseUI_s(GetReaderString(reader, "is_show_auto_fighting_got_exp"), 0) == 1;
            info.m_ActId = DBTextResource.ParseUI_s(GetReaderString(reader, "act_id"), 0);
            info.m_ExitTips = GetReaderString(reader, "exit_tips");
            info.m_is_can_exit = DBTextResource.ParseUI_s(GetReaderString(reader, "is_can_exit"), 0) == 1;
            info.m_ForbidJumpOutAnimationOut = DBTextResource.ParseUI_s(GetReaderString(reader, "forbid_jump_out_animation_out"), 0) == 1;
            info.m_ForbidJumpOutAnimationIn = DBTextResource.ParseUI_s(GetReaderString(reader, "forbid_jump_out_animation_in"), 0) == 1;
            info.m_PlayJumpOutAnimationTeamIn = DBTextResource.ParseUI_s(GetReaderString(reader, "play_jump_out_animation_team_in"), 0) == 1;
            info.m_HideCount = DBTextResource.ParseUI_s(GetReaderString(reader, "hide_count"), 0) == 1;
            info.m_ForbidElfin = DBTextResource.ParseUI_s(GetReaderString(reader, "forbid_elfin"), 0) == 1;
            info.m_ForbidMagicPet = DBTextResource.ParseUI_s(GetReaderString(reader, "forbid_magic_pet"), 0) == 1;
            info.m_hide_guild = DBTextResource.ParseUI_s(GetReaderString(reader, "hide_guild"), 0) == 1;
            info.m_hide_mate = DBTextResource.ParseUI_s(GetReaderString(reader, "hide_mate"), 0) == 1;
            info.m_replace_name = GetReaderString(reader, "replace_name");
            info.m_BanShortCutWin = DBTextResource.ParseUI_s(GetReaderString(reader, "ban_shortCut_win"), 0) == 1;
            info.m_BanBossNoticeWin = DBTextResource.ParseUI_s(GetReaderString(reader, "ban_boss_notice_win"), 0) == 1;
            info.m_BanMarriageNoticeWin = DBTextResource.ParseUI_s(GetReaderString(reader, "ban_marriage_notice_win"), 0) == 1;
            info.m_NoFlyShoe = DBTextResource.ParseUI_s(GetReaderString(reader, "no_fly_shoe"), 0) == 1;
            info.m_AutoCollect = DBTextResource.ParseUI_s(GetReaderString(reader, "auto_collect"), 0) == 1;
            info.m_DoNotPatrol = DBTextResource.ParseUI_s(GetReaderString(reader, "do_not_patrol"), 0) == 1;
            info.m_ShowServerName = DBTextResource.ParseUI_s(GetReaderString(reader, "show_server_name"), 0) == 1;
            info.m_ClearCd = DBTextResource.ParseUI_s(GetReaderString(reader, "clear_cd"), 0) == 1;
            info.m_MinPlayerCount = DBTextResource.ParseUI_s(GetReaderString(reader, "min_player_count"), 0);

            mInstanceTypeControls[key] = info;

            reader.Close();
            reader.Dispose();
            return info;

        }

        /// <summary>
        /// 根据副本类型的子类型生成唯一ID
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        uint MakeKey(uint war_type, uint war_sub_type)
        {
            uint key = (uint)(((ushort)war_type << 16) | war_sub_type);
            return key;
        }

        bool GetIntanceInfo(uint war_type, uint war_sub_type, out InstanceTypeInfo info)
        {
            uint key = MakeKey(war_type, war_sub_type);
            if (!mInstanceTypeControls.TryGetValue(key, out info))
                info = GetItemInfo(war_type, war_sub_type);

            return info != null;
        }

        /// <summary>
        /// 当前副本类型下，目标筛选时候是否优先选择玩家
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool PrecedentPlayer(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_PrecedentPlayer;
            }

            return false;
        }

        /// <summary>
        /// 当前副本类型下, 是否不能隐藏其他玩家
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool CannotHidePlayer(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_CannotHidePlayer;
            }

            return false;
        }

        /// <summary>
        /// 当前副本类型下, pv是否有等级限制
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool PKLevelLimit(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_PKLevelLimit;
            }

            return false;
        }

        /// <summary>
        /// 当前副本类型下, 是否使用pk模式来筛选可攻击目标
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool UsePKMode(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_UsePKMode;
            }

            return false;
        }

        /// <summary>
        /// 当前副本类型下, 攻击同一阵容玩家是否不飘字（“不可攻击友方"） 
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool NoShowAtkCampTips(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_NoShowAtkCampTips;
            }

            return false;
        }

        /// <summary>
        /// 是否屏蔽点击其他玩家后弹出的详情界面
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool IgnoreClickPlayer(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_IgnoreClickPlayer;
            }

            return false;
        }

        /// <summary>
        /// 强制显示玩家血条
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ForceShowHpBar(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ForceShowHpBar;
            }

            return false;
        }

        /// <summary>
        /// 禁止使用物品
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ForbidUseGoods(uint war_type, uint war_sub_type, uint goods_type, uint goods_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                foreach (KeyValuePair<uint, uint> kv in info.m_ForbidUseGoodsTypes)
                {
                    if (goods_type == kv.Key && goods_sub_type == kv.Value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool ForbiChangePkMode(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ForbidChangePk;
            }

            return false;
        }

        public bool ShowDanmakuSwitch(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                if (info.m_ShowDanmakuChatChannels == null || info.m_ShowDanmakuChatChannels.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public bool ShowDanmaku(uint war_type, uint war_sub_type, uint chat_channel)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                if (info.m_ShowDanmakuChatChannels == null || info.m_ShowDanmakuChatChannels.Count == 0)
                {
                    return false;
                }
                else
                {
                    return info.m_ShowDanmakuChatChannels.Contains(chat_channel);
                }
            }

            return false;
        }

        public bool ForbidOpenWorldMap(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ForbidOpenWorldMap;
            }

            return false;
        }

        /// <summary>
        /// 是否隐藏玩家血条
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool HideHpBar(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_HideHpBar;
            }
            return false;
        }

        /// <summary>
        /// 是否隐藏阵营标识
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool HideCamp(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_HideCamp;
            }
            return false;
        }

        /// <summary>
        /// 是否禁止魔仆
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ForbidPet(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ForbidPet;
            }
            return false;
        }

        /// <summary>
        /// 是否隐藏组队标记
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool HideTeam(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_HideTeam;
            }
            return false;
        }

        /// <summary>
        /// 是否场景中禁止组队
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ForbidTeam(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ForbidTeam;
            }
            return false;
        }

        /// <summary>
        /// 是否隐藏pvp血条
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool HidePvpHpBar(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_HidePvpHpBar;
            }
            return false;
        }

        /// <summary>
        /// 是否自动拾取掉落
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool AutoPickDrop(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_AutoPickDrop;
            }
            return false;
        }

        /// <summary>
        /// 是否显示挂机经验效率
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool IsShowAutoFightingGotExp(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_IsShowAutoFightingGotExp;
            }
            return false;
        }

        /// <summary>
        /// 对应的活动id
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public uint GetActivityId(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ActId;
            }
            return 0;
        }

        /// <summary>
        /// 副本中途离开提示
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public string GetExitTips(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ExitTips;
            }
            return string.Empty;
        }

        /// <summary>
        /// 副本是否可以退出
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool GetCanExit(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_is_can_exit;
            }
            return false;
        }

        /// <summary>
        /// 副本是否禁止弹出快捷穿戴的界面
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool IsBanShortCutWin(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_BanShortCutWin;
            }
            return false;
        }

        /// <summary>
        /// 副本是否禁止弹出BOSS刷新提示的界面
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool IsBanBossNoticeWin(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_BanBossNoticeWin;
            }
            return false;
        }


        /// <summary>
        /// 副本是否禁止弹出结婚相关的提示界面
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool IsBanMarriageNoticeWin(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_BanMarriageNoticeWin;
            }
            return false;
        }
        /// <summary>
        /// 从该副本跳出时禁止切出动作
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ForbidJumpOutAnimationOut(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ForbidJumpOutAnimationOut;
            }
            return false;
        }

        /// <summary>
        /// 跳入该副本时禁止切出动作
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ForbidJumpOutAnimationIn(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ForbidJumpOutAnimationIn;
            }
            return false;
        }

        /// <summary>
        /// 组队进入该副本时播放切出动画
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool PlayJumpOutAnimationTeamIn(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_PlayJumpOutAnimationTeamIn;
            }
            return false;
        }

        /// <summary>
        /// 是否隐藏副本结束倒计时
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool HideCount(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_HideCount;
            }
            return false;
        }

        /// <summary>
        /// 是否禁止小精灵
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ForbidElfin(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ForbidElfin;
            }
            return false;
        }

        /// <summary>
        /// 是否禁止神宠
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ForbidMagicPet(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ForbidMagicPet;
            }
            return false;
        }

        /// <summary>
        /// 替换其他玩家的名字
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public string GetReplaceOtherPlayerName(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_replace_name;
            }
            return "";
        }

        /// <summary>
        /// 屏蔽帮派显示
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool HideGuild(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_hide_guild;
            }
            return false;
        }

        /// <summary>
        /// 屏蔽伴侣显示
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool HideMate(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_hide_mate;
            }
            return false;
        }

        /// <summary>
        /// 是否禁止使用飞鞋
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool NoFlyShoe(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_NoFlyShoe;
            }
            return false;
        }

        /// <summary>
        /// 是否自动采集
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool AutoCollect(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_AutoCollect;
            }
            return false;
        }

        /// <summary>
        /// 挂机时候如果没有目标是否不要巡逻
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool DoNotPatrol(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_DoNotPatrol;
            }
            return false;
        }

        /// <summary>
        /// 是否在跨服状态下显示服务器名字
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ShowServerName(uint war_type, uint war_sub_type)
        {
            
            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ShowServerName;
            }
            return false;
        }

        /// <summary>
        /// 是否清除CD
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public bool ClearCd(uint war_type, uint war_sub_type)
        {

            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_ClearCd;
            }
            return false;
        }

        /// <summary>
        /// 最少同屏人数
        /// </summary>
        /// <param name="war_type"></param>
        /// <param name="war_sub_type"></param>
        /// <returns></returns>
        public uint MinPlayerCount(uint war_type, uint war_sub_type)
        {

            InstanceTypeInfo info = null;
            if (GetIntanceInfo(war_type, war_sub_type, out info))
            {
                return info.m_MinPlayerCount;
            }
            return 0;
        }
    }
}
