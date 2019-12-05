using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using xc;

using Net;
using xc.ui;
using Utils;

using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using System.Text;

[wxb.Hotfix]
public class Actor : IControlDelegate
{
    #region 类型定义
    public class SlotBoneItemData
    {
        public string m_slotSpineName;
        public Transform m_boneTransform;
        public SlotBoneItemData(string var_slotSpineName)
        {
            m_slotSpineName = var_slotSpineName;
        }
    }

    public class DamageValueItem
    {
        public int value;
        public bool is_crit;
        public Vector3 attacker_world_pos;
        public FightEffectHelp.FightEffectPanelType panel_type;
        public FightEffectHelp.FightEffectType effect_type; //飘字类型
    }

    /// <summary>
	/// 野外的玩家攻击状态
	/// </summary>
	public enum EWildState
    {
        Peace = 1, // 和平
        Kill = 2,  // 杀戮
        Society = 3, // 军团
    }

    public enum SlotBoneNameType
    {
        None = 0,
        /// <summary>
        /// 胸部
        /// </summary>
        Spine,
        /// <summary>
        /// 头部
        /// </summary>
        Head,
        /// <summary>
        /// 脚底
        /// </summary>
        Root,
    }

    // 角色拥有的动作
    public enum EAnimation
    {
        idle = 0, // 休闲
        idle_fight, // 战斗休闲
        walk,     // 走路
        walk_fight, // 战斗走路
        beAtk_Backward, // 普通受击
        floating, // 浮空
        falling,  // 浮空下落
        falldown, // 浮空落地动作
        death,   // 死亡动作
        rideidle,   //坐骑上休闲
        riderun,    //坐骑上跑步

        count
    }

    // 角色本身触发的事件
    public enum ActorEvent
    {
        ENTERIDLE, // 角色进入idle状态
        EXITIDLE,    // 角色退出idle状态
        BEATTACK,  // 角色受到攻击
        DEAD,        // 角色死亡
        REACH_TARGET, //走到了目标点
        SHAPE_SHIFT, // 角色变身
        AVATAR_CHANGE_BEGIN, //换装模型发生变化(换装前)
        AVATAR_CHANGE, //换装模型发生变化
        AFTER_CREATE, //角色创建后
        MODEL_CHANGE, //角色的模型发生变化
        SHADOW_CHANGE, // 阴影类型发生变化
        BATTLE_STATE_CHANGE, // 战斗状态发生改变
        RES_LOADED_CHANGE,  //角色资源加载完全（重新计算模型的高度和大小）
        HP_CHANGE,  //HP变化
        MP_CHANGE,  //MP变化
        BEFORE_ACTOR_DESTROY, //角色销毁前
        EXIT_JUMPSCENE_STATE, // 退出跳场景状态
    }

    // 玩家职业类型
    public enum EVocationType
    {
        EVT_NONE = 0,
        ROLE1 = 1, // 龙战士
        ROLE2 = 2, // 歌吟者
        ROLE3 = 3, // 魔法师
    }

    //　玩家头顶的图片标识
    public enum EHeadIcon
    {
        NONE = 0x0,
        TITLE = 0x1, // 头衔
        ARENA_GRADE = 0x2, // 竞技场军阶
        MINE = 0x4, // 挖矿
        TEAM = 0x8, // 队伍
        PK = 0x10, // 我能攻击的
        PK2 = 0x20, // 能攻击我的
        BOSS_BG = 0X40, // BOSS名字背景
        BOSS = 0X80, // BOSS标志
        PEAK = 0X100, // 巅峰标志
        ALL = TITLE | ARENA_GRADE | MINE | TEAM | PK | PK2 | BOSS_BG | BOSS | PEAK,
    }

    /// 技能id和对应的释放概率
    public class SkillCastInfo
    {
        public uint muiID;
        public ushort mbtCastRate;

        public SkillCastInfo(uint uiID, ushort btCastRate)
        {
            muiID = uiID;
            mbtCastRate = btCastRate;
        }

        public static implicit operator uint(SkillCastInfo kInfo)
        {
            if (kInfo != null)
                return kInfo.muiID;

            return 0xffffffff;
        }
    }

    //战斗状态结构
    public class DamageEffect
    {
        public FightEffectHelp.FightEffectType EffectType = FightEffectHelp.FightEffectType.none;
        public long Value = 0;
        public bool ShowPercent = false;
        public string PushStr;  //后缀字符串
    }

    /// <summary>
    /// 可见状态
    /// </summary>
    protected enum VisibleType
    {
        UNINIT = 0,
        VISIBLE,
        INVISIBLE
    }
    #endregion

    #region 变量定义
    /// <summary>
    /// 是否已经销毁
    /// </summary>
    protected bool mIsDestroy = false;

    /// <summary>
    /// 所有的角色组件
    /// </summary>
    protected Dictionary<string, IActorBehavior> mActorBehaviors = new Dictionary<string, IActorBehavior>();

    /// <summary>
    /// 静态的角色动作名字
    /// </summary>
    static Dictionary<EAnimation, AnimationOptions> m_StandardAnimation = new Dictionary<EAnimation, AnimationOptions>();
    protected Dictionary<EAnimation, AnimationOptions> m_AnimationMaps = new Dictionary<EAnimation, AnimationOptions>();
    protected UnitCacheInfo mCreateInfo;
    protected Monster.CreateParam mCreateParam;
    protected bool mResLoaded = false;
    private List<Actor> mSonActors = new List<Actor>();

    // 角色的各种控制器
    public EventCtrl mEventCtrl = new EventCtrl();
    public MoveCtrl MoveCtrl;
    public AttackCtrl AttackCtrl;
    public BeattackedCtrl BeattackedCtrl;
    private BuffCtrl m_BuffCtrl;
    public CooldownCtrl CDCtrl;
    public MaterialEffectCtrl m_MatEffectCtrl;
    public RideCtrl mRideCtrl;
    public AvatarCtrl mAvatarCtrl;
    public VisibleCtrl mVisibleCtrl;
    AnimationController mAnimationCtrl;
    SkillEffectPlayer mSkillEffectPlayer;
    StateEffectPlayer mStateEffectPlayer;
    MoveImpl mMoveImpl;
    List<DamageValueItem> mDamagesValueList; //普通伤害飘字(DoDamage添加)

    List<DamageEffect> mDamageEffectList = new List<DamageEffect>(); // 特殊伤害效果缓存(ShowDamageEffect添加)
    // buff 缓存
    List<string> mBuffTipList = new List<string>();
    private string mName = "";// 角色表中的名字
    private string mUserName = ""; // 玩家名字
    private string mMonsterSpecName = ""; // 蓝、金色怪特殊附加名
    private EVocationType mVocationID = EVocationType.EVT_NONE;
    private float mFreezeTime = 0.0f;
    private float mMemFreezeTime = 0.0f;
    private bool m_IsFreeze = false;
    private string m_LastAnimation = "";
    protected bool m_InBattleStatus = false;
    private string m_real_LastAnimation = "";
    public const string SlotSpineName = "Bip001 Spine1";    //胸部骨骼
    public const string SlotHeadName = "Bip001 Head";       //头部骨骼
    public const string SlotRootName = "root_node";         //脚底挂点
    protected AI mAI;
    private bool mNoUpdate = false;
    Skill mCurSkill;
    protected UnitID mUintID = new UnitID();
    private EUnitType mUnitType = EUnitType.UNITTYPE_PLAYER;
    // Self的位置信息
    Transform mTarget;
    // 称号相关的变量
    uint mTitleIdx = 0;
    private uint mTypeIdx = 0;
    // 角色属性的数据
    protected ActorAttributeData mActorAttr = new ActorAttributeData();
    private static float DefaultFadeTime = 0.1f;
    //背包可掉落状态
    protected uint mBagDropState;
    private uint mUpdateFlag = DBActor.UF_ALL;
    ulong mBitStates = 0;    // 位状态
    public uint PKLvProtect;
    string mOverridingName = null;   //玩家名字，如果非空会覆盖默认Name 
    string mOverridingTargetName = null;    //被选中时显示的目标名字
    uint mNameColor = 0;  // 玩家名字颜色
    /// <summary>
    /// 被召唤后的父亲Actor
    /// </summary>
    private WeakReference m_ParentActor;
    protected Dictionary<string, SlotBoneItemData> m_slotBoneItemData;
    // 技能音效实例 id 用于打断声音
    private uint mSkillSoundId = 0;
    #endregion

    #region 角色组件接口
    /// <summary>
    /// Inits the behaviors.
    /// </summary>
    public virtual void InitBehaviors()
    {
        AddBehavior(new TextNameBehavior(this));
        AddBehavior(new HeadIconsBehavior(this));
        AddBehavior(new SkillInfoBehavior(this));
        AddBehavior(new BattleStateBehavior(this));
        AddBehavior(new ShadowBehavior(this));
        AddBehavior(new BindEffectBehavior(this));
        AddBehavior(new HPProgressBarBehavior(this));
        AddBehavior(new FootprintBehavior(this));


        foreach (IActorBehavior behavior in mActorBehaviors.Values)
        {
            if (behavior != null)
            {
                behavior.InitBehaviors();
            }
        }
    }

    public virtual void UnInitBehaviors()
    {
        foreach (IActorBehavior behavior in mActorBehaviors.Values)
        {
            if (behavior != null)
            {
                behavior.UnInitBehaviors();
            }
        }
        mActorBehaviors.Clear();
    }

    public void AddBehavior(IActorBehavior behavior)
    {
        string name = behavior.GetType().Name;
        mActorBehaviors[name] = behavior;
    }

    public T GetBehavior<T>() where T : IActorBehavior
    {
        //return GetBehavior(typeof(T).Name) as T;

        return GetBehavior(UtilType.GetTypeName(typeof(T))) as T;

    }

    public virtual void EnableBehaviors(bool enable)
    {
        foreach (IActorBehavior behavior in mActorBehaviors.Values)
            behavior.EnableBehaviors(enable);
    }

    public IActorBehavior GetBehavior(string name)
    {
        IActorBehavior behavoir;
        if (mActorBehaviors.TryGetValue(name, out behavoir))
            return behavoir;
        else
            return null;
    }
    #endregion

    #region 初始化和销毁接口
    /// <summary>
    /// 角色对应的GameObject发生改变后
    /// 第一次：InitEmptyModle
    /// 第二次：加载默认套装的角色后
    /// </summary>
    virtual public void OnModelChanged()
    {
        if (IsDestroy)
            return;

        var model = GetModel();

        if (model != null)
            mAnimationCtrl = model.GetComponent<AnimationController>();

        if (mAnimationCtrl != null)
        {
            mAnimationCtrl.enabled = true;
            if(this.IsPlayer())
            {
                VocationInfo info = DBVocationInfo.Instance.GetVocationInfo((uint)this.VocationID);
                if (info != null)
                {
                    mAnimationCtrl.CullMode = info.animator_cull_mode;
                }
            }
            else
            {
                // 怪物、NPC等根据AnimationCull来设置动画的裁剪模式
                if (model != null)
                {
                    var cull = model.GetComponent<AnimationCull>();
                    if (cull != null)
                    {
                        mAnimationCtrl.CullMode = cull.CullMode;
                    }
                }
            }
            mAnimationCtrl.Reset();
        }

        if (model != null)
        {
            mSkillEffectPlayer = model.GetComponent<SkillEffectPlayer>();
            mStateEffectPlayer = model.GetComponent<StateEffectPlayer>();
        }

        if (mSkillEffectPlayer != null)
            mSkillEffectPlayer.SetOwner(this);

        if (mStateEffectPlayer != null)
            mStateEffectPlayer.SetOwner(this);

        mEventCtrl.FireEvent((int)ActorEvent.MODEL_CHANGE, null);

        // 其他玩家取消动态骨骼
        if(model != null)
        {
            var dynamic_bone = model.transform.Find("DynamicBone");
            if(dynamic_bone != null)
            {
                /*bool use_dynamic_bone = false;
                if (IsLocalPlayer)
                    use_dynamic_bone = true;
                else if (IsClientModel())
                {
                    var client_model = (ClientModel)this;
                    if (client_model != null && (client_model.RawUID == Game.Instance.LocalPlayerID.obj_idx || Game.Instance.IsEnterGame == false))
                        use_dynamic_bone = true;
                }*/

                // 进入游戏前才使用动态骨骼
                bool use_dynamic_bone = Game.Instance.IsEnterGame == false;
                dynamic_bone.gameObject.SetActive(use_dynamic_bone);
            }
        }
    }

