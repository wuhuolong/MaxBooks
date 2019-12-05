#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class SystemDateTimeWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(System.DateTime), L, translator, 5, 27, 13, 0);
			XUtils.RegisterFunc(L, XUtils.OBJ_META_IDX, "__add", __AddMeta);
            XUtils.RegisterFunc(L, XUtils.OBJ_META_IDX, "__eq", __EqMeta);
            XUtils.RegisterFunc(L, XUtils.OBJ_META_IDX, "__lt", __LTMeta);
            XUtils.RegisterFunc(L, XUtils.OBJ_META_IDX, "__le", __LEMeta);
            XUtils.RegisterFunc(L, XUtils.OBJ_META_IDX, "__sub", __SubMeta);
            
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Add", _m_Add);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddDays", _m_AddDays);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddTicks", _m_AddTicks);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddHours", _m_AddHours);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddMilliseconds", _m_AddMilliseconds);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddMinutes", _m_AddMinutes);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddMonths", _m_AddMonths);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddSeconds", _m_AddSeconds);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddYears", _m_AddYears);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CompareTo", _m_CompareTo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsDaylightSavingTime", _m_IsDaylightSavingTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Equals", _m_Equals);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToBinary", _m_ToBinary);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetDateTimeFormats", _m_GetDateTimeFormats);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTypeCode", _m_GetTypeCode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Subtract", _m_Subtract);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToFileTime", _m_ToFileTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToFileTimeUtc", _m_ToFileTimeUtc);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToLongDateString", _m_ToLongDateString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToLongTimeString", _m_ToLongTimeString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToOADate", _m_ToOADate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToShortDateString", _m_ToShortDateString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToShortTimeString", _m_ToShortTimeString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToString", _m_ToString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToLocalTime", _m_ToLocalTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToUniversalTime", _m_ToUniversalTime);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Date", _g_get_Date);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Month", _g_get_Month);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Day", _g_get_Day);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DayOfWeek", _g_get_DayOfWeek);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DayOfYear", _g_get_DayOfYear);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TimeOfDay", _g_get_TimeOfDay);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Hour", _g_get_Hour);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Minute", _g_get_Minute);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Second", _g_get_Second);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Millisecond", _g_get_Millisecond);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Ticks", _g_get_Ticks);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Year", _g_get_Year);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Kind", _g_get_Kind);
            
			
			XUtils.EndObjectRegister(typeof(System.DateTime), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(System.DateTime), L, __CreateInstance, 16, 3, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Compare", _m_Compare_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FromBinary", _m_FromBinary_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SpecifyKind", _m_SpecifyKind_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "DaysInMonth", _m_DaysInMonth_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Equals", _m_Equals_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FromFileTime", _m_FromFileTime_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FromFileTimeUtc", _m_FromFileTimeUtc_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FromOADate", _m_FromOADate_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsLeapYear", _m_IsLeapYear_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Parse", _m_Parse_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseExact", _m_ParseExact_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "TryParse", _m_TryParse_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "TryParseExact", _m_TryParseExact_xlua_st_);
            
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MaxValue", System.DateTime.MaxValue);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MinValue", System.DateTime.MinValue);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(System.DateTime));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Now", _g_get_Now);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Today", _g_get_Today);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "UtcNow", _g_get_UtcNow);
            
			
			XUtils.EndClassRegister(typeof(System.DateTime), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)))
				{
					long ticks = LuaAPI.lua_toint64(L, 2);
					
					System.DateTime __cl_gen_ret = new System.DateTime(ticks);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					int year = LuaAPI.xlua_tointeger(L, 2);
					int month = LuaAPI.xlua_tointeger(L, 3);
					int day = LuaAPI.xlua_tointeger(L, 4);
					
					System.DateTime __cl_gen_ret = new System.DateTime(year, month, day);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 7 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7))
				{
					int year = LuaAPI.xlua_tointeger(L, 2);
					int month = LuaAPI.xlua_tointeger(L, 3);
					int day = LuaAPI.xlua_tointeger(L, 4);
					int hour = LuaAPI.xlua_tointeger(L, 5);
					int minute = LuaAPI.xlua_tointeger(L, 6);
					int second = LuaAPI.xlua_tointeger(L, 7);
					
					System.DateTime __cl_gen_ret = new System.DateTime(year, month, day, hour, minute, second);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 8 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8))
				{
					int year = LuaAPI.xlua_tointeger(L, 2);
					int month = LuaAPI.xlua_tointeger(L, 3);
					int day = LuaAPI.xlua_tointeger(L, 4);
					int hour = LuaAPI.xlua_tointeger(L, 5);
					int minute = LuaAPI.xlua_tointeger(L, 6);
					int second = LuaAPI.xlua_tointeger(L, 7);
					int millisecond = LuaAPI.xlua_tointeger(L, 8);
					
					System.DateTime __cl_gen_ret = new System.DateTime(year, month, day, hour, minute, second, millisecond);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && translator.Assignable<System.Globalization.Calendar>(L, 5))
				{
					int year = LuaAPI.xlua_tointeger(L, 2);
					int month = LuaAPI.xlua_tointeger(L, 3);
					int day = LuaAPI.xlua_tointeger(L, 4);
					System.Globalization.Calendar calendar = (System.Globalization.Calendar)translator.GetObject(L, 5, typeof(System.Globalization.Calendar));
					
					System.DateTime __cl_gen_ret = new System.DateTime(year, month, day, calendar);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 8 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && translator.Assignable<System.Globalization.Calendar>(L, 8))
				{
					int year = LuaAPI.xlua_tointeger(L, 2);
					int month = LuaAPI.xlua_tointeger(L, 3);
					int day = LuaAPI.xlua_tointeger(L, 4);
					int hour = LuaAPI.xlua_tointeger(L, 5);
					int minute = LuaAPI.xlua_tointeger(L, 6);
					int second = LuaAPI.xlua_tointeger(L, 7);
					System.Globalization.Calendar calendar = (System.Globalization.Calendar)translator.GetObject(L, 8, typeof(System.Globalization.Calendar));
					
					System.DateTime __cl_gen_ret = new System.DateTime(year, month, day, hour, minute, second, calendar);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 9 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8) && translator.Assignable<System.Globalization.Calendar>(L, 9))
				{
					int year = LuaAPI.xlua_tointeger(L, 2);
					int month = LuaAPI.xlua_tointeger(L, 3);
					int day = LuaAPI.xlua_tointeger(L, 4);
					int hour = LuaAPI.xlua_tointeger(L, 5);
					int minute = LuaAPI.xlua_tointeger(L, 6);
					int second = LuaAPI.xlua_tointeger(L, 7);
					int millisecond = LuaAPI.xlua_tointeger(L, 8);
					System.Globalization.Calendar calendar = (System.Globalization.Calendar)translator.GetObject(L, 9, typeof(System.Globalization.Calendar));
					
					System.DateTime __cl_gen_ret = new System.DateTime(year, month, day, hour, minute, second, millisecond, calendar);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2)) && translator.Assignable<System.DateTimeKind>(L, 3))
				{
					long ticks = LuaAPI.lua_toint64(L, 2);
					System.DateTimeKind kind;translator.Get(L, 3, out kind);
					
					System.DateTime __cl_gen_ret = new System.DateTime(ticks, kind);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 8 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && translator.Assignable<System.DateTimeKind>(L, 8))
				{
					int year = LuaAPI.xlua_tointeger(L, 2);
					int month = LuaAPI.xlua_tointeger(L, 3);
					int day = LuaAPI.xlua_tointeger(L, 4);
					int hour = LuaAPI.xlua_tointeger(L, 5);
					int minute = LuaAPI.xlua_tointeger(L, 6);
					int second = LuaAPI.xlua_tointeger(L, 7);
					System.DateTimeKind kind;translator.Get(L, 8, out kind);
					
					System.DateTime __cl_gen_ret = new System.DateTime(year, month, day, hour, minute, second, kind);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 9 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8) && translator.Assignable<System.DateTimeKind>(L, 9))
				{
					int year = LuaAPI.xlua_tointeger(L, 2);
					int month = LuaAPI.xlua_tointeger(L, 3);
					int day = LuaAPI.xlua_tointeger(L, 4);
					int hour = LuaAPI.xlua_tointeger(L, 5);
					int minute = LuaAPI.xlua_tointeger(L, 6);
					int second = LuaAPI.xlua_tointeger(L, 7);
					int millisecond = LuaAPI.xlua_tointeger(L, 8);
					System.DateTimeKind kind;translator.Get(L, 9, out kind);
					
					System.DateTime __cl_gen_ret = new System.DateTime(year, month, day, hour, minute, second, millisecond, kind);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 10 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8) && translator.Assignable<System.Globalization.Calendar>(L, 9) && translator.Assignable<System.DateTimeKind>(L, 10))
				{
					int year = LuaAPI.xlua_tointeger(L, 2);
					int month = LuaAPI.xlua_tointeger(L, 3);
					int day = LuaAPI.xlua_tointeger(L, 4);
					int hour = LuaAPI.xlua_tointeger(L, 5);
					int minute = LuaAPI.xlua_tointeger(L, 6);
					int second = LuaAPI.xlua_tointeger(L, 7);
					int millisecond = LuaAPI.xlua_tointeger(L, 8);
					System.Globalization.Calendar calendar = (System.Globalization.Calendar)translator.GetObject(L, 9, typeof(System.Globalization.Calendar));
					System.DateTimeKind kind;translator.Get(L, 10, out kind);
					
					System.DateTime __cl_gen_ret = new System.DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime constructor!");
            
        }
        
		
        
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __AddMeta(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			try {
				if (translator.Assignable<System.DateTime>(L, 1) && translator.Assignable<System.TimeSpan>(L, 2))
				{
					System.DateTime leftside;translator.Get(L, 1, out leftside);
					System.TimeSpan rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside + rightside);
					
					return 1;
				}
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of + operator, need System.DateTime!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __EqMeta(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			try {
				if (translator.Assignable<System.DateTime>(L, 1) && translator.Assignable<System.DateTime>(L, 2))
				{
					System.DateTime leftside;translator.Get(L, 1, out leftside);
					System.DateTime rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of == operator, need System.DateTime!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __LTMeta(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			try {
				if (translator.Assignable<System.DateTime>(L, 1) && translator.Assignable<System.DateTime>(L, 2))
				{
					System.DateTime leftside;translator.Get(L, 1, out leftside);
					System.DateTime rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside < rightside);
					
					return 1;
				}
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of < operator, need System.DateTime!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __LEMeta(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			try {
				if (translator.Assignable<System.DateTime>(L, 1) && translator.Assignable<System.DateTime>(L, 2))
				{
					System.DateTime leftside;translator.Get(L, 1, out leftside);
					System.DateTime rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside <= rightside);
					
					return 1;
				}
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of <= operator, need System.DateTime!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __SubMeta(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			try {
				if (translator.Assignable<System.DateTime>(L, 1) && translator.Assignable<System.DateTime>(L, 2))
				{
					System.DateTime leftside;translator.Get(L, 1, out leftside);
					System.DateTime rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            
			try {
				if (translator.Assignable<System.DateTime>(L, 1) && translator.Assignable<System.TimeSpan>(L, 2))
				{
					System.DateTime leftside;translator.Get(L, 1, out leftside);
					System.TimeSpan rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of - operator, need System.DateTime!");
            
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Add(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    System.TimeSpan value;translator.Get(L, 2, out value);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.Add( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddDays(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    double value = LuaAPI.lua_tonumber(L, 2);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.AddDays( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddTicks(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    long value = LuaAPI.lua_toint64(L, 2);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.AddTicks( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddHours(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    double value = LuaAPI.lua_tonumber(L, 2);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.AddHours( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddMilliseconds(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    double value = LuaAPI.lua_tonumber(L, 2);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.AddMilliseconds( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddMinutes(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    double value = LuaAPI.lua_tonumber(L, 2);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.AddMinutes( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddMonths(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    int months = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.AddMonths( months );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSeconds(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    double value = LuaAPI.lua_tonumber(L, 2);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.AddSeconds( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddYears(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    int value = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.AddYears( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Compare_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.DateTime t1;translator.Get(L, 1, out t1);
                    System.DateTime t2;translator.Get(L, 2, out t2);
                    
                        int __cl_gen_ret = System.DateTime.Compare( t1, t2 );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareTo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object value = translator.GetObject(L, 2, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.CompareTo( value );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.DateTime>(L, 2)) 
                {
                    System.DateTime value;translator.Get(L, 2, out value);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.CompareTo( value );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime.CompareTo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDaylightSavingTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsDaylightSavingTime(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.DateTime>(L, 2)) 
                {
                    System.DateTime value;translator.Get(L, 2, out value);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Equals( value );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object value = translator.GetObject(L, 2, typeof(object));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Equals( value );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime.Equals!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToBinary(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        long __cl_gen_ret = __cl_gen_to_be_invoked.ToBinary(  );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromBinary_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    long dateData = LuaAPI.lua_toint64(L, 1);
                    
                        System.DateTime __cl_gen_ret = System.DateTime.FromBinary( dateData );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SpecifyKind_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.DateTime value;translator.Get(L, 1, out value);
                    System.DateTimeKind kind;translator.Get(L, 2, out kind);
                    
                        System.DateTime __cl_gen_ret = System.DateTime.SpecifyKind( value, kind );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DaysInMonth_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    int year = LuaAPI.xlua_tointeger(L, 1);
                    int month = LuaAPI.xlua_tointeger(L, 2);
                    
                        int __cl_gen_ret = System.DateTime.DaysInMonth( year, month );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.DateTime t1;translator.Get(L, 1, out t1);
                    System.DateTime t2;translator.Get(L, 2, out t2);
                    
                        bool __cl_gen_ret = System.DateTime.Equals( t1, t2 );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromFileTime_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    long fileTime = LuaAPI.lua_toint64(L, 1);
                    
                        System.DateTime __cl_gen_ret = System.DateTime.FromFileTime( fileTime );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromFileTimeUtc_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    long fileTime = LuaAPI.lua_toint64(L, 1);
                    
                        System.DateTime __cl_gen_ret = System.DateTime.FromFileTimeUtc( fileTime );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromOADate_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    double d = LuaAPI.lua_tonumber(L, 1);
                    
                        System.DateTime __cl_gen_ret = System.DateTime.FromOADate( d );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDateTimeFormats(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        string[] __cl_gen_ret = __cl_gen_to_be_invoked.GetDateTimeFormats(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    char format = (char)LuaAPI.xlua_tointeger(L, 2);
                    
                        string[] __cl_gen_ret = __cl_gen_to_be_invoked.GetDateTimeFormats( format );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        string[] __cl_gen_ret = __cl_gen_to_be_invoked.GetDateTimeFormats( provider );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.IFormatProvider>(L, 3)) 
                {
                    char format = (char)LuaAPI.xlua_tointeger(L, 2);
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 3, typeof(System.IFormatProvider));
                    
                        string[] __cl_gen_ret = __cl_gen_to_be_invoked.GetDateTimeFormats( format, provider );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime.GetDateTimeFormats!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeCode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        System.TypeCode __cl_gen_ret = __cl_gen_to_be_invoked.GetTypeCode(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLeapYear_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    int year = LuaAPI.xlua_tointeger(L, 1);
                    
                        bool __cl_gen_ret = System.DateTime.IsLeapYear( year );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Parse_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    
                        System.DateTime __cl_gen_ret = System.DateTime.Parse( s );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        System.DateTime __cl_gen_ret = System.DateTime.Parse( s, provider );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)&& translator.Assignable<System.Globalization.DateTimeStyles>(L, 3)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    System.Globalization.DateTimeStyles styles;translator.Get(L, 3, out styles);
                    
                        System.DateTime __cl_gen_ret = System.DateTime.Parse( s, provider, styles );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime.Parse!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseExact_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 3)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    string format = LuaAPI.lua_tostring(L, 2);
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 3, typeof(System.IFormatProvider));
                    
                        System.DateTime __cl_gen_ret = System.DateTime.ParseExact( s, format, provider );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 3)&& translator.Assignable<System.Globalization.DateTimeStyles>(L, 4)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    string format = LuaAPI.lua_tostring(L, 2);
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 3, typeof(System.IFormatProvider));
                    System.Globalization.DateTimeStyles style;translator.Get(L, 4, out style);
                    
                        System.DateTime __cl_gen_ret = System.DateTime.ParseExact( s, format, provider, style );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<string[]>(L, 2)&& translator.Assignable<System.IFormatProvider>(L, 3)&& translator.Assignable<System.Globalization.DateTimeStyles>(L, 4)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    string[] formats = (string[])translator.GetObject(L, 2, typeof(string[]));
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 3, typeof(System.IFormatProvider));
                    System.Globalization.DateTimeStyles style;translator.Get(L, 4, out style);
                    
                        System.DateTime __cl_gen_ret = System.DateTime.ParseExact( s, formats, provider, style );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime.ParseExact!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryParse_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    System.DateTime result;
                    
                        bool __cl_gen_ret = System.DateTime.TryParse( s, out result );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    translator.Push(L, result);
                        
                    
                    
                    
                    return 2;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)&& translator.Assignable<System.Globalization.DateTimeStyles>(L, 3)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    System.Globalization.DateTimeStyles styles;translator.Get(L, 3, out styles);
                    System.DateTime result;
                    
                        bool __cl_gen_ret = System.DateTime.TryParse( s, provider, styles, out result );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    translator.Push(L, result);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime.TryParse!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryParseExact_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 3)&& translator.Assignable<System.Globalization.DateTimeStyles>(L, 4)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    string format = LuaAPI.lua_tostring(L, 2);
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 3, typeof(System.IFormatProvider));
                    System.Globalization.DateTimeStyles style;translator.Get(L, 4, out style);
                    System.DateTime result;
                    
                        bool __cl_gen_ret = System.DateTime.TryParseExact( s, format, provider, style, out result );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    translator.Push(L, result);
                        
                    
                    
                    
                    return 2;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<string[]>(L, 2)&& translator.Assignable<System.IFormatProvider>(L, 3)&& translator.Assignable<System.Globalization.DateTimeStyles>(L, 4)) 
                {
                    string s = LuaAPI.lua_tostring(L, 1);
                    string[] formats = (string[])translator.GetObject(L, 2, typeof(string[]));
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 3, typeof(System.IFormatProvider));
                    System.Globalization.DateTimeStyles style;translator.Get(L, 4, out style);
                    System.DateTime result;
                    
                        bool __cl_gen_ret = System.DateTime.TryParseExact( s, formats, provider, style, out result );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    translator.Push(L, result);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime.TryParseExact!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Subtract(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.DateTime>(L, 2)) 
                {
                    System.DateTime value;translator.Get(L, 2, out value);
                    
                        System.TimeSpan __cl_gen_ret = __cl_gen_to_be_invoked.Subtract( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.TimeSpan>(L, 2)) 
                {
                    System.TimeSpan value;translator.Get(L, 2, out value);
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.Subtract( value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime.Subtract!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToFileTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        long __cl_gen_ret = __cl_gen_to_be_invoked.ToFileTime(  );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToFileTimeUtc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        long __cl_gen_ret = __cl_gen_to_be_invoked.ToFileTimeUtc(  );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToLongDateString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToLongDateString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToLongTimeString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToLongTimeString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToOADate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        double __cl_gen_ret = __cl_gen_to_be_invoked.ToOADate(  );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToShortDateString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToShortDateString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToShortTimeString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToShortTimeString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString( provider );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string format = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString( format );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 3)) 
                {
                    string format = LuaAPI.lua_tostring(L, 2);
                    System.IFormatProvider provider = (System.IFormatProvider)translator.GetObject(L, 3, typeof(System.IFormatProvider));
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString( format, provider );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.DateTime.ToString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToLocalTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.ToLocalTime(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToUniversalTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
            
            
            try {
                
                {
                    
                        System.DateTime __cl_gen_ret = __cl_gen_to_be_invoked.ToUniversalTime(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                        translator.Update(L, 1, __cl_gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Date(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked.Date);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Month(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Month);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Day(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Day);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DayOfWeek(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked.DayOfWeek);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DayOfYear(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.DayOfYear);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TimeOfDay(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked.TimeOfDay);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Hour(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Hour);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Minute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Minute);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Second(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Second);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Millisecond(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Millisecond);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Now(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, System.DateTime.Now);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Ticks(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.Ticks);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Today(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, System.DateTime.Today);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UtcNow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, System.DateTime.UtcNow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Year(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Year);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Kind(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.DateTime __cl_gen_to_be_invoked;translator.Get(L, 1, out __cl_gen_to_be_invoked);
                translator.Push(L, __cl_gen_to_be_invoked.Kind);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
