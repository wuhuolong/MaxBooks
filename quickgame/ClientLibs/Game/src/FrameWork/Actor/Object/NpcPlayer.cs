//------------------------------------------------------------------------------
// Desc   :  Npc Actor对象
// Author :  ljy
// Date   :  2017.6.1
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;
using xc.ui.ugui;
using SGameEngine;

// NPC
[wxb.Hotfix]
public class NpcPlayer : Player
{
    private Neptune.NPC mNpcData;
    public Neptune.NPC NpcData
    {
        get
        {
            return mNpcData;
        }
    }

    private NpcDefine mDefine;

    public NpcDefine Define
    {
        get
        {
            if (mDefine == null)
            {
                if (NpcData == null)
                {
                    return null;
                }

                mDefine = NpcHelper.MakeNpcDefine((uint)NpcData.ExcelId);
            }

            return mDefine;
        }
    }

    public bool CanClickNPC = true;

    private bool mIsTouching = false;
    private float mCurrentTime = 0.0f;

    private bool mIsClickedTouch = false;

    private bool mIsTurnedToLocalPlayer = false;

    private float mTouchSqrRadius;

    private Vector3 mOriginalDir;

    GameObject mSelectActorEffect;

    string mFollowAIFile = string.Empty;

    /// <summary>
    /// 走路动作的原始速度
    /// </summary>
    float mOriginalWalkAniSpeed = 0f;

    /// <summary>
    /// 动画播放速度
    /// </summary>
    float mAnimationSpeed = 1f;

    /// <summary>
    /// 是否是护送NPC
    /// </summary>
    public bool IsEscortNPC
    {
        get
        {
            if (Define != null)
            {
                return Define.Function == NpcDefine.EFunction.ESCORT;
            }

            return false;
        }
    }

    public void InitNPCData(Neptune.NPC data)
    {
        mNpcData = data;
        gameObject.layer = LayerMask.NameToLayer("Npc");
        CanClickNPC = true;

#if UNITY_EDITOR
        if (IsEscortNPC)
        {
            gameObject.name = "Npc_Escort_" + data.Id + "_" + data.ExcelId + "_" + ActorId + "_" + UID.obj_idx;
        }
        else
        {
            gameObject.name = "Npc_" + data.Id + "_" + data.ExcelId + "_" + ActorId + "_" + UID.obj_idx;
        }
#endif

        Stand();

        float radius = NpcHelper.MakeNpcDefine((uint)NpcData.ExcelId).Radius;
        mTouchSqrRadius = radius * radius;

        mOriginalDir = Trans.forward;
    }

    public bool IsLocalPlayerCloseEnoughToEnter
    {
        get
        {
            var player = Game.GetInstance().GetLocalPlayer();
            if (player == null)
                return false;

            if (player.transform == null)
            {
                return false;
            }

            return (player.transform.position - transform.position).sqrMagnitude < mTouchSqrRadius;
        }
    }

    bool IsLocalPlayerCloseEnoughToExit
    {
        get
        {
            var player = Game.GetInstance().GetLocalPlayer();
            if (player == null)
                return false;

            if (player.transform == null)
            {
                return false;
            }

            return (player.transform.position - transform.position).sqrMagnitude < mTouchSqrRadius;
        }
    }

    public override void InitBehaviors()
    {
        AddBehavior(new NpcHeadBehavior(this));

        base.InitBehaviors();
    }

    public override void OnResLoaded()
    {
        base.OnResLoaded();

        // 如果是间接创建的NPC，则在创建之后执行一下任务事件
        if (mNpcData.SpawnDirectly == false)
        {
            if (InstanceManager.Instance.IsOnHook == false && TargetPathManager.Instance.IsNavigating == false)
            {
                if (NpcManager.Instance.NpcCanGuide(this.NpcData.Id) == true)
                {
                    TaskHelper.TaskNpcGuide(this);
                }
                else
                {
                    NpcManager.Instance.RemoveNpcInDoNotGuideList(this.NpcData.Id);
                }
            }
        }

        if (IsEscortNPC == true)
        {
            // 护送NPC激活跟随AI
            this.ActiveFollowAI(true);

            // 护送NPC重新设置动画播放速度
            SetAnimationSpeed(mAnimationSpeed);

            // 播放出场动作
            //Play("enter");
        }
    }

