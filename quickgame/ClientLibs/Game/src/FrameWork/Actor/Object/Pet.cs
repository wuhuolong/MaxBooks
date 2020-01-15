/*
\brief 文件描述需要修改

Date:2016年03月21日

*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;

// 宠物对象
[wxb.Hotfix]
public class Pet : Monster
{
    /// <summary>
    /// 等级
    /// </summary>
    //public uint PetLevel { get; set; }

    /// <summary>
    /// 品质
    /// </summary>
    public uint PetId { get; set; }

    protected override void InitAOIData(xc.UnitCacheInfo info)
    {
        base.InitAOIData(info);

        PetId = info.AOIPet.pet_id;

        CreateParam createParam = mCreateParam as CreateParam;
        if (createParam == null)
            return;

        ParentActor = ActorManager.Instance.GetActor(createParam.master);

        if (ParentActor != null)
        {
            mActorAttr.Camp = ParentActor.ActorAttribute.Camp;
        }
        else
            Debug.LogError("Pet's parent is null, UID: " + info.UnitID.obj_idx);

     
        HPProgressBarIsActive = false;
        UpdateBattleAttribute();
    }

    public override void AfterCreate()
    {
        base.AfterCreate();
        UpdateBattleAttribute();
        ResetCtrls();
        ActiveAI(true);
        if (ParentActor != null && ParentActor.transform != null)
        {
            SetPosition(ParentActor.transform.position);
        }

#if UNITY_EDITOR
        gameObject.name = "Pet_" + UID.obj_idx + "_" + ActorId;
#endif
    }

    /// <summary>
    /// 销毁宠物
    /// </summary>
    public override void Destroy()
    {
        base.Destroy();

        // 在销毁宠物后，需要将拥有者的CurrentPet设置为null
        Player parent = ParentActor as Player;
        if(parent != null)
            parent.CurrentPet = null;
    }

    /// <summary>
    /// 宠物需要重写改函数，以取消发送MonsterDead消息
    /// </summary>
    protected override void AfterKill()
    {
        return;
    }

    /// <summary>
    /// 更新战斗属性
    /// </summary>
    public virtual void UpdateBattleAttribute()
    {
        if (ParentActor == null)
            return;
        this.AttackSpeed = ParentActor.AttackSpeed;

        mActorAttr.MoveSpeedScale = ParentActor.ActorAttribute.MoveSpeedScale;
        mActorAttr.MoveSpeedAdd = ParentActor.ActorAttribute.MoveSpeedAdd;

        AnimationOptions parent_actor_walk_options = ParentActor.GetWalkAniOptions();
        AnimationOptions op = GetWalkAniOptions();
        if(op != null && parent_actor_walk_options != null)
            op.Speed = parent_actor_walk_options.Speed;
        
    }

    protected virtual void ResetCtrls()
    {
        AttackCtrl.mIsSendMsg           = true;
        AttackCtrl.mIsRecvMsg           = false;
        AttackCtrl.mIsProcessInput      = false;
        
        BeattackedCtrl.mIsSendMsg       = false;
        BeattackedCtrl.mIsRecvMsg       = false;
        
        MoveCtrl.mIsProcessInput = false;
        MoveCtrl.mIsSendMsg = false;
        MoveCtrl.mIsRecvMsg = false;
    }

    /// <summary>
    /// 是否可以被选中
    /// </summary>
    public override bool CanBeChoosed()
    {
        return false;
    }

    public override bool IsPet()
    {
        return true;
    }

    public override bool Relive()
    {
        if(ParentActor != null && ParentActor.transform != null)
        {
            SetPosition(ParentActor.transform.position);
        }
        ActiveAI(true);

        ShadowBehavior behaviour = GetBehavior<ShadowBehavior>();
        if(behaviour != null)
            behaviour.InitColor();
        return base.Relive();
    }
}
