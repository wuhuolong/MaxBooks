using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;
using xc;

public abstract class BehaviourAI : AI, BehaviourTree.IBehaviourEmployee
{
    protected AIRunningProperty mRunningProperty;
    protected BehaviourMachine mMachine;
    /// <summary>
    /// AI行为树 Key: AI Level; Value: AI行为树
    /// </summary>
    protected BehaviourTree.BehaviourTree mBehaviourTree = null;
    protected BehaviourTree.BehaviourTree mCurrentBehaviourTree;
    protected AIBaseFunction mFunction;
    protected AIActorPathWalker mPathWalker;
    protected AIAmbientState mAmbient;

    /// <summary>
    /// AI文件路径
    /// </summary>
    protected string mAIFile = "";

    /// <summary>
    /// 血量标记，用来标注什么时候切换下一级AI
    /// </summary>
    protected List<float> mAILevelHpBeacons = new List<float>();

    protected enum AILevelSwitchBeaconType : byte
    {
        SELF_HP = 0,
        LOCALPLAYER_HP
    }

    protected AILevelSwitchBeaconType mAILevelSwitchBeaconType = AILevelSwitchBeaconType.SELF_HP;

    /// <summary>
    /// 构造函数 抽象类不建议是public构造函数
    /// </summary>
    /// <param name="parent"></param>
    protected BehaviourAI(Actor parent)
    {
        mRunningProperty = new AIRunningProperty();
        mRunningProperty.SelfActor = parent;
        mRunningProperty.OriginalSelfActorPos = parent.transform.position;
        mRunningProperty.AI = this;
        mRunningProperty.ViewRange = GetActorViewRange();
        mPathWalker = new AIActorPathWalker(parent);

        mMachine = new BehaviourMachine(this);
        mAmbient = new AIAmbientState(this);
    }

    public override void Init()
    {
        InitBehaivorTree();
        InitAIFunction();

        mMachine.SwitchToState(BehaviourMachine.State.STAND);
    }

    public override void Reset()
    {
        mPathWalker.Reset();
        mRunningProperty.Reset();
    }

    public static readonly string AI_PATH_PREFIX = "Assets/Res";

    /// <summary>
    /// 先试图从预加载的bundle缓存中加载ai文件
    /// </summary>
    /// <param name="ai_file"></param>
    bool TryLoadAIFileImmediate(string ai_file)
    {
        // 先从缓存中读取ai文件的资源
        string path = string.Format(AI_PATH_PREFIX + "/{0}", ai_file);
        var text_asset = ResourceLoader.Instance.try_load_cached_asset(path) as TextAsset;
        if (text_asset == null)
        {
            return false;
        }

        // 解析失败则将Hashtable对象放回内存池
        var options = MiniJSON.JsonDecode(text_asset.text) as Hashtable;
        if (options == null)
        {
            //Resources.UnloadAsset(text_asset);
            return false;
        }

        //Resources.UnloadAsset(text_asset);

        // 解析成功创建BehaviourTree对象
        var behaviourTree = new BehaviourTree.BehaviourTree(ai_file, options, this);
        ObjCachePoolMgr.Instance.RecycleCSharpObject(options, ObjCachePoolType.AIJSON, ai_file);

        SetBehaviourTree(behaviourTree);
        return true;
    }

    /// <summary>
    /// 加载ai对应的文件
    /// </summary>
    /// <param name="aiFile"></param>
    /// <returns></returns>
    private IEnumerator LoadAIFile(string aiFile)
    {
        SGameEngine.AssetResource result = new SGameEngine.AssetResource();

        string path = string.Format(AI_PATH_PREFIX + "/{0}", aiFile);
        yield return MainGame.HeartBehavior.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset(path, typeof(TextAsset), result));

        if (result.asset_ == null)
        {
            GameDebug.LogError("BehaviourAI::LoadAIFile, read ai file error 1:" + aiFile);

            yield break;
        }

        TextAsset textAsset = result.asset_ as TextAsset;
        if (textAsset == null)
        {
            Debug.LogError("BehaviourAI::LoadAIFile,can not read ai file:" + aiFile);
            yield break;
        }

        var options = MiniJSON.JsonDecode(textAsset.text) as Hashtable;
        if (options == null)
        {
            result.destroy();
            yield break;
        }

