using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;
using Net;

// 玩家基类，保存玩家的各种属性
[wxb.Hotfix]
public class Player : Actor
{
    private static uint mExitBattleStateTime = 0;
    public static uint ExitBattleStateTime{
        get {
            if(mExitBattleStateTime == 0)
            {
                mExitBattleStateTime = xc.GameConstHelper.GetUint("GAME_BATTLE_STATE_TIME_CLIENT");
            }
            return mExitBattleStateTime;
        }
    }
    bool mShowPickUpBossChip = false;
    GameObject mPickUpBossChipObj = null;
    GameObject mPickUpBossChipObj_hand = null;
    public bool IsShowPickUpBossChip
    {
        get { return mShowPickUpBossChip; }
    }

    public virtual bool OpenPVPBlood
    {
        set
        {
            TextNameBehavior nameBehavoir = GetBehavior<TextNameBehavior>();
            UI3DText.StyleInfo info = nameBehavoir.DataStyleInfo;
            if (info == null)
                return;

            if (info.IsShowBar == value)
                return;

            SetShowBar(info, value);
            nameBehavoir.SetStyle(info);
        }
    }

    public void SetShowBar(UI3DText.StyleInfo info, bool is_show_bar)
    {
        info.IsShowBar = is_show_bar;

        if (this.IsLocalPlayer)
        {
            info.HpBarName = UI3DText.LocalPlayerHpName;
        }
        else
        {
            if (info.IsEnemyRelation == false)//队友
            {
                info.HpBarName = UI3DText.FriendHpName;
            }
            else
            {//敌人
                info.HpBarName = UI3DText.EnemyHpName;
            }
        }
    }