    /// <summary>
    /// 是否是交互类型的NPC
    /// </summary>
    bool mIsInteractNPC = false;

    /// <summary>
    /// 交互特效名字
    /// </summary>
    static string mInteractEffectName = "InteractEffect";

    protected override void InitAOIData(xc.UnitCacheInfo info)
    {
        base.InitAOIData(info);

        ParentActor = info.ParentActor;
        UpdateBattleAttribute();
    }

    public override void AfterCreate()
    {
        base.AfterCreate();

        mIsInteractNPC = mCreateInfo.ClientNpcDefine.Function == NpcDefine.EFunction.INTERACTION;

        InitNPCData(mCreateInfo.ClientNpc);

        NpcManager.Instance.AddNpc(this);

        xc.Dungeon.LevelManager.Instance.SetAreaClose(mNpcData.Mark);

        // 读取配置表的待机动作
        m_AnimationMaps[EAnimation.idle] = new AnimationOptions();
        m_AnimationMaps[EAnimation.idle].Name = Define.IdleAni;

        AnimationOptions op = GetWalkAniOptions();
        if (op != null)
        {
            mOriginalWalkAniSpeed = op.OriSpeed;
        }

        // 这里要stop一下，不然配置的待机动作不生效
        if (IsIdle() == true)
        {
            Stop();
        }

        UpdateInteractEffect();
        UpdateBattleAttribute();

        // 护送NPC要重新激活一次头顶改名字
        if (IsEscortNPC && AutoActiveTextName)
            GetBehavior<TextNameBehavior>().Active(Trans.gameObject);
    }

    /// <summary>
    /// 根据npc的光照类型选择层级
    /// </summary>
    /// <returns></returns>
    public override int GetModelLayer()
    {
        if (Define != null)
        {
            if (Define.LightMode == NpcDefine.ELightMode.ROLE) // 角色光照
            {
                return base.GetModelLayer();
            }
            else if (Define.LightMode == NpcDefine.ELightMode.SCENE)    // 场景光照
            {
                return 0;
            }
        }

        return 0;
    }

    public override void OnModelChanged()
    {
        base.OnModelChanged();

        // 这里要stop一下，不然配置的待机动作不生效
        if (IsIdle() == true)
        {
            Stop();
        }
    }

    protected override string GetColorName(string name)
    {
        if (string.IsNullOrEmpty(OverridingName))
            return string.Format("<color=#FFFF00>{0}</color>", name);
        else
            return OverridingName;
    }

    /// <summary>
    /// 是否可以被选中
    /// </summary>
    public override bool CanBeChoosed()
    {
        return false;
    }

