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
    public class xcinstance_behaviourBossBehaviourRedefinePosWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefinePos), L, translator, 0, 0, 2, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "px", _g_get_px);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "py", _g_get_py);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "px", _s_set_px);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "py", _s_set_py);
            
			XUtils.EndObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefinePos), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefinePos), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.instance_behaviour.BossBehaviour.RedefinePos));
			
			
			XUtils.EndClassRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefinePos), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.instance_behaviour.BossBehaviour.RedefinePos __cl_gen_ret = new xc.instance_behaviour.BossBehaviour.RedefinePos();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.instance_behaviour.BossBehaviour.RedefinePos constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_px(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefinePos __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefinePos)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.px);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_py(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefinePos __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefinePos)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.py);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_px(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefinePos __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefinePos)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.px = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_py(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefinePos __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefinePos)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.py = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
