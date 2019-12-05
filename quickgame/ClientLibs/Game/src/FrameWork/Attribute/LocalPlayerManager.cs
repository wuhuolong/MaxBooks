using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc.protocol;
using xc.ui;
using Net;
using xc.ui.ugui;

namespace xc
{
    public class LocalPlayerManager : xc.Singleton<LocalPlayerManager>
    {
        public ActorAttributeData LocalActorAttribute = null; //本地玩家固定属性

        private bool mbRegisterAllMessage = false;

        public ulong Exp = 0; //经验值
        public ulong ExpMax = 0;//当前等级最大经验值

        public uint Coin = 0;// 铜币
        public uint BindCoin = 0;// 绑定铜币
        public uint Diamond = 0; // 金锭
        public uint BindDiamond = 0; // 银锭
        public uint SoulCream = 0;//武魂精髓
        public uint SoulHolyWater = 0;//铸魂圣水
        public uint GuildMoney = 0;//军团贡献
        public uint BfireScore = 0;//遗迹积分
        public uint RaceScore = 0;//职业积分
        public uint ActivityScore = 0; // 活跃积分
        public uint TrigramSp = 0;//八卦牌剑灵货币
        public uint HangTime = 0; // 离线挂机可用时间
        public uint Fury = 0; // 怒气数值
        

        public Dictionary<ushort, uint> MoneyData = new Dictionary<ushort, uint>();

        private bool IsFirstCallBackExp = true;
        private long mLastBattlePower = 0;//上一个战斗力
        public uint WorldLevel = 0;//世界等级
        public uint LimitLevel = 0;//限制等级
        public uint HiBreak = 0;//巅峰突破

        /// <summary>
        /// 上次同步给LocalPlayer的血量
        /// </summary>
        private long mLastHp = 0;

        /// <summary>
        /// 上次同步给LocalPlayer的最大血量
        /// </summary>
        private long mLastHpMax = 0;

        private uint mMainPetID = 0;//主宠ID
        private uint mMainPetLevel = 0;//主宠等级
        private List<uint> mMainPetExSkills = new List<uint>();//主宠技能
        private bool mInBattleStatus = false;// 是否在战斗状态

        private uint mMountId = 0;  //坐骑ID

        /// <summary>
        /// 出生朝向，用于保存上一个副本的朝向
        /// </summary>
        public Quaternion BornRotation { get; set; }

        /// <summary>
        /// 剩余升级点数
        /// </summary>
        public uint ReaminLvPoint = 0; 

        /// <summary>
        /// 是否在战斗状态中
        /// </summary>
        public bool InBallteStatus
        {
            get
            {
                return mInBattleStatus;
            }

            set
            {
                if (mInBattleStatus != value)
                {
                    mInBattleStatus = value;

                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_BATTLESTATUS_CHANGE, new CEventBaseArgs(mInBattleStatus));
                }
            }
        }


        public uint Level
        {
            get
            {
                if (LocalActorAttribute != null)
                {
                    return LocalActorAttribute.Level;
                }

                return 0;
            }
        }

