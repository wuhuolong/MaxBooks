using System;
namespace xc
{
    public enum ObjCachePoolType
    {
        TEXT_ASSET,
        JSON,
        AI,
        ACTOR,// 角色
        SMALL_PREFAB, // 小的prefab资源
        SFX, //技能特效
        AIJSON, // AI的JSON文件
        MACHINE, // 角色状态机
        STATE, // 角色状态
        UI_PREFAB,  //UI的prefab资源
        DROP_PREFAB,    // 掉落prefab资源
    }
}

