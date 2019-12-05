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
    public class xcinstance_behaviourBossBehaviourUpdateBossAffiItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem), L, translator, 0, 0, 3, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_player_id", _g_get_m_player_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_before_isAffi", _g_get_m_before_isAffi);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_now_isAffi", _g_get_m_now_isAffi);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_player_id", _s_set_m_player_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_before_isAffi", _s_set_m_before_isAffi);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_now_isAffi", _s_set_m_now_isAffi);
            
			XUtils.EndObjectRegister(typeof(xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem));
			
			
			XUtils.EndClassRegister(typeof(xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem __cl_gen_ret = new xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_player_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.m_player_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_before_isAffi(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_before_isAffi);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_now_isAffi(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.m_now_isAffi);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_player_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_player_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_before_isAffi(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_before_isAffi = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_now_isAffi(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem __cl_gen_to_be_invoked = (xc.instance_behaviour.BossBehaviour.UpdateBossAffiItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.m_now_isAffi = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
