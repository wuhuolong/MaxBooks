using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using xc.protocol;
using xc.ui;
using Net;

namespace xc
{
    //PK模式管理类扩展
    [wxb.Hotfix]
    public class PKModeManagerEx : xc.Singleton<PKModeManagerEx>
    {
        private uint mPKMode;
        private uint mPKValue;  //PK值
        private bool m_has_init_inSafeArea = false;
        private bool m_isInSafeArea = false;
        private bool m_has_init_inPKArea = false;   //是否初始化过 m_isInPKArea
        private bool m_isInPKArea = false;
        private bool m_final_canAttackRemotePlayer = true;  //主角是否可以攻击其他玩家

        private Dictionary<uint, float> m_hostileAttackMap;
        private int m_hostileAttackTipsInterval;  //恶意攻击tips的时间间隔（秒）
        private uint m_gamePKReviveBuffId;           //pk复活BUFFid
        private uint m_gamePVPBloodDelayDisappearInterval;
        private uint m_game_wboss_lv_no_drop;
        private uint m_game_wboss_lv_no_drop_tips_interval = 5;
        private float m_last_show_no_drop_tips_time = 0;

        //主角处于PVP的PK状态
        private bool m_isPVPBattleState = false;
        private float m_enterPVPTime = 0;   //进入PVP的时间
        private uint m_gameEnterPVPStateInterval = 10; //进入PVP的时间（秒）

        public bool IsPVPBattleState //传送限制
        {
            get {
                return m_isPVPBattleState;
            }
            set
            {
                bool can_exchange_state = false;
                if (m_isPVPBattleState != value)
                    can_exchange_state = true;
                m_isPVPBattleState = value;
                if(m_isPVPBattleState)
                    m_enterPVPTime = Time.realtimeSinceStartup;
                if (can_exchange_state)//改变PVP状态
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_LOCAL_PLAYER_EXCHANGE_PVP_STATE, new CEventBaseArgs(m_isPVPBattleState));
            }
        }

        public void UpdatePVPBattleState()
        {
            if (m_isPVPBattleState == false)
                return;
            float now_time = Time.realtimeSinceStartup;
            if (m_enterPVPTime + m_gameEnterPVPStateInterval < now_time)
            {
                IsPVPBattleState = false;
            }
        }

        void ShowMessage(string str, bool is_important_msg = false)
        {
            if (Game.GetInstance().IsSwitchingScene == false)
                xc.UINotice.Instance.ShowMessage(str, is_important_msg);
        }
        void ShowMessage_showMaxOne(string str, bool is_important_msg = false)
        {
            if (Game.GetInstance().IsSwitchingScene == false)
                xc.UINotice.Instance.ShowMessage_showMaxOne(str, is_important_msg);
        }
        /// <summary>
        /// 是否在安全区域
        /// </summary>
        public bool IsInSafeArea
        {
            get { return m_isInSafeArea; }
            set
            {
                if (m_has_init_inSafeArea && m_isInSafeArea == value)
                    return;
                
                m_isInSafeArea = value;
                UpdateAttack();
                if(m_has_init_inSafeArea)
                {
                    if (m_isInSafeArea)
                        ShowMessage(xc.DBConstText.GetText("ENTER_SAFE_AREA"), true);
                    else
                        ShowMessage(xc.DBConstText.GetText("EXIT_SAFE_AREA"), true);
                }
                
                ClientEventMgr.Instance.FireEvent((int)xc.ClientEvent.CE_CHANGE_LOCALPLAYER_IN_SAFE_AREA, null);
                PKModeManagerEx.Instance.UpdatePKIcons();
                m_has_init_inSafeArea = true;
            }
        }
        
