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
    public class xcuiuguiUIBaseWindowWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UIBaseWindow), L, translator, 0, 29, 32, 25);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetShowParam", _m_SetShowParam);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetCanvasOrderInLayer", _m_SetCanvasOrderInLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetDynamicLayerIndex", _m_SetDynamicLayerIndex);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLayerDirectIndex", _m_SetLayerDirectIndex);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCanvas", _m_GetCanvas);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Show", _m_Show);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitData", _m_InitData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Close", _m_Close);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddBehaviour", _m_AddBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AppendBehaviour", _m_AppendBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetBehaviour", _m_GetBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindChild", _m_FindChild);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadSprite", _m_LoadSprite);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadMaterial", _m_LoadMaterial);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadAudioClip", _m_LoadAudioClip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindWidgetByPath", _m_FindWidgetByPath);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddTemplate", _m_AddTemplate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTemplateInstance", _m_GetTemplateInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetTemplateInstanceEx", _m_GetTemplateInstanceEx);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FreeAllTemplateInstance", _m_FreeAllTemplateInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FreeTemplateInstance", _m_FreeTemplateInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FreeTemplateInstanceGameObject", _m_FreeTemplateInstanceGameObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveTemplate", _m_RemoveTemplate);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetUICacheManager", _m_GetUICacheManager);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetItemGameObj", _m_GetItemGameObj);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetItemGameObjEx", _m_GetItemGameObjEx);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FreeItemGameObj", _m_FreeItemGameObj);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FreeAllItemGameObj", _m_FreeAllItemGameObj);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DestroyDelayTime", _g_get_DestroyDelayTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mCloseWinsType", _g_get_mCloseWinsType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReconnectHandle", _g_get_ReconnectHandle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ReturnHandle", _g_get_ReturnHandle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StayWhenSwitchPlaneInstance", _g_get_StayWhenSwitchPlaneInstance);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsModal", _g_get_IsModal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LuaPath", _g_get_LuaPath);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsSystemWindow", _g_get_IsSystemWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsMainmapSwitch", _g_get_IsMainmapSwitch);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SubSystemInfo", _g_get_SubSystemInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WindowCloseTime", _g_get_WindowCloseTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Behaviours", _g_get_Behaviours);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mWndName", _g_get_mWndName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mPrefabName", _g_get_mPrefabName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mUIObject", _g_get_mUIObject);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsLoadDone", _g_get_IsLoadDone);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsGlobal", _g_get_IsGlobal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsShow", _g_get_IsShow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WindowType", _g_get_WindowType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowParam", _g_get_ShowParam);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SubWindow", _g_get_SubWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InitOpenWindows", _g_get_InitOpenWindows);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BackupOpenSubWindows", _g_get_BackupOpenSubWindows);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "WinState", _g_get_WinState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsBackMainMapOpen", _g_get_IsBackMainMapOpen);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "staticLayerIndex", _g_get_staticLayerIndex);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UpdateParam", _g_get_UpdateParam);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MoneyBarObj", _g_get_MoneyBarObj);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ProbabilityBtnObj", _g_get_ProbabilityBtnObj);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RefundBtnObj", _g_get_RefundBtnObj);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Param1_str", _g_get_Param1_str);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrencyScale", _g_get_CurrencyScale);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsSystemWindow", _s_set_IsSystemWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsMainmapSwitch", _s_set_IsMainmapSwitch);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SubSystemInfo", _s_set_SubSystemInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WindowCloseTime", _s_set_WindowCloseTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Behaviours", _s_set_Behaviours);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mWndName", _s_set_mWndName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mPrefabName", _s_set_mPrefabName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mUIObject", _s_set_mUIObject);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsLoadDone", _s_set_IsLoadDone);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsGlobal", _s_set_IsGlobal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsShow", _s_set_IsShow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WindowType", _s_set_WindowType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowParam", _s_set_ShowParam);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SubWindow", _s_set_SubWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InitOpenWindows", _s_set_InitOpenWindows);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BackupOpenSubWindows", _s_set_BackupOpenSubWindows);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "WinState", _s_set_WinState);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsBackMainMapOpen", _s_set_IsBackMainMapOpen);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "staticLayerIndex", _s_set_staticLayerIndex);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UpdateParam", _s_set_UpdateParam);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MoneyBarObj", _s_set_MoneyBarObj);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ProbabilityBtnObj", _s_set_ProbabilityBtnObj);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RefundBtnObj", _s_set_RefundBtnObj);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Param1_str", _s_set_Param1_str);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurrencyScale", _s_set_CurrencyScale);
            
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UIBaseWindow), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.UIBaseWindow), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UIBaseWindow));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.UIBaseWindow), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.UIBaseWindow __cl_gen_ret = new xc.ui.ugui.UIBaseWindow();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string winName = LuaAPI.lua_tostring(L, 2);
					
					xc.ui.ugui.UIBaseWindow __cl_gen_ret = new xc.ui.ugui.UIBaseWindow(winName);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIBaseWindow constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetShowParam(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] new_show_param = translator.GetParams<object>(L, 2);
                    
                    __cl_gen_to_be_invoked.SetShowParam( new_show_param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCanvasOrderInLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int orderInLayer = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SetCanvasOrderInLayer( orderInLayer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDynamicLayerIndex(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int layer = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SetDynamicLayerIndex( layer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayerDirectIndex(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int layer = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.SetLayerDirectIndex( layer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCanvas(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        UnityEngine.Canvas __cl_gen_ret = __cl_gen_to_be_invoked.GetCanvas(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Show(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Show(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Close(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Close(  );
                    
                    
                    
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
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_AddBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        xc.ui.ugui.IUIBehaviour __cl_gen_ret = __cl_gen_to_be_invoked.AddBehaviour( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AppendBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.AppendBehaviour( name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        xc.ui.ugui.IUIBehaviour __cl_gen_ret = __cl_gen_to_be_invoked.GetBehaviour( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindChild(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string childName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.FindChild( childName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.GameObject parent = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string childName = LuaAPI.lua_tostring(L, 3);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.FindChild( parent, childName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIBaseWindow.FindChild!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSprite(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string spriteName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Sprite __cl_gen_ret = __cl_gen_to_be_invoked.LoadSprite( spriteName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadMaterial(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string materialName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Material __cl_gen_ret = __cl_gen_to_be_invoked.LoadMaterial( materialName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAudioClip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string audioClipName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.AudioClip __cl_gen_ret = __cl_gen_to_be_invoked.LoadAudioClip( audioClipName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindWidgetByPath(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string widgetPath = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.FindWidgetByPath( widgetPath );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.Transform>(L, 2)&& translator.Assignable<string[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Transform trans = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    string[] obj_names = (string[])translator.GetObject(L, 3, typeof(string[]));
                    int begin_idx = LuaAPI.xlua_tointeger(L, 4);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.FindWidgetByPath( trans, obj_names, begin_idx );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIBaseWindow.FindWidgetByPath!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddTemplate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GameObject>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 3, typeof(UnityEngine.GameObject));
                    float releaseTime = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    __cl_gen_to_be_invoked.AddTemplate( name, template, releaseTime );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.GameObject>(L, 3)) 
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GameObject template = (UnityEngine.GameObject)translator.GetObject(L, 3, typeof(UnityEngine.GameObject));
                    
                    __cl_gen_to_be_invoked.AddTemplate( name, template );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIBaseWindow.AddTemplate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTemplateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 3, typeof(UnityEngine.Transform));
                    bool isActive = LuaAPI.lua_toboolean(L, 4);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetTemplateInstance( name, parent, isActive );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTemplateInstanceEx(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 3, typeof(UnityEngine.Transform));
                    bool isActive = LuaAPI.lua_toboolean(L, 4);
                    int sort = LuaAPI.xlua_tointeger(L, 5);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetTemplateInstanceEx( name, parent, isActive, sort );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FreeAllTemplateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FreeAllTemplateInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FreeTemplateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.FreeTemplateInstance( name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FreeTemplateInstanceGameObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 3, typeof(UnityEngine.GameObject));
                    
                    __cl_gen_to_be_invoked.FreeTemplateInstanceGameObject( name, obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveTemplate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveTemplate( name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUICacheManager(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.ui.ugui.UICacheManager __cl_gen_ret = __cl_gen_to_be_invoked.GetUICacheManager(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemGameObj(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetItemGameObj( parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemGameObjEx(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    int sort = LuaAPI.xlua_tointeger(L, 3);
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.GetItemGameObjEx( parent, sort );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FreeItemGameObj(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    
                    __cl_gen_to_be_invoked.FreeItemGameObj( obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FreeAllItemGameObj(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.FreeAllItemGameObj(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DestroyDelayTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.DestroyDelayTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mCloseWinsType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.PushxcuiuguiUIBaseWindowCloseWinsType(L, __cl_gen_to_be_invoked.mCloseWinsType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReconnectHandle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ReconnectHandle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReturnHandle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ReturnHandle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StayWhenSwitchPlaneInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.StayWhenSwitchPlaneInstance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsModal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsModal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaPath(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.LuaPath);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsSystemWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsSystemWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsMainmapSwitch(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsMainmapSwitch);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SubSystemInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.SubSystemInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WindowCloseTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.WindowCloseTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Behaviours(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Behaviours);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mWndName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mWndName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mPrefabName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.mPrefabName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mUIObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mUIObject);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsLoadDone(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsLoadDone);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsGlobal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsGlobal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsShow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WindowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.PushxcuiuguiUIType(L, __cl_gen_to_be_invoked.WindowType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ShowParam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SubWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.SubWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InitOpenWindows(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InitOpenWindows);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BackupOpenSubWindows(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BackupOpenSubWindows);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WinState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.WinState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsBackMainMapOpen(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsBackMainMapOpen);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_staticLayerIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.staticLayerIndex);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UpdateParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.UpdateParam);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MoneyBarObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MoneyBarObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ProbabilityBtnObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ProbabilityBtnObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RefundBtnObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.RefundBtnObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Param1_str(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Param1_str);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrencyScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.CurrencyScale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsSystemWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsSystemWindow = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsMainmapSwitch(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsMainmapSwitch = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SubSystemInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SubSystemInfo = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WindowCloseTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.WindowCloseTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Behaviours(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Behaviours = (System.Collections.Generic.Dictionary<string, xc.ui.ugui.IUIBehaviour>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, xc.ui.ugui.IUIBehaviour>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mWndName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mWndName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mPrefabName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mPrefabName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mUIObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mUIObject = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsLoadDone(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsLoadDone = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsGlobal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsGlobal = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsShow = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WindowType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                xc.ui.ugui.UIType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.WindowType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowParam = (object[])translator.GetObject(L, 2, typeof(object[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SubWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SubWindow = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InitOpenWindows(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InitOpenWindows = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BackupOpenSubWindows(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BackupOpenSubWindows = (System.Collections.Generic.List<xc.ui.ugui.UIBaseWindow.BackupWin>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.ui.ugui.UIBaseWindow.BackupWin>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_WinState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                xc.ui.ugui.WinowState __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.WinState = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsBackMainMapOpen(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsBackMainMapOpen = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_staticLayerIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.staticLayerIndex = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UpdateParam(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UpdateParam = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MoneyBarObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MoneyBarObj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ProbabilityBtnObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ProbabilityBtnObj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RefundBtnObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RefundBtnObj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Param1_str(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Param1_str = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrencyScale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIBaseWindow __cl_gen_to_be_invoked = (xc.ui.ugui.UIBaseWindow)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurrencyScale = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
