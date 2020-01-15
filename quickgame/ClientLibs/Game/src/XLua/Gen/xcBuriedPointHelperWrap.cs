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
    public class xcBuriedPointHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.BuriedPointHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.BuriedPointHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.BuriedPointHelper), L, __CreateInstance, 8, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReportAppsflyerEvnet", _m_ReportAppsflyerEvnet_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReportTapjoyEvnet", _m_ReportTapjoyEvnet_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReportTjPlacementEvnet", _m_ReportTjPlacementEvnet_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GoogleShowAchievements", _m_GoogleShowAchievements_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GoogleSubmitAchievements", _m_GoogleSubmitAchievements_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ReportEsaAppsflyerEvnet", _m_ReportEsaAppsflyerEvnet_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "DoFacebookShare", _m_DoFacebookShare_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.BuriedPointHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.BuriedPointHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.BuriedPointHelper __cl_gen_ret = new xc.BuriedPointHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.BuriedPointHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReportAppsflyerEvnet_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string value = LuaAPI.lua_tostring(L, 1);
                    
                    xc.BuriedPointHelper.ReportAppsflyerEvnet( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReportTapjoyEvnet_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string value = LuaAPI.lua_tostring(L, 1);
                    string category = LuaAPI.lua_tostring(L, 2);
                    
                    xc.BuriedPointHelper.ReportTapjoyEvnet( value, category );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string value = LuaAPI.lua_tostring(L, 1);
                    
                    xc.BuriedPointHelper.ReportTapjoyEvnet( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.BuriedPointHelper.ReportTapjoyEvnet!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReportTjPlacementEvnet_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string value = LuaAPI.lua_tostring(L, 1);
                    string category = LuaAPI.lua_tostring(L, 2);
                    
                    xc.BuriedPointHelper.ReportTjPlacementEvnet( value, category );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string value = LuaAPI.lua_tostring(L, 1);
                    
                    xc.BuriedPointHelper.ReportTjPlacementEvnet( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.BuriedPointHelper.ReportTjPlacementEvnet!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoogleShowAchievements_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.BuriedPointHelper.GoogleShowAchievements(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoogleSubmitAchievements_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string value = LuaAPI.lua_tostring(L, 1);
                    
                    xc.BuriedPointHelper.GoogleSubmitAchievements( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReportEsaAppsflyerEvnet_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string eventName = LuaAPI.lua_tostring(L, 1);
                    string argKey = LuaAPI.lua_tostring(L, 2);
                    int argValue = LuaAPI.xlua_tointeger(L, 3);
                    
                    xc.BuriedPointHelper.ReportEsaAppsflyerEvnet( eventName, argKey, argValue );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoFacebookShare_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string value = LuaAPI.lua_tostring(L, 1);
                    
                    xc.BuriedPointHelper.DoFacebookShare( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