    public override void ActiveAI(bool active)
    {
        if (active)
        {
            if (mAI == null)
            {
                BehaviourNpcAI ai = new BehaviourNpcAI(this, mFollowAIFile);
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
        }
    }

    public void ActiveFollowAI(bool active)
    {
        mFollowAIFile = @"AI/normal_npc_follow.json";
        ActiveAI(active);
    }

    override public void Update()
    {
        if (this == null)
        {
            return;
        }

        base.Update();

        if (mNpcData == null)
        {
            return;
        }

        if (IsDead())
        {
            return;
        }

        if (mIsTouching == true)
        {
            if (IsLocalPlayerCloseEnoughToExit == false)
            {
                OnTouchExit();
            }
        }
        else
        {
            if (IsLocalPlayerCloseEnoughToEnter == true)
            {
                OnTouchEnter();
            }
        }
    }

    /// <summary>
    /// 因此NpcPlayer继承自Player，因此需要重写IsPlayer方法
    /// </summary>
    /// <returns></returns>
    public override bool IsPlayer()
    {
        return false;
    }

    public override bool IsNpc()
    {
        return true;
    }

    public void TurnToLocalPlayer()
    {
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();

        if (localPlayer != null && this != null/* && mIsTurnedToLocalPlayer == false*/)
        {
            Vector3 towardDir = localPlayer.transform.position - this.transform.position;
            towardDir.y = 0f;
            //this.TurnDir(towardDir);

            Quaternion rotation = Quaternion.LookRotation(towardDir);
            xc.ui.ugui.TweenRotation tween = xc.ui.ugui.TweenRotation.Begin(this.gameObject, 0.2f, rotation);
            tween.quaternionLerp = true;
            tween.onFinished = (t) =>
            {
                this.TurnDir(towardDir);
            };

            mIsTurnedToLocalPlayer = true;
        }
    }

    public void TurnToOriginalDir()
    {
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();

        if (localPlayer != null && this != null)
        {
            this.TurnDir(mOriginalDir);

            mIsTurnedToLocalPlayer = false;
        }
    }

    public override void OnBecomeVisible(bool bVisible)
    {
    }

    public override void Destroy()
    {
        base.Destroy();

        NpcManager.Instance.RemoveNpc(this);

        xc.Dungeon.LevelManager.Instance.SetAreaOpen(mNpcData.Mark);

        // 在销毁护送NPC后，需要将拥有者的CurrentEscortNPC设置为null
        if (IsEscortNPC == true)
        {
            Player parent = ParentActor as Player;
            if (parent != null)
                parent.CurrentEscortNPC = null;
        }
    }

    public bool FireNpcTouch()
    {
        if (mIsTouching && (!mIsClickedTouch && !IsInNavigating))
        {
            if (TaskHelper.ProcessTouchInteractTasksNpc(this) == true)
            {
                return true;
            }
        }

        if (!mIsTouching || (!mIsClickedTouch && !IsInNavigating))
        {
            // 当前触碰的npc是否是飞鞋传送过去的，如果是则不return
            if (NpcData.Id == TaskHelper.TransferingNpcId)
            {
                TaskHelper.TransferingNpcId = 0;
            }
            else
            {
                return false;
            }
        }

        return FireTouchEvent();
    }

    public bool FireTouchEvent()
    {
        if (!mIsTouching)
        {
            return false;
        }

        Actor localPlayer = Game.GetInstance().GetLocalPlayer();
        if (localPlayer != null && localPlayer.IsAttacking() == false)// 在释放技能时不能停止
        {
            localPlayer.Stop();
            localPlayer.MoveCtrl.TryWalkAlongStop();
        }

        if (TaskHelper.ProcessTouchTasksNpc(this) == false) // 任务npc逻辑
        {
            if (MarryHelper.ProcessTouchMarryNpc(this) == false)    // 结婚npc逻辑
            {
                NpcHelper.ProcessNpcFunction(this);
            }
        }

        TargetPathManager.Instance.StopPlayerAndReset(true, false);

        SetSelectEffect(true);
        //TurnToOriginalDir();

        bool isTurnToLocalPlayer = true;
        if (mDefine.Function == NpcDefine.EFunction.INTERACTION)
        {
            if (mDefine.FunctionParams[2] == "0")
            {
                isTurnToLocalPlayer = false;
            }
        }
        if (isTurnToLocalPlayer == true)
        {
            TurnToLocalPlayer();
        }

        return true;
    }

    protected override void OnTriggerEnter(Collider other)
    {

    }

    protected override void OnTriggerExit(Collider other)
    {

    }

    void OnTouchEnter()
    {
        // 护送NPC不处理
        if (IsEscortNPC == true)
        {
            return;
        }

        mIsTouching = true;

        FireNpcTouch();
        TargetPathManager.Instance.NotifyMetNpc((uint)NpcData.Id);
    }

    void OnTouchExit()
    {
        // 护送NPC不处理
        if (IsEscortNPC == true)
        {
            return;
        }

        mIsClickedTouch = false;

        mIsTouching = false;

        // 把对话关掉
        DialogManager.GetInstance().SkipDialog();

        UIManager.GetInstance().CloseSysWindow("UINpcDialogWindow");
        SetSelectEffect(false);
        TurnToOriginalDir();

        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_NPCLEAVED, new CEventBaseArgs(UID));
        ClientEventMgr.Instance.FireEvent((int)ClientEvent.INTERACT_TASK_NPC_UNTOUCHED, new CEventBaseArgs(this));

        CommonSliderHelper.Interrupt();
    }

