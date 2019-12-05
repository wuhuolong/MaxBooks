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
    public class xcDBGuildBossDBGuildBossStatisticItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBGuildBoss.DBGuildBossStatisticItem), L, translator, 0, 1, 4, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanOpenMaxStar", _m_CanOpenMaxStar);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BossType", _g_get_BossType);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "MaxStar", _g_get_MaxStar);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TypeName", _g_get_TypeName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BossItemSortArray", _g_get_BossItemSortArray);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BossType", _s_set_BossType);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "MaxStar", _s_set_MaxStar);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TypeName", _s_set_TypeName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BossItemSortArray", _s_set_BossItemSortArray);
            
			XUtils.EndObjectRegister(typeof(xc.DBGuildBoss.DBGuildBossStatisticItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBGuildBoss.DBGuildBossStatisticItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBGuildBoss.DBGuildBossStatisticItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBGuildBoss.DBGuildBossStatisticItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_ret = new xc.DBGuildBoss.DBGuildBossStatisticItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBGuildBoss.DBGuildBossStatisticItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanOpenMaxStar(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossStatisticItem)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint world_level = LuaAPI.xlua_touint(L, 2);
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.CanOpenMaxStar( world_level );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BossType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossStatisticItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.BossType);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxStar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossStatisticItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.MaxStar);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TypeName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossStatisticItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.TypeName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BossItemSortArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossStatisticItem)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.BossItemSortArray);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BossType(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossStatisticItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BossType = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxStar(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossStatisticItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.MaxStar = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TypeName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossStatisticItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TypeName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BossItemSortArray(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBGuildBoss.DBGuildBossStatisticItem __cl_gen_to_be_invoked = (xc.DBGuildBoss.DBGuildBossStatisticItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BossItemSortArray = (System.Collections.Generic.List<xc.DBGuildBoss.DBGuildBossItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<xc.DBGuildBoss.DBGuildBossItem>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
