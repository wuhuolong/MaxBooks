using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;

using SGameEngine;


/// <summary>
/// 本地玩家
/// </summary>
[wxb.Hotfix]
public class LocalPlayer : Player
{
    private float m_prepearSelectTotalTime = 0;
    private float m_PrepearAutoSelectInterval = 3.0f;   //时间间隔（秒）
    private float m_PrepearAutoSelectSearchRadius = 10;   //搜索范围（米）
    private float m_PrepearAutoSelectMoveMaxDist = 5;   //触发预选的最大移动距离（米）
    private Vector3 m_lastPrepearPos = Vector3.zero;    //上次预选的位置


    public LocalPlayer()
    {
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE, OnLevelUp);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_PET_MAIN_CHANGED_IN_SCENE, UpdateScenePetId);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_LOCAL_PLAYER_ADD_ENEMY, AddOneEnemy);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_MOUNT_LOCAL_PLAYER_CHANGED_ID_IN_SCENE, RefreshMountId);
    }

    ~LocalPlayer()
    {
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE, OnLevelUp);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_PET_MAIN_CHANGED_IN_SCENE, UpdateScenePetId);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_LOCAL_PLAYER_ADD_ENEMY, AddOneEnemy);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_MOUNT_LOCAL_PLAYER_CHANGED_ID_IN_SCENE, RefreshMountId);
    }

    protected override void InitCtrl()
    {
        base.InitCtrl();

        m_PrepearAutoSelectInterval = GameConstHelper.GetFloat("GAME_BF_PREPEAR_AUTO_SELECT_INTERVAL");
        m_PrepearAutoSelectSearchRadius = GameConstHelper.GetFloat("GAME_BF_PREPEAR_AUTO_SELECT_SEARCH_RADIUS");
        m_PrepearAutoSelectMoveMaxDist = GameConstHelper.GetFloat("GAME_BF_PREPEAR_AUTO_SELECT_MOVE_MAX_DIST");
        mVisibleCtrl.SetActorVisible(true, VisiblePriority.NORMAL);

        // attackctrl
        AttackCtrl.mIsSendMsg = true;
        AttackCtrl.mIsRecvMsg = false;
        AttackCtrl.mIsProcessInput = true;

        // beattackctrl
        BeattackedCtrl.mIsSendMsg = true;
        BeattackedCtrl.mIsRecvMsg = true;

        // movectrl
        MoveCtrl.mIsProcessInput = true;
        MoveCtrl.mIsRecvMsg = false;
        MoveCtrl.mIsSendMsg = true;
    }

    public override bool IsLocalPlayer
    {
        get
        {
            return true;
        }
    }

    Transform mTrans = null;
    bool mIsLoadRelive = false;

    public override bool Relive()
    {
        ResourceLoader.Instance.StartCoroutine(LoadReliveEffect());
        return base.Relive();
    }

    /// <summary>
    /// 加载复活的特效
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadReliveEffect()
    {
        if (mIsLoadRelive)
            yield break;

        mIsLoadRelive = true;
        ResourceLoader.Instance.StartCoroutine(LoadEffect("Assets/" + ResPath.ReliveEffect1, relive_cache_path, GlobalConst.ReliveEffectLink));
        yield return ResourceLoader.Instance.StartCoroutine(LoadEffect("Assets/" + ResPath.ReliveEffect2, relive_cache_path2, ""));
        yield return new WaitForSeconds(2.0f);// 因为未等待第一个特效加载完毕，此处等待2s
        mIsLoadRelive = false;
    }

    /// <summary>
    /// 复活特效加载完毕后的回调
    /// </summary>
    /// <param name="effect_object"></param>
    /// <param name="parent_trans"></param>
    /// <param name="bind_node"></param>
    bool OnEffectResLoad(GameObject effect_object, string bind_node)
    {
        if (mIsDestroy || this.transform == null)
            return false;

        Transform parent_trans = transform;
        Transform effect_trans = effect_object.transform;
        if (string.IsNullOrEmpty(bind_node))
        {
            effect_trans.parent = parent_trans;
        }
        else
        {
            Transform link_node = CommonTool.FindChildInHierarchy(parent_trans, bind_node);
            if (link_node != null)
                effect_trans.parent = link_node;
            else
                effect_trans.parent = parent_trans;
        }

        effect_trans.localPosition = new Vector3(0, 0.1f, 0);
        effect_trans.localRotation = Quaternion.identity;
        effect_object.SetActive(true);

        return true;
    }

    override public void Update()
	{
        if(mTrans == null)
            mTrans = transform;

        bool need_trigger_autoFindTarget = false;
        if (AttackCtrl != null && AttackCtrl.CurSelectActor == null)
        {
            Skill cur_skill = GetCurSkill();
            if (cur_skill != null && cur_skill.IsInBeforeSkillActionEndingStage())
                need_trigger_autoFindTarget = false;
            else
                need_trigger_autoFindTarget = true;
        }
        else if(InBattleStatus == false && InstanceManager.Instance.IsAutoFighting == false)
        {
            m_prepearSelectTotalTime += Time.deltaTime;
            
            if((m_lastPrepearPos - mTrans.position).magnitude >= m_PrepearAutoSelectMoveMaxDist)
            {
                need_trigger_autoFindTarget = true;
            }
            if (m_prepearSelectTotalTime > m_PrepearAutoSelectInterval)
            {
                need_trigger_autoFindTarget = true;
            }
        }
        else
            m_prepearSelectTotalTime = 0;
        if (AttackCtrl != null && need_trigger_autoFindTarget)
        {
            m_lastPrepearPos = mTrans.position;
            m_prepearSelectTotalTime = 0;
            AttackCtrl.AutoFindTarget(m_PrepearAutoSelectSearchRadius);
        }
        PKModeManagerEx.Instance.UpdatePVPBattleState();
        PKModeManagerEx.Instance.UpdateEnemyList();
        base.Update();
// 
//         if (mEnemyList != null)
//         {
//             m_cur_has_enemy = mEnemyList.HasEnemy();
//             if (m_pre_has_enemy != m_cur_has_enemy)
//             {
//                 TextNameBehavior nameBehavoir = GetBehavior<TextNameBehavior>();
//                 if (nameBehavoir != null)
//                 {
//                     UI3DText.StyleInfo info = nameBehavoir.DataStyleInfo;
//                     if (info != null)
//                     {
//                         m_pre_has_enemy = m_cur_has_enemy;
//                         info.IsShowBar = m_pre_has_enemy;
//                     }
//                 }
//             }
//         }
    }

    protected override void InitAOIData(UnitCacheInfo info)
    {
        base.InitAOIData(info);

        Game mGame = Game.GetInstance();
        mGame.SetLocalPlayer(this);
        mGame.LocalPlayerAOIInfo = info.AOIPlayer;

        ActorManager.Instance.PlayerSet.Add(mGame.LocalPlayerID, this);
        SkillManager.GetInstance().InitSkillOwner(this);
    }
	
    public override void OnResLoaded ()
	{
		base.OnResLoaded ();
        if (mRideCtrl.RemotePlayerShouldRiding())
        {
            mRideCtrl.Ride(mRideCtrl.RemotePlayerUsingRideId, true);
        }

        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCALPLAYER_CREATED, new CEventActorArgs(this));
        //FashionManager.Instance.OnLocalPlayerResLoaded();

        // Reload AI 假如说在跨入场景的时候就立即启用AI，此时Actor资源还未加载完成，于是AI保存的ActorMono是一个临时的值，此时会变成null，于是这里需要重新reload AI
        if(GetAIEnable())
        {
            ActiveAI(true);
        }
        Game.Instance.LocalPlayerRadius = Radius;

        if (InstanceManager.Instance.IsAutoFighting == true)
        {
            ActiveAI(true);
        }
    }

    public override void AfterCreate()
    {
        // 在base.AfterCreate中，有使用本地玩家的属性，因此需要先赋值
        if (null != LocalPlayerManager.Instance.LocalActorAttribute)
        {
            // 使用SetActorAttriBute接口在单人副本中赋值时，hp和mp没有赋值
            // 只有当SetPlayerInfoByConfig接口调用后，血量才赋值成功
            LocalPlayerManager.Instance.LocalActorAttribute.Camp = Camp;
            LocalPlayerManager.Instance.LocalActorAttribute.GuildName = GuildName;
            LocalPlayerManager.Instance.LocalActorAttribute.EscortId = EscortId;
            LocalPlayerManager.Instance.LocalActorAttribute.TransferLv = TransferLv;

            SetActorAttribute(LocalPlayerManager.Instance.LocalActorAttribute);
        }

        base.AfterCreate();

        gameObject.name = "LocalPlayer_" + UID.obj_idx + "_" + ActorId;

        if (Game.Instance.CameraControl != null)
            Game.Instance.CameraControl.Target = transform;

        SkillManager.GetInstance().InitSkillOwner(this as LocalPlayer);
    }

    public override void OnModelChanged()
    {
        base.OnModelChanged();

        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_LOCALPLAYER_MODEL_CHANGE, new CEventActorArgs(this));
    }

    protected override string GetColorName(string name)
    {
        ActorHelper.GetPKColorName(PKModeManagerEx.Instance.LocalPlayerNameColor, ref name, true);

        return name;
    }
	
	public override void ActiveAI(bool active)
	{
		if (active)
		{
            if (mAI == null)
            {
                BehaviourPlayerAI playerAI = new BehaviourPlayerAI(this);
                playerAI.Init();
                SetAI(playerAI);
            }
            else
            {
                mAI.Enabled = true;
            }
        }
		else
		{
			if (mAI != null)
            {
                mAI.Enabled = false;
            }
        }
	}

    #region PET
    /// <summary>
    /// 主宠发生变化
    /// </summary>
    /// <param name="args"></param>
    protected void OnPetMainChanged(CEventBaseArgs args)
    {
        UpdatePetActor();
    }

    /// <summary>
    /// 宠物等级发生变化
    /// </summary>
    /// <param name="args"></param>
    protected void OnPetLevelChanged(CEventBaseArgs args)
    {
        if (CurrentPet != null)
        {
            Pet pet = ActorManager.Instance.GetActor(CurrentPet) as Pet;
            if(pet != null)
            {
                //pet.PetLevel = LocalPlayerManager.Instance.MainPetLevel;
                pet.UpdateBattleAttribute();
            }
        }
    }

    /// <summary>
    /// 更新宠物
    /// </summary>
    public void UpdatePetActor()
    {
        CachePetInfo(0,0);

        if (CurrentPet != null)
        {
            DestroyPet();
        }

        CreatePet();
    }
    #endregion PET

	public override void Destroy ()
	{
		base.Destroy ();
        LocalPlayerManager.Instance.InBallteStatus = false;
        PKModeManagerEx.Instance.IsPVPBattleState = false;
        TargetPathManager.Instance.TaskNavigationActive(false);
    }
	
	public new AI GetAI()
	{
		return mAI;
	}

    /// <summary>
    /// 与actor是好友还是敌人
    /// </summary>
    public bool IsFriendOrEnermy(Actor actor)
    {
        if (actor == this)
        {
            //self
            return true;
        }
        else if (actor is Monster)
        {
            //my summon monster
            Monster monster = actor as Monster;
            if (monster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_PLAYER && monster.ParentActor!= null)
            {
                if (monster.ParentActor == this || monster.ParentActor.Camp == this.Camp)
                {
                    return true;
                }
            }
        }
        else if (actor is RemotePlayer)
        {
           ///TODO
        }
   
        return false;
    }

    protected override void CachePetInfo(uint pet_id, uint level)
    {
        CurrentPetInfo.pet_id = LocalPlayerManager.Instance.MainPetID;
        //CurrentPetInfo.level = LocalPlayerManager.Instance.MainPetLevel;
        CurrentPetInfo.is_local = true;
    }

    public static uint NowCamp
    {
        get
        {
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if(localPlayer != null)
            {
                return localPlayer.Camp;
            }
            else
                return 0xffffffff;
        }
    }

    public override uint TeamId
    {
        get { return TeamManager.Instance.TeamId; }
    }

    /// <summary>
    /// 当对其他玩家造成伤害或者其他玩家攻击自己时，触发进入战斗状态的逻辑
    /// </summary>
    public override void OnBattleTrigger()
    {
        base.OnBattleTrigger();

        LocalPlayerManager.Instance.InBallteStatus = true;
    }

    public override void OnBattleTimeOut(float remain)
    {
        if(remain <= 0)
        {
            InBattleStatus = false;
            LocalPlayerManager.Instance.InBallteStatus = false;
        }
    }

    public float PrepearAutoSelectSearchRadius
    {
        get { return m_PrepearAutoSelectSearchRadius; }
    }

    bool mIsLoadLevelup = false;

    void OnLevelUp(CEventBaseArgs data)
    {
        ResourceLoader.Instance.StartCoroutine(LoadLevelUpEffect());
    }

    IEnumerator LoadLevelUpEffect()
    {
        if (mIsLoadLevelup)
            yield break;

        mIsLoadLevelup = true;
        yield return ResourceLoader.Instance.StartCoroutine(LoadEffect("Assets/" + ResPath.EFFECT_LEVELUP2, lv_up_cache_path, ""));
        mIsLoadLevelup = false;
    }

    string lv_up_cache_path = "levle_up_effect";
    string relive_cache_path = "levle_up_effect";
    string relive_cache_path2 = "levle_up_effect2";

    /// <summary>
    /// 加载指定路径下的特效资源
    /// </summary>
    /// <param name="effect_path"></param>
    /// <param name="effect_cache_path"></param>
    /// <param name="bind_node"></param>
    /// <returns></returns>
    IEnumerator LoadEffect(string effect_path, string effect_cache_path, string bind_node)
    {
        GameObject go = ObjCachePoolMgr.Instance.LoadFromCache(ObjCachePoolType.SFX, effect_cache_path) as GameObject;
        if (go == null)
        {
            PrefabResource ar_prefab = new PrefabResource();
            yield return ResourceLoader.Instance.load_prefab(effect_path, ar_prefab);
            if (ar_prefab.obj_ == null)
                yield break;

            go = ar_prefab.obj_;

            //将加载的gameobject放入内存池中
            PoolGameObject pg = go.AddComponent<PoolGameObject>();
            pg.poolType = ObjCachePoolType.SFX;
            pg.key = effect_cache_path;
            GameObject.DontDestroyOnLoad(go);
        }

        var succ = OnEffectResLoad(go, bind_node);
        if (!succ)
        {
            ObjCachePoolMgr.Instance.RecyclePrefab(go, ObjCachePoolType.SFX, effect_path);
        }
        else
        {
            // 等待2s之后将特效放回内存池中
            yield return new WaitForSeconds(2.0f);
            ObjCachePoolMgr.Instance.RecyclePrefab(go, ObjCachePoolType.SFX, effect_path);
        }
    }

    void UpdateScenePetId(CEventBaseArgs data)
    {
        UpdatePetId(LocalPlayerManager.Instance.MainPetID);
    }

    /// <summary>
    /// 是否可以被选中
    /// </summary>
    public override bool CanBeChoosed()
    {
        return false;
    }

    public void RefreshPlayerHpBar()
    {
        TextNameBehavior nameBehavoir = GetBehavior<TextNameBehavior>();
        if (nameBehavoir == null)
            return;
        UI3DText.StyleInfo info = nameBehavoir.DataStyleInfo;
        if (info == null)
            return;

        // 和平模式(且没有锁定的攻击敌人)，不显示血条，破碎死域副本内要总是显示血条
        if (PKModeManagerEx.Instance.CanShowPVPBlood(this) == false && SceneHelp.Instance.ForceShowHpBar == false)
        {
            SetShowBar(info, false);
        }
        else
        {
            SetShowBar(info, true);
        }

        nameBehavoir.RefreshStyle();
    }

    public void AddOneEnemy(CEventBaseArgs data)
    {
        if (data == null || data.arg == null)
            return;
        
        UnitID uid = data.arg as UnitID;
        PKModeManagerEx.Instance.AddOneEnemy(uid);
    }

    void RefreshMountId(CEventBaseArgs data)
    {
        this.MountId = LocalPlayerManager.Instance.MountId;
//         uint new_mount_id = LocalPlayerManager.Instance.MountId;
//         if (mRideCtrl != null && mRideCtrl.RemotePlayerUsingRideId != new_mount_id)
//             mRideCtrl.RemotePlayerUsingRideId = new_mount_id;
//         if(mRideCtrl != null)
//             mRideCtrl.RemotePlayerServerStatusRiding = true;
    }

    public override void Beattacked(Damage dam)
    {
        base.Beattacked(dam);
        var src_actor = dam.src;
        if(dam != null && src_actor != null && src_actor.IsDestroy == false)
        {
            if (src_actor.IsPlayer())
            {
                PKModeManagerEx.Instance.IsPVPBattleState = true;
            }
        }
        
    }
}

