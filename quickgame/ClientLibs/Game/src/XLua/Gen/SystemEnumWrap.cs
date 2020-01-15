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
    public class SystemEnumWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(System.Enum), L, translator, 0, 5, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTypeCode", _m_GetTypeCode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CompareTo", _m_CompareTo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToString", _m_ToString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Equals", _m_Equals);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			
			
			
			
			XUtils.EndObjectRegister(typeof(System.Enum), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(System.Enum), L, __CreateInstance, 9, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetValues", _m_GetValues_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetNames", _m_GetNames_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetName", _m_GetName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsDefined", _m_IsDefined_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetUnderlyingType", _m_GetUnderlyingType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Parse", _m_Parse_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ToObject", _m_ToObject_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Format", _m_Format_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(System.Enum));
			
			
			XUtils.EndClassRegister(typeof(System.Enum), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "System.Enum does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeCode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Enum __cl_gen_to_be_invoked = (System.Enum)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.TypeCode __cl_gen_ret = __cl_gen_to_be_invoked.GetTypeCode(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetValues_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    
                        System.Array __cl_gen_ret = System.Enum.GetValues( enumType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNames_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    
                        string[] __cl_gen_ret = System.Enum.GetNames( enumType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetName_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    object value = translator.GetObject(L, 2, typeof(object));
                    
                        string __cl_gen_ret = System.Enum.GetName( enumType, value );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDefined_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    object value = translator.GetObject(L, 2, typeof(object));
                    
                        bool __cl_gen_ret = System.Enum.IsDefined( enumType, value );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUnderlyingType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    
                        System.Type __cl_gen_ret = System.Enum.GetUnderlyingType( enumType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
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
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    string value = LuaAPI.lua_tostring(L, 2);
                    
                        object __cl_gen_ret = System.Enum.Parse( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<System.Type>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    string value = LuaAPI.lua_tostring(L, 2);
                    bool ignoreCase = LuaAPI.lua_toboolean(L, 3);
                    
                        object __cl_gen_ret = System.Enum.Parse( enumType, value, ignoreCase );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Enum.Parse!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareTo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Enum __cl_gen_to_be_invoked = (System.Enum)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object target = translator.GetObject(L, 2, typeof(object));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.CompareTo( target );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
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
            
            
            System.Enum __cl_gen_to_be_invoked = (System.Enum)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string format = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString( format );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Enum.ToString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToObject_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    byte value = (byte)LuaAPI.lua_tonumber(L, 2);
                    
                        object __cl_gen_ret = System.Enum.ToObject( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    short value = (short)LuaAPI.xlua_tointeger(L, 2);
                    
                        object __cl_gen_ret = System.Enum.ToObject( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    int value = LuaAPI.xlua_tointeger(L, 2);
                    
                        object __cl_gen_ret = System.Enum.ToObject( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isint64(L, 2))) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    long value = LuaAPI.lua_toint64(L, 2);
                    
                        object __cl_gen_ret = System.Enum.ToObject( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    sbyte value = (sbyte)LuaAPI.xlua_tointeger(L, 2);
                    
                        object __cl_gen_ret = System.Enum.ToObject( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    ushort value = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                        object __cl_gen_ret = System.Enum.ToObject( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    uint value = LuaAPI.xlua_touint(L, 2);
                    
                        object __cl_gen_ret = System.Enum.ToObject( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) || LuaAPI.lua_isuint64(L, 2))) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    ulong value = LuaAPI.lua_touint64(L, 2);
                    
                        object __cl_gen_ret = System.Enum.ToObject( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 1)&& translator.Assignable<object>(L, 2)) 
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    object value = translator.GetObject(L, 2, typeof(object));
                    
                        object __cl_gen_ret = System.Enum.ToObject( enumType, value );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Enum.ToObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Enum __cl_gen_to_be_invoked = (System.Enum)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object obj = translator.GetObject(L, 2, typeof(object));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Equals( obj );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Enum __cl_gen_to_be_invoked = (System.Enum)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Format_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Type enumType = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    object value = translator.GetObject(L, 2, typeof(object));
                    string format = LuaAPI.lua_tostring(L, 3);
                    
                        string __cl_gen_ret = System.Enum.Format( enumType, value, format );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
