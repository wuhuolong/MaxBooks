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
    public class xcinstance_behaviourBossBehaviourRedefineBossInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossInfo), L, translator, 0, 0, 5, 5);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "id", _g_get_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "state", _g_get_state);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "refresh_time", _g_get_refresh_time);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "pos", _g_get_pos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "killers", _g_get_killers);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "id", _s_set_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "state", _s_set_state);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "refresh_time", _s_set_refresh_time);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "pos", _s_set_pos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "killers", _s_set_killers);
            
			XUtils.EndObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossInfo), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInfo", _m_GetInfo_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.instance_behaviour.BossBehaviour.RedefineBossInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.instance_behaviour.BossBehaviour.RedefineBossInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_ret = new xc.instance_behaviour.BossBehaviour.RedefineBossInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.instance_behaviour.BossBehaviour.RedefineBossInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInfo_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    Net.PkgBossInfo pkg_info = (Net.PkgBossInfo)translator.GetObject(L, 1, typeof(Net.PkgBossInfo));
                    
                        xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_ret = xc.instance_behaviour.BossBehaviour.RedefineBossInfo.GetInfo( pkg_info );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_state(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.state);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_refresh_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.refresh_time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.pos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_killers(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.killers);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_state(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.state = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_refresh_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.refresh_time = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.pos = (xc.instance_behaviour.BossBehaviour.RedefinePos)translator.GetObject(L, 2, typeof(xc.instance_behaviour.BossBehaviour.RedefinePos));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_killers(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.RedefineBossInfo __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.RedefineBossInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.killers = (System.Collections.Generic.List<xc.instance_behaviour.BossBehaviour.RedefineBossKiller>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.instance_behaviour.BossBehaviour.RedefineBossKiller>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
