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
    public class xcTextHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.TextHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.TextHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.TextHelper), L, __CreateInstance, 7, 24, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTupleFromString", _m_GetTupleFromString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetListFromString", _m_GetListFromString_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetConstText", _m_GetConstText_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetTranslateText", _m_GetTranslateText_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseBraceContent", _m_ParseBraceContent_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CopyTextToClipboard", _m_CopyTextToClipboard_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.TextHelper));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "LoadingNotice", _g_get_LoadingNotice);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "InitDataNotice", _g_get_InitDataNotice);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DBInitFailed", _g_get_DBInitFailed);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "BtnConfirm", _g_get_BtnConfirm);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "BtnCancel", _g_get_BtnCancel);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DBDownloading", _g_get_DBDownloading);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "InitSceneFailed", _g_get_InitSceneFailed);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "InitSceneNewVersion", _g_get_InitSceneNewVersion);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "BtnDownload", _g_get_BtnDownload);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "StartUpgrade", _g_get_StartUpgrade);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "InitSceneFirstRunTips", _g_get_InitSceneFirstRunTips);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "InitSceneLackStorage", _g_get_InitSceneLackStorage);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "InitSceneGetUpgradeInfoFailed", _g_get_InitSceneGetUpgradeInfoFailed);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "BtnRetry", _g_get_BtnRetry);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "UpgradeNoWifiTips", _g_get_UpgradeNoWifiTips);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "NoWifiContinue", _g_get_NoWifiContinue);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "ContinueDownload", _g_get_ContinueDownload);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DownloadException", _g_get_DownloadException);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DownloadProcess", _g_get_DownloadProcess);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DownloadSizeKb", _g_get_DownloadSizeKb);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "DownloadSizeMb", _g_get_DownloadSizeMb);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "UpgradeSuccess", _g_get_UpgradeSuccess);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "SDKLoginCancel", _g_get_SDKLoginCancel);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "SDKLogingFail", _g_get_SDKLogingFail);
            
			
			XUtils.EndClassRegister(typeof(xc.TextHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.TextHelper __cl_gen_ret = new xc.TextHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TextHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTupleFromString_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                        string[] __cl_gen_ret = xc.TextHelper.GetTupleFromString( text );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetListFromString_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                        string[] __cl_gen_ret = xc.TextHelper.GetListFromString( text );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetConstText_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.TextHelper.GetConstText( key );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTranslateText_xlua_st_(RealStatePtr L)
        {
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.TextHelper.GetTranslateText( text );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string tableName = LuaAPI.lua_tostring(L, 1);
                    string col_name = LuaAPI.lua_tostring(L, 2);
                    string text = LuaAPI.lua_tostring(L, 3);
                    
                        string __cl_gen_ret = xc.TextHelper.GetTranslateText( tableName, col_name, text );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TextHelper.GetTranslateText!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseBraceContent_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    bool usePool = LuaAPI.lua_toboolean(L, 2);
                    
                        System.Collections.Generic.List<System.Collections.Generic.List<string>> __cl_gen_ret = xc.TextHelper.ParseBraceContent( str, usePool );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<System.Collections.Generic.List<string>> __cl_gen_ret = xc.TextHelper.ParseBraceContent( str );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.TextHelper.ParseBraceContent!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CopyTextToClipboard_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                    xc.TextHelper.CopyTextToClipboard( text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadingNotice(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.LoadingNotice);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InitDataNotice(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.InitDataNotice);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DBInitFailed(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.DBInitFailed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BtnConfirm(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.BtnConfirm);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BtnCancel(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.BtnCancel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DBDownloading(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.DBDownloading);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InitSceneFailed(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.InitSceneFailed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InitSceneNewVersion(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.InitSceneNewVersion);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BtnDownload(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.BtnDownload);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StartUpgrade(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.StartUpgrade);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InitSceneFirstRunTips(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.InitSceneFirstRunTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InitSceneLackStorage(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.InitSceneLackStorage);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InitSceneGetUpgradeInfoFailed(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.InitSceneGetUpgradeInfoFailed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BtnRetry(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.BtnRetry);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UpgradeNoWifiTips(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.UpgradeNoWifiTips);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NoWifiContinue(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.NoWifiContinue);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ContinueDownload(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.ContinueDownload);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DownloadException(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.DownloadException);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DownloadProcess(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.DownloadProcess);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DownloadSizeKb(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.DownloadSizeKb);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DownloadSizeMb(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.DownloadSizeMb);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UpgradeSuccess(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.UpgradeSuccess);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SDKLoginCancel(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.SDKLoginCancel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SDKLogingFail(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushstring(L, xc.TextHelper.SDKLogingFail);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
