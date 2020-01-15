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
    public class xcSysConfigManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.SysConfigManager), L, translator, 0, 18, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessages", _m_RegisterAllMessages);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OpenSys", _m_OpenSys);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAllOpenSysList", _m_GetAllOpenSysList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetAllWaitingSysList", _m_GetAllWaitingSysList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetSysConfigById", _m_GetSysConfigById);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckSysHasOpened", _m_CheckSysHasOpened);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckSysHasOpenIgnoreActivity", _m_CheckSysHasOpenIgnoreActivity);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckSysHasDownloaded", _m_CheckSysHasDownloaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsWaiting", _m_IsWaiting);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsSysOpened", _m_IsSysOpened);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetWaittingSysConfig", _m_GetWaittingSysConfig);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "MarkRedSpotById", _m_MarkRedSpotById);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFirstOpenSysByPos", _m_GetFirstOpenSysByPos);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForceOpenSys", _m_ForceOpenSys);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForceCloseSys", _m_ForceCloseSys);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleNotifySysOpen", _m_HandleNotifySysOpen);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "HandleNotifySysClose", _m_HandleNotifySysClose);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SkipSysOpen", _g_get_SkipSysOpen);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AutoExpandLeft", _g_get_AutoExpandLeft);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SkipSysOpen", _s_set_SkipSysOpen);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AutoExpandLeft", _s_set_AutoExpandLeft);
            
			XUtils.EndObjectRegister(typeof(xc.SysConfigManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.SysConfigManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.SysConfigManager));
			
			
			XUtils.EndClassRegister(typeof(xc.SysConfigManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.SysConfigManager __cl_gen_ret = new xc.SysConfigManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SysConfigManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessages(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RegisterAllMessages(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenSys(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<xc.DBSysConfig.SysConfig>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    xc.DBSysConfig.SysConfig config = (xc.DBSysConfig.SysConfig)translator.GetObject(L, 2, typeof(xc.DBSysConfig.SysConfig));
                    bool fire_evet = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.OpenSys( config, fire_evet );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<xc.DBSysConfig.SysConfig>(L, 2)) 
                {
                    xc.DBSysConfig.SysConfig config = (xc.DBSysConfig.SysConfig)translator.GetObject(L, 2, typeof(xc.DBSysConfig.SysConfig));
                    
                    __cl_gen_to_be_invoked.OpenSys( config );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SysConfigManager.OpenSys!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllOpenSysList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.DBSysConfig.SysConfig> __cl_gen_ret = __cl_gen_to_be_invoked.GetAllOpenSysList(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllWaitingSysList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.DBSysConfig.SysConfig> __cl_gen_ret = __cl_gen_to_be_invoked.GetAllWaitingSysList(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSysConfigById(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBSysConfig.SysConfig __cl_gen_ret = __cl_gen_to_be_invoked.GetSysConfigById( sys_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckSysHasOpened(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckSysHasOpened( sys_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    bool need_tips = LuaAPI.lua_toboolean(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckSysHasOpened( sys_id, need_tips );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.SysConfigManager.CheckSysHasOpened!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckSysHasOpenIgnoreActivity(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckSysHasOpenIgnoreActivity( sys_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckSysHasDownloaded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    int patch_id;
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CheckSysHasDownloaded( sys_id, out patch_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    LuaAPI.xlua_pushinteger(L, patch_id);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWaiting(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsWaiting(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSysOpened(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsSysOpened( sys_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWaittingSysConfig(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                        xc.DBSysConfig.SysConfig __cl_gen_ret = __cl_gen_to_be_invoked.GetWaittingSysConfig( sys_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MarkRedSpotById(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int sys_id = LuaAPI.xlua_tointeger(L, 2);
                    bool red_spot = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.MarkRedSpotById( sys_id, red_spot );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFirstOpenSysByPos(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBSysConfig.ESysBtnPos pos;translator.Get(L, 2, out pos);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.GetFirstOpenSysByPos( pos );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceOpenSys(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ForceOpenSys( sys_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceCloseSys(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.ForceCloseSys( sys_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleNotifySysOpen(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.HandleNotifySysOpen( sys_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HandleNotifySysClose(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint sys_id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.HandleNotifySysClose( sys_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SkipSysOpen(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.SkipSysOpen);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoExpandLeft(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.AutoExpandLeft);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SkipSysOpen(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SkipSysOpen = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AutoExpandLeft(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.SysConfigManager __cl_gen_to_be_invoked = (xc.SysConfigManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AutoExpandLeft = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
