using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using xc.protocol;
using Net;

namespace xc
{
    class CommonHelper : xc.Singleton<CommonHelper>
    {
        public static Vector3 Pos_S2C(int x, int y)
        {
            Vector3 result = new Vector3(x * GlobalConst.UnitScale, 2.0f, y * GlobalConst.UnitScale);
            return result;
        }
    }
}
