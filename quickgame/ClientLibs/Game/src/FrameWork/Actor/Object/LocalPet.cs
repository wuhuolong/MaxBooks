//--------------------------------------------------------------
//  Desc: 本地玩家创建的宠物
//  Author: raorui
//  Date: 2016.5.30
//--------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;

// 宠物对象
[wxb.Hotfix]
public class LocalPet : Pet
{
    /// <summary>
    /// 更新战斗属性
    /// </summary>
    public override void UpdateBattleAttribute()
    {
        base.UpdateBattleAttribute();
    }

    public override void AfterCreate()
    {
        base.AfterCreate();

        SetSkillCastInfo(LocalPlayerManager.Instance.MainPetExSkills);

        GetBehavior<TextNameBehavior>().Active(Trans.gameObject);

        gameObject.name = "LocalPet_" + UID.obj_idx + "_" + ActorId;
    }

    public override void OnResLoaded()
    {
        base.OnResLoaded();

        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PET_CREATED, new CEventObjectArgs(this.UID.obj_idx, this.TypeIdx, this.PetId));

        GetBehavior<TextNameBehavior>().ClearNameText();
        GetBehavior<TextNameBehavior>().NameText = "";
    }
}
