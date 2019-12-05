using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;
using Net;
using xc.protocol;

// 怪物类
[wxb.Hotfix]
public class Monster : Actor
{
    public enum QualityColor : byte// 怪物品质的颜色
    {
        COMMON = (byte)GameConst.MON_COLOR_COMMON,  // 普通
        ELITE = (byte)GameConst.MON_COLOR_ELITE,    // 精英
        BOSS = (byte)GameConst.MON_COLOR_BOSS,      // BOSS
    }

    public class CreateParam
    {
        public bool is_pet = false; // 是否是宠物
        public bool summon = false; // 是否是召唤怪
        public UnitID master = null;
        public float time = 0;
        public Monster.MonsterType summonType;
        public bool hasAI = false;
        public bool summonByMonster = false;
    }

	private MonsterType mMonsterType;
    private MonsterSpawnType mMonsterSpawnType;

    QualityColor mColor = QualityColor.COMMON; // 品质
    Vector3 mCenterSpawnPos;

    public enum BeSummonType : byte
    {
        NULL,
        BE_SUMMON_BY_MONSTER, // 由怪物召唤出来的
        BE_SUMMON_BY_PLAYER, // 由本地玩家召唤出来的
        BE_SUMMON_BY_ROBOT // 由其他玩家召唤出来的
    }
    /// <summary>
    /// 是否是被召唤出来的怪物（被玩家或者被boss怪物）
    /// </summary>
    public BeSummonType BeSummonedType = BeSummonType.NULL;

    List<uint> mSkillIds;

    Utils.Timer mShowHPProgressBarTimer = null;

    private bool mAlwaysShowHpBar = false;
    public bool AlwaysShowHpBar
    {
        get
        {
            return mAlwaysShowHpBar;
        }
        set
        {
            mAlwaysShowHpBar = value;
            HPProgressBarIsActive = value;
        }
    }
	
	public Monster ()
	{
		mMonsterType = MonsterType.None;
        mMonsterSpawnType = MonsterSpawnType.ST_Normal;
	}
	
    protected override void InitCtrl ()
	{
        base.InitCtrl();
		AttackCtrl.mIsSendMsg 			= false;
		AttackCtrl.mIsRecvMsg			= false;
		AttackCtrl.mIsProcessInput		= false;
								
		BeattackedCtrl.mIsSendMsg		= false;
		BeattackedCtrl.mIsRecvMsg		= false;
				
		MoveCtrl.mIsProcessInput = false;
		MoveCtrl.mIsSendMsg = false;
		MoveCtrl.mIsRecvMsg = false;
	}

    protected override void InitAOIData(xc.UnitCacheInfo info)
    {
        base.InitAOIData(info);

        if (ActorManager.Instance.MonsterSet.ContainsKey(info.UnitID) == false)
        {
            if (!(this is Pet))
            {
                ActorManager.Instance.MonsterSet.Add(info.UnitID, this);
            }
            else
                ActorManager.Instance.PetSet.Add(info.UnitID, this);
        }
        else
        {
            GameDebug.LogError("MonsterSet has conflict key " + info.UnitID.obj_idx);
        }
    }

