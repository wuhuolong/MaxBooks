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
    public class xcuiLockIconWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.LockIcon), L, translator, 0, 1, 12, 11);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetSystemId", _m_SetSystemId);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RealObj", _g_get_RealObj);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Model", _g_get_Model);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SystemId", _g_get_SystemId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ExpectObj", _g_get_ExpectObj);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UseDefaultPos", _g_get_UseDefaultPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeltaX", _g_get_DeltaX);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeltaY", _g_get_DeltaY);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Scale", _g_get_Scale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TargetImage", _g_get_TargetImage);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UseDefaultColor", _g_get_UseDefaultColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ExpectColor", _g_get_ExpectColor);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GreyComponent", _g_get_GreyComponent);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Model", _s_set_Model);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SystemId", _s_set_SystemId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ExpectObj", _s_set_ExpectObj);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UseDefaultPos", _s_set_UseDefaultPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeltaX", _s_set_DeltaX);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeltaY", _s_set_DeltaY);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Scale", _s_set_Scale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TargetImage", _s_set_TargetImage);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "UseDefaultColor", _s_set_UseDefaultColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ExpectColor", _s_set_ExpectColor);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GreyComponent", _s_set_GreyComponent);
            
			XUtils.EndObjectRegister(typeof(xc.ui.LockIcon), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.LockIcon), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.LockIcon));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.LockIcon), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.LockIcon __cl_gen_ret = new xc.ui.LockIcon();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.LockIcon constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSystemId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint id = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.SetSystemId( id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RealObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.RealObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Model(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                translator.PushxcuiLockIconState(L, __cl_gen_to_be_invoked.Model);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SystemId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.SystemId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExpectObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ExpectObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseDefaultPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.UseDefaultPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeltaX(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.DeltaX);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeltaY(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.DeltaY);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Scale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Scale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TargetImage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.TargetImage);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseDefaultColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.UseDefaultColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExpectColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, __cl_gen_to_be_invoked.ExpectColor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GreyComponent(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.GreyComponent);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Model(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                xc.ui.LockIcon.State __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.Model = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SystemId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SystemId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExpectObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ExpectObj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UseDefaultPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UseDefaultPos = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeltaX(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DeltaX = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DeltaY(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DeltaY = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Scale(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Scale = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TargetImage(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TargetImage = (UnityEngine.UI.Image)translator.GetObject(L, 2, typeof(UnityEngine.UI.Image));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UseDefaultColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UseDefaultColor = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExpectColor(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                UnityEngine.Color __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.ExpectColor = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GreyComponent(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.LockIcon __cl_gen_to_be_invoked = (xc.ui.LockIcon)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GreyComponent = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
