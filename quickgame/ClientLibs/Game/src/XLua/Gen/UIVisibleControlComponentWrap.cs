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
    public class UIVisibleControlComponentWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UIVisibleControlComponent), L, translator, 0, 0, 7, 7);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ControlChild", _g_get_m_ControlChild);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ChildList", _g_get_m_ChildList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleWarTypes", _g_get_VisibleWarTypes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InvisibleWarTypes", _g_get_InvisibleWarTypes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "VisibleWarSubTypes", _g_get_VisibleWarSubTypes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "InvisibleWarSubTypes", _g_get_InvisibleWarSubTypes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_SpecialFlagStr", _g_get_m_SpecialFlagStr);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ControlChild", _s_set_m_ControlChild);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ChildList", _s_set_m_ChildList);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "VisibleWarTypes", _s_set_VisibleWarTypes);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InvisibleWarTypes", _s_set_InvisibleWarTypes);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "VisibleWarSubTypes", _s_set_VisibleWarSubTypes);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "InvisibleWarSubTypes", _s_set_InvisibleWarSubTypes);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_SpecialFlagStr", _s_set_m_SpecialFlagStr);
            
			XUtils.EndObjectRegister(typeof(UIVisibleControlComponent), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UIVisibleControlComponent), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "UpdateVisibleState", _m_UpdateVisibleState_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UIVisibleControlComponent));
			
			
			XUtils.EndClassRegister(typeof(UIVisibleControlComponent), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UIVisibleControlComponent __cl_gen_ret = new UIVisibleControlComponent();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UIVisibleControlComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateVisibleState_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    
                    UIVisibleControlComponent.UpdateVisibleState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ControlChild(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_ControlChild);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ChildList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.m_ChildList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleWarTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleWarTypes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InvisibleWarTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InvisibleWarTypes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VisibleWarSubTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.VisibleWarSubTypes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InvisibleWarSubTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.InvisibleWarSubTypes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_SpecialFlagStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.m_SpecialFlagStr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ControlChild(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ControlChild = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ChildList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_ChildList = (UnityEngine.GameObject[])translator.GetObject(L, 2, typeof(UnityEngine.GameObject[]));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_VisibleWarTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.VisibleWarTypes = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InvisibleWarTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InvisibleWarTypes = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_VisibleWarSubTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.VisibleWarSubTypes = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_InvisibleWarSubTypes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.InvisibleWarSubTypes = (System.Collections.Generic.List<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<uint>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_SpecialFlagStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UIVisibleControlComponent __cl_gen_to_be_invoked = (UIVisibleControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_SpecialFlagStr = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
