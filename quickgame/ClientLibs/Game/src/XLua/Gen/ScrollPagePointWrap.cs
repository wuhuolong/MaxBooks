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
    public class ScrollPagePointWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(ScrollPagePoint), L, translator, 0, 1, 3, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnScrollPageChanged", _m_OnScrollPageChanged);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "scrollPage", _g_get_scrollPage);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "toggleGroup", _g_get_toggleGroup);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "togglePrefab", _g_get_togglePrefab);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "scrollPage", _s_set_scrollPage);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "toggleGroup", _s_set_toggleGroup);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "togglePrefab", _s_set_togglePrefab);
            
			XUtils.EndObjectRegister(typeof(ScrollPagePoint), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(ScrollPagePoint), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(ScrollPagePoint));
			
			
			XUtils.EndClassRegister(typeof(ScrollPagePoint), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					ScrollPagePoint __cl_gen_ret = new ScrollPagePoint();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ScrollPagePoint constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnScrollPageChanged(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ScrollPagePoint __cl_gen_to_be_invoked = (ScrollPagePoint)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int pageCount = LuaAPI.xlua_tointeger(L, 2);
                    int currentPageIndex = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.OnScrollPageChanged( pageCount, currentPageIndex );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scrollPage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPagePoint __cl_gen_to_be_invoked = (ScrollPagePoint)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.scrollPage);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toggleGroup(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPagePoint __cl_gen_to_be_invoked = (ScrollPagePoint)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.toggleGroup);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_togglePrefab(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPagePoint __cl_gen_to_be_invoked = (ScrollPagePoint)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.togglePrefab);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scrollPage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPagePoint __cl_gen_to_be_invoked = (ScrollPagePoint)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.scrollPage = (ScrollPage)translator.GetObject(L, 2, typeof(ScrollPage));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toggleGroup(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPagePoint __cl_gen_to_be_invoked = (ScrollPagePoint)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.toggleGroup = (UnityEngine.UI.ToggleGroup)translator.GetObject(L, 2, typeof(UnityEngine.UI.ToggleGroup));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_togglePrefab(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ScrollPagePoint __cl_gen_to_be_invoked = (ScrollPagePoint)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.togglePrefab = (UnityEngine.UI.Toggle)translator.GetObject(L, 2, typeof(UnityEngine.UI.Toggle));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
