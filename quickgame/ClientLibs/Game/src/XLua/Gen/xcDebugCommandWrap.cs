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
    public class xcDebugCommandWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DebugCommand), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.DebugCommand), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DebugCommand), L, __CreateInstance, 5, 2, 2);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SendGMCommandForDebugUI", _m_SendGMCommandForDebugUI_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SendGMCommandThroughMajorConnect", _m_SendGMCommandThroughMajorConnect_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "OnProcessCmd", _m_OnProcessCmd_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ToProcessCommand", _m_ToProcessCommand_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DebugCommand));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "mTestRide", _g_get_mTestRide);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "xihun_sound_id", _g_get_xihun_sound_id);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "mTestRide", _s_set_mTestRide);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "xihun_sound_id", _s_set_xihun_sound_id);
            
			XUtils.EndClassRegister(typeof(xc.DebugCommand), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DebugCommand __cl_gen_ret = new xc.DebugCommand();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DebugCommand constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendGMCommandForDebugUI_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    DebugUI.Command cmd;translator.Get(L, 1, out cmd);
                    
                    xc.DebugCommand.SendGMCommandForDebugUI( cmd );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendGMCommandThroughMajorConnect_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    DebugUI.Command cmd;translator.Get(L, 1, out cmd);
                    
                    xc.DebugCommand.SendGMCommandThroughMajorConnect( cmd );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnProcessCmd_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    DebugUI.Command cmd;translator.Get(L, 1, out cmd);
                    
                        bool __cl_gen_ret = xc.DebugCommand.OnProcessCmd( cmd );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToProcessCommand_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string main = LuaAPI.lua_tostring(L, 1);
                    System.Collections.Generic.List<string> paramArray = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
                    DebugUI debugUI = (DebugUI)translator.GetObject(L, 3, typeof(DebugUI));
                    
                        bool __cl_gen_ret = xc.DebugCommand.ToProcessCommand( main, paramArray, debugUI );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mTestRide(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.DebugCommand.mTestRide);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_xihun_sound_id(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushuint(L, xc.DebugCommand.xihun_sound_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mTestRide(RealStatePtr L)
        {
            
            try {
			    xc.DebugCommand.mTestRide = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_xihun_sound_id(RealStatePtr L)
        {
            
            try {
			    xc.DebugCommand.xihun_sound_id = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
