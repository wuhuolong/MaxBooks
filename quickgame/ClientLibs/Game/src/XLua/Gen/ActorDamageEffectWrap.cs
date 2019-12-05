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
    public class ActorDamageEffectWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Actor.DamageEffect), L, translator, 0, 0, 4, 4);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "EffectType", _g_get_EffectType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Value", _g_get_Value);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShowPercent", _g_get_ShowPercent);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PushStr", _g_get_PushStr);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "EffectType", _s_set_EffectType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Value", _s_set_Value);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShowPercent", _s_set_ShowPercent);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PushStr", _s_set_PushStr);
            
			XUtils.EndObjectRegister(typeof(Actor.DamageEffect), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Actor.DamageEffect), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Actor.DamageEffect));
			
			
			XUtils.EndClassRegister(typeof(Actor.DamageEffect), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Actor.DamageEffect __cl_gen_ret = new Actor.DamageEffect();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Actor.DamageEffect constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EffectType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor.DamageEffect __cl_gen_to_be_invoked = (Actor.DamageEffect)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.EffectType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Value(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor.DamageEffect __cl_gen_to_be_invoked = (Actor.DamageEffect)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.Value);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShowPercent(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor.DamageEffect __cl_gen_to_be_invoked = (Actor.DamageEffect)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.ShowPercent);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PushStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor.DamageEffect __cl_gen_to_be_invoked = (Actor.DamageEffect)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.PushStr);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EffectType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor.DamageEffect __cl_gen_to_be_invoked = (Actor.DamageEffect)translator.FastGetCSObj(L, 1);
                xc.FightEffectHelp.FightEffectType __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.EffectType = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Value(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor.DamageEffect __cl_gen_to_be_invoked = (Actor.DamageEffect)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Value = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShowPercent(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor.DamageEffect __cl_gen_to_be_invoked = (Actor.DamageEffect)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShowPercent = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PushStr(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Actor.DamageEffect __cl_gen_to_be_invoked = (Actor.DamageEffect)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PushStr = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
