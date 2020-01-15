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
    public class xcDBWorldBossDBWorldBossRewardItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBWorldBoss.DBWorldBossRewardItem), L, translator, 0, 0, 3, 3);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "goods_id", _g_get_goods_id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "goods_num", _g_get_goods_num);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "reward_type", _g_get_reward_type);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "goods_id", _s_set_goods_id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "goods_num", _s_set_goods_num);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "reward_type", _s_set_reward_type);
            
			XUtils.EndObjectRegister(typeof(xc.DBWorldBoss.DBWorldBossRewardItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBWorldBoss.DBWorldBossRewardItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBWorldBoss.DBWorldBossRewardItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBWorldBoss.DBWorldBossRewardItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBWorldBoss.DBWorldBossRewardItem __cl_gen_ret = new xc.DBWorldBoss.DBWorldBossRewardItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBWorldBoss.DBWorldBossRewardItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_goods_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossRewardItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossRewardItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.goods_id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_goods_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossRewardItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossRewardItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.goods_num);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_reward_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossRewardItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossRewardItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.reward_type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_goods_id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossRewardItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossRewardItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.goods_id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_goods_num(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossRewardItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossRewardItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.goods_num = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_reward_type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBWorldBoss.DBWorldBossRewardItem __cl_gen_to_be_invoked = (xc.DBWorldBoss.DBWorldBossRewardItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.reward_type = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