        /// <summary>
        /// 帮派ID
        /// </summary>
        public uint GuildID
        {
            get
            {
                if (LocalActorAttribute != null)
                {
                    return LocalActorAttribute.GuildId;
                }
                return 0;
            }
            set
            {
                if (value != GuildID)
                {
                    if (LocalActorAttribute != null)
                    {
                        LocalActorAttribute.GuildId = value;
                    }
                    Actor local_player = Game.Instance.GetLocalPlayer();
                    if (local_player != null && local_player.ActorAttribute != null)
                        local_player.ActorAttribute.GuildId = value;
                    //触发事件
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_GUILD_CHANGED_ID_IN_SCENE, new CEventBaseArgs());
                }
            }
        }

        /// <summary>
        /// 帮派名字
        /// </summary>
        public string GuildName
        {
            get
            {
                if (LocalActorAttribute != null)
                {
                    return LocalActorAttribute.GuildName;
                }
                return "";
            }
            set
            {
                if (LocalActorAttribute != null)
                {
                    LocalActorAttribute.GuildName = value;
                }
            }
        }

        /// <summary>
        /// 主宠ID(品质)
        /// </summary>
        public uint MainPetID
        {
            get
            {
                return mMainPetID;
            }
            set
            {
                if (value != mMainPetID)
                {
                    mMainPetID = value;
                    //触发事件
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_PET_MAIN_CHANGED_IN_SCENE, new CEventBaseArgs());
                }
            }
        }


        /// <summary>
        /// 主宠技能
        /// </summary>
        public List<uint> MainPetExSkills
        {
            get
            {
                return mMainPetExSkills;
            }
        }

        /// <summary>
        /// 清除主宠技能
        /// </summary>
        public void ClearMainPetExSkills()
        {
            mMainPetExSkills.Clear();

            LocalPlayer localPlayer = Game.Instance.GetLocalPlayer() as LocalPlayer;
            if (localPlayer != null)
            {
                Actor pet = ActorManager.Instance.GetActor(localPlayer.CurrentPet);
                if (pet != null)
                {
                    pet.SetSkillCastInfo(LocalPlayerManager.Instance.MainPetExSkills);
                }
            }
        }

        /// <summary>
        /// 添加主宠技能
        /// </summary>
        public void AddMainPetExSkill(uint skillId)
        {
            uint subSkillId = DBManager.Instance.GetDB<DBDataAllSkill>().GetSubSkillIdByAllSkillId(skillId);
            mMainPetExSkills.Add(subSkillId);

            LocalPlayer localPlayer = Game.Instance.GetLocalPlayer() as LocalPlayer;
            if (localPlayer != null)
            {
                Actor pet = ActorManager.Instance.GetActor(localPlayer.CurrentPet);
                if (pet != null)
                {
                    pet.AddSkillCastInfo(subSkillId, 100);
                }
            }
        }

        public void Reset(bool is_reconnect)
        {
            LocalActorAttribute = new ActorAttributeData();

            Exp = 0; //经验值
            ExpMax = 0;//当前等级最大经验值

            Coin = 0;//金币
            BindCoin = 0;//绑金
            Diamond = 0; //钻石
            BindDiamond = 0; //绑钻
            SoulCream = 0;//武魂精髓
            SoulHolyWater = 0;//铸魂圣水
            GuildMoney = 0;//军团贡献
            BfireScore = 0;//遗迹积分
            RaceScore = 0;//职业积分
            ActivityScore = 0; // 活跃积分
            TrigramSp = 0;//八卦牌剑灵货币
            HangTime = 0; // 离线挂机可用时间
            Fury = 0; // 怒气数值

            MoneyData.Clear();

            IsFirstCallBackExp = true;
            mLastBattlePower = 0;//上一个战斗力
            WorldLevel = 0;//世界等级
            LimitLevel = 0;//限制等级
            HiBreak = 0;//巅峰突破

            mLastHp = 0;
            mLastHpMax = 0;

            mMainPetID = 0;//主宠ID
            mMainPetLevel = 0;//主宠等级
            mMainPetExSkills.Clear();
            mInBattleStatus = false;// 是否在战斗状态

            mMountId = 0;  //坐骑ID

            BornRotation = Quaternion.identity;

            ReaminLvPoint = 0;

            if(is_reconnect == false)
            {//非断线重连
                m_isFirstLoadingScene = false;    //是否第一次进入场景
                m_canShowBuffTips = true;   //是否可以显示获得buff提示
                FristGetNewMountId = 0;
                m_hasInitOpenSysMount = false;
                m_hasOpenSysMount = false;
            }
        }

        public void OnDestroyScene()
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            bool isSaved = false;
            if (localPlayer != null)
            {
                // 武神秘境不保存朝向
                if (SceneHelp.Instance.IsKungfuInstance == false)
                {
                    BornRotation = localPlayer.GetModelParent().transform.rotation;
                    isSaved = true;
                }
            }

            if (isSaved == false)
            {
                BornRotation = Quaternion.identity;
            }
        }

        public uint GetMoneyByConst(ushort moneyType)
        {
            switch (moneyType)
            {
                case GameConst.MONEY_COIN:
                    {
                        return Coin;
                    }
                case GameConst.MONEY_COIN_ANY:
                    {
                        return Coin + BindCoin;
                    }
                case GameConst.MONEY_DIAMOND:
                    {
                        return Diamond;
                    }
                case GameConst.MONEY_DIAMOND_ANY:
                    {
                        return Diamond + BindDiamond;
                    }
                case GameConst.MONEY_SOUL_CREAM:
                    {
                        return SoulCream;
                    }
                case GameConst.MONEY_SOUL_HOLY_WATER:
                    {
                        return SoulHolyWater;
                    }
                case GameConst.MONEY_COIN_BIND:
                    {
                        return BindCoin;
                    }
                case GameConst.MONEY_DIAMOND_BIND:
                    {
                        return BindDiamond;
                    }
                case GameConst.MONEY_TRIGRAM_SP:
                    {
                        return TrigramSp;
                    }
                case GameConst.MONEY_HANG_TIME:
                    {
                        return HangTime;
                    }

                default:
                    if (MoneyData.ContainsKey(moneyType))
                        return MoneyData[moneyType];
                    return 0;
            }
        }

        public static string GetMoneyNameByConst(ushort moneyType)
        {
            return GoodsHelper.GetGoodsOriginalNameByTypeId(moneyType);
        }

        public static ushort GetMoneyTypeByString(string type)
        {
            if (type == "MONEY_COIN")
            {
                return GameConst.MONEY_COIN;
            }

            if (type == "MONEY_COIN_ANY")
            {
                return GameConst.MONEY_COIN_ANY;
            }

            if (type == "MONEY_DIAMOND")
            {
                return GameConst.MONEY_DIAMOND;
            }

            if (type == "MONEY_DIAMOND_ANY")
            {
                return GameConst.MONEY_DIAMOND_ANY;
            }

            if (type == "MONEY_DIAMOND_BIND")
            {
                return GameConst.MONEY_DIAMOND_BIND;
            }

            if (type == "MONEY_COIN_BIND")
            {
                return GameConst.MONEY_COIN_BIND;
            }
            if (type == "MONEY_TRIGRAM_SP")
            {
                return GameConst.MONEY_TRIGRAM_SP;
            }

            if (type == "MONEY_HANG_TIME")
            {
                return GameConst.MONEY_HANG_TIME;
            }

            if (type == "MONEY_HONOR")
            {
                return GameConst.MONEY_HONOR;
            }

            return 0;
        }

        public static string GetMoneySpriteName(string type)
        {
            int moneyType = GetMoneyTypeByString(type);

            return GetMoneySpriteName(moneyType);
        }

        public static string GetMoneySpriteName(int moneyType)
        {
            var info = DBManager.instance.GetDB<DBCurrencyInfo>().GetOneInfo(moneyType);
            if (info == null)
                return string.Empty;
            return info.CurrencyIcon;
        }

        public void RegisterAllMessage()
        {
            if (mbRegisterAllMessage)
                return;

            mbRegisterAllMessage = true;
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_SYNC_ATTRS, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_ACC_GET_RAND_NAME, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_HP, HandleServerData);// 多人副本中血量改变
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_EN, HandleServerData);// 多人副本中蓝量改变
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_FURY, HandleServerData);// 本地玩家的怒气值
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_LV_EXP, HandleServerData);// 同步等级和经验
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_MONEY, HandleServerData);// 同步等级和经验
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_WLV, HandleServerData);// 世界等级
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_CHANGE_NAME, HandleServerData);// 改名
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_RESCUE, HandleServerData);// 技能复活
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_LVPOINT_INFO, HandleServerData);// 升级点数
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GOODS_ADD_HP, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_BUFF_ADD_EN, HandleServerData);
        }

        public void UnRegisterAllMessage()
        {
            if (!mbRegisterAllMessage)
                return;

            mbRegisterAllMessage = false;
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_PLAYER_SYNC_ATTRS, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_ACC_GET_RAND_NAME, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_HP, HandleServerData);// 多人副本中血量改变
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_EN, HandleServerData);// 多人副本中蓝量改变
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_FURY, HandleServerData);// 本地玩家的怒气值
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_PLAYER_LV_EXP, HandleServerData);// 同步等级和经验
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_MONEY, HandleServerData);// 同步等级和经验
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_PLAYER_WLV, HandleServerData);// 世界等级
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_PLAYER_CHANGE_NAME, HandleServerData);// 改名
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_RESCUE, HandleServerData);// 技能复活
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_PLAYER_LVPOINT_INFO, HandleServerData);// 升级点数
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_GOODS_ADD_HP, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_BUFF_ADD_EN, HandleServerData);
        }

        private void HandleServerData(ushort protocol, byte[] data)
        {
            Actor localActor = Game.GetInstance().GetLocalPlayer();
            switch (protocol)
            {
                case NetMsg.MSG_ACC_GET_RAND_NAME: //获取随机名字
                    {
                        S2CAccGetRandName s2cRandName = S2CPackBase.DeserializePack<S2CAccGetRandName>(data);
                        string roleName = System.Text.Encoding.UTF8.GetString(s2cRandName.name);
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_RANDNAME_UPDATE, new CEventBaseArgs(roleName));
                    }
                    break;
                case NetMsg.MSG_PLAYER_SYNC_ATTRS: //同步属性
                    {
                        var sync_attr = S2CPackBase.DeserializePack<S2CPlayerSyncAttrs>(data);
                        ProcessCharacterInfo(sync_attr);

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.EC_PLAYER_ATTRS_UPDATE, new CEventBaseArgs());
                    }
                    break;
                case NetMsg.MSG_NWAR_BUFF_ADD_EN://多人副本中的Buff加蓝
                    {
                        var packData = S2CPackBase.DeserializePack<S2CNwarBuffAddEn>(data);
                        Actor act = Game.GetInstance().GetLocalPlayer();
                        if (act != null && !act.IsDead() && act.UID.obj_idx == packData.uuid)
                        {
                            act.ShowDamageEffect(FightEffectHelp.FightEffectType.AddMp, 0, (int)packData.en);
                        }
                    }
                    break;
                case NetMsg.MSG_NWAR_HP://玩家血量
                    {
                        S2CNwarHp rep = S2CPackBase.DeserializePack<S2CNwarHp>(data);
                        if (rep.uuid == Game.GetInstance().LocalPlayerID.obj_idx)
                        {
                            if (LocalActorAttribute != null)
                                LocalActorAttribute.HP = rep.hp;
                        }

                        Actor act = ActorManager.Instance.GetPlayer(rep.uuid);
                        if (act != null)
                        {
                            act.CurLife = rep.hp;
                            if (act.FullLife < rep.hp)
                                act.FullLife = rep.hp;
                        }

                        if (rep.uuid == Game.GetInstance().LocalPlayerID.obj_idx)
                        {
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCAL_PLAYER_NWAR_CHANGED, new CEventEventParamArgs("hp", rep.hp));
                        }
                    }
                    break;
                case NetMsg.MSG_NWAR_EN://玩家蓝量
                    {
                        S2CNwarEn rep = S2CPackBase.DeserializePack<S2CNwarEn>(data);

                        if (rep.uuid == Game.GetInstance().LocalPlayerID.obj_idx)
                        {
                            if (LocalActorAttribute != null)
                                LocalActorAttribute.MP = rep.en;
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCAL_PLAYER_NWAR_CHANGED, new CEventEventParamArgs("en", rep.en));
                        }

                        Actor act = ActorManager.Instance.GetPlayer(rep.uuid);
                        if (act != null)
                        {
                            act.CurMp = rep.en;
                            if (act.FullMp < rep.en)
                                act.FullMp = rep.en;
                        }
                    }
                    break;
                case NetMsg.MSG_NWAR_FURY:// 同步怒气数值
                    {
                        var msg_fury = S2CPackBase.DeserializePack<S2CNwarFury>(data);
                        Fury = msg_fury.fury;
                    }
                    break;
                case NetMsg.MSG_PLAYER_LV_EXP: //同步等级和经验
                    {
                        var lv_exp = S2CPackBase.DeserializePack<S2CPlayerLvExp>(data);
                        ProcessCharacterInfo(lv_exp);
                    }
                    break;
                case NetMsg.MSG_MONEY://货币信息
                    {
                        S2CMoney s2cMoney = S2CPackBase.DeserializePack<S2CMoney>(data);
                        ProcessMoney(s2cMoney);
                    }
                    break;
                case NetMsg.MSG_PLAYER_WLV: //世界等级
                    {
                        S2CPlayerWlv s2cPlayerWlv = S2CPackBase.DeserializePack<S2CPlayerWlv>(data);
                        WorldLevel = s2cPlayerWlv.wlv;
                        LimitLevel = s2cPlayerWlv.limit_lv;
                        HiBreak = s2cPlayerWlv.limit_hilv;
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_WORLD_LEVEL_UPDATE, null);
                    }
                    break;
                case NetMsg.MSG_PLAYER_CHANGE_NAME: //改名
                    {
                        S2CPlayerChangeName s2cPlayerChangName = S2CPackBase.DeserializePack<S2CPlayerChangeName>(data);
                        Game.GetInstance().LocalPlayerName = System.Text.Encoding.UTF8.GetString(s2cPlayerChangName.name);
                        UINotice.Instance.ShowMessage(DBConstText.GetText("ROLE_RENAME_SUCC") + Game.GetInstance().LocalPlayerName);
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_BASEINFO_UPDATE, new CEventActorArgs(localActor));
                    }
                    break;
                case NetMsg.MSG_PLAYER_LVPOINT_INFO: //等级加点信息
                    {
                        var msg = S2CPackBase.DeserializePack<S2CPlayerLvpointInfo>(data);
                        ReaminLvPoint = msg.remain;
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.EC_PLAYER_LV_POINT_UPDATE, new CEventBaseArgs());
                    }
                    break;
                case NetMsg.MSG_GOODS_ADD_HP: //物品加血
                    {
                        var rep = S2CPackBase.DeserializePack<S2CGoodsAddHp>(data);
                        Actor act = Game.GetInstance().GetLocalPlayer();
                        if (act != null && !act.IsDead())
                        {
                            act.ShowDamageEffect(FightEffectHelp.FightEffectType.AddHp, 0, (int)rep.hp);
                        }
                    }
                    break;
            }
        }

        void GetExpMax()
        {
            DBLevelExp.LevelExpInfo info = DBLevelExp.Instance.GetLevelInfo(LocalActorAttribute.Level);
            if (info != null)
                ExpMax = info.Exp;
        }

        private void ProcessMoney(S2CMoney s2cMoney)
        {
            string text = string.Empty;
            bool is_change = false;
            bool show_cost_or_add_tips = false;
            int change_money = 0;
            foreach (PkgMoneyInfo money in s2cMoney.info)
            {
                show_cost_or_add_tips = false;
                text = string.Empty;
                switch (money.money_type)
                {
                    case GameConst.MONEY_COIN:
                        {
                            if(Coin != money.num)
                            {
                                show_cost_or_add_tips = true;
                                change_money = (int)(money.num) - (int)(Coin);
                                Coin = money.num;
                                is_change = true;
                            }
                            break;
                        }
                    case GameConst.MONEY_TRIGRAM_SP:
                        {
                            if(TrigramSp != money.num)
                            {
                                if (TrigramSp < money.num)
                                {
                                    uint add_sp = money.num - TrigramSp;
                                    var localplayer = Game.Instance.GetLocalPlayer();
                                    if (localplayer != null)
                                        localplayer.ShowDamageEffect(FightEffectHelp.FightEffectType.AddSp, 0, (int)(add_sp));
                                }
                                TrigramSp = money.num;
                                is_change = true;
                            }
                            break;
                        }
                    case GameConst.MONEY_DIAMOND:
                        {
                            if(Diamond != money.num)
                            {
                                show_cost_or_add_tips = true;
                                change_money = (int)(money.num) - (int)(Diamond);
                                Diamond = money.num;
                                is_change = true;
                            }
                            break;
                        }

                    case GameConst.MONEY_SOUL_CREAM:
                        {
                            if(SoulCream != money.num)
                            {
                                show_cost_or_add_tips = true;
                                change_money = (int)(money.num) - (int)(SoulCream);
                                SoulCream = money.num;
                                is_change = true;
                            }
                            break;
                        }
                    case GameConst.MONEY_SOUL_HOLY_WATER:
                        {
                            if (SoulHolyWater != money.num)
                            {
                                show_cost_or_add_tips = true;
                                change_money = (int)(money.num) - (int)(SoulHolyWater);
                                SoulHolyWater = money.num;
                                is_change = true;
                            }
                            break;
                        }
                    case GameConst.MONEY_COIN_BIND:
                        {
                            if (BindCoin != money.num)
                            {
                                BindCoin = money.num;
                                is_change = true;
                            }
                            break;
                        }
                    case GameConst.MONEY_DIAMOND_BIND:
                        {
                            if(BindDiamond != money.num)
                            {
                                show_cost_or_add_tips = true;
                                change_money = (int)(money.num) - (int)(BindDiamond);
                                BindDiamond = money.num;
                                is_change = true;
                            }
                            break;
                        }

                    case GameConst.MONEY_HANG_TIME:
                        {
                            if (HangTime != money.num)
                            {
                                show_cost_or_add_tips = true;
                                int value = Mathf.Abs((int)HangTime - (int)money.num);
                                string str = CommonTool.SecondsToStr_2(value);

                                if (HangTime > money.num)
                                    text = string.Format(DBConstText.GetText("BAG_LOST_HANG_TIME"), str);
                                else
                                    text = string.Format(DBConstText.GetText("BAG_GET_HANG_TIME"), str);

                                HangTime = money.num;
                                is_change = true;

                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_OFFLINE_HANGE_TIME_UPDATE, null);
                            }
                            break;
                        }

                    default:
                        {
                            uint old_num = 0;
                            if (MoneyData.ContainsKey((ushort)money.money_type))
                                old_num = MoneyData[(ushort)money.money_type];

                            MoneyData[(ushort)money.money_type] = money.num;
                            if(old_num != money.num)
                            {
                                if (old_num < money.num) //获得货币
                                {
                                    var info = DBMoney.Instance.GetMoneyInfo(money.money_type);
                                    if (info != null)
                                        show_cost_or_add_tips = info.show_get;

                                    change_money = (int)(money.num - old_num);
                                }
                                is_change = true;
                            }
                            break;
                        }
                }

                if (Game.Instance.AllSystemInited)
                {
                    if (s2cMoney.op == GameConst.MONEY_OPERATE_NO_TIP)
                        show_cost_or_add_tips = false;  //一定不飘字
                    if (show_cost_or_add_tips && string.IsNullOrEmpty(text))
                    {
                        string goods_name = GoodsHelper.GetGoodsNameByTypeId_blackBkg(money.money_type);
                        if (change_money > 0)
                            text = string.Format(DBConstText.GetText("COMMON_ADD_ONE_MONEY_NUM"), goods_name, change_money);
                    }

                    if (string.IsNullOrEmpty(text) == false)
                    {
                        UINotice.Instance.ShowMessage(text);
                    }
                }
            }

            if (is_change == false)
                return;

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MONEY_UPDATE, null);
        }

        ulong GetAddExp(uint old_level, ulong old_exp, uint new_level, ulong new_exp)
        {
            if (old_level > new_level)
                return 0;
            if(old_level == new_level)
            {
                if (new_exp > old_exp)
                    return new_exp - old_exp;
                return 0;
            }
            DBLevelExp db_level_exp = DBManager.Instance.GetDB<DBLevelExp>();
            ulong add_exp = 0;
            DBLevelExp.LevelExpInfo exp_info;
            for (uint level = old_level; level < new_level; ++level)
            {
                exp_info = db_level_exp.GetLevelInfo(level);
                if (exp_info != null)
                {
                    if (level == old_level)
                        add_exp = add_exp + exp_info.Exp - old_exp;
                    else
                        add_exp = add_exp + exp_info.Exp;
                }
            }
            add_exp = add_exp + new_exp;
            return add_exp;
        }

        public void ProcessCharacterInfo(S2CPlayerLvExp lv_exp)
        {
            bool isInitInfo = IsFirstCallBackExp;

            if (IsFirstCallBackExp == true)
            {
                IsFirstCallBackExp = false;
                GetExpMax();
            }

            bool is_level_change = false;

            ulong add_exp = GetAddExp(Level, Exp, lv_exp.level, lv_exp.exp);
            // 检测角色等级是否变化
            if (LocalActorAttribute != null && LocalActorAttribute.Level != lv_exp.level)
            {
                LocalActorAttribute.Level = lv_exp.level;
                GlobalConfig.GetInstance().LoginInfo.Level = lv_exp.level.ToString();
                GetExpMax();
                is_level_change = true;

                if (isInitInfo == false)
                {
                    ControlServerLogHelper.Instance.PostRoleInfo();
                }
                HookSettingManager.Instance.UpdateAutoBuyDrugGoodsId();
            }

            // 收到角色信息时都要检查是否弹出小包的更新界面
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CHECK_MINIPACK, null);
            if (add_exp > 0)
            {
                //                UINotice.GetInstance().ShowMessage("[efdb7c]获得经验：[e3e3e3]" + (s2cLvExp.exp - Exp));
                var localplayer = Game.Instance.GetLocalPlayer();
                if (localplayer != null)
                {
                    string push_str = "";
                    if (lv_exp.extra_rate > 0)
                    {
                        push_str = (lv_exp.extra_rate / 100.0f).ToString("0");
                        //push_str = ActorUtils.Instance.TrimFloatStr(push_str);
                        push_str = string.Format("(+{0}%)", push_str);
                    }
                    localplayer.ShowDamageEffect(FightEffectHelp.FightEffectType.AddExp, 0, (long)add_exp, false, push_str);
                }
                    

                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCALPLAYER_EXP_ADDED, new CEventObjectArgs(add_exp, lv_exp.reason));
            }

            Exp = lv_exp.exp;

            Actor localActor = Game.GetInstance().GetLocalPlayer();
            if (null != localActor)
            {
                localActor.SetActorAttribute(LocalActorAttribute);

                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_BASEINFO_UPDATE, new CEventActorArgs(localActor));
            }

            if (is_level_change && !isInitInfo)
            {
                ItemManager.Instance.CheckBagCanQuickUse();
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE, new CEventBaseArgs());

                // 等级升级的时候通知sdk
                SDKControler.getSDKControler().sendRoleInfo2SDK((int)SDKControler.RoleEvent.LEVEL_UP);
            }
        }

        List<uint> mUpdateTipsShowLevelRange = null;
        List<uint> mUpdateTipsShowReasons = null;
        public void ProcessCharacterInfo(S2CPlayerSyncAttrs attrs)
        {
            // 有变化的属性
            ActorAttribute actorAttributeOffset = new ActorAttribute();
            actorAttributeOffset.Clear();

            // 同步服务端数据
            foreach (PkgAttrElm attrElm in attrs.attr_elm)
            {
                // 属性赋值
                IActorAttribute attr = null;
                if (LocalActorAttribute.Attribute.TryGetValue(attrElm.attr, out attr))
                {
                    if ((ushort)attrElm.attr != GameConst.AR_BAT_PW)
                    {
                        // 属性增加才显示
                        if (attrElm.value > attr.Value)
                        {
                            actorAttributeOffset.Add(attrElm.attr, attrElm.value - attr.Value);
                        }
                    }
                    attr.Value = attrElm.value;
                }
                else
                {
                    if ((ushort)attrElm.attr != GameConst.AR_BAT_PW)
                    {
                        actorAttributeOffset.Add(attrElm.attr, attrElm.value);
                    }
                    //包含其他字段赋值
                    LocalActorAttribute.Attribute.Add(attrElm.attr, attrElm.value);
                }

                if ((ushort)attrElm.attr == GameConst.AR_BAT_PW)//战斗力赋值
                {
                    long new_battlepower = attrElm.value;
                    long delta = new_battlepower - mLastBattlePower;
                    if (new_battlepower != 0 && mLastBattlePower != 0)
                    {
                        //if (delta > 0)
                        if(delta != 0)
                            TryShowFightRankAnim(delta);
                    }

                    mLastBattlePower = new_battlepower;
                    LocalActorAttribute.BattlePower = new_battlepower;

                    if (delta != 0)
                    {
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCALPLAYER_BATTLE_POWER_CHANGED, null);
                    }
                }

                // 移动速度的同步需要特殊处理
                Actor actor = Game.GetInstance().GetLocalPlayer();
                if (null != actor)
                {
                    if ((ushort)attrElm.attr == GameConst.AR_SPEED || (ushort)attrElm.attr == GameConst.AR_SPEED_ADD)
                    {
                        actor.SetMoveSpeedScale(LocalActorAttribute.MoveSpeedScale * GlobalConst.AttrConvert, LocalActorAttribute.MoveSpeedAdd);
                    }
                }
            }

            if (mUpdateTipsShowLevelRange == null)
            {
                mUpdateTipsShowLevelRange = GameConstHelper.GetUintList("GAME_ATTR_UPDATE_TIPS_SHOW_LEVEL_RANGE");
            }
            if (mUpdateTipsShowReasons == null)
            {
                mUpdateTipsShowReasons = GameConstHelper.GetUintList("GAME_ATTR_UPDATE_TIPS_SHOW_REASONS");
            }
            bool meetShowReason = false;
            foreach (uint reason in mUpdateTipsShowReasons)
            {
                if (reason == attrs.reason)
                {
                    meetShowReason = true;
                }
            }
            if (meetShowReason == true && Level >= mUpdateTipsShowLevelRange[0] && Level <= mUpdateTipsShowLevelRange[1] && attrs.init != 1 && actorAttributeOffset.Count > 0)
            {
                // 属性变化界面的弹出，如果战力提升界面正在显示，则等该界面关闭后再弹出属性变化界面
                if (xc.ui.ugui.UIManager.Instance.GetExistingWindow("UIAttributeTipsWindow") != null)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SHOW_ATTRS_UPDATE_WINDOW, new CEventBaseArgs(actorAttributeOffset));
                }
                else
                {
                    xc.ui.ugui.UIManager.Instance.ShowWindow("UIAttributeTipsWindow", actorAttributeOffset);
                }
            }

            // 设置本地玩家的属性
            Actor local_player = Game.GetInstance().GetLocalPlayer();
            if (null != local_player)
            {
                bool need_update_hp = false;
                if(mLastHp != LocalActorAttribute.HP || mLastHpMax != LocalActorAttribute.HPMax)
                {
                    need_update_hp = true;
                    mLastHp = LocalActorAttribute.HP;
                    mLastHpMax = LocalActorAttribute.HPMax;
                }

                local_player.SetActorAttribute(LocalActorAttribute);

                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_BASEINFO_UPDATE, new CEventActorArgs(local_player));

                if (need_update_hp)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCAL_PLAYER_NWAR_CHANGED, new CEventEventParamArgs("hp", LocalActorAttribute.HP));
                    local_player.CurLife = local_player.CurLife;// 强制更新下当前血量, 发送相关的消息
                    local_player.FullLife = LocalActorAttribute.HPMax;
                }
            }
        }

        /// <summary>
        /// 初始化角色属性
        /// </summary>
        public void InitAttribute(uint type_id, string name)
        {
            if (LocalActorAttribute == null)
                LocalActorAttribute = new ActorAttributeData();

            LocalActorAttribute.InitAttributeData(type_id);
            LocalActorAttribute.Name = name;
        }

        /// <summary>
        /// 主宠ID(品质)
        /// </summary>
        public uint MountId
        {
            get
            {
                return mMountId;
            }
            set
            {
                if (value != mMountId)
                {
                    mMountId = value;
                    //触发事件
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_MOUNT_LOCAL_PLAYER_CHANGED_ID_IN_SCENE, new CEventBaseArgs());
                }
            }
        }

        /// <summary>
        /// 坐骑的等级
        /// </summary>
        public uint MountLv;




        List<long> m_cacheFightRankArray = new List<long>();
        public void TryShowFightRankAnim(long add_num)
        {
            bool isShowing = UIManager.Instance.GetWindow("UIFightRankWindow") != null;
            //Debug.Log("UIFightRankWindow TryShowFightRankAnim " + isShowing + "    "+ add_num);
            if (add_num <= 0 && m_cacheFightRankArray.Count == 0 && !isShowing)
            {
                return;
            }
            m_cacheFightRankArray.Add(add_num);

            if(!isShowing)
            {
                xc.ui.ugui.UIManager.Instance.ShowWindow("UIFightRankWindow");
            }
        }

        /// <summary>
        /// 返回下一个战力新增值
        /// </summary>
        /// <returns>若返回0，则没有下一个战力新增值</returns>
        public long GetNextFightRankNum()
        {
            if (m_cacheFightRankArray.Count == 0)
                return 0;
            long next_fight_rank = m_cacheFightRankArray[0];
            return next_fight_rank;
        }

        public void RemoveNextFightRankNum()
        {
            if (m_cacheFightRankArray.Count == 0)
                return;
            m_cacheFightRankArray.RemoveAt(0);
        }

        public long PopAllFightRankNum()
        {
            long add = 0;
            for (var i = 0; i < m_cacheFightRankArray.Count; i++)
            {
                add += m_cacheFightRankArray[i];
            }
            m_cacheFightRankArray.Clear();
            //Debug.Log("UIFightRankWindow PopAllFightRankNum " + add);

            return add;
        }

        public void ClearFightRank()
        {
            m_cacheFightRankArray.Clear();
        }

        public int GetFightRankCount()
        {
            return m_cacheFightRankArray.Count;
        }

        public bool m_isFirstLoadingScene = false;    //是否第一次进入场景
        public bool m_canShowBuffTips = true;   //是否可以显示获得buff提示
        private uint m_firstGetNewMountId = 0;   //第一次获得的坐骑ID（系统未开放）
        public uint FristGetNewMountId
        {
            get { return m_firstGetNewMountId; }
            set {
                if (m_firstGetNewMountId == value)
                    return;
                m_firstGetNewMountId = value;
                if(m_firstGetNewMountId != 0)
                {
                    if(Game.GetInstance().LocalPlayerID != null)
                    {
                        CustomDataMgr.Instance.AddCustomData(CustomDataType.IsOpenSysMount, 1, true);
                        m_hasOpenSysMount = true;
                    }
                }
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_MOUNT_EXCHANGE_FIRST_GETING_NEW_MOUNT_ID, null);
            }
        }

        private bool m_hasInitOpenSysMount = false;
        private bool m_hasOpenSysMount = false;
        public bool HasOpenSysMount
        {
            get {
                InitHasOpenSysMount();
                if (m_hasInitOpenSysMount == false)
                    return true;//如果没有取到数据，则默认认为坐骑系统已经开放
                return m_hasOpenSysMount;
            }
        }

        public void ResetOpenSysMount()
        {
            m_hasInitOpenSysMount = false;
            InitHasOpenSysMount();
        }

        void InitHasOpenSysMount()
        {
            if (m_hasInitOpenSysMount)
                return;
            if(Game.GetInstance().LocalPlayerID == null)
            {
                m_hasInitOpenSysMount = false;
                return;
            }
            string newSkillSaveNameStr = string.Format("{0}IsOpenSysMount", Game.GetInstance().LocalPlayerID.obj_idx);
            m_hasOpenSysMount = UserPlayerPrefs.GetInstance().GetInt(newSkillSaveNameStr, 0) == 1; //默认是不开启
            //默认是不开启
            if (CustomDataMgr.Instance.IsExistCustomData(CustomDataType.IsOpenSysMount, 1))
                m_hasOpenSysMount = true;
            m_hasInitOpenSysMount = true;
        }

        /// <summary>
        /// 是否完成过第一次获得坐骑动画
        /// </summary>
        /// <returns></returns>
        public bool IsFinishOpenMountAnim()
        {
            InitHasOpenSysMount();
            if (m_hasInitOpenSysMount && m_hasOpenSysMount && FristGetNewMountId == 0)
                return true;
            return false;
        }
    }
}


