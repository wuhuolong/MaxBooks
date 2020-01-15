using System;
using System.Collections.Generic;
using UnityEngine;
using xc;
using BehaviourTree;

public class AINpcFunction : AIBaseFunction
{
    public override bool ConditionIsNeedFollowPlayer()
    {
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();

        if(localPlayer == null)
        {
            return false;
        }

        float distance = AIHelper.DistanceSquare(RunningProperty.SelfActorPos, localPlayer.transform.position);

        if(distance > 20.0f)
        {
            return true;
        }

        return false;
    }
    
    /// <summary>
    /// 是否看到本地玩家
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsSeeLocalPlayer()
    {
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();

        if (localPlayer == null || !localPlayer.IsResLoaded)
        {
            return false;
        }

        float distance = AIHelper.DistanceSquare(RunningProperty.SelfActorPos, localPlayer.transform.position);
        

        if (distance > RunningProperty.ViewRange * RunningProperty.ViewRange)
        {
            return false;
        }

        return true;
    }
}
