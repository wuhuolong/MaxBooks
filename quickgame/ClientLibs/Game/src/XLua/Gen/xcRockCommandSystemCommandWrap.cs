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
    public class xcRockCommandSystemCommandWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.RockCommandSystem.Command), L, translator, 0, 0, 2, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mSkillID", _g_get_mSkillID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CommandKey", _g_get_CommandKey);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mSkillID", _s_set_mSkillID);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CommandKey", _s_set_CommandKey);
            
			XUtils.EndObjectRegister(typeof(xc.RockCommandSystem.Command), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.RockCommandSystem.Command), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.RockCommandSystem.Command));
			
			
			XUtils.EndClassRegister(typeof(xc.RockCommandSystem.Command), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.RockCommandSystem.Command __cl_gen_ret = new xc.RockCommandSystem.Command();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.RockCommandSystem.Command constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mSkillID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.RockCommandSystem.Command __cl_gen_to_be_invoked = (xc.RockCommandSystem.Command)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.mSkillID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CommandKey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.RockCommandSystem.Command __cl_gen_to_be_invoked = (xc.RockCommandSystem.Command)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CommandKey);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mSkillID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.RockCommandSystem.Command __cl_gen_to_be_invoked = (xc.RockCommandSystem.Command)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mSkillID = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CommandKey(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.RockCommandSystem.Command __cl_gen_to_be_invoked = (xc.RockCommandSystem.Command)translator.FastGetCSObj(L, 1);
                xc.DBCommandList.OPFlag __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.CommandKey = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
