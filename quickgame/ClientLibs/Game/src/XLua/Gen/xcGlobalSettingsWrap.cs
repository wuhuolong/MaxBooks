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
    public class xcGlobalSettingsWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GlobalSettings), L, translator, 0, 4, 14, 13);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterAllMessages", _m_RegisterAllMessages);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Save", _m_Save);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayerSettingValue", _m_PlayerSettingValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangePlayerSetting", _m_ChangePlayerSetting);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SFXVolume", _g_get_SFXVolume);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SFXMute", _g_get_SFXMute);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxPlayerCount", _g_get_MaxPlayerCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlayerSettings", _g_get_PlayerSettings);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NormalMonsterVisible", _g_get_NormalMonsterVisible);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SummonMonsterVisible", _g_get_SummonMonsterVisible);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MusicVolume", _g_get_MusicVolume);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MarryNotified", _g_get_MarryNotified);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MusicMute", _g_get_MusicMute);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CameraShake", _g_get_CameraShake);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GraphicLevel", _g_get_GraphicLevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LastAccount", _g_get_LastAccount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LastServer", _g_get_LastServer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LastActorIndex", _g_get_LastActorIndex);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SFXVolume", _s_set_SFXVolume);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SFXMute", _s_set_SFXMute);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxPlayerCount", _s_set_MaxPlayerCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NormalMonsterVisible", _s_set_NormalMonsterVisible);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SummonMonsterVisible", _s_set_SummonMonsterVisible);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MusicVolume", _s_set_MusicVolume);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MarryNotified", _s_set_MarryNotified);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MusicMute", _s_set_MusicMute);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CameraShake", _s_set_CameraShake);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GraphicLevel", _s_set_GraphicLevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LastAccount", _s_set_LastAccount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LastServer", _s_set_LastServer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LastActorIndex", _s_set_LastActorIndex);
            
			XUtils.EndObjectRegister(typeof(xc.GlobalSettings), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GlobalSettings), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GlobalSettings));
			
			
			XUtils.EndClassRegister(typeof(xc.GlobalSettings), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GlobalSettings __cl_gen_ret = new xc.GlobalSettings();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GlobalSettings constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterAllMessages(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Save(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Save(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayerSettingValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.PlayerSettingValue( type );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangePlayerSetting(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint type = LuaAPI.xlua_touint(L, 2);
                    uint value = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.ChangePlayerSetting( type, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SFXVolume(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.SFXVolume);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SFXMute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.SFXMute);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxPlayerCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MaxPlayerCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayerSettings(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PlayerSettings);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NormalMonsterVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NormalMonsterVisible);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SummonMonsterVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.SummonMonsterVisible);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MusicVolume(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.MusicVolume);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MarryNotified(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.MarryNotified);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MusicMute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.MusicMute);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CameraShake(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.CameraShake);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GraphicLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.GraphicLevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LastAccount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LastAccount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LastServer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LastServer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LastActorIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.LastActorIndex);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SFXVolume(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SFXVolume = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SFXMute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SFXMute = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxPlayerCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxPlayerCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NormalMonsterVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NormalMonsterVisible = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SummonMonsterVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SummonMonsterVisible = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MusicVolume(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MusicVolume = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MarryNotified(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MarryNotified = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MusicMute(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MusicMute = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CameraShake(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CameraShake = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GraphicLevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GraphicLevel = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LastAccount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LastAccount = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LastServer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LastServer = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LastActorIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalSettings __cl_gen_to_be_invoked = (xc.GlobalSettings)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LastActorIndex = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
