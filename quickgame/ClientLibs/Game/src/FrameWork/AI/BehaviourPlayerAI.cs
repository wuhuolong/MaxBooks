using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xc;

public class BehaviourPlayerAI : BehaviourAI
{
    protected AIPlayerFunction mPlayerFunction;

    private string mExclusiveAIFile = string.Empty;
    public BehaviourPlayerAI(LocalPlayer player)
        : base(player)
    {

    }

    public BehaviourPlayerAI(LocalPlayer player, string aiFile)
        : base(player)
    {
        mExclusiveAIFile = aiFile;
    }

    protected override float GetActorViewRange()
    {
        if (mRunningProperty.SelfActor == null)
        {
            return 99999.0f;
        }

        // 视野改成无限大
        //return mRunningProperty.SelfActor.ActorAttribute.EyesightRange;
        return 99999f;
    }

    protected override string GetBehaivorTreeFile()
    {
        if(!string.IsNullOrEmpty(mExclusiveAIFile))
        {
            return mExclusiveAIFile;
        }

        if(InstanceManager.Instance.IsPlayerVSPlayerType)
        {
            return @"AI/gvg_robot.json";
        }

        if (SceneHelp.Instance.IsInInstance)
        {
            // 副本里面活动半径是无限大
            mRunningProperty.MotionRadius = 999999f;
            //return @"AI/player_instance.json";
        }
        else
        {
            mRunningProperty.MotionRadius = GameConstHelper.GetFloat("GAME_AUTO_FIGHT_MOTION_RADIUS");
        }

        // 定点挂机
        //if (HookSettingManager.Instance.RangeType == EHookRangeType.FixedPos)
        //{
        //    mRunningProperty.MotionRadius = 0f;
        //}

        return @"AI/player.json";
    }

    protected override void InitAIFunction()
    {
        mPlayerFunction = new AIPlayerFunction();
        mFunction = mPlayerFunction;
    }

    public override Actor GetDefaultTargetActor()
    {
        return null;
    }

    protected override BehaviourTree.BehaviourReturnCode RunActionImplement(string action, object[] parameters)
    {
        if (action == "ActionWalkToInstanceEndPosition")
        {
            return mPlayerFunction.ActionWalkToInstanceEndPosition();
        }
        else if (action == "ActionSetAvailableSkill")
        {
            return mPlayerFunction.ActionSetAvailableSkill();
        }
        else if (action == "ActionOpenChest")
        {
            return mPlayerFunction.ActionOpenChest();
        }
        else if(action == "ActionUseHpDrug")
        {
            return mPlayerFunction.ActionUseHpDrug();
        }
        else if(action == "ActionWalkToClosestMine")
        {
            return mPlayerFunction.ActionWalkToClosestMine();
        }
        else if (action == "ActionSetTargetDrop")
        {
            return mPlayerFunction.ActionSetTargetDrop();
        }
        else if (action == "ActionSetTargetCollection")
        {
            return mPlayerFunction.ActionSetTargetCollection();
        }
        else if (action == "ActionWalkToTargetDrop")
        {
            return mPlayerFunction.ActionWalkToTargetDrop();
        }
        else if (action == "ActionWalkToTargetCollection")
        {
            return mPlayerFunction.ActionWalkToTargetCollection();
        }

        return base.RunActionImplement(action, parameters);
    }

    protected override bool RunConditionImplement(string condition, object[] parameters)
    {
        if(condition == "ConditionIsNeedOpenChest")
        {
            return mPlayerFunction.ConditionIsNeedOpenChest();
        }
        else if(condition == "ConditionIsOpeningChest")
        {
            return mPlayerFunction.ConditionIsOpeningChest();
        }
        else if(condition == "ConditionIsHaveCaveInWild")
        {
            return mPlayerFunction.ConditionIsHaveCaveInWild();
        }
        else if(condition == "ConditionIsSeeMine")
        {
            return mPlayerFunction.ConditionIsSeeMine();
        }
        else if(condition == "ConditionIsCanDigClosestMine")
        {
            return mPlayerFunction.ConditionIsCanDigClosestMine();
        }
        else if(condition == "ConditionIsMineFull")
        {
            return mPlayerFunction.ConditionIsMineFull();
        }
        else if(condition == "ConditionClosetMineIsNearThanMonster")
        {
            return mPlayerFunction.ConditionClosetMineIsNearThanMonster();
        }

        return base.RunConditionImplement(condition, parameters);
    }
}