        /// <summary>
        /// 是否在PK区域
        /// </summary>
        public bool IsInPKArea
        {
            get { return m_isInPKArea; }
            set
            {
                if (m_has_init_inPKArea && m_isInPKArea == value)
                    return;
                
                m_isInPKArea = value;
                UpdateAttack();
                ClientEventMgr.Instance.FireEvent((int)xc.ClientEvent.CE_CHANGE_LOCALPLAYER_IN_PK_AREA, null);

                bool show_tips = false;
                //bool need_exchange_mode = false;
                if (m_isInPKArea)
                {
                    //进入PK区域
                    int scene_pk_type = InstanceManager.Instance.InstanceInfo.mPKType;
                    if (IsScenePKSafe(scene_pk_type) || scene_pk_type == GameConst.SCENE_PK_COMMON)
                    {//安全场景或PK场景的PK区域，自动切换成“强制PK模式”
                        if(PKMode != GameConst.PK_MODE_FRIENDLY && PKMode != GameConst.PK_MODE_KILLER)
                        {
                            C2SPlayerPkMode pack = new C2SPlayerPkMode();
                            pack.mode = GameConst.PK_MODE_FRIENDLY;
                            NetClient.GetBaseClient().SendData<C2SPlayerPkMode>(NetMsg.MSG_PLAYER_PK_MODE, pack);
                            if(m_has_init_inPKArea)
                                ShowMessage(xc.DBConstText.GetText("FORCE_CHANGE_PK_MODE_TO_FRIENDLY"), true);
                            show_tips = true;
                            //need_exchange_mode = true;
                        }
                    }
                }
                else
                {//退出安全区域
                    int scene_pk_type = InstanceManager.Instance.InstanceInfo.mPKType;
                    if (IsScenePKSafe(scene_pk_type) || scene_pk_type == GameConst.SCENE_PK_COMMON)
                    {//安全场景或PK场景的PK区域，自动切换成“和平PK模式”
                        if (PKMode != GameConst.PK_MODE_PEACE)
                        {
                            C2SPlayerPkMode pack = new C2SPlayerPkMode();
                            pack.mode = GameConst.PK_MODE_PEACE;
                            NetClient.GetBaseClient().SendData<C2SPlayerPkMode>(NetMsg.MSG_PLAYER_PK_MODE, pack);
                            if (m_has_init_inPKArea)
                                ShowMessage(xc.DBConstText.GetText("FORCE_CHANGE_PK_MODE_TO_PEACE"), true);
                            show_tips = true;
                            //need_exchange_mode = true;
                        }
                    }
                }
                if(m_has_init_inPKArea && show_tips == false)
                {
                    if (m_isInPKArea)
                        ShowMessage(xc.DBConstText.GetText("ENTER_PK_AREA"), true);
                    else
                        ShowMessage(xc.DBConstText.GetText("EXIT_PK_AREA"), true);
                }
                m_has_init_inPKArea = true;
                PKModeManagerEx.Instance.UpdatePKIcons();
            }
        }

        public void UpdateAttack()
        {
            bool new_canAttack = IsInAttackArea();
            if (new_canAttack == m_final_canAttackRemotePlayer)
                return;
            m_final_canAttackRemotePlayer = new_canAttack;
        }

        public bool IsInAttackArea()
        {
            if (IsInSafeArea)
                return false;
            if (IsInPKArea)
                return true;
            if (InstanceManager.Instance.InstanceInfo == null)
                return false;
            int scene_pk_type = InstanceManager.Instance.InstanceInfo.mPKType;
            if (IsScenePKSafe(scene_pk_type))
                return false;
            else if (scene_pk_type == GameConst.SCENE_PK_DANGER)
                return true;
            else if (scene_pk_type == GameConst.SCENE_PK_COMMON)
                return true;
            else
            {
                GameDebug.LogError(string.Format("undefined scene_pk_type = {0}", scene_pk_type));
                return true;
            }   
        }
        public uint PKValue {
            set
            {
                if (mPKValue == value)
                    return;
                mPKValue = value;
                ClientEventMgr.Instance.FireEvent((int)xc.ClientEvent.CE_CHANGE_LOCALPLAYER_PKVALUE, null);
            }
            get { return mPKValue; }
        }
        public int mGamePKLvProtect;
        
        public uint PKMode {
            get
            {
                return mPKMode;
            }
        }