    public void RefreshPVPBlood()
    {

    }
    protected override bool AutoActiveTextName
    {
        get
        {
            if (InstanceManager.Instance.InstanceInfo != null && InstanceManager.Instance.InstanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_BATTLE_FIELD)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    protected uint mWeaponId = 0;
    
    public Player ()
	{
	}
	
    override public void Update()
	{
		base.Update();
    }

    override public void LateUpdate()
    {
        base.LateUpdate();

        if(CreatePetWhenVisible)
        {
            CreatePetWhenVisible = false;

            if (IsHidePet)
                return;

            if(CurrentPet != null)
                return;

            CreatePet();
        }
    }

    public override bool Kill ()
	{
		bool succ = base.Kill ();

        KillPet();

        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PLAYERDEAD, new CEventBaseArgs(UID));

        return succ;
	}
	
    public override bool Relive()
    {
        bool succ = base.Relive();

        RelivePet();

        return succ;
    }

    public override void Destroy()
    {
        base.Destroy();
        CreatePetWhenVisible = false;
        DestroyPet();

        DestroyEscortNPC();

        if (m_BattleTimer != null)
        {
            m_BattleTimer.Destroy();
            m_BattleTimer = null;
        }

        m_InBattleStatus = false;
        if(mShowPickUpBossChip)
            FinishPickUpEffect();
    }

    public override void OnResLoaded()
    {
        base.OnResLoaded();
    
        if (mRideCtrl != null && mRideCtrl.RemotePlayerUsingRideId != 0 && mRideCtrl.RemotePlayerServerStatusRiding)
        {
            mRideCtrl.Ride(mRideCtrl.RemotePlayerUsingRideId, false);
        }
        UpdatePKIconImpl(); //更新头顶PK值图标
        SetHeadIcons(EHeadIcon.TEAM);
        SetHeadIcons(EHeadIcon.PEAK);

        // 远程玩家的护送npc暂时屏蔽掉
        if (this.IsLocalPlayer)
        {
            UpdateEscortNPC();
        }
    }

    public override void AfterCreate()
    {
        base.AfterCreate();
        CreatePet();

#if UNITY_EDITOR
        gameObject.name = "Player_" + UID.obj_idx + "_" + ActorId;
#endif
    }

    public override bool IsPlayer()
    {
        return true;
    }
    /// <summary>
    /// 设置头顶的ICON
    /// </summary>
    public override void SetHeadIcons(EHeadIcon icon_type)
    {
        TextNameBehavior textNameBehavoir = GetBehavior<TextNameBehavior>();
        if (textNameBehavoir == null)
            return;

        textNameBehavoir.EnableBehaviors(mVisibleCtrl.VisibleMode == EVisibleMode.Visible/* && !IsDead()*/);

        if ((icon_type & EHeadIcon.TEAM) == EHeadIcon.TEAM)
        {
            string spriteName = "";
            bool isShow = false;
            if (TeamManager.Instance.IsLeader(UID.obj_idx) == true)
            {
                spriteName = "MainWindow_New@TeamWindow@LeaderTag";
                isShow = true;
            }
            else if (TeamManager.Instance.IsMember(UID.obj_idx) == true)
            {
                spriteName = "MainWindow_New@TeamWindow@MemberTag";
                isShow = true;
            }
            textNameBehavoir.ShowTeamIcon(spriteName, isShow);
        }
        else if ((icon_type & EHeadIcon.PEAK) == EHeadIcon.PEAK)
        {
            bool isPeak = TransferHelper.IsPeak((uint)Level, TransferLv);
            textNameBehavoir.ShowPeakTeamIcon(isPeak);
        }
    }

    /// <summary>
    /// 角色组件被添加到GameObject之后调用的函数
    /// </summary>
    protected override void InitAOIData(xc.UnitCacheInfo info)
    {
        base.InitAOIData(info);
        // 因为NPC继承自Player因此需要判断UnitType类型
        if (info.UnitType == EUnitType.UNITTYPE_PLAYER && info.AOIPlayer.pet_id != 0)
        {
            CachePetInfo(info.AOIPlayer.pet_id, 0);
        }
    }

    /// <summary>
    /// 当角色被显示出来后，需要创建宠物
    /// </summary>
    public bool CreatePetWhenVisible = false;

    #region PET
    /// <summary>
    /// 当前的宠物
    /// </summary>
    public UnitID CurrentPet
    { get; set; }

    protected UnitEnterAOI._Pet CurrentPetInfo = new UnitEnterAOI._Pet();

    /// <summary>
    /// 接收到AOI消息时，需要把宠物的相关参数保存下来
    /// </summary>
    protected virtual void CachePetInfo(uint pet_id, uint level)
    {
        CurrentPetInfo.pet_id = pet_id;
        //CurrentPetInfo.level = level;
        CurrentPetInfo.is_local = false;
    }

    /// <summary>
    /// 创建宠物
    /// </summary>
    /// <returns></returns>
    protected void CreatePet()
    {
        DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
        if (instanceInfo != null)
        {
            if (DBInstanceTypeControl.Instance.ForbidPet(instanceInfo.mWarType, instanceInfo.mWarSubType))
            {
                return;
            }
        }

        uint pet_id = CurrentPetInfo.pet_id;
        if (pet_id == 0)
            return;

        //uint level = CurrentPetInfo.level;

        //通过宠物ID查找角色ID
        DBPet pet_csv = DBManager.GetInstance().GetDB<DBPet>();
        DBPet.PetInfo pet = pet_csv.GetOnePetInfo(pet_id);
        if (pet != null)
        {
            uint actorId = pet.Actor_id;
            CurrentPet = ActorManager.Instance.CreatePet(pet_id, actorId, this.transform.position, this.transform.rotation, this);
        }
    }

    public virtual void UpdatePetId(uint new_pet_id)
    {
        if (CurrentPetInfo.pet_id == new_pet_id)
            return;
        DestroyPet();
        CurrentPetInfo.pet_id = new_pet_id;
        if (this.gameObject == null)
            return;
        CreatePet();
    }

    protected bool IsHidePet
    {
        get
        {
            if (mVisibleCtrl.IsVisible == false && this is RemotePlayer)
                return true;
            else
                return false;
        }
    }
    /// <summary>
    /// 杀死宠物
    /// </summary>
    protected void KillPet()
    {
        if(CurrentPet == null)
            return;
        
        Actor pet = ActorManager.Instance.GetActor(CurrentPet);
        if (pet != null)
        {
            pet.BeattackedCtrl.KillSelf();
        }
    }

    /// <summary>
    /// 复活宠物
    /// </summary>
    protected void RelivePet()
    {
        if(CurrentPet == null)
            return;

        Actor pet = ActorManager.Instance.GetActor(CurrentPet);
        if (pet != null)
        {
            pet.Relive();
        }
    }

    public UnitID CurrentEscortNPC { get; set; }

    /// <summary>
    /// 更新护送NPC 
    /// </summary>
    public void UpdateEscortNPC()
    {
        int escortNpcId = 0;
        if (EscortId > 0)
        {
            TaskDefine escortTaskDefine = TaskDefine.MakeDefine(EscortId);
            if (escortTaskDefine != null && escortTaskDefine.FollowNpcs != null && escortTaskDefine.FollowNpcs.Count > 0)
            {
                escortNpcId = (int)escortTaskDefine.FollowNpcs[0].NpcId;
            }
        }

        // 删除旧的护送NPC
        DestroyEscortNPC();

        if (escortNpcId > 0)
        {
            CurrentEscortNPC = NpcManager.Instance.CreateNPC(escortNpcId, this);
        }
    }

    public Actor GetEscortNPC()
    {
        if (CurrentEscortNPC != null)
        {
            return ActorManager.Instance.GetActor(CurrentEscortNPC);
        }

        return null;
    }

    /// <summary>
    /// 删除护送NPC
    /// </summary>
    protected void DestroyEscortNPC()
    {
        if (CurrentEscortNPC == null)
            return;

        if (ActorManager.Instance.GetActor(CurrentEscortNPC) != null)
        {
            ActorManager.Instance.DestroyActor(CurrentEscortNPC, 0.0f);
            CurrentEscortNPC = null;
        }
        else
        {
            bool succ = ActorManager.Instance.RemoveUnitCacheData(
                (info) =>
                {
                    return info.UnitID.Equals(CurrentEscortNPC);
                    //&& info.CacheType == xc.UnitCacheInfo.EType.ET_Create;
                });

            if (succ)
            {
                CurrentEscortNPC = null;
            }
            else
                Debug.LogError("Remove escort npc failed, UID: " + CurrentEscortNPC.obj_idx);
        }
    }

    public override void OnBecomeVisible(bool bVisible)
    {

        if (CurrentPet != null)
        {
            Actor pet = ActorManager.Instance.GetActor(CurrentPet);
            if(pet != null)
            {
                pet.mVisibleCtrl.SetActorVisible(bVisible, VisiblePriority.NORMAL);
            }
            // 角色显示时，如果此时宠物还未创建，需要标记变量进行延迟创建
            else if(IsResLoaded && bVisible)
            {
                CreatePetWhenVisible = true;
            }
        }
        else
        {
            if(IsResLoaded && bVisible)
            {
               CreatePetWhenVisible = true;
            }
        }
    }

    public override void OnBecomeNameVisible()
    {
        if (CurrentPet != null)
        {
            Actor pet = ActorManager.Instance.GetActor(CurrentPet);
            if(pet != null)
            {
                pet.mVisibleCtrl.SetActorVisible(false, VisiblePriority.NORMAL);
            }
        }

        CreatePetWhenVisible = false;
    }

    /// <summary>
    /// 删除宠物
    /// </summary>
    protected void DestroyPet()
    {
        if(CurrentPet == null)
            return;

        if (ActorManager.Instance.GetActor(CurrentPet) != null)
        {
            ActorManager.Instance.DestroyActor(CurrentPet, 0.0f);
            CurrentPet = null;
        }
        else
        {
            bool succ = ActorManager.Instance.RemoveUnitCacheData(
                (info) => {return info.UnitID.Equals(CurrentPet);
                //&& info.CacheType == xc.UnitCacheInfo.EType.ET_Create;
            });

            if(succ)
            {
                CurrentPet = null;
            }
            else
                Debug.LogError("Remove pet failed, Pet UID: " + CurrentPet.obj_idx);
        }
    }

    /// <summary>
    /// 获取宠物
    /// </summary>
    /// <returns></returns>
    public Pet GetPet()
    {
        if(CurrentPet == null)
        {
            return null;
        }
        
        return ActorManager.Instance.GetActor(CurrentPet) as Pet;
    }
    #endregion PET

    /// <summary>
    /// 玩家受击
    /// </summary>
    public override void Beattacked(Damage dam)
    {
        base.Beattacked(dam);

        var src_actor = dam.src;
        if (src_actor == null)
            return;

        if (dam != null && src_actor != null && src_actor.IsDestroy == false)
        {
            if (src_actor.IsLocalPlayer && this.IsLocalPlayer == false)//攻击者是主角，主角也进入PVP状态
            {
                PKModeManagerEx.Instance.IsPVPBattleState = true;
            }
        }
        OnBattleTrigger();
    }

    Utils.Timer m_BattleTimer = null;

    public override void OnBattleTrigger()
    {
        base.OnBattleTrigger();

        if (m_BattleTimer != null && !m_BattleTimer.IsDead)
        {
            m_BattleTimer.Reset(ExitBattleStateTime);
        }
        else
        {
            m_BattleTimer = new Utils.Timer(ExitBattleStateTime, false, 1000.0f, OnBattleTimeOut);
        }

        InBattleStatus = true;
    }

    public virtual void OnBattleTimeOut(float remain)
    {
        if (remain <= 0)
            InBattleStatus = false;
    }

    public override void InitBehaviors()
    {
        AddBehavior(new PKModeBehavior(this));

        base.InitBehaviors();
    }

    public PKModeBehavior GetPKModeBehavior()
    {
        return GetBehavior<PKModeBehavior>();
    }

    public void UpdatePKMode(ulong mBitStates)
    {
        PKModeBehavior behavior = GetPKModeBehavior();
        if (behavior != null)
            behavior.UpdatePKMode(mBitStates);
    }

    public void SetPKMode(uint new_pk_mode)
    {
        PKModeBehavior behavior = GetPKModeBehavior();
        if (behavior != null)
            behavior.SetPKMode(new_pk_mode);
    }

    public uint GetPKMode()
    {
        PKModeBehavior behavior = GetPKModeBehavior();
        if (behavior != null)
            return behavior.PkModeType;
        else
            return GameConst.PK_MODE_PEACE;
    }

    public override bool CanBeChoosed()
    {
        return true;
    }

    public void UpdatePetAttackSpeed()
    {
        if (CurrentPet == null || CurrentPetInfo.pet_id == 0)
            return;
        Actor pet = ActorManager.Instance.GetActor(CurrentPet);
        if (pet != null && pet is Pet)
        {
            (pet as Pet).UpdateBattleAttribute();
        }
    }

    public void UpdatePetMoveSpeed()
    {
        if (CurrentPet == null || CurrentPetInfo.pet_id == 0)
            return;
        Actor pet = ActorManager.Instance.GetActor(CurrentPet);
        if (pet != null && pet is Pet)
        {
            (pet as Pet).UpdateBattleAttribute();
        }
    }

    public void UpdateEscortNPCMoveSpeed()
    {
        if (CurrentEscortNPC == null)
            return;
        Actor escortNPC = ActorManager.Instance.GetActor(CurrentEscortNPC);
        if (escortNPC != null && escortNPC is NpcPlayer)
        {
            (escortNPC as NpcPlayer).UpdateBattleAttribute();
        }
    }

    public void UpdatePVPBlood()
    {
        ActorAttributeData localActorAttribute = LocalPlayerManager.Instance.LocalActorAttribute;

        if (localActorAttribute != null && mUintID.obj_idx == localActorAttribute.UnitId.obj_idx)
        {//主角的头顶血条更新
            if (this.IsLocalPlayer)
            {
                (this as LocalPlayer).RefreshPlayerHpBar();
            }
            return;
        }

        if (localActorAttribute == null || mUintID.obj_idx == localActorAttribute.UnitId.obj_idx)
            return;

        SetNameStyle();
    }

    public virtual void StartPickUpBossChipEffect(Vector3 drop_dest_world_pos)
    {
        if (IsDestroy)
            return;
        if (mShowPickUpBossChip)
            return;
        if (this.GetModelParent() == null)
            return;
        if (this.transform == null)
            return;
        GameDebug.LogRed("StartPickUpBossChipEffect");
        Vector3 forward_v = drop_dest_world_pos - this.transform.position;
        Vector3 v = forward_v.normalized;
        v.y = 0;
        this.GetModelParent().transform.forward = v;
        BeginInteraction("action_3");
        mShowPickUpBossChip = true;
        EffectManager.GetInstance().GetEffectEmitter("Effects/Prefabs/Skill/BOSS_skill/EF_boss_hunpo_guiji_2.prefab").CreateInstance(x => OnBossChipEffectResLoad(x, this.transform.position, drop_dest_world_pos));
        EffectManager.GetInstance().GetEffectEmitter("Effects/Prefabs/Skill/BOSS_skill/Ani_BOSS_shiqu.prefab").CreateInstance(x => OnBossChipEffectResLoad_hand(x, this.transform.position, drop_dest_world_pos));
    }

    /// <summary>
    /// BOSS碎片特效加载完毕后的回调
    /// </summary>
    /// <param name="effect_object"></param>
    /// <param name="parent_trans"></param>
    /// <param name="bind_node"></param>
    void OnBossChipEffectResLoad(GameObject effect_object, Vector3 start_position, Vector3 end_position)
    {
        if (effect_object != null)
        {
            if(mShowPickUpBossChip == false || IsDestroy)
            {
                GameObject.DestroyObject(effect_object);
                return;
            }
            mPickUpBossChipObj = effect_object;
            Transform selectTrans = effect_object.transform;
            start_position = start_position + new Vector3(0, Height / 2.0f, 0);

            selectTrans.parent = null;
            selectTrans.position = start_position;

            Vector3 v = end_position - start_position;
            float real_dist = v.magnitude;
            float scale = real_dist / 10.0f;
            selectTrans.localScale = Vector3.one * scale;
            
            selectTrans.forward = v.normalized;
            effect_object.SetActive(true);

            var delay_destroy = effect_object.GetComponent<DelayDestroyComponent>();
            if(delay_destroy == null)
                delay_destroy = effect_object.AddComponent<DelayDestroyComponent>();

            delay_destroy.DelayTime = 10.0f;
            delay_destroy.Start();

            xc.ui.ugui.UIHelper.SetLayer(effect_object.transform, LayerMask.NameToLayer("Player"));
        }
    }

    /// <summary>
    /// BOSS碎片特效加载完毕后的回调(手上特效)
    /// </summary>
    /// <param name="effect_object"></param>
    /// <param name="parent_trans"></param>
    /// <param name="bind_node"></param>
    void OnBossChipEffectResLoad_hand(GameObject effect_object, Vector3 start_position, Vector3 end_position)
    {
        if (effect_object != null)
        {
            if (mShowPickUpBossChip == false || IsDestroy)
            {
                GameObject.DestroyObject(effect_object);
                return;
            }
            VocationInfo vocation_info = DBVocationInfo.Instance.GetVocationInfo((uint)this.VocationID);
            string slot_name = AvatarCtrl.BOSS_CHIP_HAND_NAME;
            if (vocation_info != null && string.IsNullOrEmpty(vocation_info.boss_chip_slot_name) == false)
                slot_name = vocation_info.boss_chip_slot_name;
            Transform hand_root_transform = xc.ui.ugui.UIHelper.FindChildInHierarchy(transform, slot_name);
            if(hand_root_transform != null)
            {
                effect_object.transform.parent = hand_root_transform;
                effect_object.transform.localPosition = Vector3.zero;
                effect_object.transform.localEulerAngles = Vector3.zero;
                effect_object.transform.localScale = Vector3.one;
            }
            mPickUpBossChipObj_hand = effect_object;
            effect_object.SetActive(true);

            var delay_destroy = effect_object.GetComponent<DelayDestroyComponent>();
            if(delay_destroy == null)
                delay_destroy = effect_object.AddComponent<DelayDestroyComponent>();

            delay_destroy.DelayTime = 10.0f;
            delay_destroy.Start();

            xc.ui.ugui.UIHelper.SetLayer(effect_object.transform, LayerMask.NameToLayer("Player"));
        }
    }
    public virtual void FinishPickUpEffect()
    {
        //GameDebug.LogError("FinishPickUpEffect");
        mShowPickUpBossChip = false;
        if(mPickUpBossChipObj != null && mPickUpBossChipObj.transform != null)
        {
            GameObject.DestroyObject(mPickUpBossChipObj);
        }
        if(mPickUpBossChipObj_hand != null && mPickUpBossChipObj_hand.transform != null)
        {
            GameObject.DestroyObject(mPickUpBossChipObj_hand);
        }
        mPickUpBossChipObj = null;
        mPickUpBossChipObj_hand = null;
        if (this.ActorMachine != null && this.ActorMachine.IsInInteraction == true)
            this.Stand();
    }
}

