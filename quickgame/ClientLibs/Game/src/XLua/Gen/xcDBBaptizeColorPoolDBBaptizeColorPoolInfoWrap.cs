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
    public class xcDBBaptizeColorPoolDBBaptizeColorPoolInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo), L, translator, 0, 0, 3, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Color", _g_get_Color);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttrRatioMin", _g_get_AttrRatioMin);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AttrRatio", _g_get_AttrRatio);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Color", _s_set_Color);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttrRatioMin", _s_set_AttrRatioMin);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AttrRatio", _s_set_AttrRatio);
            
			XUtils.EndObjectRegister(typeof(xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo __cl_gen_ret = new xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Color(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo __cl_gen_to_be_invoked = (xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Color);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttrRatioMin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo __cl_gen_to_be_invoked = (xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.AttrRatioMin);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttrRatio(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo __cl_gen_to_be_invoked = (xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.AttrRatio);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Color(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo __cl_gen_to_be_invoked = (xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Color = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttrRatioMin(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo __cl_gen_to_be_invoked = (xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttrRatioMin = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AttrRatio(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo __cl_gen_to_be_invoked = (xc.DBBaptizeColorPool.DBBaptizeColorPoolInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AttrRatio = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