    public bool IsTouching
    {
        get
        {
            return mIsTouching;
        }
    }

    public bool IsInNavigating
    {
        get
        {
            uint navigatingNpcId = NpcManager.Instance.NavigatingNpcId;
            if (navigatingNpcId > 0 && mNpcData != null)
            {
                return mNpcData.Id == navigatingNpcId;
            }
            return false;
        }
    }

    public void OnClicked()
    {
        // 护送NPC不能点击
        if (IsEscortNPC == true)
        {
            return;
        }

        if(!CanClickNPC)
        {
            return;
        }

        mIsClickedTouch = true;

        if (!IsLocalPlayerCloseEnoughToEnter)
        {
            OnUntouchingClicked();
        }
        else
        {
            FireNpcTouch();
        }
    }

    private void OnUntouchingClicked()
    {
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();
        if (localPlayer == null || localPlayer.IsDead() == true)
        {
            return;
        }

        TargetPathManager.Instance.Reset();

        if (NpcData == null)
        {
            return;
        }

        TargetPathManager.Instance.GoToNpcPos(SceneHelp.Instance.CurSceneID, (uint)NpcData.Id, null);
    }

    public override bool Kill()
    {
        bool isDead = base.Kill();

        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_NPCDEAD, new CEventBaseArgs(UID));

