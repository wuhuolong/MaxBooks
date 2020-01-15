//--------------------------------------------------------------
//  Desc: 远程玩家创建的宠物
//  Author: raorui
//  Date: 2016.5.31
//--------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;

// 宠物对象
[wxb.Hotfix]
public class RemotePet : Pet
{
    protected override void ResetCtrls()
    {
        base.ResetCtrls();

        AttackCtrl.mIsRecvMsg = true;

        BeattackedCtrl.mIsRecvMsg = true;
    }

    public override void AfterCreate()
    {
        base.AfterCreate();

        gameObject.name = "RemotePet_" + UID.obj_idx + "_" + ActorId;

        mVisibleCtrl.SetActorVisible(ShieldManager.Instance.SummonMonsterVisible, VisiblePriority.CULL);
    }

    /// <summary>
    /// 更新战斗属性
    /// </summary>
    public override void UpdateBattleAttribute()
    {
        base.UpdateBattleAttribute();
    }
}
