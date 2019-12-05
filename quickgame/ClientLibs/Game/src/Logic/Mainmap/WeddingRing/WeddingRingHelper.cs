//-----------------------------------
// File: WeddingRingHelper.cs
// Desc: 婚戒工具类
// Author: luozhuocheng
// Date: 2018/11/7 16:16:26
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class WeddingRingHelper
    {
        public static Goods CreateWeddingRingByIdInfo(uint idInfo, XLua.LuaTable mateInfo)
        {
            if (idInfo <= 0)
                return null;

            return new GoodsWeddingRing(idInfo, mateInfo);
        }


    }
}