        return isDead;
    }

    public override void SetHeadIcons(EHeadIcon icon_type)
    {
        base.SetHeadIcons(icon_type);

        GetBehavior<NpcHeadBehavior>().BuildIcons();
    }

    void OnEffectResLoad(GameObject effectObject, Transform parentTrans)
    {
        mSelectActorEffect = effectObject;
        if (mSelectActorEffect != null && parentTrans != null)
        {
            Transform selectTrans = mSelectActorEffect.transform;
            selectTrans.parent = parentTrans;
            selectTrans.localPosition = new Vector3(0, 0.1f, 0);

            mSelectActorEffect.SetActive(true);
        }
    }

    public void SetSelectEffect(bool isSelect)
    {
        if (isSelect == true)
        {
            if (mSelectActorEffect == null)
            {
                EffectManager.GetInstance().GetEffectEmitter("Effects/Prefabs/EF_SelectActor_2.prefab").CreateInstance(x => OnEffectResLoad(x, this.transform));
            }
        }
        else
        {
            if (mSelectActorEffect != null)
            {
                GameObject.DestroyImmediate(mSelectActorEffect);
                mSelectActorEffect = null;
            }
        }
    }

    /// <summary>
    /// 开始互动（读条）
    /// </summary>
    public void StartInteract(System.Action finishCallback)
    {
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();

        if (localPlayer == null)
        {
            return;
        }

        localPlayer.Stop();
        localPlayer.MoveCtrl.TryWalkAlongStop();

        string localPlayerInteractionAni = "action_1";
        if (string.IsNullOrEmpty(Define.FunctionParams[4]) == false)
        {
            localPlayerInteractionAni = Define.FunctionParams[4];
        }
        bool ret = localPlayer.BeginInteraction(localPlayerInteractionAni);
        if (ret == false)
        {
            return;
        }

        // 如果该NPC配置有交互动画，则先播放，完毕后再处理回调
        string npcInteractionAni = string.Empty;
        if (string.IsNullOrEmpty(Define.FunctionParams[5]) == false)
        {
            npcInteractionAni = Define.FunctionParams[5];
        }
        if (string.IsNullOrEmpty(npcInteractionAni) == false)
        {
            Play(npcInteractionAni);
        }

        CommonSliderHelper.Interrupt();
        int second = 0;
        int.TryParse(Define.FunctionParams[0], out second);
        bool canBeInterruptedWhenBeAttacked = true;
        int canBeInterruptedWhenBeAttackedUint = 0;
        int.TryParse(Define.FunctionParams[3], out canBeInterruptedWhenBeAttackedUint);
        if (canBeInterruptedWhenBeAttackedUint > 0)
        {
            canBeInterruptedWhenBeAttacked = true;
        }
        else
        {
            canBeInterruptedWhenBeAttacked = false;
        }
        CommonSliderHelper.Start(second, Define.ConstBtnText, Define.ConstBtnPic,
        () =>
        {
            Play(EAnimation.idle);
        },
        () =>
        {
            if (mIsDestroy == true)
            {
                return;
            }

            SafeCoroutine.CoroutineManager.StartCoroutine(InteractEndCoroutine(npcInteractionAni, finishCallback));
        }, canBeInterruptedWhenBeAttacked);

        localPlayer.CanBeInterruptedWhenInInteractionAndBeAttacked = canBeInterruptedWhenBeAttacked;

        ClientEventMgr.Instance.FireEvent((int)ClientEvent.INTERACT_TASK_NPC_UNTOUCHED, new CEventBaseArgs(this));
        TargetPathManager.Instance.TaskNavigationActive(false);
    }

    IEnumerator InteractEndCoroutine(string npcInteractionAni, System.Action finishCallback)
    {
        if (this != null)
        {
            this.IsPlaying(npcInteractionAni);
        }

        yield return new SafeCoroutine.WaitForCondition(CanFinishInteract);

        if (finishCallback != null)
        {
            finishCallback();
        }

        int isDisappear = 0;
        int.TryParse(Define.FunctionParams[1], out isDisappear);
        if (isDisappear > 0)
        {
            NpcManager.Instance.DestroyNpc(this);
        }

        Actor localPlayer = Game.GetInstance().GetLocalPlayer();
        if (localPlayer != null)
        {
            localPlayer.Stop();
        }
    }

    bool CanFinishInteract()
    {
        if (this == null)
        {
            return true;
        }
        return !this.IsAttacking() || this.IsInSkillActionEndingStage();
    }

    /// <summary>
    /// 非护送的NPC不用自动显示头顶名字，在屏幕范围内才显示
    /// </summary>
    protected override bool AutoActiveTextName
    {
        get
        {
            if (IsEscortNPC)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 任务变化
    /// </summary>
    public void OnTaskChanged()
    {
        UpdateInteractEffect();
    }

    void UpdateInteractEffect()
    {
        Transform interactEffectTrans = GetModelParent().transform.Find(mInteractEffectName);

        // 交互NPC要加上特效
        if (mIsInteractNPC == true)
        {
            List<Task> needDoTasks = new List<Task>();
            needDoTasks.Clear();
            List<Task> needAcceptAndSubmitTasks = new List<Task>();
            needAcceptAndSubmitTasks.Clear();

            TaskHelper.GetNpcRelatedTasks(this, out needDoTasks, out needAcceptAndSubmitTasks);

            if (needDoTasks.Count > 0)
            {
                // 有任务且特效已经创建过了则什么都不干
                if (interactEffectTrans != null)
                {
                    return;
                }

                SGameEngine.ResourceLoader.Instance.LoadPrefabAsync("Assets/" + ResPath.EF_caiji_ty, (go) =>
                {
                    if (mIsDestroy == false)
                    {
                        go.name = mInteractEffectName;
                        go.transform.SetParent(GetModelParent().transform);
                        go.transform.localPosition = Vector3.zero;

                        float scale = 1f;
                        if (mDefine != null)
                        {
                            string param7 = mDefine.FunctionParams[6];
                            if (string.IsNullOrEmpty(param7) == false)
                            {
                                float.TryParse(param7, out scale);
                            }
                        }
                        go.transform.localScale = new Vector3(scale, scale, scale);
                    }
                    else
                    {
                        GameObject.DestroyImmediate(go);
                    }
                });
            }
            else
            {
                // 没任务且特效已经创建过了则删除特效
                if (interactEffectTrans != null)
                {
                    GameObject.DestroyImmediate(interactEffectTrans.gameObject);
                }
            }
        }
    }

    /// <summary>
    /// 更新战斗属性，主要是移动速度
    /// </summary>
    public void UpdateBattleAttribute()
    {
        if (ParentActor == null)
            return;

        if (mActorAttr != null)
        {
            if (ParentActor.ActorAttribute != null)
            {
                mActorAttr.MoveSpeedScale = (int)(ParentActor.ActorAttribute.MoveSpeedScale);
                mActorAttr.MoveSpeedAdd = (int)(ParentActor.ActorAttribute.MoveSpeedAdd);
                SetMoveSpeedScale(mActorAttr.MoveSpeedScale * GlobalConst.AttrConvert, mActorAttr.MoveSpeedAdd);
            }
        }

        AnimationOptions op = GetWalkAniOptions();
        if (op != null)
        {
            AnimationOptions parent_actor_walk_options = ParentActor.GetWalkAniOptions();
            if (parent_actor_walk_options != null)
                op.Speed = parent_actor_walk_options.Speed;

            // 护送NPC的走路动作要使用原始速度
            if (IsEscortNPC == true)
            {
                mAnimationSpeed = mOriginalWalkAniSpeed / op.Speed;
                SetAnimationSpeed(mAnimationSpeed);
            }
        }
    }


    //---------------------- 语音 start --------------------------------------------------------------------------------
    private float mPlayVoiceEndTime = 0;

    public int PlayRandomVoice()
    {
        if(Define != null && Define.VoiceIds != null && Define.VoiceIds.Count > 0)
        {
            int index = Random.Range(0, Define.VoiceIds.Count);
            PlayDialogVoice(Define.VoiceIds[index]);
            return index;
        }
        return -1;
    }

    public void PlayDialogVoice(uint voiceId)
    {
        if (voiceId <= 0)
            return;

        if (Time.time < mPlayVoiceEndTime)
            return;

        ResourceLoader.Instance.StartCoroutine(LoadAndPlayVoice(voiceId));
    }

    IEnumerator LoadAndPlayVoice(uint id)
    {
        var db = DBManager.Instance.GetDB<DBVoice>();
        string voicePath = db.GetVoicePath(id);
        if (voicePath == "")
        {
            yield break;
        }
        AssetResource ar = new AssetResource();
        yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(GlobalConst.ResPath + voicePath, typeof(Object), ar));

        if (ar.asset_ == null)
        {
            GameDebug.LogError(string.Format("the res {0} does not exist", voicePath));
            yield break;
        }

        GameObject model = GetModelParent();
        if (model == null)
        {
            ar.destroy();
            yield break;
        }
        AudioClip audio_clip = ar.asset_ as AudioClip;
        ResourceUtilEx.Instance.host_res_to_gameobj(model, ar);
        AudioManager.Instance.PlayBattleSFX(audio_clip, SoundType.NPC);

        mPlayVoiceEndTime = Time.time + audio_clip.length;
    }


    //---------------------- 语音 end --------------------------------------------------------------------------------

}