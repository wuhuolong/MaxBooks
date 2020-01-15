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
    public class UnityEngineCanvasGroupWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.CanvasGroup), L, translator, 0, 1, 4, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsRaycastLocationValid", _m_IsRaycastLocationValid);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "alpha", _g_get_alpha);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "interactable", _g_get_interactable);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "blocksRaycasts", _g_get_blocksRaycasts);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ignoreParentGroups", _g_get_ignoreParentGroups);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "alpha", _s_set_alpha);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "interactable", _s_set_interactable);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "blocksRaycasts", _s_set_blocksRaycasts);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ignoreParentGroups", _s_set_ignoreParentGroups);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.CanvasGroup), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.CanvasGroup), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.CanvasGroup));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.CanvasGroup), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.CanvasGroup __cl_gen_ret = new UnityEngine.CanvasGroup();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.CanvasGroup constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsRaycastLocationValid(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.CanvasGroup __cl_gen_to_be_invoked = (UnityEngine.CanvasGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Vector2 sp;translator.Get(L, 2, out sp);
                    UnityEngine.Camera eventCamera = (UnityEngine.Camera)translator.GetObject(L, 3, typeof(UnityEngine.Camera));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsRaycastLocationValid( sp, eventCamera );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_alpha(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.CanvasGroup __cl_gen_to_be_invoked = (UnityEngine.CanvasGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.alpha);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_interactable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.CanvasGroup __cl_gen_to_be_invoked = (UnityEngine.CanvasGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.interactable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_blocksRaycasts(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.CanvasGroup __cl_gen_to_be_invoked = (UnityEngine.CanvasGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.blocksRaycasts);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ignoreParentGroups(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.CanvasGroup __cl_gen_to_be_invoked = (UnityEngine.CanvasGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ignoreParentGroups);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_alpha(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.CanvasGroup __cl_gen_to_be_invoked = (UnityEngine.CanvasGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.alpha = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_interactable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.CanvasGroup __cl_gen_to_be_invoked = (UnityEngine.CanvasGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.interactable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_blocksRaycasts(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.CanvasGroup __cl_gen_to_be_invoked = (UnityEngine.CanvasGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.blocksRaycasts = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ignoreParentGroups(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.CanvasGroup __cl_gen_to_be_invoked = (UnityEngine.CanvasGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ignoreParentGroups = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
