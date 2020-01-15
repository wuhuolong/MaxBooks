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
    public class xcGuildTaskInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GuildTaskInfo), L, translator, 0, 0, 3, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "id", _g_get_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "num", _g_get_num);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "reward_state", _g_get_reward_state);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "id", _s_set_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "num", _s_set_num);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "reward_state", _s_set_reward_state);
            
			XUtils.EndObjectRegister(typeof(xc.GuildTaskInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GuildTaskInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GuildTaskInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.GuildTaskInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					int id = LuaAPI.xlua_tointeger(L, 2);
					int num = LuaAPI.xlua_tointeger(L, 3);
					int reward_state = LuaAPI.xlua_tointeger(L, 4);
					
					xc.GuildTaskInfo __cl_gen_ret = new xc.GuildTaskInfo(id, num, reward_state);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GuildTaskInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuildTaskInfo __cl_gen_to_be_invoked = (xc.GuildTaskInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuildTaskInfo __cl_gen_to_be_invoked = (xc.GuildTaskInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.num);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_reward_state(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuildTaskInfo __cl_gen_to_be_invoked = (xc.GuildTaskInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.reward_state);
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
			
                xc.GuildTaskInfo __cl_gen_to_be_invoked = (xc.GuildTaskInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.id = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuildTaskInfo __cl_gen_to_be_invoked = (xc.GuildTaskInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.num = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_reward_state(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GuildTaskInfo __cl_gen_to_be_invoked = (xc.GuildTaskInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.reward_state = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