        bool mOpenPVPBlood;
        private List<UnitID> m_removeEnemys = new List<UnitID>();
        private Dictionary<UnitID, float> mEnemyPVPBloodList = new Dictionary<UnitID, float>();
        public bool ShowPVPBlood
        {
            get { return mOpenPVPBlood; }
            set
            {
                if(mOpenPVPBlood != value)
                {
                    mOpenPVPBlood = value;
                    //刷新血条可见性
                    foreach (Actor actor in ActorManager.Instance.PlayerSet.Values)
                    {
                        Player player = actor as Player;
                        if (player != null)
                        {
                            player.UpdatePVPBlood();
                        }
                    }
                }
            }
        }
        public void AddOneEnemy(UnitID uid)
        {
            if (uid == null)
                return;
            int last_count = mEnemyPVPBloodList.Count;
            mEnemyPVPBloodList[uid] = Time.realtimeSinceStartup;
            if (last_count == 0)
            {//之前是空列表，尝试刷新一次是否显示血条
                RefreshPVPVisible();
            }
            else
            {
                //更新新加敌人的血条
                Actor enemy_actor = ActorManager.Instance.GetActor(uid);
                if (enemy_actor != null && enemy_actor is Player)
                {
                    (enemy_actor as Player).OpenPVPBlood = true;
                }
            }
        }

        public void DelOneEmey(UnitID uid)
        {
            if (mEnemyPVPBloodList.ContainsKey(uid) == false)
                return;
            mEnemyPVPBloodList.Remove(uid);
            if (mEnemyPVPBloodList.Count == 0)
            {//变成是空列表
                RefreshPVPVisible();
            }
            else
            {
                //更新新加敌人的血条
                Actor enemy_actor = ActorManager.Instance.GetActor(uid);
                if (enemy_actor != null && enemy_actor is Player)
                {
                    (enemy_actor as Player).UpdatePVPBlood();
                }
            }
        }

        public void UpdateEnemyList()
        {
            m_removeEnemys.Clear();
            float now_time = Time.realtimeSinceStartup;
            float pass_time = 0;
            foreach (var item in mEnemyPVPBloodList)
            {
                pass_time = now_time - item.Value;
                if (pass_time > m_gamePVPBloodDelayDisappearInterval)
                {//超过5秒，主动删除
                    m_removeEnemys.Add(item.Key);
                }
            }
            for (int index = 0; index < m_removeEnemys.Count; ++index)
            {
                DelOneEmey(m_removeEnemys[index]);
            }
        }

