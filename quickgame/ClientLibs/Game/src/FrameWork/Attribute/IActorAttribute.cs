using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public interface IActorAttribute
    {
        uint Id {set;get;}
        long Value {set;get;}
    }

    public enum AttrScoreGType : byte
    {
        Normal = 0,
        EquipBase,
        EquipStrength,
        EquipBaptize,
        DecorateBase,   // 饰品基础属性
        DecorateStrength, // 饰品强化属性
    }
}



