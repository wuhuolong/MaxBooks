using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;

namespace xc
{
	public class DBCommandList
	{
        public enum OPFlag
        {
            OP_None = 0,

            // 技能的按键信息
            OP_A = 1,
            OP_B,
            OP_C,
            OP_D,
            OP_E,
            OP_F,
            OP_G,
            OP_H,
            OP_I
        }

        /// <summary>
        /// 将int数据转化成按键的枚举数值
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public static DBCommandList.OPFlag BtnToOPFlag(uint btn)
        {
            if(btn >= (int)DBCommandList.OPFlag.OP_A && btn <= (int)DBCommandList.OPFlag.OP_I)
                return (DBCommandList.OPFlag)btn;
            else
                return DBCommandList.OPFlag.OP_None;
        }
	}
}

