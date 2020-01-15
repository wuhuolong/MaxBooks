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
    public class xcBuffBuffInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Buff.BuffInfo), L, translator, 0, 0, 3, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mAddHandle", _g_get_mAddHandle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mFinishedHandle", _g_get_mFinishedHandle);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mPeriodHandle", _g_get_mPeriodHandle);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mAddHandle", _s_set_mAddHandle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mFinishedHandle", _s_set_mFinishedHandle);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mPeriodHandle", _s_set_mPeriodHandle);
            
			XUtils.EndObjectRegister(typeof(xc.Buff.BuffInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Buff.BuffInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Buff.BuffInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.Buff.BuffInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Buff.BuffInfo __cl_gen_ret = new xc.Buff.BuffInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Buff.BuffInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mAddHandle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff.BuffInfo __cl_gen_to_be_invoked = (xc.Buff.BuffInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mAddHandle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mFinishedHandle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff.BuffInfo __cl_gen_to_be_invoked = (xc.Buff.BuffInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mFinishedHandle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mPeriodHandle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff.BuffInfo __cl_gen_to_be_invoked = (xc.Buff.BuffInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mPeriodHandle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mAddHandle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff.BuffInfo __cl_gen_to_be_invoked = (xc.Buff.BuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mAddHandle = translator.GetDelegate<xc.Buff.BuffInfo.FunctionHandle>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mFinishedHandle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff.BuffInfo __cl_gen_to_be_invoked = (xc.Buff.BuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mFinishedHandle = translator.GetDelegate<xc.Buff.BuffInfo.FunctionHandle>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mPeriodHandle(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Buff.BuffInfo __cl_gen_to_be_invoked = (xc.Buff.BuffInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mPeriodHandle = translator.GetDelegate<xc.Buff.BuffInfo.FunctionHandle>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