    /// <summary>
    /// 在创建怪物后的处理
    /// </summary>
    private void OnCreateSummonMonster(xc.UnitCacheInfo info, CreateParam param)
    {
        Actor master = ActorManager.Instance.GetActor(param.master);
        if (param.summonByMonster)
        {
            BeSummonedType = Monster.BeSummonType.BE_SUMMON_BY_MONSTER;
        }
        else
        {
            if (master is LocalPlayer)
            {
                BeSummonedType = Monster.BeSummonType.BE_SUMMON_BY_PLAYER;
            }
            else
            {
                BeSummonedType = Monster.BeSummonType.BE_SUMMON_BY_ROBOT;
            }
        }
        
        // 初始化怪物的各种数据
        if(master != null)
            Camp = master.Camp;
        else
            Camp = info.AOIMonster.camp;

        SetMonsterType(param.summonType);
        if (param.summonType == Monster.MonsterType.SummonRemoteMonster)
        {
            ActiveAI(false);
        }
        else
        {
            ActiveAI(true);
        }

        if (param.summonByMonster)
        {
            CenterSpawnPos = info.PosBorn;
        }

        if(BeSummonedType == BeSummonType.BE_SUMMON_BY_MONSTER)
        {
            if(!ActorManager.Instance.CalledMonsterSet.ContainsKey(info.UnitID))
            {
                ActorManager.Instance.CalledMonsterSet.Add(info.UnitID, this);
            }
        }
        else if(this is Pet)
        {

        }
        else
        {
            if(!ActorManager.Instance.SummonMonsterSet.ContainsKey(info.UnitID))
            {
                ActorManager.Instance.SummonMonsterSet.Add(info.UnitID, this);
            }
        }
        
        if (param.summonType == Monster.MonsterType.LocalMonster)
        {
            // 定时销毁召唤怪
            /*DelayTimeComponent delayTime = GetModel().AddComponent<DelayTimeComponent>();
            delayTime.DelayTime = param.time;
            delayTime.SetEndCallBack(new DelayDestroyComponent.EndCallBackInfo(OnSummonMonsterDisappear, info.UnitID));
            if(!param.summonByMonster)
                // 显示血条
                HPProgressBarIsActive = true;*/
        }
        
        // 设置sonActor
        if (master != null)
            master.AddSonActor(this);
        
        ParentActor = master;


        if(param.summonType == MonsterType.SummonRemoteMonster)
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_REMOTEMONSTERCREATEED, new CEventBaseArgs(this));
        else
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCALMONSTERCREATEED, new CEventBaseArgs(this));

        // 添加CE_MONSTERCREATEED消息通知Lua,避免Monster类对象的传递
        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MONSTERCREATEED, new CEventObjectArgs(this.UID.obj_idx, this.TypeIdx));
    }

    /// <summary>
    /// 召唤怪物到时间后要被销毁
    /// </summary>
    static void OnSummonMonsterDisappear(System.Object param)
    {
        UnitID uid = (UnitID)(param);
        ActorManager.Instance.DestroyActor(uid, 0);
    }

    /// <summary>
    /// 当角色在屏幕内
    /// </summary>
    public override void  OnBecomeVisible(bool bVisible)
    {

        if (bVisible)
        {
            return;
        }
        if (IsDead())
        {
            return;
        }

    }

    public override void OnResLoaded()
    {
        base.OnResLoaded();

        if (BeSummonedType != BeSummonType.NULL)
        {
            ActiveAI(true);
        }
    }

    public bool m_SummonMonster = false;

    /// <summary>
    /// 是否是召唤怪
    /// </summary>
    public bool IsSummonMonster
    {
        get
        {
            return m_SummonMonster;
        }
    }

    public override void AfterCreate()
    {
        base.AfterCreate();

#if UNITY_EDITOR
        gameObject.name = "Monster_" + UID.obj_idx + "_" + ActorId;
#endif

        CreateParam createParam = mCreateParam as CreateParam;
        if (createParam == null)
        {
            return;
        }

        m_SummonMonster = createParam.summon;

        var select_actor = LockTargetManager.Instance.SelectActor;
        if (createParam.summon)
        {
            OnCreateSummonMonster(mCreateInfo, createParam);
            if (this.ParentActor == null || this.ParentActor.IsLocalPlayer == false)
            {
                if (this == select_actor)// 选中的角色选中显示头顶名字和血条等
                    mVisibleCtrl.SetActorVisible(ShieldManager.Instance.SummonMonsterVisible, false, true, VisiblePriority.CULL);
                else
                    mVisibleCtrl.SetActorVisible(ShieldManager.Instance.SummonMonsterVisible, false, false, VisiblePriority.CULL);
            }

            return;
        }
        else
        {
            if (IsBoss() == false)
            {
                if (this == select_actor)// 选中的角色选中显示头顶名字和血条等
                    mVisibleCtrl.SetActorVisible(ShieldManager.Instance.NomralMonsterVisible, false, true, VisiblePriority.CULL);
                else
                    mVisibleCtrl.SetActorVisible(ShieldManager.Instance.NomralMonsterVisible, false, false, VisiblePriority.CULL);
            }
        }

        if (createParam.is_pet)
        {
            SetMonsterType(Monster.MonsterType.LocalMonster);
            if (!IsBoss())
                HPProgressBarIsActive = true;

            if (createParam.hasAI)
            {
                ActiveAI(true);
            }

            //ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCALMONSTERCREATEED, new CEventBaseArgs(this));
        }
        else
        {
            if (!IsBoss())
                HPProgressBarIsActive = true;
            SetMonsterType(Monster.MonsterType.RemoterMonster);

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_REMOTEMONSTERCREATEED, new CEventBaseArgs(this));

            // 添加CE_MONSTERCREATEED消息通知Lua,避免Monster类对象的传递
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MONSTERCREATEED, new CEventObjectArgs(this.UID.obj_idx, this.TypeIdx));
        }

        var camp = mCreateInfo.AOIMonster != null ? mCreateInfo.AOIMonster.camp : 0xffffffff;
        Camp = camp;

