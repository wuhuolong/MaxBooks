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
    public class MonsterCreateParamWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Monster.CreateParam), L, translator, 0, 0, 7, 7);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "is_pet", _g_get_is_pet);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "summon", _g_get_summon);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "master", _g_get_master);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "time", _g_get_time);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "summonType", _g_get_summonType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "hasAI", _g_get_hasAI);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "summonByMonster", _g_get_summonByMonster);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "is_pet", _s_set_is_pet);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "summon", _s_set_summon);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "master", _s_set_master);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "time", _s_set_time);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "summonType", _s_set_summonType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "hasAI", _s_set_hasAI);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "summonByMonster", _s_set_summonByMonster);
            
			XUtils.EndObjectRegister(typeof(Monster.CreateParam), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Monster.CreateParam), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Monster.CreateParam));
			
			
			XUtils.EndClassRegister(typeof(Monster.CreateParam), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Monster.CreateParam __cl_gen_ret = new Monster.CreateParam();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Monster.CreateParam constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_is_pet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.is_pet);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_summon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.summon);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_master(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.master);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.time);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_summonType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                translator.PushMonsterMonsterType(L, __cl_gen_to_be_invoked.summonType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hasAI(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.hasAI);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_summonByMonster(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.summonByMonster);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_is_pet(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.is_pet = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_summon(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.summon = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_master(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.master = (xc.UnitID)translator.GetObject(L, 2, typeof(xc.UnitID));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_time(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.time = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_summonType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                Monster.MonsterType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.summonType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hasAI(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.hasAI = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_summonByMonster(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Monster.CreateParam __cl_gen_to_be_invoked = (Monster.CreateParam)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.summonByMonster = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