    public ActorMono GetActorMono()
    {
        var model = mAvatarCtrl.GetModelParent();

        if (model != null)
        {
            return model.GetComponent<ActorMono>();
        }

        return null;
    }

    /// <summary>
    /// 在Actor对应的GameObject创建后调用，但是此时实际的模型并未加载
    /// </summary>
    virtual public void AfterCreate()
    {
        SetHeadIcons(Actor.EHeadIcon.ALL);

        mTarget = GetModelParent().GetComponent<Transform>();
        mMoveImpl = new MoveImpl(this);// 初始化移动组件

        SetMoveSpeedScale(mActorAttr.MoveSpeedScale * GlobalConst.AttrConvert, mActorAttr.MoveSpeedAdd);
        if (!(this is Player) || this is NpcPlayer || this is ClientModel)
        {
            mVisibleCtrl.SetActorVisible(true, VisiblePriority.NORMAL);
        }

        mEventCtrl.FireEvent((int)ActorEvent.AFTER_CREATE, null);
        if (mActorMachine != null)
            mActorMachine.AfterCreate();

        SetNameStyle();
        SetNameText();

        if (AutoActiveTextName)
            GetBehavior<TextNameBehavior>().Active(mTarget.gameObject);

        PostprocessAOIData(mCreateInfo);
    }

    /// <summary>
    /// 当Actor对应的实际模型加载完毕后调用
    /// </summary>
    virtual public void OnResLoaded() // 当模型资源加载完成后调用的函数
    {
        mMoveImpl.OnResLoaded();
        mActorMachine.OnResLoaded();

        mResLoaded = true;
        SetNameText();
        SetHeadIcons(EHeadIcon.ALL);
        FireActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, null);
        PlayLastAnimation_real();

