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
    public class ScrollPageWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(ScrollPage), L, translator, 0, 5, 11, 11);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdatePosition", _m_UpdatePosition);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnBeginDrag", _m_OnBeginDrag);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnEndDrag", _m_OnEndDrag);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ChangePage", _m_ChangePage);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitLayout", _m_InitLayout);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CurrentPageIndex", _g_get_CurrentPageIndex);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SmoothSpeed", _g_get_SmoothSpeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Height", _g_get_Height);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Width", _g_get_Width);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Sensitivity", _g_get_Sensitivity);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PageCount", _g_get_PageCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PageChangeAction", _g_get_PageChangeAction);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GameObjCount", _g_get_GameObjCount);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isHorizontal", _g_get_isHorizontal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Spacing", _g_get_Spacing);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnPageChanged", _g_get_OnPageChanged);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CurrentPageIndex", _s_set_CurrentPageIndex);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SmoothSpeed", _s_set_SmoothSpeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Height", _s_set_Height);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Width", _s_set_Width);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Sensitivity", _s_set_Sensitivity);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PageCount", _s_set_PageCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PageChangeAction", _s_set_PageChangeAction);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GameObjCount", _s_set_GameObjCount);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isHorizontal", _s_set_isHorizontal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Spacing", _s_set_Spacing);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnPageChanged", _s_set_OnPageChanged);
            
			XUtils.EndObjectRegister(typeof(ScrollPage), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(ScrollPage), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(ScrollPage));
			
			
			XUtils.EndClassRegister(typeof(ScrollPage), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					ScrollPage __cl_gen_ret = new ScrollPage();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ScrollPage constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePosition(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdatePosition(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnBeginDrag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnBeginDrag( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEndDrag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnEndDrag( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangePage(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int pageNum = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.ChangePage( pageNum );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitLayout(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitLayout(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentPageIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.CurrentPageIndex);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SmoothSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.SmoothSpeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Height(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Height);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Width(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Width);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Sensitivity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Sensitivity);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PageCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.PageCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PageChangeAction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.PageChangeAction);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GameObjCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.GameObjCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isHorizontal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isHorizontal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Spacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Spacing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnPageChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnPageChanged);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentPageIndex(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CurrentPageIndex = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SmoothSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SmoothSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Height(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Height = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Width(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Width = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Sensitivity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Sensitivity = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PageCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PageCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PageChangeAction(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PageChangeAction = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GameObjCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GameObjCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isHorizontal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isHorizontal = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Spacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Spacing = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnPageChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPage __cl_gen_to_be_invoked = (ScrollPage)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnPageChanged = translator.GetDelegate<System.Action<int, int>>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
