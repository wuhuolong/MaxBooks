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
    public class xcuiRedPointWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.RedPoint), L, translator, 0, 1, 7, 7);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RefreshPosAndScale", _m_RefreshPosAndScale);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PointKey", _g_get_PointKey);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RedPointObj", _g_get_RedPointObj);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mPointKey", _g_get_mPointKey);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeltaX", _g_get_DeltaX);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DeltaY", _g_get_DeltaY);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Scale", _g_get_Scale);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mAssignRedPointObj", _g_get_mAssignRedPointObj);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PointKey", _s_set_PointKey);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AssignRedPointObj", _s_set_AssignRedPointObj);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mPointKey", _s_set_mPointKey);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeltaX", _s_set_DeltaX);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DeltaY", _s_set_DeltaY);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Scale", _s_set_Scale);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mAssignRedPointObj", _s_set_mAssignRedPointObj);
            
			XUtils.EndObjectRegister(typeof(xc.ui.RedPoint), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.RedPoint), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.RedPoint));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.RedPoint), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.RedPoint __cl_gen_ret = new xc.ui.RedPoint();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.RedPoint constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshPosAndScale(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RefreshPosAndScale(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PointKey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.PointKey);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RedPointObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.RedPointObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mPointKey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mPointKey);
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
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
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
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
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
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Scale);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mAssignRedPointObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mAssignRedPointObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PointKey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PointKey = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AssignRedPointObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AssignRedPointObj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mPointKey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mPointKey = LuaAPI.xlua_touint(L, 2);
            
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
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
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
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
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
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Scale = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mAssignRedPointObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.RedPoint __cl_gen_to_be_invoked = (xc.ui.RedPoint)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mAssignRedPointObj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