        var behaviourTree = new BehaviourTree.BehaviourTree(aiFile, options, this);
        ObjCachePoolMgr.Instance.RecycleCSharpObject(options, ObjCachePoolType.AIJSON, aiFile);

        SetBehaviourTree(behaviourTree);

        result.destroy();
    }

    private void SetBehaviourTree(BehaviourTree.BehaviourTree behaviourTree)
    {
        mBehaviourTree = behaviourTree;
    }

    private BehaviourTree.BehaviourTree GetBehaviourTree()
    {
        return mBehaviourTree;
    }

    private void InitBehaivorTree()
    {
        string aiRawFiles = GetBehaivorTreeFile();

        if (string.IsNullOrEmpty(aiRawFiles))
            return;

        string aiFile = aiRawFiles;
        mAIFile = aiRawFiles;

        BehaviourTree.BehaviourTree behaviourTree = ObjCachePoolMgr.Instance.TryLoadCSharpObject<BehaviourTree.BehaviourTree>(ObjCachePoolType.AI, aiFile);
        if (behaviourTree == null)
        {
            Hashtable options = ObjCachePoolMgr.Instance.TryLoadCSharpObject<Hashtable>(ObjCachePoolType.AIJSON, aiFile);
            if (options == null)
            {
                if(!TryLoadAIFileImmediate(aiFile))
                    MainGame.HeartBehavior.StartCoroutine(LoadAIFile(aiFile));
            }
            else
            {
                behaviourTree = new BehaviourTree.BehaviourTree(aiFile, options, this);
                ObjCachePoolMgr.Instance.RecycleCSharpObject(options, ObjCachePoolType.AIJSON, aiFile);

                SetBehaviourTree(behaviourTree);
            }
        }
        else
        {
            behaviourTree.Reset(this);
            SetBehaviourTree(behaviourTree);
        }
    }
    /// <summary>
    /// 得到行为树文件
    /// </summary>
    /// <returns></returns>
    protected abstract string GetBehaivorTreeFile();
    /// <summary>
    /// 得到角色的视野范围
    /// </summary>
    /// <returns>视野范围</returns>
    protected abstract float GetActorViewRange();

    protected virtual void InitAIFunction()
    {
        mFunction = new AIBaseFunction();
        mFunction.RunningProperty = mRunningProperty;
    }

    protected virtual void ActiveImplement()
    {
 
    }

    public override void BeAttack(Damage damage)
    {
        base.BeAttack(damage);

        mAmbient.BeAttacked(damage);
    }

    /// <summary>
    /// 找到目标 Actor，默认是LocalPlayer
    /// </summary>
    /// <returns></returns>
    public virtual Actor GetDefaultTargetActor()
    {
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();

        if(localPlayer == null || localPlayer.IsActorInvisiable)
        {
            return null;
        }

        Vector3 localPlayerPos = localPlayer.transform.position;
        Vector3 selfPos = mRunningProperty.SelfActor.transform.position;

        float distanceSquare = (selfPos.x - localPlayerPos.x) * (selfPos.x - localPlayerPos.x) + (selfPos.y - localPlayerPos.y) * (selfPos.y - localPlayerPos.y) + (selfPos.z - localPlayerPos.z) * (selfPos.z - localPlayerPos.z);

        if (distanceSquare <= mRunningProperty.ViewRange * mRunningProperty.ViewRange)
        {
            return localPlayer;
        }

        return null;
    }

    public override void Active()
    {
        // Temp Test
        //UnityEngine.Time.timeScale = 0.1f;

        //mRunningProperty.TargetActor = GetDefaultTargetActor();

        mRunningProperty.RefreshState();
        mFunction.RunningProperty = mRunningProperty;


        mCurrentBehaviourTree = GetBehaviourTree();

        if(mCurrentBehaviourTree != null)
        {
            mCurrentBehaviourTree.Run();
        }

        ActiveImplement();
        mPathWalker.Update();
        mAmbient.Update();

        mMachine.Update();
    }

    public override void OnDestroy()
    {
        if(mBehaviourTree != null)
        {
            ObjCachePoolMgr.Instance.RecycleCSharpObject(mBehaviourTree, ObjCachePoolType.AI, mBehaviourTree.GetName());
            mBehaviourTree = null;
        }
        
        mAIFile = "";
    }

    protected virtual int GetAILevel()
    {
        return 0;
    }

    /// <summary>
    /// 随机设置将要攻击的技能
    /// </summary>
    public virtual void SetRandomSkill()
    {
        if (mRunningProperty.TargetSkill != null)
        {
            return;
        }

        if (mRunningProperty.SelfActor.UnitType != EUnitType.UNITTYPE_PLAYER)
        {
            int skillCount = mRunningProperty.SelfActor.GetSkillCount();
            if (skillCount <= 0)
            {
                Debug.LogError("AIBaseFunction::SetRandomSkill failed, do not have any skill");
                return;
            }

            Actor.SkillCastInfo skillInfo;
            ushort[] skillRates = new ushort[skillCount];
            ushort allRate = 0;
            for (int i = 0; i < skillCount; ++i)
            {
                skillInfo = RunningProperty.SelfActor.GetSkillIDByIndex(i);

                if(skillInfo == null)
                {
                    skillRates[i] = 0;
                    continue;
                }

                Skill skill = RunningProperty.SelfActor.GetSelfSkill(skillInfo.muiID);

                if(skill == null)
                {
                    skillRates[i] = 0;
                    continue;
                }

                if(RunningProperty.SelfActor.AttackCtrl.IsSkillCanCast(skill, 0) == false)
                {
                    skillRates[i] = 0;
                    continue;
                }

                skillRates[i] = (ushort)(skillInfo.mbtCastRate);
                allRate += skillInfo.mbtCastRate;
            }

            uint skillId = 0xffffffff;

            int rand = UnityEngine.Random.Range(0, allRate);
            int skillIndex = 0;

            ushort currentTotal = 0;
            for (int i = 0; i < skillRates.Length; i++)
            {
                currentTotal += skillRates[i];

                if (rand <= currentTotal)
                {
                    skillIndex = i;
                    break;
                }
            }

            skillId = RunningProperty.SelfActor.GetSkillIDByIndex(skillIndex);

            if (skillId != 0xffffffff)
            {
                //RunningProperty.TargetSkill = RunningProperty.SelfActor.GetSelfSkill(skillId);
                RunningProperty.TargetSkillId = skillId;
            }

            if (RunningProperty.TargetSkill == null)
            {
                Debug.LogError(string.Format("BehaviourAI::SetRandomSkill failed,{0} can not get skill:{1}", RunningProperty.SelfActor.TypeIdx, skillId));
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            List<uint> skillIds = new List<uint>();

            Dictionary<uint, Skill>.ValueCollection learnedSkills = SkillManager.GetInstance().GetLocalSkill();

            foreach (Skill skill in learnedSkills)
            {
                if(mRunningProperty.SelfActor.AttackCtrl.IsSkillCanCast(skill, 0) == false)
                {
                    continue;
                }

                if (skill != null)
                {
                    skillIds.Add(skill.SkillID);
                }
            }

            if(skillIds.Count <= 0)
            {
                string normalSkillRaw = string.Format("GAME_AI_NORMAL_SKILL_ID_ROLE_{0}", (int)RunningProperty.SelfActor.VocationID);
                uint skillId = GameConstHelper.GetUint(normalSkillRaw);

                if(skillId > 0)
                {
                    //RunningProperty.TargetSkill = RunningProperty.SelfActor.GetSelfSkill(skillId);
                    skillId = skillId;
                    UINotice.Instance.ShowMessage(xc.DBConstText.GetText("AI_TURN_TO_NORMAL_SKILL_TIPS"));
                }
            }

            // 随机技能
            int randIndex = UnityEngine.Random.Range(0, skillIds.Count);

            if(randIndex < skillIds.Count)
            {
                uint skillId = skillIds[randIndex];

                //RunningProperty.TargetSkill = RunningProperty.SelfActor.GetSelfSkill(skillId);
                skillId = skillId;
            }
        }

        return;
    }

    public BehaviourTree.BehaviourReturnCode RunAction(string action, object[] parameters)
    {
        return RunActionImplement(action, parameters);
    }

    public bool RunCondition(string condition, object[] parameters)
    {
        return RunConditionImplement(condition, parameters);
    }
    public float RunGetProperty(string property)
    {
        return 0.0f;
    }

    /// <summary>
    /// 初始化AI调节器数据
    /// </summary>
    protected virtual void InitModulatorActionImplement()
    { }

    protected virtual BehaviourTree.BehaviourReturnCode RunActionImplement(string action, object[] parameters)
    {
        if (action == "ActionFireEvent")
        {
            int eventId = (int)parameters[0];
            return mFunction.ActionFireEvent(eventId);
        }
        else if (action == "ActionTestRun")
        {
            return mFunction.ActionTestRun();
        }
        else if (action == "ActionReturnCode")
        {
            int returnCode = 0;
            if (parameters.Length >= 1)
            {
                returnCode = (int)parameters[0];
            }

            return mFunction.ActionReturnCode(returnCode);
        }
        else if (action == "ActionChaseTarget")
        {
            return mFunction.ActionChaseTarget();
        }
        else if (action == "ActionAttack")
        {
            return mFunction.ActionAttack();
        }
        else if (action == "ActionTryAttack")
        {
            return mFunction.ActionTryAttack();
        }
        else if (action == "ActionStand")
        {
            return mFunction.ActionStand();
        }
        else if (action == "ActionSetMostHateActorToTarget")
        {
            return mFunction.ActionSetMostHateActorToTarget();
        }
        else if (action == "ActionSetPlayerToTarget")
        {
            return mFunction.ActionSetPlayerToTarget();
        }
        else if (action == "ActionSetMonsterToTarget")
        {
            return mFunction.ActionSetMonsterToTarget();
        }
        else if (action == "ActionDoNothing")
        {
            return mFunction.ActionDoNothing();
        }
        else if (action == "ActionSetDefaultActorToTarget")
        {
            return mFunction.ActionSetDefaultActorToTarget();
        }
        else if (action == "ActionSetNeedCounterattackPlayerToTarget")
        {
            return mFunction.ActionSetNeedCounterattackPlayerToTarget();
        }
        else if (action == "ActionSetPlayerOrMonsterToTarget")
        {
            return mFunction.ActionSetPlayerOrMonsterToTarget();
        }
        else if (action == "ActionCleanCanNotAttackTarget")
        {
            return mFunction.ActionCleanCanNotAttackTarget();
        }
        else if (action == "ActionSuicide")
        {
            return mFunction.ActionSuicide();
        }
        else if (action == "ActionPatrol")
        {
            bool setCenterPos = false;
            if (parameters.Length >= 1)
            {
                setCenterPos = (bool)parameters[0];
            }

            return mFunction.ActionPatrol(setCenterPos);
        }
        else if (action == "ActionSetAILevelHpBeacons")
        {
            float beacon1 = (float)parameters[0];
            float beacon2 = 0.0f;

            // 是不是有三级AI还是有二级AI
            if (parameters.Length > 1)
            {
                beacon2 = (float)parameters[1];
            }

            int beaconType = 0;

            if (parameters.Length > 2)
            {
                beaconType = (int)parameters[2];
            }

            return mFunction.ActionSetAILevelHpBeacons(beacon1, beacon2, beaconType);
        }
        else if (action == "ActionFollowPlayer")
        {
            return mFunction.ActionFollowPlayer();
        }
        else if (action == "ActionSelectSkillAttack")
        {
            int skillId = (int)parameters[0];
            return mFunction.ActionSelectSkillAttack(skillId);
        }
        else if (action == "ActionSetLastSkillAndTargetToCurrent")
        {
            return mFunction.ActionSetLastSkillAndTargetToCurrent();
        }
        else if (action == "ActionWalkToOriginalPos")
        {
            return mFunction.ActionWalkToOriginalPos();
        }
        else if (action == "ActionTeleportToParentActorRangeRandomPosition")
        {
            float nearRadius = 0;
            float farRadius = 0;

            if (parameters.Length >= 1)
            {
                nearRadius = (float)parameters[0];
            }
            if (parameters.Length >= 2)
            {
                farRadius = (float)parameters[1];
            }

            return mFunction.ActionTeleportToParentActorRangeRandomPosition(nearRadius, farRadius);
        }
        else if (action == "ActionWalkToParentActorRangeRandomPosition")
        {
            float nearRadius = 0;
            float farRadius = 0;

            if (parameters.Length >= 1)
            {
                nearRadius = (float)parameters[0];
            }
            if (parameters.Length >= 2)
            {
                farRadius = (float)parameters[1];
            }

            return mFunction.ActionWalkToParentActorRangeRandomPosition(nearRadius, farRadius);
        }
        else
        {
            AIHelper.WriteErrorLog("BehaviourAI.RunActionImplement can not find action:" + action, this);
        }

        return BehaviourTree.BehaviourReturnCode.Success;
    }

    protected virtual bool RunConditionImplement(string condition, object[] parameters)
    {
        if (condition == "ConditionTargetIsInAttackRange")
        {
            return mFunction.ConditionTargetIsInAttackRange();
        }
        else if (condition == "ConditionIsSeeTarget")
        {
            return mFunction.ConditionIsSeeTarget();
        }
        else if (condition == "ConditionIsInMotionRange")
        {
            return mFunction.ConditionIsInMotionRange();
        }
        else if (condition == "ConditionIsNeedPatrol")
        {
            return mFunction.ConditionIsNeedPatrol();
        }
        else if(condition == "ConditionIsNeedFollowPlayer")
        {
            return mFunction.ConditionIsNeedFollowPlayer();
        }
        else if (condition == "ConditionHaveTargetDrop")
        {
            return mFunction.ConditionHaveTargetDrop();
        }
        else if (condition == "ConditionHaveTargetCollection")
        {
            return mFunction.ConditionHaveTargetCollection();
        }
        else if (condition == "ConditionSelfActorIsInteraction")
        {
            return mFunction.ConditionSelfActorIsInteraction();
        }
        else if (condition == "ConditionIsChasingOverrideTime")
        {
            float time = (float)parameters[0];
            return mFunction.ConditionIsChasingOverrideTime(time);
        }
        else if(condition == "ConditionIsStandingOverrideTime")
        {
            float time = (float)parameters[0];
            return mFunction.ConditionIsStandingOverrideTime(time);
        }
        else if(condition == "ConditionIsInSafaArea")
        {
            return mFunction.ConditionIsInSafaArea();
        }
        else if(condition == "ConditionIsInWildScene")
        {
            return mFunction.ConditionIsInWildScene();
        }
        else if (condition == "ConditionPlayerIsControlling")
        {
            return mFunction.ConditionPlayerIsControlling();
        }
        else if (condition == "ConditionIsHaveFollowInfo")
        {
            return mFunction.ConditionIsHaveFollowInfo();
        }
        else if (condition == "ConditionIsFarAwayFollowActor")
        {
            return mFunction.ConditionIsFarAwayFollowActor();
        }
        else if (condition == "ConditionIsInChaosState")
        {
            return mFunction.ConditionIsInChaosState();
        }
        else if (condition == "ConditionFollowActorIsAttacked")
        {
            return mFunction.ConditionFollowActorIsAttacked();
        }
        else if(condition == "ConditionIsIdle")
        {
            return mFunction.ConditionIsIdle();
        }
        else if(condition == "ConditionSelectSkillInCanFire")
        {
            return mFunction.ConditionSelectSkillInCanFire();
        }
        else if (condition == "ConditionIsWalking")
        {
            return mFunction.ConditionIsWalking();
        }
        else if (condition == "ConditionIsAttacking")
        {
            return mFunction.ConditionIsAttacking();
        }
        else if (condition == "ConditionIsAttackingOrBeAttacking")
        {
            return mFunction.ConditionIsAttackingOrBeAttacking();
        }
        else if (condition == "ConditionTargetSkillIsInBeforeSkillActionEndingStage")
        {
            return mFunction.ConditionTargetSkillIsInBeforeSkillActionEndingStage();
        }
        else if (condition == "ConditionIsWalkingToOriginalPos")
        {
            return mFunction.ConditionIsWalkingToOriginalPos();
        }
        else if (condition == "ConditionIsWalkingToDropPos")
        {
            return mFunction.ConditionIsWalkingToDropPos();
        }
        else if (condition == "ConditionIsWalkingToCollectionPos")
        {
            return mFunction.ConditionIsWalkingToCollectionPos();
        }
        else if (condition == "ConditionIsFarAwayParentActor")
        {
            float distanceSquare = 0f;

            if (parameters.Length >= 1)
            {
                distanceSquare = (float)parameters[0];
            }

            return mFunction.ConditionIsFarAwayParentActor(distanceSquare);
        }
        else if (condition == "ConditionIsNearParentActor")
        {
            float distanceSquare = 0f;

            if (parameters.Length >= 1)
            {
                distanceSquare = (float)parameters[0];
            }

            return mFunction.ConditionIsNearParentActor(distanceSquare);
        }
        else
        {
            AIHelper.WriteErrorLog("BehaviourAI.RunConditionImplement can not find condition:" + condition, this);
        }

        return true;
    }

    protected virtual float RunGetPropertyImplement(string property)
    {
        return 0.0f;
    }

    /// <summary>
    /// 设置AI等级切换的HP标记值
    /// </summary>
    /// <param name="beacon1"></param>
    /// <param name="beacon2"></param>
    public void SetAILevelHpBeacons(float beacon1, float beacon2, int beaconType)
    {
        mAILevelSwitchBeaconType = (AILevelSwitchBeaconType)beaconType;

        mAILevelHpBeacons.Clear();
        mAILevelHpBeacons.Add(beacon1);
        mAILevelHpBeacons.Add(beacon2);
    }

    /// <summary>
    /// 得到搭档列表，可能是怪物，也有可能是玩家
    /// </summary>
    protected Dictionary<UnitID, Actor> mPartners = new Dictionary<UnitID, Actor>();
    public virtual Dictionary<UnitID, Actor> GetPartners()
    {
        return mPartners;
    }

    /// <summary>
    /// 进行攻击
    /// </summary>
    /// <returns></returns>
    public bool DoAttack()
    {
        if(mRunningProperty == null)
        {
            return false;
        }

        if (mRunningProperty.TargetSkill == null)
        {
            return false;
        }

        if(mRunningProperty.SelfActor == null)
        {
            return false;
        }

        if(mRunningProperty.TargetActor == null)
        {
            return false;
        }

        if (mRunningProperty.TargetActor.IsDead() == true)
        {
            mRunningProperty.TargetSkillId = 0;
            mRunningProperty.TargetActor = null;

            return false;
        }

        //转向
        Vector3 parentPos = mRunningProperty.SelfActor.transform.position;

        if (mRunningProperty.TargetActor != null)
        {
            Vector3 targetPos = mRunningProperty.TargetActor.transform.position;

            Vector3 towardDir = targetPos - parentPos;
            Vector3 parentDir = mRunningProperty.SelfActor.transform.forward;
            if (towardDir != Vector3.zero/* && Vector3.Angle(towardDir, parentDir) > 90.0f*/)
            {
                if (mRunningProperty.SelfActor.CanMove() && mRunningProperty.SelfActor.ActorAttribute != null && mRunningProperty.SelfActor.ActorAttribute.AttackRotaion > 0)
                {
                    mRunningProperty.SelfActor.TurnDir(towardDir);
                }
            }
        }

        //         if(mRunningProperty.SelfActor.mRideCtrl.IsRiding())
        //         {
        //             mRunningProperty.SelfActor.mRideCtrl.UnRide();
        //         }

        //GameDebug.LogError("DoAttack: " + mRunningProperty.TargetSkill.SkillID);
        bool result = false;
        if (mRunningProperty.TargetSkill.IsNextActionInCD() == false && mRunningProperty.SelfActor.AttackCtrl.IsSkillCanCast(mRunningProperty.TargetSkill, 0) == true)
        {
            //GameDebug.LogError("DoAttack: " + mRunningProperty.TargetSkill.SkillID);
            //if(mRunningProperty.SelfActor.AttackCtrl.IsExchangeMountToBattleProcessing == false)
            result = mRunningProperty.SelfActor.AttackCtrl.Attack(mRunningProperty.TargetSkill.SkillID, true);
        }
        else
        {
            mRunningProperty.TargetSkillId = 0;
        }

        if (!result)
        {
            //GameDebug.LogError("BehaviourAI.DoAttack mRunningProperty.TargetSkill attack failed, skill id:" + mRunningProperty.TargetSkill.SkillID);
        }

        return result;
    }

    public string AIFile
    {
        get
        {
            return mAIFile;
        }
    }

    public BehaviourMachine Machine
    {
        get
        {
            return mMachine;
        }
    }

    public bool IsHaveTarget
    {
        get
        {
            if(mRunningProperty.TargetActor != null)
            {
                return true;
            }

            return false;
        }
    }

    public AIRunningProperty RunningProperty
    {
        get
        {
            return mRunningProperty;
        }
    }

    public AIBaseFunction AIFunction
    {
        get
        {
            return mFunction;
        }
    }

    public AIActorPathWalker PathWalker
    {
        get
        {
            return mPathWalker;
        }
    }

    public AIAmbientState Ambient
    {
        get
        {
            return mAmbient;
        }
    }
}