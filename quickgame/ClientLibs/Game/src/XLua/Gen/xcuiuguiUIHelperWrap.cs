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
    public class xcuiuguiUIHelperWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UIHelper), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UIHelper), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.UIHelper), L, __CreateInstance, 27, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetRaycastDisable", _m_SetRaycastDisable_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetVector2ByPivot", _m_GetVector2ByPivot_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindChildInHierarchy", _m_FindChildInHierarchy_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetSupportBack", _m_GetSupportBack_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindChild", _m_FindChild_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindAllChildrenInHierarchy_out", _m_FindAllChildrenInHierarchy_out_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetObjectCanvas", _m_GetObjectCanvas_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsUniqueWin", _m_IsUniqueWin_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetWindowInitOpenSubWin", _m_GetWindowInitOpenSubWin_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "InstUIObject", _m_InstUIObject_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CheckWindowIsModalByName", _m_CheckWindowIsModalByName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetUITypeByWindowName", _m_GetUITypeByWindowName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsBanBackLastPanelByWindowName", _m_IsBanBackLastPanelByWindowName_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsBanSubWindowWhenBack", _m_IsBanSubWindowWhenBack_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "InitLoginAllUI", _m_InitLoginAllUI_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LoadSpriteByBaseWindow", _m_LoadSpriteByBaseWindow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LoadMaterialByBaseWindow", _m_LoadMaterialByBaseWindow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "LoadAudioClipByBaseWindow", _m_LoadAudioClipByBaseWindow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetLuaWindowPath", _m_GetLuaWindowPath_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetWindowPatchId", _m_GetWindowPatchId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetDBTextResourceVector", _m_GetDBTextResourceVector_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetLayer", _m_SetLayer_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetMainUISysBtnBySysId", _m_GetMainUISysBtnBySysId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "CreateMainUISysBtnBySysId", _m_CreateMainUISysBtnBySysId_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "IsIndependentSysWindow", _m_IsIndependentSysWindow_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "SetChildrenActiveExclude", _m_SetChildrenActiveExclude_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UIHelper));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.UIHelper), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.UIHelper __cl_gen_ret = new xc.ui.ugui.UIHelper();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRaycastDisable_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject root = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                    xc.ui.ugui.UIHelper.SetRaycastDisable( root );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVector2ByPivot_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.ui.ugui.Pivot piovt;translator.Get(L, 1, out piovt);
                    
                        UnityEngine.Vector2 __cl_gen_ret = xc.ui.ugui.UIHelper.GetVector2ByPivot( piovt );
                        translator.PushUnityEngineVector2(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindChildInHierarchy_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 1, typeof(UnityEngine.Transform));
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Transform __cl_gen_ret = xc.ui.ugui.UIHelper.FindChildInHierarchy( parent, name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSupportBack_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = xc.ui.ugui.UIHelper.GetSupportBack( name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindChild_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.GameObject parent = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string childName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject __cl_gen_ret = xc.ui.ugui.UIHelper.FindChild( parent, childName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Transform>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.Transform transform = (UnityEngine.Transform)translator.GetObject(L, 1, typeof(UnityEngine.Transform));
                    string childName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject __cl_gen_ret = xc.ui.ugui.UIHelper.FindChild( transform, childName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIHelper.FindChild!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindAllChildrenInHierarchy_out_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 1, typeof(UnityEngine.Transform));
                    string name = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.List<UnityEngine.GameObject> childrenObj;
                    
                    xc.ui.ugui.UIHelper.FindAllChildrenInHierarchy_out( parent, name, out childrenObj );
                    translator.Push(L, childrenObj);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetObjectCanvas_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject Obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                        UnityEngine.Canvas __cl_gen_ret = xc.ui.ugui.UIHelper.GetObjectCanvas( Obj );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsUniqueWin_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = xc.ui.ugui.UIHelper.IsUniqueWin( name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWindowInitOpenSubWin_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<string> __cl_gen_ret = xc.ui.ugui.UIHelper.GetWindowInitOpenSubWin( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstUIObject_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                        UnityEngine.GameObject __cl_gen_ret = xc.ui.ugui.UIHelper.InstUIObject( obj );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckWindowIsModalByName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = xc.ui.ugui.UIHelper.CheckWindowIsModalByName( name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUITypeByWindowName_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        xc.ui.ugui.UIType __cl_gen_ret = xc.ui.ugui.UIHelper.GetUITypeByWindowName( name );
                        translator.PushxcuiuguiUIType(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBanBackLastPanelByWindowName_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = xc.ui.ugui.UIHelper.IsBanBackLastPanelByWindowName( name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBanSubWindowWhenBack_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = xc.ui.ugui.UIHelper.IsBanSubWindowWhenBack( name );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitLoginAllUI_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    xc.ui.ugui.UIHelper.InitLoginAllUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSpriteByBaseWindow_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.ui.ugui.UIBaseWindow win = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 1, typeof(xc.ui.ugui.UIBaseWindow));
                    string spriteName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Sprite __cl_gen_ret = xc.ui.ugui.UIHelper.LoadSpriteByBaseWindow( win, spriteName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadMaterialByBaseWindow_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.ui.ugui.UIBaseWindow win = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 1, typeof(xc.ui.ugui.UIBaseWindow));
                    string materialName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Material __cl_gen_ret = xc.ui.ugui.UIHelper.LoadMaterialByBaseWindow( win, materialName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAudioClipByBaseWindow_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    xc.ui.ugui.UIBaseWindow win = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 1, typeof(xc.ui.ugui.UIBaseWindow));
                    string audioClipName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.AudioClip __cl_gen_ret = xc.ui.ugui.UIHelper.LoadAudioClipByBaseWindow( win, audioClipName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLuaWindowPath_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string winName = LuaAPI.lua_tostring(L, 1);
                    
                        string __cl_gen_ret = xc.ui.ugui.UIHelper.GetLuaWindowPath( winName );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWindowPatchId_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        int __cl_gen_ret = xc.ui.ugui.UIHelper.GetWindowPatchId( name );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDBTextResourceVector_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Vector3 __cl_gen_ret = xc.ui.ugui.UIHelper.GetDBTextResourceVector( str );
                        translator.PushUnityEngineVector3(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayer_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Transform root = (UnityEngine.Transform)translator.GetObject(L, 1, typeof(UnityEngine.Transform));
                    int layer = LuaAPI.xlua_tointeger(L, 2);
                    
                    xc.ui.ugui.UIHelper.SetLayer( root, layer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMainUISysBtnBySysId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint sysId = LuaAPI.xlua_touint(L, 1);
                    
                        UISysConfigBtn __cl_gen_ret = xc.ui.ugui.UIHelper.GetMainUISysBtnBySysId( sysId );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateMainUISysBtnBySysId_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    uint sysId = LuaAPI.xlua_touint(L, 1);
                    UnityEngine.Transform parent_trans = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    uint sort_index = LuaAPI.xlua_touint(L, 3);
                    
                        UISysConfigBtn __cl_gen_ret = xc.ui.ugui.UIHelper.CreateMainUISysBtnBySysId( sysId, parent_trans, sort_index );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsIndependentSysWindow_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string windowName = LuaAPI.lua_tostring(L, 1);
                    
                        bool __cl_gen_ret = xc.ui.ugui.UIHelper.IsIndependentSysWindow( windowName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetChildrenActiveExclude_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 1, typeof(UnityEngine.Transform));
                    bool active = LuaAPI.lua_toboolean(L, 2);
                    string[] name_list = (string[])translator.GetObject(L, 3, typeof(string[]));
                    
                    xc.ui.ugui.UIHelper.SetChildrenActiveExclude( parent, active, name_list );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
