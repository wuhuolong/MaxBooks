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
    public class xcDBGuildBossDBGuildBossRewardItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGuildBoss.DBGuildBossRewardItem), L, translator, 0, 0, 4, 4);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "GoodsId", _g_get_GoodsId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RewardType", _g_get_RewardType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RewardDesc1", _g_get_RewardDesc1);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RewardDesc2", _g_get_RewardDesc2);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "GoodsId", _s_set_GoodsId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RewardType", _s_set_RewardType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RewardDesc1", _s_set_RewardDesc1);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RewardDesc2", _s_set_RewardDesc2);
            
			XUtils.EndObjectRegister(typeof(xc.DBGuildBoss.DBGuildBossRewardItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGuildBoss.DBGuildBossRewardItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGuildBoss.DBGuildBossRewardItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGuildBoss.DBGuildBossRewardItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBGuildBoss.DBGuildBossRewardItem __cl_gen_ret = new xc.DBGuildBoss.DBGuildBossRewardItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGuildBoss.DBGuildBossRewardItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GoodsId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossRewardItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossRewardItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.GoodsId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RewardType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossRewardItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossRewardItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RewardType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RewardDesc1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossRewardItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossRewardItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RewardDesc1);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RewardDesc2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossRewardItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossRewardItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RewardDesc2);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GoodsId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossRewardItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossRewardItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.GoodsId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RewardType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossRewardItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossRewardItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RewardType = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RewardDesc1(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossRewardItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossRewardItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RewardDesc1 = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RewardDesc2(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossRewardItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossRewardItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RewardDesc2 = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
