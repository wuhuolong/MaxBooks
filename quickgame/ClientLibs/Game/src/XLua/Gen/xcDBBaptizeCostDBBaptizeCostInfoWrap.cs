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
    public class xcDBBaptizeCostDBBaptizeCostInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBBaptizeCost.DBBaptizeCostInfo), L, translator, 0, 0, 3, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Num", _g_get_Num);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CostDiamond", _g_get_CostDiamond);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CostGoods", _g_get_CostGoods);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Num", _s_set_Num);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CostDiamond", _s_set_CostDiamond);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CostGoods", _s_set_CostGoods);
            
			XUtils.EndObjectRegister(typeof(xc.DBBaptizeCost.DBBaptizeCostInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBBaptizeCost.DBBaptizeCostInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBBaptizeCost.DBBaptizeCostInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBBaptizeCost.DBBaptizeCostInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBBaptizeCost.DBBaptizeCostInfo __cl_gen_ret = new xc.DBBaptizeCost.DBBaptizeCostInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBBaptizeCost.DBBaptizeCostInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeCost.DBBaptizeCostInfo __cl_gen_to_be_invoked = (xc.DBBaptizeCost.DBBaptizeCostInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Num);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CostDiamond(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeCost.DBBaptizeCostInfo __cl_gen_to_be_invoked = (xc.DBBaptizeCost.DBBaptizeCostInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.CostDiamond);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CostGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeCost.DBBaptizeCostInfo __cl_gen_to_be_invoked = (xc.DBBaptizeCost.DBBaptizeCostInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CostGoods);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeCost.DBBaptizeCostInfo __cl_gen_to_be_invoked = (xc.DBBaptizeCost.DBBaptizeCostInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Num = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CostDiamond(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeCost.DBBaptizeCostInfo __cl_gen_to_be_invoked = (xc.DBBaptizeCost.DBBaptizeCostInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CostDiamond = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CostGoods(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeCost.DBBaptizeCostInfo __cl_gen_to_be_invoked = (xc.DBBaptizeCost.DBBaptizeCostInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CostGoods = (System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<uint, uint>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<uint, uint>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