#if UNITY_EDITOR
        // 更改名字
        GetModel().name = string.Format("Monster_{0}", UID.obj_idx);
#endif
    }

	public enum MonsterType : byte
	{
		None = 0,
		LocalMonster,// 单人副本中的怪
		RemoterMonster,// 多人副本中的远程怪
        SummonLocalMonster, // 由本地玩家召唤出来的怪
        SummonRemoteMonster, // 由远程玩家召唤出来的怪
    }

    public enum MonsterSpawnType : byte
    {
        ST_Normal = 0,
        ST_Random,
    }
	
    /// <summary>
    /// 设置怪物类型，用于控制消息同步机制
    /// </summary>
	public void SetMonsterType(MonsterType t)
	{
        // 怪物取消MP消耗
        AttackCtrl.IsUseMP = false;

		if(mMonsterType!=t)
		{
			mMonsterType = t;
            if(t == MonsterType.LocalMonster)
			{
				AttackCtrl.mIsSendMsg 			= false;
				AttackCtrl.mIsRecvMsg			= false;
				AttackCtrl.mIsProcessInput		= false;
								
				BeattackedCtrl.mIsSendMsg		= false;
				BeattackedCtrl.mIsRecvMsg		= false;
				
				MoveCtrl.mIsProcessInput = false;
				MoveCtrl.mIsSendMsg = false;
				MoveCtrl.mIsRecvMsg = false;
			}
			else if(t == MonsterType.RemoterMonster)
			{
				AttackCtrl.mIsSendMsg 			= false;
				AttackCtrl.mIsRecvMsg			= true;
				AttackCtrl.mIsProcessInput		= false;
				AttackCtrl.IsUseCD			= false;
                AttackCtrl.IsUseMP = false;
				
				BeattackedCtrl.mIsSendMsg		= true;
				BeattackedCtrl.mIsRecvMsg		= true;	
				
				MoveCtrl.mIsProcessInput = false;
				MoveCtrl.mIsSendMsg = false;
				MoveCtrl.mIsRecvMsg = true;
			}
            else if(t == MonsterType.SummonLocalMonster)
            {
                AttackCtrl.mIsSendMsg           = true;
                AttackCtrl.mIsRecvMsg           = false;
                AttackCtrl.mIsProcessInput      = false;
                AttackCtrl.IsUseCD          = true;
                AttackCtrl.IsUseMP = false;
                
                BeattackedCtrl.mIsSendMsg       = true;
                BeattackedCtrl.mIsRecvMsg       = true;
                
                MoveCtrl.mIsProcessInput = false;
                MoveCtrl.mIsSendMsg = true;
                MoveCtrl.mIsRecvMsg = false;
            }
            else if(t == MonsterType.SummonRemoteMonster)
            {
                AttackCtrl.mIsSendMsg           = false;
                AttackCtrl.mIsRecvMsg           = true;
                AttackCtrl.mIsProcessInput      = false;
                AttackCtrl.IsUseCD          = false;
                AttackCtrl.IsUseMP = false;
                
                BeattackedCtrl.mIsSendMsg       = true;
                BeattackedCtrl.mIsRecvMsg       = true; 
                
                MoveCtrl.mIsProcessInput = false;
                MoveCtrl.mIsSendMsg = false;
                MoveCtrl.mIsRecvMsg = true;
            } 
		}
	}
	
    public override void ActiveAI(bool active)
	{

		if (active)
		{
			if (mAI == null)
			{
                BehaviourMonsterAI ai = new BehaviourMonsterAI(this);
                ai.Init();
                SetAI(ai);
            }
		}
		else
		{
			if (mAI != null)
            {   
                mAI.OnDestroy();
				mAI = null;
            }
            SetAI(null);

        }
	}
	
	public override bool Kill ()
	{
        bool isDead = base.Kill ();
        AfterKill();

		return isDead;
	}

    protected virtual void AfterKill()
    {
        if (m_MatEffectCtrl != null)
        {
            if(IsWorldBoss())
            {
                m_MatEffectCtrl.AddEffectMat(float.MaxValue, MaterialEffectCtrl.MAT_TYPE.DEAD_TOMBSTONE, MaterialEffectCtrl.Priority.TOMB);
            }
               
            else
                m_MatEffectCtrl.AddEffectMat(GlobalConst.MonsterDestroyDelay, MaterialEffectCtrl.MAT_TYPE.DEAD_DISSOLVE, MaterialEffectCtrl.Priority.DEAD);
           
        }

        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MONSTERDEAD,new CEventBaseArgs(UID));
    }

    public override void DoDamage(uint attacker_obj_idx, int iDamageValue, float fShowDelayTime, bool bCritic, uint proto_damageEffectType)
    {
        base.DoDamage(attacker_obj_idx, iDamageValue, fShowDelayTime, bCritic, proto_damageEffectType);
    }
    
    public override void Beattacked (Damage dam)
	{
		base.Beattacked (dam);
	}
	
    public override void EnterFreezeState ()
	{
		SetAIEnable(false);
		base.EnterFreezeState();
	}
	
    public override void ExitFreezeState ()
	{
		SetAIEnable(true);		
		base.ExitFreezeState();
	}
	
	public override void EnterDizzyState ()
	{
		SetAIEnable(false);
		base.EnterDizzyState ();
	}
	
    public override void ExitDizzyState ()
	{
		SetAIEnable(true);		
		base.ExitDizzyState ();
	}

    public MonsterType InstMonsterType
    {
        get { return mMonsterType; }
    }

    public MonsterSpawnType SpawnType
    {
        get { return mMonsterSpawnType; }
        set { mMonsterSpawnType = value; }
    }

    public QualityColor Color
    {
        get
        {
            return mColor;
        }
        set
        { 
            if(value <= 0)// FIXME 服务端发送过来的数据可能为0，强制转为1
                mColor = QualityColor.COMMON;
            else
                mColor = value;
        }
    }

    public Vector3 CenterSpawnPos
    {
        get 
        {
            if (ParentActor != null)
            {
                return ParentActor.GetModel().transform.position;
            }

            if (Camp == LocalPlayer.NowCamp)
            {
                Actor localPlayer = Game.GetInstance().GetLocalPlayer();

                if (localPlayer != null)
                {
                    return Game.GetInstance().GetLocalPlayer().GetModel().transform.position;
                }
            }

            return mCenterSpawnPos; 
        }
        set 
        { 
            mCenterSpawnPos = value; 
        }
    }

    public int MotionRadius
    {
        get
        {
            return ActorAttribute.DefaultMotionRadius;
        }
    }

    public int MaxChaseDistance
    {
        get
        {
            return ActorAttribute.DefaultMotionRadius;
        }
    }

    public override bool IsBoss()
    {
        return (QualityColor)mActorAttr.Quality == QualityColor.BOSS;
    }

    public bool IsWorldBoss()
    {
        return mActorAttr.WarTag == (byte)GameConst.WAR_TAG_WORLD_BOSS;
    }

    public string GetMonsterColorStr()
    {
        string colorText = "ffffff";
        if (mColor == Monster.QualityColor.COMMON)
        {
            colorText = "ffffff";
        }
        else if (mColor == Monster.QualityColor.ELITE)
        {
            colorText = "FF3F40";
        }
        else if (mColor == Monster.QualityColor.BOSS)
        {
            colorText = "FF3F40";
        }

        return colorText;
    }

    public override bool IsMonster()
    {
        return true;
    }

    public List<uint> SkillIds
    {
        get { return mSkillIds; }
        set { mSkillIds = value; }
    }

    void OnShowHPProgressBarTimer(float remainTime)
    {
        if (remainTime <= 0f)
        {
            HPProgressBarIsActive = false;
        }
    }

    void ShowHPProgressBarForAWhile(float second)
    {
        if (mShowHPProgressBarTimer != null)
        {
            mShowHPProgressBarTimer.Destroy();
            mShowHPProgressBarTimer = null;
        }

        HPProgressBarIsActive = true;

        mShowHPProgressBarTimer = new Utils.Timer((int)(second * 1000f), false, second * 1000f, OnShowHPProgressBarTimer);
    }

    /// <summary>
    /// 设置头顶的ICON
    /// </summary>
    public override void SetHeadIcons(EHeadIcon icon_type)
    {
        HeadIconsBehavior headIconBehavoir = GetBehavior<HeadIconsBehavior>();
        if (headIconBehavoir == null)
            return;

        headIconBehavoir.EnableBehaviors(mVisibleCtrl.VisibleMode == EVisibleMode.Visible && !IsDead());
    }

    /// <summary>
    /// 是否可以被选中(手动)
    /// </summary>
    public override bool CanBeChoosed()
    {
        return true;
    }

    public override bool CanBeHited()
    {
        // 召唤怪不能作为攻击目标
        if (BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_PLAYER || BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_ROBOT)
        {
            return false;
        }
        return base.CanBeHited();
    }
}