        bool GetShowPVPBlood()
        {
            if (PKModeManagerEx.Instance.PKMode != GameConst.PK_MODE_PEACE)
                return true;
            if (mEnemyPVPBloodList.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 是否处于PVP状态
        /// </summary>
        /// <returns></returns>
        public bool IsInPVPState()
        {
            if (mEnemyPVPBloodList == null || mEnemyPVPBloodList.Count == 0)
                return false;
            return true;
        }

        /// <summary>
        /// 是否可以跳转到其他副本去
        /// </summary>
        /// <returns></returns>
        public bool TryToOtherDungeonScene()
        {
            if (SceneHelp.IsReEnterScene)//处于重进当前场景中，一直允许切换
                return true;
            if (PKModeManagerEx.Instance.IsInPVPState() || PKModeManagerEx.Instance.IsPVPBattleState)
            {
                xc.UINotice.Instance.ShowMessage(DBConstText.GetText("SKILL_CANNT_FLY_IN_PVP_BATTLE"));
                return false;
            }
            return true;
        }
        

    void RefreshPVPVisible()
        {
            bool new_show = GetShowPVPBlood();
            if (mOpenPVPBlood != new_show)
            {
                PKModeManagerEx.GetInstance().ShowPVPBlood = new_show;
            }
        }


        public bool CanShowPVPBlood(Actor actor)
        {
            if (actor == null)
                return false;
            if (mOpenPVPBlood == false)
                return false;
            if (actor.IsPlayer() == false)//只有玩家才有血条
                return false;
            if (actor.IsLocalPlayer)
                return true;
            if(PKMode == GameConst.PK_MODE_PEACE)
            {//主角和平模式，却需要显示主角血条
                if (mEnemyPVPBloodList.ContainsKey(actor.UID)) //在仇恨列表中,需要显示血条
                    return true;
                return false;
            }
            else
            {
                //主角处于PK模式（非和平模式），所有的玩家血条都要显示(2018/1/4)
                if (actor.IsPlayer())
                    return true;
                return false;
                //主角处于PK模式（非和平模式），只显示敌人和友方
                //                 bool show_tips = false;
                //                 LocalPlayer localPlayer = (LocalPlayer)Game.GetInstance().GetLocalPlayer();
                //                 bool is_enemy = IsCanAttack(localPlayer, actor, ref show_tips);
                //                 if (is_enemy)
                //                     return true;
                //                 bool is_friend = IsFriendRelation(localPlayer, actor);
                //                 if (is_friend)
                //                     return true;
                //                 return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkMode"></param>
        public void UpdatePkMode(uint pkMode)
        {
            if (mPKMode == pkMode)
                return;
            mPKMode = pkMode;
            Actor localPlayer = xc.Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
                (localPlayer as LocalPlayer).SetPKMode(pkMode);
            RefreshPVPVisible();
        }
        

        private bool mIsPKProtectionTeamMate;
        public bool IsPKProtectionTeamMate {
            set
            {
                mIsPKProtectionTeamMate = value;
                UpdatePKIcons();
            }
            get
            {
                return mIsPKProtectionTeamMate;
            }
        }

        private bool mIsPKProtectionSociety;
        public bool IsPKProtectionSociety {
            set
            {
                mIsPKProtectionSociety = value;
                UpdatePKIcons();
            }
            get
            {
                return mIsPKProtectionSociety;
            }
        }

        private bool mIsPKProtectionGreenName;
        public bool IsPKProtectionGreenName
        {
            set
            {
                mIsPKProtectionGreenName = value;
                UpdatePKIcons();
            }
            get
            {
                return mIsPKProtectionGreenName;
            }
        }


        private uint mPKProtectionLv;
        public uint PKProtectionLv
        {
            set
            {
                mPKProtectionLv = value;
                UpdatePKIcons();
            }
            get
            {
                return mPKProtectionLv;
            }
        }

        /// <summary>
        /// 更新所有玩家的头顶PK状态
        /// </summary>
        public void UpdatePKIcons()
        {
            foreach (Actor actor in ActorManager.Instance.PlayerSet.Values)
            {
                Player player = actor as Player;
                if (player != null)
                {
                    player.UpdatePKIconImpl();
                }
            }
        }

        protected uint mLocalPlayerNameColor;
        public uint LocalPlayerNameColor {
            set
            {
                mLocalPlayerNameColor = value;
                LocalPlayer localPlayer = (LocalPlayer)Game.GetInstance().GetLocalPlayer();
                if (localPlayer != null)
                {
                    localPlayer.NameColor = value;
                    localPlayer.SetNameText();
                    //UpdatePKIcons();
                }
            }
        
            get
            {
                return mLocalPlayerNameColor;
            }
         }

        public PKModeManagerEx()
        {
            Reset();
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE, OnLevelup);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_GUILD_CHANGED_ID_IN_SCENE, OnChangeGuildId);
            
        }

        public void Reset()
        {
            PKValue = 0;
            mPKValue = 0;
            mPKMode = GameConst.PK_MODE_PEACE;
            IsPKProtectionTeamMate = true;
            IsPKProtectionSociety = true;
            IsPKProtectionGreenName = true;
            PKProtectionLv = GameConstHelper.GetUint("GAME_PK_MIN");
            mGamePKLvProtect = GameConstHelper.GetInt("GAME_PK_LV_PROTECT");
            m_hostileAttackMap = new Dictionary<uint, float>();
            m_hostileAttackTipsInterval = GameConstHelper.GetInt("GAME_PK_HOSTILEATTACK_TIPS_INTERVAL");
            m_gamePKReviveBuffId = GameConstHelper.GetUint("GAME_PK_REVIVE_BUFF_ID");
            m_gamePVPBloodDelayDisappearInterval = GameConstHelper.GetUint("GAME_BF_PVP_BLOOD_DELAY_DISAPPEAR_INTERVAL");
            m_game_wboss_lv_no_drop = GameConstHelper.GetUint("GAME_WBOSS_AFFILI_LV_NO_DROP");
            m_game_wboss_lv_no_drop_tips_interval = GameConstHelper.GetUint("GAME_WBOSS_AFFILI_LV_ON_DROP_CD_INTERVAL");
            m_gameEnterPVPStateInterval = GameConstHelper.GetUint("GAME_PK_ENTER_PVP_PK_INTERVAL");
        }

        public bool IsInPKScene()
        {
            // 非主城都可以进入pk模式
            // 现在已经没有了主城
            return true;
            /*uint ID = GameConstHelper.GetUint("GAME_GUILD_HOME_DUNGEON_ID");    // 军团驻地
            bool bRet = (SceneHelp.Instance.IsInPublicWildInstance() || xc.SceneHelp.Instance.CurSceneID == ID);
            return bRet;*/
        }

        public bool IsMonster(uint uuid)
        {
            return uuid >= GameConst.INIT_MON_UUID && uuid < GameConst.INIT_HUMAN_UUID;
        }

        public bool IsEqualActor(Actor attacker, Actor defender)
        {
            if (attacker == defender)
                return true;
            if (attacker != null && defender != null && attacker.UID.obj_idx == defender.UID.obj_idx)
                return true;
            return false;
        }

        //判断 A 是否可能攻击 B
        public bool IsEnemyRelation(Actor attacker, Actor defender, ref bool show_tips)
        {
            if (attacker == null || defender == null)
                return false;

            if(defender != null && defender.IsPlayer())
            {
                if (show_tips)
                {
                    if (InstanceManager.Instance.InstanceInfo != null)
                    {
                        int scene_pk_type = InstanceManager.Instance.InstanceInfo.mPKType;
                        if (IsScenePKSafe(scene_pk_type))
                        {
                            ShowMessage(xc.DBConstText.GetText("NO_BATTLE_IN_SAFE_SCENE"));
                            show_tips = false;
                            return false;
                        }
                    }
                    if (IsInSafeArea)
                    {
                        ShowMessage(xc.DBConstText.GetText("NO_DAMAGE_PK_MODE"));
                        show_tips = false;
                        return false;
                    }
                }

                if (!IsInPKScene())
                {
                    if (show_tips)
                    {
                        ShowMessage(xc.DBConstText.GetText("TRY_SKILL_IN_SAFEAREA"));
                        show_tips = false;
                    }
                    return false;
                }
            }
            
            
            if (IsEqualActor(attacker, defender))
                return false;

            //由于远程玩家没有挂rigidBody，检测不了安全区，故用本地玩家判断，存在的误差不大
            //             if (attacker.IsInSafeArea || defender.IsInSafeArea)
            //                 return false;
            

            string tips_id = string.Empty;
            bool is_enemy_relation = false;
            if (attacker.IsPlayer())
            {
                if (IsMonster(defender.UID.obj_idx))//玩家可以攻击怪物
                {
                    if(attacker.Camp == 0 || defender.Camp == 0 || attacker.Camp != defender.Camp)
                        is_enemy_relation = true;
                }
                else if (defender.IsPlayer() == false)  //玩家不可以攻击除“怪物和玩家”以外的actor
                    is_enemy_relation = false;  
                else
                {
                    if (m_final_canAttackRemotePlayer == false) //不可攻击其他玩家
                        return false;

                    Player attacker_player = attacker as Player;
                    Player defender_player = defender as Player;
                    if (attacker_player == null || defender_player == null)
                        return false;

                    if(SceneHelp.Instance.UsePKMode == false)//当前场景不允许使用PK模式判定，则直接视为“全体”模式
                    {
                        if (attacker.Camp == 0 || defender.Camp == 0 || attacker.Camp != defender.Camp)
                            return true;
                        return false;
                    }

                    bool is_common_team = true;//是否是同一个队伍(组队)
                    if (attacker_player.TeamId == 0 || defender_player.TeamId == 0 || attacker_player.TeamId != defender_player.TeamId)
                        is_common_team = false;

                    bool is_common_guild = true;//是否是同一个帮派
                    if (attacker_player.GuildId == 0 || defender_player.GuildId == 0 || attacker_player.GuildId != defender_player.GuildId)
                        is_common_guild = false;

                    // 取消反击的逻辑
                    /*if (is_common_team == false && is_common_guild == false && attacker_player.IsAttackEmeny(defender_player)) //防御者之前攻击过attacker
                    {
                        return true;
                    }*/

                    if (SceneHelp.Instance.PKLevelLimit) // 当前副本对pk具有等级限制
                    {
                        if (attacker_player.Level >= mGamePKLvProtect + defender_player.Level)  //不可攻击低于自身 mGamePKLvProtect 级的白名玩家
                        {
                            if (defender_player.NameColor == GameConst.NAME_COLOR_WHITE &&
                                InstanceManager.Instance.InstanceInfo != null)
                            {
                                int scene_pk_type = InstanceManager.Instance.InstanceInfo.mPKType;
                                //PK场景，PK区域不受等级差限制
                                if (scene_pk_type != GameConst.SCENE_PK_DANGER && IsInPKArea == false)
                                {
                                    if (show_tips)
                                    {
                                        ShowMessage(xc.DBConstText.GetText("LOW_LEVEL_PLAYER_PROTECK"));
                                        show_tips = false;
                                    }
                                    return false;
                                }
                            }
                        }
                    }

                    uint attacker_pk_mode = attacker_player.GetPKMode();
                    if (attacker_pk_mode == GameConst.PK_MODE_PEACE) // 和平模式
                    {
                        if (defender_player.NameColor != GameConst.NAME_COLOR_WHITE && defender_player.GetPKMode() == GameConst.PK_MODE_KILLER) //灰名且全体模式
                            is_enemy_relation = true;
                        else if(defender_player.NameColor != GameConst.NAME_COLOR_WHITE && is_common_team == false && is_common_guild == false) //灰名且敌军
                        {
                            is_enemy_relation = true;
                        }
                        else
                            is_enemy_relation = false;
                    }
                    else if (attacker_pk_mode == GameConst.PK_MODE_FRIENDLY)// 强制，不能攻击队友和盟友
                    {
                        if (is_common_team == false && is_common_guild == false) //敌军
                            is_enemy_relation = true;
                        else if(defender_player.NameColor != GameConst.NAME_COLOR_WHITE && defender_player.GetPKMode() == GameConst.PK_MODE_KILLER)//灰名 且 全体模式
                            is_enemy_relation = true;
                        else
                            is_enemy_relation = false;
                    }
                    else if (attacker_pk_mode == GameConst.PK_MODE_KILLER)//全体模式
                    {
                        is_enemy_relation = true;
                    }
                    else if (attacker_pk_mode == GameConst.PK_MODE_DEFEND)//TODO:防卫模式
                    {
                        is_enemy_relation = false;
                    }
                    else if (attacker_pk_mode == GameConst.PK_MODE_ATTACK)// 进攻模式
                    {
                        if (attacker.Camp != defender.Camp)// 攻守方的阵营不同
                            is_enemy_relation = true;
                        else
                            is_enemy_relation = false;
                    }
                    else if (attacker_pk_mode == GameConst.PK_MODE_SERVER)// 同服模式
                    {
                        var inSameServer = SpanServerManager.Instance.IsInSameServer(attacker.UID.obj_idx, defender.UID.obj_idx);
                        is_enemy_relation = !inSameServer;
                    }
                    else
                    {
                        is_enemy_relation = PostProcessEnemyRelation(attacker_pk_mode, attacker, defender, is_enemy_relation);
                        GameDebug.Log(string.Format("exception pk_mode {0}", attacker_pk_mode));
                    }

                    if (is_enemy_relation == false && tips_id.Length == 0)
                    {
                        bool is_friend = IsFriendRelation(attacker, defender);
                        if (is_friend)
                        {
                            tips_id = "SKILL_CANNT_ATTACK_FRIEND";
                        }
                        else
                            tips_id = "NO_DAMAGE_PK_MODE";
                    }
                }
            }
            else if (IsMonster(attacker.UID.obj_idx))
            {//怪物只攻击玩家
                if (defender.IsPlayer())
                {
                    if (attacker.Camp == 0 || defender.Camp == 0 || attacker.Camp != defender.Camp)
                        is_enemy_relation = true;
                    else
                        is_enemy_relation = false;
                }
                else
                    is_enemy_relation = false;
            }
            else
                return false;
            if (show_tips && tips_id.Length > 0)
            {
                ShowMessage(xc.DBConstText.GetText(tips_id));
                show_tips = false;
            }
            return is_enemy_relation;
        }

        //判断 B 是否是 A 的友方
        public bool IsFriendRelation(Actor attacker, Actor defender)
        {
            if (attacker == null || defender == null)
                return false;

            if (IsEqualActor(attacker, defender))
                return false;

            if (SceneHelp.Instance.UsePKMode == false)//场景限定不使用PK模式，只看camp
            {
                if (attacker.Camp == defender.Camp && attacker.Camp != 0)
                    return true;
                return false;
            }
            //string tips_id = string.Empty;
            bool is_friend_relation = false;
            if (attacker.IsPlayer())
            {
                if (defender.IsPlayer() == false) //玩家，非玩家；只有当阵营不为0，且相等时，才是友方
                {
                    if (attacker.Camp != 0 && attacker.Camp == defender.Camp)
                        is_friend_relation = true;
                    else
                        is_friend_relation = false;
                }
                else
                {
                    Player attacker_player = attacker as Player;
                    Player defender_player = defender as Player;
                    if (attacker_player == null || defender_player == null)
                        return false;

                    if (attacker.Camp == defender.Camp && attacker.Camp != 0) //同一阵营，总是队友
                        return true;

                    bool is_common_team = true;    //是否是同一个队伍
                    if (attacker_player.TeamId == 0 || defender_player.TeamId == 0 || attacker_player.TeamId != defender_player.TeamId)
                        is_common_team = false;
                    bool is_common_guild = true;    //是否是同一个帮派
                    if (attacker_player.GuildId == 0 || defender_player.GuildId == 0 || attacker_player.GuildId != defender_player.GuildId)
                        is_common_guild = false;

                    // 取消反击的逻辑
                    /*if (is_common_team == false && is_common_guild == false && attacker_player.IsAttackEmeny(defender_player)) //防御者之前攻击过attacker
                    {
                        return false;
                    }*/
                    
                    uint attacker_pk_mode = attacker_player.GetPKMode();
                    if (attacker_pk_mode == GameConst.PK_MODE_PEACE)
                    {
                        if (attacker.Camp != 0 && attacker.Camp == defender.Camp)
                            is_friend_relation = true;
                        else
                            is_friend_relation = false;
                    }
                    else if (attacker_pk_mode == GameConst.PK_MODE_FRIENDLY)//强制
                    {
                        if (is_common_team == true || is_common_guild == true)
                            is_friend_relation = true;
                        else
                            is_friend_relation = false;
                    }
                    else if (attacker_pk_mode == GameConst.PK_MODE_KILLER)//全体
                    {
                        is_friend_relation = false;
                    }
                    else if (attacker_pk_mode == GameConst.PK_MODE_DEFEND)//TODO:防卫
                    {
                        is_friend_relation = false;
                    }
                    else if(attacker_pk_mode == GameConst.PK_MODE_ATTACK)// 进攻模式
                    {
                        if (attacker.Camp == defender.Camp)
                            is_friend_relation = true;
                        else
                            is_friend_relation = false;
                    }
                    else if (attacker_pk_mode == GameConst.PK_MODE_SERVER)// 同服模式
                    {
                        var inSameServer = SpanServerManager.Instance.IsInSameServer(attacker.UID.obj_idx, defender.UID.obj_idx);
                        is_friend_relation = inSameServer;
                    }
                    else
                    {
                        is_friend_relation = PostProcessFriendRelation(attacker_pk_mode, attacker, defender, is_friend_relation);
                        GameDebug.Log(string.Format("exception pk_mode {0}", attacker_pk_mode));
                    }
                }
            }
            else if (IsMonster(attacker.UID.obj_idx))
            {//怪物只攻击玩家
                if(IsMonster(defender.UID.obj_idx))
                {//怪物和怪物都是友方
                    if(attacker.Camp == 0 || attacker.Camp == defender.Camp)
                        return true;
                    return false;
                }
                if (defender.IsPlayer())
                {
                    if (attacker.Camp != 0 && attacker.Camp == defender.Camp)
                        return true;
                    return true;
                }
                else
                    is_friend_relation = false;
            }
            else
                return false;
            return is_friend_relation;
        }

        bool PostProcessFriendRelation(uint attacker_pk_mode, Actor attacker, Actor defender, bool is_friend_relation)
        {
            return is_friend_relation;
        }

        bool PostProcessEnemyRelation(uint attacker_pk_mode, Actor attacker, Actor defender, bool is_enemy_relation)
        {
            return is_enemy_relation;
        }

        //判断本地玩家是否能攻击actor
        public bool IsLocalPlayerCanAttackActor(Actor actor, ref bool show_tips)
        {
            LocalPlayer localPlayer = (LocalPlayer)Game.GetInstance().GetLocalPlayer();
            return IsCanAttack(localPlayer, actor, ref show_tips);
        }

        //判断actor能否攻击本地玩家
        public bool IsActorCanAttackLocalPlayer(Actor actor, ref bool show_tips)
        {
            LocalPlayer localPlayer = (LocalPlayer)Game.GetInstance().GetLocalPlayer();
            return IsCanAttack(actor, localPlayer, ref show_tips);
        }

        UnityEngine.Profiling.CustomSampler sampler = UnityEngine.Profiling.CustomSampler.Create("IsEnemyRelation");

        private bool IsCanAttack(Actor attacker, Actor defender, ref bool show_tips)
        {
            if (attacker == null)
                return false;
            if (defender == null)
                return false;

            sampler.Begin();
            bool is_enemy = IsEnemyRelation(attacker, defender, ref show_tips);
            sampler.End();

            if (is_enemy == false)
            {
                if (show_tips)
                {
                    bool is_friend = IsFriendRelation(attacker, defender);
                    if (is_friend)
                    {
                        show_tips = false;
                        ShowMessage(xc.DBConstText.GetText("SKILL_CANNT_ATTACK_FRIEND"));
                    }
                }
                return false;
            }
            if (defender.CanBeHited() == false)
            {//defender不可以被攻击
                if (show_tips)
                {
                    if (defender.IsPlayer() && defender.BuffCtrl != null && defender.BuffCtrl.HasActive(m_gamePKReviveBuffId))
                    {
                        ShowMessage(xc.DBConstText.GetText("TRY_ATTACK_PLAYER_IN_REVIVE_BUFF"));
                    }
                    else
                    {//目标处于不可攻击状态
                        ShowMessage(xc.DBConstText.GetText("TRY_ATTACK_TARGET_IN_CANT_BE_HITED"));
                    }
                    show_tips = false;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 尝试提示被恶意攻击
        /// </summary>
        /// <param name="isPlayer"></param>
        /// <param name="obj_idx"></param>
        /// <param name="name"></param>
        public void TryShowHostileAttackTips(bool isPlayer, uint obj_idx, string name)
        {
            if (isPlayer == false)
                return;
            LocalPlayer localPlayer = (LocalPlayer)Game.GetInstance().GetLocalPlayer();
            if (localPlayer == null || localPlayer.NameColor != GameConst.NAME_COLOR_WHITE)
                return;
            if (InstanceManager.Instance.InstanceInfo == null)
                return;
            int scene_pk_type = InstanceManager.Instance.InstanceInfo.mPKType;
            //只有非安全场景的非特殊区域（如：PK和安全区域）才会显示提示
            if (scene_pk_type != GameConst.SCENE_PK_COMMON || IsInPKArea || IsInSafeArea)
            {
                return;
            }

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.EC_ACTOR_ADD_UNDER_ATTACK, new CEventBaseArgs(obj_idx));
            float last_show_time = 0;
            if(m_hostileAttackMap.TryGetValue(obj_idx, out last_show_time))
            {
                if (last_show_time + m_hostileAttackTipsInterval > Time.time)
                    return;
            }
            ShowMessage(string.Format(xc.DBConstText.GetText("LOCALPLAYER_BE_ATTACKED"), name));
            m_hostileAttackMap[obj_idx] = Time.time;
        }
       
        void OnLevelup(CEventBaseArgs args)
        {
            UpdatePKIcons();
        }

        void OnChangeGuildId(CEventBaseArgs args)
        {
            UpdatePKIcons();
        }
        public bool IsScenePKSafe(int scene_pk_type)
        {
            if (scene_pk_type == GameConst.SCENE_PK_SAFE || scene_pk_type == GameConst.SCENE_PK_PVE)
                return true;
            return false;
        }
    }
}