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
    public class xpatchXPatchManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xpatch.XPatchManager), L, translator, 0, 28, 16, 6);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CreatePatchProcess", _m_CreatePatchProcess);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CollectAllPatchInfo", _m_CollectAllPatchInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemovePatchContext", _m_RemovePatchContext);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsPatchDownloaded", _m_IsPatchDownloaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsAllBinUnpacked", _m_IsAllBinUnpacked);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPatchIdByAsset", _m_GetPatchIdByAsset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsAssetDownloaded", _m_IsAssetDownloaded);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetDownloadPatchId", _m_GetDownloadPatchId);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetBundleAndPatchConfig", _m_SetBundleAndPatchConfig);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetExtendPatchProgress", _m_GetExtendPatchProgress);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Pause", _m_Pause);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Resume", _m_Resume);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CleanUp", _m_CleanUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitFileInfo", _m_InitFileInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitSDFileInfo", _m_InitSDFileInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitRoutine", _m_InitRoutine);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetUpdateCheckUrl", _m_SetUpdateCheckUrl);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetServerVersionRoutine", _m_GetServerVersionRoutine);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ConvertToBundleInfoItem", _m_ConvertToBundleInfoItem);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateDLFileRoutine", _m_UpdateDLFileRoutine);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Load0Unity3dRoutine", _m_Load0Unity3dRoutine);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CollectPatchContextByList", _m_CollectPatchContextByList);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddDownloadedPatch", _m_AddDownloadedPatch);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OverrideServerUrl", _m_OverrideServerUrl);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CollectPatch", _m_CollectPatch);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DownloadBundle", _m_DownloadBundle);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "onPatchFinished", _e_onPatchFinished);
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LocalVersion", _g_get_LocalVersion);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerVersion", _g_get_ServerVersion);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BundleConfig", _g_get_BundleConfig);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BinConfig", _g_get_BinConfig);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PatchConfig", _g_get_PatchConfig);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LimitBytesPerSec", _g_get_LimitBytesPerSec);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BytesDownloadedPerSec", _g_get_BytesDownloadedPerSec);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DownloadSpeedStr", _g_get_DownloadSpeedStr);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "State", _g_get_State);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxConnectionLimit", _g_get_MaxConnectionLimit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsBinPatch", _g_get_IsBinPatch);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsAutoFix", _g_get_IsAutoFix);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsPause", _g_get_IsPause);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "FatalError", _g_get_FatalError);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LatestVersionInfo", _g_get_LatestVersionInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EnableBundleInEditor", _g_get_EnableBundleInEditor);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LimitBytesPerSec", _s_set_LimitBytesPerSec);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxConnectionLimit", _s_set_MaxConnectionLimit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsBinPatch", _s_set_IsBinPatch);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsAutoFix", _s_set_IsAutoFix);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LatestVersionInfo", _s_set_LatestVersionInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EnableBundleInEditor", _s_set_EnableBundleInEditor);
            
			XUtils.EndObjectRegister(typeof(xpatch.XPatchManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xpatch.XPatchManager), L, __CreateInstance, 1, 1, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xpatch.XPatchManager));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(xpatch.XPatchManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xpatch.XPatchManager __cl_gen_ret = new xpatch.XPatchManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xpatch.XPatchManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePatchProcess(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xpatch.PatchProgress __cl_gen_ret = __cl_gen_to_be_invoked.CreatePatchProcess(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xpatch.PatchProgress progress = (xpatch.PatchProgress)translator.GetObject(L, 2, typeof(xpatch.PatchProgress));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.Init( progress );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CollectAllPatchInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xpatch.PatchProgress progress = (xpatch.PatchProgress)translator.GetObject(L, 2, typeof(xpatch.PatchProgress));
                    
                    __cl_gen_to_be_invoked.CollectAllPatchInfo( progress );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemovePatchContext(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int patch_id = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.RemovePatchContext( patch_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPatchDownloaded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int patch_id = LuaAPI.xlua_tointeger(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsPatchDownloaded( patch_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAllBinUnpacked(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsAllBinUnpacked(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPatchIdByAsset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string asset_path = LuaAPI.lua_tostring(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetPatchIdByAsset( asset_path );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAssetDownloaded(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string asset_path = LuaAPI.lua_tostring(L, 2);
                    int patch_id;
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsAssetDownloaded( asset_path, out patch_id );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    LuaAPI.xlua_pushinteger(L, patch_id);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDownloadPatchId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetDownloadPatchId(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBundleAndPatchConfig(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    SGameFirstPass.AssetBundleInfoRuntime bundle_config = (SGameFirstPass.AssetBundleInfoRuntime)translator.GetObject(L, 2, typeof(SGameFirstPass.AssetBundleInfoRuntime));
                    SGameFirstPass.AssetPatchInfoRuntime patch_config = (SGameFirstPass.AssetPatchInfoRuntime)translator.GetObject(L, 3, typeof(SGameFirstPass.AssetPatchInfoRuntime));
                    
                    __cl_gen_to_be_invoked.SetBundleAndPatchConfig( bundle_config, patch_config );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetExtendPatchProgress(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int patch_id = LuaAPI.xlua_tointeger(L, 2);
                    
                        xpatch.ExtendPatchProgress __cl_gen_ret = __cl_gen_to_be_invoked.GetExtendPatchProgress( patch_id );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pause(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Pause(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Resume(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Resume(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CleanUp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CleanUp(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitFileInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitFileInfo(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitSDFileInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitSDFileInfo(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitRoutine(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xpatch.PatchProgress progress = (xpatch.PatchProgress)translator.GetObject(L, 2, typeof(xpatch.PatchProgress));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.InitRoutine( progress );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUpdateCheckUrl(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string update_url = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetUpdateCheckUrl( update_url );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetServerVersionRoutine(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xpatch.PatchProgress progress = (xpatch.PatchProgress)translator.GetObject(L, 2, typeof(xpatch.PatchProgress));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.GetServerVersionRoutine( progress );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConvertToBundleInfoItem(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    BinItemInfo bin_item = (BinItemInfo)translator.GetObject(L, 2, typeof(BinItemInfo));
                    
                        SGameFirstPass.AssetBundleInfoItem __cl_gen_ret = __cl_gen_to_be_invoked.ConvertToBundleInfoItem( bin_item );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateDLFileRoutine(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xpatch.PatchProgress progress = (xpatch.PatchProgress)translator.GetObject(L, 2, typeof(xpatch.PatchProgress));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.UpdateDLFileRoutine( progress );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load0Unity3dRoutine(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xpatch.PatchProgress progress = (xpatch.PatchProgress)translator.GetObject(L, 2, typeof(xpatch.PatchProgress));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.Load0Unity3dRoutine( progress );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CollectPatchContextByList(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xpatch.PatchProgress progress = (xpatch.PatchProgress)translator.GetObject(L, 2, typeof(xpatch.PatchProgress));
                    System.Collections.Generic.List<xpatch.DL_PatchContext> patch_ctx_lst = (System.Collections.Generic.List<xpatch.DL_PatchContext>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<xpatch.DL_PatchContext>));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.CollectPatchContextByList( progress, patch_ctx_lst );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddDownloadedPatch(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int patch_id = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.AddDownloadedPatch( patch_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OverrideServerUrl(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.OverrideServerUrl( url );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CollectPatch(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<xpatch.DL_PatchContext>(L, 3)) 
                {
                    int patch_id = LuaAPI.xlua_tointeger(L, 2);
                    xpatch.DL_PatchContext parent = (xpatch.DL_PatchContext)translator.GetObject(L, 3, typeof(xpatch.DL_PatchContext));
                    
                    __cl_gen_to_be_invoked.CollectPatch( patch_id, parent );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int patch_id = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.CollectPatch( patch_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xpatch.XPatchManager.CollectPatch!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DownloadBundle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string asset_path = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.DownloadBundle( asset_path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LocalVersion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.LocalVersion);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerVersion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.ServerVersion);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BundleConfig(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BundleConfig);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BinConfig(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BinConfig);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PatchConfig(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PatchConfig);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LimitBytesPerSec(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.LimitBytesPerSec);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BytesDownloadedPerSec(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.BytesDownloadedPerSec);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DownloadSpeedStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.DownloadSpeedStr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_State(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.State);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxConnectionLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MaxConnectionLimit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsBinPatch(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsBinPatch);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAutoFix(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsAutoFix);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xpatch.XPatchManager.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPause(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsPause);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FatalError(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.FatalError);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LatestVersionInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LatestVersionInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnableBundleInEditor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.EnableBundleInEditor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LimitBytesPerSec(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LimitBytesPerSec = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxConnectionLimit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxConnectionLimit = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsBinPatch(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsBinPatch = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsAutoFix(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsAutoFix = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LatestVersionInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LatestVersionInfo = (System.Collections.Generic.Dictionary<int, int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<int, int>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnableBundleInEditor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.EnableBundleInEditor = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_onPatchFinished(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
			xpatch.XPatchManager __cl_gen_to_be_invoked = (xpatch.XPatchManager)translator.FastGetCSObj(L, 1);
            try {
                xpatch.XPatchManager.delPatchEventHandler __gen_delegate = translator.GetDelegate<xpatch.XPatchManager.delPatchEventHandler>(L, 3);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need xpatch.XPatchManager.delPatchEventHandler!");
                }
				
				if (__gen_param_count == 3)
				{
					System.IntPtr strlen;

					System.IntPtr str = LuaAPI.lua_tolstring(L, 2, out strlen);

					if (str != System.IntPtr.Zero && strlen.ToInt32() == 1)
					{
						byte op = System.Runtime.InteropServices.Marshal.ReadByte(str);
					
						
						if (op == (byte)'+') {
							__cl_gen_to_be_invoked.onPatchFinished += __gen_delegate;
							return 0;
						} 
						
						
						if (op == (byte)'-') {
							__cl_gen_to_be_invoked.onPatchFinished -= __gen_delegate;
							return 0;
						} 
						
					}
				}
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to xpatch.XPatchManager.onPatchFinished!");
            return 0;
        }
        
		
		
    }
}
