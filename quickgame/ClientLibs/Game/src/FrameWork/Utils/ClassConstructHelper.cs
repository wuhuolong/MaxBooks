using System;
using System.Collections.Generic;

namespace xc
{
    public class ClassConstructHelper
    {
        public static UnityEngine.Rect ConstructRect(float left, float top, float width, float height)
        {
            return new UnityEngine.Rect(left, top, width, height);
        }

        public static xc.Machine.State ConstructCommonInstanceState(string lua_script, uint id, xc.Machine machine)
        {
            return new CommonLuaInstanceState(lua_script, id, machine);
        }

        public static DateTime ConstructDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
