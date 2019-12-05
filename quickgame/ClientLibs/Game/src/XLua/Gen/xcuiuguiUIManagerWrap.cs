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
    public class xcuiuguiUIManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UIManager), L, translator, 0, 32, 8, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLayerInfo", _m_GetLayerInfo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SwitchUI", _m_SwitchUI);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsLuaScriptExist", _m_IsLuaScriptExist);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLoadingTip", _m_SetLoadingTip);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowLoadingBK", _m_ShowLoadingBK);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowWaitScreen", _m_ShowWaitScreen);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateLoadingBar", _m_UpdateLoadingBar);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetWindow", _m_GetWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetExistingWindow", _m_GetExistingWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetNeedCloseSystemWindowsByType", _m_GetNeedCloseSystemWindowsByType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowWindowLayer", _m_ShowWindowLayer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowWindow", _m_ShowWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetWindowDynOrder", _m_SetWindowDynOrder);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveWindowDynOrder", _m_RemoveWindowDynOrder);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroyWindow", _m_DestroyWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CloseWindow", _m_CloseWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CloseAllWindow", _m_CloseAllWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CloseAllWindowExcept", _m_CloseAllWindowExcept);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CloseWindowsWhenSwitchPlaneInstance", _m_CloseWindowsWhenSwitchPlaneInstance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowAllWindow", _m_ShowAllWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ClearUI", _m_ClearUI);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Dispose", _m_Dispose);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowSysWindowEx", _m_ShowSysWindowEx);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ShowSysWindow", _m_ShowSysWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CloseSysWindow", _m_CloseSysWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsOpenedSysWindow", _m_IsOpenedSysWindow);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsOpeningSysWinExceptMainmapWin", _m_IsOpeningSysWinExceptMainmapWin);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetStateIsShowWindowByWindowType", _m_GetStateIsShowWindowByWindowType);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetPlaneDistance", _m_GetPlaneDistance);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryCloseAllWindow", _m_TryCloseAllWindow);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UICache", _g_get_UICache);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MainCtrl", _g_get_MainCtrl);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LoadingBKIsShow", _g_get_LoadingBKIsShow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AllWindow", _g_get_AllWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxDepth", _g_get_MaxDepth);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ModalWindow", _g_get_ModalWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LoadingWindow", _g_get_LoadingWindow);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsBackMainMapShowWin", _g_get_IsBackMainMapShowWin);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MainCtrl", _s_set_MainCtrl);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ModalWindow", _s_set_ModalWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LoadingWindow", _s_set_LoadingWindow);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsBackMainMapShowWin", _s_set_IsBackMainMapShowWin);
            
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UIManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.UIManager), L, __CreateInstance, 4, 1, 1);
			
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "MainPanelName", xc.ui.ugui.UIManager.MainPanelName);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "DynamicPath", xc.ui.ugui.UIManager.DynamicPath);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "PresetPath", xc.ui.ugui.UIManager.PresetPath);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UIManager));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "IsPopBackWin", _g_get_IsPopBackWin);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "IsPopBackWin", _s_set_IsPopBackWin);
            
			XUtils.EndClassRegister(typeof(xc.ui.ugui.UIManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.UIManager __cl_gen_ret = new xc.ui.ugui.UIManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLayerInfo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ui.ugui.UIType type;translator.Get(L, 2, out type);
                    
                        xc.ui.ugui.UILayerInfo __cl_gen_ret = __cl_gen_to_be_invoked.GetLayerInfo( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_SwitchUI(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string uiName = LuaAPI.lua_tostring(L, 2);
                    bool hideLoadingBk = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.SwitchUI( uiName, hideLoadingBk );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string uiName = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.SwitchUI( uiName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIManager.SwitchUI!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLuaScriptExist(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string lua_script = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsLuaScriptExist( lua_script );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLoadingTip(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetLoadingTip( text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowLoadingBK(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowLoadingBK( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowWaitScreen(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    float wait_time = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowWaitScreen( isShow, wait_time );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool isShow = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.ShowWaitScreen( isShow );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIManager.ShowWaitScreen!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateLoadingBar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    double process = LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.UpdateLoadingBar( process );
                    
                    
                    
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
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        xc.ui.ugui.UIBaseWindow __cl_gen_ret = __cl_gen_to_be_invoked.GetWindow( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetExistingWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        xc.ui.ugui.UIBaseWindow __cl_gen_ret = __cl_gen_to_be_invoked.GetExistingWindow( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNeedCloseSystemWindowsByType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ui.ugui.UIType uiType;translator.Get(L, 2, out uiType);
                    
                        System.Collections.Generic.List<xc.ui.ugui.UIBaseWindow> __cl_gen_ret = __cl_gen_to_be_invoked.GetNeedCloseSystemWindowsByType( uiType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowWindowLayer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string winName = LuaAPI.lua_tostring(L, 2);
                    int layer = LuaAPI.xlua_tointeger(L, 3);
                    object[] param = translator.GetParams<object>(L, 4);
                    
                    __cl_gen_to_be_invoked.ShowWindowLayer( winName, layer, param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string winName = LuaAPI.lua_tostring(L, 2);
                    object[] param = translator.GetParams<object>(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowWindow( winName, param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetWindowDynOrder(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ui.ugui.UIBaseWindow baseWin = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 2, typeof(xc.ui.ugui.UIBaseWindow));
                    
                    __cl_gen_to_be_invoked.SetWindowDynOrder( baseWin );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveWindowDynOrder(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ui.ugui.UIBaseWindow win = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 2, typeof(xc.ui.ugui.UIBaseWindow));
                    
                    __cl_gen_to_be_invoked.RemoveWindowDynOrder( win );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.DestroyWindow( name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.CloseWindow( name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseAllWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CloseAllWindow(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseAllWindowExcept(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool record = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.CloseAllWindowExcept( record );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.CloseAllWindowExcept(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIManager.CloseAllWindowExcept!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseWindowsWhenSwitchPlaneInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CloseWindowsWhenSwitchPlaneInstance(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowAllWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ShowAllWindow(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearUI(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.ClearUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowSysWindowEx(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string winName = LuaAPI.lua_tostring(L, 2);
                    bool mainmap_switch = LuaAPI.lua_toboolean(L, 3);
                    object[] param = translator.GetParams<object>(L, 4);
                    
                    __cl_gen_to_be_invoked.ShowSysWindowEx( winName, mainmap_switch, param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowSysWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string winName = LuaAPI.lua_tostring(L, 2);
                    object[] param = translator.GetParams<object>(L, 3);
                    
                    __cl_gen_to_be_invoked.ShowSysWindow( winName, param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseSysWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string winName = LuaAPI.lua_tostring(L, 2);
                    bool isPlayMainMapAni = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.CloseSysWindow( winName, isPlayMainMapAni );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string winName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.CloseSysWindow( winName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIManager.CloseSysWindow!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsOpenedSysWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string wnd_name = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsOpenedSysWindow( wnd_name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsOpeningSysWinExceptMainmapWin(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsOpeningSysWinExceptMainmapWin(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStateIsShowWindowByWindowType(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ui.ugui.UIType uiType;translator.Get(L, 2, out uiType);
                    bool isShow = LuaAPI.lua_toboolean(L, 3);
                    
                        System.Collections.Generic.List<xc.ui.ugui.UIBaseWindow> __cl_gen_ret = __cl_gen_to_be_invoked.GetStateIsShowWindowByWindowType( uiType, isShow );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlaneDistance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int orderInLayer = LuaAPI.xlua_tointeger(L, 2);
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.GetPlaneDistance( orderInLayer );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryCloseAllWindow(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryCloseAllWindow(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UICache(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UICache);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.MainCtrl);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadingBKIsShow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.LoadingBKIsShow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.AllWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsPopBackWin(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, xc.ui.ugui.UIManager.IsPopBackWin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxDepth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.MaxDepth);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ModalWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ModalWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadingWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LoadingWindow);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsBackMainMapShowWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.IsBackMainMapShowWin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MainCtrl(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MainCtrl = (xc.ui.ugui.UIMainCtrl)translator.GetObject(L, 2, typeof(xc.ui.ugui.UIMainCtrl));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsPopBackWin(RealStatePtr L)
        {
            
            try {
			    xc.ui.ugui.UIManager.IsPopBackWin = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ModalWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ModalWindow = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 2, typeof(xc.ui.ugui.UIBaseWindow));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LoadingWindow(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LoadingWindow = (xc.ui.ugui.UILoadingWindow)translator.GetObject(L, 2, typeof(xc.ui.ugui.UILoadingWindow));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsBackMainMapShowWin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.UIManager __cl_gen_to_be_invoked = (xc.ui.ugui.UIManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsBackMainMapShowWin = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
