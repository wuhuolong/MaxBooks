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
    public class xcDBBaptizeAttrStandardDBBaptizeAttrStandardInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo), L, translator, 0, 0, 2, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LvStep", _g_get_LvStep);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BaseAttrs", _g_get_BaseAttrs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "LvStep", _s_set_LvStep);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BaseAttrs", _s_set_BaseAttrs);
            
			XUtils.EndObjectRegister(typeof(xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo __cl_gen_ret = new xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LvStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo __cl_gen_to_be_invoked = (xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.LvStep);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo __cl_gen_to_be_invoked = (xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BaseAttrs);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LvStep(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo __cl_gen_to_be_invoked = (xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.LvStep = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BaseAttrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo __cl_gen_to_be_invoked = (xc.DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BaseAttrs = (xc.ActorAttribute)translator.GetObject(L, 2, typeof(xc.ActorAttribute));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
