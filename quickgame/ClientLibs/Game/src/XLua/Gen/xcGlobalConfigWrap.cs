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
    public class xcGlobalConfigWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GlobalConfig), L, translator, 0, 2, 29, 7);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetHostURL", _m_ResetHostURL);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ResetLoginInfo", _m_ResetLoginInfo);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "XgDeviceId", _g_get_XgDeviceId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CSURLV", _g_get_CSURLV);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LogURLV", _g_get_LogURLV);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LoginURL", _g_get_LoginURL);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CSURLVEX", _g_get_CSURLVEX);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LoginNoticeUrl", _g_get_LoginNoticeUrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PackCodeURL", _g_get_PackCodeURL);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CommonURL", _g_get_CommonURL);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PhoneBindURL", _g_get_PhoneBindURL);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ClientURL", _g_get_ClientURL);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GameMark", _g_get_GameMark);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsEnterSDK", _g_get_IsEnterSDK);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerType", _g_get_ServerType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsDisableDoAction2SDK", _g_get_IsDisableDoAction2SDK);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPostCloudLadderAction", _g_get_IsPostCloudLadderAction);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AppDocPath", _g_get_AppDocPath);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AppResPath", _g_get_AppResPath);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PlatformName", _g_get_PlatformName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SDKName", _g_get_SDKName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AppId", _g_get_AppId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Channel", _g_get_Channel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SubChannel", _g_get_SubChannel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StartTimeStamp", _g_get_StartTimeStamp);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeviceMark", _g_get_DeviceMark);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsDebugMode", _g_get_IsDebugMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AppStoreGID", _g_get_AppStoreGID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BindMobileState", _g_get_BindMobileState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Token", _g_get_Token);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LoginInfo", _g_get_LoginInfo);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "XgDeviceId", _s_set_XgDeviceId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "StartTimeStamp", _s_set_StartTimeStamp);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeviceMark", _s_set_DeviceMark);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsDebugMode", _s_set_IsDebugMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BindMobileState", _s_set_BindMobileState);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Token", _s_set_Token);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LoginInfo", _s_set_LoginInfo);
            
			XUtils.EndObjectRegister(typeof(xc.GlobalConfig), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GlobalConfig), L, __CreateInstance, 1, 6, 3);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GlobalConfig));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "HostURL", _g_get_HostURL);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DBFile", _g_get_DBFile);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "GoodsNameDBFile", _g_get_GoodsNameDBFile);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DebugHostURL", _g_get_DebugHostURL);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DebugGameMark", _g_get_DebugGameMark);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DebugServerType", _g_get_DebugServerType);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "DebugHostURL", _s_set_DebugHostURL);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "DebugGameMark", _s_set_DebugGameMark);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "DebugServerType", _s_set_DebugServerType);
            
			XUtils.EndClassRegister(typeof(xc.GlobalConfig), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GlobalConfig __cl_gen_ret = new xc.GlobalConfig();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GlobalConfig constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetHostURL(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetHostURL(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetLoginInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ResetLoginInfo(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HostURL(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.GlobalConfig.HostURL);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_XgDeviceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.XgDeviceId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CSURLV(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CSURLV);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LogURLV(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LogURLV);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoginURL(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LoginURL);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CSURLVEX(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CSURLVEX);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoginNoticeUrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LoginNoticeUrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PackCodeURL(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.PackCodeURL);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CommonURL(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CommonURL);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PhoneBindURL(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.PhoneBindURL);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ClientURL(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ClientURL);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GameMark(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.GameMark);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsEnterSDK(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsEnterSDK);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ServerType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsDisableDoAction2SDK(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsDisableDoAction2SDK);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPostCloudLadderAction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPostCloudLadderAction);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AppDocPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.AppDocPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AppResPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.AppResPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlatformName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.PlatformName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SDKName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.SDKName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AppId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.AppId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Channel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Channel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SubChannel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.SubChannel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StartTimeStamp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.StartTimeStamp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeviceMark(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.DeviceMark);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsDebugMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsDebugMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AppStoreGID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.AppStoreGID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BindMobileState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.BindMobileState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DBFile(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.GlobalConfig.DBFile);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GoodsNameDBFile(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.GlobalConfig.GoodsNameDBFile);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DebugHostURL(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.GlobalConfig.DebugHostURL);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DebugGameMark(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.GlobalConfig.DebugGameMark);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DebugServerType(RealStatePtr L)
        {
            
            try {
			    LuaAPI.xlua_pushinteger(L, xc.GlobalConfig.DebugServerType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Token(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Token);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoginInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LoginInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_XgDeviceId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.XgDeviceId = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StartTimeStamp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.StartTimeStamp = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeviceMark(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DeviceMark = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsDebugMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsDebugMode = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BindMobileState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BindMobileState = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DebugHostURL(RealStatePtr L)
        {
            
            try {
			    xc.GlobalConfig.DebugHostURL = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DebugGameMark(RealStatePtr L)
        {
            
            try {
			    xc.GlobalConfig.DebugGameMark = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DebugServerType(RealStatePtr L)
        {
            
            try {
			    xc.GlobalConfig.DebugServerType = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Token(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Token = LuaAPI.lua_tobytes(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LoginInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig __cl_gen_to_be_invoked = (xc.GlobalConfig)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LoginInfo = (xc.GlobalConfig.LoginInfoStruct)translator.GetObject(L, 2, typeof(xc.GlobalConfig.LoginInfoStruct));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