        if (IsGuardedNpc())
        {
            GetBehavior<TextNameBehavior>().EnableBehaviors(true);
            ShowTextName(true);
            SetNameText();
        }
    }

    public bool IsGuardedNpc()
    {
        return InstanceHelper.IsGuardedNpc(ActorId);
    }

    public virtual void LateUpdate()
    {
        using (var enumerator = mActorBehaviors.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                var cur = enumerator.Current;
                cur.Value.LateUpdate();
            }
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (NoUpdate)
        {
            return;
        }

        //update ctrl
        mAvatarCtrl.Update();
        if (mRideCtrl != null)
            mRideCtrl.Update();

        if (mFreezeTime > 0.0f)
        {
            if (m_IsFreeze)
            {
                mFreezeTime -= Time.deltaTime;
            }
        }
        else
        {
            if (m_IsFreeze)
                UnFreeze();
        }

        if (!IsDead())
        {
            if (NeedUpdate(DBActor.UF_ATTACK))
                AttackCtrl.Update();
            if (NeedUpdate(DBActor.UF_BEATTACK))
                BeattackedCtrl.Update();
            if (NeedUpdate(DBActor.UF_MOVE))
                MoveCtrl.Update();
            if (NeedUpdate(DBActor.UF_BUFF))
                m_BuffCtrl.Update();

            if (NeedUpdate(DBActor.UF_AI) && mAI != null)
            {
                mAI.Update();
            }

            if (NeedUpdate(DBActor.UF_SKILL) && mCurSkill != null)
            {
                mCurSkill.Update();
            }
        }

        if (mAnimationCtrl != null)
        {
            if (NeedUpdate(DBActor.UF_ANIMATION))
            {
                mAnimationCtrl.Pause(false);
            }
            else
            {
                mAnimationCtrl.Pause(true);
            }
        }

        if (NeedUpdate(DBActor.UF_ACTION))
        {
            if (mActorMachine != null)
            {
                mActorMachine.Update();
            }
        }

        if (NeedUpdate(DBActor.UF_BATTLESTATE))
            UpdateBattleState();
        if (CDCtrl != null)
            CDCtrl.Update();
        if (m_MatEffectCtrl != null)
            m_MatEffectCtrl.Update();

        UpdateFightEffect();

        using (var enumer = mActorBehaviors.GetEnumerator())
        {
            while (enumer.MoveNext())
            {
                IActorBehavior be = (IActorBehavior)enumer.Current.Value;
                be.Update();
            }
        }
    }

    public bool IsDestroy
    {
        get
        {
            return mIsDestroy;
        }
    }

    public virtual void Destroy()
    {
        if (mIsDestroy)
            return;

        FireActorEvent(ActorEvent.BEFORE_ACTOR_DESTROY, null);

        mIsDestroy = true;
        NoUpdate = false;

        if (m_IsFreeze)
            UnFreeze();

        ResetLayer();
        GetBehavior<BattleStateBehavior>().Reset();

        mVisibleCtrl.SetActorVisible(true, VisiblePriority.CULL);
        mAvatarCtrl.UpdateVisibleState();// 设置可见后，需要强制更新一次
        mVisibleCtrl.RecoverPriority();
        CullManager.Instance.RemoveActor(this);
        mSonActors.Clear();

        UnInitBehaviors();
        DestoryCtrls();
        // 清除状态机
        if (mActorMachine != null)
        {
            mActorMachine.Destroy();
            mActorMachine = null;
        }
        // 清除动画数据
        if (m_AnimationMaps != null)
        {
            m_AnimationMaps.Clear();
            m_AnimationMaps = null;
        }
        // 清除属性数据
        if (mActorAttr != null)
        {
            mActorAttr.Clear();
            mActorAttr = null;
        }

        ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SETTING_QUALITY_CHANGED, OnSettingQualityChanged);
    }

    /// <summary>
    /// 销毁所有的控制器
    /// </summary>
    void DestoryCtrls()
    {
        if (MoveCtrl != null)
        {
            MoveCtrl.Destroy();
            MoveCtrl = null;
        }

        if (AttackCtrl != null)
        {
            AttackCtrl.Destroy();
            AttackCtrl = null;
        }

        if (BeattackedCtrl != null)
        {
            BeattackedCtrl.Destroy();
            BeattackedCtrl = null;
        }

        if (m_BuffCtrl != null)
        {
            m_BuffCtrl.Destroy();
            m_BuffCtrl = null;
        }

        if (CDCtrl != null)
        {
            //CDCtrl.Destroy();
            CooldownCtrlMgr.Instance.RecyleCooldown(CDCtrl);
            CDCtrl = null;
        }

        if (m_MatEffectCtrl != null)
        {
            m_MatEffectCtrl.Destroy();
            m_MatEffectCtrl = null;
        }

        if (mRideCtrl != null)
        {
            mRideCtrl.Destroy();
            mRideCtrl = null;
        }

        if (mAnimationCtrl != null)
        {
            // 在销毁前需要播放下idle动作，避免下次从内存池中拿出来时候的角色位置不对
            var cull_mode = mAnimationCtrl.CullMode;
            mAnimationCtrl.CullMode = AnimatorCullingMode.AlwaysAnimate;
            mAnimationCtrl.PlayAnimation("idle");
            mAnimationCtrl.CullMode = cull_mode;

            mAnimationCtrl.Reset();
            mAnimationCtrl = null;
        }

        if (mAvatarCtrl != null)
        {
            mAvatarCtrl.Destroy();
            mAvatarCtrl = null;
        }

        if (mVisibleCtrl != null)
        {
            mVisibleCtrl.Destroy();
            mVisibleCtrl = null;
        }

        if (mEventCtrl != null)
        {
            mEventCtrl.Destory();
            mEventCtrl = null;
        }

        if (mAI != null)
        {
            mAI.OnDestroy();
            mAI = null;
        }

        if (mSkillEffectPlayer != null)
        {
            mSkillEffectPlayer.ClearEffects();
            mSkillEffectPlayer.IsEnable = true;
            mSkillEffectPlayer = null;
        }

        if (mStateEffectPlayer != null)
        {
            mStateEffectPlayer.ClearEffects();
            mStateEffectPlayer.IsEnable = true;
            mStateEffectPlayer = null;
        }
    }

    /// <summary>
    /// 根据Actor表的数据来初始化Actor类的变量
    /// </summary>
    private DBActor.ActorData LoadActorData()
    {
        var actor_table = DBManager.GetInstance().GetDB<DBActor>();

        if (UID == null)
        {
            GameDebug.LogError("[LoadActorData] UID is null");
            return null;
        }

        if (!actor_table.ContainsKey(mTypeIdx))
        {
            GameDebug.LogError("actor table does't exist. type_id:" + mTypeIdx.ToString());
            return null;
        }

        DBActor.ActorData data = actor_table.GetData(mTypeIdx);

        mName = data.name;
        mVocationID = (EVocationType)data.vocation;
        mActorAttr.Vocation = (uint)mVocationID;
        mUnitType = (EUnitType)data.type;

        int skill_count = (int)data.skill_count;
        for (byte i = 0; i < skill_count; i++)
        {
            uint sid = data.skill_idx[i];
            if (0 == sid || ushort.MaxValue == sid)
                continue;

            AddSkillCastInfo(sid, (ushort)data.cast_rate[i]);
        }

        uint race_id = data.race_id;
        if (mActorAttr.Level == 0)
            mActorAttr.Level = (uint)data.level;

        if (data.motion_radius > 0)
        {
            mActorAttr.DefaultMotionRadius = (int)data.motion_radius;
        }
        else
        {
            mActorAttr.BehaviourTree = string.Empty;
        }

        mActorAttr.BehaviourTree = string.Format("{0}{1}", data.behaviour_tree, ".json");
        mActorAttr.SummonBehaviourTree = string.Format("{0}{1}", data.summon_behaviour_tree, ".json");

        mActorAttr.WarTag = data.war_tag;
        mActorAttr.AttackRotaion = (uint)data.attack_rotaion;
        mActorAttr.Quality = (uint)data.color;
        mActorAttr.Gravity = data.gravity;

        return data;
    }

    public void SetActorAttribute(ActorAttributeData info)
    {
        mVocationID = (EVocationType)(int)info.Vocation;
        mActorAttr.Copy(info);

        SetNameText();
        SetHeadIcons(Actor.EHeadIcon.ALL);
    }

    /// <summary>
    /// Actor实例化后立即调用
    /// info : AOI信息 param : 创建参数
    /// </summary>
	public void OnCreate(xc.UnitCacheInfo info, Monster.CreateParam param)
    {
        mCreateInfo = info;
        mCreateParam = param;

        InitAOIData(info);
        InitBehaviors();
        InitCtrl();

        DBActor.ActorData actor_data = LoadActorData();
        SyncCtrlInfo(info, param);

        InitActionMaps(actor_data);
        InitStateMachine();

        ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SETTING_QUALITY_CHANGED, OnSettingQualityChanged);
    }

    /// <summary>
    /// 初始化AnimationMap数据字典
    /// </summary>
    private void InitActionMaps(DBActor.ActorData data)
    {
        if (m_StandardAnimation.Count <= 0)
        {
            m_StandardAnimation[EAnimation.idle] = new AnimationOptions();
            m_StandardAnimation[EAnimation.idle].Name = "idle";
            m_StandardAnimation[EAnimation.idle_fight] = new AnimationOptions();
            m_StandardAnimation[EAnimation.idle_fight].Name = "fightidle";
            m_StandardAnimation[EAnimation.beAtk_Backward] = new AnimationOptions();
            m_StandardAnimation[EAnimation.beAtk_Backward].Name = "behit";
            m_StandardAnimation[EAnimation.falling] = new AnimationOptions();
            m_StandardAnimation[EAnimation.falling].Name = "falling";
            m_StandardAnimation[EAnimation.floating] = new AnimationOptions();
            m_StandardAnimation[EAnimation.floating].Name = "floating";
            m_StandardAnimation[EAnimation.falldown] = new AnimationOptions();
            m_StandardAnimation[EAnimation.falldown].Name = "falldown";
            m_StandardAnimation[EAnimation.death] = new AnimationOptions();
            m_StandardAnimation[EAnimation.death].Name = "die";
            m_StandardAnimation[EAnimation.rideidle] = new AnimationOptions();
            m_StandardAnimation[EAnimation.rideidle].Name = "rideidle";
            m_StandardAnimation[EAnimation.riderun] = new AnimationOptions();
            m_StandardAnimation[EAnimation.riderun].Name = "riderun";
        }

        if (data == null)
        {
            GameDebug.LogError("[InitActionMaps]ActorData is null");
            return;
        }

        m_AnimationMaps.Clear();
        m_AnimationMaps[EAnimation.walk] = new AnimationOptions();
        m_AnimationMaps[EAnimation.walk].Name = "run";
        float run_speed = data.runspeed * 0.01f;
        m_AnimationMaps[EAnimation.walk].Speed = run_speed;
        m_AnimationMaps[EAnimation.walk].OriSpeed = run_speed;
        m_AnimationMaps[EAnimation.walk_fight] = new AnimationOptions();
        m_AnimationMaps[EAnimation.walk_fight].Name = "fightrun";
        m_AnimationMaps[EAnimation.walk_fight].Speed = run_speed;
        m_AnimationMaps[EAnimation.walk_fight].OriSpeed = run_speed;
    }

    private void InitStateMachine() // 初始化角色状态机
    {
        // 初始化状态机
        mActorMachine = new ActorMachine(this);
        mActorMachine.Init();
    }

    /// <summary>
    /// 从AOI信息初始化角色属性
    /// </summary>
    protected virtual void InitAOIData(xc.UnitCacheInfo info)
    {
        UID = info.UnitID;
        if (UID.type == (byte)EUnitType.UNITTYPE_PLAYER)
        {
            mTypeIdx = info.AOIPlayer.type_idx;
            mUserName = info.AOIPlayer.name;
            mActorAttr.Level = (uint)info.AOIPlayer.level;
            mActorAttr.TeamId = (uint)info.AOIPlayer.team_id;
            mActorAttr.EscortId = (uint)info.AOIPlayer.escort_id;
            mUnitType = info.UnitType;
            if (this.IsLocalPlayer && LocalPlayerManager.Instance.LocalActorAttribute != null)
            {
                mActorAttr.HP = (int)LocalPlayerManager.Instance.LocalActorAttribute.HP;
                mActorAttr.HPMax = (int)LocalPlayerManager.Instance.LocalActorAttribute.HPMax;
            }
            else
                mActorAttr.HP = (int)info.AOIPlayer.hp;
            //mActorAttr.BattlePower = (uint)Mathf.CeilToInt((float) info.AOIPlayer.fight_rank * ActorHelper.UnitConvertInv) ;
            mActorAttr.Camp = info.AOIPlayer.camp;
            mNameColor = info.AOIPlayer.name_color;
            mActorAttr.State = info.AOIPlayer.state;
            mActorAttr.GuildName = info.AOIPlayer.guild_name;
            mActorAttr.GuildId = info.AOIPlayer.guild_id;
            mActorAttr.Honor = info.AOIPlayer.honor_id;
            mActorAttr.Title = info.AOIPlayer.title_id;
            mActorAttr.TransferLv = info.AOIPlayer.transfer_lv;

            SetHeadIcons(Actor.EHeadIcon.PEAK);
            if (this is Player)
            {
                (this as Player).UpdatePetId(info.AOIPlayer.pet_id);
                this.MountId = info.AOIPlayer.mount_id;
            }
            this.MateInfo = info.AOIPlayer.mate_info;
        }
        else if (UID.type == (byte)EUnitType.UNITTYPE_MONSTER)
        {
            mTypeIdx = info.AOIMonster.type_idx;
            mUserName = "";
            mUnitType = info.UnitType;
            mActorAttr.HP = (int)info.AOIMonster.hp;
            mActorAttr.Level = info.AOIMonster.level;
            mActorAttr.Camp = info.AOIMonster.camp;
        }
        else if (UID.type == (byte)EUnitType.UNITTYPE_PET)
        {
            mTypeIdx = info.AOIPet.type_idx;
            mUserName = "";
            mUnitType = info.UnitType;
            mActorAttr.HP = 0;
            mActorAttr.Level = 0;
            mActorAttr.Camp = 0;
        }
        else if (UID.type == (byte)EUnitType.UNITTYPE_NPC)
        {
            mTypeIdx = NpcHelper.GetNpcActorId((uint)info.ClientNpc.ExcelId);
            mUserName = info.ClientNpc.GameObjectName;
            mUnitType = info.UnitType;
            mActorAttr.Level = 1;
            mActorAttr.Camp = 0xffffffff;
        }

        if (info.AttrElements != null)
        {
            foreach (var elem in info.AttrElements)
            {
                mActorAttr.Attribute[elem.attr].Value = elem.value;
            }
        }

        // 先将最大蓝量属性赋值为当前蓝量
        mActorAttr.MP = mActorAttr.MPMax;
    }

    /// <summary>
    /// 在角色虚拟模型创建后再执行某些AOI的数据处理
    /// </summary>
    /// <param name="info"></param>
    void PostprocessAOIData(UnitCacheInfo info)
    {
        if (UID.type == (byte)EUnitType.UNITTYPE_PLAYER)
        {
            if (info.AOIPlayer.leave_buff_id_list != null)
            {
                foreach (var buff_info in info.AOIPlayer.leave_buff_id_list)
                {
                    if (buff_info.no_tips == 0)
                        buff_info.no_tips = 1;
                    m_BuffCtrl.AddBuff_out(buff_info.id, buff_info.time * GlobalConst.MilliToSecond, buff_info.layer, buff_info.no_tips);
                }
            }
        }
        else if (UID.type == (byte)EUnitType.UNITTYPE_MONSTER)
        {
            if (info.AOIMonster.leave_buff_id_list != null)
            {
                foreach (var buff_info in info.AOIMonster.leave_buff_id_list)
                {
                    m_BuffCtrl.AddBuff_out(buff_info.id, buff_info.time * GlobalConst.MilliToSecond, buff_info.layer, buff_info.no_tips);
                }
            }
        }
    }

    /// <summary>
    /// 更新AOI中的角色属性数据
    /// </summary>
    public void UpdateAOIAttrElement(List<PkgAttrElm> attr_element)
    {
        foreach (var elem in attr_element)
        {
            mActorAttr.Attribute[elem.attr].Value = elem.value;
        }
    }

    /// <summary>
    /// 初始化各类控制器
    /// </summary>
    protected virtual void InitCtrl()
    {
        MoveCtrl = new MoveCtrl(this);
        AttackCtrl = new AttackCtrl(this);
        BeattackedCtrl = new BeattackedCtrl(this);
        m_BuffCtrl = new BuffCtrl(this);
        CDCtrl = CooldownCtrlMgr.Instance.GetNewCoolDown(this);
        mAvatarCtrl = new AvatarCtrl(this);
        if (this.IsPlayer())//玩家才有ridectrl
            mRideCtrl = new RideCtrl(this);
        mVisibleCtrl = new VisibleCtrl(this);
        m_MatEffectCtrl = new MaterialEffectCtrl(this);
    }

    /// <summary>
    /// 某些控制器的初始化需要AOI信息
    /// </summary>
    protected virtual void SyncCtrlInfo(xc.UnitCacheInfo info, System.Object param)
    {
        if (mRideCtrl != null)
            mRideCtrl.Init(info);
    }
    #endregion

    #region 模型接口
    /// <summary>
    /// 获取角色模型对应的Layer(在某些情况下可能与根节点的Layer不一致)
    /// </summary>
    /// <returns></returns>
    public virtual int GetModelLayer()
    {
        return GetLayer();
    }

    /// <summary>
    /// 获取角色对应的层级
    /// </summary>
    /// <returns></returns>
    public int GetLayer()
    {
        int layer = 0;
        if (IsPlayer()) // 玩家
        {
            layer = LayerMask.NameToLayer("Player");
        }
        else if (IsNpc()) // NPC
        {
            layer = LayerMask.NameToLayer("Npc");
        }
        else if (IsMonster()) // 怪物
        {
            if (IsPet())
            {
                layer = LayerMask.NameToLayer("Pet");
            }
            else
                layer = LayerMask.NameToLayer("Monster");
        }
        else if (IsClientModel())// 预览模型
        {
            ClientModel client_model = this as ClientModel;
            if (client_model != null && client_model.IsRidePlayer)
                layer = LayerMask.NameToLayer("Player");
            else
                layer = 0;
        }
        else
            layer = 0;

        return layer;
    }

    /// <summary>
    /// 获取模型的默认层级
    /// </summary>
    public void ResetLayer()
    {
        var model = GetModelParent();

        if (model != null)
        {
            int layer = 0;

            model.layer = layer;
            //遍历所有子节点
            foreach (Transform tran in GetComponentsInChildren<Transform>())
            {
                tran.gameObject.layer = layer;
            }
        }
    }

    public Transform GetSlotTransform(string bone)
    {
        if (transform == null)
            return null;
        if (bone == string.Empty)
            return transform;
        if (m_slotBoneItemData == null)
            m_slotBoneItemData = new Dictionary<string, SlotBoneItemData>();
        SlotBoneItemData item_data;
        if (m_slotBoneItemData.TryGetValue(bone, out item_data) == false)
        {
            item_data = new SlotBoneItemData(bone);
            item_data.m_boneTransform = ModelHelper.FindChildInHierarchy(transform, item_data.m_slotSpineName);
            m_slotBoneItemData[bone] = item_data;
            return item_data.m_boneTransform;
        }
        if (item_data.m_boneTransform == null || item_data.m_boneTransform.IsChildOf(transform) == false)
        {
            item_data.m_boneTransform = ModelHelper.FindChildInHierarchy(transform, item_data.m_slotSpineName);
        }
        if (item_data.m_boneTransform == null)
        {
            //Debug.LogErrorFormat("bone {0} can't find in {1}", item_data.m_slotSpineName.ToString(), this.Name);
        }
        return item_data.m_boneTransform;
    }

    //if you want to know if the real model loaded, use Actor.Inited instead
    public GameObject GetModel()
    {
        if (mIsDestroy == false && mAvatarCtrl != null)
        {
            return mAvatarCtrl.GetModel();
        }

        return null;
    }

    public GameObject GetModelParent()
    {
        if (mIsDestroy == false && mAvatarCtrl != null)
        {
            return mAvatarCtrl.GetModelParent();
        }

        return null;
    }

    public GameObject gameObject
    {
        get
        {
            return GetModelParent();
        }
    }

    public Transform transform
    {
        get
        {
            GameObject obj = gameObject;
            if (obj != null)
                return obj.transform;
            else
                return null;
        }
    }

    public Collider collider
    {
        get
        {
            var model = GetModelParent();
            if (model != null)
                return model.GetComponent<Collider>();
            else
                return null;
        }
    }

    public T GetModelComponent<T>()
        where T : UnityEngine.Component
    {
        var model = GetModel();
        if (model != null)
            return model.GetComponent<T>();
        else
            return null;
    }


    public T GetComponent<T>()
       where T : UnityEngine.Component
    {
        var model = GetModelParent();
        if (model != null)
            return model.GetComponent<T>();
        else
            return null;
    }

    public T[] GetComponentsInChildren<T>()
        where T : UnityEngine.Component
    {
        var model = GetModelParent();
        if (model != null)
            return model.GetComponentsInChildren<T>();
        else
            return null;
    }

    #endregion

    #region 动画接口
    public void PlayLastAnimation()
    {
        if (string.IsNullOrEmpty(m_LastAnimation))
            return;

        if (m_LastAnimation == "die")
            Play(m_LastAnimation, 1);
        else
            Play(m_LastAnimation, 0);

        m_LastAnimation = "";
    }

    public void PlayLastAnimation_real()
    {
        if (string.IsNullOrEmpty(m_real_LastAnimation))
            return;

        if (m_real_LastAnimation == "die")
            Play(m_real_LastAnimation, 1);
        else
            Play(m_real_LastAnimation, 0);
    }

    public AnimationOptions GetAnimationOptions(EAnimation id)
    {
        AnimationOptions op;
        if (m_AnimationMaps != null && m_AnimationMaps.TryGetValue(id, out op))
        {
            return op;
        }
        else if (m_StandardAnimation != null && m_StandardAnimation.TryGetValue(id, out op))
        {
            return op;
        }
        return null;
    }

    public AnimationOptions GetWalkAniOptions()
    {
        EAnimation animation = EAnimation.walk;
        if (InBattleStatus)
        {
            if (mRideCtrl != null && mRideCtrl.IsRiding())
                animation = EAnimation.walk;//战斗状态，但是有坐骑
            else
                animation = EAnimation.walk_fight;
        }
        else
            animation = EAnimation.walk;

        return GetAnimationOptions(animation);
    }

    public AnimationOptions GetIdleAniOptions()
    {
        EAnimation animation = EAnimation.idle;
        if (InBattleStatus)
        {
            if (mRideCtrl != null && mRideCtrl.IsRiding())
                animation = EAnimation.idle;//战斗状态，但是有坐骑
            else
                animation = EAnimation.idle_fight;
        }
        //         else if (IsRider)
        //             animation = EAnimation.rideidle;
        else
            animation = EAnimation.idle;

        return GetAnimationOptions(animation);
    }

    public void Play(AnimationOptions op)
    {
        if (null == op)
        {
            GameDebug.LogError(string.Format("_play null op"));
            return;
        }

        Play(op.Name);
    }

    public void Play(EAnimation state)
    {
        AnimationOptions option = null;

        if (m_AnimationMaps != null && m_AnimationMaps.TryGetValue(state, out option))
        {
            Play(option);
        }
        else if (m_StandardAnimation != null && m_StandardAnimation.TryGetValue(state, out option))
        {
            Play(option);
        }
    }

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="name"></param>
    /// <param name="time"></param>
	public void Play(string name, float time = 0)
    {
        m_real_LastAnimation = name;
        if (mAnimationCtrl == null)
        {
            m_LastAnimation = name;
            return;
        }

        bool ret = mAnimationCtrl.PlayAnimation(name, time);
        if (ret == false)
            GameDebug.LogWarning(string.Format("play animation failed, actor: {0}, animation: {1}", Name, name));

        if (mRideCtrl != null)
        {
            mRideCtrl.SyncAnim(name);
        }

        // TODO 清旧的音效
        if(mSkillSoundId != 0)
        {
            AudioManager.Instance.StopBattleSFX(mSkillSoundId);
            mSkillSoundId = 0;
        }
    }
    public void PlaySkillSound(string res_path)
    {
        mSkillSoundId = AudioManager.Instance.PlayBattleSFX(res_path, AudioManager.GetSFXSoundType(this));
    }

    public void CrossFade(AnimationOptions op)
    {
        if (null == op)
        {
            GameDebug.LogError(string.Format("_crossFade null op"));
            return;
        }

        CrossFade(op.Name, DefaultFadeTime);
    }

    public void CrossFade(string name)
    {
        CrossFade(name, DefaultFadeTime);
    }

    private void CrossFade(string name, float fadeTime)
    {
        m_real_LastAnimation = name;
        if (mAnimationCtrl == null)
        {
            m_LastAnimation = name;
            return;
        }

        bool ret = mAnimationCtrl.CrossfadeAnimation(name, fadeTime);
        if (ret == false)
            GameDebug.LogWarning(string.Format("play animation failed, actor: {0}, animation: {1}", Name, name));

        if (mRideCtrl != null)
        {
            mRideCtrl.SyncAnim(name);
        }
    }

    public void SetAnimationSpeed(float speed)
    {
        if (mAnimationCtrl != null)
            mAnimationCtrl.SetAnimationSpeed(speed);
    }

    public float GetMoveSpeed(EAnimation type)
    {
        AnimationOptions op = GetAnimationOptions(type);
        if (null == op)
            return 1.0f;

        return op.Speed;
    }

    /// <summary>
    /// 获取走路的速度
    /// </summary>
    /// <returns></returns>
    public float GetWalkSpeed()
    {
        if (m_FinalSpeed <= 0.0f)
        {
            AnimationOptions op = GetWalkAniOptions();
            if (null == op)
                return 1.0f;
            else
                return op.Speed;
        }
        else
            return m_FinalSpeed;
    }

    /// <summary>
    /// 最终速度 = 属性*角色表中的原始速度
    /// </summary>
    float m_FinalSpeed = 0.0f;

    /// <summary>
    /// 设置行走\跑的速度
    /// </summary>
    public void SetMoveSpeedScale(float speed_scale, float speed_add)
    {
        speed_scale = Mathf.Clamp(speed_scale, 0.1f, 10.0f);

        AnimationOptions op = GetWalkAniOptions();

        float speed = 0f;
        if (op != null)
        {
            speed = op.OriSpeed * speed_scale + speed_add * 0.01f;// speed_add的属性是以cm为单位，需要除以100
            op.Speed = speed;
        }
        else
        {
            GameDebug.LogError("Walk animation option is null!!!  UID: " + this.UID.ToString());
        }

        m_FinalSpeed = speed;
        if (IsWalking())
            MoveSpeed = speed;

        if (this.IsPlayer())
        {
            Player player = this as Player;
            if (player != null)
            {
                player.UpdatePetMoveSpeed();
                player.UpdateEscortNPCMoveSpeed();
            }
        }
    }

    /// <summary>
    /// 设置行走\跑的动画速度
    /// </summary>
    /// <param name="speed"></param>
    public void SetMoveAnimationSpeed(float speed)
    {
        if (mAnimationCtrl != null)
            mAnimationCtrl.SetMoveSpeed(speed);
        if (mRideCtrl != null && mRideCtrl.Rider != null && mRideCtrl.Rider.IsDestroy == false)
            mRideCtrl.Rider.SetMoveAnimationSpeed(speed);
    }

    public float GetAnimationLength(string name)
    {
        if (mAnimationCtrl != null)
            return mAnimationCtrl.GetAnimationLength(name);
        else
            return 0.0f;
    }

    public bool IsPlaying(string ani_name)
    {
        if (mAnimationCtrl != null)
            return mAnimationCtrl.IsPlaying(ani_name);
        else
            return false;
    }

    /// <summary>
    /// 是否在指定的动画状态下
    /// </summary>
    /// <param name="ani"></param>
    /// <returns></returns>
    public bool IsInAnimationState(string ani)
    {
        if (null == mAnimationCtrl)
        {
            return false;
        }

        return mAnimationCtrl.IsInAnimationState(ani);
    }

    /// <summary>
    /// 是否正在播放动画
    /// </summary>
    public bool IsPlayingAnimation
    {
        get
        {
            if (null == mAnimationCtrl)
            {
                return false;
            }

            return mAnimationCtrl.IsPlaying();
        }
    }


    public bool HasAnimation(string ani_name)
    {
        if (mAnimationCtrl != null)
            return mAnimationCtrl.HasAnimation(ani_name);
        else
            return false;
    }

    public bool IsPlaying()
    {
        if (mAnimationCtrl != null)
            return mAnimationCtrl.IsPlaying();
        else
            return false;
    }
    #endregion

    #region 状态机
    public virtual bool BeginInteraction(string aniName)
    {
        if (mRideCtrl != null && mRideCtrl.IsRiding())
        {
            mRideCtrl.UnRide(true, () =>
            {
                mActorMachine.BeginInteraction(aniName);
            });

            return true;
        }
        else
        {
            return mActorMachine.BeginInteraction(aniName);
        }
    }

    /// <summary>
    /// 尝试进入切换场景的状态
    /// </summary>
    /// <param name="aniName"></param>
    /// <returns></returns>
    public bool BeginJumpScene(string aniName)
    {
        if (mRideCtrl != null && mRideCtrl.IsRiding())
        {
            mRideCtrl.UnRide(true, () =>
            {
                mActorMachine.BeginJumpScene(aniName);
            });

            return true;
        }
        else
        {
            return mActorMachine.BeginJumpScene(aniName);
        }
    }

    /// <summary>
    /// 角色走到目标点的移动方向
    /// </summary>
    public Vector3 MoveDir
    {
        get
        {
            if (mActorMachine != null)
                return mActorMachine.MoveDir;
            else
                return Vector3.zero;
        }
    }

    public bool IsBeAttacking()
    {
        if (mActorMachine != null)
            return mActorMachine.IsBeattacking;
        else
            return false;
    }

    public bool IsDead()
    {
        if (mActorMachine != null)
            return mActorMachine.IsDead();
        else
            return true;
    }

    public bool IsIdle()
    {
        if (mActorMachine != null)
            return mActorMachine.IsIdle();
        else
            return false;
    }

    /// <summary>
    /// 移动速度
    /// </summary>
    float m_MoveSpeed;
    public float MoveSpeed
    {
        set
        {
            m_MoveSpeed = value;
            if (IsWalking())
            {
                float scale = 1.0f;
                AnimationOptions op = GetWalkAniOptions();
                if(op != null)
                    scale = op.OriSpeed != 0 ? m_MoveSpeed / op.OriSpeed : 1.0f;

                // 设置动画的加速参数
                SetMoveAnimationSpeed(scale);
            }
        }

        get
        {
            return m_MoveSpeed;
        }
    }

    // 角色状态机
    ActorMachine mActorMachine;
    public ActorMachine ActorMachine
    {
        get
        {
            return mActorMachine;
        }
    }

    public bool IsWalking()
    {
        if (mActorMachine != null)
            return mActorMachine.IsWalking();
        else
            return false;
    }

    public bool IsAttacking()
    {
        if (mActorMachine != null)
            return mActorMachine.IsAttacking();
        else
            return false;
    }
    #endregion

    #region 移动接口
    public bool IsGrounded()
    {
        if (mMoveImpl != null)
        {
            return mMoveImpl.IsGrounded;
        }
        return false;
    }

    public void Freeze(uint flag)
    {
        Freeze(mMemFreezeTime, flag);
    }

    public void Freeze(float time, uint flag)
    {
        UnFreeze();
        mUpdateFlag = flag;
        mFreezeTime = Mathf.Max(time, mFreezeTime);
        m_IsFreeze = true;

        if (NeedUpdate(DBActor.UF_ANIMATION) == false) //冻结动画
        {
            if (mAnimationCtrl != null)
                mAnimationCtrl.Pause(true);
        }
    }

    public void UnFreeze()
    {
        m_IsFreeze = false;
        mFreezeTime = 0.0f;
        mUpdateFlag = DBActor.UF_ALL;

        if (mAnimationCtrl != null)
            mAnimationCtrl.Pause(false);
    }

    // 停止
    public virtual bool Stop()
    {
        if(MoveCtrl != null)
            MoveCtrl.Interrupt();

        if (mActorMachine != null)
            return mActorMachine.Stop();
        else
            return false;
    }

    public virtual bool Stand()
    {
        return mActorMachine.Stand();
    }

    public void SetPosition(Vector3 pos)
    {
        mMoveImpl.SetPosition(pos);
    }

    public void TurnDir(Vector3 dir)
    {
        dir.y = 0;
        if (dir != Vector3.zero)
            mTarget.forward = dir;
    }

    public void SetRotation(Quaternion rotation)
    {
        mTarget.rotation = rotation;
    }

    public Vector3 ForwardDir
    {
        get
        {
            return mTarget.forward;
        }
    }

    public virtual bool WalkTo(Vector3 dst)
    {
        return mActorMachine.WalkTo(dst);
    }

    public bool CanMove()
    {
        return (mActorMachine.IsWalking() || FSM.CanReact((uint)ActorMachine.EFSMEvent.DE_Walk)) && !DisableMoveState && mCurSkill == null;
    }

    public bool DisableMoveState
    {
        get
        {
            return GetBehavior<BattleStateBehavior>().IsMoveDisable;
        }
    }

    // 沿着指定方向行走
    public virtual bool WalkAlong(Vector3 dir)
    {
        bool r = mActorMachine.WalkAlong(dir);
        return r;
    }

    public virtual bool ReachDst()
    {
        return FSM.React((uint)ActorMachine.EFSMEvent.DE_ReachDst);
    }

    /// <summary>
    /// 在攻击时候改变移动方向
    /// </summary>
    /// <param name="dir">当在攻击中并且方向与之前不同时返回true</param>
    /// <returns></returns>
    public bool MoveDirInAttacking(Vector3 dir)
    {
        if (mActorMachine != null)
            return mActorMachine.MoveDirInAttacking(dir);
        else
            return false;
    }

    public virtual bool WalkAlongStop()
    {
        return Stand();
    }
    #endregion

    #region 技能和战斗
    public virtual bool Kill()
    {
        GetBehavior<BattleStateBehavior>().Reset();
        mSonActors.Clear();

        mBuffTipList.Clear();
        mDamageEffectList.Clear();

        // 死亡只播放最后一次伤害效果
        if (mDamagesValueList != null && mDamagesValueList.Count > 0)
        {
            DamageValueItem value = mDamagesValueList[mDamagesValueList.Count - 1];
            mDamagesValueList.Clear();
            mDamagesValueList.Add(value);
        }

        mEventCtrl.FireEvent((int)ActorEvent.DEAD, null);

        if (this is LocalPlayer)
        {
            xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.PLAYER_DEAD, null);
        }

        return mActorMachine.Kill();
    }

    public virtual bool Relive()
    {
        GetBehavior<BattleStateBehavior>().Reset();

        bool r = mActorMachine.Relive();
        if (r)
        {
            // 复活后重置移动速度
            SetMoveSpeedScale(mActorAttr.MoveSpeedScale * GlobalConst.AttrConvert, mActorAttr.MoveSpeedAdd);
            mActorAttr.HP = FullLife;
            mActorAttr.MP = FullMp;
        }

        return r;
    }

    // 被攻击
    public virtual void Beattacked(Damage dam)
    {
        // 根据dam，产生对应事件，让状态机切换到正确的被攻击状态，如：击飞，击退等。
        // ..
        if (mActorMachine.IsDead())
            return;

        if (m_MatEffectCtrl != null)
        {
            m_MatEffectCtrl.AddEffectMat(0.2f, MaterialEffectCtrl.MAT_TYPE.HURT_HIGHLIGHT, MaterialEffectCtrl.Priority.HURT);
        }

        mActorMachine.BeattackState(dam);

        if (mAI != null)
        {
            mAI.BeAttack(dam);
        }

        mEventCtrl.FireEvent((int)ActorEvent.BEATTACK, null);

        if (this is LocalPlayer)
        {
            ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.PLAYER_BE_ATTACKED, null);
        }
    }

    public bool IsMPEnough(int mp)
    {
        return mActorAttr.MP >= mp;
    }

    /// <summary>
    /// 使用技能进行攻击，如果当前不能攻击，则返回false
    /// </summary>
    public bool Attack(uint skill_id)
    {
        Skill skill = GetSelfSkill(skill_id);
        if (skill == null)
            return false;

        if (FSM.React((uint)ActorMachine.EFSMEvent.DE_NormalAttack))
        {
            // 这个技能可用，开始使用它
            skill.Begin();
            return true;
        }

        return false;
    }

    /// <summary>
    /// 是否处在变身状态
    /// </summary>
    /// <returns></returns>
    public bool IsShapeShift
    {
        get
        {
            if (mAvatarCtrl != null)
                return mAvatarCtrl.IsShapeShift;
            else
                return false;
        }

    }

    /// <summary>
    /// 变身状态的特殊标记
    /// </summary>
    public byte ShiftState
    {
        get
        {
            if (mAvatarCtrl != null)
                return mAvatarCtrl.ShiftState;
            else
                return 0;
        }
    }

    /// <summary>
    /// 是否处在变身/恢复加载模型过程中
    /// </summary>
    /// <returns></returns>
    public bool IsShapeProcessing
    {
        get
        {
            if (mAvatarCtrl != null)
                return mAvatarCtrl.IsShapeProcessing;
            else
                return false;
        }

    }

    /// <summary>
    /// 设置技能id到列表中，默认权重为100
    /// </summary>
    public void SetSkillCastInfo(List<uint> skillList)
    {
        GetBehavior<SkillInfoBehavior>().SetSkillCastInfo(skillList);
    }

    /// <summary>
    /// 添加技能id和释放的权重到技能列表中
    /// </summary>
    public void AddSkillCastInfo(uint uiSkillID, ushort rate)
    {
        GetBehavior<SkillInfoBehavior>().AddSkillCastInfo(uiSkillID, rate);
    }

    public int GetSkillCount()// 用于怪物ai和机器人ai中
    {
        return GetBehavior<SkillInfoBehavior>().GetSkillCount();
    }

    /// <summary>
    /// 得到技能Cast Info
    /// </summary>
    /// <param name="skillId"></param>
    /// <returns></returns>
    public SkillCastInfo GetSkillCastInfo(uint skillId)
    {
        return GetBehavior<SkillInfoBehavior>().GetSkillCastInfo(skillId);
    }

    public SkillCastInfo GetSkillIDByIndex(int index) // 根据idx获取技能数据
    {
        return GetBehavior<SkillInfoBehavior>().GetSkillIDByIndex(index);
    }

    // 设置当前激活的技能。
    // 使用Sill.Start函数时将自动调用此函数，一般不用在其他地方显示调用它
    public void SetCurSkill(Skill skill)
    {
        mCurSkill = skill;
    }

    public Skill GetCurSkill()
    {
        return mCurSkill;
    }

    public Skill GetSelfSkill(uint skillID)
    {
        return GetBehavior<SkillInfoBehavior>().GetSelfSkill(skillID);
    }

    public List<Skill> GetSkillList()
    {
        List<Skill> skillList = new List<Skill>();
        skillList.Clear();

        SkillInfoBehavior skillInfoBehavior = GetBehavior<SkillInfoBehavior>();
        for (int i = 0; i < skillInfoBehavior.GetSkillCount(); ++i)
        {
            skillList.Add(skillInfoBehavior.GetSelfSkill(skillInfoBehavior.GetSkillIDByIndex(i)));
        }

        return skillList;
    }

    // 战斗标签
    public byte WarTag
    {
        get { return ActorAttribute.WarTag; }
    }

    /// <summary>
    /// 技能的攻速
    /// </summary>
    public float AttackSpeed
    {
        set
        {
            mAttackSpeed = value;
            if (this.IsPlayer() && this is Player)
            {
                (this as Player).UpdatePetAttackSpeed();
            }
        }
        get
        {
            if (mAttackSpeed != 0)
                return mAttackSpeed;
            else
                return mActorAttr.AttackSpeedComb;
        }
    }

    float mAttackSpeed = 0.0f;

    /// <summary>
    /// 玩家的陣營,相同陣營不能相互攻擊
    /// </summary>
    public uint Camp
    {
        get
        {
            return mActorAttr.Camp;
        }
        set
        {
            if (this.IsLocalPlayer)
            {
                GameDebug.LogError("set localplayer Camp = " + value.ToString());
            }
            mActorAttr.Camp = value;
            //角色的名字在不同组下显示的颜色不一样
            if (IsResLoaded)
                SetNameText();
        }
    }

    public bool IsInSkillActionEndingStage()
    {
        if (AttackCtrl != null)
            return AttackCtrl.IsInSkillActionEndingStage();
        return false;
    }

    /// <summary>
    /// 结束“吟唱阶段”
    /// </summary>
    public void FinishCastingReadyStage()
    {
        if (!IsDead())
        {
            Skill skill = GetCurSkill();
            if (skill != null && skill.CurAction != null)
                skill.CurAction.FinishCastingReadyStage();
        }
    }
    #endregion

    #region 战斗状态
    /// <summary>
    /// 根据当前角色状态标志做对应的状态处理
    /// </summary>
    public void UpdateBattleState()
    {
        GetBehavior<BattleStateBehavior>().UpdateBattleState();
    }

    /// <summary>
    /// 角色是否处于隐身状态
    /// </summary>
    public bool IsActorInvisiable
    {
        get
        {
            return GetBehavior<BattleStateBehavior>().IsActorInvisiable;
        }
    }

    /// <summary>
    /// 是否处于不可选中和受击状态
    /// </summary>
	public bool IsNoStrike
    {
        get
        {
            return GetBehavior<BattleStateBehavior>().IsNoStrike;
        }
    }

    public bool IsActorBeattackDisable
    {
        get
        {
            return GetBehavior<BattleStateBehavior>().IsActorBeattackDisable || IsDead();
        }
    }

    /// <summary>
    /// 角色是否在冰冻状态
    /// </summary>
    public bool IsFreezeState
    {
        get
        {
            return GetBehavior<BattleStateBehavior>().IsFreezeState;
        }
    }

    /// <summary>
    /// 是否具备某种战斗状态
    /// </summary>
    public bool HasBattleState(BattleStatusType type)
    {
        return GetBehavior<BattleStateBehavior>().HasBattleState(type);
    }

    /// <summary>
    /// 是否可以被攻击
    /// </summary>
    public virtual bool CanBeHited()
    {
        //if (HasBattleState(BattleStatusType.BATTLE_STATUS_TYPE_SUPER))
        //    return false;
        if (IsActorInvisiable || IsNpc() || IsNoStrike)
            return false;
        return true;
    }

    /// <summary>
    /// 是否可以被选中
    /// </summary>
    public virtual bool CanBeChoosed()
    {
        return false;
    }

    const uint FreezeFlag = DBActor.UF_ALL & ~(DBActor.UF_ANIMATION | DBActor.UF_ACTION | DBActor.UF_AI);

    /// <summary>
    /// 进入冰冻状态
    /// </summary>
    public virtual void EnterFreezeState()
    {
        if (mCurSkill != null)
            mCurSkill.Interrupt();

        if (mSkillEffectPlayer != null)
            mSkillEffectPlayer.ClearEffects();

        Freeze(Mathf.Infinity, FreezeFlag);
        mEventCtrl.FireEvent((int)ActorEvent.EXITIDLE, null);
        if (IsLocalPlayer)
        {//冰冻，结束“吟唱”
            FinishCastingReadyStage();
        }
    }

    /// <summary>
    /// 退出冰冻状态
    /// </summary>
    public virtual void ExitFreezeState()
    {
        Stop();
        UnFreeze();
        Play(GetIdleAniOptions());
    }

    /// <summary>
    /// 进入晕眩状态
    /// </summary>
    public virtual void EnterDizzyState()
    {
        Stop();
        mEventCtrl.FireEvent((int)ActorEvent.EXITIDLE, null);
        Play("stun");

        if (IsLocalPlayer)//晕眩，结束“吟唱”
        {
            FinishCastingReadyStage();
        }
    }

    /// <summary>
    /// 退出晕眩状态
    /// </summary>
    public virtual void ExitDizzyState()
    {
        Stop();
    }

    /// <summary>
    /// 进入无敌状态
    /// </summary>
    public virtual void EnterSuperState()
    {
        if (IsLocalPlayer)
        {
            PKModeManagerEx.GetInstance().UpdatePKIcons();
        }
        else
        {
            UpdatePKIconImpl();
        }
    }

    /// <summary>
    /// 退出无敌状态
    /// </summary>
    public virtual void ExitSuperState()
    {
        if (IsLocalPlayer)
        {
            PKModeManagerEx.GetInstance().UpdatePKIcons();
        }
        else
        {
            UpdatePKIconImpl();
        }
    }

    /// <summary>
    /// 进入混乱状态
    /// </summary>
    public virtual void EnterChaosState()
    {
        mEventCtrl.FireEvent((int)ActorEvent.EXITIDLE, null);

        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_SET_CHAOS_MODE, new CEventObjectArgs(this, true));
    }

    /// <summary>
    /// 退出混乱状态
    /// </summary>
    public virtual void ExitChaosState()
    {
        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_SET_CHAOS_MODE, new CEventObjectArgs(this, false));
    }

    #endregion

    #region 战斗飘字和伤害特效
    /// <summary>
    /// 显示子弹命中后的受击特效
    /// </summary>
    public void ShowDamageEffectModel(AnimationEffect.ResInitData effectData)
    {
        if (effectData != null && Trans != null)
        {
            AnimationEffect.ResInitData kData = effectData.Clone();

            //受击特效绑定在角色骨骼上
            EffectManager.GetInstance().AddAnimationEffect(new AnimationEffect(kData, gameObject, this.Radius, null));
        }
    }

    /// <summary>
    /// 判断是否可以显示伤害飘字
    /// </summary>
    /// <param name="attacker_obj_idx"></param>
    /// <param name="defender"></param>
    /// <returns></returns>
    public static bool IsShowDamageWord(uint attacker_obj_idx, Actor defender)
    {
        if (defender == null)
            return false;
        Actor local_player = Game.GetInstance().GetLocalPlayer();
        if (local_player != null)
        {
            if (local_player.AttackCtrl != null &&
                local_player.AttackCtrl.CurSelectActor &&
                defender == local_player.AttackCtrl.CurSelectActor.BindActor)
            {
                return true;
            }
        }
        if (defender.IsGuardedNpc()) //SceneHelp.Instance != null && SceneHelp.Instance.IsInSecretDefendInstance
        {
            return true;
        }
        bool attackerParentActor_is_localPlayer = false;
        Actor attacker = ActorManager.Instance.GetActor(attacker_obj_idx);

        if (attacker != null && attacker.ParentActor == local_player)
        {

            attackerParentActor_is_localPlayer = true;
        }

        if (Game.GetInstance().LocalPlayerID != null && attacker_obj_idx != Game.GetInstance().LocalPlayerID.obj_idx && defender.IsLocalPlayer == false &&
            defender.ParentActor != local_player && attackerParentActor_is_localPlayer == false)
            return false;
        return true;
    }

    /// <summary>
    /// actor是否和主角是同一阵营
    /// </summary>
    /// <returns></returns>
    public bool IsLocalPlayerCamp()
    {
        if (IsLocalPlayer)
            return true;
        
        if (IsPet() && ParentActor != null && ParentActor.IsLocalPlayer)
        {//主角的魔仆
            return true;
        }
        return false;
    }
    /// <summary>
    /// Dos the damage. isPlayer 表示攻击者是否是玩家
    /// </summary>
    public virtual void DoDamage(uint attacker_obj_idx, int iDamageValue, float fShowDelayTime, bool bCritic, uint proto_damageEffectType)
    {
        if (mRideCtrl != null && mRideCtrl.IsRiding())
        {
            mRideCtrl.UnRide(true);
        }

        if (IsShowDamageWord(attacker_obj_idx, this) == false)
            return;

        if (iDamageValue > 0)
        {
            FightEffectHelp.FightEffectPanelType panel_type;
            bool defender_is_local_player_type = IsLocalPlayer || IsGuardedNpc();
            if (defender_is_local_player_type)
            {
                panel_type = FightEffectHelp.FightEffectPanelType.PlayerDamage;
                bCritic = false;    //玩家一定不会被暴击
            }
            else
            {
                panel_type = FightEffectHelp.FightEffectPanelType.MonsterDamage;
            }
            var playData = FightEffectHelp.GetFightEffectPlayData(panel_type);
            if (playData != null)
            {
                if (mDamageEffectList.Count >= playData.NormalContainerSize + playData.HurryContainerSize)
                    return;
            }
            DamageValueItem item = new DamageValueItem();
            item.value = iDamageValue;
            item.is_crit = bCritic;
            item.panel_type = panel_type;
            item.attacker_world_pos = Vector3.zero;
            Actor attacker = ActorManager.Instance.GetActor(attacker_obj_idx);

            FightEffectHelp.FightEffectType type;
            if (defender_is_local_player_type) //主角受击飘字
            {
                type = FightEffectHelp.FightEffectType.OurDamage;
            }
            else
            {
                if (attacker != null)
                {
                    bool attacker_is_localPlayer = false;//攻击者是主角
                    if (attacker.IsLocalPlayerCamp())
                        attacker_is_localPlayer = true;
                    else if(this.IsLocalPlayerCamp() == false)//防御者是非主角，也使用“攻击者是主角”的样式
                    {//攻击者和防御均是非主角的玩家
                        attacker_is_localPlayer = true;
                    }
                    if (attacker_is_localPlayer)
                    {//攻击者是主角
                        if(attacker.IsPet())
                        {
                            //主角的魔仆造成的伤害
                            if (item.is_crit)
                                type = FightEffectHelp.FightEffectType.CriticAttendantDamage;
                            else
                                type = FightEffectHelp.FightEffectType.Attendant_damage;
                        }
                        else
                        {
                            if (item.is_crit)
                                type = FightEffectHelp.FightEffectType.CriticEnemyDamage;
                            else
                                type = FightEffectHelp.FightEffectType.EnemyDamage;
                        }
                    }
                    else
                        type = FightEffectHelp.FightEffectType.EnemyDamage;
                }
                else
                    type = FightEffectHelp.FightEffectType.EnemyDamage;
            }

            if (proto_damageEffectType == (uint)Damage.EDamageEffect.DE_KILL)
                type = FightEffectHelp.FightEffectType.OneHitKill;

            item.effect_type = type;
            if (attacker != null && attacker.gameObject != null)
            {
                item.attacker_world_pos = attacker.gameObject.transform.position;
            }

            if(type == FightEffectHelp.FightEffectType.OneHitKill && attacker != null && attacker == this)
            {//自爆不显示飘字
                return;
            }

            if (mDamagesValueList == null)
                mDamagesValueList = new List<DamageValueItem>();
            mDamagesValueList.Add(item);
        }
    }

    protected IEnumerator WaitToShowDamageVal(float fTime, int iDamageValue, bool bCritic)
    {
        yield return new SafeCoroutine.SafeWaitForSeconds(fTime);
        if (mTarget == null || mIsDestroy)
            yield break;

        // 远程玩家在隐身时不显示伤害飘字
        if (!this.IsLocalPlayer && this.IsActorInvisiable)
            yield break;

        Vector3 pos = mTarget.position;
        pos.y += mMoveImpl.CharacterHeight;
        UIWidgetHelp kUIWidgetHelp = UIWidgetHelp.GetInstance();

        // 玩家收到的攻击在显示上没有暴击，跟普通攻击一样
        if (bCritic)
        {
            pos.y += mMoveImpl.CharacterHeight * 0.5f;

        }
        else
        {

        }
    }

    /// <summary>
    /// 播放伤害飘字
    /// </summary>
    /// <param name="iDamageValue"></param>
    /// <param name="bCritic"></param>
    /// <param name="displayTimeScale"></param>
    /// <param name="attacker_world_pos"></param>
    /// <param name="effect_type"></param>
    protected void ShowDamageVal(int iDamageValue, bool bCritic, float displayTimeScale, Vector3 attacker_world_pos, FightEffectHelp.FightEffectType effect_type)
    {
        if (mTarget == null || mIsDestroy)
        {
            GameDebug.LogWarning("call ShowDamageVal true");
            return;
        }

        // 远程玩家在隐身时不显示伤害飘字
        if (!this.IsLocalPlayer && this.IsActorInvisiable)
            return;

        UIWidgetHelp kUIWidgetHelp = UIWidgetHelp.GetInstance();

        if (bCritic)
        {
            kUIWidgetHelp.ShowDamageValue_Critic(iDamageValue, displayTimeScale, this.IsLocalPlayer, this, attacker_world_pos, effect_type);
        }
        else
        {
            kUIWidgetHelp.ShowDamageValue(iDamageValue, displayTimeScale, mUnitType, this.IsLocalPlayer, this, attacker_world_pos, effect_type);
        }
    }

    /// <summary>
    /// 播放特殊战斗飘字
    /// </summary>
    /// <param name="damageType"></param>
    /// <param name="attacker_obj_idx"></param>
    /// <param name="value"></param>
    /// <param name="show_percent"></param>
    /// <param name="push_str"></param>
    public void ShowDamageEffect(FightEffectHelp.FightEffectType damageType, uint attacker_obj_idx, long value = 0, bool show_percent = false, string push_str = "")
    {
        if (IsShowDamageWord(attacker_obj_idx, this) == false)
            return;

        var playData = FightEffectHelp.GetFightEffectPlayData(FightEffectHelp.FightEffectPanelType.DamageEffect);
        if (playData != null)
        {
            if (mDamageEffectList.Count >= playData.NormalContainerSize + playData.HurryContainerSize)
                return;
        }

        DamageEffect damageEffect = new DamageEffect();
        damageEffect.Value = value;
        damageEffect.EffectType = damageType;
        damageEffect.ShowPercent = show_percent;
        damageEffect.PushStr = push_str;
        mDamageEffectList.Add(damageEffect);
    }

    public float Alpha
    {
        set
        {
            float alpha = value;
            if (alpha >= 1.0f)
            {
                mVisibleCtrl.SetActorVisible(true, VisiblePriority.BUFF_STATE);
            }
            else if (alpha <= 0.0f)
            {
                mVisibleCtrl.SetActorVisible(false, VisiblePriority.BUFF_STATE);
            }
            else
            {
                mVisibleCtrl.SetActorVisible(true, VisiblePriority.BUFF_STATE);
            }
        }
    }

    public virtual void ResetEffect()
    {
        if (m_BuffCtrl != null)
            m_BuffCtrl.ResetAllEffectObj();
    }

    float mLastPlayerDamagePlayDeltaTimeBySeconds = 0f;
    void ProcessPlayerDamageDisplay()
    {
        mLastPlayerDamagePlayDeltaTimeBySeconds += Time.deltaTime;
        if (mDamagesValueList == null)
            return;
        if (mDamagesValueList.Count != 0)
        {

            var playData = FightEffectHelp.GetFightEffectPlayData(mDamagesValueList[0].panel_type);
            if (playData == null)
                return;
            float playDeltaTime = playData.NormalPlayDeltaTimeBySeconds;
            float displayTimeScale = 1;
            if (mDamagesValueList.Count > playData.NormalContainerSize)
            {
                playDeltaTime = playData.HurryPlayDeltaTimeBySeconds;
                displayTimeScale = playData.HurryPlayTimeBySeconds;
            }

            if (mLastPlayerDamagePlayDeltaTimeBySeconds < playDeltaTime)
            {
                return;
            }

            // 开始播放下一条信息
            mLastPlayerDamagePlayDeltaTimeBySeconds = 0;
            ShowDamageVal(mDamagesValueList[0].value, mDamagesValueList[0].is_crit, displayTimeScale, mDamagesValueList[0].attacker_world_pos, mDamagesValueList[0].effect_type);
            mDamagesValueList.RemoveAt(0);
        }
    }

    float mLastDamageEffectPlayDeltaTimeBySeconds = 0.0f;
    void ProcessDamageEffectDisplay()
    {
        mLastDamageEffectPlayDeltaTimeBySeconds += Time.deltaTime;

        if (mDamageEffectList.Count != 0)
        {
            var playData = FightEffectHelp.GetFightEffectPlayData(FightEffectHelp.FightEffectPanelType.DamageEffect);

            float playDeltaTime = playData.NormalPlayDeltaTimeBySeconds;
            //float playTimeBySeconds = playData.NormalPlayTimeBySeconds;
            float displayTimeScale = 1;
            if (mDamageEffectList.Count > playData.NormalContainerSize)
            {
                playDeltaTime = playData.HurryPlayDeltaTimeBySeconds;
                //playTimeBySeconds = playData.HurryPlayTimeBySeconds;
                displayTimeScale = playData.HurryPlayTimeBySeconds;
            }

            if (mLastDamageEffectPlayDeltaTimeBySeconds < playDeltaTime)
            {
                return;
            }

            xc.ui.UIWidgetHelp.GetInstance().ShowDamageEffect(mDamageEffectList[0].EffectType, mDamageEffectList[0].Value, displayTimeScale,
                this, mDamageEffectList[0].ShowPercent, mDamageEffectList[0].PushStr);
            mDamageEffectList.RemoveAt(0);
            mLastDamageEffectPlayDeltaTimeBySeconds = 0;
        }
    }

    public void ShowBuffTip(uint buffID)
    {
        var kInfo = DBManager.GetInstance().GetDB<DBBuffSev>().GetBuffInfo(buffID) as Buff.BuffInfo;
        if (kInfo != null && !string.IsNullOrEmpty(kInfo.name) && kInfo.is_show_tip)
        {
            mBuffTipList.Add(string.Format(xc.DBConstText.GetText("BATTLE_ADD_BUFF_TIPS_FORMAT"), kInfo.name));
        }
    }

    void ProcessFightBuffDisplay()
    {
        if (mBuffTipList.Count != 0)
        {
            // 开始播放下一条信息
            if (xc.ui.UIWidgetHelp.GetInstance().ShowBuffTip(mBuffTipList[0]))
                mBuffTipList.RemoveAt(0);
        }
    }

    void UpdateFightEffect()
    {
        ProcessPlayerDamageDisplay();
        ProcessDamageEffectDisplay();
        ProcessFightBuffDisplay();
    }

    #endregion

    #region 角色名字等组件
    /// <summary>
    /// 设置角色头顶名字、头衔、自动战斗标记、血条的显示和隐藏
    /// </summary>
    public void ShowTextBehaviors(bool show)
    {
        GetBehavior<TextNameBehavior>().EnableBehaviors(show);
        GetBehavior<HeadIconsBehavior>().EnableBehaviors(show);
        GetBehavior<HPProgressBarBehavior>().EnableBehaviors(show);
    }

    /// <summary>
    /// 显示、隐藏头顶名字
    /// </summary>
    /// <param name="show"></param>
    public void ShowTextName(bool show)
    {
        if (mVisibleCtrl.VisibleMode != EVisibleMode.Name)
        {
            if (show)
            {
                if (mTarget != null)
                    GetBehavior<TextNameBehavior>().Active(mTarget.gameObject);
                GetBehavior<TextNameBehavior>().EnableBehaviors(true);
            }
            else
                GetBehavior<TextNameBehavior>().EnableBehaviors(false);
        }

    }

    /// <summary>
    /// 创建角色头顶的名字组件
    /// </summary>
    protected virtual void SetNameStyle()
    {
        UI3DText.StyleInfo styleInfo = new UI3DText.StyleInfo();
        styleInfo.Offset = new Vector3(0, 2.8f, 0);
        styleInfo.HeadOffset = new Vector3(0, this.Height, 0);
        styleInfo.ScreenOffset = UI3DText.NameTextScreenOffset;
        styleInfo.Scale = Vector3.one;
        styleInfo.IsShowBg = false;
        styleInfo.SpritName = "";

        //更新归属
        xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
        CommonLuaInstanceState wildInstanceState = curState as CommonLuaInstanceState;
        if (wildInstanceState != null && wildInstanceState.DataBossBehaviour != null)
            styleInfo.IsShowAffiliationPanel = wildInstanceState.DataBossBehaviour.IsAffiliation(this);
        if (SceneHelp.Instance.IsInWorldBossExperienceInstance && this.IsLocalPlayer == false && this.IsPlayer() && this.IsDead())
        {
            styleInfo.LayoutIsVisiable = false;
        }
        else
            styleInfo.LayoutIsVisiable = true;
        if (this.IsLocalPlayer)
        {
            if (PKModeManagerEx.Instance.PKMode == GameConst.PK_MODE_PEACE)
            {//和平模式，不显示血条
                styleInfo.IsShowBar = false;
            }
            else
            {
                styleInfo.IsShowBar = true;
                styleInfo.HpBarName = UI3DText.LocalPlayerHpName;
            }
        }

        TextNameBehavior nameBehavoir = GetBehavior<TextNameBehavior>();
        if (nameBehavoir != null)
        {
            nameBehavoir.SetStyle(styleInfo);
        }
    }

    /// <summary>
    /// Sets the head icons.
    /// </summary>
    public virtual void SetHeadIcons(EHeadIcon icon_type)
    {
        return;
    }

    protected bool IsTeamIconShow = false;
    public void ShowTeamIcon(bool isShow)
    {
        IsTeamIconShow = isShow;

        SetHeadIcons(EHeadIcon.TEAM);
    }

    protected virtual string GetColorName(string name)
    {
        if (string.IsNullOrEmpty(OverridingName))
            name = RoleHelp.GetInstColorName(this, name);
        else
            name = OverridingName;

        return name;
    }

    public string GetNameText()
    {
        string name = "";
        Color color = Color.black;
        if (UID.type == (byte)EUnitType.UNITTYPE_PLAYER)// 角色为Player
            name = mUserName;// 用户自定义名字
        else if (UID.type == (byte)EUnitType.UNITTYPE_MONSTER || UID.type == (byte)EUnitType.UNITTYPE_NPC)// 角色为怪物或者NPC
        {
            // 如果是boss，则使用自定义名字
            if (IsBoss())
            {
                name = mUserName;
            }
            // 角色表中名字
            else
                name = mName;
        }

        return GetColorName(name);
    }

    /// <summary>
    /// 设置角色的头顶名字
    /// </summary>
    public void SetNameText()
    {
        string name = "";
        if (string.IsNullOrEmpty(OverridingName))
        {
            Color color = Color.black;
            var curState = Game.Instance.GetFSM().GetCurState() as CommonInstanceState;
            if (curState != null)
            {
                name = curState.ActorNameText(this);
            }
            else
            {
                name = GetNameText();
            }
        }
        else
            name = OverridingName;

        string guild_name = "";
        // 跨服状态显示玩家所在服务器，跟帮派名字是同一个控件
        if (DBInstanceTypeControl.Instance.ShowServerName(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType) == true)
        {
            if (SpanServerManager.Instance.IsSpaning == true)
            {
                if (mActorAttr.GuildId > 0)
                {
                    guild_name = string.Format("{0}\n", SpanServerManager.Instance.GetServerNameByUuid(UID.obj_idx));
                }
                else
                {
                    guild_name = SpanServerManager.Instance.GetServerNameByUuid(UID.obj_idx);
                }
            }
        }

        // 帮派
        if (mActorAttr.GuildId > 0)
        {
            string preStr = DBConstText.GetText("GUILD_SCENE_NAME");
            string color = "<color=#4ef269>";
            guild_name = string.Format("{0}{1}{2}{3}</color>", guild_name, color, preStr, mActorAttr.GuildName);
        }

        // 帮派联赛、跨服帮战阵营
        if (SceneHelp.Instance.IsInGuildLeagueInstance() == true
            || SceneHelp.Instance.IsInSpanGuildWarInstance() == true)
        {
            uint camp = GuildLeagueManager.Instance.GetGuildCamp(mActorAttr.GuildId);
            if (camp == 1)
            {
                guild_name = GameConst.COLOR_DARK_BLUE + DBConstText.GetText("GUILD_LEAGUE_BLUE_CAMP_SCENE_NAME") + "</color>" + guild_name;
            }
            else if (camp == 2)
            {
                guild_name = GameConst.COLOR_DARK_RED + DBConstText.GetText("GUILD_LEAGUE_RED_CAMP_SCENE_NAME") + "</color>" + guild_name;
            }
        }

        // 离线挂机中
        string hang_up_str = "";
        if (mActorAttr.State == GameConst.PLAYER_STATE_HANG)
        {
            string hangTips = DBConstText.GetText("GAME_PLAYER_STATE_HANG");
            string color = "<color=#ffea87>";
            hang_up_str = string.Format("{0}{1}</color>", color, hangTips);
        }

        TextNameBehavior behavoir = GetBehavior<TextNameBehavior>();
        if (behavoir != null)
        {
            behavoir.NameText = name;
            behavoir.SetGuildName(guild_name);
            behavoir.SetMateName(MateName);
            behavoir.SetHangUp(hang_up_str);

            // 头衔图标
            if (mActorAttr.Honor > 0)
                behavoir.SetHonor(mActorAttr.Honor);

            // 称号图标
            behavoir.SetTitle(mActorAttr.Title);
        }
    }

    bool mHPProgressBarIsActive = false;
    public bool HPProgressBarIsActive
    {
        set
        {
            mHPProgressBarIsActive = value;
        }
        get
        {
            return mHPProgressBarIsActive;
        }
    }

    /// <summary>
    /// 显示说话冒泡
    /// </summary>
    public bool ShowDialogBubble(string text, int time)
    {
        return GetBehavior<TextNameBehavior>().ShowDialogBubble(text, time);
    }

    /// <summary>
    /// 是否自动激活名字组件
    /// </summary>
    protected virtual bool AutoActiveTextName
    {
        get
        {
            return false;
        }
    }

    public BindEffectInfo InitBindEffectInfo(string effect, DBBuffSev.BindPos bind_pos, bool follow_target, float scale, bool auto_scale, int maxCount)
    {
        return GetBehavior<BindEffectBehavior>().InitBindEffectInfo(effect, bind_pos, follow_target, scale, auto_scale, maxCount);
    }
    #endregion RES_LOAD_INIT

    #region Unity消息响应
    public void NotifyTriggerEnter(Collider other)
    {
        OnTriggerEnter(other);
    }
    protected virtual void OnTriggerEnter(Collider other)
    { }

    public void NotifyTriggerExit(Collider other)
    {
        OnTriggerExit(other);
    }
    protected virtual void OnTriggerExit(Collider other)
    { }

    #endregion

    #region 属性访问器
    /// <summary>
    /// 获取创建时候的参数
    /// </summary>
    public Monster.CreateParam CreateParamInfo
    {
        get
        {
            return mCreateParam;
        }
    }

    public EVocationType VocationID
    {
        get { return mVocationID; }
        set { mVocationID = value; }
    }

    public ActorAttributeData ActorAttribute//返回角色属性数据
    {
        get { return mActorAttr; }
        set { mActorAttr = value; }
    }
    public uint NormalAttackID
    {
        get
        {
            return GetBehavior<SkillInfoBehavior>().NormalAttackID;
        }
    }

    public Transform ActorTrans
    {
        get
        {
            if (mRideCtrl != null && mRideCtrl.Rider != null)
            {
                if (mRideCtrl.Rider.mSkillEffectPlayer != null)
                    return mRideCtrl.Rider.mSkillEffectPlayer.transform;
                return mRideCtrl.Rider.transform;
            }
            return mTarget;
        }
    }

    // 角色状态的相关属性访问
    public ActorMachine.EWalkMode WalkMode
    {
        get
        {
            if (mActorMachine != null)
                return mActorMachine.WalkMode;
            else
                return ActorMachine.EWalkMode.EWM_Uninit;
        }
    }

    /// <summary>
    /// 自动寻路的路点
    /// </summary>
    public BetterList<Vector3> DestList
    {
        get
        {
            if (mActorMachine != null)
                return mActorMachine.DestList;
            else
            {
                return new BetterList<Vector3>();
            }
        }
    }
    public bool IsHaveSonActors
    {
        get
        {
            foreach (var item in mSonActors)
            {
                if (item != null)
                {
                    return true;
                }
            }

            return false;
        }
    }

    /// <summary>
    /// 服务器id
    /// </summary>
    public uint SvrId
    {
        get
        {
            return ActorHelper.GetSvrId(UID.obj_idx);
        }
    }

    public Actor ParentActor
    {
        get
        {
            if (m_ParentActor != null && m_ParentActor.IsAlive)
                return (Actor)m_ParentActor.Target;
            else
                return null;
        }
        set
        {
            if (m_ParentActor == null || !m_ParentActor.IsAlive)
                m_ParentActor = new WeakReference(value);
            else
                m_ParentActor.Target = value;
        }
    }

    public bool InBattleStatus
    {
        get { return m_InBattleStatus; }
        set
        {
            if (value != m_InBattleStatus)
            {
                m_InBattleStatus = value;
                FireActorEvent(ActorEvent.BATTLE_STATE_CHANGE, null);
                if (mRideCtrl != null)
                {
                    if (m_InBattleStatus == false && !(this is LocalPlayer && InstanceHelper.IsJumpingOut()))
                    {
                        mRideCtrl.Ride(mRideCtrl.RemotePlayerUsingRideId, false);
                    }
                }

            }
        }
    }

    public string OverridingName
    {
        get { return mOverridingName; }
        set
        {
            mOverridingName = value;
            SetNameText();
        }
    }

    public float Height
    {
        get
        {
            if (null != mMoveImpl)
                return mMoveImpl.CharacterHeight * RoleHelp.GetPrefabFloatScale(this.ActorId);
            return 0.0f;
        }
    }

    /// <summary>
    /// 未缩放过的高度数值
    /// </summary>
    public float CharacterHeight
    {
        get
        {
            if (null != mMoveImpl)
                return mMoveImpl.CharacterHeight;
            return 0.0f;
        }
    }

    public float Radius
    {
        get
        {
            if (null != mMoveImpl)
                return mMoveImpl.CharacterRadius;
            return 0.0f;
        }
    }

    public float HpPercent
    {
        get
        {
            if (FullLife == 0)
            {
                return 0f;
            }
            else
            {
                return (float)((double)CurLife / (double)FullLife);
            }
        }
    }

    public long CurLife
    {
        get
        {
            return mActorAttr.HP;
        }
        set
        {
            mActorAttr.HP = value;
            xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.EC_ACTOR_HP_CHANGE, new xc.ClientEventBaseArgs(this));
            FireActorEvent(ActorEvent.HP_CHANGE, new CEventBaseArgs(this));

            if (IsGuardedNpc())
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_GUARDED_NPC_HP_CHANGE, new CEventBaseArgs(this));


            // 怪物才显示血条
            if (EUnitType.UNITTYPE_MONSTER == mUnitType)
            {
                if (CurLife < FullLife)
                {
                    HPProgressBarIsActive = true;
                }
                else
                {
                    HPProgressBarIsActive = false;
                }
            }
        }
    }

    public long FullLife
    {
        get { return mActorAttr.HPMax; }
        set { mActorAttr.HPMax = value; }
    }

    public long CurMp
    {
        get { return mActorAttr.MP; }
        set
        {
            mActorAttr.MP = value;
            FireActorEvent(ActorEvent.MP_CHANGE, new CEventBaseArgs(this));
        }
    }

    public long FullMp
    {
        get { return mActorAttr.MPMax; }
        set { mActorAttr.MPMax = value; }
    }

    public string Name
    {
        get { return mName; }
    }

    public string UserName
    {
        get { return mUserName; }
        set { mUserName = value; }
    }

    public string MonsterSpecName
    {
        get { return mMonsterSpecName; }
        set { mMonsterSpecName = value; }
    }

    public uint TitleId
    {
        get { return mTitleIdx; }
        set { mTitleIdx = value; }
    }

    public uint TypeIdx
    {
        get { return mTypeIdx; }
    }

    /// <summary>
    /// 为了避免命名混淆，特别加了这个变量
    /// </summary>
    public uint ActorId
    {
        get
        {
            return TypeIdx;
        }
    }

    public int Level
    {
        get { return (int)mActorAttr.Level; }
    }

    public virtual uint TeamId
    {
        get { return mActorAttr.TeamId; }
    }

    public virtual uint EscortId
    {
        get { return mActorAttr.EscortId; }
    }

    public virtual uint Honor
    {
        get { return mActorAttr.Honor; }
    }

    public virtual uint Title
    {
        get { return mActorAttr.Title; }
    }

    public virtual uint TransferLv
    {
        get { return mActorAttr.TransferLv; }
        set { mActorAttr.TransferLv = value; }
    }

    /// <summary>
    /// 帮派ID
    /// </summary>
    public virtual uint GuildId
    {
        get { return mActorAttr.GuildId; }
    }

    /// <summary>
    /// 帮派名字
    /// </summary>
    public virtual string GuildName
    {
        get { return mActorAttr.GuildName; }
    }

    public string OverridingTargetName
    {
        get { return mOverridingTargetName; }
        set { mOverridingTargetName = value; }
    }

    public uint NameColor
    {
        set { mNameColor = value; }
        get { return mNameColor; }
    }

    public ulong BitStates
    {
        get { return mBitStates; }
    }

    public List<Actor> SonActors
    {
        get
        {
            return mSonActors;
        }
    }

    public bool IsResLoaded
    {
        get
        {
            return mResLoaded;
        }
    }

    public BuffCtrl BuffCtrl
    {
        get
        {
            return m_BuffCtrl;
        }
    }

    public bool NoUpdate
    {
        get
        {
            return mNoUpdate;
        }
        set
        {
            mNoUpdate = value;
        }
    }

    public SkillEffectPlayer SkillEffectPlayer
    {
        get
        {
            return mSkillEffectPlayer;
        }
    }

    public StateEffectPlayer StateEffectPlayer
    {
        get
        {
            return mStateEffectPlayer;
        }
    }

    public MoveImpl MoveImplement
    {
        get { return mMoveImpl; }
    }

    public EUnitType UnitType
    {
        get { return mUnitType; }
    }

    public xc.Machine FSM
    {
        get
        {
            if (mActorMachine != null)
                return mActorMachine.FSM;
            else
                return null;
        }
    }

    public UnitID UID
    {
        set { mUintID = value; }
        get { return mUintID; }
    }

    public Transform Trans
    {
        get { return mTarget; }
    }

    public AnimationController AnimationCtrl
    {
        get { return mAnimationCtrl; }
    }

    void OnSettingQualityChanged(CEventBaseArgs data)
    {
        SetNameText();
    }

    public Actor CurSelectActor
    {
        get
        {
            if (AttackCtrl != null)
            {
                ActorMono actorMono = AttackCtrl.CurSelectActor;
                if (actorMono != null)
                {
                    return actorMono.BindActor;
                }
            }

            return null;
        }
    }

    #endregion

    #region 虚函数接口
    /// <summary>
    /// 交互过程中是否能被攻击打断
    /// </summary>
    public virtual bool CanBeInterruptedWhenInInteractionAndBeAttacked { get; set; }

    /// <summary>
    /// 当对其他玩家造成伤害或者其他玩家攻击自己时，触发进入战斗状态的逻辑
    /// </summary>
    public virtual void OnBattleTrigger()
    {

    }

    public virtual void ActiveAI(bool active)
    {

    }

    public virtual bool IsBoss()
    {
        return false;
    }

    public virtual bool IsMonster()
    {
        return false;
    }

    public virtual bool IsPet()
    {
        return false;
    }

    public virtual bool IsPlayer()
    {
        return false;
    }

    public virtual bool IsNpc()
    {
        return false;
    }

    public virtual bool IsClientModel()
    {
        return false;
    }

    public virtual bool IsLocalPlayer
    {
        get
        {
            return false;
        }
    }

    public virtual void OnBecomeVisible(bool bVisible)
    {

    }

    public virtual void OnBecomeNameVisible()
    {

    }
    #endregion

    #region 野外逻辑
    private bool mIsInSafeArea = false;

    /// <summary>
    /// 是否在安全区（野外地图用）
    /// </summary>
    public bool IsInSafeArea
    {
        get
        {
            return mIsInSafeArea;
        }
        set
        {
            if (mIsInSafeArea == value)
            {
                return;
            }
            mIsInSafeArea = value;

            UpdatePKIconImpl();
        }
    }

    private EWildState mWildState = EWildState.Kill;
    public EWildState WildState
    {
        get { return mWildState; }
        set
        {
            mWildState = value;
            if (this is LocalPlayer)
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_ACTOR_FRIEND_MARCK_CHANGED, null);
            }
        }
    }

    public void UpdatePKIconImpl()
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

    public virtual void UpdateNameStyle()
    {
        //         if (IsShemale(mUintID.obj_idx))
        //             return;
        SetNameStyle();
    }

    public virtual void SetNameLayoutVisiable(bool is_visiable)
    {
        TextNameBehavior nameBehavoir = GetBehavior<TextNameBehavior>();
        if (nameBehavoir != null)
        {
            nameBehavoir.SetLayoutVisiable(is_visiable);
        }
    }
    /// <summary>
    /// 是否是人形怪（显示的是玩家的外观，但是在服务端被当作怪物处理）
    /// </summary>
    /// <param name="uuid"></param>
    /// <returns></returns>
    public bool IsShemale(uint uuid)
    {
        //return uuid >= GameConst.INIT_SHEMALE_UUID && uuid < GameConst.INIT_HUMAN_UUID;
        return ActorUtils.Instance.IsShemale(uuid);
    }

    public void UpdateByBitState(ulong bitStates)
    {
        mBitStates = bitStates;
        if (this.IsPlayer())
            (this as Player).UpdatePKMode(mBitStates);
        UpdatePKIconImpl();
    }

    public void UpdateNameColor(uint nameColor)
    {
        mNameColor = nameColor;
    }

    /// <summary>
    /// 判断是否可以攻击对方
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool CheckCanAttackOtherPlayer(Actor target)
    {
        bool show_tips = false;
        return PKModeManagerEx.GetInstance().IsEnemyRelation(this, target, ref show_tips);
    }

    #endregion

    #region 其他  
    public void AddSonActor(Actor son)
    {
        mSonActors.Add(son);
    }

    public void SetAIEnable(bool enable)
    {
        if (mAI != null)
        {
            mAI.Enabled = enable;
        }
    }

    public bool GetAIEnable()
    {
        if (mAI != null)
            return mAI.Enabled;
        else
            return false;
    }

    public AI GetAI()
    {
        return mAI;
    }

    uint m_mount_id;
    public uint MountId
    {
        get { return m_mount_id; }
        set
        {
            if (m_mount_id == value)
                return;
            m_mount_id = value;
            if (mRideCtrl != null)
            {
                mRideCtrl.RemotePlayerUsingRideId = m_mount_id;
                mRideCtrl.RemotePlayerServerStatusRiding = true;
            }

        }
    }

    /// <summary>
    /// 伴侣信息
    /// </summary>
    public PkgMateInfo MateInfo { set; get; }

    /// <summary>
    /// 伴侣唯一id
    /// </summary>
    public uint MateUuid
    {
        get
        {
            if (MateInfo != null)
            {
                return MateInfo.uuid;
            }
            return 0;
        }
    }

    /// <summary>
    /// 伴侣名称
    /// </summary>
    public string MateName
    {
        get
        {
            if (MateInfo != null)
            {
                return System.Text.Encoding.UTF8.GetString(MateInfo.name);
            }
            return string.Empty;
        }
    }

    //[DisableLuaBugFix]
    public bool NeedUpdate(uint flag)
    {
        return 0 != (mUpdateFlag & flag);
    }

    public void SetUpdateFlag(uint flag)
    {
        mUpdateFlag = flag;
    }

    public void SetAI(AI ai)
    {
        if (mAI != null)
        {
            mAI.OnDestroy();
        }
        mAI = ai;
    }

    public void SubscribeActorEvent(ActorEvent eEvent, EventCtrl.EventProcessFunc kFunc)
    {
        if (mEventCtrl != null)
            mEventCtrl.SubscribeEvent((int)eEvent, ref kFunc);
    }

    public void UnsubscribeActorEvent(ActorEvent eEvent, EventCtrl.EventProcessFunc kFunc)
    {
        if (mEventCtrl != null)
            mEventCtrl.UnSubscribeEvent((int)eEvent, ref kFunc);
    }

    public void UnsubscribeAllActorEvent(ActorEvent eEvent)
    {
        if (mEventCtrl != null)
            mEventCtrl.UnSubscribeAllEvent((int)eEvent);
    }

    public void FireActorEvent(ActorEvent eEvent, CEventBaseArgs data)
    {
        if (mEventCtrl != null)
            mEventCtrl.FireEvent((int)eEvent, data);
    }

    public void SetAvatarParent(Transform parent, Vector3 local_scale, Vector3 local_pos, Vector3 local_eulerAngles)
    {
        if (this.mAvatarCtrl != null)
            this.mAvatarCtrl.SetParent(parent, local_scale, local_pos, local_eulerAngles);
    }

    public virtual bool IsUIModel()
    {
        if (mCreateInfo != null)
            return mCreateInfo.IsUIModel;
        return false;
    }
    #endregion
}