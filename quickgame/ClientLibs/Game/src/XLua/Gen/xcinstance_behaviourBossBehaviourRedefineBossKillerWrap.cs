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
    public class xcinstance_behaviourBossBehaviourRedefineBossKillerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossKiller), L, translator, 0, 0, 5, 5);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "time", _g_get_time);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "name", _g_get_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "team_id", _g_get_team_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "rid", _g_get_rid);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "aff_names", _g_get_aff_names);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "time", _s_set_time);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "name", _s_set_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "team_id", _s_set_team_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "rid", _s_set_rid);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "aff_names", _s_set_aff_names);
            
			XUtils.EndObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossKiller), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossKiller), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.instance_behaviour.BossBehaviour.RedefineBossKiller));
			
			
			XUtils.EndClassRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossKiller), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_ret = new xc.instance_behaviour.BossBehaviour.RedefineBossKiller();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.instance_behaviour.BossBehaviour.RedefineBossKiller constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_team_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.team_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.rid);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_aff_names(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.aff_names);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.time = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.name = LuaAPI.lua_tobytes(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_team_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.team_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rid(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.rid = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_aff_names(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossKiller __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossKiller)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.aff_names = (System.Collections.Generic.List<byte[]>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<byte[]>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
