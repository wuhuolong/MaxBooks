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
    public class UnityEngineUIHorizontalOrVerticalLayoutGroupWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup), L, translator, 0, 0, 5, 5);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "spacing", _g_get_spacing);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "childForceExpandWidth", _g_get_childForceExpandWidth);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "childForceExpandHeight", _g_get_childForceExpandHeight);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "childControlWidth", _g_get_childControlWidth);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "childControlHeight", _g_get_childControlHeight);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "spacing", _s_set_spacing);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "childForceExpandWidth", _s_set_childForceExpandWidth);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "childForceExpandHeight", _s_set_childForceExpandHeight);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "childControlWidth", _s_set_childControlWidth);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "childControlHeight", _s_set_childControlHeight);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.HorizontalOrVerticalLayoutGroup does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.spacing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_childForceExpandWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.childForceExpandWidth);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_childForceExpandHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.childForceExpandHeight);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_childControlWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.childControlWidth);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_childControlHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.childControlHeight);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.spacing = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_childForceExpandWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.childForceExpandWidth = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_childForceExpandHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.childForceExpandHeight = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_childControlWidth(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.childControlWidth = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_childControlHeight(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.HorizontalOrVerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.HorizontalOrVerticalLayoutGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.childControlHeight = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
