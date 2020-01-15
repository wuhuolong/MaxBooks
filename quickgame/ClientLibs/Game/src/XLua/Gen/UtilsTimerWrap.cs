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
    public class UtilsTimerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Utils.Timer), L, translator, 0, 5, 8, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFMTRemainTime", _m_GetFMTRemainTime);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFMTRemainTime2", _m_GetFMTRemainTime2);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ID", _g_get_ID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Remain", _g_get_Remain);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsDead", _g_get_IsDead);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Pause", _g_get_Pause);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CallBackFunc", _g_get_CallBackFunc);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CallBackFuncEx", _g_get_CallBackFuncEx);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CallBackFuncEx2", _g_get_CallBackFuncEx2);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UserData", _g_get_UserData);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Pause", _s_set_Pause);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UserData", _s_set_UserData);
            
			XUtils.EndObjectRegister(typeof(Utils.Timer), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Utils.Timer), L, __CreateInstance, 3, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFMTTime2", _m_GetFMTTime2_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetFMTTime", _m_GetFMTTime_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Utils.Timer));
			
			
			XUtils.EndClassRegister(typeof(Utils.Timer), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3))
				{
					float time = (float)LuaAPI.lua_tonumber(L, 2);
					bool loop = LuaAPI.lua_toboolean(L, 3);
					
					Utils.Timer __cl_gen_ret = new Utils.Timer(time, loop);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && translator.Assignable<Utils.Timer.DetalCallback>(L, 5))
				{
					float time = (float)LuaAPI.lua_tonumber(L, 2);
					bool loop = LuaAPI.lua_toboolean(L, 3);
					float detalTime = (float)LuaAPI.lua_tonumber(L, 4);
					Utils.Timer.DetalCallback callback = translator.GetDelegate<Utils.Timer.DetalCallback>(L, 5);
					
					Utils.Timer __cl_gen_ret = new Utils.Timer(time, loop, detalTime, callback);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 5 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && translator.Assignable<Utils.Timer.DetalCallbackEx2>(L, 5))
				{
					float time = (float)LuaAPI.lua_tonumber(L, 2);
					bool loop = LuaAPI.lua_toboolean(L, 3);
					float detalTime = (float)LuaAPI.lua_tonumber(L, 4);
					Utils.Timer.DetalCallbackEx2 callback = translator.GetDelegate<Utils.Timer.DetalCallbackEx2>(L, 5);
					
					Utils.Timer __cl_gen_ret = new Utils.Timer(time, loop, detalTime, callback);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 6 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && translator.Assignable<Utils.Timer.DetalCallbackEx>(L, 5) && translator.Assignable<object>(L, 6))
				{
					float time = (float)LuaAPI.lua_tonumber(L, 2);
					bool loop = LuaAPI.lua_toboolean(L, 3);
					float detalTime = (float)LuaAPI.lua_tonumber(L, 4);
					Utils.Timer.DetalCallbackEx callback = translator.GetDelegate<Utils.Timer.DetalCallbackEx>(L, 5);
					object userData = translator.GetObject(L, 6, typeof(object));
					
					Utils.Timer __cl_gen_ret = new Utils.Timer(time, loop, detalTime, callback, userData);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Utils.Timer constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float time = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.Reset( time );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float deltaTime = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Update( deltaTime );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFMTTime2_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    float fTime = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        string __cl_gen_ret = Utils.Timer.GetFMTTime2( fTime );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFMTTime_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    float fTime = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        string __cl_gen_ret = Utils.Timer.GetFMTTime( fTime );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFMTRemainTime(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetFMTRemainTime(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFMTRemainTime2(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetFMTRemainTime2(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Remain(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Remain);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsDead(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsDead);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Pause(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.Pause);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CallBackFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CallBackFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CallBackFuncEx(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CallBackFuncEx);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CallBackFuncEx2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CallBackFuncEx2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UserData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.UserData);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Pause(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Pause = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UserData(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Utils.Timer __cl_gen_to_be_invoked = (Utils.Timer)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UserData = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
