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
    public class xcShieldManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ShieldManager), L, translator, 0, 4, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHideBulletEffect", _m_IsHideBulletEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHideBuffEffect", _m_IsHideBuffEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsHideBeattackEffect", _m_IsHideBeattackEffect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NomralMonsterVisible", _g_get_NomralMonsterVisible);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SummonMonsterVisible", _g_get_SummonMonsterVisible);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NomralMonsterVisible", _s_set_NomralMonsterVisible);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SummonMonsterVisible", _s_set_SummonMonsterVisible);
            
			XUtils.EndObjectRegister(typeof(xc.ShieldManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ShieldManager), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ShieldManager));
			
			
			XUtils.EndClassRegister(typeof(xc.ShieldManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ShieldManager __cl_gen_ret = new xc.ShieldManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ShieldManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHideBulletEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ShieldManager __cl_gen_to_be_invoked = (xc.ShieldManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor src_actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    Actor target_actor = (Actor)translator.GetObject(L, 3, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHideBulletEffect( src_actor, target_actor );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHideBuffEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ShieldManager __cl_gen_to_be_invoked = (xc.ShieldManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHideBuffEffect( actor );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsHideBeattackEffect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ShieldManager __cl_gen_to_be_invoked = (xc.ShieldManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Actor src_actor = (Actor)translator.GetObject(L, 2, typeof(Actor));
                    Actor target_actor = (Actor)translator.GetObject(L, 3, typeof(Actor));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsHideBeattackEffect( src_actor, target_actor );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ShieldManager __cl_gen_to_be_invoked = (xc.ShieldManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NomralMonsterVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ShieldManager __cl_gen_to_be_invoked = (xc.ShieldManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.NomralMonsterVisible);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SummonMonsterVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ShieldManager __cl_gen_to_be_invoked = (xc.ShieldManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.SummonMonsterVisible);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NomralMonsterVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ShieldManager __cl_gen_to_be_invoked = (xc.ShieldManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NomralMonsterVisible = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SummonMonsterVisible(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ShieldManager __cl_gen_to_be_invoked = (xc.ShieldManager)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SummonMonsterVisible = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
